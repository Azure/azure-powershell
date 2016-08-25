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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    public class VirtualMachineChefExtensionCmdletBase : VirtualMachineExtensionCmdletBase
    {
        protected const string VirtualMachineChefExtensionNoun = "AzureVMChefExtension";

        protected const string ExtensionDefaultPublisher = "Chef.Bootstrap.WindowsAzure";
        protected const string ExtensionDefaultName = "ChefClient";
        protected const string LinuxExtensionName = "LinuxChefClient";
        protected const string PrivateConfigurationTemplate = "{{\"validation_key\":\"{0}\"}}";
        protected const string ClientRbTemplate = "\"client_rb\":\"{0}\"";
        protected const string BootstrapVersionTemplate = "\"bootstrap_version\":\"{0}\"";
        protected const string BootStrapOptionsTemplate = "\"bootstrap_options\":{0}";
        protected const string RunListTemplate = "\"runlist\": \"\\\"{0}\\\"\"";

        public VirtualMachineChefExtensionCmdletBase()
        {
            base.publisherName = ExtensionDefaultPublisher;
        }

        // Currently we have platform-wise extension names,
        // So it uses VM object's platform details to find out platform specific extension name.
        // This helper method is used for Get/Remove AzureVMChefExtension.
        protected string GetPlatformSpecificExtensionName()
        {
            var vm = VM.GetInstance();
            if (vm.OSVirtualHardDisk != null)
            {
                return vm.OSVirtualHardDisk.OS.Equals("Windows",
                System.StringComparison.OrdinalIgnoreCase) ? ExtensionDefaultName : LinuxExtensionName;
            }
            else { return null; }
        }
    }
}
