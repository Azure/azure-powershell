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

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSAvailabilitySet
    {
        public string ResourceGroupName { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Etag { get; set; }

        public string Id { get; set; }

        public int? PlatformUpdateDomainCount { get; set; }

        public int? PlatformFaultDomainCount { get; set; }

        public IList<InstanceViewStatus> Statuses { get; set; }

        public IList<VirtualMachineReference> VirtualMachines { get; set; }
    }

    public static class PSAvailabilitySetConversions
    {
        public static PSAvailabilitySet ToPSAvailabilitySet(this AvailabilitySetGetResponse response, string rgName = null)
        {
            if (response == null)
            {
                return null;
            }

            return response.AvailabilitySet.ToPSAvailabilitySet(rgName);
        }

        public static PSAvailabilitySet ToPSAvailabilitySet(this AvailabilitySet avSet, string rgName = null)
        {
            PSAvailabilitySet result = new PSAvailabilitySet
            {
                ResourceGroupName = rgName,
                Name = avSet == null ? null : avSet.Name,
                Etag = null, // TODO: Update CRP library for this field
                Id = avSet.Id,
                Location = avSet.Location,
                Statuses = avSet.Properties.Statuses,
                PlatformFaultDomainCount = avSet.Properties == null ? null : avSet.Properties.PlatformFaultDomainCount,
                PlatformUpdateDomainCount = avSet.Properties == null ? null : avSet.Properties.PlatformUpdateDomainCount,
                VirtualMachines = avSet.Properties == null ? null : avSet.Properties.VirtualMachinesReferences
            };

            return result;
        }

        public static List<PSAvailabilitySet> ToPSAvailabilitySetList(this AvailabilitySetListResponse response, string rgName = null)
        {
            List<PSAvailabilitySet> results = new List<PSAvailabilitySet>();

            if (response != null && response.AvailabilitySets != null)
            {
                foreach (var item in response.AvailabilitySets)
                {
                    var vm = item.ToPSAvailabilitySet(rgName);
                    results.Add(vm);
                }
            }

            return results;
        }
    }
}
