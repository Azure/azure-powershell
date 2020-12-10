using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.ManagedHsmRoleAssignment, DefaultParameterSetName = ListParameterSet)]
    [OutputType(typeof(PSKeyVaultRoleAssignment))]
    public class GetAzureManagedHsmRoleAssignment : RbacCmdletBase
    {
        private const string ListParameterSet = "List";
        private const string GetByNameParameterSet = "GetByName";

        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter(ResourceType.ManagedHsm, "IntentionalFakeParameterName")]
        public string HsmName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'. By default it lists all scopes.")]
        public string Scope { get; set; } = string.Empty;

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet,
            HelpMessage = "Name of the RBAC role to assign the principal with.")]
        [Alias("RoleName")]
        public string RoleDefinitionName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet,
            HelpMessage = "Role Id the principal is assigned to.")]
        [Alias("RoleId")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet,
            HelpMessage = "The user or group object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "PrincipalId")]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet,
            HelpMessage = "The user SignInName.")]
        [ValidateNotNullOrEmpty]
        [Alias("Email", "UserPrincipalName")]
        public string SignInName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet,
            HelpMessage = "The app SPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN", "ServicePrincipalName")]
        public string ApplicationId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet,
            HelpMessage = "Name of the role assignment.")]
        [ValidateNotNullOrEmpty]
        public string RoleAssignmentName { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ListParameterSet:
                    DoList();
                    break;
                case GetByNameParameterSet:
                    DoGetByName();
                    break;
            }
        }

        private void DoGetByName()
        {
            var assignment = Track2DataClient.GetHsmRoleAssignment(HsmName, Scope, RoleAssignmentName);
            GetAssignmentDetails(assignment, HsmName, Scope);
            WriteObject(assignment);
        }

        private void DoList()
        {
            // get role assignments
            var assignments = Track2DataClient.GetHsmRoleAssignments(HsmName, Scope);
            assignments.ForEach(assignment => GetAssignmentDetails(assignment, HsmName, Scope));
            assignments = FilterAssignments(assignments);
            WriteObject(assignments, enumerateCollection: true);
        }

        private PSKeyVaultRoleAssignment[] FilterAssignments(PSKeyVaultRoleAssignment[] assignments)
        {
            if (!string.IsNullOrEmpty(RoleDefinitionName))
            {
                var definition = Track2DataClient.GetHsmRoleDefinitions(HsmName, Scope)
                    .FirstOrDefault(x => string.Equals(x.RoleName, RoleDefinitionName, StringComparison.OrdinalIgnoreCase));
                RoleDefinitionId = definition?.Id;
            }
            if (!string.IsNullOrEmpty(SignInName))
            {
                var filter = new ADObjectFilterOptions() { UPN = SignInName };
                var user = ActiveDirectoryClient.FilterUsers(filter).FirstOrDefault();
                ObjectId = user?.Id.ToString();
            }
            if (!string.IsNullOrEmpty(ApplicationId))
            {
                var odataQuery = new Rest.Azure.OData.ODataQuery<Application>(s => string.Equals(s.AppId, ApplicationId, StringComparison.OrdinalIgnoreCase));
                var app = ActiveDirectoryClient.GetApplicationWithFilters(odataQuery).FirstOrDefault();
                ObjectId = app?.ObjectId.ToString();
            }
            if (!string.IsNullOrEmpty(RoleDefinitionId))
            {
                assignments = assignments.Where(assignment => string.Equals(assignment.RoleDefinitionId, RoleDefinitionId, StringComparison.OrdinalIgnoreCase)).ToArray();
            }
            if (!string.IsNullOrEmpty(ObjectId))
            {
                assignments = assignments.Where(assignment => string.Equals(assignment.PrincipalId, ObjectId, StringComparison.OrdinalIgnoreCase)).ToArray();
            }
            return assignments;
        }
    }
}
