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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Profile.Models;

namespace Microsoft.WindowsAzure.Commands.Profile
{


    [Cmdlet(VerbsCommon.Select, "AzureSubscription", DefaultParameterSetName = SelectSubscriptionByNameParameterSet)]
    [OutputType(typeof(PSAzureSubscription))]
    public class SelectAzureSubscriptionCommand : SubscriptionCmdletBase
    {
        private const string SelectSubscriptionByIdParameterSet = "SelectSubscriptionByIdParameterSet";

        private const string SelectSubscriptionByNameParameterSet = "SelectSubscriptionByNameParameterSet";

        private const string SelectDefaultSubscriptionByIdParameterSet = "SelectDefaultSubscriptionByIdParameterSet";

        private const string SelectDefaultSubscriptionByNameParameterSet = "SelectDefaultSubscriptionByNameParameterSet";

        private const string NoCurrentSubscriptionParameterSet = "NoCurrentSubscriptionParameterSet";

        private const string NoDefaultSubscriptionParameterSet = "NoDefaultSubscriptionParameterSet";


        public SelectAzureSubscriptionCommand() : base(true)
        {
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            ParameterSetName = SelectSubscriptionByNameParameterSet, HelpMessage = "Name of subscription to select")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = SelectDefaultSubscriptionByNameParameterSet, HelpMessage = "Name of subscription to select")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string SubscriptionName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = SelectSubscriptionByIdParameterSet, HelpMessage = "Id of subscription to select")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = SelectDefaultSubscriptionByIdParameterSet, HelpMessage = "Id of subscription to select")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of account to select")]
        [ValidateNotNullOrEmpty]
        public string Account { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SelectSubscriptionByIdParameterSet, 
            HelpMessage = "Switch to set the chosen subscription as the current one")]
        [Parameter(Mandatory = false, ParameterSetName = SelectSubscriptionByNameParameterSet,
            HelpMessage = "Switch to set the chosen subscription as the current one")]
        public SwitchParameter Current { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SelectDefaultSubscriptionByIdParameterSet, 
            HelpMessage = "Switch to set the chosen subscription as the default one")]
        [Parameter(Mandatory = true, ParameterSetName = SelectDefaultSubscriptionByNameParameterSet,
            HelpMessage = "Switch to set the chosen subscription as the default one")]
        public SwitchParameter Default { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NoCurrentSubscriptionParameterSet, 
            HelpMessage = "Switch to clear the current subscription")]
        public SwitchParameter NoCurrent { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NoDefaultSubscriptionParameterSet, 
            HelpMessage = "Switch to clear the default subscription")]
        public SwitchParameter NoDefault { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            AzureSubscription azureSubscription = null;
            switch (ParameterSetName)
            {
                case SelectSubscriptionByNameParameterSet:
                    azureSubscription = ProfileClient.SetSubscriptionAsDefault(SubscriptionName, GetAccount());
                    break;

                case SelectSubscriptionByIdParameterSet:
                    azureSubscription = ProfileClient.SetSubscriptionAsDefault(SubscriptionIdAsGuid(), GetAccount());
                    break;

                case SelectDefaultSubscriptionByNameParameterSet:
                    azureSubscription = ProfileClient.SetSubscriptionAsDefault(SubscriptionName, GetAccount());
                    WriteWarning("Current and Default parameters have been deprecated. Select-AzureSubscription will always update the Default Subscription.");
                    break;

                case SelectDefaultSubscriptionByIdParameterSet:
                    azureSubscription = ProfileClient.SetSubscriptionAsDefault(SubscriptionIdAsGuid(), GetAccount());
                    WriteWarning("Current and Default parameters have been deprecated. Select-AzureSubscription will always update the Default Subscription.");
                    break;

                case NoCurrentSubscriptionParameterSet:
                    WriteWarning("Current parameter set has been deprecated. Use Select-AzureSubscription -NoDefault instead.");
                    break;

                case NoDefaultSubscriptionParameterSet:
                    ProfileClient.ClearDefaultSubscription();
                    break;
            }

            if (PassThru.IsPresent && azureSubscription != null)
            {
                WriteObject(new PSAzureSubscription(azureSubscription, ProfileClient.Profile));
            }
        }

        /// <summary>
        /// Returns Account specified in the parameter or current account of the subscription
        /// </summary>
        /// <returns></returns>
        private string GetAccount()
        {
            if (!string.IsNullOrEmpty(Account))
            {
                return Account;
            }

            AzureSubscription subscription = ProfileClient.Profile.Subscriptions.Values
                .Where(s => !string.IsNullOrWhiteSpace(s.Name))
                .FirstOrDefault(s => s.Name.Equals(SubscriptionName, StringComparison.InvariantCultureIgnoreCase) ||
                                     s.Id.ToString().Equals(SubscriptionId, StringComparison.InvariantCultureIgnoreCase));

            if (subscription != null)
            {
                return subscription.Account;
            }
            else
            {
                return null;
            }
        }

        private Guid SubscriptionIdAsGuid()
        {
            Guid subscriptionIdGuid;
            if (!Guid.TryParse(SubscriptionId, out subscriptionIdGuid))
            {
                throw new ArgumentException(string.Format(Resources.InvalidGuid, SubscriptionId), "SubscriptionId");
            }
            return subscriptionIdGuid;
        }
    }
}