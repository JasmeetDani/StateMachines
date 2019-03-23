using System;
using System.Collections.Generic;

namespace General
{
	// REF : AI Game Engine Programming : Brian Schwab
	public abstract class FuSMachine<T> : FSMState<T>
	{
		private List<FuSMState> states = new List<FuSMState>();

		private List<FuSMState> active_states = new List<FuSMState>();

		// cached list for use in Update()
		private List<FuSMState> non_active_states = new List<FuSMState>();
		private List<FuSMState> non_active_states_temp = new List<FuSMState>();


		public void addState(FuSMState state)
		{
			states.Add(state);
		}

		// Need to be implmented by concrete FuSMState classes	
		public abstract Enum getFallbackID();

#region IState_Overrides
		
		// TODO : are the overrides to be called only using the FSMState interface ??? (revisit)
		
		public override void init()
		{
			Enum ID = this.getID();

			foreach (FuSMState state in states) 
			{
				state.init();
								
				// We need to do this or we are screwed badly
				state.setCurrentTransition(ID);
			}
		}
		
		public override void enter()
		{
			foreach (FuSMState state in states) 
			{
				if(state.getActivation() > state.LowerBound)
				{
					state.enter();

					active_states.Add(state);
				}
				else
				{
					// Inactive non-triggerable states shouldn't exist on enter by design
					if(state.IsTriggerable)
					{
						state.enterWhileInactive();
					}

					non_active_states.Add(state);
				}
			}
		}

		public override Enum checkTransitions()
		{
			if(active_states.Count != 0)
			{
				foreach (FuSMState state in active_states) 
				{
					// The fuzzy states return the ID of the fuzzy state machine to 
					// signify no state change
					Enum ret = state.checkTransitions();

					Enum ID = this.getID();

					if(!ret.Equals(ID))
					{
						// Let us not forget to reset the currentTransition of the exiting state
						// Currently the Fuzzy State Machine doesn't support multiple fuzzy states
						// try to exit the parent state, I think it doesn't make any sense, that is the 
						// reason we reset the currentTransition on only one and only one exiting state
						// TODO : (revisit)
						state.setCurrentTransition(ID);

						foreach (FuSMState active_state in active_states) 
						{
							active_state.exit();
						}

						return ret;
					}
				}
			}
			else
			{
				// if no state is active we should move to fallback state
				return getFallbackID ();
			}

			return this.getID ();
		}
		
		public override void FixedUpdate()
		{
			// TODO : revisit below code as I am not sure what should go here
			foreach (FuSMState state in active_states) 
			{
				state.FixedUpdate();
			}
		}
		
		// TODO : The below function seems to be inefficient, revisit for optimization, if required
		public override void Update()
		{
			non_active_states_temp.Clear();

			for (int i = active_states.Count - 1; i >= 0; i--)
			{
				FuSMState state = active_states[i];

				if (!(state.getActivation() > state.LowerBound))
				{
					state.exit();

					active_states.RemoveAt(i);
				
					non_active_states_temp.Add(state);
				}
			}

			for (int i = non_active_states.Count - 1; i >= 0; i--)
			{
				FuSMState state = non_active_states[i];
				
				if (state.getActivation() > state.LowerBound)
				{
					state.enter();
					
					non_active_states.RemoveAt(i);
					
					active_states.Add(state);
				}
			}

			non_active_states.AddRange (non_active_states_temp);

			foreach (FuSMState state in active_states) 
			{
				state.Update();
			}
		}

		public override void exit()
		{
			foreach (FuSMState state in states) 
			{
				state.resetActivation();
			}

			active_states.Clear ();

			non_active_states.Clear ();
		}
		
#endregion

		// Unused for now
		private void reset()
		{
			foreach (FuSMState state in states) {
				state.exit();

				state.init();
			}
		}
	}
}