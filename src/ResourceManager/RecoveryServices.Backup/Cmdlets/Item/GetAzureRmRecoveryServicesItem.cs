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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesItem"), OutputType(typeof(List<AzureRmRecoveryServicesItemBase>), typeof(AzureRmRecoveryServicesItemBase))]
    public class GetAzureRmRecoveryServicesItem : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesContainerBase Container { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Item.AzureVMName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
    }
}
