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
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeAnalyticsDataSource", DefaultParameterSetName = ListStorageParameterSetName), OutputType(typeof(StorageAccountInfo), typeof(DataLakeStoreAccountInfo), typeof(IEnumerable<AdlDataSource>))]
    [Alias("Get-AdlAnalyticsDataSource")]
    public class GetAzureDataLakeAnalyticsDataSource : DataLakeAnalyticsCmdletBase
    {
        internal const string DataLakeParameterSetName = "Get a Data Lake Store account";
        internal const string BlobParameterSetName = "Get a Blob storage account";
        internal const string ListStorageParameterSetName = "List all data sources";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = DataLakeParameterSetName, HelpMessage = "Name of the account to add the data source to.")
        ]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = BlobParameterSetName, HelpMessage = "Name of the account to add the data source to.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = ListStorageParameterSetName, HelpMessage = "Name of the account to add the data source to.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            ParameterSetName = DataLakeParameterSetName,
            HelpMessage = "The name of the Data Lake Store account to get from the account.")]
        [ValidateNotNullOrEmpty]
        public string DataLakeStore { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            ParameterSetName = BlobParameterSetName, HelpMessage = "The name of the Blob storage to get from the account.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureBlob")]
        public string Blob { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            ParameterSetName = DataLakeParameterSetName,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            ParameterSetName = BlobParameterSetName,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            ParameterSetName = ListStorageParameterSetName,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(BlobParameterSetName, StringComparison.InvariantCultureIgnoreCase))
            {
                WriteObject(DataLakeAnalyticsClient.GetStorageAccount(ResourceGroupName, Account, Blob));
            }
            else if ((ParameterSetName.Equals(DataLakeParameterSetName, StringComparison.InvariantCultureIgnoreCase)))
            {
                WriteObject(DataLakeAnalyticsClient.GetDataLakeStoreAccount(ResourceGroupName, Account, DataLakeStore));
            }
            else
            {
                WriteObject(DataLakeAnalyticsClient.GetAllDataSources(ResourceGroupName, Account), true);
            }
        }
    }
}