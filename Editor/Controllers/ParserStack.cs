using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Editor.Controllers
{
    public class ParserStack
    {

        private int top;
        private List<string> stack = new List<string>();


        public ParserStack()
        {
            top = -1;
        }

        public bool IsEmpty()
        {
            return (top < 0);
        }
        public void Push(string data)
        {
            stack.Add(data);
            ++top;
        }

        public string Pop()
        {
            string value = stack[top];
            stack.RemoveAt(top--);
            return value;
        }
    }
}