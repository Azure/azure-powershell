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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.HDInsight.Models.Management;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightPrivateEndpointConnection
    {
        public AzureHDInsightPrivateEndpointConnection(PrivateEndpointConnection privateEndpointConnection)
        {
            Id = privateEndpointConnection.Id;
            Name = privateEndpointConnection.Name;
            Type = privateEndpointConnection.Type;
            LinkIdentifier = privateEndpointConnection.LinkIdentifier;
            PrivateEndpoint = new AzureHDInsightPrivateEndpoint(privateEndpointConnection.PrivateEndpoint);
            PrivateLinkServiceConnectionState = new AzureHDInsightPrivateLinkServiceConnectionState(privateEndpointConnection.PrivateLinkServiceConnectionState);
            ProvisioningState = privateEndpointConnection.ProvisioningState;
        }


        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public AzureHDInsightPrivateEndpoint PrivateEndpoint { get; }

        public AzureHDInsightPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

        public string LinkIdentifier { get; set; }

        public string ProvisioningState { get; set; }
    }
}
