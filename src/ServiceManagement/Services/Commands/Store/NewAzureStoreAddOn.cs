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
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Store;

namespace Microsoft.WindowsAzure.Commands.Store
{
    /// <summary>
    /// Purchase a new Add-On from Microsoft Azure Store.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStoreAddOn"), OutputType(typeof(bool))]
    public class NewAzureStoreAddOnCommand : ServiceManagementBaseCmdlet
    {
        public StoreClient StoreClient { get; set; }

        public PowerShellCustomConfirmation CustomConfirmation;

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Add-On name")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Add-On id")]
        public string AddOn { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Add-On plan id")]
        public string Plan { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Add-On location")]
        public string Location { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Add-On promotion code")]
        public string PromotionCode { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            StoreClient = StoreClient ?? new StoreClient(Profile, Profile.Context.Subscription);
            WindowsAzureAddOn addon;
            CustomConfirmation = CustomConfirmation ?? new PowerShellCustomConfirmation(Host);

            if (!StoreClient.TryGetAddOn(Name, out addon))
            {
                string message = StoreClient.GetConfirmationMessage(OperationType.New, AddOn, Plan);
                bool purchase = CustomConfirmation.ShouldProcess(Resources.NewAddOnConformation, message);

                if (purchase)
                {
                    StoreClient.NewAddOn(Name, AddOn, Plan, Location, PromotionCode);
                    WriteVerbose(string.Format(Resources.AddOnCreatedMessage, Name));
                    WriteObject(true);
                }
            }
            else
            {
                throw new Exception(string.Format(Resources.AddOnNameAlreadyUsed, Name));
            }
        }
    }
}