using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    internal class PSSigningCertificate
    {
        public string Thumbprint { get; set; }
        public string Subject { get; set; }

    }
}
