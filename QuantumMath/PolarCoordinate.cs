using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace QuantumMath
{
    public class PolarCoordinate
    {
        public PolarCoordinate(double magnitude, double phase)
        {
            Magnitude = magnitude;
            Phase = phase;
        }

        public double Magnitude { get;  }

        public double Phase { get; set; }

        public static PolarCoordinate operator + (PolarCoordinate lhs, PolarCoordinate rhs)
            => throw new NotImplementedException();

        public static PolarCoordinate operator -(PolarCoordinate lhs, PolarCoordinate rhs) 
            => throw new NotImplementedException();

        public static PolarCoordinate operator * (PolarCoordinate lhs, PolarCoordinate rhs) 
            => throw new NotImplementedException();

        public static PolarCoordinate operator /(PolarCoordinate lhs, PolarCoordinate rhs) 
            => throw new NotImplementedException();

        public override string ToString()
        {
            return base.ToString();
        }

        static ComplexNumber ToComplexNumber(ref PolarCoordinate obj)
        {
            throw new NotImplementedException();
        }

        public ComplexNumber ToComplexNumber() => throw new NotImplementedException();

        public static explicit operator ComplexNumber(PolarCoordinate obj)
        {
            throw new NotImplementedException();
        }
    }
}
