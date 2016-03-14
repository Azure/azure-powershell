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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class JobConversions
    {
        #region Hydra to PS convertors

        public static AzureRmRecoveryServicesJobBase GetPSJob(JobResponse hydraJob)
        {
            AzureRmRecoveryServicesJobBase response = null;

            if (hydraJob.Item.Properties.GetType() == typeof(AzureIaaSVMJob))
            {
                response = GetPSAzureVmJob(hydraJob);
            }

            return response;
        }

        public static AzureRmRecoveryServicesAzureVmJob GetPSAzureVmJob(JobResponse hydraJob)
        {
            AzureRmRecoveryServicesAzureVmJob response = new AzureRmRecoveryServicesAzureVmJob();

            response.InstanceId = hydraJob.Item.Id;
            // TODO: Fill complete conversion

            return response;
        }

        #endregion
    }
}
