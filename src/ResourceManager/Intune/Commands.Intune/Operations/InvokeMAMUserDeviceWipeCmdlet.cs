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

namespace Microsoft.Azure.Commands.Intune.Operations
{
    using Microsoft.Azure.Commands.Intune.Properties;
    using Management.Intune.Models;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// Cmdlet to Invoke user device wipe operation.
    /// </summary>
    [Cmdlet("Invoke", "AzureRmIntuneMAMUserDeviceWipe", SupportsShouldProcess = true), OutputType(typeof(WipeDeviceOperationResult))]
    public sealed class InvokeMAMUserDeviceWipeCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the User name 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The User name(Unique Id) for whom the device should be wiped.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets the Device Name(unique Id) 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The device Name for which to invoke wipe.")]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InvokeDeviceWipeOperation();
        }

        /// <summary>
        /// Invoke wipe operation for the user's device
        /// </summary>
        private void InvokeDeviceWipeOperation()
        {
            this.ConfirmAction(
                this.Force,
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.InvokeDeviceWipe_ActionMessage,
                    this.DeviceName,                    
                    this.Name),
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.InvokeDeviceWipe_ProcessMessage,
                    this.DeviceName,
                    this.Name),
                    this.Name,
                () =>
                {
                    var result = 
                    IntuneClient.WipeMAMUserDeviceWithHttpMessagesAsync(
                        this.AsuHostName, 
                        this.Name, 
                        this.DeviceName)
                        .GetAwaiter()
                        .GetResult();

                    this.WriteObject(result.Body);
                });
        }
    }
}