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
    /// <summary>
    /// Remove-AzureVMSqlServerExtension cmdlet implementation
    /// this cmdlet removes SQL Server extension info VM object
    /// Explicit call to Update-AzureVM is required to commit changes to Azure
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        VirtualMachineSqlServerExtensionNoun,
        DefaultParameterSetName = RemoveSqlServerExtensionParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class RemoveAzureVMSqlServerExtensionCommand : VirtualMachineSqlServerExtensionCmdletBase
    {
        protected const string RemoveSqlServerExtensionParamSetName = "RemoveSqlServerExtension";

        internal void ExecuteCommand()
        {
            RemovePredicateExtensions();
            WriteObject(VM);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}
