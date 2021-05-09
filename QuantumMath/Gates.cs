using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace QuantumMath
{
    static public class Gates
    {
        public static Matrix I
        {
            /* 
                1  0
                0  1
            */
            get
            {
                var m = new Matrix(2, 2);
                m[0, 0] = new ComplexNumber(1d, 0d);
                m[0, 1] = new ComplexNumber();
                m[1, 0] = new ComplexNumber();
                m[1, 1] = new ComplexNumber(1d, 0d);
                return m;
            }
        }

        public static Matrix X
        {
            /*
               0  1
               1  0             
             */
            get
            {
                var m = new Matrix(2, 2);
                m[0,0] = new ComplexNumber();
                m[0,1] = new ComplexNumber(1d,0d);
                m[1,0] = new ComplexNumber(1d,0d);
                m[1,1] = new ComplexNumber();
                return m;
            }
        }
    }
}
