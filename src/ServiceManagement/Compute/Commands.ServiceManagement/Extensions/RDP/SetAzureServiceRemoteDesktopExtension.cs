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
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Set Microsoft Azure Service Remote Desktop Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureServiceRemoteDesktopExtension", DefaultParameterSetName = SetExtensionParameterSetName), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureServiceRemoteDesktopExtensionCommand : BaseAzureServiceRemoteDesktopExtensionCmdlet
    {

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.SlotHelpMessage)]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.SlotHelpMessage)]
        [ValidateSet(DeploymentSlotType.Production, DeploymentSlotType.Staging, IgnoreCase = true)]
        public override string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.RoleHelpMessage)]
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.RoleHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string[] Role
        {
            get;
            set;
        }

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.X509CertificateHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override X509Certificate2 X509Certificate
        {
            get;
            set;
        }

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.CertificateThumbprintHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string CertificateThumbprint
        {
            get;
            set;
        }

        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ThumbprintAlgorithmHelpMessage)]
        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ThumbprintAlgorithmHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ThumbprintAlgorithm
        {
            get;
            set;
        }

        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "Remote Desktop Credential")]
        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Remote Desktop Credential ")]
        [ValidateNotNullOrEmpty]
        public override PSCredential Credential
        {
            get;
            set;
        }

        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "Remote Desktop User Expiration Date")]
        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Remote Desktop User Expiration Date")]
        [ValidateNotNullOrEmpty]
        public override DateTime Expiration
        {
            get;
            set;
        }

        [Parameter(Position = 7, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.VersionHelpMessage)]
        [Parameter(Position = 7, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.VersionHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string Version
        {
            get;
            set;
        }

        [Parameter(Position = 8, Mandatory  = false, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ExtensionId
        {
            get;
            set;
        }


        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ValidateService();
            ValidateDeployment();
            ValidateRoles();
            ValidateThumbprint(true);
            Expiration = Expiration.Equals(default(DateTime)) ? DateTime.Now.AddMonths(12) : Expiration;
            ValidateConfiguration();
        }

        public void ExecuteCommand()
        {
            ValidateParameters();
            ExtensionConfigurationInput context = new ExtensionConfigurationInput
            {
                Id = ExtensionId,
                ProviderNameSpace = ProviderNamespace,
                Type = ExtensionName,
                CertificateThumbprint = CertificateThumbprint,
                ThumbprintAlgorithm = ThumbprintAlgorithm,
                X509Certificate = X509Certificate,
                PublicConfiguration = PublicConfiguration,
                PrivateConfiguration = PrivateConfiguration,
                Version = Version,
                Roles = new ExtensionRoleList(Role != null && Role.Any() ? Role.Select(r => new ExtensionRole(r)) : Enumerable.Repeat(new ExtensionRole(), 1))
            };
            var extConfig = ExtensionManager.InstallExtension(context, Slot, Deployment, PeerDeployment);
            ChangeDeployment(extConfig);
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
