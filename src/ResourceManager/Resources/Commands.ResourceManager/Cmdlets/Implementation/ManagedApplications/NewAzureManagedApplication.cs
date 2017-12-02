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
    [Cmdlet(VerbsCommon.New, "AzureRmManagedApplication", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public class NewAzureManagedApplicationCmdlet : ManagedApplicationCmdletBase
    {
        /// <summary>
        /// Gets or sets the managed application name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the managed application resource group parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed application managed resource group parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ManagedResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed application managed application definition id parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ManagedApplicationDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource location.")]
        [LocationCompleter("Microsoft.Solutions/applications")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the managed application parameters parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The JSON formatted string of parameters for managed application. This can either be a path to a file name or uri containing the parameters, or the parameters as string.")]
        [ValidateNotNullOrEmpty]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The managed application kind. One of marketplace or servicecatalog")]
        [ValidateNotNullOrEmpty]
        public ApplicationKind Kind { get; set; }

        /// <summary>
        /// Gets or sets the plan object.
        /// </summary>
        [Alias("PlanObject")]
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents managed application plan properties.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Plan { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.ShouldProcess(this.Name, "Create Managed Application"))
            {
                string resourceId = GetResourceId();

                var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.ApplicationApiVersion : this.ApiVersion;

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
        /// Constructs the resource
        /// </summary>
        private JToken GetResource()
        {
            var applicationObject = new Application
            {
                Name = this.Name,
                Location = this.Location,
                Plan = this.Plan.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourcePlan>(),
                Kind = this.Kind,
                Properties = new ApplicationProperties
                {
                    ManagedResourceGroupId = string.Format("/subscriptions/{0}/resourcegroups/{1}", Guid.Parse(DefaultContext.Subscription.Id), this.ManagedResourceGroupName),
                    ApplicationDefinitionId =this.ManagedApplicationDefinitionId ?? null,
                    Parameters = this.Parameter == null ? null : JObject.Parse(this.GetObjectFromParameter(this.Parameter).ToString())
                },
                Tags = TagsHelper.GetTagsDictionary(this.Tag)
            };

            return applicationObject.ToJToken();
        }
    }
}
