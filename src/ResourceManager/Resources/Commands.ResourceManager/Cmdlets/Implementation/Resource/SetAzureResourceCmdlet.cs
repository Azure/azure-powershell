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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;
    using SdkExtensions;
    using SdkModels;
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// A cmdlet that creates a new azure resource.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Resource", SupportsShouldProcess = true, DefaultParameterSetName = ResourceManipulationCmdletBase.ResourceIdParameterSet), OutputType(typeof(PSObject))]
    public sealed class SetAzureResourceCmdlet : ResourceManipulationCmdletBase
    {
        /// <summary>
        /// The object representation of the resource to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "ByInputObject", ValueFromPipeline = true, HelpMessage = "The object representation of the resource to update.")]
        [ValidateNotNull]
        public PSResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource kind.")]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the property object.
        /// </summary>
        [Alias("PropertyObject")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource properties.")]
        public PSObject Properties { get; set; }

        /// <summary>
        /// Gets or sets the plan object.
        /// </summary>
        [Alias("PlanObject")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource plan properties.")]
        public Hashtable Plan { get; set; }

        /// <summary>
        /// Gets or sets the Sku object.
        /// </summary>
        [Alias("SkuObject")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents sku properties.")]
        public Hashtable Sku { get; set; }


        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if an HTTP PATCH request needs to be made instead of PUT.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When set indicates if an HTTP PATCH should be used to update the object instead of PUT.")]
        public SwitchParameter UsePatchSemantics { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            if (this.IsParameterBound(c => c.InputObject))
            {
                ResourceId = InputObject.ResourceId;
                Kind = this.IsParameterBound(c => c.Kind) ? Kind : InputObject.Kind;
                Properties = this.IsParameterBound(c => c.Properties) ? Properties : InputObject.Properties;
                Plan = this.IsParameterBound(c => c.Plan) ? Plan : InputObject.Plan.ToHashtable();
                Sku = this.IsParameterBound(c => c.Sku) ? Sku : InputObject.Sku.ToHashtable();
                Tag = this.IsParameterBound(c => c.Tag) ? Tag : InputObject.Tags.ToHashtable();
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

                    this.TryConvertToResourceAndWriteObject(result);
                });
        }

        /// <summary>
        /// Gets the resource body.
        /// </summary>
        private JToken GetResourceBody()
        {
            if (this.ShouldUsePatchSemantics())
            {
                var resourceBody = this.GetPatchResourceBody();

                return resourceBody == null ? null : resourceBody.ToJToken();
            }
            else
            {
                var getResult = this.GetResource().Result;

                if (getResult.CanConvertTo<Resource<JToken>>())
                {
                    var resource = getResult.ToResource();
                    return new Resource<JToken>()
                    {
                        Kind = this.Kind ?? resource.Kind,
                        Plan = this.Plan.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourcePlan>() ?? resource.Plan,
                        Sku = this.Sku.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourceSku>() ?? resource.Sku,
                        Tags = TagsHelper.GetTagsDictionary(this.Tag) ?? resource.Tags,
                        Location = resource.Location,
                        Properties = this.Properties == null ? resource.Properties : this.Properties.ToResourcePropertiesBody()
                    }.ToJToken();
                }
                else
                {
                    return this.Properties.ToJToken();
                }
            }

        }

        /// <summary>
        /// Gets the resource body for PATCH calls
        /// </summary>
        private Resource<JToken> GetPatchResourceBody()
        {
            if (this.Properties == null && this.Plan == null && this.Kind == null && this.Sku == null && this.Tag == null)
            {
                return null;
            }

            Resource<JToken> resourceBody = new Resource<JToken>();

            if (this.Properties != null)
            {
                resourceBody.Properties = this.Properties.ToResourcePropertiesBody();
            }

            if (this.Plan != null)
            {
                resourceBody.Plan = this.Plan.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourcePlan>();
            }

            if (this.Kind != null)
            {
                resourceBody.Kind = this.Kind;
            }

            if (this.Sku != null)
            {
                resourceBody.Sku = this.Sku.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourceSku>();
            }

            if (this.Tag != null)
            {
                resourceBody.Tags = TagsHelper.GetTagsDictionary(this.Tag);
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
