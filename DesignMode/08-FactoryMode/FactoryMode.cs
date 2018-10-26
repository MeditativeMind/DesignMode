using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FactoryMode
{
    //工厂模式
    public abstract class Operation //抽象运算类
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
    class OperationSub : Operation
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
    public interface IFactory //抽象工厂类
    {
        Operation CreateOperation();
    }
    public class OperationAddFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationAdd();
        }
    }
    public class OperationSubFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationSub();
        }
    }
    public class OperationMulFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationMul();
        }
    }
    public class OperationDivFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationDiv();
        }
    }
    public class FactoryMode : MonoBehaviour
    {
        void Start()
        {
            IFactory operationAdd = new OperationAddFactory();
            Operation operation = operationAdd.CreateOperation();
            operation.NumberA = 1;
            operation.NumberB = 4;
            print("Resulut:" + operation.GetResult());
        }
    }
}
