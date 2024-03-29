﻿using QuantumMath.Quantum;
using System.Reflection.Metadata;
using Xunit;
using Xunit.Sdk;
using static QuantumMath.Quantum.Gates;

namespace QuantumMath.Tests
{

    public class MatrixTests
    {
       


        [Fact]
        public void GetTranspose()
        {
            var target = new Matrix(1,1);
            target[0, 0] = new ComplexNumber(1, 2);
        }


        [Fact]
        public void MultiplyXbyQubit_1()
        {
            var qbit = new Matrix(2,1);
            qbit[0, 0] = ComplexNumber.Zero;
            qbit[1, 0] = ComplexNumber.One;

            var res = X * qbit;

            Assert.Equal(2u, res.Rows);
            Assert.Equal(1u, res.Cols);
            Assert.Equal(0d, res[1, 0].Real);
            Assert.Equal(0d, res[0, 0].Imaginary);
            Assert.Equal(1d, res[0, 0].Real);
            Assert.Equal(0d, res[1, 0].Imaginary);
        }

        [Fact]
        public void MultiplyIByQubit_1()
        {
            var qbit = new Matrix(2, 1);
            qbit[0, 0] = ComplexNumber.Zero;
            qbit[1, 0] = ComplexNumber.One; // 0 + 0i

            var res = I * qbit;

            Assert.Equal(0d, res[0, 0].Real);
            Assert.Equal(0d, res[0, 0].Imaginary);
            Assert.Equal(1d, res[1, 0].Real);
            Assert.Equal(0d, res[1, 0].Imaginary);
        }

        [Fact]
        public void CNOT00Test()
        {
            var qbit0 = new Matrix(2, 1);
            qbit0[0, 0] = ComplexNumber.One;
            qbit0[1, 0] = ComplexNumber.Zero;

            var qbit1 = new Matrix(2, 1);
            qbit1[0, 0] = ComplexNumber.One;
            qbit1[1, 0] = ComplexNumber.Zero;

            var res = qbit0.GetTensorProduct(qbit1);
            Assert.True(1 == res.Cols);
            Assert.True(4 == res.Rows);

            Assert.Equal(1d, res[0, 0].Real);
            Assert.Equal(0d, res[0, 0].Imaginary);
            Assert.Equal(0d, res[1, 0].Real);
            Assert.Equal(0d, res[1, 0].Imaginary);
                                    
            Assert.Equal(0d, res[2, 0].Real);
            Assert.Equal(0d, res[2, 0].Imaginary);
            Assert.Equal(0d, res[3, 0].Real);
            Assert.Equal(0d, res[3, 0].Imaginary);
        }

        [Fact]
        public void TensorTest()
        {
            Matrix matrix0 = new Matrix(2, 1);
            matrix0[0, 0] = ComplexNumber.One;
            matrix0[1, 0] = ComplexNumber.Zero;

            var matrix1 = new Matrix(2, 1);
            matrix1[0, 0] = ComplexNumber.One;
            matrix1[1, 0] = ComplexNumber.Zero;

            // |00>
            var res0 =  matrix0.GetTensorProduct(matrix1);

            Assert.Equal(1, res0[0, 0].Real);
            Assert.Equal(0, res0[0, 0].Imaginary);
            Assert.Equal(0, res0[1, 0].Real);
            Assert.Equal(0, res0[1, 0].Imaginary);
            Assert.Equal(0, res0[2, 0].Real);
            Assert.Equal(0, res0[2, 0].Imaginary);
            Assert.Equal(0, res0[3, 0].Real);
            Assert.Equal(0, res0[3, 0].Imaginary);

            var matrix2 = new Matrix(2, 1);
            matrix2[0, 0] = ComplexNumber.Zero;
            matrix2[1, 0] = ComplexNumber.One;

            // |001>
            var res1 = res0.GetTensorProduct(matrix2);

            Assert.Equal(0, res1[0, 0].Real);
            Assert.Equal(0, res1[0, 0].Imaginary);
            Assert.Equal(1, res1[1, 0].Real);
            Assert.Equal(0, res1[1, 0].Imaginary);
            Assert.Equal(0, res1[2, 0].Real);
            Assert.Equal(0, res1[2, 0].Imaginary);
            Assert.Equal(0, res1[3, 0].Real);
            Assert.Equal(0, res1[3, 0].Imaginary);
            Assert.Equal(0, res1[4, 0].Real);
            Assert.Equal(0, res1[4, 0].Imaginary);
            Assert.Equal(0, res1[5, 0].Real);
            Assert.Equal(0, res1[5, 0].Imaginary);
            Assert.Equal(0, res1[6, 0].Real);
            Assert.Equal(0, res1[6, 0].Imaginary);
            Assert.Equal(0, res1[7, 0].Real);
            Assert.Equal(0, res1[7, 0].Imaginary);

        }

    }
}
