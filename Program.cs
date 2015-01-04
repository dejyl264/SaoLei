using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Project4
{
    public partial class Form1 : Form
    {
        //Button buttonTest;
        Button[] button = new Button[81];


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int t = i * 9 + j;
                    button[t] = new Button();
                    this.Controls.Add(button[t]);
                    button[t].Location = new System.Drawing.Point(j * 25, 25 * i);
                    button[t].Size = new System.Drawing.Size(25, 25);
                    button[t].UseVisualStyleBackColor = true;
                }
            }
            Thread.Sleep(1);
            Random autoRand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int gridNum = autoRand.Next(81);
                while (button[gridNum].Text == "@")
                {
                    gridNum = autoRand.Next(81);
                }
                button[gridNum].Text = "@";
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int t = i * 9 + j;
                    int cnt = 0;
                    if (button[t].Text == "@")
                    {
                        continue;
                    }
                    else
                    {
                        if ((i - 1 >= 0) && (j - 1 >= 0) && button[(i - 1) * 9 + j - 1].Text == "@")
                            cnt++;
                        if ((i >= 0) && (j - 1 >= 0) && button[i * 9 + j - 1].Text == "@")
                            cnt++;
                        if ((i + 1 < 9) && (j - 1 >= 0) && button[(i + 1) * 9 + j - 1].Text == "@")
                            cnt++;
                        if ((i - 1 >= 0) && (j >= 0) && button[(i - 1) * 9 + j].Text == "@")
                            cnt++;
                        if ((i + 1 < 9) && (j >= 0) && button[(i + 1) * 9 + j].Text == "@")
                            cnt++;
                        if ((i - 1 >= 0) && (j + 1 >= 0) && button[(i - 1) * 9 + j + 1].Text == "@")
                            cnt++;
                        if ((i >= 0) && (j + 1 < 9) && button[i * 9 + j + 1].Text == "@")
                            cnt++;
                        if ((i + 1 < 0) && (j + 1 < 0) && button[(i + 1) * 9 + j + 1].Text == "@")
                            cnt++;
                        button[t].Text = Convert.ToString(cnt);
                    }
                }
            }
        }
    }
}
