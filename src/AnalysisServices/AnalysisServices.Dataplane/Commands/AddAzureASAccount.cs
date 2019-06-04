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

using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

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

        // This is ignored since we only support public cloud
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

        public override void ExecuteCmdlet()
        {
            System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create();
            ps.AddCommand("Connect-AzAccount");

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Credential)))
            {
                ps.AddParameter("Credential",  Credential);
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ServicePrincipal)))
            {
                ps.AddParameter("ServicePrincipal", ServicePrincipal);
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(TenantId)))
            {
                ps.AddParameter("Tenant", TenantId);
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ApplicationId)))
            {
                ps.AddParameter("ApplicationId", ApplicationId);
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(CertificateThumbprint)))
            {
                ps.AddParameter("CertificateThumbprint", CertificateThumbprint);
            }

            ps.Invoke();
        }

        protected override void InitializeQosEvent()
        {
            // No data collection for this cmdlet
        }
    }
}
