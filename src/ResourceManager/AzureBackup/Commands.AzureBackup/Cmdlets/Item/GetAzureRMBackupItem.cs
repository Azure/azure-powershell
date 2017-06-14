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

using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of azure backup items
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupItem"), OutputType(typeof(AzureRMBackupItem), typeof(List<AzureRMBackupItem>))]
    public class GetAzureRMBackupItem : AzureBackupContainerCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ProtectionStatus)]
        [ValidateSet("Protected", "Protecting", "NotProtected")]
        public string ProtectionStatus { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.Status)]
        [ValidateSet("IRPending", "ProtectionStopped", "ProtectionError", "Protected")]
        public string Status { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.Type)]
        [ValidateSet("AzureVM")]
        public string Type { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                List<CSMProtectedItemResponse> azureBackupDatasourceObjects = null;
                List<CSMItemResponse> azureBackupPOObjects = null;

                WriteDebug(Resources.MakingClientCall);
                CSMProtectedItemQueryObject DSQueryParam = new CSMProtectedItemQueryObject()
                {
                    ProtectionStatus = this.ProtectionStatus,
                    Status = this.Status,
                    Type = GetItemType(this.Type)
                };

                CSMItemQueryObject POQueryParam = new CSMItemQueryObject()
                {
                    Status = this.ProtectionStatus,
                    Type = GetItemType(this.Type)
                };

                var azureBackupDatasourceListResponse = AzureBackupClient.ListDataSources(Container.ResourceGroupName, Container.ResourceName, DSQueryParam);

                if (azureBackupDatasourceListResponse != null)
                {
                    azureBackupDatasourceObjects = azureBackupDatasourceListResponse.Where(x => x.Properties.ContainerId.Split('/').Last().Equals(Container.ContainerUniqueName, System.StringComparison.InvariantCultureIgnoreCase)).ToList();
                }

                if (this.Status == null)
                {
                    var azureBackupPOListResponse = AzureBackupClient.ListProtectableObjects(Container.ResourceGroupName, Container.ResourceName, POQueryParam);
                    if (azureBackupPOListResponse != null)
                    {
                        azureBackupPOObjects = azureBackupPOListResponse.Where(x => x.Properties.ContainerId.Split('/').Last().Equals(Container.ContainerUniqueName, System.StringComparison.InvariantCultureIgnoreCase)).ToList();
                    }
                }

                WriteDebug(Resources.AzureBackupItemResponse);
                WriteAzureBackupItem(azureBackupDatasourceObjects, azureBackupPOObjects, Container);
            });
        }

        public void WriteAzureBackupItem(CSMProtectedItemResponse sourceItem, AzureRMBackupContainer azureBackupItem)
        {
            this.WriteObject(new AzureRMBackupItem(sourceItem, azureBackupItem));
        }

        public void WriteAzureBackupItem(List<CSMProtectedItemResponse> sourceDataSourceList, List<CSMItemResponse> sourcePOList, AzureRMBackupContainer azureBackupContainer)
        {
            List<AzureRMBackupItem> targetList = new List<AzureRMBackupItem>();

            if (sourceDataSourceList != null)
            {
                foreach (var item in sourceDataSourceList)
                {
                    targetList.Add(new AzureRMBackupItem(item, azureBackupContainer));
                }
            }

            if (sourcePOList != null)
            {
                foreach (var item in sourcePOList)
                {
                    //If user has stopped protection for some datasoure then we will have duplicate items(po and ds).
                    //So in this case removing  po items from the list.
                    if (targetList.FindIndex(element => element.ItemName == item.Name) < 0)
                    {
                        targetList.Add(new AzureRMBackupItem(item, azureBackupContainer));
                    }
                }
            }

            if (targetList.Count() == 1)
            {
                this.WriteObject(targetList.First(), true);
            }
            else
            {
                this.WriteObject(targetList, true);
            }
        }

        public string GetItemType(string sourceType)
        {
            string result = null;

            if (sourceType == "AzureVM")
            {
                result = AzureBackupItemType.IaasVM.ToString();
            }

            return result;
        }

    }
}