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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Insights.Utils;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    /// <summary>
    /// Get or List private link scope(s)
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InsightsPrivateLinkScope", DefaultParameterSetName = ByResourceGroupParameterSet), OutputType(typeof(PSMonitorPrivateLinkScope))]
    public class GetAzureInsightsPrivateLinkScope : ManagementCmdletBase
    {
        const string ByResourceGroupParameterSet = "ByResourceGroupParameterSet";
        const string ByResourceNameParameterSet = "ByResourceNameParameterSet";
        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";

        #region Cmdlet parameters

        [Parameter(
            ParameterSetName = ByResourceGroupParameterSet,
            Mandatory = false,
            HelpMessage = "Resource Group Name")]
        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Private Link Scope Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (ParameterSetName.Equals(ByResourceGroupParameterSet))
            {
                if (this.IsParameterBound(c => c.ResourceGroupName))
                {                    
                    var response = this.MonitorManagementClient
                                       .PrivateLinkScopes
                                       .ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName)
                                       .Result;
                    WriteObject(response.Body.Select(scope => PSMapper.Instance.Map<PSMonitorPrivateLinkScope>(scope)).ToList(), true);
                }
                else
                {
                    var response = this.MonitorManagementClient
                                       .PrivateLinkScopes.ListWithHttpMessagesAsync()
                                       .Result;
                    WriteObject(response.Body.Select(scope => PSMapper.Instance.Map<PSMonitorPrivateLinkScope>(scope)).ToList(), true);
                }
            }
            else if (ParameterSetName.Equals(ByResourceNameParameterSet) || ParameterSetName.Equals(ResourceId))
            {
                if (this.IsParameterBound(c => c.ResourceId))
                {
                    ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = identifier.ResourceGroupName;
                    this.Name = identifier.ResourceName;
                }

                var response = this.MonitorManagementClient
                                       .PrivateLinkScopes
                                       .GetWithHttpMessagesAsync(this.ResourceGroupName, this.Name)
                                       .Result;
                WriteObject(PSMapper.Instance.Map<PSMonitorPrivateLinkScope>(response.Body));
            }
        }
    }
}
