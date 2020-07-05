using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data.Common;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace QuantumMath
{
    public struct ComplexNumber
    {
        public double RealPart { get; }
        public double ImaginaryPart { get; }

        public double Modulos 
        { 
            get => Math.Sqrt(Math.Pow(RealPart, 2) + Math.Pow(ImaginaryPart, 2));
        }

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

        public ComplexNumber GetConjugate() =>
            new ComplexNumber(RealPart, (-1.0) * ImaginaryPart);
           
        public override string ToString() {

            double roundedReal = Math.Round(RealPart,2);
            double roundedImaginary = Math.Round(ImaginaryPart,2);

            string real = roundedReal == 0 ? "" : roundedReal.ToString();

            string imaginary = roundedImaginary >= -1 && roundedImaginary <= 1 ? "" :
                roundedImaginary.ToString();

            string imaginarySign = "";

            if (roundedImaginary == -1)
                imaginarySign = "-";
            else if (roundedImaginary >= 1 && roundedReal != 0)
                imaginarySign = "+";

            string i = roundedImaginary != 0 ? "i" : ""; 

            string retVal = $"{real}{imaginarySign}{imaginary}{i}";

            return retVal;          
        }

        static PolarCoordinate ToPolarCoordinate(ref ComplexNumber obj)
        {
            double magnitude = Math.Sqrt(Math.Pow(obj.RealPart, 2) + Math.Pow(obj.ImaginaryPart, 2));

            double phase = Math.Atan2(obj.ImaginaryPart,obj.RealPart);

            return new PolarCoordinate(magnitude, phase);
        }

        public PolarCoordinate ToPolarCoordinate()
        {
            return ToPolarCoordinate(ref this);
        }

        public static explicit operator PolarCoordinate(ComplexNumber obj)
        {
            return ToPolarCoordinate(ref obj);
        }
     
    }
}