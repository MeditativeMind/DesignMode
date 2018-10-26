using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MediatorMode
{
    public abstract class IMediator
    {
        protected abstract void Out(string name, IRoom room);
        protected abstract bool Find(IRoom room);
    }
    public interface IRoom
    {
        bool isOut { get; }
        void Out();
    }
    public class Mediator : IMediator
    {
        private RoomOriginA roomOriginA;
        private RoomOriginB roomOriginB;
        public Mediator()
        {
            roomOriginA = new RoomOriginA(); roomOriginB = new RoomOriginB();
        }
        public void Renting(string name)//租房
        {
            Debug.Log(name + "要租房");
            if (Find(roomOriginA))
            {
                Out(name, roomOriginA);
                return;
            }
            if (Find(roomOriginB))
            {
                Out(name, roomOriginB);
                return;
            }
            Debug.Log("没房子了");
        }
        protected override bool Find(IRoom room)
        {
            if (!room.isOut)
            {
                Debug.Log("还没有租出去的房间：" + room.GetType().Name);
                return true;
            }
            else
            {
                Debug.Log("租出去的房间：" + room.GetType().Name);
                return false;
            }
        }

        protected override void Out(string name, IRoom room)
        {
            Debug.Log("将房间出租给：" + name);
            room.Out();
            Debug.Log(name + "　租房完成");
        }
    }
    public class RoomOriginA : IRoom
    {
        private bool IsOutRoom { get; set; }
        public RoomOriginA()
        {
            IsOutRoom = false;
        }

        public bool isOut
        {
            get
            {
                return IsOutRoom;
            }
        }

        public void Out()
        {
            IsOutRoom = true;
        }
    }
    public class RoomOriginB : IRoom
    {
        private bool IsOutRoom { get; set; }
        public RoomOriginB()
        {
            this.IsOutRoom = false;
        }

        public bool isOut
        {
            get
            {
                return this.IsOutRoom;
            }
        }

        public void Out()
        {
            this.IsOutRoom = true;
        }
    }
    public class MediatorMode : MonoBehaviour
    {
        private string nameA = "张三";
        private string nameB = "李四";
        private string nameC = "张四";
        // Use this for initialization
        void Start()
        {
            Mediator mediator = new Mediator();
            mediator.Renting(nameA);
            mediator.Renting(nameB);
            mediator.Renting(nameC);
        }
    }
}
