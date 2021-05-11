using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace QuantumMath.Quantum
{
    public class Qubit
    {

        readonly IList<Matrix> _appliedGates;
        Matrix _theQubit;

        public Qubit()
        {
            _appliedGates = new List<Matrix>();
            _theQubit = new Matrix(2, 1);
        }

        public IEnumerable<Matrix> AppliedGates
        {
            get => _appliedGates.AsEnumerable();
        }
        
        public void Apply(Matrix gate)
        {
            _theQubit = gate * _theQubit;
            _appliedGates.Add(gate);
        }

        public void Undo()
        {
            _theQubit = _appliedGates[_appliedGates.Count - 1] *  _theQubit;
            _appliedGates.RemoveAt(_appliedGates.Count - 1);
        }
    }
}
