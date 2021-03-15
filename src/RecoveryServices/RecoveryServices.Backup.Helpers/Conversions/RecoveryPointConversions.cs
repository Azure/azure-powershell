﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System;
using System.Collections.Generic;
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
                    result.Add(GetPSAzureVMRecoveryPoint(rp, item));
                }

                else if (rp.Properties.GetType() == typeof(ServiceClientModel.AzureFileShareRecoveryPoint))
                {
                    result.Add(GetPSAzureFileRecoveryPoint(rp, item));
                }

                else if (rp.Properties.GetType().IsSubclassOf(typeof(ServiceClientModel.AzureWorkloadRecoveryPoint)))
                {
                    result.Add(GetPSAzureWorkloadRecoveryPoint(rp, item));
                }

                else if (rp.Properties.GetType() == typeof(ServiceClientModel.GenericRecoveryPoint))
                {
                    result.Add(GetPSAzureGenericRecoveryPoint(rp, item));
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

            if (rpResponse.Properties.GetType() ==
                typeof(ServiceClientModel.IaasVMRecoveryPoint))
            {
                result = GetPSAzureVMRecoveryPoint(rpResponse, item);
            }

            else if (rpResponse.Properties.GetType() ==
                typeof(ServiceClientModel.AzureFileShareRecoveryPoint))
            {
                result = GetPSAzureFileRecoveryPoint(rpResponse, item);
            }

            else if (rpResponse.Properties.GetType().IsSubclassOf(typeof(ServiceClientModel.AzureWorkloadRecoveryPoint)))
            {
                result = GetPSAzureWorkloadRecoveryPoint(rpResponse, item);
            }

            else if (rpResponse.Properties.GetType() ==
                typeof(ServiceClientModel.GenericRecoveryPoint))
            {
                result = GetPSAzureGenericRecoveryPoint(rpResponse, item);
            }
            return result;
        }

        public static RecoveryPointBase GetPSAzureVMRecoveryPoint(
            ServiceClientModel.RecoveryPointResource rp, ItemBase item)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            string containerName = IdUtils.GetNameFromUri(containerUri);
            string protectedItemName = IdUtils.GetNameFromUri(protectedItemUri);

            ServiceClientModel.IaasVMRecoveryPoint recoveryPoint =
                        rp.Properties as ServiceClientModel.IaasVMRecoveryPoint;

            DateTime recoveryPointTime = DateTime.MinValue;
            if (recoveryPoint.RecoveryPointTime.HasValue)
            {
                recoveryPointTime = (DateTime)recoveryPoint.RecoveryPointTime;
            }
            else
            {
                throw new ArgumentNullException("RecoveryPointTime is null");
            }

            bool isInstantILRSessionActive =
                recoveryPoint.IsInstantIlrSessionActive.HasValue ?
                    (bool)recoveryPoint.IsInstantIlrSessionActive : false;

            AzureVmRecoveryPoint rpBase = new AzureVmRecoveryPoint()
            {
                RecoveryPointId = rp.Name,
                BackupManagementType = item.BackupManagementType,
                ItemName = protectedItemName,
                ContainerName = containerName,
                ContainerType = item.ContainerType,
                RecoveryPointTime = recoveryPointTime,
                RecoveryPointType = recoveryPoint.RecoveryPointType,
                Id = rp.Id,
                WorkloadType = item.WorkloadType,
                RecoveryPointAdditionalInfo = recoveryPoint.RecoveryPointAdditionalInfo,
                SourceVMStorageType = recoveryPoint.SourceVMStorageType,
                SourceResourceId = item.SourceResourceId,
                EncryptionEnabled = recoveryPoint.IsSourceVMEncrypted.HasValue ?
                    recoveryPoint.IsSourceVMEncrypted.Value : false,
                IlrSessionActive = isInstantILRSessionActive,
                IsManagedVirtualMachine = recoveryPoint.IsManagedVirtualMachine.HasValue ?
                    recoveryPoint.IsManagedVirtualMachine.Value : false,
                OriginalSAEnabled = recoveryPoint.OriginalStorageAccountOption.HasValue ?
                    recoveryPoint.OriginalStorageAccountOption.Value : false,
                Zones = recoveryPoint.Zones,
                RehydrationExpiryTime = (DateTime?)null,
            };

            if (recoveryPoint.RecoveryPointTierDetails != null)
            {
                bool isHardenedRP = false;
                bool isInstantRecoverable = false;
                bool isArchived = false;
                bool isRehydrated = false;

                foreach (ServiceClientModel.RecoveryPointTierInformation tierInfo in recoveryPoint.RecoveryPointTierDetails)
                {
                    if (tierInfo.Status == ServiceClientModel.RecoveryPointTierStatus.Rehydrated)
                    {
                        if (tierInfo.Type == ServiceClientModel.RecoveryPointTierType.ArchivedRP)
                        {
                            isRehydrated = true;

                            rpBase.RehydrationExpiryTime = (tierInfo.ExtendedInfo.ContainsKey("RehydratedRPExpiryTime")) ? DateTime.Parse(tierInfo.ExtendedInfo["RehydratedRPExpiryTime"]) : (DateTime?)null;
                        }
                    }

                    if (tierInfo.Status == ServiceClientModel.RecoveryPointTierStatus.Valid)
                    {
                        if (tierInfo.Type == ServiceClientModel.RecoveryPointTierType.InstantRP)
                        {
                            isInstantRecoverable = true;
                        }
                        if (tierInfo.Type == ServiceClientModel.RecoveryPointTierType.HardenedRP)
                        {
                            isHardenedRP = true;
                        }
                        if (tierInfo.Type == ServiceClientModel.RecoveryPointTierType.ArchivedRP)
                        {
                            isArchived = true;
                        }
                    }
                }

                if ((isHardenedRP && isArchived) || (isRehydrated))
                {
                    rpBase.RecoveryPointTier = RecoveryPointTier.VaultStandardRehydrated;
                }
                else if (isInstantRecoverable && isHardenedRP)
                {
                    rpBase.RecoveryPointTier = RecoveryPointTier.SnapshotAndVaultStandard;
                }
                else if (isInstantRecoverable && isArchived)
                {
                    rpBase.RecoveryPointTier = RecoveryPointTier.SnapshotAndVaultArchive;
                }
                else if (isArchived)
                {
                    rpBase.RecoveryPointTier = RecoveryPointTier.VaultArchive;
                }
                else if (isInstantRecoverable)
                {
                    rpBase.RecoveryPointTier = RecoveryPointTier.Snapshot;
                }
                else if (isHardenedRP)
                {
                    rpBase.RecoveryPointTier = RecoveryPointTier.VaultStandard;
                }
            }


            if (rpBase.EncryptionEnabled && recoveryPoint.KeyAndSecret != null)
            {
                rpBase.KeyAndSecretDetails = new KeyAndSecretDetails()
                {
                    SecretUrl = recoveryPoint.KeyAndSecret.BekDetails.SecretUrl,
                    KeyUrl = recoveryPoint.KeyAndSecret.KekDetails.KeyUrl,
                    SecretData = recoveryPoint.KeyAndSecret.BekDetails.SecretData,
                    KeyBackupData = recoveryPoint.KeyAndSecret.KekDetails.KeyBackupData,
                    KeyVaultId = recoveryPoint.KeyAndSecret.KekDetails.KeyVaultId,
                    SecretVaultId = recoveryPoint.KeyAndSecret.BekDetails.SecretVaultId,
                };
            }
            return rpBase;
        }

        public static RecoveryPointBase GetPSAzureFileRecoveryPoint(
            ServiceClientModel.RecoveryPointResource rp, ItemBase item)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            string containerName = IdUtils.GetNameFromUri(containerUri);
            string protectedItemName = IdUtils.GetNameFromUri(protectedItemUri);
            ServiceClientModel.AzureFileShareRecoveryPoint recoveryPoint =
                        rp.Properties as ServiceClientModel.AzureFileShareRecoveryPoint;

            DateTime recoveryPointTime = DateTime.MinValue;
            if (recoveryPoint.RecoveryPointTime.HasValue)
            {
                recoveryPointTime = (DateTime)recoveryPoint.RecoveryPointTime;
            }
            else
            {
                throw new ArgumentNullException("RecoveryPointTime is null");
            }

            AzureFileShareRecoveryPoint rpBase = new AzureFileShareRecoveryPoint()
            {
                RecoveryPointId = rp.Name,
                BackupManagementType = item.BackupManagementType,
                ItemName = protectedItemName,
                ContainerName = containerName,
                ContainerType = item.ContainerType,
                RecoveryPointTime = recoveryPointTime,
                RecoveryPointType = recoveryPoint.RecoveryPointType,
                Id = rp.Id,
                WorkloadType = item.WorkloadType,
                FileShareSnapshotUri = recoveryPoint.FileShareSnapshotUri,
            };
            return rpBase;
        }

        public static RecoveryPointBase GetPSAzureWorkloadRecoveryPoint(
            ServiceClientModel.RecoveryPointResource rp, ItemBase item)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            string containerName = IdUtils.GetNameFromUri(containerUri);
            string protectedItemName = IdUtils.GetNameFromUri(protectedItemUri);

            ServiceClientModel.AzureWorkloadSQLRecoveryPoint recoveryPoint =
                        rp.Properties as ServiceClientModel.AzureWorkloadSQLRecoveryPoint;

            DateTime recoveryPointTime = DateTime.MinValue;

            if (recoveryPoint.RecoveryPointTimeInUTC.HasValue)
            {
                recoveryPointTime = (DateTime)recoveryPoint.RecoveryPointTimeInUTC;
            }
            else
            {
                throw new ArgumentNullException("RecoveryPointTime is null");
            }

            AzureWorkloadRecoveryPoint rpBase = new AzureWorkloadRecoveryPoint()
            {
                RecoveryPointId = rp.Name,
                BackupManagementType = item.BackupManagementType,
                ItemName = protectedItemName,
                ContainerName = containerName,
                ContainerType = item.ContainerType,
                RecoveryPointTime = recoveryPointTime,
                RecoveryPointType = recoveryPoint.Type,
                Id = rp.Id,
                WorkloadType = item.WorkloadType,
                DataDirectoryPaths = recoveryPoint.ExtendedInfo != null ? recoveryPoint.ExtendedInfo.DataDirectoryPaths : null
            };
            return rpBase;
        }

        public static RecoveryPointBase GetPSAzureGenericRecoveryPoint(
            ServiceClientModel.RecoveryPointResource rp, ItemBase item)
        {
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            string containerName = IdUtils.GetNameFromUri(containerUri);
            string protectedItemName = IdUtils.GetNameFromUri(protectedItemUri);

            ServiceClientModel.GenericRecoveryPoint recoveryPoint =
                        rp.Properties as ServiceClientModel.GenericRecoveryPoint;

            DateTime recoveryPointTime = DateTime.MinValue;
            if (recoveryPoint.RecoveryPointTime.HasValue)
            {
                recoveryPointTime = (DateTime)recoveryPoint.RecoveryPointTime;
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
                RecoveryPointTime = recoveryPointTime,
                RecoveryPointType = recoveryPoint.RecoveryPointType,
                Id = rp.Id,
                WorkloadType = item.WorkloadType,
                RecoveryPointAdditionalInfo = recoveryPoint.RecoveryPointAdditionalInfo,
                FriendlyName = recoveryPoint.FriendlyName,
            };
            return rpBase;
        }
    }
}
