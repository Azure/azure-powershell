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

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        public PSBigDataPoolReference BigDataPool { get; set; }

        public PSNotebookSessionProperties SessionProperties { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public PSNotebookMetadata Metadata { get; set; }

        public int? NotebookFormat { get; set; }

        public int? NotebookFormatMinor { get; set; }

        [JsonProperty(PropertyName = "cells")]
        public IList<PSNotebookCell> Cells { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }

        public Notebook ToSdkObject()
        {
            var notebook = new Notebook(this.Metadata?.ToSdkObject(), this.NotebookFormat.GetValueOrDefault(), this.NotebookFormatMinor.GetValueOrDefault(),
                this.Cells?.Select(element => element?.ToSdkObject()))
            {
                Description = this.Description,
                BigDataPool = this.BigDataPool?.ToSdkObject(),
                SessionProperties = this.SessionProperties?.ToSdkObject()
            };
            this.AdditionalProperties?.ForEach(item => notebook.Add(item.Key, item.Value));
            return notebook;
        }
    }
}
