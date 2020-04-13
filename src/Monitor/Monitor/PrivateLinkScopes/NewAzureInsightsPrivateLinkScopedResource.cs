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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Insights.Utils;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InsightsPrivateLinkScopedResource", DefaultParameterSetName = ByResourceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMonitorPrivateLinkScopedResource))]
    public class NewAzureInsightsPrivateLinkScopedResource : AzureInsightsPrivateLinkScopedResourceCreateOrUpdateCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "LA/AI Resource Id to Link")]
        [ValidateNotNullOrEmpty]
        public string LinkedResourceId { get; set; }

        protected override void ProcessRecordInternal()
        {
            base.ProcessRecordInternal();

            ScopedResource existingScopedResource = null;


            try
            {
                existingScopedResource = getExistingScopedResource(this.ResourceGroupName, this.ScopeName, this.Name);
            }
            catch
            {
                existingScopedResource = null;
            }

            if (existingScopedResource != null)
            {
                throw new PSInvalidOperationException(string.Format("A scoped resource with name: '{0}' in scope: {1}, resource group: '{2}' already exists. Please use Update-AzInsightsPrivateLinkScopeScopedResource to update an existing scoped resource.", this.Name, this.ScopeName, this.ResourceGroupName));
            }

            if (ShouldProcess(this.Name, string.Format("create scoped resource: {0} from scope: {1} under resource group: {2}", this.Name, this.ScopeName, this.ResourceGroupName)))
            {
                var response = this.MonitorManagementClient
                                       .PrivateLinkScopedResources
                                       .CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ScopeName, this.Name, this.LinkedResourceId)
                                       .Result;
                WriteObject(PSMapper.Instance.Map<PSMonitorPrivateLinkScopedResource>(response.Body));
            }
        }


    }
}
