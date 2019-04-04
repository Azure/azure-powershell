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
    [OutputType(typeof(AsAzureProfile))]
    public class AddAzureASAccountCommand : AzurePSCmdlet
    {
        private const string UserParameterSet = "UserParameterSetName";
        private const string ServicePrincipalWithPasswordParameterSet = "ServicePrincipalWithPasswordParameterSetName";
        private const string ServicePrincipalWithCertificateParameterSet = "ServicePrincipalWithCertificateParameterSetName";

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

        protected AsAzureEnvironment AsEnvironment;

        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Management context
                return null;
            }
        }

        protected override string DataCollectionWarning
        {
            get
            {
                return Resources.ARMDataCollectionMessage;
            }
        }

        protected override void BeginProcessing()
        {
            this._dataCollectionProfile = new AzurePSDataCollectionProfile(false);

            if (string.IsNullOrEmpty(RolloutEnvironment))
            {
                RolloutEnvironment = AsAzureClientSession.GetDefaultEnvironmentName();
            }

            if (AsAzureClientSession.Instance.Profile.Environments.ContainsKey(RolloutEnvironment))
            {
                AsEnvironment = (AsAzureEnvironment)AsAzureClientSession.Instance.Profile.Environments[RolloutEnvironment];
            }
            else
            {
                AsEnvironment = AsAzureClientSession.Instance.Profile.CreateEnvironment(RolloutEnvironment);
            }
            base.BeginProcessing();
        }

        protected override void InitializeQosEvent()
        {
            // nothing to do here.
        }

        protected override void SetupDebuggingTraces()
        {
            // nothing to do here.
        }

        protected override void TearDownDebuggingTraces()
        {
            // nothing to do here.
        }

        protected override void SetupHttpClientPipeline()
        {
            // nothing to do here.
        }

        protected override void TearDownHttpClientPipeline()
        {
            // nothing to do here.
        }

        public override void ExecuteCmdlet()
        {
            var azureAccount = new AsAzureAccount
            {
                Type = ServicePrincipal ? AsAzureAccount.AccountType.ServicePrincipal : AsAzureAccount.AccountType.User
            };

            SecureString password = null;
            if (Credential != null)
            {
                azureAccount.Id = Credential.UserName;
                password = Credential.Password;
            }

            if (ServicePrincipal)
            {
                azureAccount.Tenant = TenantId;

                if (!string.IsNullOrEmpty(ApplicationId))
                {
                    azureAccount.Id = ApplicationId;
                }
                if (!string.IsNullOrEmpty(CertificateThumbprint))
                {
                    azureAccount.CertificateThumbprint = CertificateThumbprint;
                }
            }

            if (ShouldProcess(string.Format(Resources.LoginTarget, AsEnvironment.Name), "log in"))
            {
                var currentProfile = AsAzureClientSession.Instance.Profile;
                var currentContext = currentProfile.Context;

                // If there is no current context create one. If there is one already then
                // if the current credentials (userid) match the one that is already in context then use it.
                // if either the userid that is logging in or the environment to which login is happening is
                // different than the one in the context then clear the current context and proceed to login.
                // At any given point in time, we should only have one context i.e. one user logged in to one
                // environment.
                if (currentContext == null || Credential == null ||
                    string.IsNullOrEmpty(currentContext.Account.Id) || 
                    !currentContext.Account.Id.Equals(Credential.UserName) ||
                    !RolloutEnvironment.Equals(currentContext.Environment.Name))
                {
                    AsAzureClientSession.Instance.SetCurrentContext(azureAccount, AsEnvironment);
                }
// TODO: Remove IfDef
#if NETSTANDARD
                var asAzureProfile = AsAzureClientSession.Instance.Login(currentProfile.Context, password, WriteWarning);
#else
                var asAzureProfile = AsAzureClientSession.Instance.Login(currentProfile.Context, password);
#endif

                WriteObject(asAzureProfile);
            }
        }
    }
}
