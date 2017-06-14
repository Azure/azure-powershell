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
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Remove Microsoft Azure Service Diagnostics Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureServiceDiagnosticsExtension", DefaultParameterSetName = RemoveByRolesParameterSet), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureServiceDiagnosticsExtensionCommand : BaseAzureServiceDiagnosticsExtensionCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveAllRolesParameterSet, HelpMessage = ExtensionParameterPropertyHelper.ServiceNameHelpMessage)]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByRolesParameterSet, HelpMessage =  ExtensionParameterPropertyHelper.SlotHelpMessage)]
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

            bool removeAll = Role == null || !Role.Any();
            ExtensionConfigurationBuilder configBuilder = ExtensionManager.GetBuilder(Deployment != null ? Deployment.ExtensionConfiguration : null);
            if ((UninstallConfiguration || removeAll) && configBuilder.ExistAny(ProviderNamespace, ExtensionName))
            {
                // Remove extension for all roles
                configBuilder.RemoveAny(ProviderNamespace, ExtensionName);
                WriteWarning(string.Format(Resources.ServiceExtensionRemovingFromAllRoles, ExtensionName, ServiceName));

                ChangeDeployment(configBuilder.ToConfiguration());
            }
            else if (!removeAll && configBuilder.Exist(Role, ProviderNamespace, ExtensionName))
            {
                // Remove extension for the specified roles
                bool defaultExists = configBuilder.ExistDefault(ProviderNamespace, ExtensionName);
                foreach (var r in Role)
                {
                    var singleRoleAsArray = new string[] { r };
                    if (configBuilder.Exist(singleRoleAsArray, ProviderNamespace, ExtensionName))
                    {
                        configBuilder.Remove(singleRoleAsArray, ProviderNamespace, ExtensionName);
                        WriteWarning(string.Format(Resources.ServiceExtensionRemovingFromSpecificRoles, ExtensionName, r, ServiceName));
                    }
                    else
                    {
                        WriteWarning(string.Format(Resources.ServiceExtensionNoExistingExtensionsEnabledOnRole, ProviderNamespace, ExtensionName, r));
                    }

                    if (defaultExists)
                    {
                        WriteWarning(string.Format(Resources.ServiceExtensionRemovingSpecificAndApplyingDefault, ExtensionName, r));
                    }
                }

                ChangeDeployment(configBuilder.ToConfiguration());
            }
            else
            {
                WriteWarning(string.Format(Resources.ServiceExtensionNoExistingExtensionsEnabledOnRoles, ProviderNamespace, ExtensionName));
            }

            if (UninstallConfiguration)
            {
                var allConfig = ExtensionManager.GetBuilder();
                var deploymentList = (from slot in (new string[] { DeploymentSlot.Production.ToString(), DeploymentSlot.Staging.ToString() })
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
