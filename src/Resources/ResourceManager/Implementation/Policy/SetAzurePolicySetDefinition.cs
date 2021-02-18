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
    using Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.IO;
=======
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using System.Management.Automation;

    /// <summary>
    /// Sets the policy definition.
    /// </summary>
<<<<<<< HEAD
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicySetDefinition", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSObject))]
=======
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicySetDefinition", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PsPolicySetDefinition))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class SetAzurePolicySetDefinitionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy set definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionIdHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy definition parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionPolicyDefinitionHelp)]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinition { get; set; }

        /// <summary>
        /// Gets or sets the policy definition metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the policy definition parameters parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionParameterHelp)]
        [ValidateNotNullOrEmpty]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition management group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionManagementGroupHelp)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition subscription id parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionSubscriptionIdHelp)]
        [ValidateNotNullOrEmpty]
        public Guid? SubscriptionId { get; set; }

        /// <summary>
<<<<<<< HEAD
=======
        /// Gets or sets the policy set definition input object parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionInputObjectHelp)]
        public PsPolicySetDefinition InputObject { get; set; }

        /// <summary>
        /// Gets or sets the policy definition groups parameter of the new policy set definition
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicySetDefinitionGroupDefinitionHelp)]
        [ValidateNotNullOrEmpty]
        public string GroupDefinition { get; set; }

        /// <summary>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.ShouldProcess(this.Name, "Update Policy Set Definition"))
            {
                string resourceId = this.GetResourceId();
                var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicySetDefintionApiVersion : this.ApiVersion;

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

<<<<<<< HEAD
                this.WriteObject(this.GetOutputObjects("PolicySetDefinitionId", JObject.Parse(result)), enumerateCollection: true);
=======
                this.WriteObject(this.GetOutputPolicySetDefinitions(JObject.Parse(result)), enumerateCollection: true);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

<<<<<<< HEAD
            var metaDataJson = string.IsNullOrEmpty(this.Metadata) ? resource.Properties["metadata"]?.ToString() : GetObjectFromParameter(this.Metadata).ToString();
            var parameterJson = string.IsNullOrEmpty(this.Parameter) ? resource.Properties["parameters"]?.ToString() : GetObjectFromParameter(this.Parameter).ToString();
=======
            // apply incoming object properties if present
            if (this.InputObject != null)
            {
                resource.Properties = this.InputObject.Properties.ToJToken();
            }

            var metaDataJson = string.IsNullOrEmpty(this.Metadata) ? resource.Properties["metadata"]?.ToString() : this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata)).ToString();
            var parameterJson = string.IsNullOrEmpty(this.Parameter) ? resource.Properties["parameters"]?.ToString() : this.GetObjectFromParameter(this.Parameter, nameof(this.Parameter)).ToString();
            var groupsJson = string.IsNullOrEmpty(this.GroupDefinition) ? resource.Properties["policyDefinitionGroups"]?.ToString() : this.GetArrayFromParameter(this.GroupDefinition, nameof(this.GroupDefinition)).ToString();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            var policySetDefinitionObject = new PolicySetDefinition
            {
                Name = this.Name ?? resource.Name,
                Properties = new PolicySetDefinitionProperties
                {
                    Description = this.Description ?? resource.Properties["description"]?.ToString(),
                    DisplayName = this.DisplayName ?? resource.Properties["displayName"]?.ToString(),
<<<<<<< HEAD
                    PolicyDefinitions = string.IsNullOrEmpty(this.PolicyDefinition) ? JArray.Parse(resource.Properties["policyDefinitions"].ToString()) : GetPolicyDefinitionsObject(),
                    Metadata = string.IsNullOrEmpty(metaDataJson) ?  null : JObject.Parse(metaDataJson),
                    Parameters = string.IsNullOrEmpty(parameterJson) ? null : JObject.Parse(parameterJson)
=======
                    PolicyDefinitions = string.IsNullOrEmpty(this.PolicyDefinition) ? resource.Properties["policyDefinitions"] as JArray : this.GetArrayFromParameter(this.PolicyDefinition, nameof(this.PolicyDefinition)),
                    Metadata = string.IsNullOrEmpty(metaDataJson) ?  null : JObject.Parse(metaDataJson),
                    Parameters = string.IsNullOrEmpty(parameterJson) ? null : JObject.Parse(parameterJson),
                    PolicyDefinitionGroups = string.IsNullOrEmpty(groupsJson) ? null : JArray.Parse(groupsJson)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                }
            };

            return policySetDefinitionObject.ToJToken();
        }

        /// <summary>
<<<<<<< HEAD
        /// Gets the policy definitions object
        /// </summary>
        private JArray GetPolicyDefinitionsObject()
        {
            string policyFilePath = this.TryResolvePath(this.PolicyDefinition);

            return File.Exists(policyFilePath)
                ? JArray.Parse(FileUtilities.DataStore.ReadFileAsText(policyFilePath))
                : JArray.Parse(this.PolicyDefinition);
        }

        /// <summary>
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
<<<<<<< HEAD
            return this.Id ?? this.MakePolicySetDefinitionId(this.ManagementGroupName, this.SubscriptionId, this.Name);
=======
            return this.Id ?? this.InputObject?.ResourceId ?? this.MakePolicySetDefinitionId(this.ManagementGroupName, this.SubscriptionId, this.Name);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
