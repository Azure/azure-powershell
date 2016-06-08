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

using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities
{
    /// <summary>
    /// Diagnostics settings.
    /// </summary>
    public class DiagnosticsSettings
    {
        [JsonProperty(PropertyName = "AzureDriveEnabled")]
        public bool? AzureDriveTraceEnabled { get; set; }

        [JsonProperty]
        public LogEntryType AzureDriveTraceLevel { get; set; }

        [JsonProperty(PropertyName = "AzureTableEnabled")]
        public bool? AzureTableTraceEnabled { get; set; }

        [JsonProperty]
        public LogEntryType AzureTableTraceLevel { get; set; }

        [JsonProperty(PropertyName = "AzureBlobEnabled")]
        public bool? AzureBlobTraceEnabled { get; set; }

        [JsonProperty]
        public LogEntryType AzureBlobTraceLevel { get; set; }
    }
}
