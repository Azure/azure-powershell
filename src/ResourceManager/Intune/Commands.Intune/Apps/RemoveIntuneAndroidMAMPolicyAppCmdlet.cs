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
    using System.Net;

    /// <summary>
    /// A cmdlet to remove a linked app from Android Intune MAM policy Azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntuneAndroidMAMPolicyApp", SupportsShouldProcess = true)]
    public sealed class RemoveIntuneAndroidMAMPolicyAppCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the policy name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Android policy Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the App name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Android App name to remove.")]
        [ValidateNotNullOrEmpty]
        public string AppName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional. Default value is false.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                this.Force,
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.RemoveLinkedResource_ActionMessage, 
                    Resources.App, 
                    this.AppName,
                    Resources.AndroidPolicy, 
                    this.Name),
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.RemoveLinkedResource_ProcessMessage,
                    Resources.App,
                    this.AppName,
                    Resources.AndroidPolicy,
                    this.Name),
                this.Name,
                () =>
                {
                    var result = IntuneClient.Android.DeleteAppForMAMPolicyWithHttpMessagesAsync(this.AsuHostName, this.Name, this.AppName).GetAwaiter().GetResult();
                    if (result.Response.StatusCode == HttpStatusCode.NoContent)
                    {
                        this.WriteWarning(Resources.NoItemsDeleted);
                    }

                    if (PassThru)
                    {
                        this.WriteObject(result.Response.StatusCode == HttpStatusCode.OK ? true : false);                                             
                    }

                });
        }
    }
}