using System.Collections.Generic;
using UnityEngine;

namespace VisitorMode
{
    //访问者模式
    abstract class Action
    {
        //得到男人反应
        public abstract void GetManConclusion(Man man);
        //得到女人反应
        public abstract void GetWomanConclusion(Woman woman);
    }
    abstract class Person
    {
        public abstract void Accept(Action action);
    }
    //行为
    class Success : Action
    {
        public override void GetManConclusion(Man man)
        {
            Debug.Log(man.GetType().Name +GetType().Name + "背后有一个伟大的女人");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Debug.Log(woman.GetType().Name + GetType().Name + "背后有一个不成功的男人");
        }
    }
    class Faling : Action
    {
        public override void GetManConclusion(Man man)
        {
            Debug.Log(man.GetType().Name + GetType().Name + "背后有一个伟大的女人");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Debug.Log(woman.GetType().Name + GetType().Name + "背后有一个不成功的男人");
        }
    }

    // 状态
    class Man : Person
    {
        public override void Accept(Action action)
        {
            action.GetManConclusion(this);
        }
    }
    class Woman : Person
    {
        public override void Accept(Action action)
        {
            action.GetWomanConclusion(this);
        }
    }

    //对象结构
    class ObjectStrucute
    {
        private List<Person> list = new List<Person>();

        public void Add(Person person)
        {
            list.Add(person);
        }
        public void Remove(Person person)
        {
            list.Remove(person);
        }
        public void Show(Action action)
        {
            foreach (var item in list)
            {
                item.Accept(action);
            }
        }
    }
    public class VisitorMode : MonoBehaviour
    {
        void Start()
        {
            ObjectStrucute objectStrucute = new ObjectStrucute();

            objectStrucute.Add(new Man());
            objectStrucute.Add(new Woman());

            objectStrucute.Show(new Success());
        }

    }
}
