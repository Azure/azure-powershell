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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapterNS;
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
        HydraAdapter hydraAdapter;

        public PsBackupProviderManager(Dictionary<System.Enum, object> providerParams, HydraAdapter hydraAdapterIn)
            : this(new ProviderData(providerParams), hydraAdapterIn) { }

        public PsBackupProviderManager(ProviderData providerDataIn, HydraAdapter hydraAdapterIn)
        {
            providerData = providerDataIn;
            hydraAdapter = hydraAdapterIn;
        }

        public IPsBackupProvider GetProviderInstance(ContainerType containerType, BackupManagementType? backupManagementType)
        {
            PsBackupProviderTypes providerType = 0;

            switch (containerType)
            {
                case ContainerType.AzureVM:
                    providerType = PsBackupProviderTypes.IaasVm;
                    break;
                case ContainerType.Windows:
                    if (backupManagementType == BackupManagementType.MARS)
                        providerType = PsBackupProviderTypes.Mab;
                    else
                        throw new ArgumentException(String.Format("BackupManagementType is required for ContainerType {1}.", backupManagementType.ToString(), containerType));
                    break;
                //case ContainerType.AzureSqlContainer:
                //    if (backupManagementType.HasValue)
                //    {
                //        throw new ArgumentException("BackupManagementType is not expected for ContainerType: " +
                //                                     containerType.ToString());
                //    }
                //    providerType = PsBackupProviderTypes.AzureSql;
                //    break;
                default:
                    throw new ArgumentException("Unsupported containerType: " + containerType.ToString());
            }

            return GetProviderInstance(providerType);
        }

        public IPsBackupProvider GetProviderInstanceForBackupManagementServer()
        {
            return GetProviderInstance(PsBackupProviderTypes.Dpm);
        }

        public IPsBackupProvider GetProviderInstance(WorkloadType workloadType)
        {
            PsBackupProviderTypes providerType = 0;

            switch (workloadType)
            {
                case WorkloadType.AzureVM:
                    providerType = PsBackupProviderTypes.IaasVm;
                    break;
                default:
                    throw new ArgumentException("BackupManagementType is also required for WorkloadType: " +
                                                     workloadType.ToString());
            }

            return GetProviderInstance(providerType);
        }

        public IPsBackupProvider GetProviderInstance(ContainerType containerType)
        {
            throw new NotImplementedException();
        }

        public IPsBackupProvider GetProviderInstance(WorkloadType workloadType, BackupManagementType? backupManagementType)
        {
            PsBackupProviderTypes psProviderType;

            switch (workloadType)
            {
                case WorkloadType.AzureVM:
                    // validate backupManagementType is valid
                    if (backupManagementType.HasValue && backupManagementType != BackupManagementType.AzureVM)
                    {
                        // throw exception that it is not expected
                        throw new ArgumentException("BackupManagementType is not expected for WorkloadType: " +
                                                     workloadType.ToString());
                    }
                    psProviderType = PsBackupProviderTypes.IaasVm;
                    break;
                default:
                    throw new ArgumentException("Unsupported workloadType: " + workloadType.ToString());
            }

            return GetProviderInstance(psProviderType);
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
                case PsBackupProviderTypes.Mab:
                    psBackupProvider = new MabPsBackupProvider();
                    break;
                case PsBackupProviderTypes.Dpm:
                    psBackupProvider = new DpmPsBackupProvider();
                    break;
                default:
                    break;
            }

            psBackupProvider.Initialize(providerData, hydraAdapter);

            return psBackupProvider;
        }
    }
}
