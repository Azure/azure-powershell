using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSConnectionMonitorWorkspaceSettings
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string WorkspaceResourceId { get; set; }
    }
}
