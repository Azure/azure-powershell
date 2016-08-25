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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    [Cmdlet(
        VerbsCommon.Set,
        VirtualMachineAccessExtensionNoun,
        DefaultParameterSetName = EnableExtensionParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMAccessExtensionCommand : VirtualMachineAccessExtensionCmdletBase
    {
        public const string EnableExtensionParamSetName = "EnableAccessExtension";
        public const string DisableExtensionParamSetName = "DisableAccessExtension";
        public const string UninstallExtensionParamSetName = "UninstallAccessExtension";

        [Parameter(
            ParameterSetName = EnableExtensionParamSetName,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "New or Existing User Name")]
        public override string UserName { get; set; }

        [Parameter(
            ParameterSetName = EnableExtensionParamSetName,
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "New or Existing User Password")]
        public override string Password { get; set; }

        [Parameter(
            ParameterSetName = DisableExtensionParamSetName,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable VM Access Extension")]
        public override SwitchParameter Disable { get; set; }

        [Parameter(
            ParameterSetName = UninstallExtensionParamSetName,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Uninstall VM Access Extension")]
        public override SwitchParameter Uninstall { get; set; }

        [Parameter(
            ParameterSetName = EnableExtensionParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Reference Name.")]
        [Parameter(
            ParameterSetName = DisableExtensionParamSetName,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Reference Name.")]
        [Parameter(
            ParameterSetName = UninstallExtensionParamSetName,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Reference Name.")]
        [ValidateNotNullOrEmpty]
        public override string ReferenceName { get; set; }

        [Parameter(
            ParameterSetName = EnableExtensionParamSetName,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [Parameter(
            ParameterSetName = DisableExtensionParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [Parameter(
            ParameterSetName = UninstallExtensionParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            HelpMessage = "Re-apply a configuration to an extension when the configuration has not been updated.")]
        public override SwitchParameter ForceUpdate { get; set; }

        internal void ExecuteCommand()
        {
            ValidateParameters();
            RemovePredicateExtensions();
            AddResourceExtension();
            WriteObject(VM);
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            if (IsLegacyExtension())
            {
                this.PublicConfiguration = GetLegacyConfiguration();
                this.Version = VMAccessAgentLegacyVersion;
            }
            else if (IsXmlExtension(this.Version))
            {
                this.ReferenceName = string.IsNullOrEmpty(this.ReferenceName) ? ExtensionDefaultName : this.ReferenceName;
                this.PublicConfiguration = GetPublicConfiguration();
                this.PrivateConfiguration = GetPrivateConfiguration();
            }
            else
            {
                this.ReferenceName = string.IsNullOrEmpty(this.ReferenceName) ? ExtensionDefaultName : this.ReferenceName;
                this.PublicConfiguration = GetJsonPublicConfiguration();
                this.PrivateConfiguration = GetJsonPrivateConfiguration();
                if (string.IsNullOrEmpty(this.Version))
                {
                    this.Version = ExtensionDefaultVersion;
                }
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}
