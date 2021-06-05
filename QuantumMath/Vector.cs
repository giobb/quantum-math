using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace QuantumMath
{
    public class Vector : Matrix
    {
        protected Vector(uint rows) : base(rows,1)
        {
            
        }

        public static Vector CreateInstance(uint rows)
            => new Vector(rows);
    }
}
