using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD
{
    public class MO
    {
        public double f1 = 0; //функция среднее кол-во точек в одном квадрате
        public double f2 = 0;//функция среднего движения точек
      
        public void calculF1(Points data)
        {
            
            f1 = CalToch(data);
           
        }
        public void calculF2(Points data)
        {
            f2 = CalOtkl(data);
        }

        double CalOtkl(Points data)
        {
            double res = 0;
            for (int i = 0; i < data.masNach.Length; i++)
            {

                res += Math.Sqrt((data.masNach[i].X - data.masConech[i].X) * (data.masNach[i].X - data.masConech[i].X)
                    + (data.masNach[i].Y - data.masConech[i].Y) * (data.masNach[i].Y - data.masConech[i].Y));
            }

            res /= data.masNach.Length;

            return res;
        }
        double CalToch(Points data)
        {
             double res = 0;
             int n = ((data.n) - 1) * ((data.m) - 1);
             for (int i = 0; i< n;i++) {
                 res += Math.Abs(data.ChisloTochInKv[i] - data.retsize() /(n));
            
             }
             res /= n;
                 return res;
           
        }
    }
}
