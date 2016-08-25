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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;

namespace Microsoft.WindowsAzure.Commands.Profile
{


    /// <summary>
    /// Removes a Microsoft Azure environment.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureEnvironment"), OutputType(typeof(PSAzureEnvironment))]
    public class RemoveAzureEnvironmentCommand : SubscriptionCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The environment name")]
        public string Name { get; set; }

        [Parameter(Position = 1, HelpMessage = "Do not confirm deletion of subscription")]
        public SwitchParameter Force { get; set; }

        public RemoveAzureEnvironmentCommand() : base(true) { }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveEnvironmentConfirmation, Name),
                Resources.RemoveEnvironmentMessage,
                Name,
                RemoveEnvironmentProcess);
        }

        public void RemoveEnvironmentProcess()
        {
            WriteObject((PSAzureEnvironment)(ProfileClient.RemoveEnvironment(Name)));
        }
    }
}
