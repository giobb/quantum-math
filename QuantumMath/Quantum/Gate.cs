using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace QuantumMath.Quantum
{
    static public class Gate
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
                m[0,1] = new ComplexNumber(1,0);
                m[1,0] = new ComplexNumber(1,0);
                m[1,1] = new ComplexNumber();
                return m;
            }
        }

        public static Matrix CNot
        {
            /*
             * 1 0 0 0
             * 0 1 0 0
             * 0 0 0 1
             * 0 0 1 0
             */
            get
            {
                var m = new Matrix(4, 4);
                m[0, 0] = new ComplexNumber(1, 0);
                m[0, 1] = new ComplexNumber();
                m[0, 2] = new ComplexNumber();
                m[0, 3] = new ComplexNumber();

                m[1, 0] = new ComplexNumber();
                m[1, 1] = new ComplexNumber(1, 0);
                m[1, 2] = new ComplexNumber();
                m[1, 3] = new ComplexNumber();

                m[2, 0] = new ComplexNumber();
                m[2, 1] = new ComplexNumber();
                m[2, 2] = new ComplexNumber();
                m[2, 3] = new ComplexNumber(1, 0);

                m[3, 0] = new ComplexNumber();
                m[3, 1] = new ComplexNumber();
                m[3, 2] = new ComplexNumber(1, 0);
                m[3, 3] = new ComplexNumber();

                return m;
            }
        }
    }
}
