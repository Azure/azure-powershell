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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.IotCentral;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.IotCentral.Common
{
    public abstract class IotCentralBaseCmdlet : AzureRMCmdlet
    {
        private IIotCentralClient iotCentralClient;

        private IResourceManagementClient resourceManagementClient;

        protected const string InteractiveIotCentralParameterSet = "InteractiveIotCentralParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        protected const string resourceType = "IoTApps";

        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "Name of the Resource Group.",
            ParameterSetName = InteractiveIotCentralParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = "Name of the Iot Central Application Resource.",
            ParameterSetName = InteractiveIotCentralParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected IIotCentralClient IotCentralClient
        {
            get
            {
                if (this.iotCentralClient == null)
                {
                    this.iotCentralClient = AzureSession.Instance.ClientFactory.CreateArmClient<IotCentralClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }
                return this.iotCentralClient;
            }
        }

        protected IResourceManagementClient ResourceManagementClient
        {
            get
            {
                if (this.resourceManagementClient == null)
                {
                    this.resourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }
                return this.resourceManagementClient;
            }
        }
    }
}
