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
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A cmdlet that creates a new azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmResource", SupportsShouldProcess = true, DefaultParameterSetName = ResourceManipulationCmdletBase.ResourceIdParameterSet), OutputType(typeof(PSObject))]
    public sealed class SetAzureResourceCmdlet : ResourceManipulationCmdletBase
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource kind.")]
        [ValidateNotNullOrEmpty]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the property object.
        /// </summary>
        [Alias("PropertyObject")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource properties.")]
        [ValidateNotNullOrEmpty]
        public PSObject Properties { get; set; }

        /// <summary>
        /// Gets or sets the plan object.
        /// </summary>
        [Alias("PlanObject")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource plan properties.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Plan { get; set; }

        /// <summary>  
        /// Gets or sets the plan object.  
        /// </summary>  
        [Alias("SkuObject")]  
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents sku properties.")]  
        [ValidateNotNullOrEmpty]  
        public Hashtable Sku { get; set; }  


        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if an HTTP PATCH request needs to be made instead of PUT.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When set indicates if an HTTP PATCH should be used to update the object instead of PUT.")]
        public SwitchParameter UsePatchSemantics { get; set; }

        /// <summary>
        /// Gets or sets the resource property object format.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The output format of the resource properties.")]
        [ValidateNotNull]
        public ResourceObjectFormat? OutputObjectFormat { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            this.DetermineOutputObjectFormat();
            if (this.OutputObjectFormat == ResourceObjectFormat.Legacy)
            {
                this.WriteWarning("This cmdlet is using the legacy properties object format. This format is being deprecated. Please use '-OutputObjectFormat New' and update your scripts.");
            }

            if(!string.IsNullOrEmpty(this.ODataQuery))
            {
                this.WriteWarning("The ODataQuery parameter is being deprecated in Set-AzureRmResource cmdlet and will be removed in a future release.");
            }

            var resourceId = this.GetResourceId();
            this.ConfirmAction(
                this.Force,
                "Are you sure you want to update the following resource: " + resourceId,
                "Updating the resource...",
                resourceId,
                () =>
                {
                    var apiVersion = this.DetermineApiVersion(resourceId: resourceId).Result;
                    var resourceBody = this.GetResourceBody();

                    var operationResult = this.ShouldUsePatchSemantics()
                        ? this.GetResourcesClient()
                            .PatchResource(
                                resourceId: resourceId,
                                apiVersion: apiVersion,
                                resource: resourceBody,
                                cancellationToken: this.CancellationToken.Value,
                                odataQuery: this.ODataQuery)
                            .Result
                        : this.GetResourcesClient()
                            .PutResource(
                                resourceId: resourceId,
                                apiVersion: apiVersion,
                                resource: resourceBody,
                                cancellationToken: this.CancellationToken.Value,
                                odataQuery: this.ODataQuery)
                            .Result;

                    var managementUri = this.GetResourcesClient()
                        .GetResourceManagementRequestUri(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            odataQuery: this.ODataQuery);

                    var activity = string.Format("{0} {1}", this.ShouldUsePatchSemantics() ? "PATCH" : "PUT", managementUri.PathAndQuery);
                    var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: true)
                        .WaitOnOperation(operationResult: operationResult);

                    this.TryConvertToResourceAndWriteObject(result, this.OutputObjectFormat.Value);
                });
        }

        /// <summary>
        /// Determines the output object format.
        /// </summary>
        private void DetermineOutputObjectFormat()
        {
            if (this.Properties != null && this.OutputObjectFormat == null && this.Properties.TypeNames.Any(typeName => typeName.EqualsInsensitively(Constants.MicrosoftAzureResource)))
            {
                this.OutputObjectFormat = ResourceObjectFormat.New;
            }

            if (this.OutputObjectFormat == null)
            {
                this.OutputObjectFormat = ResourceObjectFormat.Legacy;
            }
        }

        /// <summary>
        /// Gets the resource body.
        /// </summary>
        private JToken GetResourceBody()
        {
            var getResult = this.GetResource().Result;

            JToken resourceBody;
            if (getResult.CanConvertTo<Resource<JToken>>())
            {
                if (this.ShouldUsePatchSemantics())
                {
                    resourceBody = new Resource<JToken>()
                    {
                        Kind = this.Kind,
                        Plan = this.Plan.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourcePlan>(),
                        Sku = this.Sku.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourceSku>(),
                        Tags = TagsHelper.GetTagsDictionary(this.Tag),
                        Properties = this.Properties.ToResourcePropertiesBody(),
                    }.ToJToken();
                }
                else
                {
                    var resource = getResult.ToResource();
                    resourceBody = new Resource<JToken>()
                    {
                        Kind = this.Kind ?? resource.Kind,
                        Plan = this.Plan.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourcePlan>() ?? resource.Plan,
                        Sku = this.Sku.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourceSku>() ?? resource.Sku,
                        Tags = TagsHelper.GetTagsDictionary(this.Tag) ?? resource.Tags,
                        Location = resource.Location,
                        Properties = this.Properties == null ? resource.Properties : this.Properties.ToResourcePropertiesBody(),
                    }.ToJToken();
                }
            }
            else
            {
                resourceBody = this.Properties.ToJToken();
            }
            return resourceBody;
        }

        /// <summary>
        /// Determines if the cmdlet should use <c>PATCH</c> semantics.
        /// </summary>
        private bool ShouldUsePatchSemantics()
        {
            return this.UsePatchSemantics || ((this.Tag != null || this.Sku != null) && this.Plan == null && this.Properties == null && this.Kind == null);
        }

        /// <summary>
        /// Gets a resource.
        /// </summary>
        private async Task<JObject> GetResource()
        {
            var resourceId = this.GetResourceId();
            var apiVersion = await this
                .DetermineApiVersion(resourceId: resourceId)
                .ConfigureAwait(continueOnCapturedContext: false);

            return await this
                .GetResourcesClient()
                .GetResource<JObject>(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}