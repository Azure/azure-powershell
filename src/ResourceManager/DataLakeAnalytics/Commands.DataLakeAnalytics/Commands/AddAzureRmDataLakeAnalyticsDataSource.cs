﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeAnalyticsDataSource")]
    [Alias("Add-AdlAnalyticsDataSource")]
    public class AddAzureDataLakeAnalyticsDataSource : DataLakeAnalyticsCmdletBase
    {
        internal const string DataLakeParameterSetName = "AddDataLakeStorageAccount";
        internal const string BlobParameterSetName = "AddBlobStorageAccount";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = DataLakeParameterSetName, HelpMessage = "Name of the account to add the data source to.")
        ]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            ParameterSetName = BlobParameterSetName, HelpMessage = "Name of the account to add the data source to.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            ParameterSetName = DataLakeParameterSetName,
            HelpMessage = "The name of the Data Lake Storage account to add to the account.")]
        [ValidateNotNullOrEmpty]
        public string DataLakeStore { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            ParameterSetName = BlobParameterSetName, HelpMessage = "The name of the Blob to add to the account.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureBlob")]
        public string Blob { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            ParameterSetName = BlobParameterSetName,
            HelpMessage = "The corresponding access key for the Blob to add to the account.")]
        [ValidateNotNullOrEmpty]
        public string AccessKey { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            ParameterSetName = DataLakeParameterSetName,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            ParameterSetName = BlobParameterSetName,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(BlobParameterSetName, StringComparison.InvariantCultureIgnoreCase))
            {
                var toAdd = new AddStorageAccountParameters
                {
                    AccessKey = AccessKey
                };

                DataLakeAnalyticsClient.AddStorageAccount(ResourceGroupName, Account, Blob, toAdd);
            }
            else
            {
                var toAdd = new DataLakeStoreAccountInformation
                (
                    name: DataLakeStore
                );

                DataLakeAnalyticsClient.AddDataLakeStoreAccount(ResourceGroupName, Account, toAdd);
            }
        }
    }
}
