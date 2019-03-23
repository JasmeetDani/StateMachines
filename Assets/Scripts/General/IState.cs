using System;

namespace General
{
	public interface IState
	{
		Enum getID();
		
		void init();
		
		void enter();	
		
		Enum checkTransitions();
		
		void FixedUpdate();
		
		void Update();
		
		void exit();
	}
}