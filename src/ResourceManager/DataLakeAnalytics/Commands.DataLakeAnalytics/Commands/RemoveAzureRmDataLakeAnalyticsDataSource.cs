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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeAnalyticsDataSource",
        SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AdlAnalyticsDataSource")]
    public class RemoveAzureDataLakeAnalyticsDataSource : DataLakeAnalyticsCmdletBase
    {
        internal const string DataLakeParameterSetName = "Remove a Data Lake storage account";
        internal const string BlobParameterSetName = "Remove a Blob storage account";

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
            HelpMessage = "The name of the Data Lake Store to add to the account.")]
        [ValidateNotNullOrEmpty]
        public string DataLakeStore { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            ParameterSetName = BlobParameterSetName, HelpMessage = "The name of the Blob to add to the account.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureBlob")]
        public string Blob { get; set; }

        [Parameter(Mandatory = false, Position = 2, ParameterSetName = DataLakeParameterSetName, HelpMessage = "Do not ask for confirmation.")]
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = BlobParameterSetName, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, Position = 3, ParameterSetName = DataLakeParameterSetName, HelpMessage = "Return true upon successfull deletion.")]
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = BlobParameterSetName, HelpMessage = "Return true upon successfull deletion.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            ParameterSetName = DataLakeParameterSetName,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            ParameterSetName = BlobParameterSetName,
            HelpMessage =
                "Name of resource group under which the Data Lake Analytics account exists to add a data source to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(DataLakeParameterSetName, StringComparison.InvariantCultureIgnoreCase))
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemovingDataLakeAnalyticsDataLakeStore, DataLakeStore),
                    string.Format(Resources.RemoveDataLakeAnalyticsCatalogSecret, DataLakeStore),
                    DataLakeStore,
                    () =>
                    {
                        DataLakeAnalyticsClient.RemoveDataLakeStoreAccount(ResourceGroupName, Account, DataLakeStore);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }

                    });

            }
            else
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemovingDataLakeAnalyticsBlobAccount, Blob),
                    string.Format(Resources.RemoveDataLakeAnalyticsBlobAccount, Blob),
                    Blob,
                    () =>
                    {
                        DataLakeAnalyticsClient.RemoveStorageAccount(ResourceGroupName, Account, Blob);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }

        }
    }
}