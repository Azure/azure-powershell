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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmDataLakeAnalyticsAccount"), OutputType(typeof(bool))]
    [Alias("Test-AdlAnalyticsAccount")]
    public class TestAzureDataLakeAnalyticsAccount : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of a specific account.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which want to test the account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(DataLakeAnalyticsClient.TestAccount(ResourceGroupName, Name));
        }
    }
}