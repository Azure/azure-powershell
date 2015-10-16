using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class AuthorizationHelper
    {
        public const string roleDefinitionIdPrefixFormat = "/subscriptions/{0}/providers/Microsoft.Authorization/roleDefinitions/";

        public static string GetRoleDefinitionFullyQualifiedId(string subscriptionId, string roleDefinitionGuid)
        {
            return string.Concat(string.Format(AuthorizationHelper.roleDefinitionIdPrefixFormat, subscriptionId), roleDefinitionGuid);
        }
    }
}
