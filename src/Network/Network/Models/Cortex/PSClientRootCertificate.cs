using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSClientRootCertificate
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string Name { get; set; }


        [Ps1Xml(Label = "PublicCertData", Target = ViewControl.Table)]
        public string PublicCertData { get; set; }
    }
}
