using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    class PSParameterValue : PSParameterValueBase
    {
        public object Value { get; set; }
    }
}
