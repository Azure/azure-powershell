using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models.ADObject
{
    internal class PSADServicePrincipal : PSADObject
    {
        public string[] ServicePrincipalNames { get; set; }

        public Guid ApplicationId { get; set; }

        public string ObjectType => "ServicePrincipal";
    }
}
