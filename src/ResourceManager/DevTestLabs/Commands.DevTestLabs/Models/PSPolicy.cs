using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs.Models
{
    public class PSPolicy
    {
        //
        // Summary:
        //     The description of the policy.
        [JsonProperty(PropertyName = "properties.description")]
        public string Description { get; set; }

        //
        // Summary:
        //     The evaluator type of the policy. Possible values include: 'AllowedValuesPolicy',
        //     'MaxValuePolicy'
        [JsonProperty(PropertyName = "properties.evaluatorType")]
        public string EvaluatorType { get; set; }

        //
        // Summary:
        //     The fact data of the policy.
        [JsonProperty(PropertyName = "properties.factData")]
        public string FactData { get; set; }

        //
        // Summary:
        //     The fact name of the policy. Possible values include: 'UserOwnedLabVmCount',
        //     'LabVmCount', 'LabVmSize', 'GalleryImage', 'UserOwnedLabVmCountInSubnet'
        [JsonProperty(PropertyName = "properties.factName")]
        public string FactName { get; set; }

        //
        // Summary:
        //     The identifier of the resource.
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        //
        // Summary:
        //     The location of the resource.
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        //
        // Summary:
        //     The name of the resource.
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        //
        // Summary:
        //     The provisioning status of the resource.
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        //
        // Summary:
        //     The status of the policy. Possible values include: 'Enabled', 'Disabled'
        [JsonProperty(PropertyName = "properties.status")]
        public string Status { get; set; }

        //
        // Summary:
        //     The tags of the resource.
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        //
        // Summary:
        //     The threshold of the policy.
        [JsonProperty(PropertyName = "properties.threshold")]
        public string Threshold { get; set; }

        //
        // Summary:
        //     The type of the resource.
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
