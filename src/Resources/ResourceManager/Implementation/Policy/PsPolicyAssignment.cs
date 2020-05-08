namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Class that wraps a policy definition PSObject
    /// </summary>
    public class PsPolicyAssignment
    {
        public PsPolicyAssignment(JToken input)
        {
            var resource = input.ToResource();
            Identity = resource.Identity?.ToJToken().ToPsObject();
            Location = resource.Location;
            Name = resource.Name;
            PolicyAssignmentId = resource.Id;
            Properties = new PsPolicyAssignmentProperties(resource.Properties);
            ResourceId = resource.Id;
            ResourceName = resource.Name;
            ResourceGroupName = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceGroupName(resource.Id);
            ResourceType = resource.Type;
            Sku = resource.Sku?.ToJToken().ToPsObject();
            SubscriptionId = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetSubscriptionId(resource.Id);
        }

        public PSObject Identity { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceGroupName { get; set; }
        public string ResourceType { get; set; }
        public string SubscriptionId { get; set; }
        public PSObject Sku { get; set; }
        public string PolicyAssignmentId { get; set; }
        public PsPolicyAssignmentProperties Properties { get; set; }
    }
}
