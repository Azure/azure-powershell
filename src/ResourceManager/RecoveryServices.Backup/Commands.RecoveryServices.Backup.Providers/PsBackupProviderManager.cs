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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements provider intialization based on workload
    /// and backup management type.
    /// </summary>
    public class PsBackupProviderManager
    {
        /// <summary>
        /// Dictionary of cmdlet param enums and provider specific objects.
        /// </summary>
        Dictionary<System.Enum, object> providerData;

        /// <summary>
        /// Service client adapter object.
        /// </summary>
        ServiceClientAdapter serviceClientAdapter;

        public PsBackupProviderManager(Dictionary<System.Enum, object> providerDataIn, ServiceClientAdapter serviceClientAdapterIn)
        {
            providerData = providerDataIn;
            serviceClientAdapter = serviceClientAdapterIn;
        }

        /// <summary>
        /// Gets an instance of the provider based on the container type and backup management type (optional)
        /// </summary>
        /// <param name="containerType">Type of the container</param>
        /// <param name="backupManagementType">Type of the backup management type (optional)</param>
        /// <returns></returns>
        public IPsBackupProvider GetProviderInstance
            (
            ContainerType containerType,
            BackupManagementType? backupManagementType
            )
        {
            PsBackupProviderTypes providerType = 0;

            switch (containerType)
            {
                case ContainerType.AzureVM:
                    if (backupManagementType == BackupManagementType.AzureVM || backupManagementType == null)
                    {
                        providerType = PsBackupProviderTypes.IaasVm;
                    }
                    else
                    {
                        throw new ArgumentException(
                            String.Format(Resources.BackupManagementTypeIncorrectForContainerType,
                            containerType)
                            );
                    }
                    break;
                case ContainerType.Windows:
                    if (backupManagementType == BackupManagementType.MARS)
                    {
                        providerType = PsBackupProviderTypes.Mab;
                    }
                    else if (backupManagementType == null)
                    {
                        throw new ArgumentException(
                            String.Format(
                            Resources.BackupManagementTypeRequiredForContainerType,
                            containerType)
                            );
                    }
                    else
                    {
                        throw new ArgumentException(
                            String.Format(
                            Resources.BackupManagementTypeIncorrectForContainerType,
                            containerType)
                            );
                    }
                    break;
                case ContainerType.AzureSQL:
                    if (backupManagementType == BackupManagementType.AzureSQL ||
                        backupManagementType == null)
                    {
                        providerType = PsBackupProviderTypes.AzureSql;
                    }
                    else
                    {
                        throw new ArgumentException(
                            String.Format(
                            Resources.BackupManagementTypeRequiredForContainerType,
                            containerType));
                    }
                    break;
                default:
                    throw new ArgumentException(
                        String.Format(Resources.UnsupportedContainerType,
                        containerType.ToString())
                        );
            }

            return GetProviderInstance(providerType);
        }

        /// <summary>
        /// To get provider instance for backup management server.
        /// </summary>
        public IPsBackupProvider GetProviderInstanceForBackupManagementServer()
        {
            return GetProviderInstance(PsBackupProviderTypes.Dpm);
        }

        /// <summary>
        /// To get provider instance using workload type.
        /// </summary>
        public IPsBackupProvider GetProviderInstance(WorkloadType workloadType)
        {
            PsBackupProviderTypes providerType = 0;

            switch (workloadType)
            {
                case WorkloadType.AzureVM:
                    providerType = PsBackupProviderTypes.IaasVm;
                    break;
                default:
                    throw new ArgumentException(
                        String.Format(Resources.BackupManagementTypeRequiredForWorkloadType,
                                                     workloadType.ToString()));
            }

            return GetProviderInstance(providerType);
        }

        /// <summary>
        /// To get provider instance using container type.
        /// </summary>
        public IPsBackupProvider GetProviderInstance(ContainerType containerType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// To get provider instance using workload and backup management type.
        /// </summary>
        public IPsBackupProvider GetProviderInstance(
            WorkloadType workloadType, BackupManagementType? backupManagementType)
        {
            PsBackupProviderTypes psProviderType;

            switch (workloadType)
            {
                case WorkloadType.AzureVM:
                    // validate backupManagementType is valid
                    if (backupManagementType.HasValue && backupManagementType
                        != BackupManagementType.AzureVM)
                    {
                        // throw exception that it is not expected
                        throw new ArgumentException(
                            String.Format(Resources.BackupManagementTypeNotExpectedForWorkloadType,
                                                     workloadType.ToString()));
                    }
                    psProviderType = PsBackupProviderTypes.IaasVm;
                    break;
                case WorkloadType.AzureSQLDatabase:
                    // validate backupManagementType is valid
                    if (backupManagementType.HasValue &&
                        backupManagementType != BackupManagementType.AzureSQL)
                    {
                        throw new ArgumentException(
                            String.Format(Resources.BackupManagementTypeNotExpectedForWorkloadType,
                                                     workloadType.ToString()));
                    }
                    psProviderType = PsBackupProviderTypes.AzureSql;
                    break;
                default:
                    throw new ArgumentException(
                        String.Format(Resources.UnsupportedWorkloadTypeException,
                        workloadType.ToString()));
            }

            return GetProviderInstance(psProviderType);
        }

        /// <summary>
        /// To get provider instance using provider type.
        /// </summary>
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

            psBackupProvider.Initialize(providerData, serviceClientAdapter);

            return psBackupProvider;
        }
    }
}
