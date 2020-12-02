using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    public class RbacCmdletBase: KeyVaultCmdletBase
    {
        private ActiveDirectoryClient _activeDirectoryClient;

        protected ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient != null) return _activeDirectoryClient;
                try
                {
                    _activeDirectoryClient = new ActiveDirectoryClient(DefaultProfile.DefaultContext);
                }
                catch
                {
                    _activeDirectoryClient = null;
                }
                return _activeDirectoryClient;
            }

            set { _activeDirectoryClient = value; }
        }

        internal static class ParameterSet
        {
            public const string DefinitionIdObjectId = "DefinitionIdObjectId";
            public const string DefinitionIdSignInName = "DefinitionIdSignInName";
            public const string DefinitionIdApplicationId = "DefinitionIdApplicationId";
            public const string DefinitionNameObjectId = "DefinitionNameObjectId";
            public const string DefinitionNameSignInName = "DefinitionNameSignInName";
            public const string DefinitionNameApplicationId = "DefinitionNameApplicationId";
            public const string InputObject = "InputObject";
            public const string RoleAssignmentName = "AssignmentName";
        }

        /// <summary>
        /// Get details of the role assignment -- principal name, role definition name, etc.,
        /// and assign them back in the role assignment object.
        /// </summary>
        /// <param name="assignment"></param>
        protected void GetAssignmentDetails(PSKeyVaultRoleAssignment assignment, string hsmName, string scope)
        {
            // get all role definition
            var definitions = Track2DataClient.GetHsmRoleDefinitions(hsmName, scope);

            // get info about assignee
            var assignee = ModelExtensions.GetDetailsFromADObjectId(assignment.PrincipalId, ActiveDirectoryClient);
            (assignment.DisplayName, assignment.ObjectType) = assignee;

            // traverse role definitions to find the correct one
            assignment.RoleDefinitionName = definitions
                .FirstOrDefault(definition => string.Equals(definition.Id, assignment.RoleDefinitionId, StringComparison.OrdinalIgnoreCase))
                ?.RoleName;
        }
    }
}
