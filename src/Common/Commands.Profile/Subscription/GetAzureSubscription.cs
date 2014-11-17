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
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using Microsoft.WindowsAzure.Management;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Implementation of the get-azuresubscription cmdlet that works against
    /// the AzureProfile layer.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSubscription", DefaultParameterSetName = "ByName")]
    [OutputType(typeof(AzureSubscription))]
    public class GetAzureSubscriptionCommand : SubscriptionCmdletBase
    {
        public GetAzureSubscriptionCommand() : base(true)
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
                    WriteSubscriptions(ProfileClient.RefreshSubscriptions(AzureSession.CurrentContext.Environment)
                        .Where(s => SubscriptionName == null || s.Name.Equals(SubscriptionName, StringComparison.InvariantCultureIgnoreCase)));
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
            if (AzureSession.CurrentContext.Subscription == null)
            {
                WriteError(new ErrorRecord(
                    new InvalidOperationException(Resources.InvalidSelectedSubscription),
                    string.Empty,
                    ErrorCategory.InvalidData, null));
            }
            else
            {
                WriteSubscriptions(AzureSession.CurrentContext.Subscription);
            }
        }

        private void WriteSubscriptions(params AzureSubscription[] subscriptions)
        {
            WriteSubscriptions((IEnumerable<AzureSubscription>) subscriptions);
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
                subscriptionOutput = subscriptions.Select(ConstructPsAzureSubscription);
            }

            WriteObject(subscriptionOutput, true);
        }

        private PSAzureSubscription ConstructPsAzureSubscription(AzureSubscription subscription)
        {
            PSAzureSubscription psObject = new PSAzureSubscription();

            psObject.SubscriptionId = subscription.Id.ToString();
            psObject.SubscriptionName = subscription.Name;
            psObject.Environment = subscription.Environment;
            psObject.SupportedModes = subscription.GetProperty(AzureSubscription.Property.SupportedModes);
            psObject.DefaultAccount = subscription.Account;
            psObject.Accounts = ProfileClient.Profile.Accounts.Values.Where(a => a.HasSubscription(subscription.Id)).ToArray();
            psObject.IsDefault = subscription.IsPropertySet(AzureSubscription.Property.Default);
            psObject.IsCurrent = AzureSession.CurrentContext.Subscription != null && AzureSession.CurrentContext.Subscription.Id == subscription.Id;
            psObject.CurrentStorageAccountName = subscription.GetProperty(AzureSubscription.Property.StorageAccount);
            return psObject;
        }

        private PSAzureSubscriptionExtended ConstructPsAzureSubscriptionExtended(AzureSubscription subscription, IClientFactory clientFactory)
        {
            using (var client = clientFactory.CreateClient<ManagementClient>(subscription, AzureEnvironment.Endpoint.ServiceManagement))
            {
                var response = client.Subscriptions.Get();
                var environment = ProfileClient.GetEnvironmentOrDefault(subscription.Environment);
                var account = DefaultProfileClient.Profile.Accounts[subscription.Account];
                bool isCert = account.Type == AzureAccount.AccountType.Certificate;

                PSAzureSubscriptionExtended result = new PSAzureSubscriptionExtended(ConstructPsAzureSubscription(subscription))
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
                    Certificate = isCert ? ProfileClient.DataStore.GetCertificate(subscription.Account) : null,
                    CurrentStorageAccountName = subscription.GetProperty(AzureSubscription.Property.StorageAccount)
                };

                return result;
            }
        }
    }
}
