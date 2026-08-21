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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
    using Microsoft.Azure.Management.Resources.Models;
    using Newtonsoft.Json;

    public class PSDeploymentStackWhatIfResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("systemData")]
        public SystemData SystemData { get; set; }

        [JsonProperty("properties")]
        public PSDeploymentStackWhatIfProperties Properties { get; set; }

        public override string ToString()
        {
            return DeploymentStackWhatIfFormatter.Format(this);
        }
    }
}
