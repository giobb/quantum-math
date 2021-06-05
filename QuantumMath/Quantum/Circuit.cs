using System.Collections.Generic;

namespace QuantumMath.Quantum
{
    public class Circuit
    {
        IList<Matrix> _qubits = new List<Matrix>();
        Matrix _state;
        IList<IDictionary<int, Matrix>> _appliedGates;


    }
}
