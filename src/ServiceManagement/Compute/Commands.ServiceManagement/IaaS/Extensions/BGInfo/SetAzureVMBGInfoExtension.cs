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
        VirtualMachineBGInfoExtensionNoun,
        DefaultParameterSetName = SetBGInfoExtensionParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMBGInfoExtensionCommand : VirtualMachineBGInfoExtensionCmdletBase
    {
        protected const string SetBGInfoExtensionParamSetName = "SetBGInfoExtension";
        protected const string UninstallBGInfoExtensionParamSetName = "UninstallBGInfoExtension";

        [Parameter(
            ParameterSetName = SetBGInfoExtensionParamSetName,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable VM BGInfo Extension")]
        public override SwitchParameter Disable { get; set; }

        [Parameter(
            ParameterSetName = UninstallBGInfoExtensionParamSetName,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Uninstall VM BGInfo Extension")]
        public override SwitchParameter Uninstall { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Reference Name.")]
        [ValidateNotNullOrEmpty]
        public override string ReferenceName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ValidateParameters();
            RemovePredicateExtensions();
            AddResourceExtension();
            WriteObject(VM);
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            this.ReferenceName = string.IsNullOrEmpty(this.ReferenceName) ? ExtensionDefaultName : this.ReferenceName;
            this.Version = this.Version ?? ExtensionDefaultVersion;
        }
    }
}
