﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    [Cmdlet(
        VerbsCommon.Get,
        VirtualMachinePuppetExtensionNoun,
        DefaultParameterSetName = GetPuppetExtensionParamSetName),
    OutputType(
        typeof(IEnumerable<VirtualMachinePuppetExtensionContext>))]
    public class GetAzureVMPuppetExtensionCommand : VirtualMachinePuppetExtensionCmdletBase
    {
        protected const string GetPuppetExtensionParamSetName = "GetPuppetExtension";

        internal void ExecuteCommand()
        {
            var extensionRefs = GetPredicateExtensionList();
            WriteObject(
                extensionRefs == null ? null : extensionRefs.Select(
                r => new VirtualMachinePuppetExtensionContext
                {
                    ExtensionName = r.Name,
                    Publisher = r.Publisher,
                    ReferenceName = r.ReferenceName,
                    Version = r.Version,
                    State = r.State
                }).FirstOrDefault());
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}