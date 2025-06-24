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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class ReplicationExtensions
    {       
        public static PSNetAppFilesReplication ConvertToPs(this Management.NetApp.Models.Replication replication)
        {
            var psReplicaitonObject = new PSNetAppFilesReplication
            {
                ReplicationId = replication.ReplicationId,
                EndpointType = replication.EndpointType,
                RemoteVolumeRegion = replication.RemoteVolumeRegion,
                RemoteVolumeResourceId = replication.RemoteVolumeResourceId
            };
            return psReplicaitonObject;
        }

        
        public static List<PSNetAppFilesReplication> ConvertToPs(this IEnumerable<Management.NetApp.Models.Replication> replications)
        {
            return replications.Select(e => e.ConvertToPs()).ToList();
        }

        public static PSSvmPeerCommandResponse ConvertToPs(this Management.NetApp.Models.SvmPeerCommandResponse svmPeerCommandResponse)
        {
            var psSvmPeerCommandResponse = new PSSvmPeerCommandResponse
            {
                SvmPeeringCommand = svmPeerCommandResponse.SvmPeeringCommand
            };
            return psSvmPeerCommandResponse;
        }

        public static PSNetAppFilesDestinationReplication ConvertToPs(this Management.NetApp.Models.DestinationReplication destinationReplication)
        {
            PSNetAppFilesDestinationReplication pSNetAppFilesDestinationReplication = new PSNetAppFilesDestinationReplication
            {
                Region = destinationReplication.Region,
                ReplicationType = destinationReplication.ReplicationType,
                ResourceId = destinationReplication.ResourceId,
                Zone = destinationReplication.Zone
            };
            return pSNetAppFilesDestinationReplication;
        }

        public static List<PSNetAppFilesDestinationReplication> ConvertToPs(this IEnumerable<Management.NetApp.Models.DestinationReplication> destinationReplications)
        {
            return destinationReplications.Select(e => e.ConvertToPs()).ToList();
        }
    }
}
