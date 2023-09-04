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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Common.Exceptions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Newtonsoft.Json.Linq;
    using Policy;

    /// <summary>
    /// Sets the policy assignment.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(
        typeof(PsPolicyAssignment), deprecateByAzVersion: "11.0.0", deprecateByVersion: "7.0.0", DeprecatedOutputProperties = new[] { "Properties" },
        NewOutputProperties = new[] { "Description", "DisplayName", "EnforcementMode", "Metadata", "NonComplianceMessages", "NotScopes", "Parameters", "PolicyDefinitionId", "Scope" })]
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyAssignment", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(PsPolicyAssignment))]
    public class SetAzurePolicyAssignmentCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy assignment name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterNameObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentPolicyParameterObjectHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterNameStringParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentScopeHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterNameObjectParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentPolicyParameterObjectHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterNameStringParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment not scopes parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentNotScopesHelp)]
        [ValidateNotNull]
        public string[] NotScope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentIdHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterIdObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentPolicyParameterObjectHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterIdStringParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the new policy assignment metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy parameter object.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterNameObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentPolicyParameterObjectHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterIdObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentPolicyParameterObjectHelp)]
        public Hashtable PolicyParameterObject { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy parameter file path or policy parameter string.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterNameStringParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyParameterHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterIdStringParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string PolicyParameter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = PolicyHelpStrings.PolicyAssignmentAssignIdentityHelp)]
        public SwitchParameter AssignIdentity { get; set; }

        /// <summary>
        /// Gets or sets the location of the policy assignment. Only required when assigning a resource identity to the assignment.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.PolicyAssignmentLocationHelp)]
        [LocationCompleter("Microsoft.ManagedIdentity/userAssignedIdentities")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment enforcement mode.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentEnforcementModeHelp)]
        [ValidateNotNullOrEmpty]
        public PolicyAssignmentEnforcementMode? EnforcementMode { get; set; }

        /// <summary>
        /// Gets or sets the type of managed identity to be assigned to the policy assignment.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = PolicyHelpStrings.PolicyAssignmentIdentityTypeHelp)]
        public ManagedIdentityType? IdentityType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user assigned managed identity to be assigned to the policy assignment.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = PolicyHelpStrings.PolicyAssignmentIdentityIdHelp)]
        public string IdentityId { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment input object parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentInputObjectHelp)]
        public PsPolicyAssignment InputObject { get; set; }

        /// <summary>
        /// Gets or sets the messages that describe why a resource is non-compliant with the policy.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.PolicyAssignmentNonComplianceMessageHelp)]
        [ValidateNotNull]
        public PsNonComplianceMessage[] NonComplianceMessage { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            CheckIfIdentityPresent();
            string resourceId = this.GetResourceId();
            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyAssignmentApiVersion : this.ApiVersion;

            var operationResult = this.GetResourcesClient()
                        .PutResource(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            resource: this.GetResource(resourceId, apiVersion),
                            cancellationToken: this.CancellationToken.Value,
                            odataQuery: null)
                        .Result;

            var managementUri = this.GetResourcesClient()
              .GetResourceManagementRequestUri(
                  resourceId: resourceId,
                  apiVersion: apiVersion,
                  odataQuery: null);

            var activity = string.Format("PUT {0}", managementUri.PathAndQuery);
            var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: true)
                .WaitOnOperation(operationResult: operationResult);

            this.WriteObject(this.GetOutputPolicyAssignments(JObject.Parse(result)), enumerateCollection: true);
        }

        /// <summary>
        /// Verifies if identity type and/or identity ID and/or location are present
        /// </summary>
        private bool CheckIfIdentityPresent()
        {
            if (this.AssignIdentity.IsPresent && this.IdentityType != null)
            {
                throw new AzPSArgumentException("Cannot specify both IdentityType and AssignIdentity at the same time.", "IdentityType");
            }

            if (this.AssignIdentity.IsPresent && !string.IsNullOrEmpty(this.IdentityId))
            {
                throw new AzPSArgumentException("Cannot specify both AssignIdentity and IdentityId at the same time.", "IdentityId");
            }

            if (this.IdentityType != null && string.IsNullOrEmpty(this.Location) || this.AssignIdentity.IsPresent && string.IsNullOrEmpty(this.Location))
            {
                throw new AzPSArgumentException("Location needs to be specified if a managed identity is to be assigned to the policy assignment.", "Location");
            }

            if (this.IdentityType == ManagedIdentityType.UserAssigned && string.IsNullOrEmpty(this.IdentityId))
            {
                throw new AzPSArgumentException("A user assigned identity id needs to be specified if the identity type is 'UserAssigned'.", "IdentityId");
            }

            if (this.IdentityType == ManagedIdentityType.SystemAssigned && !string.IsNullOrEmpty(this.IdentityId))
            {
                throw new AzPSArgumentException("Cannot specify an identity ID if identity type is 'SystemAssigned'.", "IdentityId");
            }

            return true;
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource<PolicyAssignmentProperties>();

            // get incoming object properties if present
            JObject inputMetadata = null;
            if (this.InputObject != null)
            {
                var newProperties = this.InputObject.Properties.ToJToken();
                inputMetadata = newProperties["metadata"] as JObject;
            }

            var parameterMetadata = this.Metadata != null ? this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata)) : null;

            PolicyAssignmentEnforcementMode? inputMode = null;
            if (Enum.TryParse(this.InputObject?.Properties?.EnforcementMode?.ToString(), true, out PolicyAssignmentEnforcementMode tempMode1))
            {
                inputMode = tempMode1;
            }

            // Grab the non-compliance messages from the parameter or input object or existing resource
            var nonComplianceMessages = this.NonComplianceMessage?.Where(message => message != null).SelectArray(message => message.ToModel());
            if (nonComplianceMessages == null && this.InputObject?.Properties.NonComplianceMessages != null)
            {
                nonComplianceMessages = this.InputObject.Properties.NonComplianceMessages.Where(message => message != null).SelectArray(message => message.ToModel());
            }
            else if (nonComplianceMessages == null)
            {
                nonComplianceMessages = resource.Properties.NonComplianceMessages;
            }

            if (this.AssignIdentity != null && this.AssignIdentity.IsPresent)
            {
                this.IdentityType = ManagedIdentityType.SystemAssigned;
            }

            ResourceIdentity identityObject = this.IdentityType != null ?
                ( this.IdentityType == ManagedIdentityType.UserAssigned ?
                    new ResourceIdentity
                    {
                        Type = IdentityType.ToString(),
                        UserAssignedIdentities = new Dictionary<string, UserAssignedIdentityResource>
                        {
                            { this.IdentityId, new UserAssignedIdentityResource {} }
                        }
                    } :
                    new ResourceIdentity { Type = IdentityType.ToString() }
                ) : null;

            var policyAssignmentObject = new PolicyAssignment
            {
                Name = this.Name ?? this.InputObject?.Name ?? resource.Name,
                Identity = identityObject,
                Location = this.Location ?? this.InputObject?.Location ?? resource.Location,
                Properties = new PolicyAssignmentProperties
                {
                    DisplayName = this.DisplayName ?? this.InputObject?.Properties?.DisplayName ?? resource.Properties.DisplayName,
                    Description = this.Description ?? this.InputObject?.Properties?.Description ?? resource.Properties.Description,
                    Scope = resource.Properties.Scope,
                    NotScopes = this.NotScope ?? this.InputObject?.Properties?.NotScopes ?? resource.Properties.NotScopes,
                    PolicyDefinitionId = resource.Properties.PolicyDefinitionId,
                    Metadata = parameterMetadata ?? inputMetadata ?? resource.Properties.Metadata,
                    EnforcementMode = this.EnforcementMode ?? inputMode ?? resource.Properties.EnforcementMode,
                    NonComplianceMessages = nonComplianceMessages,
                    Parameters =
                        this.GetParameters(this.PolicyParameter, this.PolicyParameterObject)
                            ?? this.InputObject?.Properties?.Parameters?.ToResourcePropertiesBody() as JObject
                            ?? resource.Properties.Parameters
                }
            };

            return policyAssignmentObject.ToJToken();
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.InputObject?.ResourceId ?? this.GetPolicyArtifactFullyQualifiedId(this.Scope, Constants.MicrosoftAuthorizationPolicyAssignmentType, this.Name);
        }
    }
}
