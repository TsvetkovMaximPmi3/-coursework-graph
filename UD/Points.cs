using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace UD
{
    public class Points
    {
		public int E = 10;//сколько итераций для черчения полной прямой conech- nach
		public static int size = 100;
	
		public PointF[] masNach = new PointF[size];
		public PointF[] masConech = new PointF[size];
		private Random rnd = new Random(0);
		public PointF[] masKv = new PointF[size];//координаты левого верхнего угла квадрата для i-ой точки
		public int[] masKvnumber = new int[size];//порядковый номер квадрата
		public int[] ChisloTochInKv = new int[size];
		public double dlinaKvx = 0;
		public double dlinaKvy = 0;
		public double tmpdlx1, tmpdly1, tmpdlx2, tmpdly2;
		public double[,] resx = new double[0,0];
		public double[,] resy= new double [0,0];
		public int m = 0;
		public int n = 0;
		public int Kostyil = 0;

		public Points()
		{
			


		}

		public void setN(int _n,int _n1,int _m)
		{	n = _n1;
			m = _m;
			size = _n;
			masNach = new PointF[size];
			//setRandomNachToch();
			masConech = new PointF[size];
			masKv = new PointF[size];
			ChisloTochInKv = new int[(n - 1) * (m - 1)];


			for (int i = 0; i < size; i++) {
				masKv[i].X = 0;
				masKv[i].Y = 0; }
			

			
			masKvnumber = new int[size];
			resx = new double[n, m];
			resy = new double[m, n];
			double[] coefx = new double[m-1];
			double[] coefy = new double[n - 1];
			for (int i = 0; i < m-1; i++)
            {
				coefx[i] = 1;
            }

			for (int i = 0; i < n - 1; i++)
			{
				coefy[i] = 1;
			}
			UD.Сoefficients tempx = new UD.Сoefficients(coefx.GetLength(0)+1);
			
			tempx.setCoef(coefx);
			UD.Сoefficients tempy = new UD.Сoefficients(coefy.GetLength(0) + 1);

			tempy.setCoef(coefy);
			for (int i = 0; i < n; i++)
			{		
				for (int j = 0; j < m; j++)
				{
					resx[i, j] = tempx.getMasx()[j];
					
				}
			}

			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					resy[i, j] = tempy.getMasx()[j];

				}
			}
			
		}
		public void setMasKv()
		{
			
			dlinaKvx = resx[0, 1] - resx[0, 0];
			dlinaKvy = resy[0, 1] - resy[0, 0];
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < resx.GetLength(0)-1/*внес правку (-1 ) и в след строчке,мб не правильно*/ ; j++)
				{
					for (int g = 0; g <resx.GetLength(1)-1; g++)
					{
						if (masNach[i].X >= resx[0, g] && masNach[i].X <= resx[0, g + 1])
						{
							if (masNach[i].Y >= resy[0, j] && masNach[i].Y <= resy[0, j + 1])
							{

								masKv[i].X = resx[0, g];
								masKv[i].Y = resy[0, j];
								masKvnumber[i] = (resx.GetLength(1) - 1) * j + g;
							}
						}
					}
				}



			}


		}
		public void setRandomNachToch()
		{
			if (Kostyil == 0)
			{
				for (int i = 0; i < size; i++)
				{

					masNach[i].X = rnd.Next(0, UD.Сoefficients.diapozon);
					masNach[i].Y = rnd.Next(0, UD.Сoefficients.diapozon);

					masConech[i].X = 0;
					masConech[i].Y = 0;

				}

			}
				else for (int i = 0; i < ((n - 1) * (m - 1)); i++) { ChisloTochInKv[i] = 0; }
			
			for ( int i = 0; i < n-1 ; i++)
			{
				for (int j = 0; j < m-1 ; j++)
				{

					for (int w = 0; w < masNach.GetLength(0); w++)
					{
						if ((masNach[w].X <= resx[0, j + 1]) &&
							(masNach[w].X >= resx[0, j]) &&
							(masNach[w].Y >= resy[0, i]) &&
							(masNach[w].Y <= resy[0, i + 1]))
						{
							
							ChisloTochInKv[(m - 1) * i + j]++;//поменял n на m
							
						}
						
					}
				}

			}
			setMasKv();
			Kostyil++;
		}
		
		public double Sred_otklon_toch(PointF[] nach, PointF[] conech)
		{
			double res = 0;
			for (int i = 0; i < nach.Length; i++)
			{

				res += Math.Sqrt((nach[i].X - conech[i].X) * (nach[i].X - conech[i].X)
					+ (nach[i].Y - conech[i].Y) * (nach[i].Y - conech[i].Y));
			}

			res /= nach.Length;
			return res;
		}
		public double searchmas()
		{
			double massive = 0;



			return massive;
		}
		public void setConechToch()
		{


			for (int i = 0; i < size; i++)
			{
				double tmpx, tmpy, dlinax1, dlinax2, dlinay1, dlinay2;
				

				tmpx = masNach[i].X - masKv[i].X;
				tmpy = masNach[i].Y - masKv[i].Y;
				int w, e;
				double Ax, Bx, Cx, Dx, Ay, By, Cy, Dy;

				w = masKvnumber[i] % (resx.GetLength(1) - 1);
				e = masKvnumber[i] / (resx.GetLength(1) - 1);
				Ax = resx[e, w];//с учетом того что мы вычилслили новые res (те координаты квадратов изменились)
				Ay = resy[w, e];
				Bx = resx[e, w + 1];
				By = resy[w + 1, e];
				Cx = resx[e + 1, w + 1];
				Cy = resy[w + 1, e + 1];
				Dx = resx[e + 1, w];
				Dy = resy[w, e + 1];
				tmpdlx1 = Math.Sqrt((Bx - Ax) * (Bx - Ax) + (By - Ay) * (By - Ay)); // длина гипотинузы 
				tmpdlx2 = Math.Sqrt((Cx - Dx) * (Cx - Dx) + (Cy - Dy) * (Cy - Dy));
				tmpdly1 = Math.Sqrt((Dx - Ax) * (Dx - Ax) + (Dy - Ay) * (Dy - Ay));
				tmpdly2 = Math.Sqrt((Cx - Bx) * (Cx - Bx) + (Cy - By) * (Cy - By));
				dlinax1 = ((tmpx * tmpdlx1) / dlinaKvx);//+ resx[e, w] ;//нашел длину в новых квадратах до точки без учета наклона
				dlinax2 = ((tmpx * tmpdlx2) / dlinaKvx);//+ resx[e+1, w] ;
				dlinay1 = ((tmpy * tmpdly1) / dlinaKvy);//+ resy[e, w] ;
				dlinay2 = ((tmpy * tmpdly2) / dlinaKvy); //+ resy[e, w+1] ;


				//подсчет координат точек для построения 2х прямых
				double tchX1koordY =(dlinax1 * Math.Abs(Ay - By)) / tmpdlx1;
				double tchX1koordX =(dlinax1 * Math.Abs(Ax - Bx)) / tmpdlx1;
				double tchX2koordY =(dlinax2 * Math.Abs(Dy - Cy)) / tmpdlx2;
				double tchX2koordX =(dlinax2 * Math.Abs(Dx - Cx)) / tmpdlx2;
				double tchY1koordY =(dlinay1 * Math.Abs(Ay - Dy)) / tmpdly1;
				double tchY1koordX =(dlinay1 * Math.Abs(Ax - Dx)) / tmpdly1;
				double tchY2koordY =(dlinay2 * Math.Abs(By - Cy)) / tmpdly2;
				double tchY2koordX =(dlinay2 * Math.Abs(Bx - Cx)) / tmpdly2;

				//координаты с учетом углов квадратов

				double AxplustchX1koordX = Ax + tchX1koordX;
				double AyplustchX1koordY = Ay + tchX1koordY;
				double DxplustchX2koordX = Dx + tchX2koordX;
				double DyplustchX2koordY = Dy + tchX2koordY;
				double AyplustchY1koordY = Ay + tchY1koordY;
				double AxplustchY1koordX = Ax + tchY1koordX;
				double ByplustchY2koordY = By + tchY2koordY;
				double BxplustchY2koordX = Bx + tchY2koordX;


				//алгоритм поиска пересечения 2х прямых


				double a1, a2, b1, b2, c1, c2;
				a1 = AyplustchX1koordY - DyplustchX2koordY;
				b1 = DxplustchX2koordX - AxplustchX1koordX;
				c1 = AxplustchX1koordX * DyplustchX2koordY - DxplustchX2koordX * AyplustchX1koordY;
				a2 = AyplustchY1koordY - ByplustchY2koordY;
				b2 = BxplustchY2koordX - AxplustchY1koordX;
				c2 = AxplustchY1koordX * ByplustchY2koordY - BxplustchY2koordX * AyplustchY1koordY;

				double itogX, itogY, det;
				det = a1 * b2 - a2 * b1;
				itogX = (b1 * c2 - b2 * c1) / det;
				itogY = (a2 * c1 - a1 * c2) / det;
				//masConech[i].X = (float)itogX;
				//masConech[i].Y = (float)itogY;
				//itogX += masConech[i].X; 
				//itogY += masConech[i].Y;

				//пробую сделать последовательное приближение к концу
				double k=0;
				if ((masNach[i].X - (float)itogX) != 0)
				{
					 k = (masNach[i].Y - (float)itogY) / (masNach[i].X - (float)itogX);
				}
				double b = (float)itogY - k * (float)itogX;
				
				if (masConech[i].X == 0) masConech[i].X = masNach[i].X + ((float)itogX - masNach[i].X) * 1 / E;
				else {
					if ((float)itogX - masNach[i].X == 0) { masConech[i].X = (float)itogX; masConech[i].Y = masNach[i].Y;continue; }
					else masConech[i].X = ((float)itogX - masNach[i].X) * 1 / E; }
				masConech[i].Y = k * masConech[i].X + b;

				//if (masConech[i].X == 0) masNach[i].X = masNach[i].X + ((float)itogX - masNach[i].X) * 1 / E;
				//else masNach[i].X = ((float)itogX - masNach[i].X) * 1/E;
				//masNach[i].Y = k * masNach[i].X + b;
			}


		}

		public int retsize() { return size; }
	}

	public struct PointF
    {
		public double X, Y;
		public PointF(double _X,double _Y)
        {
			X = _X;
			Y = _Y;
        }
    }
}
