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
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.WindowsAzure.Management.Network;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Remove, "AzureVNetConfig"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureVNetConfigCommand : ServiceManagementBaseCmdlet
    {
        private static readonly XNamespace NetconfigNamespace = "http://schemas.microsoft.com/ServiceHosting/2011/07/NetworkConfiguration";
        private static readonly XNamespace InstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            var netConfig = new XElement(
                NetconfigNamespace + "NetworkConfiguration",
                new XAttribute("xmlns", NetconfigNamespace.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "xsi", InstanceNamespace.NamespaceName),
                new XElement(NetconfigNamespace + "VirtualNetworkConfiguration"));

            NetworkSetConfigurationParameters networkConfigParams = new NetworkSetConfigurationParameters
            {
                Configuration = netConfig.ToString()
            };

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.NetworkClient.Networks.SetConfiguration(networkConfigParams));
        }
    }
}
