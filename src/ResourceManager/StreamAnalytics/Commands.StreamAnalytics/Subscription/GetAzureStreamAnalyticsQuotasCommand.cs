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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.StreamAnalytics.Models;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [Cmdlet(VerbsCommon.Get, Constants.StreamAnalyticsQuota), OutputType(typeof(List<PSQuota>), typeof(PSQuota))]
    public class GetAzureStreamAnalyticsQuotasCommand : StreamAnalyticsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location of the azure stream analytics quota.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("East US", "East US 2", "North Central US", "North Europe", "West Europe", "Brazil South", "West US", "Central US", "South Central US",
            "Japan East", "Japan West", "East Asia", "Southeast Asia", IgnoreCase = true)]
        public string Location { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (Location != null && string.IsNullOrWhiteSpace(Location))
            {
                throw new PSArgumentNullException("Location");
            }

            List<PSQuota> quotas = StreamAnalyticsClient.GetQuotas(Location);

            if (quotas != null)
            {
                if (quotas.Count == 1 && Location != null)
                {
                    WriteObject(quotas[0]);
                }
                else
                {
                    WriteObject(quotas, true);
                }
            }
        }
    }
}