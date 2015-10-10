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

namespace Commands.Intune
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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A cmdlet that creates a new azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntunePolicy", SupportsShouldProcess = true, DefaultParameterSetName = ResourceManipulationCmdletBase.ResourceIdParameterSet), OutputType(typeof(PSObject))]
    public sealed class SetIntunePolicyCmdlet : ResourceManipulationCmdletBase
    {
        /// <summary>
        /// Gets or sets the property object.
        /// </summary>
        [Alias("PropertyObject")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource properties.")]
        [ValidateNotNullOrEmpty]
        public PSObject Properties { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            var resourceId = this.GetResourceId();
            this.ConfirmAction(
                this.Force,
                "Are you sure you want to update the following resource: " + resourceId,
                "Updating the resource...",
                resourceId,
                () =>
                {
                    var apiVersion = "2015-01-08-alpha";
                    var resourceBody = this.GetResourceBody();

                    var operationResult =
                         this.GetResourcesClient()
                            .PatchResource(
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

                    var activity = string.Format("{0} {1}", "PATCH", managementUri.PathAndQuery);
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
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("friendlyName", "PolicyIsPatched");
            properties.Add("pinNumRetry", 9);

            Dictionary<string, object> entityObject = new Dictionary<string, object>();
            entityObject.Add("properties", properties);

            return entityObject.ToJToken();
        }

    }
}