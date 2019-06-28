using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class AttestationCreationParameters
    {
        public string ProviderName { get; set; }
        public string ResourceGroupName { get; set; }
        public string AttestationPolicy { get; set; }
    }
}
