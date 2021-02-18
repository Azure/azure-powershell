using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSIntegrationRuntimeKeys
    {
        public PSIntegrationRuntimeKeys(string key1, string key2)
        {
            AuthKey1 = key1;
            AuthKey2 = key2;
        }

        public string AuthKey1 { get; private set; }

        public string AuthKey2 { get; private set; }
    }
}
