﻿// ----------------------------------------------------------------------------------
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

using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.Collections;
    using System.Management.Automation;

    /// <summary>
    /// Sets the policy assignment.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyAssignment", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(PSObject))]
    public class SetAzurePolicyAssignmentCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy assignment name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentScopeHelp)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment not scopes parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentNotScopesHelp)]
        [ValidateNotNullOrEmpty]
        public string[] NotScope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentIdHelp)]
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
        /// Gets or sets the policy sku object.
        /// </summary>
        [Alias("SkuObject")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyAssignmentSkuHelp)]
        [ValidateNotNullOrEmpty]
        [CmdletParameterBreakingChange("Sku", ChangeDescription = "The -Sku parameter is deprecated and ignored")]
        public Hashtable Sku { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
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

            this.WriteObject(this.GetOutputObjects("PolicyAssignmentId", JObject.Parse(result)), enumerateCollection: true);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            var metaDataJson = string.IsNullOrEmpty(this.Metadata) ? resource.Properties["metadata"]?.ToString() : GetObjectFromParameter(this.Metadata).ToString();

            var policyAssignmentObject = new PolicyAssignment
            {
                Name = this.Name ?? resource.Name,
                Sku = Sku?.ToDictionary(addValueLayer: false).ToJson().FromJson<PolicySku>(),  // only store Sku if it was provided by user
                Properties = new PolicyAssignmentProperties
                {
                    DisplayName = this.DisplayName ?? resource.Properties["displayName"]?.ToString(),
                    Description = this.Description ?? resource.Properties["description"]?.ToString(),
                    Scope = resource.Properties["scope"].ToString(),
                    NotScopes = this.NotScope ?? resource.Properties["NotScopes"]?.ToString().Split(','),
                    PolicyDefinitionId = resource.Properties["policyDefinitionId"].ToString(),
                    Metadata = string.IsNullOrEmpty(this.Metadata) ? null : JObject.Parse(metaDataJson),
                    Parameters = (JObject)resource.Properties["parameters"]
                }
            };

            return policyAssignmentObject.ToJToken();
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.MakePolicyAssignmentId(this.Scope, this.Name);
        }
    }
}
