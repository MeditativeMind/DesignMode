using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMode
{


    //状态模式
    public interface IState
    {
        void Handle(Context args);
    }
    public class StateA : IState
    {
        public void Handle(Context args)
        {
            if (args.ToString() != this.ToString())
            {
                Debug.Log("Change to StateA");
                args.SetState(this);
            }
            Debug.Log("StateA:" + args);
        }
    }
    public class StateB : IState
    {
        public void Handle(Context args)
        {
            if (args.ToString() != this.ToString())
            {
                Debug.Log("Change to StateB");
                args.SetState(this);
            }
            Debug.Log("StateB:" + args);
        }
    }
    public class Context
    {
        private IState state;
        public void SetState(IState state)
        {
            this.state = state;
        }
        public void Handle(Context args)
        {
            state.Handle(args);
        }
        public override string ToString()
        {
            return state.GetType().Name;
        }
    }
    public class StateMode : MonoBehaviour
    {

        void Start()
        {
            Context context = new Context();
            StateA stateA = new StateA();
            StateB stateB = new StateB();
            context.SetState(stateA);
            stateA.Handle(context);
            stateB.Handle(context);
        }


    }
}
