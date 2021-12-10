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

using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookSessionProperties
    {
        public PSNotebookSessionProperties(NotebookSessionProperties notebookSessionProperties)
        {
            this.DriverMemory = notebookSessionProperties?.DriverMemory;
            this.DriverCores = notebookSessionProperties?.DriverCores;
            this.ExecutorMemory = notebookSessionProperties?.ExecutorMemory;
            this.ExecutorCores = notebookSessionProperties?.ExecutorCores;
            this.NumExecutors = notebookSessionProperties?.NumExecutors;
        }

        [JsonProperty(PropertyName = "driverMemory")]
        public string DriverMemory { get; set; }

        [JsonProperty(PropertyName = "driverCores")]
        public int? DriverCores { get; set; }

        [JsonProperty(PropertyName = "executorMemory")]
        public string ExecutorMemory { get; set; }

        [JsonProperty(PropertyName = "executorCores")]
        public int? ExecutorCores { get; set; }

        [JsonProperty(PropertyName = "numExecutors")]
        public int? NumExecutors { get; set; }
    }
}
