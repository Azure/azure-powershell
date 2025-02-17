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

using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.Commands.Common.Authentication.Config.Models;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager.Common;
using Microsoft.Azure.Commands.Common.Authentication.Sanitizer;
using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.Profile.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.Azure.PowerShell.Common.Share.Survey;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Sanitizer;
using Microsoft.WindowsAzure.Commands.Common.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Connect", AzureRMConstants.AzureRMPrefix + "Account", DefaultParameterSetName = UserParameterSet, SupportsShouldProcess = true)]
    [Alias("Login-AzAccount", "Login-AzureRmAccount", "Add-" + AzureRMConstants.AzureRMPrefix + "Account")]
    [OutputType(typeof(PSAzureProfile))]
    public class ConnectAzureRmAccountCommand : AzureContextModificationCmdlet, IModuleAssemblyInitializer
    {
        public const string UserParameterSet = "UserWithSubscriptionId";
        public const string UserWithCredentialParameterSet = "UserWithCredential";
        public const string ServicePrincipalParameterSet = "ServicePrincipalWithSubscriptionId";
        public const string ServicePrincipalCertificateParameterSet = "ServicePrincipalCertificateWithSubscriptionId";
        public const string ServicePrincipalCertificateFileParameterSet = "ServicePrincipalCertificateFileWithSubscriptionId";
        public const string AccessTokenParameterSet = "AccessTokenWithSubscriptionId";
        public const string ClientAssertionParameterSet = "ClientAssertionParameterSet";
        public const string ManagedServiceParameterSet = "ManagedServiceLogin";
        public const string MSIEndpointVariable = "MSI_ENDPOINT";
        public const string MSISecretVariable = "MSI_SECRET";
        public const int DefaultMaxContextPopulation = 25;
        public const string DefaultMaxContextPopulationString = "25";
        private const int DefaultManagedServicePort = 50342;

        private IAzureEnvironment _environment;

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        [EnvironmentCompleter()]
        public string Environment { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                    Mandatory = true, HelpMessage = "Service Principal Secret")]
        [Parameter(ParameterSetName = UserWithCredentialParameterSet,
                    Mandatory = true, HelpMessage = "Username/Password Credential")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet,
                    Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        public string CertificateThumbprint { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet,
                    Mandatory = true, HelpMessage = "SPN")]
        [Parameter(ParameterSetName = ClientAssertionParameterSet,
                    Mandatory = true, HelpMessage = "SPN")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateFileParameterSet,
                    Mandatory = true, HelpMessage = "SPN")]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                    Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet,
                    Mandatory = false)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateFileParameterSet,
                    Mandatory = false)]
        [Parameter(ParameterSetName = ClientAssertionParameterSet,
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
        [Parameter(ParameterSetName = ServicePrincipalCertificateFileParameterSet,
                    Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ClientAssertionParameterSet,
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
                   Mandatory = false, HelpMessage = "Access token to Microsoft Graph")]
        [ValidateNotNullOrEmpty]
        public string MicrosoftGraphAccessToken { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet,
                   Mandatory = false, HelpMessage = "AccessToken for KeyVault Service")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultAccessToken { get; set; }

        [Parameter(ParameterSetName = UserParameterSet,
            Mandatory = false, HelpMessage = "Account Id / User Id / User Name to login with")]
        [Parameter(ParameterSetName = AccessTokenParameterSet,
                    Mandatory = true, HelpMessage = "Account Id for access token")]
        [Parameter(ParameterSetName = ManagedServiceParameterSet,
                    Mandatory = false, HelpMessage = "Client id of UserAssigned identity. To use the SystemAssigned identity, leave this field blank.")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        [Parameter(ParameterSetName = ManagedServiceParameterSet, Mandatory = true, HelpMessage = "Login using managed service identity in the current environment.")]
        [Alias("MSI", "ManagedService")]
        public SwitchParameter Identity { get; set; }

        [Alias("SubscriptionName", "SubscriptionId")]
        [Parameter(Mandatory = false, HelpMessage = "Subscription Name or ID", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

        private const string AuthScopeHelpMessage = "Optional OAuth scope for login, supported pre-defined values: AadGraph, AnalysisServices, Attestation, Batch, DataLake, KeyVault, OperationalInsights, Storage, Synapse. It also supports resource id like 'https://storage.azure.com/'.";

        [Alias("AuthScopeTypeName")]
        [Parameter(ParameterSetName = UserParameterSet,
            Mandatory = false, HelpMessage = AuthScopeHelpMessage)]
        [Parameter(ParameterSetName = UserWithCredentialParameterSet,
            Mandatory = false, HelpMessage = AuthScopeHelpMessage)]
        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
            Mandatory = false, HelpMessage = AuthScopeHelpMessage)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet,
            Mandatory = false, HelpMessage = AuthScopeHelpMessage)]
        [Parameter(ParameterSetName = ManagedServiceParameterSet,
            Mandatory = false, HelpMessage = AuthScopeHelpMessage)]
        [PSArgumentCompleter(
            SupportedResourceNames.AadGraph,
            SupportedResourceNames.AnalysisServices,
            SupportedResourceNames.Attestation,
            SupportedResourceNames.Batch,
            SupportedResourceNames.DataLake,
            SupportedResourceNames.KeyVault,
            SupportedResourceNames.ManagedHsm,
            SupportedResourceNames.OperationalInsights,
            SupportedResourceNames.Storage,
            SupportedResourceNames.Synapse
            )]
        public string AuthScope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the default context from this login")]
        [ValidateNotNullOrEmpty]
        public string ContextName { get; set; }

        [Parameter(ParameterSetName = AccessTokenParameterSet,
                    Mandatory = false, HelpMessage = "Skip validation for access token")]
        public SwitchParameter SkipValidation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Skips context population if no contexts are found.")]
        public SwitchParameter SkipContextPopulation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Max subscription number to populate contexts after login. Default is " + DefaultMaxContextPopulationString + ". To populate all subscriptions to contexts, set to -1.")]
        [PSDefaultValue(Help = DefaultMaxContextPopulationString, Value = DefaultMaxContextPopulation)]
        [ValidateRange(-1, int.MaxValue)]
        public int MaxContextPopulation { get; set; } = DefaultMaxContextPopulation;

        [Parameter(ParameterSetName = UserParameterSet,
                   Mandatory = false, HelpMessage = "Use device code authentication instead of a browser control")]
        [Alias("DeviceCode", "DeviceAuth", "Device")]
        public SwitchParameter UseDeviceAuthentication { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Overwrite the existing context with the same name, if any.")]
        public SwitchParameter Force { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, HelpMessage = "Specifies if the x5c claim (public key of the certificate) should be sent to the STS to achieve easy certificate rollover in Azure AD.")]
        [Parameter(ParameterSetName = ServicePrincipalCertificateFileParameterSet, HelpMessage = "Specifies if the x5c claim (public key of the certificate) should be sent to the STS to achieve easy certificate rollover in Azure AD.")]
        public SwitchParameter SendCertificateChain { get; set; }


        [Parameter(ParameterSetName = ServicePrincipalCertificateFileParameterSet, Mandatory = true, HelpMessage = "The path of certficate file in pkcs#12 format.")]
        public String CertificatePath { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalCertificateFileParameterSet, HelpMessage = "The password required to access the pkcs#12 certificate file.")]
        public SecureString CertificatePassword { get; set; }

        [Parameter(ParameterSetName = ClientAssertionParameterSet, Mandatory = true, HelpMessage = "Specifies a token provided by another identity provider. The issuer and subject in this token must be first configured to be trusted by the ApplicationId.")]
        [Alias("ClientAssertion")]
        [ValidateNotNullOrEmpty]
        public string FederatedToken { get; set; }

        protected override IAzureContext DefaultContext
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// This cmdlet should work even if there isn't a default context
        /// </summary>
        protected override bool RequireDefaultContext() { return false; }

        internal TokenCachePersistenceChecker TokenCachePersistenceChecker { get; set; } = new TokenCachePersistenceChecker();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            ValidateActionRequiredMessageCanBePresented();
            if (AzureEnvironment.PublicEnvironments.ContainsKey(EnvironmentName.AzureCloud))
            {
                _environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            }
            else
            {
                WriteWarning($"Default environment {EnvironmentName.AzureCloud} cannot be found from PublicEnvironment list. ");
                WriteWarning("You can get current list via [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments");
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Environment)))
            {
                var profile = GetDefaultProfile();
                if (!profile.TryGetEnvironment(Environment, out _environment))
                {
                    throw new PSInvalidOperationException(
                        string.Format(Resources.UnknownEnvironment, Environment));
                }
            }

            // save the target environment so it can be read to get the correct accounts from token cache
            AzureSession.Instance.SetProperty(AzureSession.Property.Environment, Environment);

            _writeWarningEvent -= WriteWarningSender;
            _writeWarningEvent += WriteWarningSender;
            _writeInformationEvent -= WriteInformationSender;
            _writeInformationEvent += WriteInformationSender;

            // store the original write warning handler, register a thread safe one
            AzureSession.Instance.TryGetComponent(WriteWarningKey, out _originalWriteWarning);
            AzureSession.Instance.UnregisterComponent<EventHandler<StreamEventArgs>>(WriteWarningKey);
            AzureSession.Instance.RegisterComponent(WriteWarningKey, () => _writeWarningEvent);

            // store the original write information handler, register a thread safe one
            AzureSession.Instance.TryGetComponent(WriteInformationKey, out _originalWriteInformation);
            AzureSession.Instance.UnregisterComponent<EventHandler<StreamEventArgs>>(WriteInformationKey);
            AzureSession.Instance.RegisterComponent(WriteInformationKey, () => _writeInformationEvent);

            // todo: ideally cancellation token should be passed to authentication factory as a parameter
            // however AuthenticationFactory.Authenticate does not support it
            // so I store it in AzureSession.Instance as a global variable
            // todo: CancellationTokenSource should be visiable only in cmdlet class
            // CancellationTokenSource.Token should be passed to other classes
            AzureSession.Instance.RegisterComponent("LoginCancellationToken", () => new CancellationTokenSource(), true);
        }

        private event EventHandler<StreamEventArgs> _writeWarningEvent;
        private event EventHandler<StreamEventArgs> _originalWriteWarning;

        private event EventHandler<StreamEventArgs> _writeInformationEvent;
        private event EventHandler<StreamEventArgs> _originalWriteInformation;

        private void WriteWarningSender(object sender, StreamEventArgs args)
        {
            _tasks.Enqueue(new Task(() => this.WriteWarning(args.Message)));
        }

        private void WriteInformationSender(object sender, StreamEventArgs args)
        {
            _tasks.Enqueue(new Task(() => this.WriteInformation(args.Message)));
        }

        protected override void StopProcessing()
        {
            if (AzureSession.Instance.TryGetComponent("LoginCancellationToken", out CancellationTokenSource cancellationTokenSource))
            {
                cancellationTokenSource?.Cancel();
            }
            base.StopProcessing();
        }

        public override void ExecuteCmdlet()
        {
            Guid subscriptionIdGuid;
            string subscriptionName = null;
            string subscriptionId = null;

            //Disable WAM before the issue https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/issues/4786 is fixed
            if (ParameterSetName.Equals(UserParameterSet) && UseDeviceAuthentication == true || ParameterSetName.Equals(UserWithCredentialParameterSet))
            {
                AzConfigReader.Instance?.UpdateConfig(ConfigKeys.EnableLoginByWam, false, ConfigScope.CurrentUser);
            }

            if (ParameterSetName.Equals(UserWithCredentialParameterSet))
            {
                WriteWarning(Resources.UsernamePasswordDeprecateWarningMessage);
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Subscription)))
            {
                if (Guid.TryParse(Subscription, out subscriptionIdGuid))
                {
                    subscriptionId = Subscription;
                }
                else
                {
                    subscriptionName = Subscription;
                }

            }
            else if (AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager))
            {
                string subscriptionFromConfig = configManager.GetConfigValue<string>(ConfigKeys.DefaultSubscriptionForLogin);
                if (!string.IsNullOrEmpty(subscriptionFromConfig))
                {
                    // user doesn't specify subscript; but DefaultSubscriptionForLogin is found in config
                    WriteDebugWithTimestamp($"[ConnectAzureRmAccountCommand] Using default subscription \"{subscriptionFromConfig}\" from config.");
                    if (Guid.TryParse(subscriptionFromConfig, out subscriptionIdGuid))
                    {
                        subscriptionId = subscriptionFromConfig;
                    }
                    else
                    {
                        subscriptionName = subscriptionFromConfig;
                    }
                }
            }

            if (ClientAssertionParameterSet.Equals(ParameterSetName, StringComparison.OrdinalIgnoreCase))
            {
                bool suppressWarningOrError = AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager) && configManager.GetConfigValue<bool>(ConfigKeys.DisplayBreakingChangeWarning);
                if (!suppressWarningOrError)
                {
                    WriteWarning("The feature related to parameter name 'FederatedToken' is under preview.");
                }
            }

            var azureAccount = new AzureAccount();

            switch (ParameterSetName)
            {
                case UserParameterSet:
                    azureAccount.Type = AzureAccount.AccountType.User;
                    if (!string.IsNullOrEmpty(AccountId))
                    {
                        azureAccount.SetProperty("LoginHint", AccountId);
                    }
                    break;
                case AccessTokenParameterSet:
                    azureAccount.Type = AzureAccount.AccountType.AccessToken;
                    azureAccount.Id = AccountId;
                    azureAccount.SetProperty(AzureAccount.Property.AccessToken, AccessToken);
                    azureAccount.SetProperty(AzureAccount.Property.GraphAccessToken, GraphAccessToken);
                    azureAccount.SetProperty(AzureAccount.Property.KeyVaultAccessToken, KeyVaultAccessToken);
                    azureAccount.SetProperty(Constants.MicrosoftGraphAccessToken, MicrosoftGraphAccessToken);
                    break;
                case ServicePrincipalCertificateParameterSet:
                case ServicePrincipalCertificateFileParameterSet:
                case ServicePrincipalParameterSet:
                    azureAccount.Type = AzureAccount.AccountType.ServicePrincipal;
                    break;
                case ClientAssertionParameterSet:
                    azureAccount.Type = "ClientAssertion";
                    break;
                case ManagedServiceParameterSet:
                    azureAccount.Type = AzureAccount.AccountType.ManagedService;
                    azureAccount.Id = this.IsBound(nameof(AccountId)) ? AccountId : $"{Constants.DefaultMsiAccountIdPrefix}{DefaultManagedServicePort}";
                    break;
                default:
                    //Support username + password for both Windows PowerShell and PowerShell 6+
                    azureAccount.Type = AzureAccount.AccountType.User;
                    break;
            }

            if (!AzureSession.Instance.TryGetComponent(AzKeyStore.Name, out AzKeyStore keyStore))
            {
                keyStore = null;
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

            if (azureAccount.Type == AzureAccount.AccountType.User && password != null)
            {
                azureAccount.SetProperty(AzureAccount.Property.UsePasswordAuth, "true");
            }

            if (!string.IsNullOrEmpty(ApplicationId))
            {
                azureAccount.Id = ApplicationId;
            }

            if (!string.IsNullOrWhiteSpace(CertificateThumbprint))
            {
                azureAccount.SetThumbprint(CertificateThumbprint);
            }

            if (!string.IsNullOrWhiteSpace(CertificatePath))
            {
                var resolvedPath = this.SessionState.Path.GetResolvedPSPathFromPSPath(CertificatePath).FirstOrDefault()?.Path;
                if (string.IsNullOrEmpty(resolvedPath))
                {
                    var parametersLog = $"- Invalid certificate path :'{CertificatePath}'.";
                    throw new InvalidOperationException(parametersLog);
                }
                azureAccount.SetProperty(AzureAccount.Property.CertificatePath, resolvedPath);
                if (CertificatePassword != null)
                {
                    keyStore?.SaveSecureString(new ServicePrincipalKey(AzureAccount.Property.CertificatePassword, azureAccount.Id, Tenant), CertificatePassword);
                    if (GetContextModificationScope() == ContextModificationScope.CurrentUser && !keyStore.IsProtected)
                    {
                        WriteWarning(string.Format(Resources.ServicePrincipalWarning, AzureSession.Instance.KeyStoreFile, AzureSession.Instance.ARMProfileDirectory));
                    }
                }
            }

            if ((ParameterSetName == ServicePrincipalCertificateParameterSet || ParameterSetName == ServicePrincipalCertificateFileParameterSet)
                && SendCertificateChain)
            {
                azureAccount.SetProperty(AzureAccount.Property.SendCertificateChain, SendCertificateChain.ToString());
                bool suppressWarningOrError = AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager) && configManager.GetConfigValue<bool>(ConfigKeys.DisplayBreakingChangeWarning);
                if (!suppressWarningOrError)
                {
                    WriteWarning(Resources.PreviewFunctionMessage);
                }
            }

            if (!string.IsNullOrEmpty(Tenant))
            {
                azureAccount.SetProperty(AzureAccount.Property.Tenants, Tenant);
            }

            if (azureAccount.Type == AzureAccount.AccountType.ServicePrincipal && password != null)
            {
                keyStore?.SaveSecureString(new ServicePrincipalKey(AzureAccount.Property.ServicePrincipalSecret
                    , azureAccount.Id, Tenant), password);
                if (GetContextModificationScope() == ContextModificationScope.CurrentUser && !keyStore.IsProtected)
                {
                    WriteWarning(string.Format(Resources.ServicePrincipalWarning, AzureSession.Instance.KeyStoreFile, AzureSession.Instance.ARMProfileDirectory));
                }
            }
            if (azureAccount.Type == "ClientAssertion" && FederatedToken != null)
            {
                password = SecureStringExtensions.ConvertToSecureString(FederatedToken);
                azureAccount.SetProperty("ClientAssertion", FederatedToken);
                if (GetContextModificationScope() == ContextModificationScope.CurrentUser)
                {
                    var file = AzureSession.Instance.ARMProfileFile;
                    var directory = AzureSession.Instance.ARMProfileDirectory;
                    WriteWarning(string.Format(Resources.ClientAssertionWarning, file, directory));
                }
            }

            var resourceId = PreProcessAuthScope();

            if (ShouldProcess(string.Format(Resources.LoginTarget, azureAccount.Type, _environment.Name), "log in"))
            {
                if (AzureRmProfileProvider.Instance.Profile == null)
                {
                    InitializeProfileProvider();
                }

                if (!AzureSession.Instance.TryGetComponent(nameof(CommonUtilities), out CommonUtilities commonUtilities))
                {
                    commonUtilities = new CommonUtilities();
                    AzureSession.Instance.RegisterComponent(nameof(CommonUtilities), () => commonUtilities);
                }
                if (!commonUtilities.IsDesktopSession() && IsPopUpInteractiveAuthenticationFlow())
                {
                    WriteWarning(Resources.InteractiveAuthNotSupported);
                    return;
                }

                IHttpOperationsFactory httpClientFactory = null;
                AzureSession.Instance.TryGetComponent(HttpClientOperationsFactory.Name, out httpClientFactory);

                SetContextWithOverwritePrompt((localProfile, profileClient, name) =>
                {
                    bool shouldPopulateContextList = true;
                    if (this.IsParameterBound(c => c.SkipContextPopulation))
                    {
                        shouldPopulateContextList = false;
                    }

                    profileClient.WarningLog = (message) => _tasks.Enqueue(new Task(() => this.WriteWarning(message)));
                    profileClient.InteractiveInformationLog = (message) => _tasks.Enqueue(new Task(() => WriteInteractiveInformation(message)));
                    profileClient.DebugLog = (message) => _tasks.Enqueue(new Task(() => this.WriteDebugWithTimestamp(message)));
                    profileClient.PromptAndReadLine = (message) =>
                    {
                        var prompt = new Task<string>(() => Prompt(message));
                        _tasks.Enqueue(prompt);
                        return prompt.GetAwaiter().GetResult();
                    };

                    var task = new Task<AzureRmProfile>(() => profileClient.Login(
                        azureAccount,
                        _environment,
                        Tenant,
                        subscriptionId,
                        subscriptionName,
                        password,
                        SkipValidation,
                        new OpenIDConfiguration(Tenant, baseUri: _environment.ActiveDirectoryAuthority, httpClientFactory: httpClientFactory),
                        WriteWarningEvent, //Could not use WriteWarning directly because it may be in worker thread
                        name,
                        shouldPopulateContextList,
                        MaxContextPopulation,
                        resourceId,
                        IsInteractiveContextSelectionEnabled()));
                    task.Start();
                    while (!task.IsCompleted)
                    {
                        HandleActions();
                        Thread.Yield();
                    }

                    HandleActions();

                    try
                    {
                        //Must not use task.Result as it wraps inner exception into AggregateException
                        var result = (PSAzureProfile)task.GetAwaiter().GetResult();
                        WriteObject(result);
                    }
                    catch (AuthenticationFailedException ex)
                    {
                        string message = string.Empty;
                        if (IsUnableToOpenWebPageError(ex))
                        {
                            WriteWarning(Resources.InteractiveAuthNotSupported);
                            WriteDebug(ex.ToString());
                        }
                        else if (TryParseUnknownAuthenticationException(ex, out message))
                        {
                            WriteDebug(ex.ToString());
                            throw ex.WithAdditionalMessage(message);
                        }
                        else
                        {
                            if (IsPopUpInteractiveAuthenticationFlow())
                            {
                                //Display only if user is using Interactive auth
                                WriteWarning(Resources.SuggestToUseDeviceCodeAuth);
                            }
                            WriteDebug(ex.ToString());
                            throw;
                        }
                    }
                });

                WriteAnnouncementsPeriodically();
            }
        }

        private void WriteAnnouncementsPeriodically()
        {
            if (ParameterSetName != UserParameterSet)
            {
                // Write-Host may block automation scenarios
                return;
            }
            const string AnnouncementsFeatureName = "SignInAnnouncements";
            TimeSpan AnnouncementsInterval = TimeSpan.FromDays(7);
            if (AzureSession.Instance.TryGetComponent<IFrequencyService>(nameof(IFrequencyService), out var frequency))
            {
                frequency.Register(AnnouncementsFeatureName, AnnouncementsInterval);
                // WriteInformation can't fail, so the second parameter always returns true
                frequency.TryRun(AnnouncementsFeatureName, () => true, () =>
                {
                    WriteInformation($"{Resources.AnnouncementsHeader}{System.Environment.NewLine}{Resources.AnnouncementsMessage}{System.Environment.NewLine}", false);
                    WriteInformation($"{Resources.ReportIssue}{System.Environment.NewLine}", false);
                });
            }
        }

        private bool IsInteractiveContextSelectionEnabled()
        {
            return AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out IConfigManager configManager) ? configManager.GetConfigValue<LoginExperienceConfig>(ConfigKeys.LoginExperienceV2).Equals(LoginExperienceConfig.On) : true;
        }

        private bool IsPopUpInteractiveAuthenticationFlow()
        {
            return ParameterSetName.Equals(UserParameterSet) && UseDeviceAuthentication.IsPresent == false;
        }

        private void ValidateActionRequiredMessageCanBePresented()
        {
            if (UseDeviceAuthentication.IsPresent && IsWriteInformationIgnored())
            {
                throw new ActionPreferenceStopException(Resources.DoNotIgnoreInformationIfUserDeviceAuth);
            }
        }

        private void WriteInteractiveInformation(string message)
        {
            if (ParameterSetName.Equals(UserParameterSet))
            {
                this.WriteInformation(message, false);
            }
        }

        private bool IsWriteInformationIgnored()
        {
            return !MyInvocation.BoundParameters.ContainsKey("InformationAction") && ActionPreference.Ignore.ToString().Equals(SessionState?.PSVariable?.GetValue("InformationPreference", ActionPreference.SilentlyContinue)?.ToString() ?? "") ||
                MyInvocation.BoundParameters.TryGetValue("InformationAction", out var value) && ActionPreference.Ignore.ToString().Equals(value?.ToString() ?? "", StringComparison.InvariantCultureIgnoreCase);
        }

        private string PreProcessAuthScope()
        {
            string mappedScope = AuthScope;
            if (!string.IsNullOrEmpty(AuthScope) &&
                SupportedResourceNames.DataPlaneResourceNameMap.ContainsKey(AuthScope))
            {
                mappedScope = SupportedResourceNames.DataPlaneResourceNameMap[AuthScope];
                WriteDebug($"Map AuthScope from {AuthScope} to {mappedScope}.");
            }
            return mappedScope;
        }

        private bool IsUnableToOpenWebPageError(AuthenticationFailedException exception)
        {
            return exception.InnerException is MsalClientException && ((MsalClientException)exception.InnerException)?.ErrorCode == MsalError.LinuxXdgOpen
                            || (exception.Message?.ToLower()?.Contains("unable to open a web page") ?? false);
        }

        private bool TryParseUnknownAuthenticationException(AuthenticationFailedException exception, out string message)
        {

            var innerException = exception?.InnerException as MsalServiceException;
            bool isUnknownMsalServiceException = string.Equals(innerException?.ErrorCode, "access_denied", StringComparison.OrdinalIgnoreCase);
            message = null;
            if (isUnknownMsalServiceException)
            {
                StringBuilder messageBuilder = new StringBuilder(nameof(innerException.ErrorCode));
                messageBuilder.Append(": ").Append(innerException.ErrorCode);
                message = messageBuilder.ToString();
            }
            return isUnknownMsalServiceException;
        }

        private ConcurrentQueue<Task> _tasks = new ConcurrentQueue<Task>();

        private void HandleActions()
        {
            Task task;
            while (_tasks.TryDequeue(out task))
            {
                task.RunSynchronously();
            }
        }

        private void WriteWarningEvent(string message)
        {
            EventHandler<StreamEventArgs> writeWarningEvent;
            if (AzureSession.Instance.TryGetComponent(WriteWarningKey, out writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs() { Message = message });
            }
        }

        private void WriteInformationEvent(string message)
        {
            EventHandler<StreamEventArgs> writeInformationEvent;
            if (AzureSession.Instance.TryGetComponent(WriteInformationKey, out writeInformationEvent))
            {
                writeInformationEvent(this, new StreamEventArgs() { Message = message });
            }
        }

        /// <summary>
        /// Prompt a message and read a line, may move to AzPsCmdlet if more cmdlets need to prompt
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string Prompt(string message)
        {
            this.WriteInformation(message, true);
            return this.Host.UI.ReadLine();
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

            AzureRmProfile profile = null;
            bool? originalShouldRefreshContextsFromCache = null;
            try
            {
                profile = DefaultProfile as AzureRmProfile;
                if (profile != null)
                {
                    originalShouldRefreshContextsFromCache = profile.ShouldRefreshContextsFromCache;
                    profile.ShouldRefreshContextsFromCache = false;
                }
                if (!CheckForExistingContext(profile, name)
                    || Force.IsPresent
                    || ShouldContinue(string.Format(Resources.ReplaceContextQuery, name),
                    string.Format(Resources.ReplaceContextCaption, name)))
                {
                    ModifyContext((prof, client) => setContextAction(prof, client, name));
                }
            }
            finally
            {
                if (profile != null && originalShouldRefreshContextsFromCache.HasValue)
                {
                    profile.ShouldRefreshContextsFromCache = originalShouldRefreshContextsFromCache.Value;
                }
            }
        }

        //This method may throw exception because of permission issue, exception should be handled from caller
        private static IAzureContextContainer GetAzureContextContainer()
        {
            var provider = new ProtectedProfileProvider();
            return provider.Profile;
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
                AzureSessionInitializer.InitializeAzureSession(WriteInitializationWarnings);
                AzureSessionInitializer.MigrateAdalCache(AzureSession.Instance, GetAzureContextContainer, WriteInitializationWarnings);
                AzureSessionInitializer.MigrateMsalCacheWithoutSuffix(AzureSession.Instance, WriteInitializationWarnings);
#if DEBUG
                if (!TestMockSupport.RunningMocked)
                {
#endif
                    AzureSession.Instance.DataStore = new DiskDataStore();
#if DEBUG
                }
#endif
                SurveyHelper.GetInstance().updateSurveyHelper(AzureSession.Instance.ExtendedProperties["InstallationId"]);
                var autoSaveEnabled = AzureSession.Instance.ARMContextSaveMode == ContextSaveMode.CurrentUser;
                var autosaveVariable = System.Environment.GetEnvironmentVariable(AzureProfileConstants.AzureAutosaveVariable);

                if (bool.TryParse(autosaveVariable, out bool localAutosave))
                {
                    autoSaveEnabled = localAutosave;
                }

                try
                {
                    if (autoSaveEnabled && !TokenCachePersistenceChecker.Verify())
                    {
                        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        {
                            // In Windows and macOS platforms, unknown errors are discovered that fails the persistence check.
                            // Disable context autosaving before msal library provide a fallback method for the case.
                            throw new PSInvalidOperationException(Resources.TokenCachePersistenceCheckError);
                        }
                        // If token cache persistence is not supported, fall back to plain text persistence, and print a warning
                        // We cannot just throw an exception here because this is called when importing the module
                        WriteInitializationWarnings(Resources.TokenCacheEncryptionNotSupportedWithFallback);
                    }
                }
                catch (Exception ex)
                {
                    //Likely the exception is related permission, fall back context save mode to process
                    autoSaveEnabled = false;
                    AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.Process;
                    WriteInitializationWarnings(Resources.FallbackContextSaveModeDueCacheCheckError.FormatInvariant(ex.Message));
                }

                AzKeyStore keyStore = null;
                keyStore = new AzKeyStore(AzureSession.Instance.ARMProfileDirectory, AzureSession.Instance.KeyStoreFile, autoSaveEnabled);
                AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore);

                if (!InitializeProfileProvider(autoSaveEnabled))
                {
                    AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.Process;
                    autoSaveEnabled = false;
                }

                IAuthenticatorBuilder builder = null;
                if (!AzureSession.Instance.TryGetComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, out builder))
                {
                    builder = new DefaultAuthenticatorBuilder();
                    AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => builder);
                }

                PowerShellTokenCacheProvider provider = null;
                if (autoSaveEnabled)
                {
                    provider = new SharedTokenCacheProvider();
                }
                else // if autosave is disabled, or the shared factory fails to initialize, we fallback to in memory
                {
                    provider = new InMemoryTokenCacheProvider();
                }
                IAzureEventListenerFactory azureEventListenerFactory = new AzureEventListenerFactory();
                AzureSession.Instance.RegisterComponent(nameof(CommonUtilities), () => new CommonUtilities());
                // It's tricky to register a component as an Interface
                // Make sure componentInitializer return the Interface, not the derived type
                AzureSession.Instance.RegisterComponent(nameof(ISharedUtilities), () => new AzureRmSharedUtilities() as ISharedUtilities);
                AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => provider);
                AzureSession.Instance.RegisterComponent(nameof(IAzureEventListenerFactory), () => azureEventListenerFactory);
                AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => new AzureCredentialFactory());
                AzureSession.Instance.RegisterComponent(nameof(MsalAccessTokenAcquirerFactory), () => new MsalAccessTokenAcquirerFactory());
                AzureSession.Instance.RegisterComponent<ISshCredentialFactory>(nameof(ISshCredentialFactory), () => new SshCredentialFactory());
                AzureSession.Instance.RegisterComponent<IOutputSanitizer>(nameof(IOutputSanitizer), () => new OutputSanitizer());
#if DEBUG || TESTCOVERAGE
                AzureSession.Instance.RegisterComponent<ITestCoverage>(nameof(ITestCoverage), () => new TestCoverage());
#endif

#if DEBUG
            }
            catch (Exception) when (TestMockSupport.RunningMocked)
            {
                // This will throw exception for tests, ignore.
            }
#endif
        }

        private void AddConfigTelemetry()
        {
            try
            {
                if (!_qosEvent.ConfigMetrics.ContainsKey(ConfigKeys.LoginExperienceV2))
                {
                    _qosEvent.ConfigMetrics[ConfigKeys.LoginExperienceV2] = new ConfigMetrics(ConfigKeys.LoginExperienceV2, $"Config-{ConfigKeys.LoginExperienceV2}",
                       Enum.GetName(typeof(LoginExperienceConfig), AzConfigReader.GetAzConfig(ConfigKeys.LoginExperienceV2, LoginExperienceConfig.On)));
                }

                if (!_qosEvent.ConfigMetrics.ContainsKey(ConfigKeys.EnableLoginByWam))
                {
                    _qosEvent.ConfigMetrics[ConfigKeys.EnableLoginByWam] = new ConfigMetrics(ConfigKeys.EnableLoginByWam, $"Config-{ConfigKeys.EnableLoginByWam}",
                       AzConfigReader.GetAzConfig(ConfigKeys.EnableLoginByWam, true).ToString());
                }
            }
            catch (Exception ex)
            {
                WriteDebug(string.Format("Failed to add telemtry for config as {0}", ex.Message));
            }
        }

        protected override void EndProcessing()
        {
            AddConfigTelemetry();
            base.EndProcessing();
            // unregister the thread-safe write warning, because it won't work out of this cmdlet
            AzureSession.Instance.UnregisterComponent<EventHandler<StreamEventArgs>>(WriteWarningKey);
            AzureSession.Instance.RegisterComponent(WriteWarningKey, () => _originalWriteWarning);
            // unregister the thread-safe write information, because it won't work out of this cmdlet
            AzureSession.Instance.UnregisterComponent<EventHandler<StreamEventArgs>>(WriteInformationKey);
            AzureSession.Instance.RegisterComponent(WriteInformationKey, () => _originalWriteInformation);
        }
    }
}
