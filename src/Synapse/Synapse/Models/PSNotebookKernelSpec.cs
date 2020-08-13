using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookKernelSpec
    {
        public PSNotebookKernelSpec(NotebookKernelSpec notebookKernelSpec)
        {
            this.Name = notebookKernelSpec?.Name;
            this.DisplayName = notebookKernelSpec?.DisplayName;
            var propertiesEnum = notebookKernelSpec?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public NotebookKernelSpec ToSdkObject()
        {
            var notebookKernelSpec = new NotebookKernelSpec(this.Name, this.DisplayName);
            this.AdditionalProperties?.ForEach(item => notebookKernelSpec.Add(item.Key, item.Value));
            return notebookKernelSpec;
        }
    }
}
