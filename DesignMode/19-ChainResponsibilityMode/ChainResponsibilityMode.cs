using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainResponsibilityMode
{
    //职责链模式
    public class ChainResponsibilityMode : MonoBehaviour
    {
        void Start()
        {
            Manager common = new CommonManager();
            Manager majordomo = new MajordomoManager();
            Manager general = new GeneralManager();
            //设置上级
            common.SetSuperior(majordomo);//经理上级：总监
            majordomo.SetSuperior(general);//总监上级：总经理

            // 将请求全部给经理，客户端并不知道谁处理
            Request request1 = new Request
            {
                RequestType = "请假",
                RequestContent = "员工请1天假",
                Number = 1
            };
            common.Request(request1);

            Request request2 = new Request
            {
                RequestType = "请假",
                RequestContent = "员工请5天假",
                Number = 5
            };
            common.Request(request2);

            Request request3 = new Request
            {
                RequestType = "加薪",
                RequestContent = "员工请求加薪 500",
                Number = 500
            };
            common.Request(request3);

            Request request4 = new Request
            {
                RequestType = "加薪",
                RequestContent = "员工请求加薪 1000",
                Number = 1000
            };
            common.Request(request4);
        }
    }
    abstract class Manager //抽象管理者
    {
        protected string name;
        //管理者的上级
        protected Manager superior;

        public Manager(string name)
        {
            this.name = name;
        }
        //设置管理者的上级
        public void SetSuperior(Manager superior)
        {
            this.superior = superior;
        }
        //申请请求
        public abstract void Request(Request request);
    }

    // 请求
    class Request
    {
        public string RequestType;
        public string RequestContent;
        public int Number; //请求的数量
    }
    //经理
    class CommonManager : Manager
    {
        public CommonManager(string name = "经理") : base(name) { }

        public override void Request(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                string content = string.Format("{0}:{1} 数量 {2} 被批准", name, request.RequestContent, request.Number);
                Debug.Log(content);
            }
            else
            {
                if (superior != null)
                    superior.Request(request);
            }

        }
    }
    //总监
    class MajordomoManager : Manager
    {
        public MajordomoManager(string name = "总监") : base(name) { }

        public override void Request(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 5)
            {
                string content = string.Format("{0}:{1} 数量 {2} 被批准", name, request.RequestContent, request.Number);
                Debug.Log(content);
            }
            else
            {
                if (superior != null)
                    superior.Request(request);
            }

        }
    }
    //总经理
    class GeneralManager : Manager
    {
        public GeneralManager(string name = "总经理") : base(name) { }

        public override void Request(Request request)
        {
            if (request.RequestType == "请假")
            {
                string content = string.Format("{0}:{1} 数量 {2} 被批准", name, request.RequestContent, request.Number);
                Debug.Log(content);
            }
            else if (request.RequestType == "加薪" && request.Number <= 500)
            {
                string content = string.Format("{0}:{1} 数量 {2} 被批准", name, request.RequestContent, request.Number);
                Debug.Log(content);
            }
            else if (request.RequestType == "加薪" && request.Number > 500)
            {
                string content = string.Format("{0}:{1} 数量 {2} 再说吧", name, request.RequestContent, request.Number);
                Debug.Log(content);
            }

        }
    }
  
}

