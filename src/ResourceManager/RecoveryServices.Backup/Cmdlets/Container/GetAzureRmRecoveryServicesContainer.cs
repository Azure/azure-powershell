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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    class GetAzureRmRecoveryServicesContainer : RecoveryServicesBackupCmdletBase
    {
        PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<string, object>()
            {
                {GetContainerParams.Name.ToString(), "Param1Value"}, 
                {GetContainerParams.Status.ToString(), "Param2Value"}
            });

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(ContainerType.AzureVM);
        }
    }
}
