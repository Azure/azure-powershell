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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    public class AzureRmRecoveryServicesAzureVmJob : AzureRmRecoveryServicesJobBase
    {
        public bool IsCancellable { get; set; }

        public bool IsRetriable { get; set; }

        public string VmVersion { get; set; }

        public List<AzureRmRecoveryServicesAzureVmJobErrorInfo> ErrorDetails { get; set; }
    }

    public class AzureRmRecoveryServicesAzureVmJobDetails : AzureRmRecoveryServicesAzureVmJob
    {
        /// <summary>
        /// Context sensitive error message that might be helpful in debugging the issue. 
        /// Mostly this contains trace dumps from VM.
        /// </summary>
        public string DynamicErrorMessage { get; set; }

        public Dictionary<string, string> Properties { get; set; }

        public List<AzureRmRecoveryServicesAzureVmJobSubTask> SubTasks { get; set; }
    }

    public class AzureRmRecoveryServicesAzureVmJobErrorInfo : AzureRmRecoveryServicesJobErrorInfoBase
    {
        public int ErrorCode { get; set; }
    }

    public class AzureRmRecoveryServicesAzureVmJobSubTask : AzureRmRecoveryServicesJobSubTaskBase
    {
    }
}
