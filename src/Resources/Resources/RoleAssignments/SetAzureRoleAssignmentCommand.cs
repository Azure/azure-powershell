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

using Microsoft.Azure.Commands.ActiveDirectory;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.IO;
using System.Linq;
using System.Management.Automation;

using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Updates an existing role assignment.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RoleAssignment", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.RoleAssignment), OutputType(typeof(PSRoleAssignment))]
    public class SetAzureRoleAssignmentCommand : ResourcesBaseCmdlet
    {

        #region parameters
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.InputFile, HelpMessage = "File name containing a single role definition.")]
        public string InputFile { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.RoleAssignment, HelpMessage = "Role Assignment.")]
        public PSRoleAssignment InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            // Build the new Role assignment
            if (ParameterSetName == ParameterSet.InputFile)
            {
                string fileName = this.TryResolvePath(InputFile);
                if (!(new FileInfo(fileName)).Exists)
                {
                    throw new PSArgumentException(string.Format("File {0} does not exist", fileName));
                }

                try
                {
                    InputObject = JsonConvert.DeserializeObject<PSRoleAssignment>(File.ReadAllText(fileName));
                }
                catch (JsonException)
                {
                    WriteVerbose("Deserializing the input role definition failed.");
                    throw new Exception("Deserializing the input role assignment failed. Please confirm the file is properly formated");
                }
            }

            // Build the Update Request
            var Subscription = DefaultProfile.DefaultContext.Subscription.Id;
            var scope = InputObject.Scope;
            var RoleAssignmentGUID =InputObject.RoleAssignmentId.GuidFromFullyQualifiedId();

            FilterRoleAssignmentsOptions parameters = new FilterRoleAssignmentsOptions()
            {
                Scope = scope,
                RoleAssignmentId = RoleAssignmentGUID,
                ResourceIdentifier = new ResourceIdentifier()
                {
                    Subscription = Subscription,
                }
            };
            PSRoleAssignment fetchedRole = null;
            try
            {
                fetchedRole = PoliciesClient.FilterRoleAssignments(parameters, Subscription).First();
            }
            catch (Exception)
            {
                fetchedRole = InputObject;
            }

            // Validate the request
            AuthorizationClient.ValidateScope(parameters.Scope, false);
            bool isValidRequest = true;

            // Check that only Description, Condition and ConditionVersion have been changed, if anything else is changed the whole request fails
            isValidRequest &= InputObject.RoleAssignmentId.Equals(fetchedRole.RoleAssignmentId);
            isValidRequest &= InputObject.Scope.Equals(fetchedRole.Scope, StringComparison.OrdinalIgnoreCase);
            isValidRequest &= InputObject.RoleDefinitionId.Equals(fetchedRole.RoleDefinitionId);
            isValidRequest &= InputObject.ObjectId.Equals(fetchedRole.ObjectId);
            isValidRequest &= InputObject.ObjectType.Equals(fetchedRole.ObjectType);
            isValidRequest &= InputObject.CanDelegate.Equals(fetchedRole.CanDelegate);

            if (!isValidRequest)
            {
                throw new ArgumentException("Changing a property other than 'Description', 'Condition' or 'Condition Version' is currently not supported.");
            }

            // If ConditionVersion is changed, validate it's in the allowed values

            var oldConditionVersion = string.IsNullOrWhiteSpace(fetchedRole.ConditionVersion)? Version.Parse("0.0") : Version.Parse(fetchedRole.ConditionVersion);
            var newConditionVersion = string.IsNullOrWhiteSpace(InputObject.ConditionVersion) ? Version.Parse("0.0") : Version.Parse(InputObject.ConditionVersion);

            // A condition version can change but currently we don't support downgrading to 1.0
            // we only verify the change if it's a downgrade
            if ((oldConditionVersion > newConditionVersion) && (newConditionVersion.Major < 2))
            {
                throw new ArgumentException("Condition version different than '2.0' is not supported for update operations");
            }
            fetchedRole.Description = InputObject.Description;
            fetchedRole.Condition = InputObject.Condition;
            fetchedRole.ConditionVersion = InputObject.ConditionVersion;

            // Send Request
            ConfirmAction(
               string.Format(ProjectResources.UpdatingRoleAssignment, fetchedRole.RoleAssignmentId,fetchedRole.Scope,fetchedRole.RoleDefinitionName),
               fetchedRole.RoleAssignmentId,
               () =>
               {
                   var roleAssignments = PoliciesClient.UpdateRoleAssignment(fetchedRole);
                   if (PassThru)
                   {
                       WriteObject(roleAssignments, enumerateCollection: true);
                   }
               });
        }

    }

}
