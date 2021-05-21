using System;
using System.Collections.Generic;

namespace QuantumMath
{
    public struct ComplexNumber
    {
        public double Real { get; }
        public double Imaginary { get; }

        public double Modulos
        {
            get => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        }

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            Real = realPart;
            Imaginary = imaginaryPart;
        }

        public static ComplexNumber operator +(ComplexNumber lhs, ComplexNumber rhs) =>
             new(lhs.Real + rhs.Real, lhs.Imaginary + rhs.Imaginary);

        public static ComplexNumber operator -(ComplexNumber lhs, ComplexNumber rhs) =>
            new(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);


        public static ComplexNumber operator *(ComplexNumber lhs, ComplexNumber rhs) =>
            new(realPart: (lhs.Real * rhs.Real) - (lhs.Imaginary * rhs.Imaginary),
                              imaginaryPart: (lhs.Real * rhs.Imaginary) + (lhs.Imaginary * rhs.Real));

        public static ComplexNumber operator /(ComplexNumber lhs, ComplexNumber rhs)
        {
            var denominator = Math.Pow(rhs.Real, 2) + Math.Pow(rhs.Imaginary, 2);
            var realPart = (rhs.Real * lhs.Real + rhs.Imaginary * lhs.Imaginary) / denominator;
            var imaginaryPart = (rhs.Real * lhs.Imaginary - lhs.Real * rhs.Imaginary) / denominator;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public ComplexNumber GetConjugate() =>
            new(Real, (-1.0) * Imaginary);

        public static ComplexNumber operator ^(ComplexNumber lhs, uint power)
        {
            var temp = lhs.ToPolarCoordinate().Pow(power);
            return temp.ToComplexNumber();
        }

        public static bool operator ==(ComplexNumber lhs, ComplexNumber rhs)
            => lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary;

        public static bool operator !=(ComplexNumber lhs, ComplexNumber rhs)
            => !(lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary);

        public ComplexNumber Pow(uint power)
         => this ^ power;

        public IEnumerable<ComplexNumber> NthRoot(uint root)
        {
            var pc = ToPolarCoordinate().NthRoot(root);
            foreach (var p in pc)
            {
                yield return p.ToComplexNumber();
            }

        }

        public override string ToString()
        {

            double roundedReal = Math.Round(Real, 2);
            double roundedImaginary = Math.Round(Imaginary, 2);

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
            double magnitude = Math.Sqrt(Math.Pow(obj.Real, 2) + Math.Pow(obj.Imaginary, 2));

            double phase = Math.Atan2(obj.Imaginary, obj.Real);

            return new PolarCoordinate(magnitude, phase);
        }

        public PolarCoordinate ToPolarCoordinate() => ToPolarCoordinate(ref this);

        public static explicit operator PolarCoordinate(ComplexNumber obj)
            => ToPolarCoordinate(ref obj);

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}