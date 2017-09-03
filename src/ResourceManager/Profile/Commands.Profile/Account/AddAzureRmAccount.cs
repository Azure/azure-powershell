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
using Microsoft.Azure.Commands.Profile.Common;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Add", "AzureRmAccount", DefaultParameterSetName = "UserWithSubscriptionId", SupportsShouldProcess=true)]
    [Alias("Login-AzureRmAccount")]
    [OutputType(typeof(PSAzureProfile))]
    public class AddAzureRMAccountCommand : AzureContextModificationCmdlet, IModuleAssemblyInitializer
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

        [Parameter(Mandatory = false, HelpMessage = "Name of the default context from this login")]
        [ValidateNotNullOrEmpty]
        public string ContextName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Overwrite the existing context with the same name, if any.")]
        public SwitchParameter Force { get; set; }

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
                    InitializeProfileProvider();
                }

                SetContextWithOverwritePrompt((localProfile, profileClient, name) =>
               {
                   WriteObject((PSAzureProfile)profileClient.Login(
                        azureAccount,
                        _environment,
                        TenantId,
                        subscriptionId,
                        subscriptionName,
                        password,
                        (s) => WriteWarning(s),
                        name));
               });
            }
        }

        bool CheckForExistingContext(AzureRmProfile profile, string name)
        {
            return name != null && profile != null && profile.Contexts != null && profile.Contexts.ContainsKey(name);
        }

        void SetContextWithOverwritePrompt(Action<AzureRmProfile, RMProfileClient, string> setContextAction)
        {
            string name = null;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(ContextName)))
            {
                name = ContextName;
            }

            AzureRmProfile profile = DefaultProfile as AzureRmProfile;
            if (!CheckForExistingContext(profile, name)
                || Force.IsPresent
                || ShouldContinue(string.Format(Resources.ReplaceContextQuery, name),
                string.Format(Resources.ReplaceContextCaption, name)))
            {
                ModifyContext((prof, client) => setContextAction(prof, client, name));
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
#if DEBUG
                if (!TestMockSupport.RunningMocked)
                {
#endif
                    AzureSession.Instance.DataStore = new DiskDataStore();
#if DEBUG
                }
#endif
                var invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AzureRmProfileStartup.ps1")));
                var result = invoker.Invoke();
                
                bool autoSaveEnabled = AzureSession.Instance.ARMContextSaveMode == ContextSaveMode.CurrentUser;
                var autosaveVariable = System.Environment.GetEnvironmentVariable(AzureProfileConstants.AzureAutosaveVariable);
                bool localAutosave;
                if(bool.TryParse(autosaveVariable, out localAutosave))
                {
                    autoSaveEnabled = localAutosave;
                }

                InitializeProfileProvider(autoSaveEnabled);
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
