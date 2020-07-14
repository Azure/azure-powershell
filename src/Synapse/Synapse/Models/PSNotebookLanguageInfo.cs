using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookLanguageInfo
    {
        public PSNotebookLanguageInfo(NotebookLanguageInfo notebookLanguageInfo)
        {
            this.Name = notebookLanguageInfo?.Name;
            this.CodemirrorMode = notebookLanguageInfo?.CodemirrorMode;
            this.Keys = notebookLanguageInfo?.Keys;
            this.Values = notebookLanguageInfo?.Values;
        }

        public string Name { get; set; }

        public string CodemirrorMode { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }
    }
}
