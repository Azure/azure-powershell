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

using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Enables reregistration of a machine container
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "AzureRmBackupContainerReregistration")]
    public class EnableAzureRMBackupContainerReregistration : AzureBackupContainerCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                AzureBackupContainerType containerType = (AzureBackupContainerType)Enum.Parse(typeof(AzureBackupContainerType), Container.ContainerType);
                switch (containerType)
                {
                    case AzureBackupContainerType.Windows:
                    case AzureBackupContainerType.SCDPM:
                    case AzureBackupContainerType.AzureBackupServer:
                    case AzureBackupContainerType.Other:
                        AzureBackupClient.EnableMachineContainerReregistration(Container.ResourceGroupName, Container.ResourceName, Container.Id);
                        break;
                    default:
                        throw new ArgumentException(Resources.CannotEnableRegistration);
                }
            });
        }
    }
}
