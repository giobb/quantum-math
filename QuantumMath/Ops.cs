using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumMath
{
    static public class Ops
    {
        static public Matrix Tensor(Matrix lhs, Matrix rhs)
        {
            var result = new Matrix(lhs.Rows * rhs.Rows, lhs.Cols * rhs.Cols);

            for (uint i = 0; i < lhs.Rows; i++)
                for (uint j = 0; j < rhs.Cols; j++)
                    for (uint k = 0; k < rhs.Rows; k++)
                        for (uint l = 0; l < rhs.Cols; l++)
                        {
                            var m = rhs.Rows * i + k;
                            var n = rhs.Cols * j + l;
                            result[m, n] = lhs[i, j] * rhs[k, l];
                        }

            return result;
        }
    }
}
