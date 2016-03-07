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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    public class AzureRmRecoveryServicesObjectBase
    {
        public virtual void Validate()
        {

        } 
    }

    public class AzureRmRecoveryServicesContainerBase : AzureRmRecoveryServicesObjectBase
    {
        /// <summary>
        /// Container Name
        /// </summary>
        public string Name { get; set; }

        public ContainerType ContainerType { get; set; }

        public AzureRmRecoveryServicesContainerBase(ProtectionContainerResource protectionContainer)
        {
            Name = protectionContainer.Name;
        }
    }

    public class AzureRmRecoveryServicesItemBase : AzureRmRecoveryServicesObjectBase
    {
    }

    public class AzureRmRecoveryServicesRecoveryPointBase : AzureRmRecoveryServicesObjectBase
    {
    }

    public class AzureRmRecoveryServicesPolicyBase : AzureRmRecoveryServicesObjectBase
    {
        public BackupManagementType BackupManagementType { get; set; }

        public WorkloadType WorkloadType { get; set; }

        public override void Validate()
        {
        }
    }

    public class AzureRmRecoveryServicesRetentionPolicyBase : AzureRmRecoveryServicesObjectBase
    {
        public override void Validate()
        {
        }
    }

    public class AzureRmRecoveryServicesSchedulePolicyBase : AzureRmRecoveryServicesObjectBase
    {
        public override void Validate()
        {
        }
    }
}
