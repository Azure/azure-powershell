﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class ReplicationExtensions
    {       
        public static PSNetAppFilesReplication ConvertToPs(this Management.NetApp.Models.Replication replication)
        {
            var psReplicaitonObject = new PSNetAppFilesReplication
            {
                EndpointType = replication.EndpointType,
                RemoteVolumeRegion = replication.RemoteVolumeRegion,
                RemoteVolumeResourceId = replication.RemoteVolumeResourceId,                
            };
            return psReplicaitonObject;
        }

        public static List<PSNetAppFilesReplication> ConvertToPS(this IList<Management.NetApp.Models.Replication> replications)
        {
            return replications.Select(e => e.ConvertToPs()).ToList();
        }
    }
}
