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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class ConversionHelpers
    {
        public static AzureRmRecoveryServicesContainerBase GetContainerModel(ProtectionContainerResource protectionContainer)
        {
            AzureRmRecoveryServicesContainerBase containerModel = null;

            if (protectionContainer != null &&
                protectionContainer.Properties != null)
            {
                if (protectionContainer.Properties.GetType() == typeof(AzureIaaSVMProtectionContainer))
                {
                    new AzureRmRecoveryServicesIaasVmContainer(protectionContainer);
                }
            }

            return containerModel;
        }

        public static List<AzureRmRecoveryServicesContainerBase> GetContainerModelList(IEnumerable<ProtectionContainerResource> protectionContainers)
        {
            List<AzureRmRecoveryServicesContainerBase> containerModels = new List<AzureRmRecoveryServicesContainerBase>();

            foreach (var protectionContainer in protectionContainers)
            {
                containerModels.Add(GetContainerModel(protectionContainer));
            }

            return containerModels;
        }
    }
}
