using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "kernelspec")]
        public PSNotebookKernelSpec Kernelspec { get; set; }

        [JsonProperty(PropertyName = "language_info")]
        public PSNotebookLanguageInfo LanguageInfo { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public NotebookMetadata ToSdkObject()
        {
            var metadata = new NotebookMetadata()
            {
                Kernelspec = this.Kernelspec?.ToSdkObject(),
                LanguageInfo = this.LanguageInfo?.ToSdkObject()
            };
            this.AdditionalProperties?.ForEach(item => metadata.Add(item.Key, item.Value));
            return metadata;
        }
    }
}
