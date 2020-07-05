﻿using System;
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
            Assert.Equal(-2.0, Math.Round(pc2.RealPart));
            Assert.Equal(0, Math.Round(pc2.ImaginaryPart));
        }

        [Fact] // Exam: 1.3.4
        public void ToComplexNumberConverterTest()
        {
            var pc0 = new PolarCoordinate(2, Phase.OnePI);
            var pc1 = (ComplexNumber)pc0;
            Assert.Equal(-2.0, Math.Round(pc1.RealPart));
            Assert.Equal(0, Math.Round(pc1.ImaginaryPart));
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
            Assert.Equal(r2, Math.Round(cn.RealPart));
            Assert.Equal(i2, Math.Round(cn.ImaginaryPart));
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
            Assert.Equal(r2, Math.Round(cn.RealPart));
            Assert.Equal(i2, Math.Round(cn.ImaginaryPart));
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
            Assert.Equal(r2, Math.Round(cn.RealPart));
            Assert.Equal(i2, Math.Round(cn.ImaginaryPart));
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 1, 1)]
        public void DivisionOperatorTest(double m0, double p0, double m1, double p1,
                                         double m2, double p2)
        {
            var pc0 = new PolarCoordinate(m0, p0);
            var pc1 = new PolarCoordinate(m1, p1);
            var pc2 = pc0 / pc1;
            Assert.Equal(m2, pc2.Modulos);
            Assert.Equal(p2, pc2.Phase);
        }

    }
}