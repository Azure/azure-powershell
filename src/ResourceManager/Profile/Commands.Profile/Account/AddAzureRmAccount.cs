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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Security;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Add", "AzureRmAccount", DefaultParameterSetName = "User", SupportsShouldProcess=true)]
    [Alias("Login-AzureRmAccount")]
    [OutputType(typeof(PSAzureProfile))]
    public class AddAzureRMAccountCommand : AzureRMCmdlet, IModuleAssemblyInitializer
    {
        private const string UserParameterSet = "User";
        private const string ServicePrincipalParameterSet = "ServicePrincipal";
        private const string ServicePrincipalCertificateParameterSet = "ServicePrincipalCertificate";
        private const string AccessTokenParameterSet = "AccessToken";
        private const string SubscriptionNameParameterSet = "SubscriptionName";
        private const string SubscriptionIdParameterSet = "SubscriptionId";

        [Parameter(Mandatory = false, HelpMessage = "Environment containing the account to log into")]
        [ValidateNotNullOrEmpty]
        public AzureEnvironment Environment { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [ValidateNotNullOrEmpty]

        public string EnvironmentName { get; set; }


        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "Optional credential")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true, HelpMessage = "Credential")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Optional credential")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Optional credential")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Certificate Hash (Thumbprint)")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Certificate Hash (Thumbprint)")]
        public string CertificateThumbprint { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "SPN")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "SPN")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "SPN")]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true)]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = AccessTokenParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID")]
        [Alias("Domain")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet, Mandatory = true, HelpMessage = "AccessToken")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "AccessToken")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "AccessToken")]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet, Mandatory = true, HelpMessage = "Account Id for access token")]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Account Id for access token")]
        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Account Id for access token")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Subscription", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = false, HelpMessage = "Subscription", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
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
                if (AzureRmProfileProvider.Instance.Profile.Environments.ContainsKey(EnvironmentName))
                {
                    Environment = AzureRmProfileProvider.Instance.Profile.Environments[EnvironmentName];
                }
                else
                {
                    throw new PSInvalidOperationException(
                        string.Format(Resources.UnknownEnvironment, EnvironmentName));
                }
            }
        }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(SubscriptionId) &&
                !string.IsNullOrWhiteSpace(SubscriptionName))
            {
                throw new PSInvalidOperationException(Resources.BothSubscriptionIdAndNameProvided);
            }

            Guid subscrptionIdGuid;
            if (!string.IsNullOrWhiteSpace(SubscriptionId) &&
                !Guid.TryParse(SubscriptionId, out subscrptionIdGuid))
            {
                throw new PSInvalidOperationException(
                    string.Format(Resources.InvalidSubscriptionId, SubscriptionId));
            }

            AzureAccount azureAccount = new AzureAccount();

            if (!string.IsNullOrEmpty(AccessToken))
            {
                if (string.IsNullOrWhiteSpace(AccountId))
                {
                    throw new PSInvalidOperationException(Resources.AccountIdRequired);
                }

                azureAccount.Type = AzureAccount.AccountType.AccessToken;
                azureAccount.Id = AccountId;
                azureAccount.SetProperty(AzureAccount.Property.AccessToken, AccessToken);
            }
            else if (ServicePrincipal.IsPresent)
            {
                azureAccount.Type = AzureAccount.AccountType.ServicePrincipal;
            }
            else
            {
                azureAccount.Type = AzureAccount.AccountType.User;
            }

            if (!string.IsNullOrEmpty(CertificateThumbprint))
            {
                azureAccount.SetProperty(AzureAccount.Property.CertificateThumbprint, CertificateThumbprint);
            }

            SecureString password = null;
            if (Credential != null)
            {
                azureAccount.Id = Credential.UserName;
                password = Credential.Password;
            }

            if (!string.IsNullOrEmpty(ApplicationId))
            {
                azureAccount.Id = ApplicationId;
            }

            if (!string.IsNullOrEmpty(TenantId))
            {
                azureAccount.SetProperty(AzureAccount.Property.Tenants, new[] { TenantId });
            }

            if (ShouldProcess(string.Format(Resources.LoginTarget, azureAccount.Type, Environment.Name), "log in"))
            {
                if (AzureRmProfileProvider.Instance.Profile == null)
                {
                    AzureRmProfileProvider.Instance.Profile = new AzureRMProfile();
                }

                var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);

                WriteObject((PSAzureProfile) profileClient.Login(azureAccount, Environment, TenantId, SubscriptionId,
                    SubscriptionName, password));
            }
        }

        /// <summary>
        /// Load global aliases for ARM
        /// </summary>
        public void OnImport()
        {
            try
            {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AzureRmProfileStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // This will throw exception for tests, ignore.
            }
        }

    }
}
