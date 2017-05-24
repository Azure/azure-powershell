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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Management.IotHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Management.IotHub
{
    public class IotHubBaseCmdlet : AzureRMCmdlet
    {
        protected const string ArmApiVersion = "2016-02-03";

        private IIotHubClient iothubClient;

        protected IIotHubClient IotHubClient
        {
            get
            {
                if (this.iothubClient == null)
                {
                    this.iothubClient = AzureSession.Instance.ClientFactory.CreateArmClient<IotHubClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }

                return this.iothubClient;
            }
        }

        public string SubscriptionId
        {
            get { return DefaultProfile.DefaultContext.Subscription.Id.ToString(); }
        }
    }
}
