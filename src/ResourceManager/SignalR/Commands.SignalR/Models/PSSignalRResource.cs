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

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public sealed class PSSignalRResource : PSTrackedResource
    {
        public string ExternalIp { get; }

        public string HostName { get; }

        public string HostNamePrefix { get; }

        public string ProvisioningState { get; }

        public string PublicPort { get; }

        public string ServerPort { get; }

        public string Sku { get; }

        public PSSignalRResource(
            string id,
            string name,
            string type,
            string location,
            IDictionary<string, string> tags,
            string externalIp,
            string hostName,
            string hostNamePrefix,
            string provisioningState,
            string publicPort,
            string serverPort,
            string sku)
            : base(id: id, name: name, type: type, location: location, tags: tags)
        {
            ExternalIp = externalIp;
            HostName = HostName;
            HostNamePrefix = hostNamePrefix;
            ProvisioningState = provisioningState;
            PublicPort = publicPort;
            ServerPort = serverPort;
            Sku = Sku;
        }
    }
}
