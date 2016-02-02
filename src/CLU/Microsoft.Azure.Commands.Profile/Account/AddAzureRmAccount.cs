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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using System.Management.Automation.Host;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Add", "AzureRmAccount", DefaultParameterSetName = "UserSubscriptionId")]
    [Alias("Login-AzureRmAccount", "Login")]
    [OutputType(typeof(PSAzureProfile))]
    [CliCommandAlias("login")]
    public class AddAzureRMAccountCommand : AzureRMCmdlet
    {
        private const string ServicePrincipalSubscriptionIdParameterSet = "ServicePrincipalId";
        private const string ServicePrincipalSubscriptionNameParameterSet = "ServicePrincipalName";
        private const string ServicePrincipalCertificateIdParameterSet = "ServicePrincipalCertificateId";
        private const string ServicePrincipalCertificateNameParameterSet = "ServicePrincipalCertificateName";
        private const string UserSubscriptionIdParameterSet = "UserSubscriptionId";
        private const string UserSubscriptionNameParameterSet = "UserSubscriptionName";
        private const string AccessTokenNameParameterSet = "AccessTokenName";
        private const string AccessTokenIdParameterSet = "AccessTokenId";
        internal const string CollectTelemetryEnvironmentVariable = "Azure_PS_Data_Collection";

        public AzureEnvironment Environment { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [Alias("e")]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalSubscriptionIdParameterSet, Mandatory = true, HelpMessage = "The application secret for this service principal.")]
        [Parameter(ParameterSetName = ServicePrincipalSubscriptionNameParameterSet, Mandatory = true, HelpMessage = "The application secret for this service principal.")]
        public string Secret { get; set; }

        [Parameter(ParameterSetName = AccessTokenNameParameterSet, Mandatory = true, HelpMessage = "User Account Id (for example, user@contoso.com) to use for login.")]
        [Parameter(ParameterSetName = AccessTokenIdParameterSet, Mandatory = true, HelpMessage = "User Account Id (for example, user@contoso.com) to use for login.")]
        [Parameter(ParameterSetName = UserSubscriptionIdParameterSet, Mandatory = false, HelpMessage = "User Account Id (for example, user@contoso.com) to use for login.")]
        [Parameter(ParameterSetName = UserSubscriptionNameParameterSet, Mandatory = false, HelpMessage = "User Account Id (for example, user@contoso.com) to use for login.")]
        [ValidateNotNullOrEmpty]
        [Alias("u")]
        public string Username { get; set; }

        [Parameter(ParameterSetName = UserSubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Password for given user id.  If not provided, interactvie login will be used.")]
        [Parameter(ParameterSetName = UserSubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Password for given user id.  If not provided, interactvie login will be used.")]
        [ValidateNotNullOrEmpty]
        [Alias("p")]
        public string Password { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateIdParameterSet, Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint) for authenticating the given service principal.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateNameParameterSet, Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint) for authenticating the given service principal.")]
        [Alias("cert")]
        public string CertificateThumbprint { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalSubscriptionIdParameterSet, Mandatory = true, HelpMessage = "The application id for service principal login.")]
        [Parameter(ParameterSetName = ServicePrincipalSubscriptionNameParameterSet, Mandatory = true, HelpMessage = "The application id for service principal login.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateIdParameterSet, Mandatory = true, HelpMessage = "The application id for service principal login.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateNameParameterSet, Mandatory = true, HelpMessage = "The application id for service principal login.")]
        [Alias("appid")]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalSubscriptionNameParameterSet, Mandatory = true, HelpMessage = "Indicates a login using service principal credentials.")]
        [Parameter(ParameterSetName = ServicePrincipalSubscriptionIdParameterSet, Mandatory = true, HelpMessage = "Indicates a login using service principal credentials.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateIdParameterSet, Mandatory = true, HelpMessage = "Indicates a login using service principal credentials.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateNameParameterSet, Mandatory = true, HelpMessage = "Indicates a login using service principal credentials.")]
        [Alias("spn")]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(ParameterSetName = UserSubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Optional domain name or Tenant ID.")]
        [Parameter(ParameterSetName = UserSubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Optional domain name or Tenant ID.")]
        [Parameter(ParameterSetName = ServicePrincipalSubscriptionIdParameterSet, Mandatory = true, HelpMessage = "Optional domain name or Tenant ID.")]
        [Parameter(ParameterSetName = ServicePrincipalSubscriptionNameParameterSet, Mandatory = true, HelpMessage = "Optional domain name or Tenant ID.")]
        [Parameter(ParameterSetName = AccessTokenIdParameterSet, Mandatory = false, HelpMessage = "Optional domain name or Tenant ID.")]
        [Parameter(ParameterSetName = AccessTokenNameParameterSet, Mandatory = false, HelpMessage = "Optional domain name or Tenant ID.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateIdParameterSet, Mandatory = true, HelpMessage = "Optional domain name or Tenant ID.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateNameParameterSet, Mandatory = true, HelpMessage = "Optional domain name or Tenant ID.")]
        [Alias("Domain", "t")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        [Parameter(ParameterSetName = AccessTokenIdParameterSet, Mandatory = true, HelpMessage = "AccessToken string for direct authentication of requests.")]
        [Parameter(ParameterSetName = AccessTokenNameParameterSet, Mandatory = true, HelpMessage = "AccessToken string for direct authentication of requests.")]
        [ValidateNotNullOrEmpty]
        [Alias("token")]
        public string AccessToken { get; set; }

        [Parameter(ParameterSetName = UserSubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalSubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateIdParameterSet, Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = AccessTokenIdParameterSet, Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("s", "id")]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = UserSubscriptionNameParameterSet, Mandatory = true, HelpMessage = "Subscription friendly name", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalSubscriptionNameParameterSet, Mandatory = true, HelpMessage = "Subscription friendly name", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateNameParameterSet, Mandatory = true, HelpMessage = "Subscription friendly name.", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = AccessTokenNameParameterSet, Mandatory = true, HelpMessage = "Subscriptionfriendly Name", ValueFromPipelineByPropertyName = true)]
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

            bool isInteractive = azureAccount.Id == null;

            PromptForDataCollectionProfileIfNotExists(isInteractive);

            var profileClient = new RMProfileClient(AuthenticationFactory, ClientFactory, DefaultProfile);
            profileClient.WarningLog = (s) => WriteWarning(s);
            
            WriteObject((PSAzureProfile)profileClient.Login(azureAccount, Environment, TenantId, SubscriptionId,
                SubscriptionName, password));
        }

        private void PromptForDataCollectionProfileIfNotExists(bool isInteractive)
        {
            var collectTelemetryEnv = System.Environment.GetEnvironmentVariable(CollectTelemetryEnvironmentVariable);
            if (!string.IsNullOrEmpty(collectTelemetryEnv))
            {
                bool collectTelemetry = false;
                if (bool.TryParse(collectTelemetryEnv, out collectTelemetry))
                {
                    DefaultProfile.IsTelemetryCollectionEnabled = collectTelemetry;
                }
            }

            if (!DefaultProfile.IsTelemetryCollectionEnabled.HasValue && isInteractive)
            {
                Collection<ChoiceDescription> choices = new Collection<ChoiceDescription>();
                choices.Add(new ChoiceDescription("&Yes", Resources.DataCollectionConfirmYes));
                choices.Add(new ChoiceDescription("&No", Resources.DataCollectionConfirmNo));
                try
                {
                    int choice = this.Host.UI.PromptForChoice(Resources.DataCollectionActivity, Resources.DataCollectionPrompt, choices, 1);
                    DefaultProfile.IsTelemetryCollectionEnabled = choice == 0;
                    WriteWarning(choice == 0 ? Resources.DataCollectionConfirmYes : Resources.DataCollectionConfirmNo);
                }
                catch (PSInvalidOperationException)
                {
                    // Ignore Exception
                }
            }
        }
    }
}
