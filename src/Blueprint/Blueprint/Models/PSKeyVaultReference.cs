using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSKeyVaultReference
    {
        public string Id { get; private set; }

        public PSKeyVaultReference(string id = null)
        {
            Id = id;
        }
    }
}
