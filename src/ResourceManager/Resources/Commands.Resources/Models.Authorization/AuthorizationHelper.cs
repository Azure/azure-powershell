namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class AuthorizationHelper
    {
        public static string ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(string scope, string Id)
        {
            if (string.IsNullOrEmpty(scope) || string.IsNullOrEmpty(Id))
            {
                return null;
            }

            return string.Concat(scope.TrimEnd('/'), "/providers/Microsoft.Authorization/roleDefinitions/", Id);
        }

        public static string ConstructFullyQualifiedRoleDefinitionIdFromSubscriptionAndIdAsGuid(string subscriptionId, string roleId)
        {
            if (string.IsNullOrEmpty(subscriptionId) || string.IsNullOrEmpty(roleId))
            {
                return null;
            }

            return string.Concat(GetSubscriptionScope(subscriptionId).TrimEnd('/'), "/providers/Microsoft.Authorization/roleDefinitions/", roleId);
        }

        public static string GetSubscriptionScope(string subscriptionId)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                return null;
            }

            return string.Concat("/subscriptions/", subscriptionId);
        }
    }
}
