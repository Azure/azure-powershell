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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeAnalyticsAccount", DefaultParameterSetName = BaseParameterSetName),
     OutputType(typeof(List<PSDataLakeAnalyticsAccountBasic>), typeof(PSDataLakeAnalyticsAccount))]
    [Alias("Get-AdlAnalyticsAccount")]
    public class GetAzureDataLakeAnalyticsAccount : DataLakeAnalyticsCmdletBase
    {
        internal const string BaseParameterSetName = "GetAllInSubscription";
        internal const string ResourceGroupParameterSetName = "GetByResourceGroup";
        internal const string AccountParameterSetName = "GetBySpecificAccount";

        [Parameter(ParameterSetName = ResourceGroupParameterSetName, ValueFromPipelineByPropertyName = true,
            Position = 0, Mandatory = true,
            HelpMessage = "Name of resource group under which want to retrieve the account.")]
        [Parameter(ParameterSetName = AccountParameterSetName, ValueFromPipelineByPropertyName = true, Position = 1,
            Mandatory = false, HelpMessage = "Name of resource group under which want to retrieve the account.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = AccountParameterSetName, ValueFromPipelineByPropertyName = true, Position = 0,
            Mandatory = true, HelpMessage = "Name of a specific account.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // Get for single account
                WriteObject(new PSDataLakeAnalyticsAccount(DataLakeAnalyticsClient.GetAccount(ResourceGroupName, Name)));
            }
            else
            {
                WriteWarning(Resources.IncorrectOutputTypeWarning);
                // List all accounts in given resource group if avaliable otherwise all accounts in the subscription
                WriteObject(DataLakeAnalyticsClient.ListAccounts(ResourceGroupName, null, null, null)
                    .Select(element => new PSDataLakeAnalyticsAccountBasic(element))
                    .ToList(), true);
            }
        }
    }
}