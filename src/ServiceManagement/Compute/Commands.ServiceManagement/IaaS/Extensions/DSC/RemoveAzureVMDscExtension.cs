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

using System.Globalization;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// This cmdlet is used to remove DSC extension handler from a given virtual machine(s)
    /// in a cloud service. 
    /// 
    /// Note: To get detailed output -Verbose flag need to be specified. Output of this cmdlet needs to be piped to Update-AzureVM cmdlet 
    /// 
    /// Example Usage:
    /// 
    /// $vm = Get-AzureVM -ServiceName service -Name VM-name
    /// Remove-AzureVMDscExtension -VM $vm | Update-AzureVM -Verbose
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, VirtualMachineDscExtensionCmdletNoun),
    OutputType(typeof(IPersistentVM))]
    public class RemoveAzureVMDscExtensionCommand : VirtualMachineDscExtensionCmdletBase
    {

        internal void ExecuteCommand()
        {
            //this parameter needs to be true for remove to work
            this.Uninstall = true;
            this.Version = DefaultExtensionVersion;

            RemovePredicateExtensions();
            AddResourceExtension();

            WriteObject(VM);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}

