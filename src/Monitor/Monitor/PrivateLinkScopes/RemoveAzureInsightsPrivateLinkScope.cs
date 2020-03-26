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

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    /// <summary>
    /// Get or List private link scope(s)
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InsightsPrivateLinkScope", DefaultParameterSetName = ByResourceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureInsightsPrivateLinkScope : ManagementCmdletBase
    {
        const string ByResourceNameParameterSet = "ByResourceNameParameterSet";
        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";
        const string ByInputObjectParameterSet = "ByInputObjectParameterSet";

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
            ValueFromPipeline = true,
            HelpMessage = "PSMonitorPrivateLinkScope")]
        [ValidateNotNullOrEmpty]
        public PSMonitorPrivateLinkScope InputObject { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (this.IsParameterBound(c => c.ResourceId) || this.IsParameterBound(c => c.InputObject))
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    this.ResourceId = InputObject.Id;
                }

                ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.Name = identifier.ResourceName;
            }
            
            if (ShouldProcess(this.Name, string.Format("delete scope: {0} from resource group: {1}", this.Name, this.ResourceGroupName)))
            {
                var response = this.MonitorManagementClient
                                   .PrivateLinkScopes
                                   .DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.Name)
                                   .Result;
                WriteObject(true);
            }
        }
    }
}
