using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters
{
    class AFSConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }
    }
}
