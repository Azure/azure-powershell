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
        DefaultParameterSetName = ScopeWithPrincipalsParameterSet),
        OutputType(typeof(PSDenyAssignment))]
    public class NewAzureDenyAssignmentCommand : ResourcesBaseCmdlet
    {
        private const string ScopeWithPrincipalsParameterSet = "ScopeWithPrincipalsParameterSet";
        private const string InputFileParameterSet = "InputFileParameterSet";

        #region Parameters

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "The display name for the deny assignment.")]
        [ValidateNotNullOrEmpty]
        public string DenyAssignmentName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "A description of the deny assignment.")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "Scope of the deny assignment. In the format of relative URI. For example, /subscriptions/{id}/resourceGroups/{rgName}.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = InputFileParameterSet,
            HelpMessage = "Scope of the deny assignment. In the format of relative URI.")]
        [ValidateNotNullOrEmpty]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "Actions to deny. Wildcards supported (e.g. Microsoft.Storage/storageAccounts/write, */delete). Note: read actions (*/read) are not permitted for user-assigned deny assignments.")]
        public string[] Action { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "Actions to exclude from the deny assignment.")]
        public string[] NotAction { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "Data actions to deny. Not supported for user-assigned deny assignments (Private Preview).")]
        public string[] DataAction { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "Data actions to exclude from the deny assignment. Not supported for user-assigned deny assignments (Private Preview).")]
        public string[] NotDataAction { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "Object IDs of principals to exclude from the deny assignment. Required when principal is Everyone.")]
        [ValidateNotNullOrEmpty]
        public string[] ExcludePrincipalId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "Type(s) of the exclude principals (User, Group, ServicePrincipal). One per ExcludePrincipalId, or a single value applied to all. Defaults to User.")]
        [ValidateSet("User", "Group", "ServicePrincipal")]
        public string[] ExcludePrincipalType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ScopeWithPrincipalsParameterSet,
            HelpMessage = "If set, the deny assignment does not apply to child scopes. Not supported for user-assigned deny assignments (Private Preview).")]
        public SwitchParameter DoNotApplyToChildScope { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = InputFileParameterSet,
            HelpMessage = "Path to a JSON file containing the deny assignment definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The GUID for the deny assignment. If not specified, a new GUID will be generated.")]
        public Guid DenyAssignmentId { get; set; }

        #endregion

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

                // PP1 requires at least one excluded principal
                if (options.ExcludePrincipalIds == null || options.ExcludePrincipalIds.Count == 0)
                {
                    throw new PSArgumentException(
                        "Input file must specify at least one ExcludePrincipalIds entry. " +
                        "PP1 deny assignments apply to Everyone and require at least one excluded principal.");
                }
            }
            else
            {
                // PP1 client-side validation: DataActions not supported
                if ((DataAction != null && DataAction.Length > 0) || (NotDataAction != null && NotDataAction.Length > 0))
                {
                    throw new PSArgumentException(
                        "DataActions and NotDataActions are not supported for PP1 user-assigned deny assignments. " +
                        "Only Actions and NotActions are permitted.");
                }

                // PP1 client-side validation: DoNotApplyToChildScopes not supported
                if (DoNotApplyToChildScope.IsPresent)
                {
                    throw new PSArgumentException(
                        "DoNotApplyToChildScopes is not supported for PP1 user-assigned deny assignments.");
                }

                // Require at least one Action or NotAction
                if ((Action == null || Action.Length == 0) && (NotAction == null || NotAction.Length == 0))
                {
                    throw new PSArgumentException(
                        "At least one -Action or -NotAction is required to create a deny assignment.");
                }

                // Validate ExcludePrincipalType count matches ExcludePrincipalId count
                if (ExcludePrincipalType != null && ExcludePrincipalType.Length > 1
                    && ExcludePrincipalType.Length != ExcludePrincipalId.Length)
                {
                    throw new PSArgumentException(
                        string.Format("-ExcludePrincipalType must specify either 1 value (applied to all) or exactly {0} values " +
                        "(one per -ExcludePrincipalId). Got {1}.", ExcludePrincipalId.Length, ExcludePrincipalType.Length));
                }

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
            }

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
