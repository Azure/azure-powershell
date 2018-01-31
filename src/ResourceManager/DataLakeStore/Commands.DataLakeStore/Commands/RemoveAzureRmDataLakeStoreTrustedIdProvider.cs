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

using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.PowerShell.Commands;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeStoreTrustedIdProvider", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AdlStoreTrustedIdProvider")]
    public class RemoveAzureRmDataLakeStoreAccountTrustedIdProvider : DataLakeStoreCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to remove the trusted identity provider from")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "The name of the trusted identity provider.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates a boolean response should be returned indicating the result of the delete operation"
            )]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 4,
            ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Name of resource group under which want to retrieve the account.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                string.Format(Resources.RemoveDataLakeStoreTrustedProvider, Name),
                Name,
                () =>
                {
                    DataLakeStoreClient.DeleteTrustedProvider(ResourceGroupName, Account, Name, this);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}