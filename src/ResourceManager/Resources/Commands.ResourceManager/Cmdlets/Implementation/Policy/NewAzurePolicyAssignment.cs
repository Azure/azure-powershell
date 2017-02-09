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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System.Management.Automation;
    using System;
    using System.Linq;
    using System.Collections;

    /// <summary>
    /// Creates a policy assignment.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmPolicyAssignment"), OutputType(typeof(PSObject))]
    public class NewAzurePolicyAssignmentCmdlet : PolicyAssignmentCmdletBase, IDynamicParameters
    {
        protected RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();

        protected const string PolicyParameterObjectParameterSetName = "Policy assignment with parameters via policy parameter object";
        protected const string PolicyParameterStringParameterSetName = "Policy assignment with parameters via policy parameter string";

        /// <summary>
        /// Gets or sets the policy assignment name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy assignment name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scope for policy assignment.")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description for policy assignment.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy definition parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy definition object.")]
        public PSObject PolicyDefinition { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy parameter object.
        /// </summary>
        [Parameter(ParameterSetName = PolicyParameterObjectParameterSetName,
            Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy parameter object.")]
        public Hashtable PolicyParameterObject { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy parameter file path or policy parameter string.
        /// </summary>
        [Parameter(ParameterSetName = PolicyParameterStringParameterSetName, 
            Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy parameter file path or policy parameter string.")]
        [ValidateNotNullOrEmpty]
        public string PolicyParameter { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.PolicyDefinition.Properties["policyDefinitionId"] == null)
            {
                throw new PSInvalidOperationException("The supplied PolicyDefinition object is invalid.");
            }
            string resourceId = GetResourceId();

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyApiVersion : this.ApiVersion;

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

            this.WriteObject(this.GetOutputObjects(JObject.Parse(result)), enumerateCollection: true);
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            return ResourceIdUtility.GetResourceId(
                resourceId: this.Scope,
                extensionResourceType: Constants.MicrosoftAuthorizationPolicyAssignmentType,
                extensionResourceName: this.Name);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource()
        {
            var policyassignmentObject = new PolicyAssignment
            {
                Name = this.Name,
                Properties = new PolicyAssignmentProperties
                {
                    DisplayName = this.DisplayName ?? null,
                    PolicyDefinitionId = this.PolicyDefinition.Properties["policyDefinitionId"].Value.ToString(),
                    Scope = this.Scope,
                    Parameters = this.GetParameters()
                }
            };

            return policyassignmentObject.ToJToken();
        }

        object IDynamicParameters.GetDynamicParameters()
        {
            if (this.PolicyDefinition != null)
            {
                var properties = this.PolicyDefinition.Properties["Properties"]?.Value as PSObject;
                if (properties != null)
                {
                    var parameters = properties.Properties["parameters"]?.Value as PSObject;
                    if (parameters != null)
                    {
                        foreach (var param in parameters.Properties)
                        {
                            var type = Convert.ToString((param.Value as PSObject).Properties["type"]?.Value);
                            var dp = new RuntimeDefinedParameter
                            {
                                Name = param.Name,
                                ParameterType = type.Equals("array", StringComparison.OrdinalIgnoreCase) ? typeof(object[]) : typeof(string)
                            };
                            dp.Attributes.Add(new ParameterAttribute
                            {
                                Mandatory = false,
                                ValueFromPipelineByPropertyName = true,
                                HelpMessage = param.Name
                            });
                            this.dynamicParameters.Add(param.Name, dp);
                        }
                    }
                }
            }

            return this.dynamicParameters;
        }

        private JObject GetParameters()
        {
            // Load parameters from local file or literal
            if (this.PolicyParameter != null)
            {
                string policyParameterFilePath = this.TryResolvePath(this.PolicyParameter);
                return FileUtilities.DataStore.FileExists(policyParameterFilePath)
                    ? JObject.Parse(FileUtilities.DataStore.ReadFileAsText(policyParameterFilePath))
                    : JObject.Parse(this.PolicyParameter);
            }

            // Load from PS object
            JObject parameterObject = null;
            if (this.PolicyParameterObject != null)
            {
                parameterObject = new JObject();
                foreach (string paramKey in this.PolicyParameterObject.Keys)
                {
                    var valueObject = new JObject();
                    valueObject.Add("value", this.PolicyParameterObject[paramKey].ToJToken());
                    parameterObject.Add(paramKey, valueObject);
                }
                return parameterObject;
            }

            // Load dynamic parameters
            var parameters = PowerShellUtilities.GetUsedDynamicParameters(dynamicParameters, MyInvocation);
            if (parameters.Count() > 0)
            {
                parameterObject = new JObject();
                foreach (var dp in parameters)
                {
                    var valueObject = new JObject();
                    valueObject.Add("value", MyInvocation.BoundParameters[dp.Name].ToJToken());
                    parameterObject.Add(dp.Name, valueObject);
                }
            }
            return parameterObject;
        }
    }
}