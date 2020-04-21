using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_20
{
    public class Fishka
    {
        public int Value_1 { get; set; }
        public int Value_2 { get; set; }
        public bool IsUsed { get; set; }      

        public Fishka(int AValue_1, int AValue_2)
        {
            this.Value_1 = AValue_1;
            this.Value_2 = AValue_2;
            IsUsed = false;
        }
    }
}
