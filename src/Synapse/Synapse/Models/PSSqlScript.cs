using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScript
    {
        public PSSqlScript(SqlScript sqlscript)
        {
            this.Description = sqlscript?.Description;
            this.Type = sqlscript?.Type;
            this.Content = new PSSqlScriptContent(sqlscript?.Content);
            var propertiesEnum = sqlscript?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public string Description { get; set; }

        public SqlScriptType? Type { get; set; }

        public PSSqlScriptContent Content { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
