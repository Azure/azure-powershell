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
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineCustomScriptExtension,
        DefaultParameterSetName = GetCustomScriptExtensionParamSetName),
    OutputType(
        typeof(VirtualMachineCustomScriptExtensionContext))]
    public class GetAzureVMCustomScriptExtensionCommand : VirtualMachineCustomScriptExtensionCmdletBase
    {
        protected const string GetCustomScriptExtensionParamSetName = "GetCustomScriptExtension";

        internal void ExecuteCommand()
        {
            var extensionRefs = GetPredicateExtensionList();
            WriteObject(
                extensionRefs == null ? null : extensionRefs.Select(
                r =>
                {
                    GetExtensionValues(r);
                    var pubSettings = string.IsNullOrEmpty(PublicConfiguration) ? null
                                    : JsonConvert.DeserializeObject<PublicSettings>(PublicConfiguration);

                    return new VirtualMachineCustomScriptExtensionContext
                    {
                        ExtensionName        = r.Name,
                        Publisher            = r.Publisher,
                        ReferenceName        = r.ReferenceName,
                        Version              = r.Version,
                        State                = r.State,
                        PublicConfiguration  = PublicConfiguration,
                        PrivateConfiguration = SecureStringHelper.GetSecureString(PrivateConfiguration),
                        CommandToExecute     = pubSettings == null ? string.Empty : pubSettings.commandToExecute,
                        Uri                  = pubSettings == null ? null : pubSettings.fileUris,
                        RoleName             = VM.GetInstance().RoleName
                    };
                }), true);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}
