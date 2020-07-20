using Azure.Analytics.Synapse.Artifacts.Models;
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
            this.OutputType = notebookCellOutputItem?.OutputType;
            this.Text = notebookCellOutputItem?.Text;
            this.Data = notebookCellOutputItem?.Data;
            this.Metadata = notebookCellOutputItem?.Metadata;
        }

        public string Name { get; set; }

        public int? ExecutionCount { get; set; }

        public CellOutputType? OutputType { get; set; }

        public object Text { get; set; }

        public object Data { get; set; }

        public object Metadata { get; set; }

        public NotebookCellOutputItem ToSdkObject()
        {
            return new NotebookCellOutputItem(this.OutputType.GetValueOrDefault())
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
