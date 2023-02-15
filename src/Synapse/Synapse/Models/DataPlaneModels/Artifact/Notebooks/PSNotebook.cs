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
using System.ComponentModel;
using System.Linq;

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
            this.Folder = new PSNotebookFolder(notebook?.Folder);
            this.NotebookFormat = notebook?.NotebookFormat;
            this.NotebookFormatMinor = notebook?.NotebookFormatMinor;
            this.Cells = notebook?.Cells?.Select(element => new PSNotebookCell(element)).ToList();
            this.AdditionalProperties = notebook?.AdditionalProperties;
        }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonIgnore]
        public PSBigDataPoolReference BigDataPool { get; set; }

        [JsonProperty(PropertyName = "sessionProperties")]
        public PSNotebookSessionProperties SessionProperties { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public PSNotebookMetadata Metadata { get; set; }

        [JsonIgnore]
        public PSNotebookFolder Folder { get; set; }

        [DefaultValue(4)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, PropertyName = "nbformat")]
        public int? NotebookFormat { get; set; }

        [DefaultValue(2)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, PropertyName = "nbformat_minor")]
        public int? NotebookFormatMinor { get; set; }

        [JsonProperty(PropertyName = "cells")]
        public IList<PSNotebookCell> Cells { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
