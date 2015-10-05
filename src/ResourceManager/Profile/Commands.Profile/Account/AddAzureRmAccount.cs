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
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using Microsoft.Azure.Commands.Profile.Properties;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Add", "AzureRmAccount", DefaultParameterSetName = "User")]
    [Alias("Login-AzureRmAccount")]
    [OutputType(typeof(PSAzureProfile))]
    public class AddAzureRMAccountCommand : AzureRMCmdlet , IModuleAssemblyInitializer
    {
        [Parameter(Mandatory = false, HelpMessage = "Environment containing the account to log into")]
        [ValidateNotNullOrEmpty]
        public AzureEnvironment Environment { get; set; }

        [Parameter(ParameterSetName = "User", Mandatory = false, HelpMessage = "Optional credential")]
        [Parameter(ParameterSetName = "ServicePrincipal", Mandatory = true, HelpMessage = "Credential")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = "ServicePrincipal", Mandatory = true)]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(ParameterSetName = "User", Mandatory = false, HelpMessage = "Optional tenant name or ID")]
        [Parameter(ParameterSetName = "ServicePrincipal", Mandatory = true, HelpMessage = "TenantId name or ID")]
        [Parameter(ParameterSetName = "AccessToken", Mandatory = false, HelpMessage = "TenantId name or ID")]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

        [Parameter(ParameterSetName = "AccessToken", Mandatory = true, HelpMessage = "AccessToken")]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Subscription")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Subscription")]
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
            if (Environment == null)
            {
                Environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            }
        }

        protected override void ProcessRecord()
        {
            if (SubscriptionId != null && SubscriptionName != null)
            {
                throw new PSInvalidOperationException(Resources.BothSubscriptionIdAndNameProvided);
            }

            Guid subscrptionIdGuid;
            if (SubscriptionId != null && !Guid.TryParse(SubscriptionId, out subscrptionIdGuid))
            {
                throw new PSInvalidOperationException(Resources.InvalidSubscriptionId);
            }

            AzureAccount azureAccount = new AzureAccount();

            if (!string.IsNullOrEmpty(AccessToken))
            {
                azureAccount.Type = AzureAccount.AccountType.AccessToken;
            }
            else if (ServicePrincipal.IsPresent)
            {
                azureAccount.Type = AzureAccount.AccountType.ServicePrincipal;
            }
            else
            {
                azureAccount.Type = AzureAccount.AccountType.User;
            }

            SecureString password = null;
            if (Credential != null)
            {
                azureAccount.Id = Credential.UserName;
                password = Credential.Password;
            }

            if (!string.IsNullOrEmpty(Tenant))
            {
                azureAccount.SetProperty(AzureAccount.Property.Tenants, new[] { Tenant });
            }

            if( AzureRmProfileProvider.Instance.Profile == null)
            {
                AzureRmProfileProvider.Instance.Profile = new AzureRMProfile();
            }

            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);
            
            WriteObject((PSAzureProfile)profileClient.Login(azureAccount, Environment, Tenant, SubscriptionId, SubscriptionName, password));
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
