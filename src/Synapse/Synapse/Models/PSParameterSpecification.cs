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
            if (parameterSpecification != null)
            {
                this.Type = parameterSpecification.Type;
                this.DefaultValue = parameterSpecification.DefaultValue;
            }
        }

        public ParameterType Type { get; set; }

        public object DefaultValue { get; set; }

        public ParameterSpecification ToSdkObject()
        {
            return  new ParameterSpecification(this.Type)
            {
                DefaultValue = this.DefaultValue
            };
        }
    }
}
