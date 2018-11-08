using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MementoMode
{
    //备忘录模式
    class Player
    {
        private int HP;
        private int MP;
        public void GetInitState()
        {
            HP = 100;
            MP = 100;
        }
        public void ShowState()
        {
            Debug.Log("HP:"+HP);
            Debug.Log("MP:"+MP);
        }
        public void Fight()//战斗
        {
            HP = 0;
            MP = 0;
        }
        public PlayerStateMemento SaveMemento()
        {
            return new PlayerStateMemento(HP,MP);
        }
        public void RecovertSate(PlayerStateMemento playerStateMemento)
        {
            HP = playerStateMemento.HP;
            MP = playerStateMemento.MP;
        }
    }
    class PlayerStateMemento
    {
        public int HP, MP;
        public PlayerStateMemento(int HP,int MP)
        {
            this.HP = HP;
            this.MP = MP;
        }
    }
    class PlayerStateCaretaker
    {
        private PlayerStateMemento stateMemento;
        public PlayerStateMemento StateMemento { get { return stateMemento; }set { stateMemento = value; } }
    }

    public class MementoMode : MonoBehaviour
    {
        void Start()
        {
            Player player = new Player();
            player.GetInitState();//初始化 
            player.ShowState();//显示初始化
            PlayerStateCaretaker playerStateCaretaker = new PlayerStateCaretaker();
            playerStateCaretaker.StateMemento = player.SaveMemento();//保存一下状态
            player.Fight();//战斗结束
            player.ShowState();//显示状态
            player.RecovertSate(playerStateCaretaker.StateMemento);//还原到保存的状态
            player.ShowState();
        }

    }
}
