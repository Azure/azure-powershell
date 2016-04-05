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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet(VerbsData.Restore, "AzureRMRecoveryServicesBackupItem"), OutputType(typeof(AzureRmRecoveryServicesJobBase))]
    class RestoreAzureRMRecoveryServicesBackupItem : RecoveryServicesBackupCmdletBase
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

                ResourcesNS.ResourceManagementClient rmClient = AzureSession.ClientFactory.CreateClient<ResourcesNS.ResourceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                ResourceIdentity identity = new ResourceIdentity();
                identity.ResourceName = StorageAccountName;
                identity.ResourceProviderNamespace = "Microsoft.ClassicStorage/storageAccounts";
                identity.ResourceProviderApiVersion = "2015-12-01";

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

                storageId = StorageAccountName; //TBD: once service will migrate to storageID we will remove this line;

                PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                {
                    {RestoreBackupItemParams.RecoveryPoint, RecoveryPoint},
                    {RestoreBackupItemParams.StorageAccountId, storageId}
                }, HydraAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(RecoveryPoint.WorkloadType, RecoveryPoint.BackupManagementType);
                var jobResponse = psBackupProvider.TriggerRestore();

                var response = HydraAdapter.GetProtectedItemOperationStatusByURL(jobResponse.AzureAsyncOperation);
                while (response.OperationStatus.Status == "InProgress")
                {
                    response = HydraAdapter.GetProtectedItemOperationStatusByURL(jobResponse.AzureAsyncOperation);
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                }

                if (response.OperationStatus.Status == "Completed")
                {
                    // TBD -- Hydra change to add jobId in OperationStatusExtendedInfo
                    string jobId = ""; //response.OperationStatus.Properties.jobId;
                    var job = HydraAdapter.GetJob(jobId);
                    //WriteObject(ConversionHelpers.GetJobModel(job));
                }
            });
        }
    }
}
