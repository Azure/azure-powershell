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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using System.Collections;
    using System.Management.Automation;

    /// <summary>
    /// Creates the managed application definition.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmManagedApplicationDefinition", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public class NewAzureManagedApplicationDefinitionCmdlet : ManagedApplicationCmdletBase
    {
        /// <summary>
        /// Gets or sets the managed application definition name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition resource group parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition display name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition display name.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition description parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition description.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource location.")]
        [LocationCompleter("Microsoft.Solutions/applicationDefinitions")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the lock level.
        /// </summary>
        [Alias("Level")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The level of the lock for managed application definition.")]
        [ValidateNotNullOrEmpty]
        public ApplicationLockLevel LockLevel { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition package file uri.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition package file uri.")]
        [ValidateNotNullOrEmpty]
        public string PackageFileUri { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition create ui definition file path or create ui definition as string.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition create ui definition.")]
        [ValidateNotNullOrEmpty]
        public string CreateUiDefinition { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition main template file path or main template as string.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition main template.")]
        [ValidateNotNullOrEmpty]
        public string MainTemplate { get; set; }

        /// <summary>
        /// Gets or sets the managed application definition authorization.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application definition authorization. Comma separated authorization pairs in a format of <principalId>:<roleDefinitionId>")]
        [ValidateNotNullOrEmpty]
        public string[] Authorization { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.ShouldProcess(this.Name, "Create Managed Application Definition"))
            {
                if (!string.IsNullOrEmpty(this.PackageFileUri))
                {
                    if (!string.IsNullOrEmpty(this.MainTemplate) || !string.IsNullOrEmpty(this.CreateUiDefinition))
                    {
                        throw new PSInvalidOperationException("If PackageFileUri is specified, MainTemplate and CreateUiDefinition cannot have a value.");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(this.MainTemplate) || string.IsNullOrEmpty(this.CreateUiDefinition))
                    {
                        throw new PSInvalidOperationException("If PackageFileUri is not specified, both MainTemplate and CreateUiDefinition should have a valid value.");
                    }
                }
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
                this.WriteObject(this.GetOutputObjects("ManagedApplicationDefinitionId", JObject.Parse(result)), enumerateCollection: true);
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
                Constants.MicrosoftApplicationDefinitionType,
                this.Name);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource()
        {
            var applicationDefinitionObject = new ApplicationDefinition
            {
                Name = this.Name,
                Location = this.Location,
                Properties = new ApplicationDefinitionProperties
                {
                    LockLevel = this.LockLevel,
                    Description = this.Description,
                    DisplayName = this.DisplayName,
                    PackageFileUri = this.PackageFileUri ?? null,
                    Authorizations = JArray.Parse(this.GetAuthorizationObject(this.Authorization).ToString()).ToJson().FromJson<ApplicationProviderAuthorization[]>()
                },
                Tags = TagsHelper.GetTagsDictionary(this.Tag)
            };

            if (!string.IsNullOrEmpty(this.MainTemplate) && !string.IsNullOrEmpty(this.CreateUiDefinition))
            {
                applicationDefinitionObject.Properties.MainTemplate = JObject.Parse(this.GetObjectFromParameter(this.MainTemplate).ToString());
                applicationDefinitionObject.Properties.CreateUiDefinition = JObject.Parse(this.GetObjectFromParameter(this.CreateUiDefinition).ToString());
            }

            return applicationDefinitionObject.ToJToken();
        }
    }
}
