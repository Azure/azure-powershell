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
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreVirtualNetworkRule", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AdlStoreVirtualNetworkRule")]
    public class RemoveAzureRmDataLakeStoreVirtualNetworkRule : DataLakeStoreCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to update the virtual network rule in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = "The name of the virtual network rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage =
                "Indicates a boolean response should be returned indicating the result of the delete operation."
            )]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                string.Format(Resources.RemoveDataLakeStoreVirtualNetworkRule, Name),
                Name,
                () =>
                {
                    DataLakeStoreClient.DeleteVirtualNetworkRule(Account, Name, this);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
