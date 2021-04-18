using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Numerics;
using System.Text;

namespace QuantumMath
{
    public class Matrix
    {
        readonly ComplexNumber[,] _array;

        public Matrix(uint height, uint length)
        {
            Rows = height;
            Cols = length;

            _array = new ComplexNumber[Rows, Cols];

        }

        public uint Rows { get; }

        public uint Cols { get; }

        public bool IsSquare() => Rows == Cols;

        public bool IsSymmetric() => throw new NotImplementedException();

        public bool IsInvertible() => throw new NotImplementedException();

        public bool IsUnitary() => throw new NotImplementedException();

        public bool IsHermitian() => throw new NotImplementedException();

        public Matrix GetTranspose() => throw new NotImplementedException();

        public Matrix GetAdjoint() => throw new NotImplementedException();

        public ComplexNumber this[uint m, uint n]
        {
            get => _array[m, n];
            set => _array[m, n] = value;
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

            var resultant = new Matrix(height: lhs.Rows, length: rhs.Cols);

            // Do something here
            for (uint row = 0; row < lhs.Rows; row++)
            {
                for (uint col=0; col < rhs.Cols; col++)
                {
                    resultant[row, col] = getColRowSum(lhs, rhs, row, col, lhs.Rows);
                }
            }

            return resultant;

            static ComplexNumber getColRowSum(Matrix lhs, Matrix rhs, uint rows, uint cols, uint length)
            {
                ComplexNumber result = new ComplexNumber();

                for (uint i = 0; i < length; i++)
                {
                    result += (lhs[rows, i] * rhs[i, cols]);
                }

                return result;
            }
        }

        public Matrix TensorMultiply(Matrix rhs)
        {
            throw new NotImplementedException();
        }
    }
}
