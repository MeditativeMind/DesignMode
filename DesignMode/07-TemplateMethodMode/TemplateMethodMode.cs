using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TemplateMethodMode
{
    //模板方法模式
    public abstract class TemplateMethod
    {
        public void Procedure()
        {
            Debug.Log("Start");
            ProcedureA();
            ProcedureB();
            ProcedureC();
            Debug.Log("Stop");
        }
        private void ProcedureA()
        {
            Debug.Log("步骤1");
        }
        protected abstract void ProcedureB();
        private void ProcedureC()
        {
            Debug.Log("步骤3");
        }
    }
    public class TemplateA : TemplateMethod
    {
        protected override void ProcedureB()
        {
            Debug.Log("TemplateA的步骤B");
        }
    }
    public class TemplateB : TemplateMethod
    {
        protected override void ProcedureB()
        {
            Debug.Log("TemplateB的步骤B");
        }
    }
    public class TemplateMethodMode : MonoBehaviour
    {
        void Start()
        {
            TemplateMethod method = new TemplateA();
            method.Procedure();
            method = new TemplateB();
            method.Procedure();    
        }
    }
}
