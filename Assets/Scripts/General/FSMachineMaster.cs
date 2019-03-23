using System;

namespace General
{
	public class FSMachineMaster<T> : FSMachine<T>
	{
#region IState_Overrides
		
		public override Enum getID()
		{
			// Noone is going to call getID() for the master FSM, so what we return doesn't matter
			
			return null;
		}
		
		public override Enum checkTransitions()
		{
			// Noone is going to call checkTransitions() either, for the master FSM, so what we return
			// doesn't matter, its just coded to get through compilation
			
			return null;
		}
	
#endregion
	}
}