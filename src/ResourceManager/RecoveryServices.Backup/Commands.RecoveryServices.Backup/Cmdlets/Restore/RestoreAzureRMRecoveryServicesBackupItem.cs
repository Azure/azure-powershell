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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ResourcesNS = Microsoft.Azure.Management.Resources;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet(VerbsData.Restore, "AzureRMRecoveryServicesBackupItem"), OutputType(typeof(AzureRmRecoveryServicesJobBase))]
    public class RestoreAzureRMRecoveryServicesBackupItem : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = ParamHelpMsg.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesBackupRecoveryPointBase RecoveryPoint { get; set; }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = ParamHelpMsg.RestoreDisk.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true, Position = 2, HelpMessage = ParamHelpMsg.RestoreDisk.StorageAccountResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                StorageAccountName = StorageAccountName.ToLower();
                WriteDebug("InsideRestore. going to create ResourceManager Client");
                ResourcesNS.ResourceManagementClient rmClient = AzureSession.ClientFactory.CreateClient<ResourcesNS.ResourceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                WriteDebug("Client Created successfully");
                ResourceIdentity identity = new ResourceIdentity();
                identity.ResourceName = StorageAccountName;
                identity.ResourceProviderNamespace = "Microsoft.ClassicStorage/storageAccounts";
                identity.ResourceProviderApiVersion = "2015-12-01";
                identity.ResourceType = string.Empty;

                ResourcesNS.Models.ResourceGetResult resource = null;
                try
                {
                    WriteDebug(String.Format("Query Microsoft.ClassicStorage with name = {0}", StorageAccountName));
                    resource = rmClient.Resources.GetAsync(StorageAccountResourceGroupName, identity, CancellationToken.None).Result;
                }
                catch (Exception)
                {
                    identity.ResourceProviderNamespace = "Microsoft.Storage/storageAccounts";
                    identity.ResourceProviderApiVersion = "2016-01-01";
                    resource = rmClient.Resources.GetAsync(StorageAccountResourceGroupName, identity, CancellationToken.None).Result;
                }
                
                string storageAccountId = resource.Resource.Id;
                string storageAccountlocation = resource.Resource.Location;
                string storageAccountType = resource.Resource.Type;

                WriteDebug(String.Format("StorageId = {0}", storageAccountId));

                PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                {
                    {RestoreBackupItemParams.RecoveryPoint, RecoveryPoint},
                    {RestoreBackupItemParams.StorageAccountId, storageAccountId},
                    {RestoreBackupItemParams.StorageAccountLocation, storageAccountlocation},
                    {RestoreBackupItemParams.StorageAccountType, storageAccountType}
                }, HydraAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(RecoveryPoint.WorkloadType, RecoveryPoint.BackupManagementType);
                var jobResponse = psBackupProvider.TriggerRestore();

                WriteDebug(String.Format("Restore submitted"));
                HandleCreatedJob(jobResponse, Resources.RestoreOperation);
            });
        }

        /// <summary>
        /// This code is not getting used. Will delete it once things will be closed.
        /// </summary>
        /// <param name="storageAccountName"></param>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <param name="resourceType"></param>
        internal void GetStorageResource(string storageAccountName, out string id, out string location, out string resourceType)
        {
            using (System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create())
            {
                //Get-AzureRmResource | Where-Object { ($_.Name -eq "<StorageAccName>") -and ($_.ResourceType -eq "Microsoft.Storage/storageAccounts" -or $_.ResourceType -eq "Microsoft.ClassicStorage/storageAccounts")}
                ps.AddCommand("Get-AzureRmResource");
                ps.AddCommand("where-object");
                string filterString = String.Format(@"($_.Name -eq ""{0}"") -and ($_.ResourceType -eq ""Microsoft.Storage/storageAccounts"" -or $_.ResourceType -eq ""Microsoft.ClassicStorage/storageAccounts"")");
                ScriptBlock filter = ScriptBlock.Create(filterString);

                ps.AddParameter("FilterScript", filter);                
                var result = ps.Invoke();

                if (ps.HadErrors)
                {
                    WriteVerbose(string.Format("Error in Get-AzureRmResource"));
                    throw new Exception(ps.HadErrors.ToString());
                }

                if(result.Count == 0)
                {
                    WriteVerbose(string.Format("Storage Account not fount"));
                    throw new ArgumentException(Resources.RestoreAzureStorageNotFound);
                }
                else if (result.Count > 1)
                {
                    WriteVerbose(string.Format("Found more than one StorageAccount with same name. Some thing went wrong"));
                    throw new Exception(Resources.RestoreDiskMoreThanOneAccFound);
                }
                id = result[0].Members["ResourceId"].Value.ToString();
                location = result[0].Members["Location"].Value.ToString();
                resourceType = result[0].Members["ResourceType"].Value.ToString();
            }
        }
    }
}
