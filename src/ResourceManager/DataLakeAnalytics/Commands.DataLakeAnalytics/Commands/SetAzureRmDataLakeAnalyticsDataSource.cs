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
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeAnalyticsDataSource")]
    [Alias("Set-AdlAnalyticsDataSource")]
    public class SetAzureDataLakeAnalyticsDataSource : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true, 
            HelpMessage = "Name of the account to update the data source in.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The name of the Blob to update in the account.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureBlob")]
        public string Blob { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The corresponding access key for the Blob to add to the account.")]
        [ValidateNotNullOrEmpty]
        public string AccessKey { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            // We only support updates for Storage accounts.
            var toAdd = new StorageAccountInfo
            {
                Name = Blob,
                AccessKey = AccessKey
            };

            DataLakeAnalyticsClient.SetStorageAccount(ResourceGroupName, Account, toAdd);
        }
    }
}