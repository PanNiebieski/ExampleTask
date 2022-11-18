using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain
{
    public class DeveloperId
    {
        public int Value { get; set; }

        public DeveloperId(int value)
        {
            Value = value;
        }

        public DeveloperId()
        {
            Value = default;
        }
    }
}
