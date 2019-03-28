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

using System;
using System.Collections;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-FrontDoorBackendPoolsSettingObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorBackendPoolsSettingObject"), OutputType(typeof(PSBackendPoolsSetting))]
    public class NewAzureRmFrontDoorBackendPoolsSettingObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Whether to enforce certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Whether to enforce certificate name check on HTTPS requests to all backend pools. No effect on non-HTTPS requests.")]
        public SwitchParameter DisableCertificateNameCheck { get; set; }

        public override void ExecuteCmdlet()
        {
            var backendPoolsSetting = new PSBackendPoolsSetting
            {
                EnforceCertificateNameCheck = DisableCertificateNameCheck == true ? PSEnforceCertificateNameCheck.Disabled : PSEnforceCertificateNameCheck.Enabled
            };
            WriteObject(backendPoolsSetting);
        }
    }
}