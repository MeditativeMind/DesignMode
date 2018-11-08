using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FlyweightMode
{
    //享元模式
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Debug.Log("具体Flyweight：" + extrinsicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Debug.Log("不共享的具体Flyweight：" + extrinsicstate);
        }
    }
    class FlyweightFactory
    {
        private Hashtable flyweight = new Hashtable();
        public FlyweightFactory()
        {
            flyweight.Add("X",new ConcreteFlyweight());
            flyweight.Add("Y", new ConcreteFlyweight());
            flyweight.Add("Z", new ConcreteFlyweight());
        }
        public Flyweight GetFlyweight(string key)
        {
            return (Flyweight)flyweight[key];
        }
    }


    public class FlyweightMode : MonoBehaviour
    {
        void Start()
        {
            int extrinsicstate = 2;
            FlyweightFactory f = new FlyweightFactory();
            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(extrinsicstate);
        }

    }
}
