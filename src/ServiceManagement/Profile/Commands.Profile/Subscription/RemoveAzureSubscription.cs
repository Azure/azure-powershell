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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Removes a previously imported subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSubscription", SupportsShouldProcess = true, DefaultParameterSetName = "Name")]
    [OutputType(typeof(AzureSubscription))]
    public class RemoveAzureSubscriptionCommand : SubscriptionCmdletBase
    {
        public RemoveAzureSubscriptionCommand() : base(true)
        {
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the subscription.", ParameterSetName = "Name")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string SubscriptionName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the subscription.", ParameterSetName = "Id")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 2, HelpMessage = "Do not confirm deletion of subscription")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 3, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public void RemoveSubscriptionProcess()
        {
            if (SubscriptionName != null)
            {
                ProfileClient.RemoveSubscription(SubscriptionName);
            }
            else
            {
                ProfileClient.RemoveSubscription(new Guid(SubscriptionId));
            }
        }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveSubscriptionConfirmation, SubscriptionName ?? SubscriptionId),
                Resources.RemoveSubscriptionMessage,
                SubscriptionName,
                RemoveSubscriptionProcess);
        }
    }
}
