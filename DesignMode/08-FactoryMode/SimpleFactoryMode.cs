using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFactoryMode
{
    //简单工厂模式
    public abstract class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;
        public double NumberA
        {
            get { return _numberA; }
            set { _numberA = value; }
        }
        public double NumberB
        {
            get { return _numberB; }
            set { _numberB = value; }
        }
        public abstract double GetResult();
    }
    class OperationAdd : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }
    class OperationSub: Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }
    class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }
    class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB == 0)
               throw new Exception("除数不能为0");
            result = NumberA / NumberB;
            return result;
        }
    }
    class OperationFactory
    {
        public static Operation CreatOperate(string operate)
        {
            Operation operation = default(Operation);
            switch (operate)
            {
                case "+":
                    operation = new OperationAdd();
                    break;
                case "-":
                    operation = new OperationSub();
                    break;
                case "*":
                    operation = new OperationMul();
                    break;
                case "/":
                    operation = new OperationDiv();
                    break;
            }
            return operation;
        }
    }
    public class SimpleFactoryMode : MonoBehaviour
    {
        void Start()
        {
            Operation operation = default(Operation);
            operation = OperationFactory.CreatOperate("+");
            operation.NumberA = 1;
            operation.NumberB = 2;
            var res = operation.GetResult();
            print("Result:"+ res);
        }
    }
}
