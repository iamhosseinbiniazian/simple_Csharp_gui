using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        TextBox[] txt;
        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            Form1.path_main = new int[19, 19];
            txt = new TextBox[19 * 19];
            for (int i = 0; i < 19 * 19; i++)
            {
                txt[i] = new TextBox();
            }
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                   
                    
                        txt[i + j * 19].Size = new System.Drawing.Size(20, 20);
                        txt[i + j * 19].Name = i.ToString() + j.ToString();
                        txt[i + j * 19].Location = new Point(i * 25, j * 25);
                        txt[i + j * 19].KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
                        this.Controls.Add(txt[i + j * 19]);
                   
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                   
                        Form1.path_main[i, j] =  Convert.ToInt32(txt[i + j * 19].Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
