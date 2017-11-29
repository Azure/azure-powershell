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
    using Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Application;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections;
    using System.IO;
    using System.Management.Automation;
    using WindowsAzure.Commands.Common;

    /// <summary>
    /// Creates the managed application.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmManagedApplication", DefaultParameterSetName = SetAzureManagedApplicationCmdlet.ManagedApplicationNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public class SetAzureManagedApplicationCmdlet : ManagedApplicationCmdletBase
    {
        /// <summary>
        /// The managed application Id parameter set.
        /// </summary>
        internal const string ManagedApplicationIdParameterSet = "SetById";

        /// <summary>
        /// The managed application name parameter set.
        /// </summary>
        internal const string ManagedApplicationNameParameterSet = "SetByNameAndResourceGroup";

        /// <summary>
        /// Gets or sets the managed application name parameter.
        /// </summary>
        [Parameter(ParameterSetName = SetAzureManagedApplicationCmdlet.ManagedApplicationNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the managed application resource group parameter
        /// </summary>
        [Parameter(ParameterSetName = SetAzureManagedApplicationCmdlet.ManagedApplicationNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed application id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = SetAzureManagedApplicationCmdlet.ManagedApplicationIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified managed application Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the managed application managed resource group parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ManagedResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed application managed application definition id parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ManagedApplicationDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the managed application parameters parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The JSON formatted string of parameters for managed application. This can either be a path to a file name or uri containing the parameters, or the parameters as string.")]
        [ValidateNotNullOrEmpty]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The managed application kind. One of marketplace or servicecatalog")]
        [ValidateNotNullOrEmpty]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the plan object.
        /// </summary>
        [Alias("PlanObject")]
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents managed application plan properties.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Plan { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.ShouldProcess(this.Name, "Update Managed Application"))
            {
                string resourceId = this.Id ?? GetResourceId();

                var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.ApplicationApiVersion : this.ApiVersion;
                var resourceBody = this.GetResourceBody(resourceId, apiVersion);

                var operationResult = this.ShouldUsePatchSemantics()
                    ? this.GetResourcesClient()
                        .PatchResource(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            resource: resourceBody,
                            cancellationToken: this.CancellationToken.Value,
                            odataQuery: null)
                        .Result
                    : this.GetResourcesClient()
                        .PutResource(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            resource: resourceBody,
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
                this.WriteObject(this.GetOutputObjects("ManagedApplicationId", JObject.Parse(result)), enumerateCollection: true);
            }
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            var subscriptionId = DefaultContext.Subscription.Id;
            return string.Format("/subscriptions/{0}/resourcegroups/{1}/providers/{2}/{3}",
                subscriptionId.ToString(),
                this.ResourceGroupName,
                Constants.MicrosoftApplicationType,
                this.Name);
        }

        /// <summary>
        /// Gets the resource body.
        /// </summary>
        private JToken GetResourceBody(string resourceId, string apiVersion)
        {
            if (this.ShouldUsePatchSemantics())
            {
                var resourceBody = this.GetPatchResourceBody();
                return resourceBody == null ? null : resourceBody.ToJToken();
            }
            else
            {
                return this.GetResource(resourceId, apiVersion);
            }
        }

        /// <summary>
        /// Gets the resource body for PATCH calls
        /// </summary>
        private Resource<JToken> GetPatchResourceBody()
        {
            if(this.Tag == null)
            {
                return null;
            }
            else
            {
                Resource<JToken> resourceBody = new Resource<JToken>();
                resourceBody.Tags = TagsHelper.GetTagsDictionary(this.Tag);
                return resourceBody;
            }
        }

        /// <summary>
        /// Determines if the cmdlet should use <c>PATCH</c> semantics.
        /// </summary>
        private bool ShouldUsePatchSemantics()
        {
            return ((this.Tag != null) && this.Plan == null && this.Kind == null 
                && this.ManagedApplicationDefinitionId == null && this.ManagedResourceGroupName ==null
                && this.Parameter == null);
        }


        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            var applicationObject = new Application
            {
                Name = this.Name,
                Location = resource.Location,
                Plan = this.Plan == null
                    ? resource.Plan
                    : this.Plan.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourcePlan>(),
                Properties = new ApplicationProperties
                {
                    ManagedResourceGroupId = string.IsNullOrEmpty(this.ManagedResourceGroupName)
                        ? resource.Properties["managedResourceGroupId"].ToString()
                        : string.Format("/subscriptions/{0}/resourcegroups/{1}", Guid.Parse(DefaultContext.Subscription.Id), this.ManagedResourceGroupName),
                    ApplicationDefinitionId =this.ManagedApplicationDefinitionId ?? resource.Properties["applicationDefinitionId"].ToString(),
                    Parameters = this.Parameter == null 
                    ? (resource.Properties["parameters"] != null ? JObject.Parse(resource.Properties["parameters"].ToString()) : null)
                    : JObject.Parse(this.GetObjectFromParameter(this.Parameter).ToString())
                },
                Tags = TagsHelper.GetTagsDictionary(this.Tag) ?? resource.Tags
            };

            return applicationObject.ToJToken();
        }
    }
}
