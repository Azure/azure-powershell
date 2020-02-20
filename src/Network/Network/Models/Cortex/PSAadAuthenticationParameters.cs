using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAadAuthenticationParameters
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string AadTenant { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string AadAudience { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string AadIssuer { get; set; }
    }
}
