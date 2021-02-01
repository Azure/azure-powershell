using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public class SecurityDomainRestoreData
    {
        public SecurityDomainRestoreData()
        {
            EncData = new EncData();
            WrappedKey = new Key();
        }
        public EncData EncData { get; set; }
        public Key WrappedKey { get; set; }
    }
}
