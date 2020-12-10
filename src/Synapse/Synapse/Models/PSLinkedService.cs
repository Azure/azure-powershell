using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkedService
    {
        public PSLinkedService(LinkedService linkedService)
        {
            this.ConnectVia = new PSIntegrationRuntimeReference(linkedService?.ConnectVia);
            this.Description = linkedService?.Description;
            this.Parameters = linkedService?.Parameters?
                    .Select(element => new KeyValuePair<string, PSParameterSpecification>(element.Key, new PSParameterSpecification(element.Value)))
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            this.Annotations = linkedService?.Annotations;
            var propertiesEnum = linkedService?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public PSLinkedService() { }

        public PSIntegrationRuntimeReference ConnectVia { get; set; }

        public string Description { get; set; }

        public IDictionary<string, PSParameterSpecification> Parameters { get; set; }

        public IList<object> Annotations { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }

        public virtual void Validate() { }
    }
}
