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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    class RecoveryPointConversions
    {
        public static List<AzureRmRecoveryServicesRecoveryPointBase> GetPSAzureRecoveryPoints(RecoveryPointListResponse rpList)
        {
            if (rpList == null) 
            { 
                throw new ArgumentNullException("rpList is null"); 
            }

            List<AzureRmRecoveryServicesRecoveryPointBase> result = new List<AzureRmRecoveryServicesRecoveryPointBase>();
            foreach(var rp in rpList)
            {

            }
        }

        public static List<AzureRmRecoveryServicesRecoveryPointBase> GetPSAzureRecoveryPoints(RecoveryPointResponse rp)
        {

        }
    }
}
