using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookLanguageInfo
    {
        public PSNotebookLanguageInfo(NotebookLanguageInfo notebookLanguageInfo)
        {
            this.Name = notebookLanguageInfo?.Name;
            this.CodemirrorMode = notebookLanguageInfo?.CodemirrorMode;
            var propertiesEnum = notebookLanguageInfo?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public string Name { get; set; }

        public string CodemirrorMode { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
