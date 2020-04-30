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
    public class AzureInsightsPrivateLinkScopeCreateOrUpdateCmdletBase : ManagementCmdletBase
    {
        internal const string ByResourceGroupParameterSet = "ByResourceNameParameterSet";

        #region Cmdlet parameters

        [Parameter(
            ParameterSetName = ByResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "Private Link Scope Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Tags")]
        [ValidateNotNullOrEmpty]
        public string[] Tags { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            this.validate();
        }

        private void validate()
        {
            if (this.IsParameterBound(c => c.Tags))
            {
                foreach (string tag in Tags)
                {
                    if (!tag.Contains(':'))
                    {
                        throw new PSArgumentException("invalid parameter: Tags");
                    }
                }
            }
        }

        internal AzureMonitorPrivateLinkScope getExistingScope(string resourceGroupName, string name)
        {
            return this.MonitorManagementClient
                       .PrivateLinkScopes
                       .GetWithHttpMessagesAsync(resourceGroupName, name)
                       .Result
                       .Body;
        }
    }
}
