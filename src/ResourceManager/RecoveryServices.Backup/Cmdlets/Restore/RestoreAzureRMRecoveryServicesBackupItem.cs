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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet(VerbsData.Restore, "AzureRMRecoveryServicesBackupItem"), OutputType(typeof(AzureRmRecoveryServicesJobBase))]
    public class RestoreAzureRMRecoveryServicesBackupItem : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = ParamHelpMsg.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesRecoveryPointBase RecoveryPoint { get; set; }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = ParamHelpMsg.RestoreDisk.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                WriteDebug("InsideRestore. going to create ResourceManager Client");
                ResourcesNS.ResourceManagementClient rmClient = AzureSession.ClientFactory.CreateClient<ResourcesNS.ResourceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                WriteDebug("Client Created successfully");
                ResourceIdentity identity = new ResourceIdentity();
                identity.ResourceName = StorageAccountName;
                identity.ResourceProviderNamespace = "Microsoft.ClassicStorage/storageAccounts";
                identity.ResourceProviderApiVersion = "2015-12-01";

                WriteDebug(String.Format("Query Microsoft.ClassicStorage with name = {0}", StorageAccountName));
                ResourcesNS.Models.ResourceGetResult resource = rmClient.Resources.GetAsync(StorageAccountName, identity, CancellationToken.None).Result;
                if(resource == null)
                {
                    identity.ResourceType = "Microsoft.Storage/storageAccounts";
                    resource = rmClient.Resources.GetAsync(StorageAccountName, identity, CancellationToken.None).Result;
                }
                if(resource == null)
                {
                    throw new ArgumentException("Storage account doesnt exists");
                }

                string storageId = resource.Resource.Id;
                WriteDebug(String.Format("StorageId = {0}", storageId));

                storageId = StorageAccountName; //TBD: once service will migrate to storageID we will remove this line;

                PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                {
                    {RestoreBackupItemParams.RecoveryPoint, RecoveryPoint},
                    {RestoreBackupItemParams.StorageAccountId, storageId}
                }, HydraAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(RecoveryPoint.WorkloadType, RecoveryPoint.BackupManagementType);
                var jobResponse = psBackupProvider.TriggerRestore();

                WriteDebug(String.Format("Restore submitted", storageId));
                var response = HydraAdapter.GetProtectedItemOperationStatusByURL(jobResponse.AzureAsyncOperation);
                while (response.OperationStatus.Status == "InProgress")
                {
                    WriteDebug(String.Format("Restore inProgress", storageId));
                    response = HydraAdapter.GetProtectedItemOperationStatusByURL(jobResponse.AzureAsyncOperation);
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                }

                if (response.OperationStatus.Status == "Completed")
                {
                    // TBD -- Hydra change to add jobId in OperationStatusExtendedInfo
                    WriteDebug(String.Format("Restore Completed", storageId));
                    string jobId = ""; //response.OperationStatus.Properties.jobId;
                    var job = HydraAdapter.GetJob(jobId);
                    //WriteObject(ConversionHelpers.GetJobModel(job));
                }
            });
        }

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
                    throw new ArgumentException("Storage account not found");
                }
                else if (result.Count > 1)
                {
                    WriteVerbose(string.Format("Found more than one StorageAccount with same name. Some thing went wrong"));
                    throw new Exception(string.Format("Found more than one StorageAccount with same name. Some thing went wrong"));
                }
                id = result[0].Members["ResourceId"].Value.ToString();
                location = result[0].Members["Location"].Value.ToString();
                resourceType = result[0].Members["ResourceType"].Value.ToString();
            }
        }
    }
}
