using Xunit;
using static QuantumMath.Quantum.Gate;

namespace QuantumMath.Tests
{

    public class MatrixTests
    {
       


        [Fact]
        public void GetTranspose()
        {
            var target = new Matrix(1,1);
            target[0, 0] = new ComplexNumber(1, 2);
        }


        [Fact]
        public void MultiplyXby1Qubit()
        {
            var qbit = new Matrix(2, 1);
            qbit[0,0] = new ComplexNumber(1D, 0D);
            qbit[1,0] = new ComplexNumber(); 

            var res = X * qbit;

            Assert.Equal(2u, res.Rows);
            Assert.Equal(1u, res.Cols);
            Assert.Equal(0d, res[0, 0].Real);
            Assert.Equal(0d, res[0, 0].Imaginary);
            Assert.Equal(1d, res[1, 0].Real);
            Assert.Equal(0d, res[1, 0].Imaginary);

        }

        [Fact]
        public void MultiplyIBy1Qubit()
        {
            var qbit = new Matrix(2, 1);
            qbit[0, 0] = new ComplexNumber(1D, 0D);
            qbit[1, 0] = new ComplexNumber(); // 0 + 0i

            var res = I * qbit;

            Assert.Equal(1d, res[0, 0].Real);
            Assert.Equal(0d, res[0, 0].Imaginary);
            Assert.Equal(0d, res[1, 0].Real);
            Assert.Equal(0d, res[1, 0].Imaginary);

        }

    }
}
