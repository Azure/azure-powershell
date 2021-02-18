namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Class that wraps a policy definition PSObject
    /// </summary>
    public class PsPolicySetDefinition
    {
        public PsPolicySetDefinition(JToken input)
        {
            var resource = input.ToResource();
            Name = resource.Name;
            PolicySetDefinitionId = resource.Id;
            Properties = new PsPolicySetDefinitionProperties(resource.Properties);
            ResourceId = resource.Id;
            ResourceName = resource.Name;
            ResourceType = resource.Type;
            SubscriptionId = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetSubscriptionId(resource.Id);
        }

        public string Name { get; set; }
        public string ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceType { get; set; }
        public string SubscriptionId { get; set; }
        public string PolicySetDefinitionId { get; set; }
        public PsPolicySetDefinitionProperties Properties { get; set; }
    }
}
