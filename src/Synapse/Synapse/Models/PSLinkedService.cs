using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        [JsonProperty(PropertyName = "connectVia")]
        public PSIntegrationRuntimeReference ConnectVia { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public IDictionary<string, PSParameterSpecification> Parameters { get; set; }

        [JsonProperty(PropertyName = "annotations")]
        public IList<object> Annotations { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public virtual void Validate() { }

        public virtual LinkedService ToSdkObject()
        {
            LinkedService linkedService = new LinkedService();
            SetProperties(linkedService);
            return linkedService;
        }

        protected void SetProperties(LinkedService linkedService)
        {
            linkedService.ConnectVia = this.ConnectVia?.ToSdkObject();
            linkedService.Description = this.Description;
            this.Annotations?.ForEach(item => linkedService.Annotations.Add(item));
            this.Parameters?.ForEach(item => linkedService.Parameters.Add(item.Key, item.Value?.ToSdkObject()));
            if (this.AdditionalProperties != null)
            {
                foreach(var item in this.AdditionalProperties)
                {
                    if (item.Key != "typeProperties")
                    {
                        linkedService.Add(item.Key, item.Value);
                    }
                }
            }
        }
    }
}
