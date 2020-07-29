using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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

        public NotebookCellOutputItem ToSdkObject()
        {
            return new NotebookCellOutputItem(new CellOutputType(this.OutputType))
            {
                Name = this.Name,
                ExecutionCount = this.ExecutionCount,
                Text = this.Text,
                Data = this.Data,
                Metadata = this.Metadata
            };
        }
    }
}
