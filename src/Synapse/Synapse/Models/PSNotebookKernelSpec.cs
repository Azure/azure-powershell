using Azure.Analytics.Synapse.Artifacts.Models;
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
            this.Keys = notebookKernelSpec?.Keys;
            this.Values = notebookKernelSpec?.Values;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public NotebookKernelSpec ToSdkObject()
        {
            return new NotebookKernelSpec(this.Name, this.DisplayName);
        }
    }
}
