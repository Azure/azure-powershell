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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.PowerShell.Authenticators;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Connect", AzureRMConstants.AzureRMPrefix + "Account", DefaultParameterSetName = "UserWithSubscriptionId", SupportsShouldProcess=true)]
    [Alias("Login-AzAccount", "Login-AzureRmAccount", "Add-" + AzureRMConstants.AzureRMPrefix + "Account")]
    [OutputType(typeof(PSAzureProfile))]
    public class ConnectAzureRmAccountCommand : AzureContextModificationCmdlet, IModuleAssemblyInitializer
    {
        public const string UserParameterSet = "UserWithSubscriptionId";
        public const string UserWithCredentialParameterSet = "UserWithCredential";
        public const string ServicePrincipalParameterSet = "ServicePrincipalWithSubscriptionId";
        public const string ServicePrincipalCertificateParameterSet= "ServicePrincipalCertificateWithSubscriptionId";
        public const string AccessTokenParameterSet = "AccessTokenWithSubscriptionId";
        public const string ManagedServiceParameterSet = "ManagedServiceLogin";
        public const string MSIEndpointVariable = "MSI_ENDPOINT";
        public const string MSISecretVariable = "MSI_SECRET";

        private IAzureEnvironment _environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public string Environment { get; set; }

        [Parameter(ParameterSetName = UserParameterSet,
                    Mandatory = false, HelpMessage = "Optional credential")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                    Mandatory = true, HelpMessage = "Service Principal Secret")]
        [Parameter(ParameterSetName = UserWithCredentialParameterSet,
                    Mandatory = true, HelpMessage = "User Password Credential: this is only supported in Windows PowerShell 5.1")]
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
                    Mandatory = false)]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(ParameterSetName = UserParameterSet,
                    Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = UserWithCredentialParameterSet,
                    Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = AccessTokenParameterSet,
                    Mandatory = false, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet,
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ManagedServiceParameterSet,
                    Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Alias("Domain", "TenantId")]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

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
                    Mandatory = false, HelpMessage = "Account Id for managed service. Can be a managed service resource Id, or the associated client id. To use the SyatemAssigned identity, leave this field blank.")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory =true, HelpMessage = "Login using managed service identity in the current environment.")]
        [Alias("MSI", "ManagedService")]
        public SwitchParameter Identity { get; set; }

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory = false, HelpMessage = "Port number for managed service login.")]
        [PSDefaultValue(Help = "50342", Value = 50342)]
        public int ManagedServicePort { get; set; } = 50342;

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory = false, HelpMessage = "Host name for managed service login.")]
        [PSDefaultValue(Help = "localhost", Value = "localhost")]
        public string ManagedServiceHostName { get; set; } = "localhost";

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory = false, HelpMessage = "Secret, used for some kinds of managed service login.")]
        [ValidateNotNullOrEmpty]
        public SecureString ManagedServiceSecret { get; set; }


        [Alias("SubscriptionName", "SubscriptionId")]
        [Parameter(ParameterSetName = UserParameterSet,
                    Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = UserWithCredentialParameterSet,
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

        [Parameter(Mandatory = false, HelpMessage = "Skips context population if no contexts are found.")]
        public SwitchParameter SkipContextPopulation { get; set; }

        [Parameter(ParameterSetName = UserParameterSet,
                   Mandatory = false, HelpMessage = "Use device code authentication instead of a browser control")]
        [Alias("DeviceCode", "DeviceAuth", "Device")]
        public SwitchParameter UseDeviceAuthentication { get; set; }

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

            var azureAccount = new AzureAccount();

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
                    var builder = new UriBuilder
                    {
                        Scheme = "http",
                        Host = ManagedServiceHostName,
                        Port = ManagedServicePort,
                        Path = "/oauth2/token"
                    };

                    var envSecret = System.Environment.GetEnvironmentVariable(MSISecretVariable);

                    var msiSecret = this.IsBound(nameof(ManagedServiceSecret))
                        ? ManagedServiceSecret.ConvertToString()
                        : envSecret;

                    var envUri = System.Environment.GetEnvironmentVariable(MSIEndpointVariable);

                    var suppliedUri = this.IsBound(nameof(ManagedServiceHostName))
                        ? builder.Uri.ToString()
                        : envUri;

                    if (!this.IsBound(nameof(ManagedServiceHostName)) && !string.IsNullOrWhiteSpace(envUri)
                        && !this.IsBound(nameof(ManagedServiceSecret)) && !string.IsNullOrWhiteSpace(envSecret))
                    {
                        // set flag indicating this is AppService Managed Identity ad hoc mode
                        azureAccount.SetProperty(AuthenticationFactory.AppServiceManagedIdentityFlag, "the value not used");
                    }

                    if (!string.IsNullOrWhiteSpace(msiSecret))
                    {
                        azureAccount.SetProperty(AzureAccount.Property.MSILoginSecret, msiSecret);
                    }

                    if (!string.IsNullOrWhiteSpace(suppliedUri))
                    {
                        azureAccount.SetProperty(AzureAccount.Property.MSILoginUri, suppliedUri);
                    }
                    else
                    {
                        azureAccount.SetProperty(AzureAccount.Property.MSILoginUriBackup, builder.Uri.ToString());
                        azureAccount.SetProperty(AzureAccount.Property.MSILoginUri, AuthenticationFactory.DefaultMSILoginUri);
                    }

                    azureAccount.Id = this.IsBound(nameof(AccountId)) ? AccountId : string.Format("MSI@{0}", ManagedServicePort);
                    break;
                default:
                    if (ParameterSetName == UserWithCredentialParameterSet && string.Equals(SessionState?.PSVariable?.GetValue("PSEdition") as string, "Core"))
                    {
                        throw new InvalidOperationException(Resources.PasswordNotSupported);
                    }

                    azureAccount.Type = AzureAccount.AccountType.User;
                    break;
            }

            SecureString password = null;
            if (Credential != null)
            {
                azureAccount.Id = Credential.UserName;
                password = Credential.Password;
            }

            if (UseDeviceAuthentication.IsPresent)
            {
                azureAccount.SetProperty("UseDeviceAuth", "true");
            }

            if (!string.IsNullOrEmpty(ApplicationId))
            {
                azureAccount.Id = ApplicationId;
            }

            if (!string.IsNullOrWhiteSpace(CertificateThumbprint))
            {
                azureAccount.SetThumbprint(CertificateThumbprint);
            }

            if (!string.IsNullOrEmpty(Tenant))
            {
                azureAccount.SetProperty(AzureAccount.Property.Tenants, Tenant);
            }

            if (azureAccount.Type == AzureAccount.AccountType.ServicePrincipal && string.IsNullOrEmpty(CertificateThumbprint))
            {
                azureAccount.SetProperty(AzureAccount.Property.ServicePrincipalSecret, password.ConvertToString());
                if (GetContextModificationScope() == ContextModificationScope.CurrentUser)
                {
                    var file = AzureSession.Instance.ARMProfileFile;
                    var directory = AzureSession.Instance.ARMProfileDirectory;
                    WriteWarning(string.Format(Resources.ServicePrincipalWarning, file, directory));
                }
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
                        Tenant,
                        subscriptionId,
                        subscriptionName,
                        password,
                        SkipValidation,
                        WriteWarning,
                        name,
                        !SkipContextPopulation.IsPresent));
               });
            }
        }

        private static bool CheckForExistingContext(AzureRmProfile profile, string name)
        {
            return name != null && profile?.Contexts != null && profile.Contexts.ContainsKey(name);
        }

        private void SetContextWithOverwritePrompt(Action<AzureRmProfile, RMProfileClient, string> setContextAction)
        {
            string name = null;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(ContextName)))
            {
                name = ContextName;
            }

            var profile = DefaultProfile as AzureRmProfile;
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

                var autoSaveEnabled = AzureSession.Instance.ARMContextSaveMode == ContextSaveMode.CurrentUser;
                var autosaveVariable = System.Environment.GetEnvironmentVariable(AzureProfileConstants.AzureAutosaveVariable);
                bool localAutosave;
                if(bool.TryParse(autosaveVariable, out localAutosave))
                {
                    autoSaveEnabled = localAutosave;
                }

                InitializeProfileProvider(autoSaveEnabled);
                IServicePrincipalKeyStore keyStore =
// TODO: Remove IfDef
#if NETSTANDARD
                    new AzureRmServicePrincipalKeyStore(AzureRmProfileProvider.Instance.Profile);
#else
                    new AzureRmServicePrincipalKeyStore();
#endif
                AzureSession.Instance.RegisterComponent(ServicePrincipalKeyStore.Name, () => keyStore);

                IAuthenticatorBuilder builder = null;
                if (!AzureSession.Instance.TryGetComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, out builder))
                {
                    builder = new DefaultAuthenticatorBuilder();
                    AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => builder);
                }
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
