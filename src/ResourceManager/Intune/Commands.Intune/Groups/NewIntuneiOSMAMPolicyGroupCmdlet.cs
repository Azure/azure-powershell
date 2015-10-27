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
    using System;
    using System.Management.Automation;
    using RestClient;
    using RestClient.Models;

    /// <summary>
    /// A cmdlet to link a group to Android Intune MAM policy Azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmIntuneiOSMAMPolicyGroup", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public sealed class NewIntuneiOSMAMPolicyGroupCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the policy name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The iOS policy name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Group name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The iOS group name to link to.")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }
        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            Action action = () =>
            {
                this.ConfirmAction(
                    this.Force,
                    "Are you sure you want to link Group with name:" + this.GroupName + " to iOS policy with name:" + this.Name,
                    "Link the group with iOS policy resource.",
                    this.Name,
                    () =>
                    {
                        this.IntuneClient.AddGroupForiOSMAMPolicy(this.AsuHostName, this.Name, this.GroupName, PrepareMAMPolicyAppIdGroupIdPayload());
                        this.WriteObject("Operation completed successfully");
                    });
            };

            base.SafeExecutor(action);
        }

        private MAMPolicyAppIdOrGroupIdPayload PrepareMAMPolicyAppIdGroupIdPayload()
        {
            string groupUri = string.Format(IntuneConstants.GroupUriFormat, this.IntuneClient.BaseUri.Host, this.AsuHostName, this.GroupName);
            var groupIdPayload = new MAMPolicyAppIdOrGroupIdPayload();
            groupIdPayload.Properties = new MAMPolicyAppOrGroupIdProperties()
            {
                Url = groupUri
            };

            return groupIdPayload;
        }
    }
}