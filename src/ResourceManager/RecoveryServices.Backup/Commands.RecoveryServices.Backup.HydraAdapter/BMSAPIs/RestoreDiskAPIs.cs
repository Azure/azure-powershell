using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapter
{
    public partial class HydraAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="resourceName"></param>
        /// <param name="containerName"></param>
        /// <param name="protectedItemName"></param>
        /// <param name="recoveryPointId"></param>
        /// <returns></returns>
        public BaseRecoveryServicesJobResponse RestoreDisk(AzureRmRecoveryServicesIaasVmRecoveryPoint rp, string storageAccountId)
        {
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            string resourceName = BmsAdapter.GetResourceName();
            string location = BmsAdapter.GetResourceLocation();            

            string containerName = rp.ContainerName;
            string protectedItemName = rp.ItemName;
            string recoveryPointId = rp.RecoveryPointId;

            IaasVMRestoreRequest restoreRequest = new IaasVMRestoreRequest()
            {
                AffinityGroup = String.Empty,
                CloudServiceOrResourceGroup = String.Empty,
                CreateNewCloudService = false,
                RecoveryPointId = recoveryPointId,
                RecoveryType = RecoveryType.RestoreDisks,
                Region = location,
                StorageAccountName = storageAccountId,
                SubnetName = string.Empty,
                VirtualMachineName = string.Empty,
                VirtualNetworkName = string.Empty,
            };

            TriggerRestoreRequest triggerRestoreRequest = new TriggerRestoreRequest();
            triggerRestoreRequest.Item = new RestoreRequestResource();
            triggerRestoreRequest.Item.Properties = new RestoreRequest();
            triggerRestoreRequest.Item.Properties = restoreRequest;

            var response = BmsAdapter.Client.Restore.TriggerRestoreAsync(resourceGroupName, resourceName, BmsAdapter.GetCustomRequestHeaders(),
                AzureFabricName, containerName, protectedItemName, recoveryPointId, triggerRestoreRequest, BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }
    }
}
