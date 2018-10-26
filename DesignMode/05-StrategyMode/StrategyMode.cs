using System;
using UnityEngine;
namespace StrategyMode
{
    //策略模式（政策模式）

    abstract class CashSuper//现金收费抽象类
    {
        public abstract double AcceptCash(double money);
    }
    class CashNormal : CashSuper //正常收费子类
    {
        public override double AcceptCash(double money)
        {
            return money;
        }
    }
    class CashRebate : CashSuper//打折收费子类
    {
        private double moneyRebate = 1;
        public CashRebate(double moneyRebate) //打折收费 初始化时 必须输入折扣率
        {
            this.moneyRebate = moneyRebate;
        }
        public override double AcceptCash(double money)
        {
            return money * moneyRebate;
        }
    }
    class CashReturn : CashSuper//返利收费子类
    {
        private double moneyCondition = 0.0;
        private double moneyReturn = 0.0;
        public CashReturn(double moneyCondition, double moneyReturn) //初始化时必须输入 满多少 和 返多少
        {
            this.moneyCondition = moneyCondition;
            this.moneyReturn = moneyReturn;
        }
        public override double AcceptCash(double money)
        {
            double result = money;
            if (money >= moneyCondition)
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;
            return result;
        }
    }

    class CashContext//策略管理
    {
        private CashSuper cs;
        public CashContext(CashSuper cashSuper)
        {
            cs = cashSuper;
        }
        public double GetResult(double money)
        {
            return cs.AcceptCash(money);
        }
    }

    public class StrategyMode : MonoBehaviour
    {
        void Start()
        {

        }


    }
}
