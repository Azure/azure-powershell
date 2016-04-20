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
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Intune.Properties;
    using System.Net;

    /// <summary>
    /// A cmdlet that removes Intune iOS MAM Policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntuneIOSMAMPolicy", SupportsShouldProcess = true, DefaultParameterSetName = IntuneBaseCmdlet.DefaultParameterSet)]
    public class RemoveIntuneiOSMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        #region params
        /// <summary>
        /// The iOS policy Id
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The iOS Policy Name (Policy Guid) to remove the policy.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional. Default value is false.")]
        public SwitchParameter PassThru { get; set; }
        #endregion params

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.ConfirmAction
            (
                this.Force,
                string.Format(CultureInfo.CurrentCulture, Resources.DeleteResource_ActionMessage, Resources.IosPolicy, this.Name),
                string.Format(CultureInfo.CurrentCulture, Resources.DeleteResource_ProcessMessage, Resources.IosPolicy, this.Name),
                this.Name,
                () =>
                {
                    var result = this.IntuneClient.Ios.DeleteMAMPolicyWithHttpMessagesAsync(this.AsuHostName, this.Name).GetAwaiter().GetResult();                                        
                    if (result.Response.StatusCode == HttpStatusCode.NoContent)
                    {
                        this.WriteWarning(Resources.NoItemsDeleted);
                    }

                    if (PassThru)
                    {
                        this.WriteObject(result.Response.StatusCode == HttpStatusCode.OK ? true : false);
                    }
                }
             );
        }
    }
}