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

namespace Microsoft.Azure.Commands.Intune
{
    using Management.Intune;
    using Microsoft.Azure.Commands.Intune.Properties;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// A cmdlet to remove a linked app from an iOS Intune MAM policy Azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntuneiOSMAMPolicyApp", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public sealed class RemoveIntuneiOSMAMPolicyAppCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the policy name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The iOS policy name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the App name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The iOS App Name to remove.")]
        [ValidateNotNullOrEmpty]
        public string AppName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }
        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            this.ConfirmAction(
                this.Force,
                string.Format(
                    CultureInfo.CurrentCulture, 
                    Resources.RemoveLinkedResource_ActionMessage, 
                    Resources.App, 
                    this.AppName, 
                    Resources.IosPolicy, 
                    this.Name),
                string.Format(
                    CultureInfo.CurrentCulture, 
                    Resources.RemoveLinkedResource_ProcessMessage, 
                    Resources.App, 
                    this.AppName, 
                    Resources.IosPolicy, 
                    this.Name),
                    this.Name,
                () =>
                {
                    var result = IntuneClient.Ios.DeleteAppForMAMPolicyWithHttpMessagesAsync(this.AsuHostName, this.Name, this.AppName).GetAwaiter().GetResult();
                    if (result.Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        this.WriteObject(Resources.OneItemDeleted);
                    }
                    else
                    {
                        this.WriteObject(Resources.NoItemsDeleted);
                    }
                });
        }
    }
}
