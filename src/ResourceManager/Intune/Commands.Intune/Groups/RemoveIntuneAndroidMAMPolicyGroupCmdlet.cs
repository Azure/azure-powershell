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

    /// <summary>
    /// A cmdlet to link a group to Android Intune MAM policy Azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntuneAndroidMAMPolicyGroup", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public sealed class RemoveIntuneAndroidMAMPolicyGroupCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the policy id
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Android policy name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the App id
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The group name for Android policy to remove.")]
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
                    "Are you sure you want to remove group with name:" + this.GroupName + " from android policy with name:" + this.Name,
                    "Remove the group from android policy resource...",
                    this.Name,
                    () =>
                    {
                        this.IntuneClient.DeleteGroupForAndroidMAMPolicy(this.AsuHostName, this.Name, this.GroupName);
                        this.WriteObject("Operation completed successfully");
                    });
            };

            base.SafeExecutor(action);
        }
    }
}