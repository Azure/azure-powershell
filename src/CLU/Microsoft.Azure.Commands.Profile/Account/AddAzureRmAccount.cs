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

using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common;
using System;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Properties;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Add", "AzureRmAccount", DefaultParameterSetName = "User")]
    [Alias("Login-AzureRmAccount", "Login")]
    [OutputType(typeof(PSAzureProfile))]
    [CliCommandAlias("login")]
    public class AddAzureRMAccountCommand : AzureRMCmdlet
    {
        private const string UserParameterSet = "User";
        private const string ServicePrincipalParameterSet = "ServicePrincipal";
        private const string ServicePrincipalCertificateParameterSet = "ServicePrincipalCertificate";
        private const string AccessTokenParameterSet = "AccessToken";
        private const string SubscriptionNameParameterSet = "SubscriptionName";
        private const string SubscriptionIdParameterSet = "SubscriptionId";

        public AzureEnvironment Environment { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [Alias("e")]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true, HelpMessage = "Secret")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Optional secret")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Optional secret")]
        public string Secret { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet, Mandatory = true, HelpMessage = "Account Id for access token")]
        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "User name (in username@contoso.com format)")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Account Id for access token")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Account Id for access token")]
        [ValidateNotNullOrEmpty]
        [Alias("u")]
        public string Username { get; set; }

        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "Optional password")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Optional password")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Optional password")]
        [ValidateNotNullOrEmpty]
        [Alias("p")]
        public string Password { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Certificate Hash (Thumbprint)")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Certificate Hash (Thumbprint)")]
        [Alias("cert")]
        public string CertificateThumbprint { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true, HelpMessage = "Credential")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "SPN")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "SPN")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "SPN")]
        [Alias("appid")]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true)]
        [Alias("spn")]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = AccessTokenParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID")]
        [Alias("Domain", "t")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet, Mandatory = true, HelpMessage = "AccessToken")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "AccessToken")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "AccessToken")]
        [ValidateNotNullOrEmpty]
        [Alias("token")]
        public string AccessToken { get; set; }

        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Subscription", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = false, HelpMessage = "Subscription", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("s", "id")]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("n", "name")]
        public string SubscriptionName { get; set; }

        protected override AzureContext DefaultContext
        {
            get
            {
                return null;
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (Environment == null && EnvironmentName == null)
            {
                Environment = AzureEnvironment.PublicEnvironments[Common.Authentication.Models.EnvironmentName.AzureCloud];
            }
            else if (Environment == null && EnvironmentName != null)
            {
                if (DefaultProfile.Environments.ContainsKey(EnvironmentName))
                {
                    Environment = DefaultProfile.Environments[EnvironmentName];
                }
                else
                {
                    throw new PSInvalidOperationException(
                        string.Format(Resources.UnknownEnvironment, EnvironmentName));
                }
            }
        }

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(SubscriptionId) &&
                !string.IsNullOrWhiteSpace(SubscriptionName))
            {
                ThrowTerminatingError(new ErrorRecord(new PSInvalidOperationException(Resources.BothSubscriptionIdAndNameProvided), "BothSubscriptionIdAndNameProvided", ErrorCategory.InvalidArgument, this));
            }

            Guid subscrptionIdGuid;
            if (!string.IsNullOrWhiteSpace(SubscriptionId) &&
                !Guid.TryParse(SubscriptionId, out subscrptionIdGuid))
            {
                throw new PSInvalidOperationException(
                    string.Format(Resources.InvalidSubscriptionId, SubscriptionId));
            }

            AzureAccount azureAccount = new AzureAccount();
            string password = null;
            if (!string.IsNullOrEmpty(AccessToken))
            {
                if (string.IsNullOrWhiteSpace(Username))
                {
                    throw new PSInvalidOperationException(Resources.AccountIdRequired);
                }

                azureAccount.Type = AzureAccount.AccountType.AccessToken;
                azureAccount.Id = Username;
                azureAccount.SetProperty(AzureAccount.Property.AccessToken, AccessToken);
            }
            else if (ServicePrincipal.IsPresent)
            {
                azureAccount.Type = AzureAccount.AccountType.ServicePrincipal;
                azureAccount.Id = ApplicationId;
                password = Secret;
            }
            else
            {
                azureAccount.Type = AzureAccount.AccountType.User;
                azureAccount.Id = Username;
                password = Password;
            }

            if (!string.IsNullOrEmpty(CertificateThumbprint))
            {
                azureAccount.SetProperty(AzureAccount.Property.CertificateThumbprint, CertificateThumbprint);
            }

            if (!string.IsNullOrEmpty(ApplicationId))
            {
                azureAccount.Id = ApplicationId;
            }

            if (!string.IsNullOrEmpty(TenantId))
            {
                azureAccount.SetProperty(AzureAccount.Property.Tenants, new[] { TenantId });
            }

            if (!string.IsNullOrEmpty(Secret))
            {
                azureAccount.SetProperty(AzureAccount.Property.ApplicationSecret, Secret);
            }

            if (DefaultProfile == null)
            {
                DefaultProfile = new AzureRMProfile();
            }

            var profileClient = new RMProfileClient(AuthenticationFactory, ClientFactory, DefaultProfile);
            profileClient.WarningLog = (s) => WriteWarning(s);

            WriteObject((PSAzureProfile)profileClient.Login(azureAccount, Environment, TenantId, SubscriptionId,
                SubscriptionName, password));
        }
    }
}
