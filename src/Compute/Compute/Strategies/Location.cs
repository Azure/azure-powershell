using Microsoft.Azure.Commands.Common.Strategies;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    public static class Location
    {
        public static string UpdateLocation(
            this IState current, string location, IResourceConfig config)
            => location ?? current.GetLocation(config) ?? "eastus";
    }
}
