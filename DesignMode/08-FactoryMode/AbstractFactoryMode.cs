using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AbstractFactoryMode
{
    //抽象工厂模式  
    class User
    {
       
    }

    interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    } //抽象用户类
    class SqlserverUser : IUser
    {
        public User GetUser(int id)
        {
            Debug.Log("Sqlserver通过" + id + "得到用户");
            return null;
        }

        public void Insert(User user)
        {
            Debug.Log("在Sqlserver向数据库插入数据");
        }
    }
    class AccessUser : IUser
    {
        public User GetUser(int id)
        {
            Debug.Log("AccessUser通过" + id + "得到用户");
            return null;
        }

        public void Insert(User user)
        {
            Debug.Log("在AccessUserr向数据库插入数据");
        }
    }

    interface IFactory //抽象工厂类
    {
        IUser CreateUser();
    }
    class SqlserverFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }
    }
    class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
    }
    // 添加数据 重复
    public class AbstractFactoryMode : MonoBehaviour
    {
        void Start()
        {
            User user = new User();
            IFactory factory = new SqlserverFactory();
            IUser iu = factory.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);
        }
    }
}
