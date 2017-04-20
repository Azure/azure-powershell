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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
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
    [Cmdlet("Add", "AzureRmAccount", DefaultParameterSetName = "UserWithSubscriptionId", SupportsShouldProcess=true)]
    [Alias("Login-AzureRmAccount")]
    [OutputType(typeof(PSAzureProfile))]
    public class AddAzureRMAccountCommand : AzureRMCmdlet, IModuleAssemblyInitializer
    {
        private const string UserParameterSetWithSubscriptionId = "UserWithSubscriptionId";
        private const string UserParameterSetWithSubscriptionName = "UserWithSubscriptionName";
        private const string ServicePrincipalParameterSetWithSubscriptionId = "ServicePrincipalWithSubscriptionId";
        private const string ServicePrincipalParameterSetWithSubscriptionName = "ServicePrincipalWithSubscriptionName";
        private const string ServicePrincipalCertificateParameterSetWithSubscriptionId = "ServicePrincipalCertificateWithSubscriptionId";
        private const string ServicePrincipalCertificateParameterSetWithSubscriptionName = "ServicePrincipalCertificateWithSubscriptionName";
        private const string AccessTokenParameterSetWithSubscriptionId = "AccessTokenWithSubscriptionId";
        private const string AccessTokenParameterSetWithSubscriptionName = "AccessTokenWithSubscriptionName";

        protected IAzureEnvironment _environment =AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [ValidateNotNullOrEmpty]
        public string Environment { get; set; }

        
        [Parameter(ParameterSetName = UserParameterSetWithSubscriptionId, 
                    Mandatory = false, HelpMessage = "Optional credential", Position = 0)]
        [Parameter(ParameterSetName = UserParameterSetWithSubscriptionName, 
                    Mandatory = false, HelpMessage = "Optional credential", Position = 0)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionId, 
                    Mandatory = true, HelpMessage = "Credential")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Credential")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionId, 
                    Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        public string CertificateThumbprint { get; set; }
        
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionId, 
                    Mandatory = true, HelpMessage = "SPN")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "SPN")]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionId, 
                    Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionName, 
                    Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionId, 
                    Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionName, 
                    Mandatory = true)]
        public SwitchParameter ServicePrincipal { get; set; }
        
        [Parameter(ParameterSetName = UserParameterSetWithSubscriptionId, 
                    Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = UserParameterSetWithSubscriptionName, 
                    Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionId, 
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionId, 
                    Mandatory = false, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionName, 
                    Mandatory = false, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionId, 
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Alias("Domain")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }
        
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionId, 
                    Mandatory = true, HelpMessage = "AccessToken")]
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "AccessToken")]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }
        
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionId, 
                    Mandatory = true, HelpMessage = "Account Id for access token")]
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Account Id for access token")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }
        
        [Parameter(ParameterSetName = UserParameterSetWithSubscriptionId, 
                    Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionId, 
                    Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionId, 
                    Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionId, 
                    Mandatory = false, HelpMessage = "Subscription ID", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = UserParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Subscription Name", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Subscription Name", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Subscription Name", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = AccessTokenParameterSetWithSubscriptionName, 
                    Mandatory = true, HelpMessage = "Subscription Name", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionName { get; set; }

        protected override IAzureContext DefaultContext
        {
            get
            {
                return null;
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Environment)))
            {
                var profile = AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>();
                if (profile.EnvironmentTable.ContainsKey(Environment))
                {
                    _environment = profile.EnvironmentTable[Environment];
                }
                else
                {
                    throw new PSInvalidOperationException(
                        string.Format(Resources.UnknownEnvironment, Environment));
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

            if (ShouldProcess(string.Format(Resources.LoginTarget, azureAccount.Type, _environment.Name), "log in"))
            {
                if (AzureRmProfileProvider.Instance.Profile == null)
                {
                    AzureRmProfileProvider.Instance.Profile = new AzureRmProfile();
                }

                var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());

                WriteObject((PSAzureProfile) profileClient.Login(azureAccount, _environment, TenantId, SubscriptionId,
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
                AzureSessionInitializer.InitializeAzureSession();
                ResourceManagerProfileProvider.InitializeResourceManagerProfile();
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
