namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using System.Text.RegularExpressions;

    public static class WhatIfResourceIdParser
    {
        private static readonly Regex SubscriptionRegex =
            new Regex(@"^\/?subscriptions\/(?<subscriptionId>[a-f0-9-]+)", RegexOptions.IgnoreCase);

        private static readonly Regex ResourceGroupRegex =
            new Regex(@"^\/resourceGroups\/(?<resourceGroupName>[-\w\._\(\)]+)");

        private static readonly Regex ShortResourceIdRegex =
            new Regex(@"^\/providers/(?<shortResourceId>.+$)");

        
        public static (string scope, string shortResourceId) ParseResourceId(string fullyQualifiedResourceId)
        {
            string remaining = fullyQualifiedResourceId;

            // Parse subscriptionId.
            Match subscriptionMatch = SubscriptionRegex.Match(remaining);
            string subscriptionId = subscriptionMatch.Groups["subscriptionId"].Value;
            remaining = remaining.Substring(subscriptionMatch.Length);

            // Parse resourceGroupName.
            Match resourceGroupMatch = ResourceGroupRegex.Match(remaining);
            string resourceGroupName = resourceGroupMatch.Groups["resourceGroupName"].Value;
            remaining = remaining.Substring(resourceGroupMatch.Length);

            // Parse shortResourceId.
            Match shortResourceIdMatch = ShortResourceIdRegex.Match(remaining);
            string shortResourceId = shortResourceIdMatch.Groups["shortResourceId"].Value;

            // The resourceId represents a resource group as a resource with
            // the format /subscription/{subscriptionId}/resourceGroups/{resourceGroupName},
            // which is a subscription-level resource ID. The resourceGroupName should belong to
            // the relativePath but not the scope.
            if (subscriptionMatch.Success && resourceGroupMatch.Success && !shortResourceIdMatch.Success)
            {
                shortResourceId = $"Microsoft.Resources/resourceGroups/{resourceGroupName}";
                resourceGroupName = string.Empty;
            }

            // Construct scope.
            string scope = $"/subscriptions/{subscriptionId.ToLowerInvariant()}";

            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                scope += $"/resourceGroups/{resourceGroupName}";
            }

            return (scope, shortResourceId);
        }
    }
}
