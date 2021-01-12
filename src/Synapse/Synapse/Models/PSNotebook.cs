using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this.NotebookFormat = notebook?.Nbformat;
            this.NotebookFormatMinor = notebook?.NbformatMinor;
            this.Cells = notebook?.Cells?.Select(element => new PSNotebookCell(element)).ToList();
            var propertiesEnum = notebook?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public string Description { get; set; }

        public PSBigDataPoolReference BigDataPool { get; set; }

        public PSNotebookSessionProperties SessionProperties { get; set; }

        public PSNotebookMetadata Metadata { get; set; }

        [DefaultValue(4)]
        public int? NotebookFormat { get; set; }

        [DefaultValue(2)]
        public int? NotebookFormatMinor { get; set; }

        public IList<PSNotebookCell> Cells { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
