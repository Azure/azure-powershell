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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        private ProviderData providerData;
        private HydraAdapter.HydraAdapter hydraAdapter;
        public void Initialize(ProviderData providerData, HydraAdapter.HydraAdapter hydraAdapter)
        {
            this.providerData = providerData;
            this.hydraAdapter = hydraAdapter;
        }

        public BaseRecoveryServicesJobResponse EnableProtection()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesRecoveryPointBase> GetRecoveryPoint()
        {
            RecoveryPointResponse response = null;
            DateTime startDate = (DateTime)(providerData.ProviderParameters[GetRecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(providerData.ProviderParameters[GetRecoveryPointParams.EndDate]);
            AzureRmRecoveryServicesItemBase item = providerData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesItemBase;
            
            string recoveryPointId = providerData.ProviderParameters[GetRecoveryPointParams.RecoveryPointId].ToString();

            if(item == null)
            {
                throw new InvalidCastException("Cant convert input to AzureRmRecoveryServicesItemBase");
            }

            string containerName = item.ContainerName;
            string protectedItemName = item.Name;

            TimeSpan duration = endDate - startDate;

            if(duration.TotalDays > 30)
            {
                throw new Exception("Time difference should not be more than 30 days"); //tbd: Correct nsg and exception type
            }

            if(string.IsNullOrEmpty(recoveryPointId))
            {
                //we need to fetch the list of RPs
                RecoveryPointQueryParameters queryFilter = new RecoveryPointQueryParameters();
                queryFilter.StartDate = HydraHelpers.GetDateTimeStringForService(startDate);
                queryFilter.EndDate = HydraHelpers.GetDateTimeStringForService(endDate);

                var result = hydraAdapter.GetRecoveryPoints(containerName, protectedItemName, queryFilter);
            }
            else
            {
                var result = hydraAdapter.GetRecoveryPointDetails(containerName, protectedItemName, recoveryPointId);
            }

            List<AzureRmRecoveryServicesRecoveryPointBase> abc = 
        }

        public ProtectionPolicyResponse CreatePolicy()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse ModifyPolicy()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse GetPolicy()
        {
            throw new NotImplementedException();
        }

        public void DeletePolicy()
        {
            throw new NotImplementedException();
        }
    }
}
