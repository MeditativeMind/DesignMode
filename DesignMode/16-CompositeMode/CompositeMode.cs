using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CompositeMode
{
    // 组合模式 透明方式（叶子节点也继承于Component）
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }
    //叶子节点
    class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public override void Add(Component component)
        {
            Debug.Log("Connot add to a leaf");
        }

        public override void Display(int depth)
        {
            Debug.Log(new string('-', depth) + name);
        }

        public override void Remove(Component component)
        {
            Debug.Log("Connot remove to a leaf");
        }
    }
    //枝节点
    class Composite : Component
    {
        public Composite(string name) : base(name) { }
        private List<Component> children = new List<Component>();
        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Display(int depth)
        {
            Debug.Log(new string('-', depth) + name);
            foreach (var item in children)
            {
                item.Display(depth + 2);
            }
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }
    }

    public class CompositeMode : MonoBehaviour
    {
        void Start()
        {
            Composite root = new Composite("根节点");
            root.Add(new Leaf("左边叶子"));
            root.Add(new Leaf("右边叶子"));

            Composite com = new Composite("左树枝");
            com.Add(new Leaf("左树枝的叶子"));
            root.Add(com);
            root.Display(1);
            // ... 
        }

    }
}
