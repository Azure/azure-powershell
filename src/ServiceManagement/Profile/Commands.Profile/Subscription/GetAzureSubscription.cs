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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using Microsoft.WindowsAzure.Management;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Implementation of the get-azuresubscription cmdlet that works against
    /// the AzureSMProfile layer.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSubscription", DefaultParameterSetName = "ByName")]
    [OutputType(typeof(PSAzureSubscription))]
    public class GetAzureSubscriptionCommand : SubscriptionCmdletBase
    {
        public GetAzureSubscriptionCommand()
            : base(true)
        {

        }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the subscription", ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string SubscriptionName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "ID of the subscription", ParameterSetName = "ById")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Retrieves the default subscription", ParameterSetName = "Default")]
        public SwitchParameter Default { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Retrieves the current subscription", ParameterSetName = "Current")]
        public SwitchParameter Current { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Retrieves extended details about subscription such as quota and usage")]
        public SwitchParameter ExtendedDetails { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case "ByName":
                    IEnumerable<AzureSubscription> subscriptions = new AzureSubscription[0];
                    if (Profile.Context != null && Profile.Context.Environment != null)
                    {
                        subscriptions = ProfileClient.RefreshSubscriptions(Profile.Context.Environment)
                            .Where(
                                s =>
                                    SubscriptionName == null ||
                                    s.Name.Equals(SubscriptionName, StringComparison.InvariantCultureIgnoreCase));
                    }

                    WriteSubscriptions(subscriptions);
                    break;
                case "ById":
                    WriteSubscriptions(ProfileClient.GetSubscription(new Guid(SubscriptionId)));
                    break;
                case "Default":
                    GetDefault();
                    break;
                case "Current":
                    GetCurrent();
                    break;
            }
        }

        public void GetDefault()
        {
            var defaultSubscription = ProfileClient.Profile.DefaultSubscription;

            if (defaultSubscription == null)
            {
                WriteError(new ErrorRecord(
                    new InvalidOperationException(Resources.InvalidDefaultSubscription),
                    string.Empty,
                    ErrorCategory.InvalidData, null));
            }
            else
            {
                WriteSubscriptions(defaultSubscription);
            }
        }

        public void GetCurrent()
        {
            //
            // Explicitly ignore the SubscriptionDataFile property here,
            // since current is strictly in-memory and we want the real
            // current subscription.
            //
            if (Profile.Context.Subscription == null)
            {
                WriteError(new ErrorRecord(
                    new InvalidOperationException(Resources.InvalidSelectedSubscription),
                    string.Empty,
                    ErrorCategory.InvalidData, null));
            }
            else
            {
                WriteSubscriptions(Profile.Context.Subscription);
            }
        }

        private void WriteSubscriptions(params AzureSubscription[] subscriptions)
        {
            WriteSubscriptions((IEnumerable<AzureSubscription>)subscriptions);
        }

        private void WriteSubscriptions(IEnumerable<AzureSubscription> subscriptions)
        {
            IEnumerable<PSAzureSubscription> subscriptionOutput;

            if (ExtendedDetails.IsPresent)
            {
                subscriptionOutput = subscriptions.Select(s => ConstructPsAzureSubscriptionExtended(s, AzureSession.ClientFactory));
            }
            else
            {
                subscriptionOutput = subscriptions.Select(s => new PSAzureSubscription(s, ProfileClient.Profile));
            }

            WriteObject(subscriptionOutput, true);
        }

        private PSAzureSubscriptionExtended ConstructPsAzureSubscriptionExtended(AzureSubscription subscription, IClientFactory clientFactory)
        {
            using (var client = clientFactory.CreateClient<ManagementClient>(Profile, subscription, AzureEnvironment.Endpoint.ServiceManagement))
            {
                var response = client.Subscriptions.Get();
                var environment = ProfileClient.GetEnvironmentOrDefault(subscription.Environment);
                var account = ProfileClient.Profile.Accounts[subscription.Account];
                bool isCert = account.Type == AzureAccount.AccountType.Certificate;
                var psAzureSubscription = new PSAzureSubscription(subscription, ProfileClient.Profile);
                PSAzureSubscriptionExtended result = new PSAzureSubscriptionExtended(psAzureSubscription)
                {
                    AccountAdminLiveEmailId = response.AccountAdminLiveEmailId,
                    ActiveDirectoryUserId = subscription.Account,
                    CurrentCoreCount = response.CurrentCoreCount,
                    CurrentHostedServices = response.CurrentHostedServices,
                    CurrentDnsServers = response.CurrentDnsServers,
                    CurrentLocalNetworkSites = response.CurrentLocalNetworkSites,
                    CurrentStorageAccounts = response.CurrentStorageAccounts,
                    CurrentVirtualNetworkSites = response.CurrentVirtualNetworkSites,
                    MaxCoreCount = response.MaximumCoreCount,
                    MaxDnsServers = response.MaximumDnsServers,
                    MaxHostedServices = response.MaximumHostedServices,
                    MaxLocalNetworkSites = response.MaximumLocalNetworkSites,
                    MaxStorageAccounts = response.MaximumStorageAccounts,
                    MaxVirtualNetworkSites = response.MaximumVirtualNetworkSites,
                    ServiceAdminLiveEmailId = response.ServiceAdminLiveEmailId,
                    SubscriptionRealName = response.SubscriptionName,
                    SubscriptionStatus = response.SubscriptionStatus.ToString(),
                    ServiceEndpoint = environment.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement),
                    ResourceManagerEndpoint = environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager),
                    IsDefault = subscription.GetProperty(AzureSubscription.Property.Default) != null,
                    Account = account,
                    Certificate = isCert ? AzureSession.DataStore.GetCertificate(subscription.Account) : null,
                    CurrentStorageAccountName = subscription.GetProperty(AzureSubscription.Property.StorageAccount)
                };

                return result;
            }
        }
    }
}
