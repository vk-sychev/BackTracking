using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_20
{
    public class Elem
    {
        public int Value { get; set; }
        public bool IsUsed { get; set; }
        public Elem(int Avalue)
        {
            Value = Avalue;
            IsUsed = false;
        }
    }
}
