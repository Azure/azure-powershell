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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-FrontDoorWafLogScrubbingSettingObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafLogScrubbingSettingObject"), OutputType(typeof(PSFrontDoorWafLogScrubbingSetting))]
    public class NewFrontDoorWafLogScrubbingSettingObject : AzureFrontDoorCmdletBase
    {

        /// <summary>
        /// List of log scrubbing rules applied to the Web Application Firewall logs.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "List of log scrubbing rules applied to the Web Application Firewall logs.")]
        [AllowEmptyCollection]
        public PSFrontDoorWafLogScrubbingRule[] ScrubbingRule { get; set; }

        /// State of the log scrubbing config. Default value is Enabled.
        [Parameter(Mandatory = true, HelpMessage = "State of the log scrubbing config. Default value is Enabled.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string State { get; set; }

        public override void ExecuteCmdlet()
        {
            var FrontDoorWafLogScrubbingSettingObject = new PSFrontDoorWafLogScrubbingSetting
            {
                ScrubbingRule = ScrubbingRule,
                State = State
            };
            WriteObject(FrontDoorWafLogScrubbingSettingObject);
        }

    }
}
