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

using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// New Microsoft Azure Service Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureServiceExtensionConfig", DefaultParameterSetName = NewExtensionParameterSetName), OutputType(typeof(ExtensionConfigurationInput))]
    public class NewAzureServiceExtensionConfigCommand : BaseAzureServiceExtensionCmdlet
    {
        private const string NetExtensionParameterSetName = NewExtensionParameterSetName;
        private const string NetExtensionUsingThumbprintParameterSetName = NewExtensionUsingThumbprintParameterSetName;
        private const string NetUpdateExtensionStatusParameterSetName = UpdateExtensionStatusParameterSetName;

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.RoleHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.RoleHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = NetUpdateExtensionStatusParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string[] Role
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.X509CertificateHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override X509Certificate2 X509Certificate
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.CertificateThumbprintHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string CertificateThumbprint
        {
            get;
            set;
        }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ThumbprintAlgorithmHelpMessage)]
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ThumbprintAlgorithmHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ThumbprintAlgorithm
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionNameHelpMessage)]
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ExtensionName
        {
            get;
            set;
        }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ProviderNamespaceHelpMessage)]
        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ProviderNamespaceHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ProviderNamespace
        {
            get;
            set;
        }

        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.PublicConfigurationHelpMessage)]
        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.PublicConfigurationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string PublicConfiguration
        {
            get;
            set;
        }


        [Parameter(Position = 6, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.PrivateConfigurationHelpMessage)]
        [Parameter(Position = 6, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.PrivateConfigurationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string PrivateConfiguration
        {
            get;
            set;
        }

        [Parameter(Position = 7, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.VersionHelpMessage)]
        [Parameter(Position = 7, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.VersionHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string Version
        {
            get;
            set;
        }

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = NetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetUpdateExtensionStatusParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ExtensionId
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NetUpdateExtensionStatusParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionStateHelpMessage)]
        [ValidateSet("Enable", "Disable", "Uninstall", IgnoreCase = true)]
        public override string ExtensionState
        {
            get;
            set;
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ValidateThumbprint(false);
            ValidateConfiguration();
        }

        public void ExecuteCommand()
        {
            ValidateParameters();
            WriteObject(new ExtensionConfigurationInput
            {
                Id = ExtensionId,
                State = ExtensionState,
                CertificateThumbprint = CertificateThumbprint,
                ThumbprintAlgorithm = ThumbprintAlgorithm,
                ProviderNameSpace = ProviderNamespace,
                Type = ExtensionName,
                PublicConfiguration = PublicConfiguration,
                PrivateConfiguration = PrivateConfiguration,
                X509Certificate = X509Certificate,
                Version = Version,
                Roles = new ExtensionRoleList(Role != null && Role.Any() ? Role.Select(r => new ExtensionRole(r)) : Enumerable.Repeat(new ExtensionRole(), 1))
            });
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
