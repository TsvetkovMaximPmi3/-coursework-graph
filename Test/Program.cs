using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solver_Solve: {0}", Solver_Solve());
            Console.WriteLine("Check_coefficientts: {0}", check_coefficientts());
            Console.WriteLine("Points_in_square: {0}", Points_in_square());
            Console.WriteLine("Calculate: {0}", Calculate());
            return;
        }

        static bool Solver_Solve()
        {
            double[] points_x = new double[] { 0, 1, 2, 3 };
            double[] points_y = new double[] { 0, 1, 2, 3 };
            double[,] grid_x = new double[,]
            {
                { 0, 1, 3 },
                { 0, 1, 3 },
                { 0, 1, 3 },
            };
            double[,] grid_y = new double[,]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 2, 2, 2 },
            };
            double[,] new_grid_x, new_grid_y;

            Solver.Solve(points_x, points_y, grid_x, grid_y, out new_grid_x, out new_grid_y);

            if (!equal(new_grid_x, new double[,]
            {
                { 1, 2, 4 },
                { 1, 2, 4 },
                { 1, 2, 4 },
            })) return false;
            if (!equal(new_grid_y, new double[,]
            {
                { 1, 1, 1 },
                { 2, 2, 2 },
                { 3, 3, 3 },
            })) return false;

            return true;
        }

        static bool equal(double[,] a, double[,] b)
        {
            int nx = a.GetLength(0);
            int ny = a.GetLength(1);
            if (b.GetLength(0) != nx) return false;
            if (b.GetLength(1) != ny) return false;
            for (int i = 0; i < nx; i++)
                for (int j = 0; j < ny; j++)
                    if (a[i, j] != b[i, j]) return false;
            return true;
        }

        static bool check_coefficientts()
        {   
            double[] solve1_coef = new double[] {2,3,1,4 };
            double[] solve2_coef = new double[] {4,6,2,8 };
            UD.Сoefficients Solve1= new UD.Сoefficients(solve1_coef.Length+1);
            UD.Сoefficients Solve2 = new UD.Сoefficients(solve2_coef.Length+1);
            Solve1.setCoef(solve1_coef);
            Solve2.setCoef(solve2_coef);
            solve1_coef = Solve1.getMasx();
            solve2_coef = Solve2.getMasx();

            for (int i = 0; i < 4; i++)
            {
                if (solve1_coef[i] != solve2_coef[i]) return false;
            }
                return true;

            
        }

        static bool Points_in_square()
        {
            int n = 3, m = 3;
            double[] coefx = new double[] { 1, 1, 1 };
            double[,] coefy = new double[,] {
                { 1, 1, 1 } ,
                { 1, 1, 1 },
                { 1, 1, 1 },

            };
            
            UD.Points Test=new Points();
            Test.setN(3,n,m);
            UD.PointF One = new PointF(20,20);
            UD.PointF Two = new PointF(250, 250);
            UD.PointF Free = new PointF(250, 20);
            Test.masNach[0] = One;
            Test.masNach[1] = Two;
            Test.masNach[2] = Free;
            Test.setMasKv();
            int[] masKv = new int[] { 0,3,1 };
            for (int i = 0; i < 3; i++)
            {
                if (masKv[i] != Test.masKvnumber[i]) return false;
            }


          

            return true;
        }
        static bool Calculate()
        {

            int n = 3, m = 8;
           

            UD.Points Test = new Points();
            Test.setN(7, n, m);
            Test.setRandomNachToch();

            UD.Calculate.calcul(Test);





            return true;
        }
    }
}
