using System;
using System.Linq;
using System.Security.Cryptography;
using Xunit;

namespace QuantumMath.Tests
{
    public class ComplexNumberTests
    {
        [Fact]
        public void ToPolarCoordinatTest()
        {
            var c0 = new ComplexNumber(1, 1);
            var pc0 = c0.ToPolarCoordinate();
            Assert.Equal(Math.Sqrt(2), pc0.Modulos);
            Assert.Equal(Math.PI/4, pc0.Phase);

            c0 = new ComplexNumber(3, 0);
            pc0 = c0.ToPolarCoordinate();
            Assert.Equal(3, pc0.Modulos);
            Assert.Equal(Phase.ZeroPI, pc0.Phase);
        }

        [Fact]
        public void ToPolarCoordinatConverter()
        {
            var c0 = new ComplexNumber(realPart: -2, imaginaryPart: 0);
            var pc0 = (PolarCoordinate)c0;
            Assert.Equal(2, pc0.Modulos);
            Assert.Equal(Phase.OnePI, pc0.Phase);
        }

        [Theory]
        [InlineData(3, -1, 1, 4, 4, 3)] // Exam: 1.1.2
        [InlineData(-3, 1, 2, -4, -1, -3)] // Exer: 1.1.3
        [InlineData(2, -1, 1, 1, 3, 0)]
        public void AddOperatorTest(double r0, double i0,double r1,double i1, double r2,double i2)
        {
            var c0 = new ComplexNumber(r0, i0);
            var c1 = new ComplexNumber(r1, i1);

            var c2 = c0 + c1;
            Assert.Equal(r2, c2.RealPart);
            Assert.Equal(i2, c2.ImaginaryPart);
        }

        [Theory]
        [InlineData(3, -1, 1, 4, 2, -5)]      // Exam: 
        public void SubtractionOperatorTest(double r0, double i0, double r1, double i1, double r2, double i2)
        {
            var c0 = new ComplexNumber(r0, i0);
            var c1 = new ComplexNumber(r1, i1);

            var c2 = c0 - c1;
            Assert.Equal(r2, c2.RealPart);
            Assert.Equal(i2, c2.ImaginaryPart);
        }

        [Theory]
        [InlineData(-3, 1, 2, -4, -2, 14)]     // Exer: 1.1.3
        [InlineData(3, -2, 1, 2, 7, 4)] // Ex. 1.2.1
        [InlineData(3, -1, 1, 4, 7, 11)] // Exer 1.2.1
        public void MultiplicationOperatorTest(double r0, double i0, double r1, double i1, double r2, double i2)
        {
            var c0 = new ComplexNumber(r0, i0);
            var c1 = new ComplexNumber(r1, i1);

            var c2 = c0 * c1;
            Assert.Equal(r2, c2.RealPart);
            Assert.Equal(i2, c2.ImaginaryPart);
        }

        [Theory]
        [InlineData(-2, 1, 1, 2, 0, 1)]         // Exam 1.2.2
        [InlineData(0, 3, -1, -1, -1.5, -1.5)]  // Exer. 1.2.3
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

        [Fact]
        public void NthRootTest()
        {
            var cn = new ComplexNumber(1, 1);

            var roots = cn.NthRoot(3).ToArray();

            var cn0 = roots[0];
            Assert.Equal(1.0842, Math.Round(cn0.RealPart, 4));
            Assert.Equal(0.2905, Math.Round(cn0.ImaginaryPart, 4));

            var cn1 = roots[1];
            Assert.Equal(-0.7937, Math.Round(cn1.RealPart, 4));
            Assert.Equal(0.7937, Math.Round(cn1.ImaginaryPart, 4));

            var cn2 = roots[2];
            Assert.Equal(-0.2905, Math.Round(cn2.RealPart, 4));
            Assert.Equal(-1.0842, Math.Round(cn2.ImaginaryPart, 4));

        }

        [Fact]
        public void PowerOperatorTest()
        {
            var pc0 = new ComplexNumber(1, -1);

            var pc1 = pc0 ^ 5;

            Assert.Equal(-4, Math.Round(pc1.RealPart, 4));
            Assert.Equal(4, Math.Round(pc1.ImaginaryPart, 4));
        }

        [Fact]
        public void PowTest()
        {
            var pc0 = new ComplexNumber(1, -1);

            var pc1 = pc0.Pow(5);

            Assert.Equal(-4, Math.Round(pc1.RealPart, 4));
            Assert.Equal(4, Math.Round(pc1.ImaginaryPart, 4));
        }
    }
}


