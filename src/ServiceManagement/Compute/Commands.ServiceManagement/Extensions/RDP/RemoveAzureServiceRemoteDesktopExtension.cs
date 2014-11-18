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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Remove Microsoft Azure Service Remote Desktop Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureServiceRemoteDesktopExtension", DefaultParameterSetName = RemoveByRolesParameterSet), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureServiceRemoteDesktopExtensionCommand : BaseAzureServiceRemoteDesktopExtensionCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveAllRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.SlotHelpMessage)]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveAllRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.SlotHelpMessage)]
        [ValidateSet(DeploymentSlotType.Production, DeploymentSlotType.Staging, IgnoreCase = true)]
        public override string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.RoleHelpMessage)]
        public override string[] Role
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = RemoveAllRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.UninstallConfigurationHelpMessage)]
        public override SwitchParameter UninstallConfiguration
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
        }

        public void ExecuteCommand()
        {
            ValidateParameters();
            ExtensionConfigurationBuilder configBuilder = ExtensionManager.GetBuilder(Deployment != null ? Deployment.ExtensionConfiguration : null);
            if (UninstallConfiguration && configBuilder.ExistAny(ProviderNamespace, ExtensionName))
            {
                configBuilder.RemoveAny(ProviderNamespace, ExtensionName);
                WriteVerbose(string.Format(Resources.ServiceExtensionRemovingFromAllRoles, ExtensionName, ServiceName));
                ChangeDeployment(configBuilder.ToConfiguration());
            }
            else if (configBuilder.Exist(Role, ProviderNamespace, ExtensionName))
            {
                configBuilder.Remove(Role, ProviderNamespace, ExtensionName);
                if (Role == null || !Role.Any())
                {
                    WriteVerbose(string.Format(Resources.ServiceExtensionRemovingFromAllRoles, ExtensionName, ServiceName));
                }
                else
                {
                    bool defaultExists = configBuilder.ExistDefault(ProviderNamespace, ExtensionName);
                    foreach (var r in Role)
                    {
                        WriteVerbose(string.Format(Resources.ServiceExtensionRemovingFromSpecificRoles, ExtensionName, r, ServiceName));
                        if (defaultExists)
                        {
                            WriteVerbose(string.Format(Resources.ServiceExtensionRemovingSpecificAndApplyingDefault, ExtensionName, r));
                        }
                    }
                }
                ChangeDeployment(configBuilder.ToConfiguration());
            }
            else
            {
                WriteVerbose(string.Format(Resources.ServiceExtensionNoExistingExtensionsEnabledOnRoles, ProviderNamespace, ExtensionName));
            }

            if (UninstallConfiguration)
            {
                var allConfig = ExtensionManager.GetBuilder();
                var deploymentList = (from slot in (new string[] { DeploymentSlotType.Production, DeploymentSlotType.Staging })
                                      let d = GetDeployment(slot)
                                      where d != null
                                      select d).ToList();
                deploymentList.ForEach(d => allConfig.Add(d.ExtensionConfiguration));
                ExtensionManager.Uninstall(ProviderNamespace, ExtensionName, allConfig.ToConfiguration());
            }
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
