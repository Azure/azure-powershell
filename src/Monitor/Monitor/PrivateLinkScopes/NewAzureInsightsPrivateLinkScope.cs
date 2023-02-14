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
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Azure.Commands.Insights.Utils;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InsightsPrivateLinkScope", DefaultParameterSetName = ByResourceGroupParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMonitorPrivateLinkScope))]
    public class NewAzureInsightsPrivateLinkScope : AzureInsightsPrivateLinkScopeCreateOrUpdateCmdletBase
    {
        #region Cmdlet parameters

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            base.ProcessRecordInternal();

            AzureMonitorPrivateLinkScope existingScope = null ;
            try
            {
                existingScope = this.getExistingScope(this.ResourceGroupName, this.Name);
            }
            catch
            {
                existingScope = null;
            }

            if (existingScope != null)
            {
                throw new PSInvalidOperationException(string.Format("A Private Link Scope with name: '{0}' in resource group: '{1}' already exists. Please use Update-AzInsightsPrivateLinkScope to update an existing scope.", this.Name, this.ResourceGroupName));
            }

            AzureMonitorPrivateLinkScope payLoad = new AzureMonitorPrivateLinkScope(this.Location);

            if (this.IsParameterBound(c => c.Tags))
            {
                payLoad.Tags = this.Tags.ToDictionary(s => s.Split(':')[0], s => s.Split(':')[1]);
            }

            if (ShouldProcess(this.Name, string.Format("create scope: {0} under resource group: {1}", this.Name, this.ResourceGroupName)))
            {
                var response = this.MonitorManagementClient
                                   .PrivateLinkScopes
                                   .CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, payLoad)
                                   .Result;
                WriteObject(PSMapper.Instance.Map<PSMonitorPrivateLinkScope>(response.Body));
            }
        }
    }
}
