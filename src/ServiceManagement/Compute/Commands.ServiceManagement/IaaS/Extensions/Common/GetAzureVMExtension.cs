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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineExtension,
        DefaultParameterSetName = ListByReferenceParamSetName),
    OutputType(
        typeof(VirtualMachineExtensionContext))]
    public class GetAzureVMExtensionCommand : VirtualMachineExtensionCmdletBase
    {
        protected const string ListByExtensionParamSetName = "ListByExtensionName";
        protected const string ListByReferenceParamSetName = "ListByReferenceName";

        [Parameter(
            ParameterSetName = ListByExtensionParamSetName,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Name.")]
        [ValidateNotNullOrEmpty]
        public override string ExtensionName { get; set; }

        [Parameter(
            ParameterSetName = ListByExtensionParamSetName,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher.")]
        [ValidateNotNullOrEmpty]
        public override string Publisher { get; set; }

        [Parameter(
            ParameterSetName = ListByExtensionParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

        [Parameter(
            ParameterSetName = ListByReferenceParamSetName,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Reference Name.")]
        [ValidateNotNullOrEmpty]
        public override string ReferenceName { get; set; }

        internal void ExecuteCommand()
        {
            var extensionRefs =
                string.IsNullOrEmpty(ReferenceName) && string.IsNullOrEmpty(ExtensionName) ?
                ResourceExtensionReferences : GetPredicateExtensionList();

            var extensions = extensionRefs == null ? null : extensionRefs.Select(
                r => new VirtualMachineExtensionContext
                {
                    ExtensionName = r.Name,
                    ReferenceName = r.ReferenceName,
                    Publisher = r.Publisher,
                    Version = r.Version,
                    State = r.State,
                    PublicConfiguration = IsLegacyExtension(r.Name, r.Publisher, r.Version)
                                        ? GetConfiguration(r) : GetConfiguration(r, PublicTypeStr),
                    PrivateConfiguration = SecureStringHelper.GetSecureString(GetConfiguration(r, PrivateTypeStr)),
                    RoleName = VM.GetInstance().RoleName
                });

            WriteObject(extensions, true);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}
