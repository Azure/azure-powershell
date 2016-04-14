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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System.Globalization;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class RecoveryPointConversions
    {
        public static List<AzureRmRecoveryServicesBackupRecoveryPointBase> GetPSAzureRecoveryPoints(RecoveryPointListResponse rpList, AzureRmRecoveryServicesBackupIaasVmItem item)
        {
            if (rpList == null || rpList.RecoveryPointList == null || rpList.RecoveryPointList.RecoveryPoints == null) 
            { 
                throw new ArgumentNullException("RPList"); 
            }

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            List<AzureRmRecoveryServicesBackupRecoveryPointBase> result = new List<AzureRmRecoveryServicesBackupRecoveryPointBase>();
            foreach (RecoveryPointResource rp in rpList.RecoveryPointList.RecoveryPoints)
            {
                RecoveryPoint recPoint = rp.Properties as RecoveryPoint;

                DateTime recPointTime = DateTime.ParseExact(recPoint.RecoveryPointTime, @"MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToLocalTime();
                AzureRmRecoveryServicesIaasVmRecoveryPoint rpBase = new AzureRmRecoveryServicesIaasVmRecoveryPoint()
                {
                    Name = rp.Name,
                    BackupManagementType = item.BackupManagementType,
                    ItemName = protectedItemName,
                    ContainerName = containerUri,
                    ContainerType = item.ContainerType,
                    RecoveryPointTime = recPointTime,
                    RecoveryPointType = recPoint.RecoveryPointType,
                    RecoveryPointId = rp.Id,
                    WorkloadType = item.WorkloadType,
                    RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
                    SourceVMStorageType = recPoint.SourceVMStorageType,
                };
                result.Add(rpBase);
            }

            return result;
        }

        public static AzureRmRecoveryServicesBackupRecoveryPointBase GetPSAzureRecoveryPoints(RecoveryPointResponse rpResponse, AzureRmRecoveryServicesBackupIaasVmItem item)
        {
            if (rpResponse == null || rpResponse.RecPoint == null)
            {
                throw new ArgumentNullException(Resources.GetRPResponseIsNull);
            }

            RecoveryPoint recPoint = rpResponse.RecPoint.Properties as RecoveryPoint;
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            AzureRmRecoveryServicesIaasVmRecoveryPoint result = new AzureRmRecoveryServicesIaasVmRecoveryPoint()
            {
                Name = rpResponse.RecPoint.Name,
                BackupManagementType = item.BackupManagementType,
                ItemName = protectedItemName,
                ContainerName = containerUri,
                ContainerType = item.ContainerType,
                RecoveryPointTime = Convert.ToDateTime(recPoint.RecoveryPointTime).ToLocalTime(),
                RecoveryPointType = recPoint.RecoveryPointType,
                RecoveryPointId = rpResponse.RecPoint.Id,
                WorkloadType = item.WorkloadType,
                RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
            };
            return result;
        }
    }
}
