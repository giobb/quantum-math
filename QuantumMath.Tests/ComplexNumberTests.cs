using System;
using System.Security.Cryptography;
using Xunit;

namespace QuantumMath.Tests
{
    public class ComplexNumberTests
    {
        [Theory]
        [InlineData(3,-1, 1, 4, 4, 3)]      // Sample: 
        [InlineData(1,-1, 1,-1, 2, -2)]     // Exer: 

        public void AddOperatorTest(double r0, double i0,double r1,double i1, double r2,double i2)
        {
            var c0 = new ComplexNumber(r0, i0);
            var c1 = new ComplexNumber(r1, i1);

            var c2 = c0 + c1;
            Assert.Equal(r2, c2.RealPart);
            Assert.Equal(i2, c2.ImaginaryPart);
        }

        [Theory]
        [InlineData(3, -1, 1, 4, 2, -5)]      // Sample: 
        //[InlineData(1, -1, 1, -1, 2, -2)]     // Exer: 
        public void SubtractionOperatorTest(double r0, double i0, double r1, double i1, double r2, double i2)
        {
            var c0 = new ComplexNumber(r0, i0);
            var c1 = new ComplexNumber(r1, i1);

            var c2 = c0 - c1;
            Assert.Equal(r2, c2.RealPart);
            Assert.Equal(i2, c2.ImaginaryPart);
        }

        [Theory]
        [InlineData(3, -1, 1, 4, 7, 11)]
        public void MultiplicationOperatorTest(double r0, double i0, double r1, double i1, double r2, double i2)
        {
            var c0 = new ComplexNumber(r0, i0);
            var c1 = new ComplexNumber(r1, i1);

            var c2 = c0 * c1;
            Assert.Equal(r2, c2.RealPart);
            Assert.Equal(i2, c2.ImaginaryPart);
        }

        [Theory]
        [InlineData(-2, 1, 1, 2, 0, 1)]
        public void DivisiionOperatorTest(double r0, double i0, double r1, double i1, double r2, double i2)
        {
            var c0 = new ComplexNumber(r0, i0);
            var c1 = new ComplexNumber(r1, i1);

            var c2 = c0 / c1;
            Assert.Equal(r2, c2.RealPart);
            Assert.Equal(i2, c2.ImaginaryPart);
        }

        [Fact]
        public void GetConjugateTest()
        {
            var c0  = new ComplexNumber(1, 1);
            var c1 = c0.GetConjugate();

            Assert.Equal(1, c1.RealPart);
            Assert.Equal(-1, c1.ImaginaryPart);
        }

        [Fact]  // Exer 1.2.4
        public void ModulosTest()
        {
            var c0 = new ComplexNumber(4, -3);

            Assert.Equal(5, c0.Modulos);
        }

        [Theory]
        [InlineData(1, 0, "1")]
        [InlineData(-1, 0, "-1")]
        [InlineData(0, 1, "i")]
        [InlineData(0, -1, "-i")]
        [InlineData(0, -2, "-2i")]
        [InlineData(0, 2, "2i")]
        [InlineData(1, 1, "1+i")]
        [InlineData(1, 2, "1+2i")]
        [InlineData(-1, 2, "-1+2i")]
        [InlineData(-1, -2, "-1-2i")]
        public void ToStringTest(double real, double imaginary, string expected)
        {
            var c = new ComplexNumber(real, imaginary);
            Assert.Equal(expected, c.ToString());
        }

    }
}


