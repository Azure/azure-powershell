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
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using WindowsAzure.Commands.Common;

    /// <summary>
    /// Sets the policy definition.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmPolicySetDefinition", DefaultParameterSetName = SetAzurePolicySetDefinitionCmdlet.PolicySetDefinitionNameParameterSet), OutputType(typeof(PSObject))]
    public class SetAzurePolicySetDefinitionCmdlet : PolicyDefinitionCmdletBase
    {
        /// <summary>
        /// The policy Id parameter set.
        /// </summary>
        internal const string PolicySetDefinitionIdParameterSet = "The policy set definition Id parameter set.";

        /// <summary>
        /// The policy name parameter set.
        /// </summary>
        internal const string PolicySetDefinitionNameParameterSet = "The policy set definition name parameter set.";

        /// <summary>
        /// Gets or sets the policy definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = SetAzurePolicySetDefinitionCmdlet.PolicySetDefinitionNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy set definition name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = SetAzurePolicySetDefinitionCmdlet.PolicySetDefinitionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified policy definition Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The display name for policy set definition.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description for policy set definition.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy definitions parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy set definition. This can either be a path to a file name containing the policy definitions, or the policy set definition as string.")]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitions { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            string resourceId = this.Id ?? this.GetResourceId();
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

            this.WriteObject(this.GetOutputObjects(JObject.Parse(result)), enumerateCollection: true);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            var policySetDefinitionObject = new PolicySetDefinition
            {
                Name = this.Name ?? ResourceIdUtility.GetResourceName(this.Id),
                Properties = new PolicySetDefinitionProperties
                {
                    Description = this.Description ?? (resource.Properties["description"] != null
                        ? resource.Properties["description"].ToString()
                        : null),
                    DisplayName = this.DisplayName ?? (resource.Properties["displayName"] != null
                        ? resource.Properties["displayName"].ToString()
                        : null)
                }
            };
            if (!string.IsNullOrEmpty(this.PolicyDefinitions))
            {
                policySetDefinitionObject.Properties.PolicyDefinitions = JArray.Parse(GetPolicyDefinitionsObject().ToString());
            }
            else
            {
                policySetDefinitionObject.Properties.PolicyDefinitions = JArray.Parse(resource.Properties["policyDefinitions"].ToString());
            }

            return policySetDefinitionObject.ToJToken();
        }

        /// <summary>
        /// Gets a resource.
        /// </summary>
        private async Task<JObject> GetExistingResource(string resourceId, string apiVersion)
        {
            return await this
                .GetResourcesClient()
                .GetResource<JObject>(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        protected string GetResourceId()
        {
            var subscriptionId = DefaultContext.Subscription.Id;
            return string.Format("/subscriptions/{0}/providers/{1}/{2}",
                subscriptionId.ToString(),
                Constants.MicrosoftAuthorizationPolicySetDefinitionType,
                this.Name);
        }

        /// <summary>
        /// Gets the policy rule object
        /// </summary>
        protected JToken GetPolicyDefinitionsObject()
        {
            string policyFilePath = this.TryResolvePath(this.PolicyDefinitions);

            return File.Exists(policyFilePath)
                ? JToken.FromObject(FileUtilities.DataStore.ReadFileAsText(policyFilePath))
                : JToken.FromObject(this.PolicyDefinitions);
        }
    }
}
