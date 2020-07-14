using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebook
    {
        public PSNotebook(Notebook notebook)
        {
            this.Description = notebook?.Description;
            this.BigDataPool = new PSBigDataPoolReference(notebook?.BigDataPool);
            this.SessionProperties = new PSNotebookSessionProperties(notebook?.SessionProperties);
            this.Metadata = new PSNotebookMetadata(notebook?.Metadata);
            this.Nbformat = notebook?.Nbformat;
            this.NbformatMinor = notebook?.NbformatMinor;
            this.Cells = notebook?.Cells?.Select(element => new PSNotebookCell(element)).ToList();
            this.Keys = notebook?.Keys;
            this.Values = notebook?.Values;
        }

        public string Description { get; set; }

        public PSBigDataPoolReference BigDataPool { get; set; }

        public PSNotebookSessionProperties SessionProperties { get; set; }

        public PSNotebookMetadata Metadata { get; set; }

        public int? Nbformat { get; set; }

        public int? NbformatMinor { get; set; }

        public IList<PSNotebookCell> Cells { get; set; }

        public ICollection<string> Keys { get; set; }

        public ICollection<object> Values { get; set; }
    }
}
