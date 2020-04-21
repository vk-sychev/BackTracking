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
        //Создать класс Index и сделать из него лист и передать его в PaintCell 




        //static public bool FindSolution(ref Matr mass, ref Fishki fishki, int i, int j)
        //{
        //    if (IsAllCellsFill(mass))
        //    {
        //        return true;
        //    }

        //    while (i < mass.Size)
        //    {
        //        while(j < mass.Size)
        //        {
        //            if (IsOk_Horizontal(mass, i, j))
        //            {
        //                fishki.Dibs.Remove(IsFishkaExist(ref fishki, mass[i, j].Value, mass[i, j + 1].Value));
        //                mass[i, j].IsUsed = true;
        //                mass[i, j + 1].IsUsed = true;
        //                if (IsOk_Horizontal(mass, i, j+2))
        //                {
        //                    FindSolution(ref mass, ref fishki, i, j+2);
        //                }
        //                else
        //                {
        //                    if (FindSolution(ref mass, ref fishki, i+1, 0))
        //                    {
        //                        return true;
        //                    }
        //                }
                        
        //            }
        //        }
        //    }
        //    return false;
        //}

        //static public bool Check(Matr mass)
        //{
        //    int d0 = 0, d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0;
        //    for (int i = 0; i < mass.Size; i++)
        //    {
        //        for (int j = 0; j < mass.Size; j++)
        //        {
        //            switch (mass[i,j].Value)
        //            {
        //                case (0):
        //                    d0++;
        //                    break;
        //                case (1):
        //                    d1++;
        //                    break;
        //                case (2):
        //                    d2++;
        //                    break;
        //                case (3):
        //                    d3++;
        //                    break;
        //                case (4):
        //                    d4++;
        //                    break;
        //                case (5):
        //                    d5++;
        //                    break;
        //                case (6):
        //                    d6++;
        //                    break;
        //            }

        //        }
        //    }
        //    if ((d0 > 8 || d1 > 8 || d2 > 8 || d3 > 8 || d4 > 8 || d5 > 8 || d6 > 8) ||
        //        (mass.Size == 2 && (d0 > 3 || d1 > 3 || d2 > 3 || d3 > 3 || d4 > 3 || d5 > 3 || d6 > 3)))
        //        return false;
        //    return true;
        //}

        //static private bool IsOk_Vertical(Matr mass, int i, int j)
        //{
        //    if (i == (mass.Size - 1))
        //    {
        //        return false;
        //    }

        //    if (!(mass[i, j].IsUsed) && !(mass[i + 1, j].IsUsed))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //static private bool IsOk_Horizontal(Matr mass, int i, int j)
        //{
        //    if (j >= (mass.Size - 1))
        //    {
        //        return false;
        //    }

        //    if (!(mass[i, j].IsUsed) && !(mass[i, j + 1].IsUsed))
        //    {
        //        return true;
        //    }
        //    return false;
        //}



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
