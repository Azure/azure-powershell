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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Store;

namespace Microsoft.WindowsAzure.Commands.Store
{
    /// <summary>
    /// Removes all purchased Add-Ons or specific Add-On
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStoreAddOn"), OutputType(typeof(List<PSObject>))]
    public class RemoveAzureStoreAddOnCommand : ServiceManagementBaseCmdlet
    {
        public StoreClient StoreClient { get; set; }

        public PowerShellCustomConfirmation CustomConfirmation;

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Add-On name")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Get result of the cmdlet")]
        public SwitchParameter PassThru { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            StoreClient = StoreClient ?? new StoreClient(Profile, Profile.Context.Subscription);
            CustomConfirmation = CustomConfirmation ?? new PowerShellCustomConfirmation(Host);

            string message = StoreClient.GetConfirmationMessage(OperationType.Remove);
            bool remove = CustomConfirmation.ShouldProcess(Resources.RemoveAddOnConformation, message);
            if (remove)
            {
                StoreClient.RemoveAddOn(Name);
                WriteVerbose(string.Format(Resources.AddOnRemovedMessage, Name));
                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}