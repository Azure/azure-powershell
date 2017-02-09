using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSSettingsSectionDescription : SettingsSectionDescription
    {
        [JsonProperty(PropertyName = "parameters")]
        public new IList<PSSettingsParameterDescription> Parameters { get; set; }
    }
}
