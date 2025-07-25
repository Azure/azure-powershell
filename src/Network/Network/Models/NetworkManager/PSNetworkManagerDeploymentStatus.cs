using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerDeploymentStatus
    {
        public System.DateTime? CommitTime { get; set; }

        public string Region { get; set; }

        public string DeploymentStatus { get; set; }

        public IList<string> ConfigurationIds { get; set; }

        public string DeploymentType { get; set; }

        public string ErrorMessage { get; set; }

        [JsonIgnore]
        public string ConfigurationIdsText
        {
            get { return JsonConvert.SerializeObject(ConfigurationIds, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

    }
}
