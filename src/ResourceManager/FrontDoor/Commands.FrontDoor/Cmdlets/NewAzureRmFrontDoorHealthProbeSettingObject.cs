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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorHealthProbeSettingObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorHealthProbeSettingObject"), OutputType(typeof(PSHealthProbeSetting))]
    public class NewAzureRmFrontDoorHealthProbeSettingObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Gets or sets the health probe setting name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "health probe setting name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The path to use for the health probe. Default is /
        /// </summary>
        [Parameter(Mandatory = false,  HelpMessage = "The path to use for the health probe. Default value is /")]
        public string Path { get; set; }

        /// <summary>
        /// Protocol scheme to use for this probe
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Protocol scheme to use for this probe. Default value is HTTP")]
        public PSProtocol Protocol { get; set; }

        /// <summary>
        /// The number of seconds between health probes.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The number of seconds between health probes.  Default value is 30")]
        public int IntervalInSeconds { get; set; }



        public override void ExecuteCmdlet()
        {
            var HealthProbeSetting = new PSHealthProbeSetting
            {
                Name = Name,
                Path = !this.IsParameterBound(c => c.Path)? "/" : Path,
                Protocol = !this.IsParameterBound(c => c.Protocol) ? PSProtocol.Http : Protocol,
                IntervalInSeconds = !this.IsParameterBound(c => c.IntervalInSeconds) ? 30 : IntervalInSeconds
            };
            WriteObject(HealthProbeSetting);
        }
    }
}
