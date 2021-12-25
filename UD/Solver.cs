using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UD
{
    public static class Solver
    {
        public static void Solve(
            double[] points_x,
            double[] points_y,
            double[,] grid_x,
            double[,] grid_y,
            out double[,] new_grid_x,
            out double[,] new_grid_y)
        {
            int nx = grid_x.GetLength(0);
            int ny = grid_x.GetLength(1);
            if (grid_y.GetLength(0) != nx || grid_y.GetLength(1) != ny)
                throw new Exception("Error - different grid size");
            new_grid_x = new double[nx, ny];
            new_grid_y = new double[nx, ny];
            for (int i = 0; i < nx; i++)
                for (int j = 0; j < ny; j++)
                {
                    new_grid_x[i, j] = grid_x[i, j] + 1;
                    new_grid_y[i, j] = grid_y[i, j] + 1;
                }
        }
    }
}
