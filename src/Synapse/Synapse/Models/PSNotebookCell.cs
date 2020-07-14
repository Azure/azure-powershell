using Azure.Analytics.Synapse.Artifacts.Models;
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

        public string CellType { get; set; }

        public object Metadata { get; set; }

        public IList<string> Source { get; set; }

        public object Attachments { get; set; }

        public IList<PSNotebookCellOutputItem> Outputs { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }
    }
}
