using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProxyMode
{
    //代理模式
    interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
    class Pursuit : IGiveGift//追求者
    {
        Girl girl;
        public Pursuit(Girl girl)
        {
            this.girl = girl;
        }

        public void GiveChocolate()
        {
            Debug.Log("送给"+girl.Name+"巧克力");
        }

        public void GiveDolls()
        {
            Debug.Log("送给" + girl.Name + "洋娃娃");
        }

        public void GiveFlowers()
        {
            Debug.Log("送给" + girl.Name + "鲜花");
        }
    }
    class Proxy : IGiveGift //代理人
    {
        Pursuit boy;
        public Proxy(Girl girl)
        {
            boy = new Pursuit(girl);
        }
        public void GiveChocolate()
        {
            boy.GiveChocolate();
        }

        public void GiveDolls()
        {
            boy.GiveDolls();
        }

        public void GiveFlowers()
        {
            boy.GiveFlowers();
        }
    }

    class Girl //被追求者
    {
        public string Name;
    }

    public class ProxyMode : MonoBehaviour
    {
        void Start()
        {
            Girl girl = new Girl();
            girl.Name = "李娇娇";
            Proxy proxy = new Proxy(girl);
            proxy.GiveDolls();
            proxy.GiveFlowers();
            proxy.GiveChocolate();
        }

     
    }
}
