using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSClientCertificate
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string Name { get; set; }


        [Ps1Xml(Label = "Thumbprint", Target = ViewControl.Table)]
        public string Thumbprint { get; set; }
    }
}
