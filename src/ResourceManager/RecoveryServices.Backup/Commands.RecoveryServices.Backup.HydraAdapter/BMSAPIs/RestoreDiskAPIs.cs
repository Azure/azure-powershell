using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapterNS
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
        public BaseRecoveryServicesJobResponse RestoreDisk(AzureRmRecoveryServicesBackupIaasVmRecoveryPoint rp, string storageAccountId, 
            string storageAccountLocation, string storageAccountType)
        {
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            string resourceName = BmsAdapter.GetResourceName();
            string vaultLocation = BmsAdapter.GetResourceLocation();            
            string containerName = rp.ContainerName;
            string protectedItemName = rp.ItemName;
            string recoveryPointId = rp.Name;
            //validtion block
            if(storageAccountLocation != vaultLocation)
            {
                throw new Exception(Resources.RestoreDiskIncorrectRegion);
            }
            string vmType = containerName.Split(';')[1].Equals("iaasvmcontainer", StringComparison.OrdinalIgnoreCase) ? "Classic" : "Compute";
            string strType = storageAccountType.Equals("Microsoft.ClassicStorage/StorageAccounts", StringComparison.OrdinalIgnoreCase) ? "Classic" : "Compute";
            if(vmType != strType)
            {
                throw new Exception(String.Format(Resources.RestoreDiskStorageTypeError, vmType));
            }

            IaasVMRestoreRequest restoreRequest = new IaasVMRestoreRequest()
            {
                AffinityGroup = String.Empty,
                CloudServiceOrResourceGroup = String.Empty,
                CreateNewCloudService = false,
                RecoveryPointId = recoveryPointId,
                RecoveryType = RecoveryType.RestoreDisks,
                Region = vaultLocation,
                StorageAccountId = storageAccountId,
                SubnetId = string.Empty,
                VirtualMachineName = string.Empty,
                VirtualNetworkId = string.Empty,
            };

            TriggerRestoreRequest triggerRestoreRequest = new TriggerRestoreRequest();
            triggerRestoreRequest.Item = new RestoreRequestResource();
            triggerRestoreRequest.Item.Properties = new RestoreRequest();
            triggerRestoreRequest.Item.Properties = restoreRequest;

            var response = BmsAdapter.Client.Restores.TriggerRestoreAsync(resourceGroupName, resourceName, BmsAdapter.GetCustomRequestHeaders(),
                AzureFabricName, containerName, protectedItemName, recoveryPointId, triggerRestoreRequest, BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }
    }
}