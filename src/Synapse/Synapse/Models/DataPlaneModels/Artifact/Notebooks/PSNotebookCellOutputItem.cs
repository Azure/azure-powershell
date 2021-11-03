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
    public class PSNotebookCellOutputItem
    {
        public PSNotebookCellOutputItem(NotebookCellOutputItem notebookCellOutputItem)
        {
            this.Name = notebookCellOutputItem?.Name;
            this.ExecutionCount = notebookCellOutputItem?.ExecutionCount;
            this.OutputType = notebookCellOutputItem?.OutputType.ToString();
            this.Text = notebookCellOutputItem?.Text;
            this.Data = notebookCellOutputItem?.Data;
            this.Metadata = notebookCellOutputItem?.Metadata;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "execution_count")]
        public int? ExecutionCount { get; set; }

        [JsonProperty(PropertyName = "output_type")]
        public string OutputType { get; set; }

        [JsonProperty(PropertyName = "text")]
        public object Text { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }
    }
}
