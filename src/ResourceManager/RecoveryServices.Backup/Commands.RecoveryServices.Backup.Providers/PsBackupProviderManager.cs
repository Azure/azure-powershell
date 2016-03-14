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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class PsBackupProviderManager
    {
        ProviderData providerData;
        HydraAdapter.HydraAdapter hydraAdapter;

        public PsBackupProviderManager(Dictionary<System.Enum, object> providerParams, HydraAdapter.HydraAdapter hydraAdapterIn)
            : this(new ProviderData(providerParams), hydraAdapterIn) { }

        public PsBackupProviderManager(ProviderData providerDataIn, HydraAdapter.HydraAdapter hydraAdapterIn)
        {
            providerData = providerDataIn;
            hydraAdapter = hydraAdapterIn;
        }

        public IPsBackupProvider GetProviderInstance(ContainerType containerType)
        {
            PsBackupProviderTypes providerType = 0;

            switch (containerType)
            {
                case ContainerType.AzureVM:
                    providerType = PsBackupProviderTypes.IaasVm;
                    break;
                case ContainerType.AzureSqlContainer:
                    providerType = PsBackupProviderTypes.AzureSql;
                    break;
                default:
                    break;
            }

            return GetProviderInstance(providerType);
        }

        public IPsBackupProvider GetProviderInstance(ContainerType containerType, BackupManagementType backupManagementType)
        {
            throw new NotImplementedException();
        }

        public IPsBackupProvider GetProviderInstance(WorkloadType workloadType, BackupManagementType backupManagementType)
        {
            throw new NotImplementedException();
        }

        public IPsBackupProvider GetProviderInstance(PsBackupProviderTypes providerType)
        {
            IPsBackupProvider psBackupProvider = null;

            switch (providerType)
            {
                case PsBackupProviderTypes.IaasVm:
                    psBackupProvider = new IaasVmPsBackupProvider();
                    break;
                case PsBackupProviderTypes.AzureSql:
                    psBackupProvider = new AzureSqlPsBackupProvider();
                    break;
                default:
                    break;
            }

            psBackupProvider.Initialize(providerData, hydraAdapter);

            return psBackupProvider;
        }
    }
}
