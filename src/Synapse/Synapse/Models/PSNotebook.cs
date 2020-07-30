using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
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
            this.Keys = notebook?.Keys;
            this.Values = notebook?.Values;
        }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonIgnore]
        public PSBigDataPoolReference BigDataPool { get; set; }

        [JsonIgnore]
        public PSNotebookSessionProperties SessionProperties { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public PSNotebookMetadata Metadata { get; set; }

        [DefaultValue(4)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, PropertyName = "nbformat")]
        public int? NotebookFormat { get; set; }

        [DefaultValue(2)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, PropertyName = "nbformat_minor")]
        public int? NotebookFormatMinor { get; set; }

        [JsonProperty(PropertyName = "cells")]
        public IList<PSNotebookCell> Cells { get; set; }

        public ICollection<string> Keys { get; set; }

        public ICollection<object> Values { get; set; }

        public Notebook ToSdkObject()
        {
            return new Notebook(this.Metadata?.ToSdkObject(), this.NotebookFormat.GetValueOrDefault(), this.NotebookFormatMinor.GetValueOrDefault(),
                this.Cells?.Select(element => element?.ToSdkObject()))
            {
                Description = this.Description,
                BigDataPool = this.BigDataPool?.ToSdkObject(),
                SessionProperties = this.SessionProperties?.ToSdkObject()
            };
        }
    }
}
