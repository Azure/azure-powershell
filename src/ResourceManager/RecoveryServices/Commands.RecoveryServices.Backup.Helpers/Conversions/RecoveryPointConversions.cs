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
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Recovery Point conversion helper.
    /// </summary>
    public class RecoveryPointConversions
    {
        /// <summary>
        /// Helper function to convert ps recovery points list model from service response.
        /// </summary>
        public static List<RecoveryPointBase> GetPSAzureRecoveryPoints(
            List<ServiceClientModel.RecoveryPointResource> rpList,
            ItemBase item)
        {
            if (rpList == null)
            {
                throw new ArgumentNullException("RPList");
            }

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            string containerName = IdUtils.GetNameFromUri(containerUri);
            string protectedItemName = IdUtils.GetNameFromUri(protectedItemUri);

            List<RecoveryPointBase> result = new List<RecoveryPointBase>();
            foreach (ServiceClientModel.RecoveryPointResource rp in rpList)
            {
                if (rp.Properties.GetType() == typeof(ServiceClientModel.IaasVMRecoveryPoint))
                {
                    ServiceClientModel.IaasVMRecoveryPoint recPoint =
                        rp.Properties as ServiceClientModel.IaasVMRecoveryPoint;

                    DateTime recPointTime = DateTime.MinValue;
                    if (recPoint.RecoveryPointTime.HasValue)
                    {
                        recPointTime = (DateTime)recPoint.RecoveryPointTime;
                    }
                    else
                    {
                        throw new ArgumentNullException("RecoveryPointTime is null");
                    }

                    bool isInstantILRSessionActive =
                        recPoint.IsInstantILRSessionActive.HasValue ?
                            (bool)recPoint.IsInstantILRSessionActive : false;

                    AzureVmRecoveryPoint rpBase = new AzureVmRecoveryPoint()
                    {
                        RecoveryPointId = rp.Name,
                        BackupManagementType = item.BackupManagementType,
                        ItemName = protectedItemName,
                        ContainerName = containerName,
                        ContainerType = item.ContainerType,
                        RecoveryPointTime = recPointTime,
                        RecoveryPointType = recPoint.RecoveryPointType,
                        Id = rp.Id,
                        WorkloadType = item.WorkloadType,
                        RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
                        SourceVMStorageType = recPoint.SourceVMStorageType,
                        SourceResourceId = item.SourceResourceId,
                        EncryptionEnabled = recPoint.IsSourceVMEncrypted.HasValue ?
                            recPoint.IsSourceVMEncrypted.Value : false,
                        IlrSessionActive = isInstantILRSessionActive,
                        OriginalSAEnabled = recPoint.OriginalStorageAccountOption.HasValue ?
                            recPoint.OriginalStorageAccountOption.Value : false,
                    };
                    result.Add(rpBase);
                }

                if (rp.Properties.GetType() == typeof(ServiceClientModel.GenericRecoveryPoint))
                {
                    ServiceClientModel.GenericRecoveryPoint recPoint =
                        rp.Properties as ServiceClientModel.GenericRecoveryPoint;

                    DateTime recPointTime = DateTime.MinValue;
                    if (recPoint.RecoveryPointTime.HasValue)
                    {
                        recPointTime = (DateTime)recPoint.RecoveryPointTime;
                    }
                    else
                    {
                        throw new ArgumentNullException("RecoveryPointTime is null");
                    }

                    AzureSqlRecoveryPoint rpBase = new AzureSqlRecoveryPoint()
                    {
                        RecoveryPointId = rp.Name,
                        BackupManagementType = item.BackupManagementType,
                        ItemName = protectedItemName,
                        ContainerName = containerUri,
                        ContainerType = item.ContainerType,
                        RecoveryPointTime = recPointTime,
                        RecoveryPointType = recPoint.RecoveryPointType,
                        Id = rp.Id,
                        WorkloadType = item.WorkloadType,
                        RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
                        FriendlyName = recPoint.FriendlyName,
                    };

                    result.Add(rpBase);
                }
            }

            return result;
        }

        // <summary>
        /// Helper function to convert ps recovery point model from service response.
        /// </summary>
        public static RecoveryPointBase GetPSAzureRecoveryPoints(
            ServiceClientModel.RecoveryPointResource rpResponse,
            ItemBase item)
        {
            if (rpResponse == null)
            {
                throw new ArgumentNullException(Resources.GetRPResponseIsNull);
            }

            RecoveryPointBase result = null;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string containerName = IdUtils.GetNameFromUri(containerUri);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, item.Id);
            string protectedItemName = IdUtils.GetNameFromUri(protectedItemUri);

            if (rpResponse.Properties.GetType() ==
                typeof(ServiceClientModel.IaasVMRecoveryPoint))
            {
                ServiceClientModel.IaasVMRecoveryPoint recPoint =
                    rpResponse.Properties as ServiceClientModel.IaasVMRecoveryPoint;

                DateTime recPointTime = DateTime.MinValue;
                if (recPoint.RecoveryPointTime.HasValue)
                {
                    recPointTime = (DateTime)recPoint.RecoveryPointTime;
                }
                else
                {
                    throw new ArgumentNullException("RecoveryPointTime is null");
                }

                bool isInstantILRSessionActive =
                    recPoint.IsInstantILRSessionActive.HasValue ?
                        (bool)recPoint.IsInstantILRSessionActive : false;
                AzureVmRecoveryPoint vmResult = new AzureVmRecoveryPoint()
                {
                    RecoveryPointId = rpResponse.Name,
                    BackupManagementType = item.BackupManagementType,
                    ItemName = protectedItemName,
                    ContainerName = containerName,
                    ContainerType = item.ContainerType,
                    RecoveryPointTime = recPointTime,
                    RecoveryPointType = recPoint.RecoveryPointType,
                    Id = rpResponse.Id,
                    WorkloadType = item.WorkloadType,
                    RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
                    EncryptionEnabled = recPoint.IsSourceVMEncrypted.HasValue ?
                        recPoint.IsSourceVMEncrypted.Value : false,
                    IlrSessionActive = isInstantILRSessionActive,
                    SourceResourceId = item.SourceResourceId,
                    SourceVMStorageType = recPoint.SourceVMStorageType,
                    OriginalSAEnabled = recPoint.OriginalStorageAccountOption.HasValue ?
                        recPoint.OriginalStorageAccountOption.Value : false,
                };

                if (vmResult.EncryptionEnabled && recPoint.KeyAndSecret != null)
                {
                    vmResult.KeyAndSecretDetails = new KeyAndSecretDetails()
                    {
                        SecretUrl = recPoint.KeyAndSecret.BekDetails.SecretUrl,
                        KeyUrl = recPoint.KeyAndSecret.KekDetails.KeyUrl,
                        SecretData = recPoint.KeyAndSecret.BekDetails.SecretData,
                        KeyBackupData = recPoint.KeyAndSecret.KekDetails.KeyBackupData,
                        KeyVaultId = recPoint.KeyAndSecret.KekDetails.KeyVaultId,
                        SecretVaultId = recPoint.KeyAndSecret.BekDetails.SecretVaultId,
                    };
                }

                result = vmResult;
            }

            if (rpResponse.Properties.GetType() ==
                typeof(ServiceClientModel.GenericRecoveryPoint))
            {
                ServiceClientModel.GenericRecoveryPoint recPoint =
                    rpResponse.Properties as ServiceClientModel.GenericRecoveryPoint;

                DateTime recPointTime = DateTime.MinValue;
                if (recPoint.RecoveryPointTime.HasValue)
                {
                    recPointTime = (DateTime)recPoint.RecoveryPointTime;
                }
                else
                {
                    throw new ArgumentNullException("RecoveryPointTime is null");
                }

                AzureSqlRecoveryPoint sqlResult = new AzureSqlRecoveryPoint()
                {
                    RecoveryPointId = rpResponse.Name,
                    BackupManagementType = item.BackupManagementType,
                    ItemName = protectedItemName,
                    ContainerName = containerName,
                    ContainerType = item.ContainerType,
                    RecoveryPointTime = recPointTime,
                    RecoveryPointType = recPoint.RecoveryPointType,
                    Id = rpResponse.Id,
                    WorkloadType = item.WorkloadType,
                    RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
                    SourceResourceId = item.SourceResourceId,
                    FriendlyName = recPoint.FriendlyName
                };

                result = sqlResult;
            }
            return result;
        }
    }
}
