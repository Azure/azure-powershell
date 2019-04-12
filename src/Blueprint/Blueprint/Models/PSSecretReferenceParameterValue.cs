using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSSecretReferenceParameterValue: PSParameterValueBase
    {
        public PSSecretValueReference Reference { get; set; }
    }
}
