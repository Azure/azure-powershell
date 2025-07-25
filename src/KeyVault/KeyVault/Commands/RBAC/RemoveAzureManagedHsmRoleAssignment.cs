// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVaultRoleAssignment,
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.DefinitionNameSignInName)]
    [OutputType(typeof(PSKeyVaultRoleAssignment))]
    public class RemoveAzureManagedHsmRoleAssignment : RbacCmdletBase
    {
        private const string RemoveByNameParameterSet = "RemoveByNameParameterSet";

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.", ParameterSetName = ParameterSet.DefinitionNameApplicationId)]
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.", ParameterSetName = ParameterSet.DefinitionNameObjectId)]
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.", ParameterSetName = ParameterSet.DefinitionNameSignInName)]
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.", ParameterSetName = ParameterSet.DefinitionIdApplicationId)]
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.", ParameterSetName = ParameterSet.DefinitionIdObjectId)]
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.", ParameterSetName = ParameterSet.DefinitionIdSignInName)]
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.", ParameterSetName = RemoveByNameParameterSet)]
        [ResourceNameCompleter(ResourceType.ManagedHsm, "IntentionalFakeParameterName")]
        public string HsmName { get; set; } // hsm name is in all but input object parameter set

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
            HelpMessage = "Role Id the principal is assigned to.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdObjectId,
            HelpMessage = "Role Id the principal is assigned to.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdSignInName,
            HelpMessage = "Role Id the principal is assigned to.")]
        [ValidateNotNullOrEmpty]
        [Alias("RoleId")]
        public string RoleDefinitionId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionNameObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdObjectId,
            HelpMessage = "The user or group object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "PrincipalId")]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionNameSignInName,
            HelpMessage = "The user SignInName.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdSignInName,
            HelpMessage = "The user SignInName.")]
        [ValidateNotNullOrEmpty]
        [Alias("Email", "UserPrincipalName")]
        public string SignInName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionNameApplicationId,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DefinitionIdApplicationId,
            HelpMessage = "The app SPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN", "ServicePrincipalName")]
        public string ApplicationId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Role assignment object.", ParameterSetName = ParameterSet.InputObject, ValueFromPipeline = true)]
        public PSKeyVaultRoleAssignment InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RemoveByNameParameterSet,
            HelpMessage = "Name of the role assignment.")]
        [ValidateNotNullOrEmpty]
        public string RoleAssignmentName { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSet.InputObject:
                    RoleAssignmentName = InputObject.Name;
                    HsmName = InputObject.HsmName;
                    break;
                case RemoveByNameParameterSet:
                    break;
                default:
                    RoleAssignmentName = GetRoleAssignmentNameFromFilterParameters();
                    break;
            }

            if (string.IsNullOrEmpty(RoleAssignmentName))
            {
                throw new ArgumentException(Resources.RoleAssignmentNotFound);
            }

            ConfirmAction(
                string.Format(Resources.RemoveRole, RoleDefinitionName ?? RoleDefinitionId, SignInName ?? ApplicationId ?? ObjectId, Scope),
                HsmName, () =>
            {
                Track2DataClient.RemoveHsmRoleAssignment(HsmName, Scope, RoleAssignmentName);
                if (PassThru)
                {
                    WriteObject(true);
                }
            });
        }

        private string GetRoleAssignmentNameFromFilterParameters()
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
                var user = GraphClient.Users.GetUser(SignInName);
                if (user == null)
                {
                    throw new ArgumentException(string.Format(Resources.UserNotFoundBy, SignInName));
                }
                ObjectId = user.Id;
            }
            // convert service principal app id to object id
            if (ParameterSetName == ParameterSet.DefinitionIdApplicationId
                || ParameterSetName == ParameterSet.DefinitionNameApplicationId)
            {
                string filter = ODataHelper.FormatFilterString<MicrosoftGraphServicePrincipal>(s => s.AppId == ApplicationId);
                var servicePrincipal = GraphClient.ServicePrincipals.ListServicePrincipal(filter: filter).Value.SingleOrDefault();
                if (servicePrincipal == null)
                {
                    throw new ArgumentException(string.Format(Resources.ApplicationNotFoundBy, ApplicationId));
                }
                ObjectId = servicePrincipal.Id;
            }

            var roleAssignment = Track2DataClient.GetHsmRoleAssignments(HsmName, Scope)
                .FirstOrDefault(assignment => string.Equals(assignment.PrincipalId, ObjectId) && string.Equals(assignment.RoleDefinitionId, RoleDefinitionId));
            if (roleAssignment == null)
            {
                throw new Exception(Resources.RoleAssignmentNotFound);
            }
            else
            {
                return roleAssignment.Name;
            }
        }
    }
}
