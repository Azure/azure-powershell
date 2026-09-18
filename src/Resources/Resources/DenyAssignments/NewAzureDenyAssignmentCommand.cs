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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.Authorization;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Creates a new deny assignment at the specified scope.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DenyAssignment",
        SupportsShouldProcess = true,
        DefaultParameterSetName = EveryoneParameterSet),
        OutputType(typeof(PSDenyAssignment))]
    public class NewAzureDenyAssignmentCommand : ResourcesBaseCmdlet
    {
        private const string EveryoneParameterSet = "EveryoneParameterSet";
        private const string PerPrincipalParameterSet = "PerPrincipalParameterSet";
        private const string InputFileParameterSet = "InputFileParameterSet";

        #region Parameters

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "The display name for the deny assignment.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "The display name for the deny assignment.")]
        [ValidateNotNullOrEmpty]
        public string DenyAssignmentName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "A description of the deny assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "A description of the deny assignment.")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "Scope of the deny assignment. In the format of relative URI. For example, /subscriptions/{id}/resourceGroups/{rgName}.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Scope of the deny assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = InputFileParameterSet,
            HelpMessage = "Scope of the deny assignment. In the format of relative URI.")]
        [ValidateNotNullOrEmpty]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "Actions to deny. Wildcards supported (e.g. Microsoft.Storage/storageAccounts/write, */delete). Note: read actions (*/read) are not permitted for user-assigned deny assignments.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Actions to deny. Wildcards supported (e.g. Microsoft.Storage/storageAccounts/write, */delete). Note: read actions (*/read) are not permitted for user-assigned deny assignments.")]
        public string[] Action { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "Actions to exclude from the deny assignment.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Actions to exclude from the deny assignment.")]
        public string[] NotAction { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "Data actions to deny. Not supported for user-assigned deny assignments.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Data actions to deny. Not supported for user-assigned deny assignments.")]
        public string[] DataAction { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "Data actions to exclude from the deny assignment. Not supported for user-assigned deny assignments.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Data actions to exclude from the deny assignment. Not supported for user-assigned deny assignments.")]
        public string[] NotDataAction { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "Object IDs of principals to exclude from the deny assignment. Required when targeting Everyone.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Object IDs of principals to exclude from the deny assignment. Optional when using -PrincipalId.")]
        [ValidateNotNullOrEmpty]
        public string[] ExcludePrincipalId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "Type(s) of the exclude principals (User, Group, ServicePrincipal). One per ExcludePrincipalId, or a single value applied to all. Defaults to User.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Type(s) of the exclude principals (User, Group, ServicePrincipal). One per ExcludePrincipalId, or a single value applied to all. Defaults to User.")]
        [ValidateSet("User", "Group", "ServicePrincipal")]
        public string[] ExcludePrincipalType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Object ID of the user or service principal to deny.")]
        [ValidateNotNullOrEmpty]
        public string PrincipalId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "Type of the principal: User or ServicePrincipal. Group is not supported for user-assigned deny assignments.")]
        [ValidateSet("User", "ServicePrincipal")]
        public string PrincipalType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = EveryoneParameterSet,
            HelpMessage = "If set, the deny assignment does not apply to child scopes. Not supported for user-assigned deny assignments.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = PerPrincipalParameterSet,
            HelpMessage = "If set, the deny assignment does not apply to child scopes. Not supported for user-assigned deny assignments.")]
        public SwitchParameter DoNotApplyToChildScope { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = InputFileParameterSet,
            HelpMessage = "Path to a JSON file containing the deny assignment definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The GUID for the deny assignment. If not specified, a new GUID will be generated.")]
        public Guid DenyAssignmentId { get; set; }

        #endregion

        /// <summary>
        /// Validates options that apply to all input paths (command-line and InputFile).
        /// </summary>
        private static void ValidateDenyAssignmentOptions(CreateDenyAssignmentOptions options)
        {
            bool isEveryonePrincipal = false;
            if (options.PrincipalIds != null && options.PrincipalIds.Count == 1)
            {
                isEveryonePrincipal = Guid.TryParse(options.PrincipalIds[0], out Guid parsedId) && parsedId == Guid.Empty;
            }

            bool hasPerPrincipal = options.PrincipalIds != null && options.PrincipalIds.Count > 0
                && !isEveryonePrincipal;
            bool hasExcludes = options.ExcludePrincipalIds != null && options.ExcludePrincipalIds.Count > 0;

            // Validate per-principal fields
            if (hasPerPrincipal)
            {
                if (options.PrincipalIds.Count > 1)
                {
                    throw new PSArgumentException(
                        "Only one principal is supported per user-assigned deny assignment. " +
                        "Specify a single PrincipalId.");
                }

                // Validate principal type is present and supported
                if (options.PrincipalTypes == null || options.PrincipalTypes.Count == 0)
                {
                    throw new PSArgumentException(
                        "PrincipalTypes is required when PrincipalIds is specified. " +
                        "Accepted values: User, ServicePrincipal.");
                }

                if (options.PrincipalTypes.Count != options.PrincipalIds.Count)
                {
                    throw new PSArgumentException(
                        "PrincipalTypes count must match PrincipalIds count. " +
                        "Specify exactly one PrincipalType for the single PrincipalId.");
                }

                var supportedTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "User", "ServicePrincipal" };
                foreach (var principalType in options.PrincipalTypes)
                {
                    if (string.Equals(principalType, "Group", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(
                            "Group type principals are not supported for user-assigned deny assignments. " +
                            "Use 'User' or 'ServicePrincipal'.");
                    }
                    if (!supportedTypes.Contains(principalType))
                    {
                        throw new PSArgumentException(
                            string.Format("Unsupported principal type '{0}'. Accepted values: User, ServicePrincipal.", principalType));
                    }
                }
            }
            else if (options.PrincipalTypes != null && options.PrincipalTypes.Count > 0)
            {
                throw new PSArgumentException(
                    "PrincipalTypes must not be specified without PrincipalIds.");
            }

            // Everyone mode requires at least one excluded principal
            if (!hasPerPrincipal && !hasExcludes)
            {
                throw new PSArgumentException(
                    "At least one excluded principal is required via ExcludePrincipalIds when targeting Everyone. " +
                    "Use PrincipalId and PrincipalType to target a specific user or service principal instead.");
            }

            // Validate ExcludePrincipalTypes consistency
            if (!hasExcludes && options.ExcludePrincipalTypes != null && options.ExcludePrincipalTypes.Count > 0)
            {
                throw new PSArgumentException(
                    "ExcludePrincipalTypes must not be specified without ExcludePrincipalIds.");
            }

            if (hasExcludes && options.ExcludePrincipalTypes != null && options.ExcludePrincipalTypes.Count > 1
                && options.ExcludePrincipalTypes.Count != options.ExcludePrincipalIds.Count)
            {
                throw new PSArgumentException(
                    string.Format("ExcludePrincipalTypes must specify either 1 value (applied to all) or exactly {0} values " +
                    "(one per ExcludePrincipalIds). Got {1}.", options.ExcludePrincipalIds.Count, options.ExcludePrincipalTypes.Count));
            }

            // DataActions and DoNotApplyToChildScopes are not supported for UADA
            bool hasDataActions = (options.DataActions != null && options.DataActions.Count > 0)
                || (options.NotDataActions != null && options.NotDataActions.Count > 0);
            if (hasDataActions)
            {
                throw new PSArgumentException(
                    "DataActions and NotDataActions are not supported for user-assigned deny assignments. " +
                    "Only Actions and NotActions are permitted.");
            }

            if (options.DoNotApplyToChildScopes)
            {
                throw new PSArgumentException(
                    "DoNotApplyToChildScopes is not supported for user-assigned deny assignments.");
            }

            // Require at least one Action or NotAction
            bool hasActions = (options.Actions != null && options.Actions.Count > 0)
                || (options.NotActions != null && options.NotActions.Count > 0);
            if (!hasActions)
            {
                throw new PSArgumentException(
                    "At least one Action or NotAction is required to create a deny assignment.");
            }
        }

        public override void ExecuteCmdlet()
        {
            CreateDenyAssignmentOptions options;

            if (!string.IsNullOrEmpty(InputFile))
            {
                string fileName = this.SessionState.Path.GetUnresolvedProviderPathFromPSPath(InputFile);
                if (!File.Exists(fileName))
                {
                    throw new PSArgumentException(string.Format("File {0} does not exist.", fileName));
                }

                try
                {
                    options = JsonConvert.DeserializeObject<CreateDenyAssignmentOptions>(File.ReadAllText(fileName));
                }
                catch (JsonException ex)
                {
                    throw new PSArgumentException(string.Format("Error parsing input file: {0}", ex.Message));
                }

                options.Scope = Scope;
            }
            else
            {
                options = new CreateDenyAssignmentOptions
                {
                    DenyAssignmentName = DenyAssignmentName,
                    Description = Description,
                    Scope = Scope,
                    Actions = Action != null ? new List<string>(Action) : new List<string>(),
                    NotActions = NotAction != null ? new List<string>(NotAction) : new List<string>(),
                    DataActions = DataAction != null ? new List<string>(DataAction) : new List<string>(),
                    NotDataActions = NotDataAction != null ? new List<string>(NotDataAction) : new List<string>(),
                    ExcludePrincipalIds = ExcludePrincipalId != null ? new List<string>(ExcludePrincipalId) : new List<string>(),
                    ExcludePrincipalTypes = ExcludePrincipalType != null ? new List<string>(ExcludePrincipalType) : null,
                    DoNotApplyToChildScopes = DoNotApplyToChildScope.IsPresent,
                };

                // Populate per-principal fields from cmdlet params
                if (!string.IsNullOrEmpty(PrincipalId))
                {
                    options.PrincipalIds = new List<string> { PrincipalId };
                    options.PrincipalTypes = new List<string> { PrincipalType };
                }
            }

            ValidateDenyAssignmentOptions(options);
            AuthorizationClient.ValidateScope(options.Scope, false);

            Guid assignmentId = DenyAssignmentId == Guid.Empty ? Guid.NewGuid() : DenyAssignmentId;

            if (ShouldProcess(options.Scope,
                string.Format("Creating deny assignment '{0}'", options.DenyAssignmentName ?? assignmentId.ToString())))
            {
                PSDenyAssignment result = PoliciesClient.CreateDenyAssignment(options, assignmentId);
                WriteObject(result);
            }
        }
    }
}
