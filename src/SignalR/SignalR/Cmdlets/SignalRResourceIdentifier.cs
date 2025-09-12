using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    internal class SignalRResourceIdentifier
    {
        public string ResourceGroupName { get; private set; }
        public string SignalRName { get; private set; }
        public string ChildResourceName { get; private set; }

        public SignalRResourceIdentifier(string resourceId)
        {
            var resourceIdentifier = new ResourceIdentifier(resourceId);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;

            var parentResource = resourceIdentifier.ParentResource;
            if (!string.IsNullOrEmpty(parentResource))
            {
                var parentParts = parentResource.Split('/');
                if (parentParts.Length == 2 && parentParts[0].Equals("SignalR", System.StringComparison.OrdinalIgnoreCase))
                {
                    SignalRName = parentParts[1];
                    ChildResourceName = resourceIdentifier.ResourceName;
                }
                else
                {
                    throw new System.ArgumentException($"Not a SignalR resource: {resourceId}.");
                }
            }
            else
            {
                SignalRName = resourceIdentifier.ResourceName;
            }
        }
    }
}