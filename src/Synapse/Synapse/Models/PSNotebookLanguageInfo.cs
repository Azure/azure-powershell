using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public string CodemirrorMode { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public NotebookLanguageInfo ToSdkObject()
        {
            if(this.Name == null)
            {
                this.Name = LanguageType.Python;
            }
            var info = new NotebookLanguageInfo(this.Name)
            {
                CodemirrorMode = this.CodemirrorMode
            };
            if (this.AdditionalProperties != null)
            {
                foreach (var item in this.AdditionalProperties)
                {
                    if (item.Key != "codemirror_mode")
                    {
                        info.Add(item.Key, item.Value);
                    }
                }
            }
            return info;
        }
    }
}
