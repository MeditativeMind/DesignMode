using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdapterMode
{
    //适配器模式
    class Target
    {
        public virtual void Request()
        {
            Debug.Log("普通请求");
        }
    }
    class Adaptee//被适配者
    {
        public void SpecificRequest()
        {
            Debug.Log("特殊请求");
        }
    }
    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();
        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }


    public class AdapterMode : MonoBehaviour
    {
        void Start()
        {
            Target target = new Adapter();
            target.Request();
        }

    }
}
