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

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
    using System.Collections.Generic;

    public class PSManagedStatefulService : PSManagedService
    {
        public bool? HasPersistedState { get; set; }
        public int? TargetReplicaSetSize { get; set; }
        public int? MinReplicaSetSize { get; set; }
        public string ReplicaRestartWaitDuration { get; set; }
        public string QuorumLossWaitDuration { get; set; }
        public string StandByReplicaKeepDuration { get; set; }
        public string ServicePlacementTimeLimit { get; set; }

        public PSManagedStatefulService(ServiceResource service) : base(service)
        {
            var properties = service.Properties as StatefulServiceProperties;

            HasPersistedState = properties.HasPersistedState;
            TargetReplicaSetSize = properties.TargetReplicaSetSize;
            MinReplicaSetSize = properties.MinReplicaSetSize;
            ReplicaRestartWaitDuration = properties.ReplicaRestartWaitDuration;
            QuorumLossWaitDuration = properties.QuorumLossWaitDuration;
            StandByReplicaKeepDuration = properties.StandByReplicaKeepDuration;
            ServicePlacementTimeLimit = properties.ServicePlacementTimeLimit;
        }
    }
}
