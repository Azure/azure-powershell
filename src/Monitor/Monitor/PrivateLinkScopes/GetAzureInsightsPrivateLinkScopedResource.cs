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
using Microsoft.Azure.Commands.Insights.Utils;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InsightsPrivateLinkScopedResource", DefaultParameterSetName = ByScopeParameterSet), OutputType(typeof(PSMonitorPrivateLinkScopedResource))]
    public class GetAzureInsightsPrivateLinkScopedResource : ManagementCmdletBase
    {
        const string ByScopeParameterSet = "ByScopeParameterSet";
        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";
        const string ByInputObjectParameterSet = "ByInputObjectParameterSet";

        #region Cmdlet parameters

        [Parameter(
            ParameterSetName = ByScopeParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Group Name")]        
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByScopeParameterSet,
            Mandatory = true,
            HelpMessage = "Private Link Scope Name")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Insights/privateLinkScopes", nameof(ResourceGroupName))]
        public string ScopeName { get; set; }

        [Parameter(
            ParameterSetName = ByScopeParameterSet,
            Mandatory = false,
            HelpMessage = "Scoped resource Name")]
        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            Mandatory = false,
            HelpMessage = "Scoped resource Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "PSMonitorPrivateLinkScope")]
        [ValidateNotNullOrEmpty]
        public PSMonitorPrivateLinkScope InputObject { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            ResourceIdentifier identifier;

            if (this.IsParameterBound(c => c.InputObject))
            {
                identifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.ScopeName = identifier.ResourceName;
            }
            else if (this.IsParameterBound(c => c.ResourceId))
            {
                identifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.ScopeName = identifier.ParentResource;
                this.Name = identifier.ResourceName;
            }

            if (!this.IsParameterBound(c => c.Name))
            {
                var response = this.MonitorManagementClient
                                       .PrivateLinkScopedResources
                                       .ListByPrivateLinkScopeWithHttpMessagesAsync(this.ResourceGroupName, this.ScopeName)
                                       .Result;
                WriteObject(response.Body.Select(scope => PSMapper.Instance.Map<PSMonitorPrivateLinkScopedResource>(scope)).ToList(), true);
            }
            else if (this.IsParameterBound(c => c.Name))
            {
                var response = this.MonitorManagementClient
                                       .PrivateLinkScopedResources
                                       .GetWithHttpMessagesAsync(this.ResourceGroupName, this.ScopeName, this.Name)
                                       .Result;
                WriteObject(PSMapper.Instance.Map<PSMonitorPrivateLinkScopedResource>(response.Body));
            }
        }
    }
}
