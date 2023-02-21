using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_C_Sharp
{
    internal static class Location
    {
        private static int _row;
        public static int Row => _row;

        private static int _col;
        public static int Col => _col;

        private static int _maxValue;
        public static int MaxValue => _maxValue;

        public static void LocateLargest(int[,] array)
        {
            _maxValue = array[0, 0];
            _col = 0;
            _row = 0;

            for(int i=0; i < array.GetLength(0); i++)
            {
                for(int j=0; j < array.GetLength(1); j++)
                {
                    if(array[i,j] > _maxValue)
                    {
                        _maxValue = array[i, j];
                        _row = i;
                        _col = j;
                    }
                }
            }
        }
    }
}
