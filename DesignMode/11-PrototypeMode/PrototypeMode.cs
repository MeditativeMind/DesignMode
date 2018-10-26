using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace PrototypeMode
{
    //原型模式
    
    //1、浅复制
    class Resume : ICloneable 
    {
        private string name;
        private string sex;
        private string age;
        private string company;
        public Resume(string name)
        {
            this.name = name;
        }
        //设置个人信息
        public void SetPersonalInfo(string sex, string age)
        {
            this.sex = sex;
            this.age = age;
        }
        //设置工作经历
        public void SetWorkExperience(string company)
        {
            this.company = company;
        }
        // 显示
        public void Display()
        {
            Debug.Log("name："+name);
            Debug.Log("age:"+age);
            Debug.Log("sex:" + sex);
            Debug.Log("工作经历：" + company);
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    //2、深复制
    class DeepResume : ICloneable
    {
        private string name;
        private string sex;
        private string age;
        private WorkExperience work;
        public DeepResume(string name)
        {
            Debug.Log("1");
            this.name = name;
            work = new WorkExperience();
        }
        private DeepResume(WorkExperience work)
        {
            Debug.Log("2");
            this.work = (WorkExperience)work.Clone();
        }
        //设置个人信息
        public void SetPersonalInfo(string sex, string age)
        {
            this.sex = sex;
            this.age = age;
        }
        //设置工作经历
        public void SetWorkExperience(string company)
        {
            work.Company = company;
        }
        // 显示
        public void Display()
        {
            Debug.Log("name：" + name);
            Debug.Log("age:" + age);
            Debug.Log("sex:" + sex);
            Debug.Log("工作经历：" + work.Company);
        }
        public object Clone()
        {
            DeepResume resume = new DeepResume(this.work);
            resume.name = this.name;
            resume.sex = sex;
            resume.age = age;
            return resume;
        }
    }

    class WorkExperience : ICloneable
    {
        public string Company;
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class PrototypeMode : MonoBehaviour
    {
        void Start()
        {
            //ShallowCopy();
            DeepCopy();
        }
        //1、浅复制
        void ShallowCopy()
        {

            Resume a = new Resume("路人A");
            a.SetPersonalInfo("男","20");
            a.SetWorkExperience("XX企业");
            Resume b = (Resume)a.Clone();
            b.SetWorkExperience("YY企业");
            Resume c = (Resume)a.Clone();
            c.SetPersonalInfo("男","21");
            c.SetWorkExperience("ZZ企业");
            a.Display();
            b.Display();
            c.Display();
        }
        //2、深复制  
        void DeepCopy()
        {
            DeepResume a = new DeepResume("路人A");
            a.SetPersonalInfo("男", "20");
            a.SetWorkExperience("XX企业");
            DeepResume b = (DeepResume)a.Clone();
            b.SetWorkExperience("YY企业");
            DeepResume c = (DeepResume)a.Clone();
            c.SetPersonalInfo("男", "21");
            c.SetWorkExperience("ZZ企业");
            a.Display();
            b.Display();
            c.Display();
        }

    }
}
