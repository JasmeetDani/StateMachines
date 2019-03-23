using System;
using System.Collections.Generic;

namespace General
{
    // REF : http://www.informit.com/articles/article.aspx?p=1592379&seqNum=1
    // Domain-Specific Languages: An Introductory Example : Martin Fowler
    // and AI Game Engine Programming : Brian Schwab
    public abstract class FSMachine<T> : FSMState<T>
    {
        private IState start;

        protected IState current;
        private Enum currentID;

        private Dictionary<Enum, IState> states = new Dictionary<Enum, IState>();


        public void addState(IState state)
        {
            states.Add(state.getID(), state);
        }

        // TODO : any better way of setting the start state ??? (revisit)
        public void setStartState(IState start)
        {
            this.start = start;
            this.current = start;
            this.currentID = start.getID();
        }

        public void startMachine()
        {
            this.init();

            start.enter();
        }

        #region IState_Overrides

        // TODO : are the overrides to be called only using the IState interface ??? (revisit)

        public override void init()
        {
            // TODO (revisit) : Any more efficient way of traversing a dictionary values
            foreach (IState entry in states.Values)
            {
                entry.init();
            }
        }

        public override void enter()
        {
            start.enter();
        }

        public override void FixedUpdate()
        {
            current.FixedUpdate();
        }

        public override void Update()
        {
            Enum newStateID = current.checkTransitions();

            if (!newStateID.Equals(currentID))
            {
                transitionTo(states[newStateID]);
            }

            current.Update();
        }

        public override void exit()
        {
            start.exit();
        }

        #endregion

        private void transitionTo(IState newState)
        {
            current.exit();

            current = newState;
            currentID = newState.getID();

            newState.enter();
        }

        // Unused for now
        private void reset()
        {
            current.exit();

            current = start;
            currentID = start.getID();

            // TODO (revisit) : Any more efficient way of traversing a dictionary values
            foreach (IState entry in states.Values)
            {
                entry.init();
            }

            start.enter();
        }
    }
}