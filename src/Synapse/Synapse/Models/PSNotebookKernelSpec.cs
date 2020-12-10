using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
