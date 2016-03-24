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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class RecoveryPointConversions
    {
        public static List<AzureRmRecoveryServicesRecoveryPointBase> GetPSAzureRecoveryPoints(RecoveryPointListResponse rpList, AzureRmRecoveryServicesIaasVmItem item)
        {
            if (rpList == null || rpList.RecoveryPointList == null || rpList.RecoveryPointList.RecoveryPoints == null) 
            { 
                throw new ArgumentNullException("rpList is null"); 
            }

            List<AzureRmRecoveryServicesRecoveryPointBase> result = new List<AzureRmRecoveryServicesRecoveryPointBase>();
            foreach (RecoveryPointResource rp in rpList.RecoveryPointList.RecoveryPoints)
            {
                RecoveryPoint recPoint = rp.Properties as RecoveryPoint;
                AzureRmRecoveryServicesIaasVmRecoveryPoint rpBase = new AzureRmRecoveryServicesIaasVmRecoveryPoint()
                {
                    BackupManagementType = item.BackupManagementType,
                    ContainerName = item.ContainerName,
                    ItemName = item.Name,
                    ContainerType = item.ContainerType,
                    RecoveryPointTime = Convert.ToDateTime(recPoint.RecoveryPointTime).ToLocalTime(),
                    RecoveryPointType = recPoint.RecoveryPointType,
                    WorkloadType = item.WorkloadType,
                    RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,                    
                };
                result.Add(rpBase);
            }

            return result;
        }

        public static AzureRmRecoveryServicesRecoveryPointBase GetPSAzureRecoveryPoints(RecoveryPointResponse rpResponse, AzureRmRecoveryServicesIaasVmItem item)
        {
            if (rpResponse == null || rpResponse.RecPoint == null)
            {
                throw new ArgumentNullException("rpResponse is null");
            }

            RecoveryPoint recPoint = rpResponse.RecPoint.Properties as RecoveryPoint;

            AzureRmRecoveryServicesIaasVmRecoveryPoint result = new AzureRmRecoveryServicesIaasVmRecoveryPoint()
                {
                    BackupManagementType = item.BackupManagementType,
                    ItemName = item.Name,
                    ContainerName = item.ContainerName,
                    ContainerType = item.ContainerType,
                    RecoveryPointTime = Convert.ToDateTime(recPoint.RecoveryPointTime).ToLocalTime(),
                    RecoveryPointType = recPoint.RecoveryPointType,
                    RecoveryPointId = rpResponse.RecPoint.Id,
                    Region = rpResponse.Location,
                    WorkloadType = item.WorkloadType,
                    RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
                };
            return result;
        }
    }
}
