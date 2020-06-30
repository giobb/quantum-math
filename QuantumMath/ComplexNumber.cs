﻿using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data.Common;
using System.IO;
using System.Runtime.CompilerServices;

namespace QuantumMath
{
    public class ComplexNumber
    {
        public double RealPart { get; }
        public double ImaginaryPart { get; }

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }

        public static ComplexNumber operator +(ComplexNumber lhs, ComplexNumber rhs) =>
             new ComplexNumber(lhs.RealPart + rhs.RealPart, lhs.ImaginaryPart + rhs.ImaginaryPart); 
        

        public static ComplexNumber operator -(ComplexNumber lhs, ComplexNumber rhs) =>

            new ComplexNumber(lhs.RealPart - rhs.RealPart, lhs.ImaginaryPart - rhs.ImaginaryPart);
        

        public static ComplexNumber operator *(ComplexNumber lhs, ComplexNumber rhs) =>
            new ComplexNumber(realPart: (lhs.RealPart * rhs.RealPart) - (lhs.ImaginaryPart * rhs.ImaginaryPart),
                              imaginaryPart: (lhs.RealPart * rhs.ImaginaryPart) + (lhs.ImaginaryPart * rhs.RealPart));

        public static ComplexNumber operator /(ComplexNumber lhs, ComplexNumber rhs)
        {
            var denominator = Math.Pow(rhs.RealPart, 2) + Math.Pow(rhs.ImaginaryPart, 2);
            var realPart = (rhs.RealPart * lhs.RealPart + rhs.ImaginaryPart * lhs.ImaginaryPart) / denominator;
            var imaginaryPart = (rhs.RealPart * lhs.ImaginaryPart - lhs.RealPart * rhs.ImaginaryPart) / denominator;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public override string ToString() {

            static string GetValueWithSign(double value)
            {
                if (value > 0)
                    return $" + {value}";
                if (value < 0)
                    return $" - {value}";
                return "";
            }

            string real = GetValueWithSign(value: RealPart);

            string imaginary = GetValueWithSign(value: ImaginaryPart);

            return ($"{real}{imaginary}").TrimStart('+');
        }

        static PolarCoordinate ToPolarCoordinate(ComplexNumber obj)
        {
            double magnitude = Math.Sqrt(Math.Pow(obj.RealPart, 2) + Math.Pow(obj.ImaginaryPart, 2));
            double phase = Math.Tan(obj.ImaginaryPart / obj.RealPart);
            return new PolarCoordinate(magnitude, phase);

        }

        public PolarCoordinate ToPolarCoordinate()
        {
            return ToPolarCoordinate(this);
        }

        public static explicit operator PolarCoordinate(ComplexNumber obj)
        {
            return ToPolarCoordinate(obj);
        }
     
    }
}