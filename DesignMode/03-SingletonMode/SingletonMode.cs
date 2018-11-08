using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SingletonMode
{
    //单例模式：继承于MonoBehaviour 与不继承

    //1、泛型单例
    public class Singleton<T> where T : class, new()
    {
        //利用构造 来决定是否可以被继承
        Singleton()
        {

        }
        private static T _instance;
        private readonly static object mLock = new object();//加锁 不能同时实例化
                                                            //双重锁
        public static T GetInstance
        {
            get
            {
                if (_instance == null) //第一层为了保证 不直接访问锁而造成消耗内存
                {
                    lock (mLock)
                    {
                        if (_instance == null)//第二层为了保证不会出现多次实例化
                            _instance = new T();
                    }
                }
                return _instance;
            }
        }

    }

    //2、类的单例(无法被继承或者实例化)
    public class Single
    {
        private Single()
        {

        }
        private static Single _instance;
        private readonly static object mLock = new object();//加锁 不会出现多次实例化
                                                            //双重锁
        public static Single GetInstance
        {
            get
            {
                if (_instance == null) //第一层为了保证 不直接访问锁而造成消耗内存
                {
                    lock (mLock)
                    {
                        if (_instance == null)//第二层为了保证不会出现多次实例化
                            _instance = new Single();
                    }
                }
                return _instance;
            }
        }
    }
    //3、继承于MonoBehaviour
    public class SingletonMode : MonoBehaviour
    {
        //3.1 这种最简单的单例 但是会出现空引用（当另一个类在Awake中调用此类实例时候）
        public static SingletonMode _instance;
        private void Awake()
        {
            _instance = this;
        }
        //3.2  这种需要 new 一个GameObject
        private static SingletonMode instance;
        public static SingletonMode GetInstance
        {
            //这里同样可以使用锁机制 保证不会多次实例化
            get
            {
                if (instance == null) //第一层为了保证 不直接访问锁而造成消耗内存
                {
                    GameObject go = new GameObject("SingletonMode");
                    instance = go.AddComponent<SingletonMode>();
                }
                return instance;
            }
        }
    }
}
