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

using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    public class AzureInsightsPrivateLinkScopedResourceCreateOrUpdateCmdletBase : ManagementCmdletBase
    {
        internal const string ByResourceNameParameterSet = "ByResourceNameParameterSet";
        internal const string ByInputObjectParameterSet = "ByInputObjectParameterSet";

        #region Cmdlet parameters

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Private Link Scope Name")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Insights/privateLinkScopes", nameof(ResourceGroupName))]
        public string ScopeName { get; set; }

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Scoped resource Name")]
        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "Scoped resource Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "PSMonitorPrivateLinkScope")]
        [ValidateNotNullOrEmpty]
        public PSMonitorPrivateLinkScope InputObject { get; set; }
   
        #endregion

        protected override void ProcessRecordInternal()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.ScopeName = identifier.ResourceName;
            }
        }

        internal ScopedResource getExistingScopedResource(string resourceGroupName, string scopeName, string name)
        {
            return this.MonitorManagementClient
                       .PrivateLinkScopedResources
                       .GetWithHttpMessagesAsync(resourceGroupName, scopeName, name)
                       .Result
                       .Body;
        }
    }
}
