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
using System.Management.Automation;
using System.Xml;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssLifecycleHookConfig", SupportsShouldProcess = true)]
    [OutputType(typeof(LifecycleHook))]
    public class NewAzureRmVmssLifecycleHookConfigCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the type of the lifecycle hook. Possible values: 'UpgradeAutoOSScheduling', 'UpgradeAutoOSRollingBatchStarting'.")]
        [PSArgumentCompleter("UpgradeAutoOSScheduling", "UpgradeAutoOSRollingBatchStarting")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the time duration the lifecycle hook event waits for a customer response before applying the default action. Must be in ISO 8601 duration format, for example 'PT8H' (8 hours) or 'PT30M' (30 minutes).")]
        public string WaitDuration { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the default action applied when the wait duration expires with no customer response. Accepted values: 'Approve', 'Reject'. If omitted, the service applies its own default.")]
        [PSArgumentCompleter("Approve", "Reject")]
        [ValidateSet("Approve", "Reject")]
        public string DefaultAction { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("VmssLifecycleHookConfig", "New"))
            {
                TimeSpan? waitDuration = null;
                if (!string.IsNullOrEmpty(this.WaitDuration))
                {
                    waitDuration = XmlConvert.ToTimeSpan(this.WaitDuration);
                }

                var hook = new LifecycleHook
                {
                    Type = this.Type,
                    WaitDuration = waitDuration,
                    // When the customer does not supply -DefaultAction, leave it null so the SDK
                    // (NullValueHandling.Ignore) omits it from the request and the service applies
                    // its own default for the hook type.
                    DefaultAction = this.DefaultAction
                };

                WriteObject(hook);
            }
        }
    }
}
