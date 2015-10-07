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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Management.DataLake.Analytics.Models;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Remove, "AzureDataLakeAnalyticsDataSource")]
    public class RemoveAzureDataLakeAnalyticsDataSource : DataLakeAnalyticsCmdletBase
    {
        internal const string DataLakeParameterSetName = "Remove a DataLake storage account";
        internal const string AzureBlobParameterSetName = "Remove an AzureBlob storage account";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true, ParameterSetName = DataLakeParameterSetName, HelpMessage = "Name of the account to add the data source to.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true, ParameterSetName = AzureBlobParameterSetName, HelpMessage = "Name of the account to add the data source to.")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true, ParameterSetName = DataLakeParameterSetName, HelpMessage = "The name of the DataLake to add to the account.")]
        [ValidateNotNullOrEmpty]
        public string DataLake { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true, ParameterSetName = AzureBlobParameterSetName, HelpMessage = "The name of the AzureBlob to add to the account.")]
        [ValidateNotNullOrEmpty]
        public string AzureBlob { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false, ParameterSetName = DataLakeParameterSetName, HelpMessage = "Name of resource group under which the bigAnalytics account exists to add a data source to.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false, ParameterSetName = AzureBlobParameterSetName, HelpMessage = "Name of resource group under which the bigAnalytics account exists to add a data source to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        protected override void ProcessRecord()
        {
            if(ParameterSetName.Equals(DataLakeParameterSetName, StringComparison.InvariantCultureIgnoreCase))
            {
                DataLakeAnalyticsClient.RemoveStorageAccount(ResourceGroupName, AccountName, AzureBlob);
            }
            else
            {
                DataLakeAnalyticsClient.RemoveDataLakeAccount(ResourceGroupName, AccountName, DataLake);    
            }

            
        }
    }
}