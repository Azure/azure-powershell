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
using System.Collections.Specialized;
using Microsoft.Azure.Common.OData;
using Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of azure backup items
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupItem"), OutputType(typeof(AzureBackupItem), typeof(List<AzureBackupItem>))]
    public class GetAzureBackupItem : AzureBackupContainerCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ProtectionStatus)]
        [ValidateSet("Protected","Protecting","NotProtected")]   
        public string ProtectionStatus { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.Status)]
        [ValidateSet("IRPending", "ProtectionStopped", "ProtectionError", "Protected")]        
        public string Status { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.Type)]
        [ValidateSet("VM")]
        public string Type { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                List<DataSourceInfo> azureBackupDatasourceObjects = null;
                List<ProtectableObjectInfo> azureBackupPOObjects = null;

                WriteDebug("Making client call");
                DataSourceQueryParameter DSQueryParam = new DataSourceQueryParameter()
                {
                    ProtectionStatus = this.ProtectionStatus,
                    Status = this.Status,
                    Type = this.Type
                };

                POQueryParameter POQueryParam = new POQueryParameter()
                {
                    Status = this.ProtectionStatus,
                    Type = this.Type
                };

                var azureBackupDatasourceListResponse = AzureBackupClient.ListDataSources(DSQueryParam);
                azureBackupDatasourceObjects = azureBackupDatasourceListResponse.Where(x => x.ContainerName.Equals(Container.ContainerUniqueName, System.StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (this.Status == null)
                {
                    var azureBackupPOListResponse = AzureBackupClient.ListProtectableObjects(POQueryParam);
                    azureBackupPOObjects = azureBackupPOListResponse.Where(x => x.ContainerName.Equals(Container.ContainerUniqueName, System.StringComparison.InvariantCultureIgnoreCase)).ToList();
                }

                WriteDebug("Received azure backup item response");
                WriteAzureBackupItem(azureBackupDatasourceObjects, azureBackupPOObjects, Container);
            });
        }

        public void WriteAzureBackupItem(DataSourceInfo sourceItem, AzureBackupContainer azureBackupItem)
        {
            this.WriteObject(new AzureBackupItem(sourceItem, azureBackupItem));
        }

        public void WriteAzureBackupItem(List<DataSourceInfo> sourceDataSourceList, List<ProtectableObjectInfo> sourcePOList, AzureBackupContainer azureBackupContainer)
        {
            List<AzureBackupItem> targetList = new List<AzureBackupItem>();

            foreach (var item in sourceDataSourceList)
            {
                targetList.Add(new AzureBackupItem(item, azureBackupContainer));
            }

            if (sourcePOList != null)
            {
                foreach (var item in sourcePOList)
                {
                    //If user has stopped protection for some datasoure then we will have duplicate items(po and ds).
                    //So in this case removing  poitems from the list.
                    if (targetList.FindIndex(element => element.Name == item.Name) < 0)
                    {
                        targetList.Add(new AzureBackupItem(item, azureBackupContainer));
                    }
                }
            }

            this.WriteObject(targetList, true);
        }

    }
}
