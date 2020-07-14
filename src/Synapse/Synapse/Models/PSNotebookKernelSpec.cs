using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
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

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }
    }
}
