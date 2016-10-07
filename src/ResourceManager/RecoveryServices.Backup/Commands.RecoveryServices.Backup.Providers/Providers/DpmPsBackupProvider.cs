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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for DPM backup provider
    /// </summary>
    public class DpmPsBackupProvider : IPsBackupProvider
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

        public Microsoft.Rest.Azure.AzureOperationResponse EnableProtection()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Rest.Azure.AzureOperationResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Rest.Azure.AzureOperationResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Rest.Azure.AzureOperationResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public ServiceClientModel.ProtectedItemResource GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public RecoveryPointBase GetRecoveryPointDetails()
        {
            throw new NotImplementedException();
        }

        public List<RecoveryPointBase> ListRecoveryPoints()
        {
            throw new NotImplementedException();
        }

        public ServiceClientModel.ProtectionPolicyResource CreatePolicy()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Rest.Azure.AzureOperationResponse<ServiceClientModel.ProtectionPolicyResource> ModifyPolicy()
        {
            throw new NotImplementedException();
        }

        public List<Models.ContainerBase> ListProtectionContainers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists backup management servers registered with the recovery services vault
        /// </summary>
        /// <returns></returns>
        public List<Models.BackupEngineBase> ListBackupManagementServers()
        {
            string name = (string)this.ProviderData[ContainerParams.Name];

            ODataQuery<ServiceClientModel.BMSBackupEngineQueryObject> queryParams = new ODataQuery<ServiceClientModel.BMSBackupEngineQueryObject>();

            var listResponse = ServiceClientAdapter.ListBackupEngines(queryParams);

            List<BackupEngineBase> backupEngineModels = ConversionHelpers.GetBackupEngineModelList(listResponse);

            return backupEngineModels;
        }

        public ServiceClientModel.ProtectionPolicyResource GetPolicy()
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
