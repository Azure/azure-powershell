using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.ManagedHsmRoleAssignment,
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.DefinitionNameSignInName)]
    [OutputType(typeof(PSKeyVaultRoleAssignment))]
    public class NewAzureManagedHsmRoleAssignment : RbacCmdletBase
    {
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter(ResourceType.ManagedHsm, "IntentionalFakeParameterName")]
        public string HsmName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'. '/' is used when omitted.")]
        public string Scope { get; set; } = "/";

        [Parameter(ParameterSetName = ParameterSet.DefinitionNameApplicationId, Mandatory = true,
            HelpMessage = "Name of the RBAC role to assign the principal with.")]
        [Parameter(ParameterSetName = ParameterSet.DefinitionNameObjectId, Mandatory = true,
            HelpMessage = "Name of the RBAC role to assign the principal with.")]
        [Parameter(ParameterSetName = ParameterSet.DefinitionNameSignInName, Mandatory = true,
            HelpMessage = "Name of the RBAC role to assign the principal with.")]
        [Alias("RoleName")]
        public string RoleDefinitionName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdApplicationId,
            HelpMessage = "Role ID the principal is assigned to.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdObjectId,
            HelpMessage = "Role ID the principal is assigned to.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdSignInName,
            HelpMessage = "Role ID the principal is assigned to.")]
        [ValidateNotNullOrEmpty]
        [Alias("RoleId")]
        public string RoleDefinitionId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionNameObjectId,
            HelpMessage = "The user or group object ID.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdObjectId,
            HelpMessage = "The user or group object ID.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "PrincipalId")]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionNameSignInName,
            HelpMessage = "The user sign-in name.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdSignInName,
            HelpMessage = "The user sign-in name.")]
        [ValidateNotNullOrEmpty]
        [Alias("Email", "UserPrincipalName")]
        public string SignInName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionNameApplicationId,
            HelpMessage = "The application ID.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdApplicationId,
            HelpMessage = "The application ID.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN", "ServicePrincipalName")]
        public string ApplicationId { get; set; }

        public override void ExecuteCmdlet()
        {
            // convert definition name to id
            if (ParameterSetName == ParameterSet.DefinitionNameApplicationId ||
                ParameterSetName == ParameterSet.DefinitionNameObjectId ||
                ParameterSetName == ParameterSet.DefinitionNameSignInName)
            {
                var definition = Track2DataClient.GetHsmRoleDefinitions(HsmName, Scope)
                    .FirstOrDefault(x => string.Equals(x.RoleName, RoleDefinitionName, StringComparison.OrdinalIgnoreCase));
                if (definition == null)
                {
                    throw new ArgumentException(string.Format(Resources.RoleDefinitionNotFound, RoleDefinitionName));
                }
                RoleDefinitionId = definition.Id;
            }

            // convert user sign in name to object id
            if (ParameterSetName == ParameterSet.DefinitionIdSignInName
                || ParameterSetName == ParameterSet.DefinitionNameSignInName)
            {
                var filter = new ADObjectFilterOptions() { UPN = SignInName };
                var user = ActiveDirectoryClient.FilterUsers(filter).FirstOrDefault();
                if (user == null)
                {
                    throw new ArgumentException(string.Format(Resources.UserNotFoundBy, SignInName));
                }
                ObjectId = user.Id.ToString();
            }
            // convert service principal app id to object id
            if (ParameterSetName == ParameterSet.DefinitionIdApplicationId
                || ParameterSetName == ParameterSet.DefinitionNameApplicationId)
            {
                var odataQuery = new Rest.Azure.OData.ODataQuery<Application>(s => string.Equals(s.AppId, ApplicationId, StringComparison.OrdinalIgnoreCase));
                var app = ActiveDirectoryClient.GetApplicationWithFilters(odataQuery).FirstOrDefault();
                if (app == null)
                {
                    throw new ArgumentException(string.Format(Resources.ApplicationNotFoundBy, ApplicationId));
                }
                ObjectId = app.ObjectId.ToString();
            }

            base.ConfirmAction(
                string.Format(Resources.AssignRole, RoleDefinitionName ?? RoleDefinitionId, SignInName ?? ApplicationId ?? ObjectId, Scope),
                HsmName, () =>
            {
                PSKeyVaultRoleAssignment roleAssignment = Track2DataClient.CreateHsmRoleAssignment(HsmName, Scope, RoleDefinitionId, ObjectId);
                GetAssignmentDetails(roleAssignment, HsmName, Scope);
                WriteObject(roleAssignment);
            });
        }
    }
}
