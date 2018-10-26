using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BuilderMode
{
    //建造者模式

    class Product
    {
        List<string> parts = new List<string>();
        public void Add(string part) //添加零件
        {
            parts.Add(part);
        }
        public void Show()
        {
            Debug.Log("---------产品 展示-----------------");
            foreach (var item in parts)
            {
                Debug.Log("零件："+item);
            }
            Debug.Log("---------展示 完毕-----------------");
        }
    }
    //抽象建造者
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }
    class BuilderA : Builder
    {
        private Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("部件A");
        }

        public override void BuildPartB()
        {
            product.Add("部件B");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
    //指挥建造
    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    public class BuilderMode : MonoBehaviour
    {
        void Start()
        {
            Director director = new Director();//创建指挥者
            Builder builder = new BuilderA();
            director.Construct(builder);//开始建造
            Product product = builder.GetResult();//返回一个建好的产品
            product.Show();//将产品展示
        }
    }
}
