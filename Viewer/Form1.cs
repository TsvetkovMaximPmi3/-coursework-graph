using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UD;



namespace Viewer
{
    public partial class Form1 : Form
    {
        //double[,] gx, gy;
        //double[,] qx, qy;
        int n , m , q;
        const int OtstupOtKraya = UD.Сoefficients.rangex;
        const int OtstupSverhu = UD.Сoefficients.rangey;
        Points Grid = new UD.Points();
        Points GridforStart = new UD.Points();
        MO fc1 = new MO();
        int razmer = 7;
        UD.Graph rGraph;


        public Form1()
        {
            InitializeComponent();
            
             rGraph = new Graph(razmer);
            rGraph.GenerateEdge();
            // gx = new double[,]
            // {
            //     { 10, 100, 300 },
            //     { 10, 100, 300 },
            //     { 10, 100, 300 },
            // };
            // gy = new double[,]
            // {
            //     { 10, 10, 10 },
            //     { 100, 100, 100 },
            //     { 200, 200, 200 },
            // };
            // Solver.Solve(null, null, gx, gy, out qx, out qy);
            //Points Grid = new UD.Points();
            //Grid.setN(q, n, m);
        }

        private void q_TextChanged(object sender, EventArgs e)
        {
            //string str = Tochki.Text;
            //int val = 0;
            //if (int.TryParse(str, out val))
            //{
            //
            //    Tochki.BackColor = Color.FromArgb(230, 255, 230);
            //}
            //else
            //{
            //
            //    Tochki.BackColor = Color.FromArgb(255, 230, 230);
            //
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            n = Convert.ToInt32(SetkaN.Text);
            m = Convert.ToInt32(SetkaM.Text);
            q = Convert.ToInt32(Tochki.Text);
            if ((Grid.m!=m)||(Grid.n!=n)||(Grid.masNach.Length!=q)) {
                Grid.setN(q, n, m);
                Grid.setRandomNachToch();
            }
            UD.Calculate.calcul(Grid);

            paint(g, Grid);
            fc1.f1 = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(SetkaN.Text);
            m = Convert.ToInt32(SetkaM.Text);
            q = Convert.ToInt32(Tochki.Text);
            Graphics g = this.CreateGraphics();
            if ((Grid.m != m) || (Grid.n != n) || (Grid.masNach.Length != q))
            {
                Grid.setN(q, n, m);
                Grid.setRandomNachToch();
            }
            
            paintPoints(g, Grid,true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            n = Convert.ToInt32(SetkaN.Text);
            m = Convert.ToInt32(SetkaM.Text);
            q = Convert.ToInt32(Tochki.Text);

            Grid.setN(q, n, m);
            Grid.setRandomNachToch();
            Grid.Kostyil = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            n = Convert.ToInt32(SetkaN.Text);
            m = Convert.ToInt32(SetkaM.Text);
            q = Convert.ToInt32(Tochki.Text);
            
            GridforStart.setN(q, n, m);
            GridforStart.setRandomNachToch();
            paint(e.Graphics,GridforStart);
           // paintPoints(e.Graphics, GridforStart,true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(SetkaN.Text);
            m = Convert.ToInt32(SetkaM.Text);
            q = Convert.ToInt32(Tochki.Text);
            //double tochnost = Convert.ToDouble(textBox1.Text);
            //for (int i = 0; i < Grid.E; i++)
            bool f = true;int fdop = 0;
            Graphics g = this.CreateGraphics();
            while (fc1.f1>=0.4) //(fdop<Grid.E)
            {   
                Grid.setConechToch();
                paint(g,Grid);
               // paintPoints(g, Grid, false);

                fc1.f1 = 0;                    //заношу данные в таблицу
                fc1.calculF1(Grid);            //заношу данные в таблицу
                fc1.f2 = 0;
                fc1.calculF2(Grid);
                dataGridView1.Rows.Add(fc1.f1,fc1.f2);//заношу данные в таблицу
                
                // g.Clear(Color.White);
                //paintPoints(g, Grid,false);
                for (int h = 0; h < q; h++)
                {
                    //GridforStart.masNach[h].X = Grid.masConech[h].X;
                    //GridforStart.masNach[h].Y = Grid.masConech[h].Y;
                    Grid.masNach[h].X = Grid.masConech[h].X;
                    Grid.masNach[h].Y = Grid.masConech[h].Y;
                    Grid.masConech[h].X = 0;
                    Grid.masConech[h].Y = 0;
                    
                }
                int i = 0;
                while (i < n-1)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Grid.resx[i, j] = GridforStart.resx[i, j];
                        Grid.resy[i, j] = GridforStart.resy[i, j];
                    }
                    i++;
                }
                
                Grid.setRandomNachToch();
                UD.Calculate.calcul(Grid);
               

                f = false;
                fdop++;
               
            }

            
            Grid.setConechToch();

            paint(g, Grid);
            paintPoints(g, Grid, false);


            //эксперемент
            double resultate=0;
            for(int i = 0; i < Grid.masConech.Length; i++)
            {
                resultate += Math.Sqrt((GridforStart.masNach[i].X - Grid.masConech[i].X) * (GridforStart.masNach[i].X - Grid.masConech[i].X)
                    + (GridforStart.masNach[i].Y - Grid.masConech[i].Y) * (GridforStart.masNach[i].Y - Grid.masConech[i].Y));
            }
            resultate /= Grid.masConech.Length;
            dataGridView1.Rows.Add(0, 0,resultate);

            //  paintPoints(g, Grid, false);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        void paint(Graphics g,UD.Points Gridpaint)
        {   
            g.Clear(Color.White);

            //костыль на то что строчка может быть нулевая поэтому ее не чертим
            bool[] forx =new bool[n] ;
            bool[] fory = new bool[m];
            for (int i = 0; i < n; i++)
            {
                forx[i] = true;
                int s = 0;
                for (int j = 0; j < m; j++)
                {
                    if (Gridpaint.resx[i, j] == 0) s++ ;
                }
                if (s == m) forx [i] = false ;
            }
            for (int i = 0; i < m; i++)
            {
                fory[i] = true;
                int s = 0;
                for (int j = 0; j < n; j++)
                {
                    if(Gridpaint.resy[i, j] ==0)s++;
                }
                if (s == n) fory[i] = false;
            }




           

            for (int i = 0; i < n; i++)
            {
                if (forx[i] == false) continue;
                for (int j = 0; j < m; j++)
                {
                    if (fory[j] == false) continue;
                        g.DrawRectangle(Pens.Red, (float)Gridpaint.resx[i, j] - 1 + OtstupOtKraya, (float)Gridpaint.resy[j, i] - 1 + OtstupSverhu, 2, 2); //рисую точки
                       if (j < m - 1) g.DrawLine(Pens.Red, (float)Gridpaint.resx[i, j] + OtstupOtKraya, (float)Gridpaint.resy[j, i] + OtstupSverhu, (float)Gridpaint.resx[i, j + 1] + OtstupOtKraya, (float)Gridpaint.resy[j + 1, i] + OtstupSverhu); //рисую прямые
                    
              
                }
            }
            //продолжение рисования прямых
            for (int i = 0; i < m; i++)
            {
                if (fory[i] == false) continue;
                for (int j = 0; j < n - 1; j++)
                {
                    if (forx[j] == false) continue;
                    g.DrawLine(Pens.Red, (float)Gridpaint.resx[j, i]+OtstupOtKraya, (float)Gridpaint.resy[i, j]+OtstupSverhu, (float)Gridpaint.resx[j + 1, i]+OtstupOtKraya, (float)Gridpaint.resy[i, j + 1]+OtstupSverhu);
                }
            }

        }
         
        void paintPoints(Graphics g, UD.Points Gridpaint,bool Nach)
        {   if (Nach == true)
                for (int i = 0; i < q; i++)
                {
                     g.DrawRectangle(Pens.Black, (float)Gridpaint.masNach[i].X - 1 + OtstupOtKraya, (float)Gridpaint.masNach[i].Y - 1 + OtstupSverhu, 2, 2);
                }
            else
            
                for (int i = 0; i < q; i++)
                {   
                     g.DrawRectangle(Pens.White, (float)Gridpaint.masNach[i].X - 1 + OtstupOtKraya, (float)Gridpaint.masNach[i].Y - 1 + OtstupSverhu, 2, 2);
                    g.DrawRectangle(Pens.Black, (float)Gridpaint.masConech[i].X - 1 + OtstupOtKraya, (float)Gridpaint.masConech[i].Y - 1 + OtstupSverhu, 2, 2);
                    g.DrawLine(Pens.Black, (float)Gridpaint.masNach[i].X+OtstupOtKraya, (float)Gridpaint.masNach[i].Y+OtstupSverhu, (float)Gridpaint.masConech[i].X+OtstupOtKraya, (float)Gridpaint.masConech[i].Y+OtstupSverhu);

                    
                }
            
        }

      
        // void paint(Graphics g, double[,] gx, double[,] gy)
        // {
        //     g.Clear(Color.White);
        //     int nx = gx.GetLength(0);
        //     int ny = gx.GetLength(1);
        //     for (int i = 0; i < nx; i++)
        //         for (int j = 0; j < ny; j++)
        //         {
        //             if (j < ny - 1)
        //                 g.DrawLine(Pens.Red, (int)gx[i, j], (int)gy[i, j], (int)gx[i, j + 1], (int)gy[i, j + 1]);
        //             if (i < nx - 1)
        //                 g.DrawLine(Pens.Red, (int)gx[i, j], (int)gy[i, j], (int)gx[i + 1, j], (int)gy[i + 1, j]);
        //         }
        // }




        void PrintGraph(Graphics g,UD.Graph randomGraph)
        {
            action_memory(g);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = this.CreateGraphics();
            PrintGraph(g, rGraph);
            
                
           
        }

        private void panel1_Click(object sender, EventArgs e)
        {
          
            rGraph.nextIter();

            Graphics g = this.CreateGraphics();
            PrintGraph(g, rGraph);

        }

        private void action_memory(Graphics g)
        {
            Bitmap bmp = new Bitmap(320+1000, 320+1000);
            action(Graphics.FromImage(bmp));
            Graphics.FromHwnd(panel1.Handle).DrawImage(bmp, 0, 0);
        }
        private void action(Graphics g)
        {

            g.Clear(Color.Black);
            for (int i = 0; i < rGraph.Vertex.Length ; i++)
            {
                g.FillRectangle(Brushes.Red, (float)rGraph.Vertex[i].X,(float) rGraph.Vertex[i].Y, 6, 6);
                for (int j = 0; j < rGraph.Edge[i].Length; j++)
                {
                    g.DrawLine(Pens.Red, (float)rGraph.Vertex[i].X, (float)rGraph.Vertex[i].Y, (float)rGraph.Vertex[rGraph.Edge[i][j]].X, (float)rGraph.Vertex[rGraph.Edge[i][j]].Y);
                    // if (rGraph.Edge[i] [j] != 0) g.DrawLine(Pens.Red, (float)rGraph.Vertex[i].X, (float)rGraph.Vertex[i].Y, (float)rGraph.Vertex[j].X, (float)rGraph.Vertex[j].Y);
                }
            }

            rGraph.GenerateconstrictedGraph();
            for(int i = 0; i < rGraph.cGraph.constrictedVertex.Length; i++)
            {   
                if ((rGraph.cGraph.constrictedVertex[i].X != 0) && (rGraph.cGraph.constrictedVertex[i].Y != 0))
                {
                    g.FillRectangle(Brushes.Green, (float)rGraph.cGraph.constrictedVertex[i].X, (float)(rGraph.cGraph.constrictedVertex[i].Y), 6, 6);

                    if (rGraph.cGraph.EdgeconstrictedGraph[i] != null)
                    {
                        int[] tmp = new int[rGraph.cGraph.EdgeconstrictedGraph[i].Length];for (int h = 0; h < tmp.Length; h++) tmp[h] = -1;
                        for (int j = 0; j < rGraph.cGraph.EdgeconstrictedGraph[i].Length; j++)
                        {
                            bool flag = false;
                            
                            for (int h = 0;h< rGraph.cGraph.EdgeconstrictedGraph[i].Length; h++)
                            {
                                if (tmp[h] == rGraph.cGraph.EdgeconstrictedGraph[i][j])
                                {
                                    flag = true;
                                    break;
                                }
                            }

                            if (!flag)
                            {
                                tmp[j] = rGraph.cGraph.EdgeconstrictedGraph[i][j];
                                if ((rGraph.cGraph.EdgeconstrictedGraph[i][j] != 0) && (rGraph.cGraph.constrictedVertex[j].X != 0) && (rGraph.cGraph.constrictedVertex[j].Y != 0))
                                    g.DrawLine(Pens.Green, (float)rGraph.cGraph.constrictedVertex[i].X, (float)rGraph.cGraph.constrictedVertex[i].Y, (float)rGraph.cGraph.constrictedVertex[rGraph.cGraph.EdgeconstrictedGraph[i][j]].X, (float)rGraph.cGraph.constrictedVertex[rGraph.cGraph.EdgeconstrictedGraph[i][j]].Y);
                            }
                            else
                            {
                                    g.DrawLine(Pens.Green, (float)rGraph.cGraph.constrictedVertex[i].X-2, (float)rGraph.cGraph.constrictedVertex[i].Y-2, (float)rGraph.cGraph.constrictedVertex[rGraph.cGraph.EdgeconstrictedGraph[i][j]].X-2, 
                                        (float)rGraph.cGraph.constrictedVertex[rGraph.cGraph.EdgeconstrictedGraph[i][j]].Y-2);
                            }
                        }
                        int yi = 3;
                    }
                }
            }
            
        }

            /* 
              Random rnd = new Random();
            private void action_memory(Graphics g, int w, int h)
            {
                Bitmap bmp = new Bitmap(w, h);
                action(Graphics.FromImage(bmp), bmp.Width, bmp.Height);
                Graphics.FromHwnd(panel1.Handle).DrawImage(bmp, 0, 0);
            }

            private void action(Graphics g, int w, int h)
            {

                g.Clear(Color.Black);
                for (int i = 0; i < 100000; i++)
                {
                    g.FillRectangle(Brushes.Red, rnd.Next(w), rnd.Next(h), 1, 1);
                }
                g.FillRectangle(Brushes.Yellow, rnd.Next(w), rnd.Next(h), 50, 50);


             */

        }



    }
