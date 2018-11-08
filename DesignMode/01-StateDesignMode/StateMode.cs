using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMode
{
    //状态模式
    public class Work
    {
        private IState state;
        public Work()
        {
            state = new ForenoonState();
        }
        public double Hour;
        public void SetState(IState state)
        {
            this.state = state;
        }
        public void WriteProgram()
        {
            state.WriteProgram(this);
        }
    }



    public abstract class IState
    {
        public abstract void WriteProgram(Work work);
    }
    public class ForenoonState : IState
    {
        public override void WriteProgram(Work work)
        {
            if(work.Hour < 12)
            {
                Debug.Log("当前时间"+ work.Hour + "点 上午工作状态");
            }
            else
            {
                work.SetState(new NoonState());
                work.WriteProgram();
            }
        }
    }
    public class NoonState : IState
    {
        public override void WriteProgram(Work work)
        {
            if (work.Hour < 13)
            {
                Debug.Log("当前时间" + work.Hour + "点 中午吃饭状态");
            }
            else
            {
                work.SetState(new AfterNoonState()); work.WriteProgram();
            }
        }
    }
    public class AfterNoonState : IState
    {
        public override void WriteProgram(Work work)
        {
            if (work.Hour < 18)
            {
                Debug.Log("当前时间" + work.Hour + "点 下午工作状态");
            }
            else
            {
                Debug.Log("当前时间" + work.Hour + " 下班了");
            }
        }
    }



    public class StateMode : MonoBehaviour
    {
        void Start()
        {
            Work work = new Work();
            work.Hour = 9;
            work.WriteProgram();
            work.Hour = 12;
            work.WriteProgram();
            work.Hour = 13;
            work.WriteProgram();
            work.Hour = 19;
            work.WriteProgram();
        }


    }
}
