using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//桥接模式
namespace BridgeMode
{
    public abstract class Implementor
    {
        public abstract void Operation();
    }
    public class Abstraction
    {
        public Implementor implementor;
        public virtual void Operation()
        {
            implementor.Operation();
        }
    }
    public class AbstractionA: Abstraction
    {
        public override void Operation()
        {
            Debug.Log("AbstractionA");
            base.Operation();
        }
    }
    public class ImplementorA : Implementor
    {
        public override void Operation()
        {
            Debug.Log("ImplementorA");
        }
    }
    public class ImplementorB : Implementor
    {
        public override void Operation()
        {
            Debug.Log("ImplementorB");
        }
    }

    public class BridgeMode : MonoBehaviour
    {
        void Start()
        {
            Abstraction abstraction = new AbstractionA();
            abstraction.implementor = new ImplementorA();
            abstraction.Operation();
        }
    }
}
