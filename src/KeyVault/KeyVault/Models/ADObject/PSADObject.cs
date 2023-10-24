using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models.ADObject
{
    internal class PSADObject
    {
        public string DisplayName { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
