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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Remove Microsoft Azure Service AD Domain Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ADDomainExtensionNoun, DefaultParameterSetName = RemoveByRolesParameterSet), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureServiceADDomainExtensionCommand : BaseAzureServiceADDomainExtensionCmdlet
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
            RemoveExtension();
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
