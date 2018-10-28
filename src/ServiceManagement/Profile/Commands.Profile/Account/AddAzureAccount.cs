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
using System.Security;
using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using Microsoft.WindowsAzure.Management;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureAccount", DefaultParameterSetName = UserParameterSetName)]
    [OutputType(typeof(AzureAccount))]
    public class AddAzureAccount : SubscriptionCmdletBase
    {
        private const string UserParameterSetName = "User";
        private const string ServicePrincipalByCredentialsParameterSetName = "ServicePrincipalByCredentialsParameterSetName";
        private const string ServicePrincipalByCertificateParameterSetName = "ServicePrincipalByCertificateParameterSetName";

        [Parameter(Mandatory = false, HelpMessage = "Environment containing the account to log into")]
        public string Environment { get; set; }

        [Parameter(ParameterSetName = UserParameterSetName, Mandatory = false, HelpMessage = "Optional credential")]
        [Parameter(ParameterSetName = ServicePrincipalByCredentialsParameterSetName, Mandatory = true, HelpMessage = "Credential")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalByCertificateParameterSetName, Mandatory = true, HelpMessage = "Certificate thumprint")]
        [ValidateNotNullOrEmpty]
        public string CertificateThumprint { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalByCertificateParameterSetName, Mandatory = true, HelpMessage = "Application/Client Id")]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalByCredentialsParameterSetName, Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalByCertificateParameterSetName, Mandatory = true)]
        public SwitchParameter ServicePrincipal { get; set; }
        
        [Parameter(ParameterSetName = UserParameterSetName, Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalByCredentialsParameterSetName, Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalByCertificateParameterSetName, Mandatory = true, HelpMessage = "Tenant name or ID")]
        [ValidateNotNullOrEmpty]
        [Alias("TenantId")]
        public string Tenant { get; set; }

        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        public AddAzureAccount() : base(true)
        {
            Environment = EnvironmentName.AzureCloud;
        }

        public override void ExecuteCmdlet()
        {
            bool IsLoginViaSPN = false;
            if(ParameterSetName.Equals(ServicePrincipalByCredentialsParameterSetName) ||
                ParameterSetName.Equals(ServicePrincipalByCertificateParameterSetName))
            {
                IsLoginViaSPN = true;
                if (string.IsNullOrEmpty(SubscriptionId))
                {
                    if (Profile.DefaultSubscription == null)
                    {
                        WriteErrorWithTimestamp("No Subscription Set. Please pass the -SubscriptionId/-SubscriptionName to set the default subscription.");
                        return;
                    }
                    SubscriptionId = Profile.DefaultSubscription.Id;
                }
            }

            AzureAccount azureAccount = new AzureAccount();

            azureAccount.Type = ServicePrincipal.IsPresent
                ? AzureAccount.AccountType.ServicePrincipal
                : AzureAccount.AccountType.User;
            
            SecureString password = null;

            if (Credential != null)
            {
                azureAccount.Id = Credential.UserName;
                password = Credential.Password;
            }
            else if(ParameterSetName.Equals(ServicePrincipalByCertificateParameterSetName))
            {
                azureAccount.Id = ClientId;
                azureAccount.SetProperty(AzureAccount.Property.CertificateThumbprint, CertificateThumprint); // Already validated to be not null
            }

            if (!string.IsNullOrEmpty(Tenant))
            {
                azureAccount.SetProperty(AzureAccount.Property.Tenants, new[] {Tenant});
            }

            IAzureAccount account = null;
            IAzureEnvironment environment = ProfileClient.GetEnvironmentOrDefault(Environment);

            if (IsLoginViaSPN)
            {
                account = AddAccountFromSPNAndLoadSubscription(azureAccount, environment, password);
            }
            else
            {
                account = ProfileClient.AddAccountAndLoadSubscriptions(azureAccount, environment, password);
            }

            if (account != null)
            {
                WriteVerbose(string.Format(Resources.AddAccountAdded, azureAccount.Id));
                if (ProfileClient.Profile.DefaultSubscription != null)
                {
                    WriteVerbose(string.Format(Resources.AddAccountShowDefaultSubscription,
                        ProfileClient.Profile.DefaultSubscription.Name));
                }
                WriteVerbose(Resources.AddAccountViewSubscriptions);
                WriteVerbose(Resources.AddAccountChangeSubscription);

                string subscriptionsList = account.GetProperty(AzureAccount.Property.Subscriptions);
                string tenantsList = account.GetProperty(AzureAccount.Property.Tenants);

                if (subscriptionsList == null)
                {
                    WriteWarning(string.Format(Resources.NoSubscriptionAddedMessage, azureAccount.Id));
                }

                WriteObject(account.ToPSAzureAccount());
            }
        }

        private IAzureAccount AddAccountFromSPNAndLoadSubscription(IAzureAccount account, IAzureEnvironment environment, SecureString password)
        {
            IAzureAccount tenantAccount = new AzureAccount();
            CopyAccount(account, tenantAccount);
            WriteDebugWithTimestamp("Calling AuthenticationFctory.Authenticate");
            IAccessToken tenantToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
                tenantAccount,
                environment,
                Tenant,
                password,
                ShowDialog.Never,
                null);
            if (string.Equals(tenantAccount.Id, account.Id, StringComparison.InvariantCultureIgnoreCase))
            {
                tenantAccount = account;
            }
            tenantAccount.SetOrAppendProperty(AzureAccount.Property.Tenants, new string[] { Tenant });
            WriteDebugWithTimestamp("Create Management client");
            using (var managementClient = AzureSession.Instance.ClientFactory.CreateCustomClient<ManagementClient>(
                            new TokenCloudCredentials(SubscriptionId, tenantToken.AccessToken),
                            environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement)))
            {
                WriteDebugWithTimestamp("Get Subscription");
                var subscription = managementClient.Subscriptions.Get();

                AzureSubscription psSubscription = new AzureSubscription
                {
                    Id = subscription.SubscriptionID,
                    Name = subscription.SubscriptionName,
                };
                psSubscription.SetEnvironment(environment.Name);
                psSubscription.SetProperty(AzureSubscription.Property.Tenants,
                    Tenant);
                psSubscription.SetAccount(tenantAccount.Id);
                tenantAccount.SetOrAppendProperty(AzureAccount.Property.Subscriptions,
                    new string[] { psSubscription.Id });

                WriteDebugWithTimestamp("AddOrSetAccount");
                // Add account 
                ProfileClient.AddOrSetAccount(tenantAccount);

                WriteDebugWithTimestamp("AddOrSetSubscription");
                ProfileClient.AddOrSetSubscription(psSubscription);

                // Set subscription as Default
                ProfileClient.SetSubscriptionAsDefault(psSubscription.Name, psSubscription.GetProperty(AzureSubscription.Property.Account));
            }

            return ProfileClient.Profile.AccountTable[account.Id];
        }

        private void CopyAccount(IAzureAccount sourceAccount, IAzureAccount targetAccount)
        {
            targetAccount.Id = sourceAccount.Id;
            targetAccount.Type = sourceAccount.Type;

            if (sourceAccount.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
            {
                targetAccount.SetProperty(AzureAccount.Property.CertificateThumbprint, sourceAccount.GetProperty(AzureAccount.Property.CertificateThumbprint));
            }
        }
    }
}
