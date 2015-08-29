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
    /// Cmdlet to check if a resource exists or not
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "AzureResource", DefaultParameterSetName = TestAzureResoruceCmdlet.GetTenantResourceParameterSet), OutputType(typeof(bool))]
    public sealed class TestAzureResoruceCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The get resource parameter set.
        /// </summary>
        internal const string GetResourceGroupResourceParameterSet = "Tests for the existance of a single resource in a resource group.";

        /// <summary>
        /// The get tenant resource parameter set.
        /// </summary>
        internal const string GetTenantResourceParameterSet = "Tests for the existance of a single resource at the tenant level.";

        /// <summary>
        /// The get tenant resource parameter set.
        /// </summary>
        internal const string GetResourceByIdParameterSet = "Tests for the existance of a single resource by its Id.";

        /// <summary>
        /// The get tenant resource parameter set.
        /// </summary>
        internal const string GetSubscriptionResourcesParameterSet = "Tests for the existance of a single resource at the subscription level.";

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Alias("Id")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetResourceByIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource's Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Alias("Name")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetTenantResourceParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name. e.g. to specify a database MyServer/MyDatabase.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetResourceGroupResourceParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name. e.g. to specify a database MyServer/MyDatabase.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetSubscriptionResourcesParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name. e.g. to specify a database MyServer/MyDatabase.")]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the resource type parameter.
        /// </summary>
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetResourceGroupResourceParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetTenantResourceParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetSubscriptionResourcesParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the extension resource name parameter.
        /// </summary>
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetResourceGroupResourceParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource name. e.g. to specify a database MyServer/MyDatabase.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetTenantResourceParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource name. e.g. to specify a database MyServer/MyDatabase.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetSubscriptionResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionResourceName { get; set; }

        /// <summary>
        /// Gets or sets the extension resource type.
        /// </summary>
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetResourceGroupResourceParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetTenantResourceParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetSubscriptionResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionResourceType { get; set; }
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
        /// Gets or sets the tenant level parameter.
        /// </summary>
        [Parameter(ParameterSetName = TestAzureResoruceCmdlet.GetTenantResourceParameterSet, Mandatory = true, HelpMessage = "Indicates that this is a tenant level operation.")]
        public SwitchParameter TenantLevel { get; set; }

        /// <summary>
        /// Collects subscription ids from the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (!this.TenantLevel)
            {
                this.SubscriptionId = this.Profile.Context.Subscription.Id;
            }

            this.RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            this.WriteWarning("The Test-AzureResource cmdlet is being deprecated and will be removed in a future release.");
            this.WriteObject(this.TestResource());
        }

        /// <summary>
        /// Tests if a resource exists or not.
        /// </summary>
        private bool TestResource()
        {
            var resourceId = this.GetResourceId();

            var apiVersion = this.DetermineApiVersion(resourceId: resourceId).Result;

            try
            {
                this.GetResourcesClient().GetResource<JObject>(resourceId: resourceId, apiVersion: apiVersion, cancellationToken: this.CancellationToken.Value).Wait();
                return true;
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null && ex.InnerException is ErrorResponseMessageException)
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
        private string GetResourceId()
        {
            return !string.IsNullOrWhiteSpace(this.ResourceId)
            ? this.ResourceId
            : ResourceIdUtility.GetResourceId(
                subscriptionId: this.SubscriptionId,
                resourceGroupName: this.ResourceGroupName,
                resourceType: this.ResourceType,
                resourceName: this.ResourceName,
                extensionResourceType: this.ExtensionResourceType,
                extensionResourceName: this.ExtensionResourceName);
        }
    }
}