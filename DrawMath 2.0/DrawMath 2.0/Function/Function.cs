using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawMath
{
    public class Function
    {
        private string input;

        public void SetInput(string value)
        {
            input = value.ToLower();
        }
        public string GetInput()
        {
            return input;
        }
    }
}
