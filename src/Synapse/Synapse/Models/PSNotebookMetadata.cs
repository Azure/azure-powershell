using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookMetadata
    {
        public PSNotebookMetadata(NotebookMetadata notebookMetadata)
        {
            this.Kernelspec = new PSNotebookKernelSpec(notebookMetadata?.Kernelspec);
            this.LanguageInfo = new PSNotebookLanguageInfo(notebookMetadata?.LanguageInfo);
            var propertiesEnum = notebookMetadata?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public PSNotebookKernelSpec Kernelspec { get; set; }

        public PSNotebookLanguageInfo LanguageInfo { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
