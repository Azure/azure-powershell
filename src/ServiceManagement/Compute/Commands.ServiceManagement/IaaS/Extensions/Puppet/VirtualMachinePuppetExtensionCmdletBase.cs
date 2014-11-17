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
    public class VirtualMachinePuppetExtensionCmdletBase : VirtualMachineExtensionCmdletBase
    {
        protected const string VirtualMachinePuppetExtensionNoun = "AzureVMPuppetExtension";

        protected const string ExtensionDefaultPublisher = "PuppetLabs";
        protected const string ExtensionDefaultName = "PuppetEnterpriseAgent";
        protected const string ExtensionDefaultVersion = "3.*";
        protected const string LegacyReferenceName = "PuppetAgent";
        protected const string PrivateConfigurationTemplate = "{{ \"PUPPET_MASTER_SERVER\": \"{0}\" }}";

        public VirtualMachinePuppetExtensionCmdletBase()
        {
            base.publisherName = ExtensionDefaultPublisher;
            base.extensionName = ExtensionDefaultName;
        }
    }
}