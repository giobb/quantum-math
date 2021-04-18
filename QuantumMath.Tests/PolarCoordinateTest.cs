using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuantumMath.Tests
{
    public class PolarCoordinateTest
    {
        [Fact]// Exam: 1.3.4
        public void ToComplexNumber()         
        {
            var pc0 = new PolarCoordinate(2, Phase.OnePI);
            var pc2 = pc0.ToComplexNumber();
            Assert.Equal(-2.0, Math.Round(pc2.Real));
            Assert.Equal(0, Math.Round(pc2.Imaginary));
        }

        [Fact] // Exam: 1.3.4
        public void ToComplexNumberConverterTest()
        {
            var pc0 = new PolarCoordinate(2, Phase.OnePI);
            var pc1 = (ComplexNumber)pc0;
            Assert.Equal(-2.0, Math.Round(pc1.Real));
            Assert.Equal(0, Math.Round(pc1.Imaginary));
        }

        [Theory]
        [InlineData(2,-1,1,1,3,0)]  // Exer 1.3.1
        public void AdditionOperatorTest(double r0, double i0, 
                                         double r1, double i1,
                                          double r2, double i2)
        {
            var pc0 = (new ComplexNumber(r0, i0)).ToPolarCoordinate();
            var pc1 = (new ComplexNumber(r1, i1)).ToPolarCoordinate();

            var pc2 = pc0 + pc1;
            var cn = pc2.ToComplexNumber();
            Assert.Equal(r2, Math.Round(cn.Real));
            Assert.Equal(i2, Math.Round(cn.Imaginary));
        }

        [Theory]
        [InlineData(2, -1, 1, 1, 1, -2)]  // Exer 1.3.2
        public void SubtractionOperatorTest(double r0, double i0,
                                         double r1, double i1,
                                          double r2, double i2)
        {
            var pc0 = (new ComplexNumber(r0, i0)).ToPolarCoordinate();
            var pc1 = (new ComplexNumber(r1, i1)).ToPolarCoordinate();

            var pc2 = pc0 - pc1;
            var cn = pc2.ToComplexNumber();
            Assert.Equal(r2, Math.Round(cn.Real));
            Assert.Equal(i2, Math.Round(cn.Imaginary));
        }

        [Theory]
        [InlineData(1, 1, -1, 1, -2, 0)]
        public void MultiplicationOperatorTest(double r0, double i0,
                                         double r1, double i1,
                                          double r2, double i2)
        {
            var pc0 = (new ComplexNumber(r0, i0)).ToPolarCoordinate();
            var pc1 = (new ComplexNumber(r1, i1)).ToPolarCoordinate();

            var pc2 = pc0 * pc1;
            var cn = pc2.ToComplexNumber();
            Assert.Equal(r2, Math.Round(cn.Real));
            Assert.Equal(i2, Math.Round(cn.Imaginary));
        }

        [Theory]
        [InlineData(-1, 3, -1, -4, 0.7670, 3.7083)] // Exam 1.3.5
        public void DivisionOperatorTest(double r0, double i0,
                                         double r1, double i1,
                                          double m0, double p0)
        {
            var pc0 = (new ComplexNumber(r0, i0)).ToPolarCoordinate();
            var pc1 = (new ComplexNumber(r1, i1)).ToPolarCoordinate();

            var pc2 = pc0 / pc1;
           
            Assert.Equal(m0, Math.Round(pc2.Modulos,4));
            Assert.Equal(p0, Math.Round(pc2.Phase,4));

            // Exer 1.3.7
            pc0 = (new ComplexNumber(2, 2)).ToPolarCoordinate();
            pc1 = (new ComplexNumber(1, -1)).ToPolarCoordinate();

            pc2 = pc0 / pc1;
            var cn = pc2.ToComplexNumber();

            Assert.Equal(0, Math.Round(cn.Real, 4));
            Assert.Equal(2, Math.Round(cn.Imaginary, 4));
        }

        [Fact]
        public void PowerOperatorTest()
        {
            var pc0 = (new ComplexNumber(1, -1)).ToPolarCoordinate();

            var pc1 = pc0 ^ 5;
            var cn0 = pc1.ToComplexNumber();

            Assert.Equal(-4,Math.Round(cn0.Real,4));
            Assert.Equal(4, Math.Round(cn0.Imaginary,4));
        }

        [Fact]
        public void NthRootTest()
        {
            var pc0 = (new ComplexNumber(1, 1)).ToPolarCoordinate();

            var pc = pc0.NthRoot(3).ToArray();

            var cn0 = pc[0].ToComplexNumber();
            Assert.Equal(1.0842, Math.Round(cn0.Real,4));
            Assert.Equal(0.2905, Math.Round(cn0.Imaginary,  4));

            var cn1 = pc[1].ToComplexNumber();
            Assert.Equal(-0.7937, Math.Round(cn1.Real, 4));
            Assert.Equal(0.7937, Math.Round(cn1.Imaginary, 4));

            var cn2 = pc[2].ToComplexNumber();
            Assert.Equal(-0.2905, Math.Round(cn2.Real, 4));
            Assert.Equal(-1.0842, Math.Round(cn2.Imaginary, 4));

        }
    }
}
