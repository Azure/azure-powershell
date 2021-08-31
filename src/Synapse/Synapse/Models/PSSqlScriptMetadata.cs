using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScriptMetadata
    {
        public PSSqlScriptMetadata(SqlScriptMetadata sqlScriptMetadata)
        {
            this.Language = sqlScriptMetadata?.Language;          
            var propertiesEnum = sqlScriptMetadata?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public string Language { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
