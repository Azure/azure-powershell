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
using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public sealed class PSSignalRResource : PSTrackedResource
    {
        public string ExternalIp { get; }

        public string HostName { get; }

        public string HostNamePrefix { get; }

        public string ProvisioningState { get; }

        public int? PublicPort { get; }

        public int? ServerPort { get; }

        public PSResourceSku Sku { get; }

        public IList<PSSignalRFeature> Features { get; }

        public PSSignalRCorsSettings Cors { get; }

        public string Version { get; }

        public PSSignalRResource(SignalRResource signalRResource)
            : base(signalRResource)
        {
            ExternalIp = signalRResource.ExternalIP;
            HostName = signalRResource.HostName;
            HostNamePrefix = signalRResource.HostNamePrefix;
            ProvisioningState = signalRResource.ProvisioningState;
            PublicPort = signalRResource.PublicPort;
            ServerPort = signalRResource.ServerPort;
            Sku = new PSResourceSku(signalRResource.Sku);
            Features = new List<PSSignalRFeature>();
            foreach (var feature in signalRResource.Features)
            {
                Features.Add(new PSSignalRFeature(feature));
            }
            Cors = new PSSignalRCorsSettings(signalRResource.Cors);
            Version = signalRResource.Version;
        }
    }
}
