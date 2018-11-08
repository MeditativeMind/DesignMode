using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IteratorMode
{
    //迭代器模式
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
    //聚集抽象类
    interface IAggregate
    {
        Iterator CreateIterator();
        object this[int index] { get;set; }
        int Count { get; }
    }
    //实际迭代器
    class ConcreteIterator : Iterator
    {
        private IAggregate aggregate;
        private int current = 0;
        public ConcreteIterator(IAggregate aggregate)
        {
            this.aggregate = aggregate;
        }
        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override object First()
        {
            return aggregate[0];
        }

        public override bool IsDone()
        {
            return current >= aggregate.Count ? true : false;
        }

        public override object Next()
        {
            object res = null;
            current++;
            if(current < aggregate.Count)
                res = aggregate[current];
            return res;
        }
    }
    //实际聚集类
    class ConcreteAggregate : IAggregate
    {
        private List<object> items = new List<object>();

        public object this[int index]
        {
            get
            {
                return items[index];
            }

            set
            {
                items.Insert(index,value);
            }
        }

        public int Count
        {
            get { return items.Count; }
        }

        public Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }
    public class IteratorMode : MonoBehaviour
    {
        void Start()
        {
            IAggregate aggregate = new ConcreteAggregate();
            aggregate[0] = "1";
            aggregate[1] = "2";
            aggregate[2] = "3";
            Iterator i = new ConcreteIterator(aggregate);
            while(!i.IsDone())
            {
                Debug.Log("当前值是："+i.CurrentItem());
                i.Next();
            }
        }
    }
}
