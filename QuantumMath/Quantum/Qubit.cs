using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace QuantumMath.Quantum
{
    public class Qubit
    {

        readonly Stack<Matrix> _appliedGates;
        Matrix _state;

        public Qubit()
        {
            _appliedGates = new Stack<Matrix>();
            _state = new Matrix(2, 1);
            Reset();
        }

        public IEnumerable<Matrix> AppliedGates
        {
            get => _appliedGates.AsEnumerable();
        }
        
        public void Apply(params Matrix[] gates)
        {
            foreach (Matrix g in gates)
            {
                _state = g * _state;       
                _appliedGates.Push(g);
            }
        }

        public void Undo()
        {
            _state = _appliedGates.Pop() *  _state;
        }

        public void Reset()
        {
            _state[0, 0] = new ComplexNumber(1, 0);
            _appliedGates.Clear();
        }

        public override string ToString()
            => _state[0, 0].Real == 1D ? "|0>" : "|1>";

    }
}
