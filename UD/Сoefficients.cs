using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD
{
	
    public  class Сoefficients
    {
		private double[] massivecoef = new double[0];
		private double[] masx = new double[0];
		public const int diapozon = 300;
		public const int rangex = 10;
		public const int rangey = 10;
		private int sizecoef = 0;
		private int sizex = 0;
		private double res = 0;
		private int[] mastoch = new int[0];
		public Сoefficients()
		{
		
			
	}
		public Сoefficients(int n)
		{
			if (n <= 1) throw new Exception();
			masx = new double[n];
			sizex = n;
			massivecoef = new double[n - 1];
			sizecoef = n - 1;
		}
		public void setCoef(double[] temp)
		{
			res = 0;
			for (int i = 0; i < sizecoef; i++)
			{

				massivecoef[i] = temp[i];
				res += massivecoef[i];

			}
			this.setLine();
			for (int i = 0; i < sizecoef; i++)
			{

				

			}
		}
		public void setLine()
		{


			masx[0] = 0;
			masx[sizex - 1] = 10;
			double xi = 0.0;

			for (int i = 0; i < sizecoef; i++)
			{
				if (res != 0)
				{
					xi = (massivecoef[i] * diapozon) / res;
					masx[i + 1] = masx[i] + xi;
				}
				else masx[i + 1] = 0;
			}
		}
		//public void setCoefi(int j, double c)
		//{
		//	if (j > sizecoef) throw new Exception();
		//	mascoef[j] = c;
		//	res = 0.0;
		//	for (int i = 0; i < sizecoef; i++)
		//	{
		//
		//		res += mascoef[i];
		//
		//
		//	}
		//	this.setLine();
		//}

		public double[] getMasx() { return masx; }
		//public void setMastoch()
		//{
		//	mastoch = new int[sizecoef];
		//	for (int i = 0; i < sizecoef; i++)
		//	{
		//		Random rnd = new Random();
		//		mastoch[i] = rnd.Next(0, 10);
		//	}
		//
		//}

	};
}
