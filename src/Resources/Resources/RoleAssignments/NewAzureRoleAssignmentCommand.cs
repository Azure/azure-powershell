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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Creates new role assignment.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RoleAssignment", DefaultParameterSetName = ParameterSet.Empty), OutputType(typeof(PSRoleAssignment))]
    public class NewAzureRoleAssignmentCommand : ResourcesBaseCmdlet
    {
        #region Parameters

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "The user or group object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "PrincipalId")]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "The user SignInName.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "The user SignInName.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "The user SignInName.")]
        [ValidateNotNullOrEmpty]
        [Alias("Email", "UserPrincipalName")]
        public string SignInName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "The app SPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN", "ServicePrincipalName")]
        public string ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Resource group to assign the role to.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Type of the resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [ValidateNotNullOrEmpty]
        public string ParentResource { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Role name to assign the principals with.")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Brief description of the role assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Brief description of the role assignment.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Condition to be applied to the RoleAssignment.")]
        [ValidateNotNullOrEmpty]
        public string Condition { get; set; } = null;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Version of the condition.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Version of the condition.")]
        [ValidateNotNullOrEmpty]
        public string ConditionVersion { get; set; } = null;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "To be used with ObjectId. Specifies the type of the asignee object")]
        [PSArgumentCompleter("User", "Group", "Service Principal")]
        [Alias("PrincipalType")]
        public string ObjectType { get; set; } = null;

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Role Id the principal is assigned to.")]
        [ValidateGuidNotEmpty]
        public Guid RoleDefinitionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.InputFile,
            HelpMessage = "Path to role assignment json")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Delegation flag.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowDelegation { get; set; }

        #endregion

        public Guid RoleAssignmentId { get; set; } = default(Guid);

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParameterSet.InputFile)
            {
                string fileName = this.TryResolvePath(InputFile);
                if (!(new FileInfo(fileName)).Exists)
                {
                    throw new PSArgumentException(string.Format("File {0} does not exist", fileName));
                }

                try
                {
                    PSRoleAssignment RoleAssignment = JsonConvert.DeserializeObject<PSRoleAssignment>(File.ReadAllText(fileName));

                    this.ObjectId = RoleAssignment.ObjectId;
                    this.ObjectType = RoleAssignment.ObjectType;
                    this.ResourceType = RoleAssignment.ObjectType;
                    this.Scope = RoleAssignment.Scope;
                    Guid guid = Guid.Empty;
                    Guid.TryParse(RoleAssignment.RoleDefinitionId, out guid);
                    this.RoleDefinitionId = guid;
                    this.Description = RoleAssignment.Description;
                    this.Condition = RoleAssignment.Condition;
                    this.ConditionVersion = RoleAssignment.ConditionVersion;
                }
                catch (JsonException)
                {
                    WriteVerbose("Deserializing the input role assignment failed.");
                    throw new Exception("Deserializing the input role assignment failed. Please confirm the file is properly formated");
                }
            }
            if (string.IsNullOrEmpty(Condition) ^ string.IsNullOrEmpty(ConditionVersion))
            {
                if (!string.IsNullOrEmpty(Condition))
                {
                    ConditionVersion = "2.0";
                    WriteDebug("-Condition was set but -ConditionVersion was not, defaulting to lowest publicly available version: '2.0'");
                }
                else
                {
                    WriteExceptionError(new ArgumentException("If -ConditionVersion is set -Condition can not be empty."));
                    return;
                }

            }
            // ensure that if ConditionVersion is empty in any way, it becomes null
            ConditionVersion = string.IsNullOrEmpty(ConditionVersion) ? null : string.IsNullOrWhiteSpace(ConditionVersion) ? null : ConditionVersion; 
            var _conditionVersion = Version.Parse(ConditionVersion ?? "2.0");
            if (_conditionVersion.Major < 2)
            {
                WriteExceptionError(new ArgumentException("Argument -ConditionVersion must be greater or equal than 2.0"));
                return;
            }
            FilterRoleAssignmentsOptions parameters = new FilterRoleAssignmentsOptions()
            {
                Scope = Scope,
                RoleDefinitionName = RoleDefinitionName,
                RoleDefinitionId = RoleDefinitionId == Guid.Empty ? null : RoleDefinitionId.ToString(),
                ADObjectFilter = new ADObjectFilterOptions
                {
                    UPN = SignInName,
                    SPN = ApplicationId,
                    Id = ObjectId,
                    ObjectType = ObjectType,
                },
                ResourceIdentifier = new ResourceIdentifier()
                {
                    ParentResource = ParentResource,
                    ResourceGroupName = ResourceGroupName,
                    ResourceName = ResourceName,
                    ResourceType = ResourceType,
                    Subscription = DefaultProfile.DefaultContext.Subscription.Id,
                },
                CanDelegate = AllowDelegation.IsPresent ? true : false,
                Description = Description,
                Condition = Condition,
                ConditionVersion = ConditionVersion,
            };

            AuthorizationClient.ValidateScope(parameters.Scope, false);

            WriteObject(PoliciesClient.CreateRoleAssignment(parameters, RoleAssignmentId));
        }
    }
}
