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
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Insights.Utils;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InsightsPrivateLinkScope", DefaultParameterSetName = ByResourceGroupParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMonitorPrivateLinkScope))]
    public class UpdateAzureInsightsPrivateLinkScope : AzureInsightsPrivateLinkScopeCreateOrUpdateCmdletBase
    {

        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";
        const string ByInputObjectParameterSet = "ByInputObjectParameterSet";

        #region Cmdlet parameters

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
            base.ProcessRecordInternal();

            if (this.IsParameterBound(c => c.InputObject) || this.IsParameterBound(c => c.ResourceId))
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    this.ResourceId = this.InputObject.Id;
                }
                ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.Name = identifier.ResourceName;
            }

            if (ShouldProcess(this.Name, string.Format("update scope: {0} under resource group: {1}", this.Name, this.ResourceGroupName)))
            {
                var response = this.MonitorManagementClient
                                   .PrivateLinkScopes
                                   .UpdateTagsWithHttpMessagesAsync(this.ResourceGroupName, this.Name, this.Tags.ToDictionary(s => s.Split(':')[0], s => s.Split(':')[1]))
                                   .Result;
                WriteObject(PSMapper.Instance.Map<PSMonitorPrivateLinkScope>(response.Body));
            }
        }
    }
}
