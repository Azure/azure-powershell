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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A cmdlet that creates a new azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmResource", SupportsShouldProcess = true, DefaultParameterSetName = ResourceManipulationCmdletBase.ResourceIdParameterSet), OutputType(typeof(PSObject))]
    public sealed class NewAzureResourceCmdlet : ResourceManipulationCmdletBase
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The resource location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The resource kind.")]
        [ValidateNotNullOrEmpty]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the property object.
        /// </summary>
        [Alias("PropertyObject")]
        [Parameter(Mandatory = true, HelpMessage = "A hash table which represents resource properties.")]
        [ValidateNotNullOrEmpty]
        public PSObject Properties { get; set; }

        /// <summary>
        /// Gets or sets the plan object.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource plan properties.")]
        [ValidateNotNullOrEmpty]
        public Hashtable PlanObject { get; set; }

        /// <summary>  
        /// Gets or sets the plan object.  
        /// </summary>  
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents sku properties.")]  
        [ValidateNotNullOrEmpty]  
        public Hashtable SkuObject { get; set; }  


        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Alias("Tags")]
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the full object was passed it.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When set indicates that the full object is passed in to the -PropertyObject parameter.")]
        public SwitchParameter IsFullObject { get; set; }

        /// <summary>
        /// Gets or sets the resource property object format.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The output format of the resource properties.")]
        [ValidateNotNull]
        public ResourceObjectFormat? OutputObjectFormat { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewAzureResourceCmdlet" /> class.
        /// </summary>
        public NewAzureResourceCmdlet()
        {
            this.OutputObjectFormat = ResourceObjectFormat.Legacy;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            this.DetermineOutputObjectFormat();
            if(this.IsFullObject.IsPresent)
            {
                this.WriteWarning("The IsFullObject parameter is obsolete and will be removed in future releases.");
            }
            if (this.OutputObjectFormat == ResourceObjectFormat.Legacy)
            {
                this.WriteWarning("This cmdlet is using the legacy properties object format. This format is being deprecated. Please use '-OutputObjectFormat New' and update your scripts.");
            }

            var resourceId = this.GetResourceId();
            this.ConfirmAction(
                this.Force,
                "Are you sure you want to create the following resource: "+ resourceId,
                "Creating the resource...",
                resourceId,
                () =>
                {
                    var apiVersion = this.DetermineApiVersion(resourceId: resourceId).Result;
                    var resourceBody = this.GetResourceBody();

                    var operationResult = this.GetResourcesClient()
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

                    var activity = string.Format("PUT {0}", managementUri.PathAndQuery);
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
        /// Gets the resource body from the parameters.
        /// </summary>
        private JToken GetResourceBody()
        {
            return this.IsFullObject
                ? this.Properties.ToResourcePropertiesBody().ToJToken()
                : this.GetResource().ToJToken();
        }

        /// <summary>
        /// Constructs the resource assuming that only the properties were passed in.
        /// </summary>
        private Resource<JToken> GetResource()
        {
            return new Resource<JToken>()
            {
                Location = this.Location,
                Kind = this.Kind,
                Plan = this.PlanObject.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourcePlan>(),
                Sku = this.SkuObject.ToDictionary(addValueLayer: false).ToJson().FromJson<ResourceSku>(),
                Tags = TagsHelper.GetTagsDictionary(this.Tag),
                Properties = this.Properties.ToResourcePropertiesBody(),
            };
        }


    }
}