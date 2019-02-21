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
    /// Defines the New-AzFrontDoorLoadBalancingSettingObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorLoadBalancingSettingObject"), OutputType(typeof(PSLoadBalancingSetting))]
    public class NewAzureRmFrontDoorLoadBalancingSettingObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Gets or sets the health probe setting name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "health probe setting name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The number of samples to consider for load balancing decisions
        /// </summary>
        [Parameter(Mandatory = false,  HelpMessage = "The number of samples to consider for load balancing decisions.Default value is 4")]
        public int SampleSize { get; set; }

        /// <summary>
        /// The number of samples within the sample period that must succeed
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The number of samples within the sample period that must succeed. Default value is 2")]
        public int SuccessfulSamplesRequired { get; set; }

        /// <summary>
        /// The additional latency in milliseconds for probes to fall into the lowest latency bucket
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The additional latency in milliseconds for probes to fall into the lowest latency bucket. Default value is 0")]
        public int AdditionalLatencyInMilliseconds { get; set; }



        public override void ExecuteCmdlet()
        {
            var LoadBalancingSetting = new PSLoadBalancingSetting
            {
                Name = Name,
                SampleSize = !this.IsParameterBound(c => c.SampleSize) ? 4 : SampleSize,
                AdditionalLatencyMilliseconds = !this.IsParameterBound(c => c.AdditionalLatencyInMilliseconds)? 0 : AdditionalLatencyInMilliseconds,
                SuccessfulSamplesRequired = !this.IsParameterBound(c => c.SuccessfulSamplesRequired) ? 2 : SuccessfulSamplesRequired
            };
            WriteObject(LoadBalancingSetting);
        }
        
    }
}
