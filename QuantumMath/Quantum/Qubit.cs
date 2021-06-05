using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace QuantumMath.Quantum
{
    public enum QubitValue
    {
        Zero,
        One
    }

    public class Qubit : Vector
    {
        public static Qubit CreateInstance(Matrix state)
        {
            var qubit = new Qubit();
            return qubit;
        }
                       
        public static Qubit Zero
        {
            get
            {
                Matrix qubit = new Qubit()
                qubit._state[0, 0] = ComplexNumber.One;
                return qubit;
            }
        }

        public static Qubit One
        {
            get
            {
                var qubit = new Qubit();
                qubit._state[1, 0] = ComplexNumber.One;
                return qubit;
            }
        }


        private Qubit() : base(2)
        {
           
        }       
        
        public Qubit Apply(Matrix gate)
        {
            return this * gate;       
        }       

        public override string ToString()
            => _state[0, 0].Real == 1D ? "|0>" : "|1>";

    }
}
