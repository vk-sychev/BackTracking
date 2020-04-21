using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task2_20
{
    static public class Domino
    {
        static private int x, y;
        
        static private void NextStep(Matr mass)
        {
            for (int i = 0; i < mass.Size; i++)
            {
                for (int j = 0; j < mass.Size; j++)
                {
                    if (mass[i,j].IsUsed == false)
                    {
                        x = i; y = j;
                        return;
                    }
                }
            }
        }

        static public bool backtrack(int i, int j, ref Matr mass, ref Fishki fishki, ref List<Index> index_list)
        {
            bool added = false;
            //Движение вправо
            if (j + 1 < mass.Size)
            {
                if (mass[i, j].IsUsed == false && mass[i, j + 1].IsUsed == false)
                {
                    if (IsFishkaExist(ref fishki, mass[i,j].Value, mass[i, j + 1].Value) == true)
                    {
                        mass[i,j + 1].IsUsed = true;
                        mass[i,j].IsUsed = true;
                        index_list.Add(new Index(i, j, i, j + 1));
                        NextStep(mass);
                        backtrack(x, y, ref mass, ref fishki, ref index_list);
                        added = true;
                    }
                }
            }

            //Движение влево
            if (j - 1 >= 0)
            {
                if (mass[i, j].IsUsed == false && mass[i, j - 1].IsUsed == false)
                {
                    if (IsFishkaExist(ref fishki, mass[i, j].Value, mass[i, j - 1].Value) == true)
                    {
                        if (!added)
                        {
                            mass[i, j - 1].IsUsed = true;
                            mass[i, j].IsUsed = true;
                        }
                        index_list.Add(new Index(i, j, i, j - 1));
                        NextStep(mass);
                        backtrack(x, y, ref mass, ref fishki, ref index_list);
                        added = true;
                    }
                }
            }

            //Движение вверх
            if (i + 1 < mass.Size)
            {
                if (mass[i,j].IsUsed == false && mass[i + 1, j].IsUsed == false)
                {
                    if (IsFishkaExist(ref fishki, mass[i, j].Value, mass[i + 1, j].Value) == true)
                    {
                        if (!added)
                        {
                            mass[i + 1, j].IsUsed = true;
                            mass[i, j].IsUsed = true;
                        }                       
                        index_list.Add(new Index(i, j, i + 1, j));
                        NextStep(mass);
                        backtrack(x, y, ref mass, ref fishki, ref index_list);
                        added = true;
                    }
                }
            }

            //Движение вниз
            if (i - 1 >= 0)
            {
                if (mass[i, j].IsUsed == false && mass[i - 1, j].IsUsed == false)
                {
                    if (IsFishkaExist(ref fishki, mass[i, j].Value, mass[i - 1, j].Value) == true)
                    {
                        if (!added)
                        {
                            mass[i - 1, j].IsUsed = true;
                            mass[i, j].IsUsed = true;
                        }
                        index_list.Add(new Index(i, j, i - 1, j));
                        NextStep(mass);
                        backtrack(x, y, ref mass, ref fishki, ref index_list);
                        added = true;
                    }
                }
            }
            if (IsAllCellsFill(mass))
            {
                return true;
            }
            return false;
        }

        static private bool IsAllCellsFill(Matr mass)
        {
            for (int i = 0; i < mass.Size; i++)
            {
                for (int j = 0; j < mass.Size; j++)
                {
                    if (!mass[i, j].IsUsed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static private bool IsFishkaExist(ref Fishki fishki,int value_1, int value_2)
        {
            foreach(Fishka fishka in fishki.Dibs)
            {
                if ((fishka.Value_1==value_1 && fishka.Value_2 == value_2 && !fishka.IsUsed)||((fishka.Value_1 == value_2 && fishka.Value_2 == value_1 && !fishka.IsUsed)))
                {
                    fishka.IsUsed = true;
                    return true;
                }
            }
            return false;
        }
    }

}
