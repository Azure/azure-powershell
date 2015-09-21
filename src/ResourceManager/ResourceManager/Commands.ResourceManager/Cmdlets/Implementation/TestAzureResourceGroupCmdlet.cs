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
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Cmdlet to check if a resource group exists or not
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "AzureResourceGroup"), OutputType(typeof(bool))]
    public sealed class TestAzureResoruceGroupCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets or sets the subscription ids.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = TestAzureResoruceCmdlet.GetResourceGroupResourceParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription to use.")]
        [Parameter(Mandatory = false, ParameterSetName = TestAzureResoruceCmdlet.GetSubscriptionResourcesParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription to use.")]
        [ValidateNotNullOrEmpty]
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = TestAzureResoruceCmdlet.GetResourceGroupResourceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Collects subscription ids from the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            this.SubscriptionId = this.Profile.Context.Subscription.Id;
            this.RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            this.WriteWarning("The Test-AzureResourceGroup cmdlet is being deprecated and will be removed in a future release.");
            this.WriteObject(this.TestResourceGroup());
        }

        /// <summary>
        /// Tests if a resource group exists or not.
        /// </summary>
        private bool TestResourceGroup()
        {
            var resourceGroupId = this.GetResourceGroupId();
            var apiVersion = this.DetermineApiVersion(resourceId: resourceGroupId).Result;
            try
            {
                this.GetResourcesClient().GetResource<JObject>(resourceId: resourceGroupId, apiVersion: apiVersion, cancellationToken: this.CancellationToken.Value).Wait();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is ErrorResponseMessageException)
                {
                    var exception = ex.InnerException as ErrorResponseMessageException;
                    if (exception.HttpStatus.Equals(HttpStatusCode.NotFound))
                    {
                        return false;
                    }
                    else
                    {
                        throw ex.InnerException;
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceGroupId()
        {
            return ResourceIdUtility.GetResourceId(
                subscriptionId: this.SubscriptionId,
                resourceGroupName: this.ResourceGroupName,
                resourceType: null,
                resourceName: null); 
        }
    }
}