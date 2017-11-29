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
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using WindowsAzure.Commands.Common;

    /// <summary>
    /// Creates the managed application definition.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmManagedApplicationDefinition", DefaultParameterSetName = SetAzureManagedApplicationDefinitionCmdlet.ManagedApplicationDefinitionNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public class SetAzureManagedApplicationDefinitionCmdlet : ManagedApplicationCmdletBase
    {
        /// <summary>
        /// The managed application Id parameter set.
        /// </summary>
        internal const string ManagedApplicationDefinitionIdParameterSet = "SetById";

        /// <summary>
        /// The managed application name parameter set.
        /// </summary>
        internal const string ManagedApplicationDefinitionNameParameterSet = "SetByNameAndResourceGroup";

        /// <summary>
        /// Gets or sets the managed application definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = SetAzureManagedApplicationDefinitionCmdlet.ManagedApplicationDefinitionNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition resource group parameter
        /// </summary>
        [Parameter(ParameterSetName = SetAzureManagedApplicationDefinitionCmdlet.ManagedApplicationDefinitionNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = SetAzureManagedApplicationDefinitionCmdlet.ManagedApplicationDefinitionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified managed application definition Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition display name parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition display name.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition description parameter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition description.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition package file uri.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition package file uri.")]
        [ValidateNotNullOrEmpty]
        public string PackageFileUri { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition authorization.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition authorization. Comma separated authorization pairs in a format of <principalId>:<roleDefinitionId>")]
        [ValidateNotNullOrEmpty]
        public string[] Authorization { get; set; }

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
            if (this.ShouldProcess(this.Name, "Update Managed Application Definition"))
            {
                string resourceId = this.Id ?? GetResourceId();

                var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.ApplicationApiVersion : this.ApiVersion;

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
                this.WriteObject(this.GetOutputObjects("ManagedApplicationDefinitionId", JObject.Parse(result)), enumerateCollection: true);
            }
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            var subscriptionId = DefaultContext.Subscription.Id;
            return string.Format("/subscriptions/{0}/providers/{1}/{2}",
                subscriptionId.ToString(),
                Constants.MicrosoftApplicationDefinitionType,
                this.Name);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            var applicationDefinitionObject = new ApplicationDefinition
            {
                Name = this.Name,
                Location = resource.Location,
                Properties = new ApplicationDefinitionProperties
                {
                    LockLevel = (ApplicationLockLevel) Enum.Parse(typeof(ApplicationLockLevel), resource.Properties["lockLevel"].ToString(), true),
                    Description = this.Description ?? (resource.Properties["description"] != null
                        ? resource.Properties["description"].ToString()
                        : null),
                    DisplayName = this.DisplayName ?? (resource.Properties["displayName"] != null
                        ? resource.Properties["displayName"].ToString()
                        : null),
                    PackageFileUri = this.PackageFileUri ?? null,
                    Authorizations = this.Authorization != null
                        ? JArray.Parse(this.GetAuthorizationObject(this.Authorization).ToString()).ToJson().FromJson<ApplicationProviderAuthorization[]>()
                        : JArray.Parse(resource.Properties["authorizations"].ToString()).ToJson().FromJson<ApplicationProviderAuthorization[]>()
                },
                Tags = TagsHelper.GetTagsDictionary(this.Tag) ?? resource.Tags
            };

            return applicationDefinitionObject.ToJToken();
        }
    }
}
