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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;

namespace Microsoft.WindowsAzure.Commands.Profile
{


    [Cmdlet(VerbsCommon.Select, "AzureSubscription", DefaultParameterSetName = "Current")]
    [OutputType(typeof(AzureSubscription))]
    public class SelectAzureSubscriptionCommand : SubscriptionCmdletBase
    {
        public SelectAzureSubscriptionCommand() : base(true)
        {
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "Current", HelpMessage = "Name of subscription to select")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "Default", HelpMessage = "Name of subscription to select")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string SubscriptionName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Current", HelpMessage = "Name of account to select")]
        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Default", HelpMessage = "Name of account to select")]
        [ValidateNotNullOrEmpty]
        public string Account { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Current", HelpMessage = "Switch to set the chosen subscription as the current one")]
        public SwitchParameter Current { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Default", HelpMessage = "Switch to set the chosen subscription as the default one")]
        public SwitchParameter Default { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "NoCurrent", HelpMessage = "Switch to clear the current subscription")]
        public SwitchParameter NoCurrent { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "NoDefault", HelpMessage = "Switch to clear the default subscription")]
        public SwitchParameter NoDefault { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case "Current":
                    WriteObject(ProfileClient.SetSubscriptionAsCurrent(SubscriptionName, Account));
                    break;

                case "Default":
                    WriteObject(ProfileClient.SetSubscriptionAsDefault(SubscriptionName, Account));
                    break;

                case "NoCurrent":
                    AzureSession.SetCurrentContext(null, null, null);
                    break;

                case "NoDefault":
                    ProfileClient.ClearDefaultSubscription();
                    break;
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}