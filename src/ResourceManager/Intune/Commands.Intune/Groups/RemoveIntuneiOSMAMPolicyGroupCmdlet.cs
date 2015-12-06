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
    using Microsoft.Azure.Commands.Intune.Properties;
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;

    /// <summary>
    /// A cmdlet to remove a linked group from an iOS Intune MAM policy Azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntuneiOSMAMPolicyGroup", SupportsShouldProcess = true)]
    public sealed class RemoveIntuneiOSMAMPolicyGroupCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the policy name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The iOS policy name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The group name for iOS policy to remove.")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

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
                    Resources.Group, 
                    this.GroupName, 
                    Resources.IosPolicy, 
                    this.Name),
                string.Format(
                    CultureInfo.CurrentCulture, 
                    Resources.RemoveLinkedResource_ProcessMessage, 
                    Resources.Group, 
                    this.GroupName, 
                    Resources.IosPolicy, 
                    this.Name),
                this.Name,
                () =>
                {
                    var result = IntuneClient.Ios.DeleteGroupForMAMPolicyWithHttpMessagesAsync(this.AsuHostName, this.Name, this.GroupName).GetAwaiter().GetResult();
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