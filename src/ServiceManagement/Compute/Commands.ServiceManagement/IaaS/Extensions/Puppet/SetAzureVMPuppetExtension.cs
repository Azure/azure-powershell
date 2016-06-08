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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    [Cmdlet(
        VerbsCommon.Set,
        VirtualMachinePuppetExtensionNoun,
        DefaultParameterSetName = SetPuppetExtensionParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMPuppetExtensionCommand : VirtualMachinePuppetExtensionCmdletBase
    {
        protected const string SetPuppetExtensionParamSetName = "SetPuppetExtension";

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Puppet Master server FQDN to which the Puppet Agent should connect.")]
        [ValidateNotNullOrEmpty]
        public string PuppetMasterServer { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable VM Puppet Extension.")]
        public override SwitchParameter Disable { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Reference Name.")]
        [ValidateNotNullOrEmpty]
        public override string ReferenceName { get; set; }

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
            this.Version = this.Version ?? ExtensionDefaultVersion;
            this.ReferenceName = this.ReferenceName ?? LegacyReferenceName;
            this.PrivateConfiguration = string.Format(PrivateConfigurationTemplate, this.EscapeJsonCharacters(this.PuppetMasterServer));
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }

        private string EscapeJsonCharacters(string value)
        {
            string serializedValue = Newtonsoft.Json.JsonConvert.SerializeObject(value);

            // Since SerializeObject method automatically surrounds result with double quotes, we need to remove them.
            return serializedValue.Trim('"');
        }
    }
}