using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
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
            //this.Keys = notebookLanguageInfo?.Keys;
            //this.Values = notebookLanguageInfo?.Values;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public string CodemirrorMode { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public NotebookLanguageInfo ToSdkObject()
        {
            if(this.Name == null)
            {
                this.Name = LanguageType.Python;
            }
            return new NotebookLanguageInfo(this.Name)
            {
                CodemirrorMode = this.CodemirrorMode
            };
        }
    }
}
