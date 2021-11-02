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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookCell
    {
        public PSNotebookCell(NotebookCell notebookCell)
        {
            this.CellType = notebookCell?.CellType;
            this.Metadata = notebookCell?.Metadata;
            this.Source = notebookCell?.Source;
            this.Attachments = notebookCell?.Attachments;
            this.Outputs = notebookCell?.Outputs?.Select(element => new PSNotebookCellOutputItem(element)).ToList();
            this.AdditionalProperties = notebookCell?.AdditionalProperties;
        }

        [JsonProperty(PropertyName = "cell_type")]
        public string CellType { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(PropertyName = "source")]
        public IList<string> Source { get; set; }

        [JsonProperty(PropertyName = "attachments")]
        public object Attachments { get; set; }

        [JsonProperty(PropertyName = "outputs")]
        public IList<PSNotebookCellOutputItem> Outputs { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
