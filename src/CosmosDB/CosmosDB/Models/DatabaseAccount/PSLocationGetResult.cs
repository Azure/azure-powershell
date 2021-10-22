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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using Microsoft.Azure.Management.CosmosDB.Models;
    using System.Collections.Generic;

    public class PSLocationGetResult
    {
        public PSLocationGetResult()
        {
        }

        public PSLocationGetResult(LocationGetResult locationGetResult)
        {
            if (locationGetResult == null || locationGetResult.Properties == null)
            {
                return;
            }

            SupportsAvailabilityZone = locationGetResult.Properties.SupportsAvailabilityZone;
            IsResidencyRestricted = locationGetResult.Properties.IsResidencyRestricted;
            BackupStorageRedundancies = locationGetResult.Properties.BackupStorageRedundancies;
        }

        //
        // Summary:
        //     Gets flag indicating whether the location supports availability zones or not.
        public bool? SupportsAvailabilityZone { get; set; }

        //
        // Summary:
        //     Gets flag indicating whether the location is residency sensitive.
        public bool? IsResidencyRestricted { get; set; }

        /// <summary>
        ///  Gets the properties of available backup storage redundancies.
        /// </summary>
        public IList<string> BackupStorageRedundancies { get; set; }
    }
}
