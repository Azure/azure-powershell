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
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupItem"), OutputType(typeof(AzureBackupItem), typeof(List<AzureBackupItem>))]
    public class GetAzureBackupItem : AzureBackupContainerCmdletBase
    {
        [Parameter(Position = 2, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ProtectionStatus)]
        [ValidateNotNullOrEmpty]
        public protectionStatus ProtectionStatus { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");

                DataSourceQueryParameter dsQueryParameter = new DataSourceQueryParameter()
                {
                    ContainerName = AzureBackupContainer.ContainerName
                };

                POQueryParameter pOQueryParameter = new POQueryParameter()
                {
                    Status = this.ProtectionStatus.ToString()
                };

                var azureBackupDatasourceListResponse = AzureBackupClient.DataSource.ListAsync(dsQueryParameter,GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                var azureBackupPOListResponse = AzureBackupClient.ProtectableObject. ListAsync(pOQueryParameter, GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                WriteVerbose("Received policy response");
                WriteVerbose("Received policy response2");
                List<DataSourceInfo> azureBackupDatasourceObjects = null;
                List<ProtectableObjectInfo> azureBackupPOObjects = null;

                azureBackupDatasourceObjects = azureBackupDatasourceListResponse.DataSources.Objects.ToList();
                azureBackupPOObjects = azureBackupPOListResponse.ProtectableObject.Objects.Where(x => x.ContainerName.Equals(AzureBackupContainer.ContainerName, System.StringComparison.InvariantCultureIgnoreCase)).ToList();

                //If user has stopped protection for some datasoure then we will have duplicate items(po and ds).
                //So in this case removing  poitem.
                foreach (var DSItem in azureBackupDatasourceObjects)
                {
                    foreach(var POItem in azureBackupPOObjects)
                    {
                        if(DSItem.ProtectableObjectName == POItem.Name)
                        {
                            azureBackupPOObjects.Remove(POItem);
                        }
                    }
                }

                WriteVerbose("Converting response");
                WriteAzureBackupProtectionPolicy(azureBackupDatasourceObjects, azureBackupPOObjects, AzureBackupContainer);
            });
        }

        public void WriteAzureBackupProtectionPolicy(DataSourceInfo sourceItem, AzureBackupContainer azureBackupItem)
        {
            this.WriteObject(new AzureBackupItem(sourceItem, azureBackupItem));
        }

        public void WriteAzureBackupProtectionPolicy(List<DataSourceInfo> sourceDataSourceList, List<ProtectableObjectInfo> sourcePOList, AzureBackupContainer azureBackupContainer)
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

        public enum protectionStatus
        {
            [EnumMember]
            NotProtected = 0,

            [EnumMember]
            Protected,
        }
    }
}
