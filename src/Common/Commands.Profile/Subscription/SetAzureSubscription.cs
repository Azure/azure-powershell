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
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;

namespace Microsoft.WindowsAzure.Commands.Profile
{


    /// <summary>
    /// Sets an azure subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSubscription"), OutputType(typeof(AzureSubscription))]
    public class SetAzureSubscriptionCommand : SubscriptionCmdletBase
    {
        private const string UpdateSubscriptionByIdParameterSet = "UpdateSubscriptionByIdParameterSetName";

        private const string UpdateSubscriptionByNameParameterSet = "UpdateSubscriptionByNameParameterSetName";

        private const string AddSubscriptionParameterSet = "AddSubscriptionParameterSetName";

        public SetAzureSubscriptionCommand() : base(true)
        {
            Environment = EnvironmentName.AzureCloud;
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the subscription.", ParameterSetName = UpdateSubscriptionByNameParameterSet)]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the subscription.", ParameterSetName = AddSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Account subscription ID.", ParameterSetName = UpdateSubscriptionByIdParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Account subscription ID.", ParameterSetName = AddSubscriptionParameterSet)]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Account subscription ID.", ParameterSetName = AddSubscriptionParameterSet)]
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage = "Account subscription ID.", ParameterSetName = UpdateSubscriptionByIdParameterSet)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the subscription.", ParameterSetName = UpdateSubscriptionByNameParameterSet)]
        public X509Certificate2 Certificate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Service endpoint.")]
        public string ServiceEndpoint { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Cloud service endpoint.")]
        public string ResourceManagerEndpoint { get; set; }

        [Parameter(HelpMessage = "Current storage account name.")]
        [ValidateNotNullOrEmpty]
        public string CurrentStorageAccountName { get; set; }

        [Parameter(HelpMessage = "Environment name.")]
        [ValidateNotNullOrEmpty]
        public string Environment { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Executes the set subscription cmdlet operation.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            AzureSubscription subscription = null;

            if (!string.IsNullOrEmpty(SubscriptionId) && string.IsNullOrEmpty(SubscriptionName))
            {
                subscription = ProfileClient.GetSubscription(new Guid(SubscriptionId));
                Environment = subscription.Environment;
            }
            else if (string.IsNullOrEmpty(SubscriptionId) && !string.IsNullOrEmpty(SubscriptionName))
            {
                subscription = ProfileClient.GetSubscription(SubscriptionName);
                Environment = subscription.Environment;
            }
            else
            {
                subscription = new AzureSubscription();
                subscription.Id = new Guid(SubscriptionId);
                subscription.Name = SubscriptionName;
            }

            AzureEnvironment environment = ProfileClient.GetEnvironment(Environment, ServiceEndpoint, ResourceManagerEndpoint);
            if (environment == null)
            {
                environment = DefaultProfileClient.GetEnvironment(Environment, ServiceEndpoint, ResourceManagerEndpoint);
            }

            if (environment == null)
            {
                throw new ArgumentException("ServiceEndpoint and ResourceManagerEndpoint values do not "+
                    "match existing environment. Please use Environment parameter.");
            }
            else
            {
                subscription.Environment = environment.Name;
            }

            if (ServiceEndpoint != null || ResourceManagerEndpoint != null)
            {
                WriteWarning("Please use Environment parameter to specify subscription environment. This "+
                    "warning will be converted into an error in the upcoming release.");
            }

            if (Certificate != null)
            {
                ProfileClient.ImportCertificate(Certificate);
                subscription.Account = Certificate.Thumbprint;
                AzureAccount account = new AzureAccount
                {
                    Id = Certificate.Thumbprint,
                    Type = AzureAccount.AccountType.Certificate
                };
                account.SetOrAppendProperty(AzureAccount.Property.Subscriptions, subscription.Id.ToString());
                ProfileClient.AddOrSetAccount(account);

                if (subscription.Account == null)
                {
                    subscription.Account = account.Id;
                }
            }

            if (subscription.Account == null)
            {
                throw new ArgumentException("Certificate is required for creating a new subscription.");
            }

            if (!string.IsNullOrEmpty(CurrentStorageAccountName))
            {
                subscription.Properties[AzureSubscription.Property.StorageAccount] = CurrentStorageAccountName;
            }

            subscription = ProfileClient.AddOrSetSubscription(subscription);

            if (PassThru)
            {
                WriteObject(subscription);
            }
        }
    }
}