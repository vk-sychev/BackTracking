using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_20
{
    public class Matr
    {
        public int Size { get; set; }
        private Elem[,] mass = new Elem[100,100];
        public Matr (int size)
        {
            Size = size;
            Random rand = new Random();
            for  (int i=0; i<size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Elem tmp = new Elem(rand.Next(0, 6));
                    mass[i, j] = tmp;
                }
            }


        }
    public Elem this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
        }
    }
}
