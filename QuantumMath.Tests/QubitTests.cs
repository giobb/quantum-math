using QuantumMath.Quantum;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace QuantumMath.Tests
{
    public class QubitTests
    {
        [Fact]
        public void ToString0Test()
        {
            var target = new Qubit();
            Assert.Equal("|0>", target.ToString());
        }

        [Fact]
        public void ToString1Test()
        {
            var target = new Qubit();
            target.Apply(Gate.X);
            Assert.Equal("|1>", target.ToString());
        }
    }
}
