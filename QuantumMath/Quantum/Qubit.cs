using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace QuantumMath.Quantum
{
    public class Qubit
    {
        internal Matrix _state;
        internal IList<Matrix> _appliedGates;
                       
        public static Qubit Zero
        {
            get
            {
                var qubit = new Qubit();
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

        private Qubit() 
        {
            _state = new Matrix(2, 1);
            _appliedGates = new List<Matrix>();
        }   
        
        public Qubit I()
        {
            _state = Gates.I * _state;
            _appliedGates.Add(Gates.I);
            return this;
        }

        public Qubit X()
        {
            _state = Gates.X * _state;
            _appliedGates.Add(Gates.I);
            return this;
        }

        public Qubit CNot(Qubit target)
        {
            _state = Gates.CNot * _state.GetTensorProduct(target._state);
            _appliedGates.Add(Gates.CNot);
            return this;
        }
        
        public Qubit Apply(Matrix gate)
        {
            if (!gate.IsUnitary())
                throw new ArgumentException("Gate is not unitary.");
            _state = gate * _state;
            return this;
        }   
        
        public Qubit Reset()
        {
            _state = new Matrix(2, 1);
            _appliedGates.Clear();
            return this;
        }
    }
}
