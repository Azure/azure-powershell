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
    /// <summary>
    /// Microsoft Azure Backup (MAB) Container
    /// </summary>
    public class MabContainer : ContainerBase
    {
        /// <summary>
        /// Friendly name of the container
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Status of registration of the MAB container with the Recovery Services vault
        /// </summary>
        public ContainerRegistrationStatus Status { get; set; }

        public MabContainer(ProtectionContainerResource protectionContainer)
            : base(protectionContainer)
        {
            MabProtectionContainer mabProtectionContainer = (MabProtectionContainer)protectionContainer.Properties;
            FriendlyName = mabProtectionContainer.FriendlyName;
            Status = EnumUtils.GetEnum<ContainerRegistrationStatus>(mabProtectionContainer.RegistrationStatus);
        }
    }
}
