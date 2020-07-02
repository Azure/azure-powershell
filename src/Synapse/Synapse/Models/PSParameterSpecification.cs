using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSParameterSpecification
    {
        public PSParameterSpecification(ParameterSpecification parameterSpecification)
        {
            this.Type = parameterSpecification.Type;
            this.DefaultValue = parameterSpecification.DefaultValue;
        }

        public ParameterType Type { get; set; }

        public object DefaultValue { get; set; }

        public static ParameterSpecification ToSdkObject(PSParameterSpecification pSParameterSpecification)
        {
            return  new ParameterSpecification(pSParameterSpecification.Type)
            {
                DefaultValue = pSParameterSpecification.DefaultValue
            };
        }
    }
}
