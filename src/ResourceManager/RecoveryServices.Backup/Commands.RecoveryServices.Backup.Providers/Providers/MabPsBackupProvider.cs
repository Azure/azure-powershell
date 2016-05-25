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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for MAB backup provider
    /// </summary>
    public class MabPsBackupProvider : IPsBackupProvider
    {
        Dictionary<System.Enum, object> ProviderData { get; set; }
        ServiceClientAdapter ServiceClientAdapter { get; set; }

        /// <summary>
        /// Initializes the provider with the data recieved from the cmdlet layer
        /// </summary>
        /// <param name="providerData">Data from the cmdlet layer intended for the provider</param>
        /// <param name="serviceClientAdapter">Service client adapter for communicating with the backend service</param>
        public void Initialize(Dictionary<System.Enum, object> providerData, ServiceClientAdapter serviceClientAdapter)
        {
            this.ProviderData = providerData;
            this.ServiceClientAdapter = serviceClientAdapter;
        }       

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse EnableProtection()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public CmdletModel.RecoveryPointBase GetRecoveryPointDetails()
        {
            throw new NotImplementedException();
        }

        public List<CmdletModel.RecoveryPointBase> ListRecoveryPoints()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectionPolicyResponse CreatePolicy()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse ModifyPolicy()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists containers registered to the recovery services vault according to the provider data
        /// </summary>
        /// <returns>List of protection containers</returns>
        public List<Models.ContainerBase> ListProtectionContainers()
        {
            string name = (string)this.ProviderData[ContainerParams.Name];

            ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();

            // 1. Filter by Name
            queryParams.FriendlyName = name;

            // 2. Filter by ContainerType
            queryParams.BackupManagementType = ServiceClientModel.BackupManagementType.MAB.ToString();

            var listResponse = ServiceClientAdapter.ListContainers(queryParams);

            List<ContainerBase> containerModels = ConversionHelpers.GetContainerModelList(listResponse);

            return containerModels;
        }

        public List<CmdletModel.BackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectionPolicyResponse GetPolicy()
        {
            throw new NotImplementedException();
        }

        public void DeletePolicy()
        {
            throw new NotImplementedException();
        }

        public SchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            throw new NotImplementedException();
        }

        public RetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            throw new NotImplementedException();
        }

        public List<Models.ItemBase> ListProtectedItems()
        {
            throw new NotImplementedException();
        }
    }
}
