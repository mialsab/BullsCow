using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace BullsCow
{
    public partial class Form1 : Form
    {
        private int find = 0;
        private int Ib = 0;
        private int[] masBX = new int[1000];
        private int[] masFind = new int[4];
        public Form1()
        {
            InitializeComponent();
            find = InitRand();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0, x1 = 0, f1 = 0;
            int[] masX = new int[4];
            int[] masF = new int[4];
            x = Convert.ToInt32(textBox1.Text);
            x1 = x;
            f1 = find;
            for (int i = 3; i >= 0; i--)
            {
                masX[i] = x % 10;
                masF[i] = find % 10;
                x = x / 10;
                find = find / 10;
            }
            find = f1;
            x = x1;
            int c = 0, b = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (masF[i] == masX[j] && i == j) b++;
                    else if (masF[i] == masX[j] && i != j) c++;
            if (b == 4)
            {
                textBox2.Text += "Congrats! = " + x;
            }
            else textBox2.Text += x + " bull=" + b + " cow=" + c + '\r' + '\n';
            masBX[Ib++] = b;
            masBX[Ib++] = c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 0;
            int flag1 = 0;
            var rand = new Random();
            int c = 0, b = 0, bl = 0;
            int[] masX = new int[4];
            masX[0] = 1;
            masX[1] = 0;
            masX[2] = 0;
            masX[3] = 0;
            int h = 0;
            while (flag1 == 0)
            {
                k++;
                b = 0;
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (masFind[i] == masX[j] && i == j) b++;
                        else if (masFind[i] == masX[j] && i != j) c++;

                if (b == 4)
                {
                    textBox2.Text += "Congrats!=" + masX[0] + "" + masX[1] + "" + masX[2] + "" + masX[3] + '\r' + '\n';
                    break;
                }

                if (h < 5)
                    if (b > bl) h++;
                    else
                        if (b < bl) { masX[h] = masX[h] - 1; h++; }
                    else masX[h] = masX[h] + 1;
                bl = b;

            }
            textBox2.Text += "iter=" + k + '\r' + '\n';

        }

        int InitRand()
        {
            int x = 0, x1 = 0, x2 = 0, x3 = 0, x4 = 0;
            var rand = new Random();
            x1 = rand.Next(1, 10);
            while (true)
            {
                x2 = rand.Next(0, 10);
                if (x1 != x2) break;
            }
            while (true)
            {
                x3 = rand.Next(0, 10);
                if (x3 != x2 && x3 != x1) break;
            }
            while (true)
            {
                x4 = rand.Next(0, 10);
                if (x4 != x2 && x3 != x4 && x4 != x1) break;
            }
            x = x1 * 1000 + x2 * 100 + x3 * 10 + x4;
            masFind[0] = x1;
            masFind[1] = x2;
            masFind[2] = x3;
            masFind[3] = x4;
            return x;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();          
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
