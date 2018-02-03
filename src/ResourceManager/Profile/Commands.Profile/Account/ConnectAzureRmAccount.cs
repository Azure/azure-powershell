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
    [Cmdlet(VerbsCommunications.Connect, "AzureRmAccount", DefaultParameterSetName = "UserWithSubscriptionId", SupportsShouldProcess=true)]
    [Alias("Login-AzAccount", "Login-AzureRmAccount", "Add-AzureRmAccount")]
    [OutputType(typeof(PSAzureProfile))]
    public class ConnectAzureRmAccountCommand : AzureContextModificationCmdlet, IModuleAssemblyInitializer
    {
        public const string UserParameterSet = "UserWithSubscriptionId";
        public const string ServicePrincipalParameterSet = "ServicePrincipalWithSubscriptionId";
        public const string ServicePrincipalCertificateParameterSet= "ServicePrincipalCertificateWithSubscriptionId";
        public const string AccessTokenParameterSet = "AccessTokenWithSubscriptionId";
        public const string ManagedServiceParameterSet = "ManagedServiceLogin";

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
        [Parameter(ParameterSetName = ManagedServiceParameterSet,
                    Mandatory = false, HelpMessage = "Optional tenant name or ID")]
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
        [Parameter(ParameterSetName = ManagedServiceParameterSet,
                    Mandatory = false, HelpMessage = "Account Id for managed service")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory =true, HelpMessage = "Login using managed service identity in the current environment.")]
        [Alias("MSI")]
        public SwitchParameter ManagedService { get; set; }

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory = false, HelpMessage = "Port number for managed service login.")]
        [PSDefaultValue(Help = "50342", Value = 50342)]
        public int ManagedServicePort { get; set; } = 50342;

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory = false, HelpMessage = "Host name for managed service login.")]
        [PSDefaultValue(Help = "localhost", Value = "localhost")]
        public string ManagedServiceHostName { get; set; } = "localhost";
        
        [Alias("SubscriptionName", "SubscriptionId")]
        [Parameter(ParameterSetName = UserParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = AccessTokenParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ManagedServiceParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the default context from this login")]
        [ValidateNotNullOrEmpty]
        public string ContextName { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet,
                    Mandatory = false, HelpMessage = "Skip validation for access token")]
        public SwitchParameter SkipValidation { get; set; }

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
                var profile = GetDefaultProfile();
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

            switch (ParameterSetName)
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
                case ManagedServiceParameterSet:
                    azureAccount.Type = AzureAccount.AccountType.ManagedService;
                    azureAccount.Id = MyInvocation.BoundParameters.ContainsKey(nameof(AccountId))? AccountId : string.Format("MSI@{0}", ManagedServicePort);
                    var builder = new UriBuilder();
                    builder.Scheme = "http";
                    builder.Host = ManagedServiceHostName;
                    builder.Port = ManagedServicePort;
                    builder.Path = "/oauth2/token";
                    azureAccount.SetProperty(AzureAccount.Property.MSILoginUri, builder.Uri.ToString());
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
             
            if (!string.IsNullOrWhiteSpace(CertificateThumbprint))
            {
                azureAccount.SetThumbprint(CertificateThumbprint);
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
                        SkipValidation,
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
