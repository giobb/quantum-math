using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace QuantumMath.Quantum
{
    static public class Gates
    {
        public static Matrix I
        {
            get => new Matrix(new double[] { 1, 0 },
                              new double[] { 0, 1 });
        }

        public static Matrix X
        {
            get => new Matrix(new double[] { 0, 1 },
                              new double[] { 1, 0 });
        }

        public static Matrix CNot
        {
            get => new Matrix(
                 new double[] { 1, 0, 0, 0 },
                 new double[] { 0, 1, 0, 0 },
                 new double[] { 0, 0, 0, 1 },
                 new double[] { 0, 0, 1, 0 });

        }
    }
}
