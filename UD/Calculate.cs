using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD
{
    public static class Calculate
    {	
       public static void calcul(UD.Points A)
        {	const int UbnozhenieKazhdKletki = 10;
			int m = A.m;
			int n = A.n;
			//создаю матрицу коэф
			UD.Сoefficients[] Abc = new UD.Сoefficients[n];
			UD.Сoefficients[] Acb = new UD.Сoefficients[m];
			
			double[] tempx = new double[m - 1];
			double[] tempy = new double[n - 1];
			
			
			
			for (int i = 0; i < n; i++)
				{
					Abc[i] = new UD.Сoefficients(m);
			
					for (int j = 0; j < m - 1; j++)
					{
					if ((i == 0) || (i == n - 1))
					{
						if (i == 0) tempx[j] = A.ChisloTochInKv[j] * UbnozhenieKazhdKletki+1;
						if (i == n - 1) tempx[j] = A.ChisloTochInKv[(m - 1) * (n - 2) + j] * UbnozhenieKazhdKletki+1;

					}

					else
					{	
						tempx[j] = (A.ChisloTochInKv[(m - 1) * i + j] + A.ChisloTochInKv[((m - 1) * (i - 1)) + j]) * UbnozhenieKazhdKletki+1;
						
					}
			
					}
					Abc[i].setCoef(tempx);
				}
				
				
				for (int i = 0; i < m; i++)
				{
					Acb[i] = new UD.Сoefficients(n);
					for (int j = 0; j < n - 1; j++)
					{
						if (i == 0)
						
							tempy[j] = A.ChisloTochInKv[j * (m - 1)]* UbnozhenieKazhdKletki + 1;
					else
						{
						if (i == m - 1)
							tempy[ j] = A.ChisloTochInKv[i - 1 + j * (m - 1)]* UbnozhenieKazhdKletki+1;
						else
							
							tempy[j] = (A.ChisloTochInKv[i + j * (m - 1)]  + A.ChisloTochInKv[(i + j * (m - 1)) - 1])* UbnozhenieKazhdKletki+1;

					}
						
			
						Acb[i].setCoef(tempy);
					}
			




				}

			for (int i = 0;i<n;i++)
				for(int j = 0; j<	m; j++)
            {		
					A.resx[i, j] = Abc[i].getMasx()[j];
            }
			for (int i = 0; i < m; i++)
				for (int j = 0; j < n; j++)
				{
					A.resy[i, j] = Acb[i].getMasx()[j];
				}
			//	UD.PointF[,] masSetk = new PointF[n,m];
			//	for (int i = 0; i < n; i++)
			//    {
			//		for (int j = 0; j < m; j++)
			//        {
			//			masSetk[i, j].X = Abc[i].getMasx()[j];
			//			masSetk[i, j].Y = Acb[j].getMasx()[i];
			//			
			//		}
			//    }





		}

    }
}
