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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Security;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;

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
        private const string UserParameterSet = "UserWithSubscriptionId";
        private const string ServicePrincipalParameterSet = "ServicePrincipalWithSubscriptionId";
        private const string ServicePrincipalCertificateParameterSet= "ServicePrincipalCertificateWithSubscriptionId";
        private const string AccessTokenParameterSet = "AccessTokenWithSubscriptionId";

        protected IAzureEnvironment _environment =AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public string Environment { get; set; }

        
        [Parameter(ParameterSetName = UserParameterSet, 
                    Mandatory = false, HelpMessage = "Optional credential", Position = 0)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, 
                    Mandatory = true, HelpMessage = "Credential")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, 
                    Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        public string CertificateThumbprint { get; set; }
        
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, 
                    Mandatory = true, HelpMessage = "SPN")]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet, 
                    Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, 
                    Mandatory = true)]
        public SwitchParameter ServicePrincipal { get; set; }
        
        [Parameter(ParameterSetName = UserParameterSet, 
                    Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, 
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = AccessTokenParameterSet, 
                    Mandatory = false, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, 
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Alias("Domain")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }
        
        [Parameter(ParameterSetName = AccessTokenParameterSet, 
                    Mandatory = true, HelpMessage = "AccessToken for Azure Resource Manager")]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet,
                   Mandatory = false, HelpMessage = "AccessToken for Graph Service")]
        [ValidateNotNullOrEmpty]
        public string GraphAccessToken { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet,
                   Mandatory = false, HelpMessage = "AccessToken for KeyVault Service")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultAccessToken { get; set; }
        
        [Parameter(ParameterSetName = AccessTokenParameterSet, 
                    Mandatory = true, HelpMessage = "Account Id for access token")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }
        
        [Alias("SubscriptionName", "SubscriptionId")]
        [Parameter(ParameterSetName = UserParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = AccessTokenParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

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
                if (!profile.TryGetEnvironment(Environment, out _environment))
                {
                    throw new PSInvalidOperationException(
                        string.Format(Resources.UnknownEnvironment, Environment));
                }
            }
        }

        public override void ExecuteCmdlet()
        {
            Guid subscrptionIdGuid;
            string subscriptionName = null;
            string subscriptionId = null;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subscription)))
            {
                if (Guid.TryParse(Subscription, out subscrptionIdGuid))
                {
                    subscriptionId = Subscription;
                }
                else
                {
                    subscriptionName = Subscription;
                }

            }

            AzureAccount azureAccount = new AzureAccount();

            switch(ParameterSetName)
            {
                case AccessTokenParameterSet:
                    azureAccount.Type = AzureAccount.AccountType.AccessToken;
                    azureAccount.Id = AccountId;
                    azureAccount.SetProperty(AzureAccount.Property.AccessToken, AccessToken);
                    azureAccount.SetProperty(AzureAccount.Property.GraphAccessToken, GraphAccessToken);
                    azureAccount.SetProperty(AzureAccount.Property.KeyVaultAccessToken, KeyVaultAccessToken);
                    break;
                case ServicePrincipalCertificateParameterSet:
                case ServicePrincipalParameterSet:
                    azureAccount.Type = AzureAccount.AccountType.ServicePrincipal;
                    break;
                default:
                    azureAccount.Type = AzureAccount.AccountType.User;
                    break;
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

                AzureRmProfile localProfile = AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>();
                IProfileOperations defaultProfile = localProfile;
                using (IFileProvider provider = ProtectedFileProvider.CreateFileProvider(AzureSession.Instance.ResourceManagerContextFile, FileProtection.ExclusiveWrite))
                {
                    if (this.GetAutosaveSetting())
                    {
                        defaultProfile = new AzureRmAutosaveProfile(localProfile, provider);
                    }

                    var profileClient = new RMProfileClient(defaultProfile);

                    WriteObject((PSAzureProfile)profileClient.Login(
                        azureAccount,
                        _environment,
                        TenantId,
                        subscriptionId,
                        subscriptionName,
                        password,
                        (s) => WriteWarning(s)));
                }
            }
        }

        /// <summary>
        /// Load global aliases for ARM
        /// </summary>
        public void OnImport()
        {
#if DEBUG
            try
            {
#endif
                AzureSessionInitializer.InitializeAzureSession();
                if (this.GetAutosaveSetting())
                {
                    ProtectedProfileProvider.InitializeResourceManagerProfile();
                }
                else
                {
                    ResourceManagerProfileProvider.InitializeResourceManagerProfile();
                }
#if DEBUG
                if (!TestMockSupport.RunningMocked)
                {
#endif
                    AzureSession.Instance.DataStore = new DiskDataStore();
#if DEBUG
                }
#endif
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AzureRmProfileStartup.ps1")));
                invoker.Invoke();
#if DEBUG
            }
            catch (Exception) when (TestMockSupport.RunningMocked)
            {
                // This will throw exception for tests, ignore.
            }
#endif
        }
    }
}
