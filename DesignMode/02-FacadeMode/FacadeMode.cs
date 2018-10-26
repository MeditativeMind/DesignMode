using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FacadeMode
{
    //外观模式
    // 以做饭为例：每个厨师做自己的菜

    public class ChefA
    {
        public void MealA()
        {
            Debug.Log("A号厨师的菜");
        }
    }
    public class ChefB
    {
        public void MealB()
        {
            Debug.Log("B号厨师的菜");
        }
    }
    public class ChefC
    {
        public void MealC()
        {
            Debug.Log("C号厨师的菜");
        }
    }
    public class ChefD
    {
        public void MealD()
        {
            Debug.Log("D号厨师的菜");
        }
    }
    public class FacadeClass //外观类：服务员
    {
        ChefA chefA;
        ChefB chefB;
        ChefC chefC;
        ChefD chefD;
        public FacadeClass()
        {
            chefA = new ChefA();
            chefB = new ChefB();
            chefC = new ChefC();
            chefD = new ChefD();
        }
        public void Dine()//顾客要吃饭
        {
            chefA.MealA();
            chefB.MealB();
            chefC.MealC();
            chefD.MealD();
            Debug.Log("所有菜都做好了");
        }
    }
    public class FacadeMode : MonoBehaviour
    {
        FacadeClass facadeClass = new FacadeClass();

        void Start()
        {
            facadeClass.Dine();//顾客来吃饭了
        }

        void Update()
        {

        }
    }
}
