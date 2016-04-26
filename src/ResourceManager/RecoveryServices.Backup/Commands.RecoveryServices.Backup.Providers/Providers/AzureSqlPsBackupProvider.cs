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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapterNS;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class AzureSqlPsBackupProvider : IPsBackupProvider
    {
        public void Initialize(ProviderData providerData, HydraAdapter hydraAdapter)
        {
            throw new NotImplementedException();
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

        public AzureRmRecoveryServicesBackupRecoveryPointBase GetRecoveryPointDetails()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesBackupRecoveryPointBase> ListRecoveryPoints()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectionPolicyResponse CreatePolicy()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectionPolicyResponse ModifyPolicy()
        {
            throw new NotImplementedException();
        }

        public List<Models.AzureRmRecoveryServicesBackupContainerBase> ListProtectionContainers()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesBackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }
       
        public AzureRmRecoveryServicesBackupSchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            throw new NotImplementedException();
        }

        public AzureRmRecoveryServicesBackupRetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            throw new NotImplementedException();
        }

        public List<Models.AzureRmRecoveryServicesBackupItemBase> ListProtectedItems()
        {
            throw new NotImplementedException();
        }
    }
}
