using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace QuantumMath
{
    public struct ComplexNumber
    {
        #region Properties

        public double Real { get; }
        public double Imaginary { get; }
        public double Modulos
        {
            get => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        }

        #endregion

        #region Ctors and Factories

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            Real = realPart;
            Imaginary = imaginaryPart;
        }

        public static ComplexNumber Zero
        {
            get => new ComplexNumber();
        }

        public static ComplexNumber One
        {
            get => new ComplexNumber(1, 0);
        }       

        //public static ComplexNumber CreateInstance(double realPart, double imaginaryPart)
        //{
        //    return new ComplexNumber(realPart, imaginaryPart);
        //}

        public static ComplexNumber[] CreateInstances(params double[] reals)
        {
            var list = new List<ComplexNumber>();
            foreach (int i in reals)
            {
                list.Add(new ComplexNumber(i, 0));
            }
            return list.ToArray();
        }

        #endregion

        #region Operator Overloads 

        public static ComplexNumber operator +(ComplexNumber lhs, ComplexNumber rhs) =>
             new ComplexNumber(lhs.Real + rhs.Real, lhs.Imaginary + rhs.Imaginary);

        public static ComplexNumber operator -(ComplexNumber lhs, ComplexNumber rhs) =>
            new ComplexNumber(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);


        public static ComplexNumber operator *(ComplexNumber lhs, ComplexNumber rhs) =>
            new ComplexNumber(realPart: (lhs.Real * rhs.Real) - (lhs.Imaginary * rhs.Imaginary),
                              imaginaryPart: (lhs.Real * rhs.Imaginary) + (lhs.Imaginary * rhs.Real));

        public static ComplexNumber operator /(ComplexNumber lhs, ComplexNumber rhs)
        {
            var denominator = Math.Pow(rhs.Real, 2) + Math.Pow(rhs.Imaginary, 2);
            var realPart = (rhs.Real * lhs.Real + rhs.Imaginary * lhs.Imaginary) / denominator;
            var imaginaryPart = (rhs.Real * lhs.Imaginary - lhs.Real * rhs.Imaginary) / denominator;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public static bool operator ==(ComplexNumber lhs, ComplexNumber rhs)
            => lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary;

        public static bool operator !=(ComplexNumber lhs, ComplexNumber rhs)
            => !(lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary);

        public static ComplexNumber operator ^(ComplexNumber lhs, uint power)
            => lhs.ToPolarCoordinate().Pow(power).ToComplexNumber();

        #endregion

        #region Other Math functions
        public ComplexNumber GetConjugate() 
            => new ComplexNumber(Real, (-1.0) * Imaginary);

        public IEnumerable<ComplexNumber> NthRoot(uint root)
        {
            var pc = ToPolarCoordinate().NthRoot(root);
            foreach (var p in pc)
            {
                yield return p.ToComplexNumber();
            }

        }

        #endregion

        #region To Polar Coordinate

        private static PolarCoordinate ToPolarCoordinate(ref ComplexNumber obj)
        {
            double magnitude = Math.Sqrt(Math.Pow(obj.Real, 2) + Math.Pow(obj.Imaginary, 2));

            double phase = Math.Atan2(obj.Imaginary, obj.Real);

            return new PolarCoordinate(magnitude, phase);
        }

        public PolarCoordinate ToPolarCoordinate() 
            => ToPolarCoordinate(ref this);

        public static explicit operator PolarCoordinate(ComplexNumber obj)
            => ToPolarCoordinate(ref obj);

        #endregion

        #region Object overloads

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

        public override bool Equals(object obj)
        {
            return obj is ComplexNumber number &&
                   Real == number.Real &&
                   Imaginary == number.Imaginary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }

        #endregion
    }
}