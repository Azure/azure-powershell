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
            if (linkedService != null)
            {
                this.ConnectVia = new PSIntegrationRuntimeReference(linkedService.ConnectVia);
                this.Description = linkedService.Description;
                if (linkedService.Parameters != null)
                {
                    this.Parameters = linkedService.Parameters
                            .Select(element => new KeyValuePair<string, PSParameterSpecification>(element.Key, new PSParameterSpecification(element.Value)))
                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
                this.Annotations = linkedService.Annotations;
                this.Keys = linkedService.Keys;
                this.Values = linkedService.Values;
            }
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
                ConnectVia = this.ConnectVia.ToSdkObject(),
                Description = this.Description,
                Annotations = this.Annotations
            };

            IDictionary<string, PSParameterSpecification> pSParameters = this.Parameters;
            if (pSParameters != null)
            {
                IDictionary<string, ParameterSpecification> parameters = new Dictionary<string, ParameterSpecification>();
                foreach (var pSParameter in pSParameters)
                {
                    parameters.Add(pSParameter.Key, pSParameter.Value.ToSdkObject());
                }
                linkedService.Parameters = parameters;
            }

            return linkedService;
        }
    }
}
