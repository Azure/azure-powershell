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

    public class PSStatefulServiceProperties : PSServiceResourceProperties
    {
        public bool? HasPersistedState { get; private set; }
        public int? TargetReplicaSetSize { get; private set; }
        public int? MinReplicaSetSize { get; private set; }
        public string ReplicaRestartWaitDuration { get; private set; }
        public string QuorumLossWaitDuration { get; private set; }
        public string StandByReplicaKeepDuration { get; private set; }
        public string ServicePlacementTimeLimit { get; private set; }

        public PSStatefulServiceProperties(StatefulServiceProperties statefulServiceProperties)
            : base(statefulServiceProperties)
        {
            HasPersistedState = statefulServiceProperties.HasPersistedState;
            TargetReplicaSetSize = statefulServiceProperties.TargetReplicaSetSize;
            MinReplicaSetSize = statefulServiceProperties.MinReplicaSetSize;
            ReplicaRestartWaitDuration = statefulServiceProperties.ReplicaRestartWaitDuration;
            QuorumLossWaitDuration = statefulServiceProperties.QuorumLossWaitDuration;
            StandByReplicaKeepDuration = statefulServiceProperties.StandByReplicaKeepDuration;
            ServicePlacementTimeLimit = statefulServiceProperties.ServicePlacementTimeLimit;
        }
    }
}
