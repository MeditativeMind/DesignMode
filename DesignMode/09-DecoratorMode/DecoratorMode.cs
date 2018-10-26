using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DecoratorMode
{
    //装饰模式


    class Person
    {
        public Person() { }
        private string name;
        public Person(string name)
        {
            this.name = name;
        }
        public virtual void Show()
        {
            Debug.Log("装饰的" + name);
        }
    }

    class Finery : Person //服饰类
    {
        protected Person component;
        //装饰的过程
        public void Decorator(Person component)
        {
            this.component = component;
        }
        public override void Show()
        {
            if (component != null)
            {
                component.Show();
            }
        }
    }
    class TShirt : Finery
    {
        public override void Show()
        {
            Debug.Log("T恤");
            base.Show();
        }
    }
    class Shoe : Finery
    {
        public override void Show()
        {
            Debug.Log("鞋子");
            base.Show();
        }
    }
    public class DecoratorMode : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Person self = new Person("自己");
            Shoe shoe = new Shoe();
            TShirt shirt = new TShirt();
            print("这种装扮是：");
            //装饰过程
            shirt.Decorator(self);//先穿T恤
            shoe.Decorator(shirt);//再穿鞋
            shoe.Show();
        }


    }
}
