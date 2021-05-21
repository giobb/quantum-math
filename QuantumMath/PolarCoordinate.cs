using System;
using System.Collections.Generic;

namespace QuantumMath
{
    public struct PolarCoordinate
    {
        public PolarCoordinate(double modulos
            , double phase)
        {
            Modulos = modulos;
            Phase = phase;
        }

        public double Modulos { get; }

        /// <summary>
        /// Gets the phase (angle) in degrees
        /// </summary>
        public double Phase { get; }

        public static PolarCoordinate operator +(PolarCoordinate lhs, PolarCoordinate rhs)
        {
            var x = GetX(ref lhs) + GetX(ref rhs);
            var y = GetY(ref lhs) + GetY(ref rhs);
            var phase = Math.Atan2(y, x);
            var modulos = Math.Sqrt(x * x + y * y);
            return new PolarCoordinate(phase: phase, modulos: modulos);
        }

        public static PolarCoordinate operator -(PolarCoordinate lhs, PolarCoordinate rhs)
        {
            var reversedRhs = new PolarCoordinate(modulos: rhs.Modulos, phase: rhs.Phase + Math.PI);
            return (lhs + reversedRhs);

        }

        public static PolarCoordinate operator *(PolarCoordinate lhs, PolarCoordinate rhs)
            => new(modulos: lhs.Modulos * rhs.Modulos,
                                     phase: lhs.Phase + rhs.Phase);

        public static PolarCoordinate operator /(PolarCoordinate lhs, PolarCoordinate rhs)
            => new(modulos: lhs.Modulos / rhs.Modulos,
                                     phase: lhs.Phase - rhs.Phase);

        public static PolarCoordinate operator ^(PolarCoordinate lhs, uint power)
            => new(Math.Pow(lhs.Modulos, power), lhs.Phase * power);

        public PolarCoordinate Pow(uint power)
         => new(Math.Pow(Modulos, power), Phase * power);

        public IEnumerable<PolarCoordinate> NthRoot(uint root)
        {
            var convertedRoot = (double)root;
            var modulos = Math.Pow(Modulos, 1 / convertedRoot);
            double phase;
            for (var k = 0; k < root; k++)
            {
                phase = (Phase + k * QuantumMath.Phase.TwoPI) / convertedRoot;
                yield return new PolarCoordinate(modulos, phase);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        static ComplexNumber ToComplexNumber(ref PolarCoordinate obj)
        {
            var x = GetX(ref obj);
            var y = GetY(ref obj);
            return new ComplexNumber(realPart: x, imaginaryPart: y);
        }

        static double GetX(ref PolarCoordinate obj)
            => obj.Modulos * Math.Cos(obj.Phase);

        static double GetY(ref PolarCoordinate obj)
            => obj.Modulos * Math.Sin(obj.Phase);

        public ComplexNumber ToComplexNumber() => ToComplexNumber(ref this);

        public static explicit operator ComplexNumber(PolarCoordinate obj) =>
            ToComplexNumber(ref obj);

    }
}
