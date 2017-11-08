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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    /// Gets Azure Site Recovery Notification / Alert Settings.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get, 
        "AzureRmRecoveryServicesAsrAlertSetting")]
    [Alias(
        "Get-ASRNotificationSetting",
        "Get-AzureRmRecoveryServicesAsrNotificationSetting",
        "Get-ASRAlertSetting")]
    [OutputType(typeof(IEnumerable<ASRAlertSetting>))]
    public class GetAzureRmRecoveryServicesAsrAlertSetting : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            var alertSetting =
               this.RecoveryServicesClient.GetAzureSiteRecoveryAlertSetting();
            this.WriteObject(alertSetting.Select(p => new ASRAlertSetting(p)), true);
        }
    }
}