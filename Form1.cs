using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Task2_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int n;
            if (!CheckDataInput(out n))
            {
                MessageBox.Show("Введено неверное значение. Введите 2, 4 или 6", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            for (int i=0; i<n; i++)
            {
                dataGridView1.Columns[i].Width = 50;
                dataGridView1.Rows[i].Height = 50;
            };
            ClearCells(n);
            Matr mass = new Matr(n);
            Fishki fishki = new Fishki();
            List<Index> index_list = new List<Index>();
            MatrToGrid(n, mass);
            Main(ref mass, ref fishki, ref index_list);
            PaintCellAsync(index_list);
            //прикрутить Check 
            //огрaничить ввод размера матриц
        }

        private bool CheckDataInput(out int n)
        {
            n = int.Parse(textBox1.Text);
            if (n==2||n==4||n==6)
            {
                return true;
            }
            return false;
        }
        private void MatrToGrid(int n, Matr mass)
        {        
            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mass[i,j].Value;
                }
            }
        }

        private void Main(ref Matr mass, ref Fishki fishki, ref List<Index> index_list)
        {
            int i = 0;
            int j = 0;
            bool res = Domino.backtrack(i, j, ref mass, ref fishki, ref index_list);
            if (res)
            {
                textBox2.Text = "Успешно";
            }
            else
            {
                textBox2.Text = "Неудача";
            }
        }

        private void ClearCells(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        } 
        private async Task PaintCellAsync(List<Index> index_list)
        {
            int count = 0;
            foreach(Index item in index_list)
            {
                count++;
                await Task.Delay(1000);
                dataGridView1.Rows[item.X].Cells[item.Y].Style.BackColor = GetColor(count);
                dataGridView1.Rows[item.Xn].Cells[item.Yn].Style.BackColor = GetColor(count);
            }
            
        }

        private Color GetColor(int count)
        {
            switch(count)
            {
                case 1:
                case 18:
                    return Color.Moccasin;
                case 8:
                case 17:
                    return Color.Gold;
                case 2:
                case 15:
                    return Color.Red;
                case 3:
                case 16:
                    return Color.Maroon;
                case 7:
                case 11:
                    return Color.Green;

                case 4:
                case 12:
                    return Color.Navy;
                case 6:
                case 14:
                    return Color.RosyBrown;
                case 5:
                case 13:
                    return Color.YellowGreen;
                default:
                    return Color.Fuchsia;
            }
        }


        //private void PrintToTxt()
        //{
        //    Fishki prt = new Fishki();
        //    string writePath = @"C:\Users\vasil\OneDrive\Рабочий стол\Домино C#\data.txt";
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
        //        {
        //            foreach (Fishka item in prt.Dibs)
        //            {
        //                sw.Write(item.Value_1);
        //                sw.Write(" ");
        //                sw.WriteLine(item.Value_2);
        //                sw.WriteLine();
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
    }
}
