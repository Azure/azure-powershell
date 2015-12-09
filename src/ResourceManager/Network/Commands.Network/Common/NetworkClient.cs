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

using System;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication;
namespace Microsoft.Azure.Commands.Network
{
    public partial class NetworkClient
    {
        public INetworkManagementClient NetworkManagementClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public NetworkClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateArmClient<NetworkManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public NetworkClient(INetworkManagementClient NetworkManagementClient)
        {
            this.NetworkManagementClient = NetworkManagementClient;
        }

        public NetworkClient()
        {
        }
    }
}