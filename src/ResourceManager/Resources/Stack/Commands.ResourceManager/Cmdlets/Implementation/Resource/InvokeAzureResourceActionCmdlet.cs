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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
    using System.Collections;
    using System.Management.Automation;

    /// <summary>
    /// A cmdlet that invokes a resource action.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AzureRmResourceAction", SupportsShouldProcess = true, DefaultParameterSetName = ResourceManipulationCmdletBase.ResourceIdParameterSet), OutputType(typeof(PSObject))]
    public sealed class InvokAzureResourceActionCmdlet : ResourceManipulationCmdletBase
    {
        /// <summary>
        /// Gets or sets the property object.
        /// </summary>
        [Alias("Object")]
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource properties.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Parameters { get; set; }

        /// <summary>
        /// Gets or sets the property object.
        /// </summary>
        [Alias("ActionName")]
        [Parameter(Mandatory = true, HelpMessage = "The name of the action to invoke.")]
        [ValidateNotNullOrEmpty]
        public string Action { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            var resourceId = this.GetResourceId();

            this.ConfirmAction(
                this.Force,
                string.Format(ProjectResources.ConfirmInvokeAction, this.Action, resourceId),
                string.Format(ProjectResources.InvokingResourceAction, this.Action),
                resourceId,
                () =>
                {
                    var apiVersion = this.DetermineApiVersion(resourceId: resourceId).Result;
                    var parameters = this.GetParameters();

                    var operationResult = this.GetResourcesClient()
                        .InvokeActionOnResource<JObject>(
                            resourceId: resourceId,
                            action: this.Action,
                            apiVersion: apiVersion,
                            parameters: parameters,
                            cancellationToken: this.CancellationToken.Value,
                            odataQuery: this.ODataQuery)
                        .Result;

                    var managementUri = this.GetResourcesClient()
                        .GetResourceManagementRequestUri(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            action: this.Action,
                            odataQuery: this.ODataQuery);

                    var activity = string.Format("POST {0}", managementUri.PathAndQuery);
                    var resultString = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: false)
                        .WaitOnOperation(operationResult: operationResult);

                    this.TryConvertAndWriteObject(resultString);
                });
        }

        /// <summary>
        /// Gets the resource body from the parameters.
        /// </summary>
        private JToken GetParameters()
        {
            return this.Parameters.ToDictionary(addValueLayer: false).ToJToken();
        }
    }
}
