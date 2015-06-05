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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupItem"), OutputType(typeof(AzureBackupItem), typeof(List<AzureBackupItem>))]
    public class GetAzureBackupItem : AzureBackupContainerCmdletBase
    {
        [Parameter(Position = 2, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");

                var azureBackupDatasourceListResponse = AzureBackupClient.DataSource.ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                var azureBackupPOListResponse = AzureBackupClient.ProtectableObject. ListAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteVerbose("Received policy response");
                WriteVerbose("Received policy response2");
                IEnumerable<DataSourceInfo> azureBackupDatasourceObjects = null;
                IEnumerable<ProtectableObjectInfo> azureBackupPOObjects = null;

                if (Id != null)
                {
                    azureBackupDatasourceObjects = azureBackupDatasourceListResponse.DataSources.Objects.Where(x => x.InstanceId.Equals(Id, System.StringComparison.InvariantCultureIgnoreCase));
                    azureBackupPOObjects = azureBackupPOListResponse.ProtectableObject.Objects.Where(x => x.InstanceId.Equals(Id, System.StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    azureBackupDatasourceObjects = azureBackupDatasourceListResponse.DataSources.Objects;
                    azureBackupPOObjects = azureBackupPOListResponse.ProtectableObject.Objects;
                }

                WriteVerbose("Converting response");
                WriteAzureBackupProtectionPolicy(azureBackupDatasourceObjects, azureBackupPOObjects, AzureBackupContainer);
            });
        }

        public void WriteAzureBackupProtectionPolicy(DataSourceInfo sourceItem, AzureBackupContainer azureBackupItem)
        {
            this.WriteObject(new AzureBackupItem(sourceItem, azureBackupItem));
        }

        public void WriteAzureBackupProtectionPolicy(IEnumerable<DataSourceInfo> sourceDataSourceList,IEnumerable<ProtectableObjectInfo> sourcePOList, AzureBackupContainer azureBackupContainer)
        {
            List<AzureBackupItem> targetList = new List<AzureBackupItem>();

            foreach (var item in sourceDataSourceList)
            {
                targetList.Add(new AzureBackupItem(item, azureBackupContainer));
            }

            foreach (var item in sourcePOList)
            {
                targetList.Add(new AzureBackupItem(item, azureBackupContainer));
            }

            this.WriteObject(targetList, true);
        }

    }
}
