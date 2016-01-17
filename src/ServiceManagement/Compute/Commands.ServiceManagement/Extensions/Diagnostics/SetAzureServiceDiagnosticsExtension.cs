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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Set Microsoft Azure Service Diagnostics Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureServiceDiagnosticsExtension", DefaultParameterSetName = SetExtensionParameterSetName), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureServiceDiagnosticsExtensionCommand : BaseAzureServiceDiagnosticsExtensionCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingDiagnosticsConfigurationParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.SlotHelpMessage)]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.SlotHelpMessage)]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingDiagnosticsConfigurationParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.SlotHelpMessage)]
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

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = SetExtensionUsingDiagnosticsConfigurationParameterSetName, HelpMessage = "Diagnostics configuration")]
        [ValidateNotNullOrEmpty]
        public ExtensionConfigurationInput[] DiagnosticsConfiguration
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

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Thumbprint of a certificate used for encryption.")]
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

        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "Diagnostics Storage Account Name")]
        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Account Name")]
        [ValidateNotNullOrEmpty]
        public override string StorageAccountName
        {
            get;
            set;
        }

        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "Diagnostics Storage Account Key")]
        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Account Key")]
        [ValidateNotNullOrEmpty]
        public override string StorageAccountKey
        {
            get;
            set;
        }

        [Parameter(Position = 7, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "Diagnostics Storage Account Endpoint")]
        [Parameter(Position = 7, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Account Endpoint")]
        [ValidateNotNullOrEmpty]
        public override string StorageAccountEndpoint
        {
            get;
            set;
        }

        [Parameter(Position = 8, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "Diagnostics Storage Account Context")]
        [Parameter(Position = 8, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Storage Account Context")]
        [ValidateNotNullOrEmpty]
        public override AzureStorageContext StorageContext
        {
            get;
            set;
        }

        [Parameter(Position = 9, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "Diagnostics Configuration")]
        [Parameter(Position = 9, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "Diagnostics Configuration")]
        [ValidateNotNullOrEmpty]
        public override string DiagnosticsConfigurationPath
        {
            get;
            set;
        }

        [Parameter(Position = 10, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = "WAD version")]
        [Parameter(Position = 10, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = "WAD version")]
        public override string Version
        {
            get;
            set;
        }

        [Parameter(Position = 11, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [Parameter(Position = 11, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = SetExtensionUsingThumbprintParameterSetName, HelpMessage = ExtensionParameterPropertyHelper.ExtensionIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override string ExtensionId
        {
            get;
            set;
        }

        protected override void ValidateParameters()
        {
            // Common validation
            base.ValidateParameters();
            ValidateService();
            ValidateDeployment();

            if (this.ParameterSetName == SetExtensionUsingDiagnosticsConfigurationParameterSetName)
            {
                // Validate Role for each diagnostics configuration. Other validations have been done when create the configuration.
                foreach (var config in this.DiagnosticsConfiguration)
                {
                    var roleNames = config.Roles.Where(r => !r.Default).Select(r => r.RoleName).ToArray();
                    ValidateRoles(roleNames);
                }
            }
            else
            {
                ValidateRoles();
                ValidateThumbprint(true);
                ValidateStorageAccount();
                ValidateConfiguration();
            }
        }

        public void ExecuteCommand()
        {
            ValidateParameters();

            var configurations = GetConfigurations();

            var extConfig = Deployment == null ? null : Deployment.ExtensionConfiguration;
            var secondSlotExtConfig = PeerDeployment == null ? null : PeerDeployment.ExtensionConfiguration;

            // The later configuration will override the previous one
            foreach (var config in configurations)
            {
                extConfig = ExtensionManager.InstallExtension(config, Slot, extConfig, secondSlotExtConfig);
                extConfig = PostProcessExtensionConfigAfterInstallExtension(config, extConfig);
            }

            ChangeDeployment(extConfig);
        }

        private List<ExtensionConfigurationInput> GetConfigurations()
        {
            var result = new List<ExtensionConfigurationInput>();

            if (ParameterSetName == SetExtensionUsingDiagnosticsConfigurationParameterSetName)
            {
                // If user specified multiple configurations for the same role, we only take the later configuration for that role.
                // This not only improve the efficieny, one more important reason is current InstallExtension() implementation assumes
                // we call change deployment directly after installation. Calling InstallExtension() multiple times for the same role
                // may result in removing the extension which is still working.
                for (var i = 0; i < DiagnosticsConfiguration.Length; i++)
                {
                    var currentConfig = DiagnosticsConfiguration[i];
                    for (var j = i + 1; j < DiagnosticsConfiguration.Length && currentConfig.Roles.Any(); j++)
                    {
                        var followingConfig = DiagnosticsConfiguration[j];

                        // If the following configuration is applied to all roles, we simply ingore the whole current config.
                        if (followingConfig.Roles.Any(r => r.Default))
                        {
                            currentConfig.Roles.Clear();
                        }

                        // If the role appears in following config, we will take the later one and remove the role from current config.
                        foreach (var role in currentConfig.Roles.ToArray())
                        {
                            if (followingConfig.Roles.Any(r => r.RoleName == role.RoleName))
                            {
                                currentConfig.Roles.Remove(role);
                            }
                        }
                    }

                    if (currentConfig.Roles.Any())
                    {
                        result.Add(currentConfig);
                    }
                }
            }
            else
            {
                // If user specified a config file path, then there is only one configuration.
                result.Add(new ExtensionConfigurationInput
                {
                    Id = ExtensionId,
                    Version = Version,
                    ProviderNameSpace = ProviderNamespace,
                    Type = ExtensionName,
                    CertificateThumbprint = CertificateThumbprint,
                    ThumbprintAlgorithm = ThumbprintAlgorithm,
                    X509Certificate = X509Certificate,
                    PublicConfiguration = PublicConfiguration,
                    PrivateConfiguration = PrivateConfiguration,
                    Roles = new ExtensionRoleList(Role != null && Role.Any()
                                                ? Role.Select(r => new ExtensionRole(r))
                                                : Enumerable.Repeat(new ExtensionRole(), 1))
                });
            }

            return result;
        }

        /// <summary>
        /// The configuration must be defined in either allRoles or namedRoles.
        /// Otherwise, it will fail for trying to apply the same extension.
        /// We only apply the fix here but not in ExtensionManager, so other commands won't get affected.
        /// </summary>
        /// <param name="configInput">The configuration used for InstallExtension()</param>
        /// <param name="extConfig">The extension config after InstallExtension()</param>
        private Microsoft.WindowsAzure.Management.Compute.Models.ExtensionConfiguration PostProcessExtensionConfigAfterInstallExtension(
            ExtensionConfigurationInput configInput,
            Microsoft.WindowsAzure.Management.Compute.Models.ExtensionConfiguration extConfig)
        {
            ExtensionConfigurationBuilder builder = ExtensionManager.GetBuilder(extConfig);
            if (configInput.Roles.All(r => r.Default))
            {
                // If the configuration applies to all roles, remove the ones defined in each named roles
                foreach (var role in Deployment.Roles)
                {
                    builder.Remove(role.RoleName, ProviderNamespace, ExtensionName);
                }
            }
            else
            {
                // If the configuration applies to some specific roles and there is already extension defined in allRoles,
                // we remove the setting from allRoles and move it to specific namedRoles.
                if (builder.ExistDefault(ProviderNamespace, ExtensionName))
                {
                    var diagnosticExtensionId = extConfig.AllRoles.FirstOrDefault(ext =>
                    {
                        var e = ExtensionManager.GetExtension(ext.Id);
                        return e != null && e.ProviderNamespace == ProviderNamespace && e.Type == ExtensionName;
                    }).Id;
                    builder.RemoveDefault(diagnosticExtensionId);

                    foreach (var role in Deployment.Roles)
                    {
                        // The role is previously configured by allRoles, move it to the namedRole itself
                        if (!configInput.Roles.Exists(r => r.RoleName == role.RoleName))
                        {
                            builder.Add(role.RoleName, diagnosticExtensionId);
                        }
                    }
                }
            }

            return builder.ToConfiguration();
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
