using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverMode
{
    //观察者模式

    //抽象通知者
    abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();
        //增加观察者
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        //移除观察者
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var item in observers)
            {
                item.Update();
            }
        }
    }

    //抽象观察者
    abstract class Observer
    {
        public abstract void Update();
    }


    //具体通知类
    class ConcreteSubject : Subject
    {
        public string SubjectState;
    }
    //具体观察者
    class ConcreteObserver : Observer
    {
        private string name;
        private string observerState;
        private ConcreteSubject subject;
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this.name = name;
            this.subject = subject;
        }
        public ConcreteSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public override void Update()
        {
            observerState = subject.SubjectState;
            Debug.Log("观察者" + name + "的新状态是" + observerState);
        }
    }

    public class ObserverMode : MonoBehaviour
    {
        void Start()
        {
            ConcreteSubject subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject, "x"));
            subject.Attach(new ConcreteObserver(subject, "y"));
            subject.SubjectState = "XY";
            subject.Notify();

        }
    }
}
