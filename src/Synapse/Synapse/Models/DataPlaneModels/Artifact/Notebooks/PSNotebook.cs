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
