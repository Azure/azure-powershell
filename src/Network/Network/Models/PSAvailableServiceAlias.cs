using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PsAvailableServiceAlias
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 1)]
        public string Name { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string Type { get; set; }

        public string ResourceName { get; set; }
    }
}
