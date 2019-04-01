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
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Security;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [CmdletDeprecation("2.0.0")]
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzurePrefix + "AnalysisServicesAccount", DefaultParameterSetName = "UserParameterSetName", SupportsShouldProcess =true)]
    [Alias("Login-AzureAsAccount", "Login-AzAsAccount")]
    [OutputType(typeof(PSAzureProfile))]
    public class AddAzureASAccountCommand : AzureContextModificationCmdlet
    {
        private const string UserParameterSet = "UserParameterSetName";
        private const string ServicePrincipalWithPasswordParameterSet = "ServicePrincipalWithPasswordParameterSetName";
        private const string ServicePrincipalWithCertificateParameterSet = "ServicePrincipalWithCertificateParameterSetName";

        // This is ignored sicne we only supported public cloud
        [Parameter(ParameterSetName = UserParameterSet,
            Mandatory = false, HelpMessage = "Name of the Azure Analysis Services environment to which to logon to", Position = 0)]
        [Parameter(ParameterSetName = ServicePrincipalWithPasswordParameterSet,
            Mandatory = true, HelpMessage = "Name of the Azure Analysis Services environment to which to logon to")]
        [Parameter(ParameterSetName = ServicePrincipalWithCertificateParameterSet,
            Mandatory = true, HelpMessage = "Name of the Azure Analysis Services environment to which to logon to")]
        public string RolloutEnvironment { get; set; }

        [Parameter(ParameterSetName = UserParameterSet,
            Mandatory = false, HelpMessage = "Login credentials to the Azure Analysis Services environment", Position = 1)]
        [Parameter(ParameterSetName = ServicePrincipalWithPasswordParameterSet,
            Mandatory = true, HelpMessage = "Login credentials to the Azure Analysis Services environment")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalWithPasswordParameterSet,
            Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalWithCertificateParameterSet,
            Mandatory = true)]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalWithPasswordParameterSet,
            Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = ServicePrincipalWithCertificateParameterSet,
            Mandatory = true, HelpMessage = "Tenant name or ID")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalWithCertificateParameterSet,
            Mandatory = true, HelpMessage = "The application ID.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalWithCertificateParameterSet,
            Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        [ValidateNotNullOrEmpty]
        public string CertificateThumbprint { get; set; }

        private IAzureEnvironment _environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];

        protected override IAzureContext DefaultContext
        {
            get
            {
                return null;
            }
        }

        public override void ExecuteCmdlet()
        {
            var azureAccount = new AzureAccount();

            SecureString password = null;
            if (Credential != null)
            {
                azureAccount.Id = Credential.UserName;
                password = Credential.Password;
            }

            if (ServicePrincipal)
            {
                azureAccount.Type = AzureAccount.AccountType.ServicePrincipal;
                azureAccount.SetProperty(AzureAccount.Property.Tenants, TenantId);

                if (!string.IsNullOrEmpty(ApplicationId))
                {
                    azureAccount.Id = ApplicationId;
                }

                if (!string.IsNullOrEmpty(CertificateThumbprint))
                {
                    azureAccount.SetThumbprint(CertificateThumbprint);
                }

            }
            else
            {
                azureAccount.Type = AzureAccount.AccountType.User;
            }

            if (azureAccount.Type == AzureAccount.AccountType.ServicePrincipal && string.IsNullOrEmpty(CertificateThumbprint))
            {
                azureAccount.SetProperty(AzureAccount.Property.ServicePrincipalSecret, password.ConvertToString());
            }

            if (ShouldProcess(string.Format(Resources.LoginTarget, azureAccount.Type, _environment.Name), "log in"))
            {
                if (AzureRmProfileProvider.Instance.Profile == null)
                {
                    InitializeProfileProvider();
                }

                string subscriptionName = null;
                string subscriptionId = null;
                bool SkipValidation = false;

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
                         WriteWarning,
                         name));
                });
            }
        }

        private void SetContextWithOverwritePrompt(Action<AzureRmProfile, RMProfileClient, string> setContextAction)
        {
            string name = null;
            var profile = DefaultProfile as AzureRmProfile;
            ModifyContext((prof, client) => setContextAction(prof, client, name));
        }
    }
}
