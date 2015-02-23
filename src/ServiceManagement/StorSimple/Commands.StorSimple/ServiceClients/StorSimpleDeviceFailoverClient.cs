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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public DataContainerGroupsGetResponse GetFaileoverDataContainerGroups(string deviceId)
        {
            return GetStorSimpleClient().DeviceFailover.ListDCGroups(deviceId, this.GetCustomRequestHeaders());
        }

        public JobResponse TriggerFailover(string deviceId, DeviceFailoverRequest drRequest)
        {
            return GetStorSimpleClient().DeviceFailover.Trigger(deviceId, drRequest, GetCustomRequestHeaders());

        }



        internal List<string> GetVcIdListFromVcGroups(List<DataContainerGroup> vcGroups)
        {
            var vcIdList = new List<string>();
            foreach (var vcGroup in vcGroups)
            {
                if (!vcGroup.IsDCGroupEligibleForDR)
                {
                    var nameList = from vc in vcGroup.DCGroup
                                   select vc.Name;

                    string msg = string.Format(Resources.VolumeContainerGroupNotEligibleForFailoverError,
                        string.Join(",", nameList), vcGroup.IneligibilityMessage);
                    
                    throw new ArgumentException(msg);
                }

                var idList = from vc in vcGroup.DCGroup
                             select vc.DataContainerId;

                vcIdList.AddRange(idList);
            }

            return vcIdList;
        }
    }
}
