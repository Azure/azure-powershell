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
            this.Type = variableSpecification.Type;
            this.DefaultValue = variableSpecification.DefaultValue;
        }

        public VariableType Type { get; set; }

        public object DefaultValue { get; set; }

        public static VariableSpecification ToSdkObject(PSVariableSpecification pSVariableSpecification)
        {
            return new VariableSpecification(pSVariableSpecification.Type)
            {
                DefaultValue = pSVariableSpecification.DefaultValue
            };
        }
    }
}
