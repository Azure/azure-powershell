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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication;
using System.Security;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet("Login", "AzureRMAccount", DefaultParameterSetName = "User")]
    [OutputType(typeof(AzureRMProfile))]
    public class LoginAzureRMAccount : AzureRMCmdlet
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
        [Parameter(ParameterSetName = "ServicePrincipal", Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = "AccessToken", Mandatory = false, HelpMessage = "Tenant name or ID")]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

        [Parameter(ParameterSetName = "AccessToken", Mandatory = true, HelpMessage = "AccessToken")]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Subscription")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        public LoginAzureRMAccount()
            : base()
        {
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (Environment == null)
            {
                Environment = DefaultContext.Environment;
            }
        }

        protected override void ProcessRecord()
        {
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

            var profileClient = new ProfileClient();
            var account = this.ProfileClient.AddAccountAndLoadSubscriptions(azureAccount, ProfileClient.GetEnvironmentOrDefault(Environment), password);

            if (account != null)
            {
                WriteVerbose(string.Format(Resources.AddAccountAdded, azureAccount.Id));
                if (ProfileClient.Profile.DefaultSubscription != null)
                {
                    WriteVerbose(string.Format(Resources.AddAccountShowDefaultSubscription,
                        ProfileClient.Profile.DefaultSubscription.Name));
                }
                WriteVerbose(Resources.AddAccountViewSubscriptions);
                WriteVerbose(Resources.AddAccountChangeSubscription);

                string subscriptionsList = account.GetProperty(AzureAccount.Property.Subscriptions);
                string tenantsList = account.GetProperty(AzureAccount.Property.Tenants);

                if (subscriptionsList == null)
                {
                    WriteWarning(string.Format(Resources.NoSubscriptionAddedMessage, azureAccount.Id));
                }

                WriteObject(account.ToPSAzureAccount());
            }
        }
    }
}
