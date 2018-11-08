using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InterpreterMode
{
    //解释器模式

    class PlayContext
    {
        public string PlayText { get; set; }
    }
    abstract class Expression
    {
        //解释器
        public void Interpreter(PlayContext context)
        {
            if (context.PlayText.Length == 0)
                return;
            string playKey = context.PlayText.Substring(0, 1);
            context.PlayText = context.PlayText.Substring(2);
            double playValue = double.Parse(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
            Excute(playKey, playValue);
        }
        public abstract void Excute(string key, double value);
    }

    class Note : Expression
    {
        public override void Excute(string key, double value)
        {
            string note = string.Empty;
            switch (key)
            {
                case "C":
                    note = "1";
                    break;
                case "D":
                    note = "2";
                    break;
                case "E":
                    note = "3";
                    break;
                case "F":
                    note = "4";
                    break;
                case "G":
                    note = "5";
                    break;
                case "A":
                    note = "6";
                    break;
                case "B":
                    note = "7";
                    break;
            }
            Debug.Log(note);

        }
    }
    class Scale : Expression
    {
        public override void Excute(string key, double value)
        {
            string scale = string.Empty;
            switch ((int)value)
            {
                case 1:
                    scale = "低音";
                    break;
                case 2:
                    scale = "中音";
                    break;
                case 3:
                    scale = "高音";
                    break;
            }
            Debug.Log(scale);
        }
    }

    public class InterpreterMode : MonoBehaviour
    {
        void Start()
        {
            PlayContext context = new PlayContext();
            context.PlayText = "O 2 E 0.5 G 0.5 A 3 E 0.5";
            Expression expression = null;
            while (context.PlayText.Length > 0)
            {
                string str = context.PlayText.Substring(0, 1);
                switch (str)
                {
                    case "O":
                        expression = new Scale();
                        break;
                }
                expression.Interpreter(context);
            }
        }

    }
}
