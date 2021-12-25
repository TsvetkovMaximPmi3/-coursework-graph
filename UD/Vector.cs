using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD
{
    class Vector
    {
        public double x, y;

       public double getX() { return x; }
        public Vector(double _x,double _y) { x = _x;y = _y; }
        public double[] Array
        {
            get { return new double[] { x, y }; }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: { return x; }
                    case 1: { return y; }
                   
                    default: throw new ArgumentException("eror index vector");
                }
            }
        }
        public double Magnitude()
        {
          
                return Math.Sqrt(x*x+y*y);
            
        }
        public static Vector operator+(Vector v1, Vector v2)
        {
            return new Vector(
               v1.x + v2.x,
               v1.y + v2.y
               );
        }

        public static Vector operator-(Vector v1, Vector v2)
        {
            return new Vector(
               v1.x - v2.x,
               v1.y - v2.y
               );
        }
    }
   
}
