using System;

namespace General
{
	public abstract class FSMState<T> : IState
	{
		protected T ID;


		public abstract Enum getID();				// Need to be implmented by concrete FSMState classes

		public virtual void init() {}

		public virtual void enter() {}

		public abstract Enum checkTransitions();	// Need to be implmented by concrete FSMState classes

		public abstract void FixedUpdate();			// Need to be implmented by concrete FSMState classes

		public abstract void Update();				// Need to be implmented by concrete FSMState classes

		public virtual void LateUpdate() {}

		public virtual void OnAnimatorIKCallback(int layerIndex) {}

		public virtual void exit() {}
	}
}