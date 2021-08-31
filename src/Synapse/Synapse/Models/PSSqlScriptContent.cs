using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScriptContent
    {
        public PSSqlScriptContent(SqlScriptContent sqlscriptContent)
        {
            this.Query = sqlscriptContent?.Query;
            this.CurrentConnection = new PSSqlConnection(sqlscriptContent?.CurrentConnection);
            this.Metadata = new PSSqlScriptMetadata(sqlscriptContent?.Metadata);
            var propertiesEnum = sqlscriptContent?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public string Query { get; set; }

        public PSSqlConnection CurrentConnection { get; set; }

        public PSSqlScriptMetadata Metadata { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
