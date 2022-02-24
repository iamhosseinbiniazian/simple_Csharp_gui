using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] title = { "Fp1", "Fp2", "F3", "F4", "C3", "C4", "P3", "P4", "O1", "O2", "F7", "F8", "T3",
                             "T4", "T5", "T6", "Fz", "Cz", "Pz" };
        public static int[,] path_main;
        Color[] color ={Color.Red,Color.Blue,Color.Green,Color.Yellow,Color.Black,
                         Color.Purple,Color.Gray,Color.Pink,Color.Orange,Color.Olive,Color.LimeGreen,Color.LightGray,
                         Color.DarkCyan,Color.Gold,Color.SkyBlue,Color.Cyan,Color.LightGreen,Color.LightPink,Color.Cyan,Color.DarkGoldenrod};
     public struct point {
           public float x;
            public float y;
        };
        private void button1_Click(object sender, EventArgs e)
        {
            /* System.Drawing.Graphics surface3 = this.CreateGraphics();
             Pen pen1 = new Pen(Color.Blue);
             Pen pen2 = new Pen(Color.Red);
             double x1 = Math.Sqrt(Math.Pow(150 - 100,2) + Math.Pow(150 - 100,2));
             double x2 = x1 / 2;
             double teta=Math.Atan(100/100);
             double xnew = 100 - x2 * Math.Cos(teta);
             MessageBox.Show((((float)Math.Atan(150 / 150))*(180/Math.PI)).ToString());
             double ynew = 100 + x2 * Math.Sin(teta);
             surface3.DrawArc(pen1, new Rectangle((int)(xnew), (int)ynew, (int)x1, (int)x1), (float)(((float)Math.Atan(150 / 150)) * (180 / Math.PI)), 180);
             surface3.DrawRectangle(pen1, (int)(xnew), (int)ynew, (int)x1, (int)x1);
             //surface3.DrawArc(pen1, new Rectangle((int)(100 - x2/2), 100, (int)( x2), 300 - 100), 90, 180);*/
            float lastangle = 0;
            float radius = 300;
            Graphics myGraphics;
            point[] p=new point[19];
            myGraphics = this.CreateGraphics();
            Pen myPen;
            Pen bluePen = new Pen(Color.Blue, 1);
            Pen greenPen = new Pen(Color.Green, 3);
            SolidBrush MySolidBrush = new SolidBrush(Color.Red);
            myGraphics.Clear(Color.White);
            int index = 0;
            float angle=0;
            float x,y;
            for (float i = 0.0f; i < 360.0; i += 19)
            {
                

                for (float iii = i; iii < i + 19;iii+=0.1f )
                {
                    angle = (float)(iii * Math.PI / 180);
                     x = (float)(350 + radius * Math.Cos((double)angle));
                     y = (float)(350 + radius * Math.Sin((double)angle));
                    PutPixel1(myGraphics, (int)x, (int)y, color[index]);
                  //  System.Threading.Thread.Sleep(1); // If you want to draw circle very slowly.
                    if (i+8.5<iii&& iii<i + 8.7)
                    {
                        p[index].x = x;
                        p[index].y = y;
                          x = (float)(350 +( radius+25 )* Math.Cos((double)angle));
                          y = (float)(350 + (radius+25 )* Math.Sin((double)angle));
                        if(index<19){
                        FontFamily fontFamily = new FontFamily("Arial");
                    Font font = new Font(
                     fontFamily,
                        16,
                        FontStyle.Regular,
                        GraphicsUnit.Pixel);
                    myGraphics.DrawString(title[index], font, MySolidBrush, x, y);
                            }
                    }
          
                }
                index++;
            }
          for (int ii = 0; ii < 19; ii++)
            {
                for (int jj= 0; jj <19; jj++)
                {
                    if (path_main[ii, jj] == 1)
                    {
                        radius = (float)(Math.Sqrt(Math.Pow(p[jj].x - p[ii].x, 2) + Math.Pow(p[jj].y - p[ii].y, 2)) / 2);
                        if (radius < 250)
                        {
                        for (float i = 0.0f; i < 360.0; i += 0.1f)
                        {
                            angle = (float)(i * Math.PI / 180);
                            x = (float)((p[ii].x + p[jj].x) / 2 + radius * Math.Cos((double)angle));
                            y = (float)((p[ii].y + p[jj].y) / 2 + radius * Math.Sin((double)angle));
                            float condi = (float)Math.Pow(x - 350, 2) + (float)Math.Pow(y - 350, 2);
                           
                                if (condi <= Math.Pow(300, 2))
                                {
                                    PutPixel(myGraphics, (int)x, (int)y, Color.Blue);
                                }
                            
                        }
                                } 
                         else {

                                myGraphics.DrawLine(bluePen, p[ii].x, p[ii].y, p[jj].x, p[jj].y);
                            }
                    }
                }
            }
            }
        void PutPixel(Graphics g, int x, int y, Color c)
        {
            Bitmap bm = new Bitmap(1,1);
            bm.SetPixel(0, 0,c);
            g.DrawImageUnscaled(bm, x, y);
        }
        void PutPixel1(Graphics g, int x, int y, Color c)
        {
            Bitmap bm = new Bitmap(6, 6);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j <6; j++)
                {
                    bm.SetPixel(i, j, c);  
                }
            }
            
            g.DrawImageUnscaled(bm, x, y);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form2 f = new Form2();
            //f.Show();
            path_main = new int[19, 19];
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();
            /////////////////////////////////////////////////////
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

         
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                 path_main[rCnt-1,cCnt-1]=Convert.ToInt32((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            ////////////////////////////////////////////
        }
        }
     
    }

