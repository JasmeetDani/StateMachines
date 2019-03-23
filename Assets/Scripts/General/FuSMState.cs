using System;

namespace General
{
	public abstract class FuSMState
	{
		protected float activationLevel;

		// This can be used by subclasses to signify a transition
		// Using an Enum as return type below allows the sub classes to return an invalid
		// transition, which is not possible with an FSMState subclass
		// For now we can live with this
		// TODO : (revisit to fix this)
		protected Enum currentTransition;


		public virtual float LowerBound
		{
			get { return 0.0f; }
		}

		protected virtual float UpperBound
		{
			get { return 1.0f; }
		}


		protected bool Triggerable = false;

		public bool IsTriggerable
		{
			get { return Triggerable; }
		}


		public FuSMState(bool IsTriggerable)
		{
			Triggerable = IsTriggerable;
		}

					
		public virtual void init() {}
		
		public virtual void enter() {}

		// The method can be used by Fuzzy states to hook into events while
		// they are inactive and consequently not part of the update loop.
		// The state itself will have to take care of that it doesn't execute duplicate
		// code in enter() when it becomes active. Can we avoid this quirk altogether, needs
		// more thought, TODO : revisit
		public virtual void enterWhileInactive() {}

		// It doesn't seem that I need to make the below method as virtual
		// TODO : (resolve doubt : any alternative thoughts ??)
		public Enum checkTransitions()
		{
			return currentTransition;
		}
		
		public abstract void FixedUpdate();			// Need to be implmented by concrete FuSMState classes
		
		public abstract void Update();				// Need to be implmented by concrete FuSMState classes

		public virtual void exit() {}

		public float getActivation() 
		{
			CheckBounds ();

			return activationLevel;
		}

		// Used to reset the activation level of all states so as to make the FuSM reentrant
		public virtual void resetActivation()
		{
			if(IsTriggerable)
			{
				this.activationLevel = 0.0f;
			}
			else
			{
				this.activationLevel = 1.0f;
			}
		}


		// This method is used by the parent Fuzzy State Machine to set the default transition for
		// all the constituent states, so that they do not have to explicitly do that in their code
		// It can also be used by subclasses to signify a transition or they can set the
		// currentTransition directly, latter approach is taken in this project
		public void setCurrentTransition(Enum currentTransition)
		{
			this.currentTransition = currentTransition;
		}


		public void CheckLowerBound() 
		{
			if(activationLevel < LowerBound) 
				activationLevel = LowerBound;
		}

		private void CheckUpperBound()
		{
			if(activationLevel > UpperBound) 
				activationLevel = UpperBound;
		}

		private void CheckBounds()
		{
			CheckLowerBound(); 

			CheckUpperBound();
		}
	} 
}