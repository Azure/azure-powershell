using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
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
            this.Keys = linkedService?.Keys;
            this.Values = linkedService?.Values;
        }

        public PSLinkedService() { }

        public PSIntegrationRuntimeReference ConnectVia { get; set; }

        public string Description { get; set; }

        public IDictionary<string, PSParameterSpecification> Parameters { get; set; }

        public IList<object> Annotations { get; set; }

        public ICollection<string> Keys { get; set; }

        public ICollection<object> Values { get; set; }

        public virtual void Validate() { }

        public virtual LinkedService ToSdkObject()
        {
            LinkedService linkedService = new LinkedService
            {
                ConnectVia = this.ConnectVia?.ToSdkObject(),
                Description = this.Description,
            };
            foreach (var item in this.Annotations)
            {
                linkedService.Annotations.Add(item);
            }
            IDictionary<string, PSParameterSpecification> pSParameters = this.Parameters;
            if (pSParameters != null)
            {
                foreach (var pSParameter in pSParameters)
                {
                    linkedService.Parameters.Add(pSParameter.Key, pSParameter.Value?.ToSdkObject());
                }
            }
            return linkedService;
        }
    }
}
