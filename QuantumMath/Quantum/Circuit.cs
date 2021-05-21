using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumMath.Quantum
{
    public class Circuit
    {
        IList<Qubit> _qubits = new List<Qubit>();
        Matrix _state;
    }
}
