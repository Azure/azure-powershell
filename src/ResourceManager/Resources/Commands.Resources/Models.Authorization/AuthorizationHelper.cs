using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
