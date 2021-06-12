using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Numerics;
using System.Text;

namespace QuantumMath
{
    public class Matrix
    {
        readonly ComplexNumber[,] _array;

        public Matrix(uint rows, uint cols)
        {
            Rows = rows;
            Cols = cols;

            _array = new ComplexNumber[Rows, Cols];
        }

        public Matrix(params double[][] rowValues)
        {
            if (rowValues.Select(o => o.Length).Distinct().Count() > 1)
                throw new ArgumentException("Diferrent sizes");

            Rows = (uint)rowValues.Length;
            Cols = (uint)rowValues[0].Length;

            _array = new ComplexNumber[Rows, Cols];

            // TODO: Create rows here using new
            for(int i = 0; i<rowValues.Length; i++)
            {
                var row = rowValues[i];
                var arrCN = ComplexNumber.CreateInstances(row);
                for (var j = 0; j < arrCN.Length; j++)
                    _array[i, j] = arrCN[j];
            }            
        }

        public uint Rows { get; }

        public uint Cols { get; }

        public bool IsSquare() => Rows == Cols;

        public bool IsSymmetric() => throw new NotImplementedException();

        public bool IsInvertible() => throw new NotImplementedException();

        public bool IsUnitary() => throw new NotImplementedException();

        public bool IsHermitian() => throw new NotImplementedException();

        public Matrix GetTranspose()
        {
            Matrix result = new Matrix(Cols, Rows);

            for (uint iRow = 0; iRow < Rows; iRow++)
            {
                for (uint iCol = 0; iCol < Cols; iCol++)
                {
                    result[iCol, iRow] = this[iRow, iCol];
                }
            }

            return result;
        }

        public Matrix GetAdjoint() => throw new NotImplementedException();

        public ComplexNumber this[uint row, uint col]
        {
            get => _array[row, col];
            set => _array[row, col] = value;
        }

        static void ValidateAddCompatibility(Matrix lhs, Matrix rhs)
        {
            if (rhs.Rows != lhs.Rows ||
                rhs.Cols != lhs.Cols)
                throw new InvalidOperationException("Matrices size not compatible.");
        }

        public static Matrix operator + (Matrix lhs, Matrix rhs)
        {
            ValidateAddCompatibility(lhs, rhs);

            var resultant = new Matrix(lhs.Rows, lhs.Cols);

            for (uint m = 0; m<lhs.Rows; m++)
            {
                for (uint n=0; n<lhs.Cols; n++)
                {
                    resultant[m, n] = lhs[m, n] + rhs[m, n];
                }
            }

            return resultant;
        }

        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            ValidateAddCompatibility(lhs, rhs);

            var resultant = new Matrix(lhs.Rows, lhs.Cols);

            for (uint m = 0; m < lhs.Rows; m++)
            {
                for (uint n = 0; n < lhs.Cols; n++)
                {
                    resultant[m, n] = lhs[m, n] - rhs[m, n];
                }
            }

            return resultant;
        }

        static void ValidateMultiplicationCompatibility(Matrix lhs, Matrix rhs)
        {
            if (lhs.Cols != rhs.Rows)
                throw new InvalidOperationException("Matrices size not compatible.");
        }

        public static Matrix operator * (Matrix lhs, Matrix rhs)
        {
            ValidateMultiplicationCompatibility(lhs, rhs);

            var resultant = new Matrix(rows: lhs.Rows, cols: rhs.Cols);

            // Do something here
            for (uint row = 0; row < lhs.Rows; row++)
            {
                for (uint col=0; col < rhs.Cols; col++)
                {
                    resultant[row, col] = getColRowSum(lhs, rhs, row, col, lhs.Cols);
                }
            }

            return resultant;

            static ComplexNumber getColRowSum(Matrix lhs, Matrix rhs, uint iRow, uint iCol, uint length)
            {
                var result = new ComplexNumber();

                for (uint i = 0; i < length; i++)
                {
                    result += (lhs[iRow, i] * rhs[i, iCol]);
                }

                return result;
            }
        }       

        public Matrix GetTensorProduct(Matrix multiplier)
        {
            var lhs = this;
            var rhs = multiplier;

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
