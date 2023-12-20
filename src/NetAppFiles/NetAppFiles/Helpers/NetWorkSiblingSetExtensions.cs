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
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class NetWorkSiblingSetExtensions
    {
        public static PSNetAppNetworkSiblingSet ConvertToPs(this Management.NetApp.Models.NetworkSiblingSet networkSiblingSet)
        {
            var psNetworkSiblingSet = new PSNetAppNetworkSiblingSet()
            {
                NetworkFeatures = networkSiblingSet.NetworkFeatures,
                NetworkSiblingSetId = networkSiblingSet.NetworkSiblingSetId,
                NetworkSiblingSetStateId = networkSiblingSet.NetworkSiblingSetStateId,
                NicInfoList = (networkSiblingSet.NicInfoList != null) ? networkSiblingSet.NicInfoList.ConvertToPs() : null,
                ProvisioningState = networkSiblingSet.ProvisioningState,
                SubnetId = networkSiblingSet.SubnetId
            };
            return psNetworkSiblingSet;
        }

        public static PSNetAppNicInfo ConvertToPs(this Management.NetApp.Models.NicInfo nicInfo)
        {
            var psNetAppNicInfo = new PSNetAppNicInfo()
            {
                IPAddress = nicInfo.IPAddress,
                VolumeResourceIds = nicInfo.VolumeResourceIds ?? null
            };
            return psNetAppNicInfo;
        }

        public static List<PSNetAppNicInfo> ConvertToPs(this IList<Management.NetApp.Models.NicInfo> NicInfoList)
        {
            return NicInfoList.Select(e => e.ConvertToPs()).ToList();
        }
    }
}
