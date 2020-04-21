using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_20
{
    public class Fishki
    {
        private List<Fishka> dibs = new List<Fishka>();
        public List<Fishka> Dibs => dibs;
        public Fishki()
        {
            int cnt = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j=cnt; j < 7; j++)
                {
                    Fishka tmp2 = new Fishka(i, j);//Добавляем фишки
                    dibs.Add(tmp2);
                }
                cnt++;
            }
        }
    }
}
