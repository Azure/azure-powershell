using Azure.Analytics.Synapse.Artifacts.Models;
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
            this.Keys = notebookMetadata?.Keys;
            this.Values = notebookMetadata?.Values;
        }

        public PSNotebookKernelSpec Kernelspec { get; set; }

        public PSNotebookLanguageInfo LanguageInfo { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public NotebookMetadata ToSdkObject()
        {
            return new NotebookMetadata()
            {
                Kernelspec = this.Kernelspec?.ToSdkObject(),
                LanguageInfo = this.LanguageInfo?.ToSdkObject()
            };
        }
    }
}
