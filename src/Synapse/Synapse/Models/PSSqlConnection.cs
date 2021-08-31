using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlConnection
    {
        public PSSqlConnection(SqlConnection sqlConnection)
        {
            this.Name = sqlConnection?.Name;
            this.Type = sqlConnection?.Type;
            var propertiesEnum = sqlConnection?.GetEnumerator();
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

        public SqlConnectionType? Type { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
