// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSVerifierWorkspaceBaseResource : PSResourceId
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 2)]
        public string Name { get; set; }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "NetworkManagerName", Target = ViewControl.Table, Position = 1)]
        public string NetworkManagerName { get; set; }

        public string Type { get; set; }

        public PSSystemData SystemData { get;  set; }

        [JsonIgnore]
        public string SystemDataText
        {
            get { return JsonConvert.SerializeObject(SystemData, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
