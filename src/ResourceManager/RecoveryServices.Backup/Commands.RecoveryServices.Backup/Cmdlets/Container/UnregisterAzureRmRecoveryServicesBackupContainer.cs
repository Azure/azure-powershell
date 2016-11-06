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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Unregisters container from the recovery services vault.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureRmRecoveryServicesBackupContainer")]
    public class UnregisterAzureRmRecoveryServicesBackupContainer 
        : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// Container model object to be unregistered from the vault.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, 
            HelpMessage = ParamHelpMsgs.Container.RegisteredContainer)]
        [ValidateNotNullOrEmpty]
        public ContainerBase Container { get; set; }        

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                
                if (!((Container.ContainerType == ContainerType.Windows && 
                       Container.BackupManagementType == BackupManagementType.MARS) ||
                    (Container.ContainerType == ContainerType.AzureSQL && 
                     Container.BackupManagementType == BackupManagementType.AzureSQL)))
                {
                    throw new ArgumentException(String.Format(Resources.UnsupportedContainerException, 
                        Container.ContainerType, Container.BackupManagementType));
                }
                string containerName = Container.Name;
                
                if (Container.ContainerType == ContainerType.AzureSQL)
                {
                    containerName = ContainerConstansts.SqlContainerNamePrefix + containerName;
                }

                ServiceClientAdapter.UnregisterContainers(containerName);
            });
        }
    }
}

