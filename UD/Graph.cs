using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD
{

    public class Graph
    {

        const int maxSizeEdge = 10;
        private Random rnd = new Random(0);
        public int n = 0;
        public int[][] Edge;
        public PointF[] Vertex;
        public PointF[] VertexNext;
        public double[] dx, dy;
        public int[] silaprit;
        double seed = 0.1;
        double otkloneniex = 0;
        double otkloneniey = 0;
        double centr = 150;

        //переменные для теста объединения вершин для ввода силы притяжения
        public constrict cGraph;
        Graph()
        {
            Edge = new int[n][];
            Vertex = new PointF[n];
            VertexNext = new PointF[n];
            dx = new double[n];
            dy = new double[n];
            silaprit = new int[n];

           
        }
        public  Graph(int _n) {
            n = _n;
            
            Edge = new int[n][];
            Vertex = new PointF[n];
            VertexNext = new PointF[n];
            dx = new double[n];
            dy = new double[n];
            silaprit = new int[n];

           
        }
        public void GenerateEdge() {

            // for(int i = 0; i < n; i++)
            //
            // {
            //         silaprit[i] = rnd.Next(1, maxSizeEdge);
            //         Vertex[i].X = rnd.Next(0, UD.Сoefficients.diapozon);
            //         Vertex[i].Y = rnd.Next(0, UD.Сoefficients.diapozon);
            //         Edge[i] = new int[rnd.Next(1,n/2)];
            //        
            //     for (int j = 0; j < Edge[i].Length; j++)
            //     {
            //         
            //         Edge[i][j]= rnd.Next(1, Vertex.Length-1);
            //         
            //         
            //     }
            // }
            n = 7;
            //1 вершина
            Vertex[0].X = 50;
            Vertex[0].Y = 100;
            Edge[0] = new int[3];
            Edge[0][0] = 7-1;
            Edge[0][1] = 2-1;
            Edge[0][2] = 6-1;

            //2 вершина
            Vertex[1].X = 150;
            Vertex[1].Y = 50;
            Edge[1] = new int[2];
            Edge[1][0] = 3-1;
            Edge[1][1] = 1-1;

            //3 вершина
            Vertex[2].X = 280;
            Vertex[2].Y = 90;
            Edge[2] = new int[3];
            Edge[2][0] = 2-1;
            Edge[2][1] = 7-1;
            Edge[2][2] = 4-1;

            //4 веришина
            Vertex[3].X = 230;
            Vertex[3].Y = 200;
            Edge[3] = new int[3];
            Edge[3][0] = 5-1;
            Edge[3][1] = 7-1;
            Edge[3][2] = 3-1;

            //5 вершина
            Vertex[4].X = 140;
            Vertex[4].Y = 250;
            Edge[4] = new int[2];
            Edge[4][0] = 4-1;
            Edge[4][1] = 6-1;

            //6 вершина
            Vertex[5].X = 70;
            Vertex[5].Y = 220;
            Edge[5] = new int[3];
            Edge[5][0] = 5-1;
            Edge[5][1] = 7-1;
            Edge[5][2] = 1 - 1;

            //7 вершина 
            Vertex[6].X = 140;
            Vertex[6].Y = 140;
            Edge[6] = new int[4];
            Edge[6][0] = 1-1;
            Edge[6][1] = 3-1;
            Edge[6][2] = 4-1;
            Edge[6][3] = 6-1;

        }

        public void nextIter()
        {   
            for(int i = 0; i < n; i++)
            {
                otkloneniex += Vertex[i].X;
                otkloneniey += Vertex[i].Y;

            }
            otkloneniex /= n;
            otkloneniey /= n;
            otkloneniex -= centr;
            otkloneniey -= centr;
            for (int i = 0; i < n; i++)
            {
                
                
                dx[i] = 0;
                dy[i] = 0;
               
                for (int j = 0; j < Edge[i].Length; j++)
                {
                    dx[i] += (Vertex[i].X - Vertex[j].X);
                    dy[i] += (Vertex[i].Y - Vertex[j].Y);

                    
                }

            }
            for (int i = 0; i < n; i++)
            {
                double max = 0;
                for (int j = 0; j < n; j++)
                {
                    max = Math.Max(max, (Math.Sqrt(dx[j] * dx[j] + dy[j] * dy[j])));
                }
                
                for (int g = 0; g < n; g++)
                {
                    dx[g] /=seed*max;
                    dy[g] /=seed*max;
                   

                }
               
                Vertex[i].X -= dx[i]+otkloneniex;
                Vertex[i].Y -= dy[i]+otkloneniey;

            }
            int ap = 5;
            }
        public void GenerateconstrictedGraph() {
            cGraph.weightVertex = new double[Vertex.Length];
            cGraph.constrictedGraph = new double[Vertex.Length];
            cGraph.EdgeconstrictedGraph = new int[Vertex.Length][];
            cGraph.constrictedVertex = new PointF[Vertex.Length];
            for (int i = 0; i < Vertex.Length; i++)
            {
                //cGraph.EdgeconstrictedGraph[i] = new int[Edge[i].Length];
                cGraph.constrictedGraph[i] = 0;
                cGraph.weightVertex[i] = 1;
                //for(int j = 0; j < cGraph.EdgeconstrictedGraph[i].Length;j++)
                //{
                //    cGraph.EdgeconstrictedGraph[i][j] = Edge[i][j];
                //}
            }

           int tmp = 1;
            // int[][] tmp1= new int[(cGraph.constrictedVertex.Length/2)+cGraph.constrictedVertex.Length%2][];
            // constrictedGraph[0] = 1;

            //заполняю вектор 1122334
            
            for (int i = 0; i < Vertex.Length; i++)
            {
                
                if ((cGraph.constrictedGraph[i] == 0))
                {
                    
                    cGraph.constrictedGraph[i] = tmp;
                  
                    for(int j = 0; j < Edge[i].Length; j++)
                    {
                        if (cGraph.constrictedGraph[Edge[i][j]] == 0)
                        {
                            cGraph.constrictedGraph[Edge[i][j]] = tmp;
                            tmp++;
                         
                            
                        }
                        break;
                    }
                    tmp++;
                }
            }

            tmp = 0;
            for(int i = 0; i < cGraph.constrictedGraph.Length-1; i++)
            {
                int s = 0;
                for (int j = i+1; j < cGraph.constrictedGraph.Length; j++)
                {
                    //исходный вариант 
                    //if (cGraph.constrictedGraph[i] == cGraph.constrictedGraph[j])
                    //{   
                    //    
                    //    cGraph.constrictedVertex[tmp].X = (Vertex[i].X * cGraph.weightVertex[i] + Vertex[j].X * cGraph.weightVertex[j]) / (cGraph.weightVertex[i] + cGraph.weightVertex[j]);
                    //    cGraph.constrictedVertex[tmp].Y = (Vertex[i].Y * cGraph.weightVertex[i] + Vertex[j].Y * cGraph.weightVertex[j]) / (cGraph.weightVertex[i] + cGraph.weightVertex[j]);
                    //    cGraph.EdgeconstrictedGraph[tmp] = new int[Edge[i].Length + Edge[j].Length];
                    //    for (int g = 0; g < Edge[i].Length; g++) cGraph.EdgeconstrictedGraph[tmp][g] = Edge[i][g];
                    //    for (int g = 0; g < Edge[j].Length; g++) cGraph.EdgeconstrictedGraph[tmp][g+Edge[i].Length] = Edge[j][g];
                    //    tmp++;
                    //    s++;
                    //    Vertex[j].X = 0;
                    //    Vertex[j].Y = 0;
                    //    break;
                    //}

                    //новый пробный
                    if (cGraph.constrictedGraph[i] == cGraph.constrictedGraph[j])
                    {

                        cGraph.constrictedVertex[i].X = (Vertex[i].X * cGraph.weightVertex[i] + Vertex[j].X * cGraph.weightVertex[j]) / (cGraph.weightVertex[i] + cGraph.weightVertex[j]);
                        cGraph.constrictedVertex[i].Y = (Vertex[i].Y * cGraph.weightVertex[i] + Vertex[j].Y * cGraph.weightVertex[j]) / (cGraph.weightVertex[i] + cGraph.weightVertex[j]);
                        cGraph.constrictedVertex[j].X = cGraph.constrictedVertex[i].X;
                        cGraph.constrictedVertex[j].Y = cGraph.constrictedVertex[i].Y;
                        cGraph.EdgeconstrictedGraph[i] = new int[Edge[i].Length+ Edge[j].Length];
                        cGraph.EdgeconstrictedGraph[j] = new int[Edge[j].Length+ Edge[i].Length];
                        for (int g = 0; g < Edge[i].Length; g++) { cGraph.EdgeconstrictedGraph[i][g] = Edge[i][g]; cGraph.EdgeconstrictedGraph[j][g + Edge[j].Length] = Edge[i][g]; }

                        for (int g = 0; g < Edge[j].Length; g++) { cGraph.EdgeconstrictedGraph[j][g] = Edge[j][g]; cGraph.EdgeconstrictedGraph[i][g + Edge[i].Length] = Edge[j][g]; }
                        tmp++;
                        s++;
                        //Vertex[j].X = 0;
                        //Vertex[j].Y = 0;
                        break;
                    }

                }
                if ((s == 0)&&(cGraph.constrictedVertex[i].X==0) && (cGraph.constrictedVertex[i].Y == 0)) {
                    cGraph.constrictedVertex[i] = Vertex[i];
                    cGraph.EdgeconstrictedGraph[i] = new int[Edge[i].Length];
                    for (int g = 0; g < Edge[i].Length; g++) cGraph.EdgeconstrictedGraph[i][g] = Edge[i][g];
                    tmp++;
                }
                
            }
            // if ((cGraph.constrictedVertex[cGraph.constrictedGraph.Length - 1].X == 0) && (cGraph.constrictedVertex[cGraph.constrictedGraph.Length - 1].Y == 0))
            //     cGraph.constrictedVertex[tmp] = Vertex[cGraph.constrictedGraph.Length - 1];
            
            int y = 0;
            //for(int i = 0; i < cGraph.constrictedGraph.Length; i++)//подумать как сделать 
            //{
            //    for(int j = 0; j < cGraph.constrictedGraph.Length; j++)
            //    {
            //        if (cGraph.constrictedGraph[i] == cGraph.constrictedGraph[j])
            //        {
            //            cGraph.constrictedVertex[i].X = (Vertex[i].X * cGraph.weightVertex[i] + Vertex[j].X * cGraph.weightVertex[j]) / (cGraph.weightVertex[i] + cGraph.weightVertex[j]);
            //            cGraph.constrictedVertex[i].Y = (Vertex[i].Y * cGraph.weightVertex[i] + Vertex[j].Y * cGraph.weightVertex[j]) / (cGraph.weightVertex[i] + cGraph.weightVertex[j]);
            //            tmp1[i] = new int[cGraph.EdgeconstrictedGraph[i].Length + cGraph.EdgeconstrictedGraph[j].Length];
            //            for(int g = 0; g < tmp1.Length; g++)
            //            {
            //                tmp1[g][g] = cGraph.EdgeconstrictedGraph[i][g];
            //                tmp1[g][g + 1] = cGraph.EdgeconstrictedGraph[j][g];
            //            }
            //        }
            //    }

            //}
           
        }
    }

    
        
    public struct constrict
    {
        public double[] weightVertex;
        public double[] constrictedGraph;
        public int[][] EdgeconstrictedGraph;
        public PointF[] constrictedVertex;

       
    }

}
