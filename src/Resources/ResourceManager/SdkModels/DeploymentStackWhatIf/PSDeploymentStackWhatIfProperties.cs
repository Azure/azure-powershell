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
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PSDeploymentStackWhatIfProperties
    {
        [JsonProperty("deploymentStackResourceId")]
        public string DeploymentStackResourceId { get; set; }

        [JsonProperty("retentionInterval")]
        public string RetentionInterval { get; set; }

        [JsonProperty("provisioningState")]
        public string ProvisioningState { get; set; }

        [JsonProperty("deploymentStackLastModified")]
        public DateTime? DeploymentStackLastModified { get; set; }

        [JsonProperty("deploymentExtensions")]
        public IList<PSDeploymentStackWhatIfExtension> DeploymentExtensions { get; set; }

        [JsonProperty("changes")]
        public PSDeploymentStackWhatIfChanges Changes { get; set; }

        [JsonProperty("diagnostics")]
        public IList<PSDeploymentStackWhatIfDiagnostic> Diagnostics { get; set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }

        [JsonProperty("deploymentScope")]
        public string DeploymentScope { get; set; }

        [JsonProperty("bypassStackOutOfSyncError")]
        public bool? BypassStackOutOfSyncError { get; set; }
    }
}
