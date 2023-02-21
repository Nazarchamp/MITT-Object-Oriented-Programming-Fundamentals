using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_C_Sharp
{
    internal class RegularPolygon
    {
        private readonly int _n;
        public int N => _n;

        private readonly double _side;
        public double Side => _side;

        private readonly double _x;
        public double X => _x;

        private readonly double _y;
        public double Y => _y;

        public RegularPolygon(){
            _n = 3;
            _side = 1;
            _x = 0;
            _y = 0;
        }
        public RegularPolygon(int n, double sideLength) 
            : this()
        {
            _n = n;
            _side = sideLength;
        }
        public RegularPolygon(int n, double sideLength, double x, double y) 
            : this(n, sideLength)
        {
            _x = x;
            _y = y;
        }

        public double GetPerimeter()
        {
            return _n * _side;
        }

        public double GetArea()
        {
            return Math.Round((N*Side*Side)/(4*Math.Tan(Math.PI/N)),3);
        }
    }
}
