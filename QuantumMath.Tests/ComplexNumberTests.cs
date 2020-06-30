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

    }
}


