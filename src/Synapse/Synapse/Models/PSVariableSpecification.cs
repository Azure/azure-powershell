using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSVariableSpecification
    {
        public PSVariableSpecification(VariableSpecification variableSpecification)
        {
            if (variableSpecification != null)
            {
                this.Type = variableSpecification.Type;
                this.DefaultValue = variableSpecification.DefaultValue;
            }
        }

        public VariableType Type { get; set; }

        public object DefaultValue { get; set; }

        public VariableSpecification ToSdkObject()
        {
            return new VariableSpecification(this.Type)
            {
                DefaultValue = this.DefaultValue
            };
        }
    }
}
