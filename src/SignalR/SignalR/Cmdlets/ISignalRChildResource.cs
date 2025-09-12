using Azure.Core;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    internal interface ISignalRChildResource
    {
        string ResourceGroupName { get; set; }
        string SignalRName { get; set; }
        string Name { get; set; }
    }
    internal static class SignalRChildResourceExtensions
    {
        public static void LoadFromSignalRResourceId(this ISignalRChildResource handler, string resourceId)
        {
            var resourceIdentifier = new ResourceIdentifier(resourceId);
            if (resourceIdentifier.ResourceType != Constants.SignalRResourceType)
            {
                throw new System.ArgumentException($"Expected resource type is \"{Constants.SignalRResourceType}\" while the actual resource is \"{resourceId}\".");
            }
            handler.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            handler.SignalRName = resourceIdentifier.Name;
        }

        public static void LoadFromChildResourceId(this ISignalRChildResource handler, string resourceId, string expectedChildResourceType)
        {
            var resourceIdentifier = new ResourceIdentifier(resourceId);
            if (resourceIdentifier.ResourceType != expectedChildResourceType)
            {
                throw new System.ArgumentException($"Expected resource type is \"{expectedChildResourceType}\" while the actual resource is \"{resourceId}\".");
            }
            handler.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            handler.SignalRName = resourceIdentifier.Parent.Name;
            handler.Name = resourceIdentifier.Name;
        }
    }
}
