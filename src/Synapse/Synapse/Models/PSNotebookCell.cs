using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            this.Keys = notebookCell?.Keys;
            this.Values = notebookCell?.Values;
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

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public NotebookCell ToSdkObject()
        {
            if(this.Metadata == null)
            {
                this.Metadata = new System.Collections.Generic.Dictionary<string, object>();
            }
            return new NotebookCell(this.CellType, this.Metadata, this.Source)
            {
                Attachments = this.Attachments,
            };
        }
    }
}
