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
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System.Globalization;

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
        public static List<RecoveryPointBase> GetPSAzureRecoveryPoints(ServiceClientModel.RecoveryPointListResponse rpList, AzureVmItem item)
        {
            if (rpList == null || rpList.RecoveryPointList == null || 
                rpList.RecoveryPointList.RecoveryPoints == null) 
            { 
                throw new ArgumentNullException("RPList"); 
            }

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            List<RecoveryPointBase> result = new List<RecoveryPointBase>();
            foreach (ServiceClientModel.RecoveryPointResource rp in rpList.RecoveryPointList.RecoveryPoints)
            {
                ServiceClientModel.RecoveryPoint recPoint = rp.Properties as ServiceClientModel.RecoveryPoint;

                DateTime recPointTime = DateTime.ParseExact(recPoint.RecoveryPointTime, @"MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                AzureVmRecoveryPoint rpBase = new AzureVmRecoveryPoint()
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
                    SourceVMStorageType = recPoint.SourceVMStorageType,
                    SourceResourceId = item.SourceResourceId,
                };
                result.Add(rpBase);
            }

            return result;
        }

        // <summary>
        /// Helper function to convert ps recovery point model from service response.
        /// </summary>
        public static RecoveryPointBase GetPSAzureRecoveryPoints(ServiceClientModel.RecoveryPointResponse rpResponse, AzureVmItem item)
        {
            if (rpResponse == null || rpResponse.RecPoint == null)
            {
                throw new ArgumentNullException(Resources.GetRPResponseIsNull);
            }

            ServiceClientModel.RecoveryPoint recPoint = rpResponse.RecPoint.Properties as ServiceClientModel.RecoveryPoint;
            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);
            DateTime recPointTime = DateTime.ParseExact(
                recPoint.RecoveryPointTime, 
                @"MM/dd/yyyy HH:mm:ss", 
                CultureInfo.InvariantCulture);

            AzureVmRecoveryPoint result = new AzureVmRecoveryPoint()
            {
                RecoveryPointId = rpResponse.RecPoint.Name,
                BackupManagementType = item.BackupManagementType,
                ItemName = protectedItemName,
                ContainerName = containerUri,
                ContainerType = item.ContainerType,
                RecoveryPointTime = recPointTime,
                RecoveryPointType = recPoint.RecoveryPointType,
                Id = rpResponse.RecPoint.Id,
                WorkloadType = item.WorkloadType,
                RecoveryPointAdditionalInfo = recPoint.RecoveryPointAdditionalInfo,
                SourceResourceId = item.SourceResourceId,
            };
            return result;
        }
    }
}
