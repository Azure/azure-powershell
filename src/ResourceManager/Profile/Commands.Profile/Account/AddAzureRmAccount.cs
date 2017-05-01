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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Security;
using Commands.Profile.Netcore;
using Commands.Profile.Netcore.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Add", "AzureRmAccount", DefaultParameterSetName = "UserWithSubscriptionId", SupportsShouldProcess=true)]
    [Alias("Login-AzureRmAccount")]
    [OutputType(typeof(PSAzureProfile))]
    public class AddAzureRMAccountCommand : AzureRMCmdlet
#if !NETSTANDARD1_6
        , IModuleAssemblyInitializer
#endif
    {
        private const string UserParameterSetWithSubscriptionId = "UserWithSubscriptionId";
        private const string UserParameterSetWithSubscriptionName = "UserWithSubscriptionName";
        private const string ServicePrincipalParameterSetWithSubscriptionId = "ServicePrincipalWithSubscriptionId";
        private const string ServicePrincipalParameterSetWithSubscriptionName = "ServicePrincipalWithSubscriptionName";
        private const string ServicePrincipalCertificateParameterSetWithSubscriptionId = "ServicePrincipalCertificateWithSubscriptionId";
        private const string ServicePrincipalCertificateParameterSetWithSubscriptionName = "ServicePrincipalCertificateWithSubscriptionName";
        private const string AccessTokenParameterSetWithSubscriptionId = "AccessTokenWithSubscriptionId";
        private const string AccessTokenParameterSetWithSubscriptionName = "AccessTokenWithSubscriptionName";

        [Parameter(Mandatory = false, HelpMessage = "Environment containing the account to log into")]
        [Obsolete("This parameter is only for backwards compatibility; users should use EnvironmentName instead.")]
        [ValidateNotNullOrEmpty]
        public AzureEnvironment Environment { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [ValidateNotNullOrEmpty]

        public string EnvironmentName { get; set; }

        
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
#pragma warning disable 0618
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
                        string.Format(Messages.UnknownEnvironment, EnvironmentName));
                }
            }
#pragma warning restore 0618
        }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(SubscriptionId) &&
                !string.IsNullOrWhiteSpace(SubscriptionName))
            {
                throw new PSInvalidOperationException(Messages.BothSubscriptionIdAndNameProvided);
            }

            Guid subscrptionIdGuid;
            if (!string.IsNullOrWhiteSpace(SubscriptionId) &&
                !Guid.TryParse(SubscriptionId, out subscrptionIdGuid))
            {
                throw new PSInvalidOperationException(
                    string.Format(Messages.InvalidSubscriptionId, SubscriptionId));
            }

            AzureAccount azureAccount = new AzureAccount();

            if (!string.IsNullOrEmpty(AccessToken))
            {
                if (string.IsNullOrWhiteSpace(AccountId))
                {
                    throw new PSInvalidOperationException(Messages.AccountIdRequired);
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
#pragma warning disable 0618
            if (ShouldProcess(string.Format(Messages.LoginTarget, azureAccount.Type, Environment.Name), "log in"))
            {
                if (AzureRmProfileProvider.Instance.Profile == null)
                {
                    AzureRmProfileProvider.Instance.Profile = new AzureRMProfile();
                }

                var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);

                WriteObject((PSAzureProfile) profileClient.Login(
                    azureAccount, 
                    Environment, 
                    TenantId, 
                    SubscriptionId,
                    SubscriptionName, 
                    password
#if NETSTANDARD1_6
                    , (s) => WriteWarning(s)
#endif
                    ));
            }
#pragma warning restore 0618
        }

        /// <summary>
        /// Load global aliases for ARM
        /// </summary>
#if !NETSTANDARD1_6
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
            catch(Exception) when (TestMockSupport.RunningMocked)
            {
                // This will throw exception for tests, ignore.
            }
        }
#else
        private readonly string[] AdditionalAssemblies = new[]
        {
            "Newtonsoft.Json.dll",
            "System.Runtime.Serialization.Json.dll"
        };

        /// <summary>
        /// Load global aliases for ARM
        /// </summary>
        public void OnImport()
        {
            try
            {
                var invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                
                invoker = invoker.AddScript("$PSModuleRoot = $ExecutionContext.SessionState.Module.ModuleBase");
                foreach (var assembly in AdditionalAssemblies)
                {
                    invoker = invoker.AddScript($"$module = Join-Path -Path $PSModuleRoot -ChildPath {assembly}");
                    invoker = invoker.AddScript("Add-Type -Path $module");
                }

                invoker = invoker.AddScript("$VerbosePreference=\"Continue\"");
                invoker.Invoke();
            }
            catch(Exception) when (TestMockSupport.RunningMocked)
            {
                // This will throw exception for tests, ignore.
            }
        }        
#endif
    }
}
