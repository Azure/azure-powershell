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
using Microsoft.WindowsAzure.Commands.Common.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// New Microsoft Azure Service Diagnostics Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureServiceDiagnosticsExtensionConfig", DefaultParameterSetName = NewExtensionParameterSetName), OutputType(typeof(ExtensionConfigurationInput))]
    public class NewAzureServiceDiagnosticsExtensionConfigCommand : BaseAzureServiceDiagnosticsExtensionCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.RoleHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.RoleHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string[] Role
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.X509CertificateHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override X509Certificate2 X509Certificate
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.CertificateThumbprintHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string CertificateThumbprint
        {
            get;
            set;
        }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ThumbprintAlgorithmHelpMessage)]
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ThumbprintAlgorithmHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ThumbprintAlgorithm
        {
            get;
            set;
        }

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = "Diagnostics Storage Account Name")]
        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Account Name")]
        [ValidateNotNullOrEmpty]
        public override string StorageAccountName
        {
            get;
            set;
        }

        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = "Diagnostics Storage Account Key")]
        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Account Key")]
        [ValidateNotNullOrEmpty]
        public override string StorageAccountKey
        {
            get;
            set;
        }

        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = "Diagnostics Storage Account Endpoint")]
        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Account Endpoint")]
        [ValidateNotNullOrEmpty]
        public override string StorageAccountEndpoint
        {
            get;
            set;
        }

        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = "Diagnostics Storage Name")]
        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Name")]
        [ValidateNotNullOrEmpty]
        public override AzureStorageContext StorageContext
        {
            get;
            set;
        }

        [Parameter(Position = 7, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = "Diagnostics Configuration")]
        [Parameter(Position = 7, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Configuration")]
        [ValidateNotNullOrEmpty]
        public override string DiagnosticsConfigurationPath
        {
            get;
            set;
        }

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = NewExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ExtensionId
        {
            get;
            set;
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ValidateThumbprint(false);
            ValidateStorageAccount();
            ValidateConfiguration();
        }

        public void ExecuteCommand()
        {
            ValidateParameters();
            WriteObject(new ExtensionConfigurationInput
            {
                Id = ExtensionId,
                CertificateThumbprint = CertificateThumbprint,
                ThumbprintAlgorithm = ThumbprintAlgorithm,
                ProviderNameSpace = ProviderNamespace,
                Type = ExtensionName,
                PublicConfiguration = PublicConfiguration,
                PrivateConfiguration = PrivateConfiguration,
                X509Certificate = X509Certificate,
                Roles = new ExtensionRoleList(Role != null && Role.Any() ? Role.Select(r => new ExtensionRole(r)) : Enumerable.Repeat(new ExtensionRole(), 1))
            });
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
