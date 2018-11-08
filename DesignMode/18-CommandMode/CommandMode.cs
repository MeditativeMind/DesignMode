using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommandMode
{
    //命令模式

    abstract class Command//抽象命令
    {
        protected Barbecuer receiver;
        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }
        //执行命令
        public abstract void ExcuteCommand();
    }

    // 具体命令
    class BakeMuttonCommand : Command//烤羊肉串命令
    {
        public BakeMuttonCommand(Barbecuer receiver) : base(receiver) { }
        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }
    class BackChickkenWingCommand : Command//烤鸡翅命令
    {
        public BackChickkenWingCommand(Barbecuer receiver) : base(receiver) { }
        public override void ExcuteCommand()
        {
            receiver.BackChickkenWing();
        }
    }


    // 烤肉串的人
    class Barbecuer
    {
        //烤羊肉
        public void BakeMutton()
        {
            Debug.Log("烤羊肉串");
        }
        //烤鸡翅
        public void BackChickkenWing()
        {
            Debug.Log("烤鸡翅");
        }
    }

    class Waiter //服务员
    {
        List<Command> orders = new List<Command>();
        // 设置订单
        public void SetOrder(Command command)
        {
            orders.Add(command);
            Debug.Log("增加订单：" + command.ToString() + " 时间：" + System.DateTime.Now);
        }
        //取消订单
        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Debug.Log("取消订单：" + command.ToString() + " 时间：" + System.DateTime.Now);
        }
        //通知执行
        public void Notify()
        {
            foreach (var item in orders)
            {
                item.ExcuteCommand();
            }
        }
    }

    public class CommandMode : MonoBehaviour
    {
        void Start()
        {
            // 开店前的准备
            Barbecuer boy = new Barbecuer();
            Command backChickkenWingCommand = new BackChickkenWingCommand(boy);
            Command bakeMuttonCommand = new BakeMuttonCommand(boy);
            Waiter girl = new Waiter();//服务员

            // 顾客点菜
            girl.SetOrder(backChickkenWingCommand);
            girl.SetOrder(bakeMuttonCommand);
            girl.Notify();
        }


    }
}
