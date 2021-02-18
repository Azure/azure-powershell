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
<<<<<<< HEAD
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
=======
    using System;
    using System.Collections;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    using Newtonsoft.Json.Linq;
    using Policy;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    /// <summary>
    /// Creates a policy assignment.
    /// </summary>
<<<<<<< HEAD
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyAssignment", DefaultParameterSetName = PolicyCmdletBase.DefaultParameterSet), OutputType(typeof(PSObject))]
=======
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyAssignment", DefaultParameterSetName = PolicyCmdletBase.DefaultParameterSet), OutputType(typeof(PsPolicyAssignment))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class NewAzurePolicyAssignmentCmdlet : PolicyCmdletBase, IDynamicParameters
    {
        private readonly RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();

        /// <summary>
        /// Gets or sets the policy assignment name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope parameter
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentScopeHelp)]
=======
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentScopeHelp)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment not scopes parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentNotScopesHelp)]
        [ValidateNotNullOrEmpty]
        public string[] NotScope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy definition parameter.
        /// </summary>
<<<<<<< HEAD
=======
        [CmdletParameterBreakingChange("PolicyDefinition", OldParamaterType = typeof(PSObject), NewParameterTypeName = "PsPolicyDefinition")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Parameter(Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicyDefinitionHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.DefaultParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicyDefinitionHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicyDefinitionHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterStringParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicyDefinitionHelp)]
<<<<<<< HEAD
        public PSObject PolicyDefinition { get; set; }
=======
        public PsPolicyDefinition PolicyDefinition { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        /// <summary>
        /// Gets or sets the policy assignment policy set definition parameter.
        /// </summary>
<<<<<<< HEAD
=======
        [CmdletParameterBreakingChange("PolicySetDefinition", OldParamaterType = typeof(PSObject), NewParameterTypeName = "PsPolicySetDefinition")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Parameter(Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicySetDefinitionHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.DefaultParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicySetDefinitionHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicySetParameterObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicySetDefinitionHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicySetParameterStringParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicySetDefinitionHelp)]
<<<<<<< HEAD
        public PSObject PolicySetDefinition { get; set; }
=======
        public PsPolicySetDefinition PolicySetDefinition { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        /// <summary>
        /// Gets or sets the policy assignment policy parameter object.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicyParameterObjectHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicySetParameterObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentPolicyParameterObjectHelp)]
        public Hashtable PolicyParameterObject { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy parameter file path or policy parameter string.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicyParameterStringParameterSet,  Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyParameterHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.PolicySetParameterStringParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string PolicyParameter { get; set; }

        /// <summary>
        /// Gets or sets the new policy assignment metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
<<<<<<< HEAD
=======
        /// Gets or sets the policy assignment enforcement mode.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyAssignmentEnforcementModeHelp)]        
        [ValidateNotNullOrEmpty]
        public PolicyAssignmentEnforcementMode? EnforcementMode { get; set; }

        /// <summary>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// Gets or sets a flag indicating whether a system assigned identity should be added to the policy assignment.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = PolicyHelpStrings.PolicyAssignmentAssignIdentityHelp)]
        public SwitchParameter AssignIdentity { get; set; }

        /// <summary>
        /// Gets or sets the location of the policy assignment. Only required when assigning a resource identity to the assignment.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.PolicyAssignmentLocationHelp)]
        [LocationCompleter("Microsoft.ManagedIdentity/userAssignedIdentities")]
        public string Location { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.PolicyDefinition !=null && this.PolicySetDefinition !=null)
            {
                throw new PSInvalidOperationException("Only one of PolicyDefinition or PolicySetDefinition can be specified, not both.");
            }

<<<<<<< HEAD
            if (this.PolicyDefinition != null && this.PolicyDefinition.Properties["policyDefinitionId"] == null)
=======
            if (this.PolicyDefinition != null && this.PolicyDefinition.PolicyDefinitionId == null)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                throw new PSInvalidOperationException("The supplied PolicyDefinition object is invalid.");
            }

<<<<<<< HEAD
            if (this.PolicySetDefinition != null && this.PolicySetDefinition.Properties["policySetDefinitionId"] == null)
=======
            if (this.PolicySetDefinition != null && this.PolicySetDefinition.PolicySetDefinitionId == null)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                throw new PSInvalidOperationException("The supplied PolicySetDefinition object is invalid.");
            }

            string resourceId = GetResourceId();

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyAssignmentApiVersion : this.ApiVersion;

            var operationResult = this.GetResourcesClient()
                .PutResource(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    resource: this.GetResource(),
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

<<<<<<< HEAD
            this.WriteObject(this.GetOutputObjects("PolicyAssignmentId", JObject.Parse(result)), enumerateCollection: true);
=======
            this.WriteObject(this.GetOutputPolicyAssignments(JObject.Parse(result)), enumerateCollection: true);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            return this.MakePolicyAssignmentId(this.Scope, this.Name);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource()
        {
            var policyassignmentObject = new PolicyAssignment
            {
                Name = this.Name,
                Identity = this.AssignIdentity.IsPresent ? new ResourceIdentity { Type = ResourceIdentityType.SystemAssigned } : null,
                Location = this.Location,
                Properties = new PolicyAssignmentProperties
                {
                    DisplayName = this.DisplayName ?? null,
                    Description = this.Description ?? null,
                    Scope = this.Scope,
                    NotScopes = this.NotScope ?? null,
<<<<<<< HEAD
                    Metadata = this.Metadata == null ? null : JObject.Parse(this.GetObjectFromParameter(this.Metadata).ToString()),
=======
                    Metadata = this.Metadata == null ? null : this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata)),
                    EnforcementMode = EnforcementMode ?? PolicyAssignmentEnforcementMode.Default,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    Parameters = this.GetParameters(this.PolicyParameter, this.PolicyParameterObject)
                }
            };

            if (this.PolicyDefinition != null)
            {
<<<<<<< HEAD
                policyassignmentObject.Properties.PolicyDefinitionId = this.PolicyDefinition.Properties["policyDefinitionId"].Value.ToString();
            }
            else if (this.PolicySetDefinition != null)
            {
                policyassignmentObject.Properties.PolicyDefinitionId = this.PolicySetDefinition.Properties["policySetDefinitionId"].Value.ToString();
=======
                policyassignmentObject.Properties.PolicyDefinitionId = this.PolicyDefinition.PolicyDefinitionId;
            }
            else if (this.PolicySetDefinition != null)
            {
                policyassignmentObject.Properties.PolicyDefinitionId = this.PolicySetDefinition.PolicySetDefinitionId;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }

            return policyassignmentObject.ToJToken();
        }

        object IDynamicParameters.GetDynamicParameters()
        {
            PSObject parameters = null;
            if (this.PolicyDefinition != null)
            {
<<<<<<< HEAD
                parameters = this.PolicyDefinition.GetPSObjectProperty("Properties.parameters") as PSObject;
            }
            else if (this.PolicySetDefinition != null)
            {
                parameters = this.PolicySetDefinition.GetPSObjectProperty("Properties.parameters") as PSObject;
=======
                parameters = this.PolicyDefinition.Properties.Parameters;
            }
            else if (this.PolicySetDefinition != null)
            {
                parameters = this.PolicySetDefinition.Properties.Parameters;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }

            if (parameters != null)
            {
                foreach (var param in parameters.Properties)
                {
                    var paramValue = param.Value as PSObject;
                    if (paramValue != null)
                    {
                        var type = paramValue.Properties["type"];
                        var typeString = type != null ? type.Value.ToString() : string.Empty;
                        var description = paramValue.GetPSObjectProperty("metadata.description");
                        var helpString = description != null ? description.ToString() : string.Format("The {0} policy parameter.", param.Name);
                        var dp = new RuntimeDefinedParameter
                        {
                            Name = param.Name,
                            ParameterType = typeString.Equals("array", StringComparison.OrdinalIgnoreCase) ? typeof(string[]) : typeof(string)
                        };
                        
                        // Dynamic parameter should not be mandatory if it has a default value
                        dp.Attributes.Add(new ParameterAttribute
                        {
                            ParameterSetName = PolicyCmdletBase.DefaultParameterSet,
                            Mandatory = paramValue.Properties["defaultValue"] == null,
                            ValueFromPipelineByPropertyName = false,
                            HelpMessage = helpString
                        });

                        this.dynamicParameters.Add(param.Name, dp);
                    }
                }
            }

            this.RegisterDynamicParameters(this.dynamicParameters);
            return this.dynamicParameters;
        }
    }
}
