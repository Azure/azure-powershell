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
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSLocationProperties
    {
        public PSLocationProperties()
        {
        }

        public PSLocationProperties(LocationProperties locationProperties)
        {
            if (locationProperties == null)
            {
                return;
            }

            SupportsAvailabilityZone = locationProperties.SupportsAvailabilityZone;
            IsResidencyRestricted = locationProperties.IsResidencyRestricted;
            BackupStorageRedundancies = locationProperties.BackupStorageRedundancies;
        }

        /// <summary>
        ///  Gets flag indicating whether the location supports availability zones or not.
        /// </summary>
        public bool? SupportsAvailabilityZone { get; set; }

        /// <summary>
        ///  Gets flag indicating whether the location is residency sensitive.
        /// </summary>
        public bool? IsResidencyRestricted { get; set; }

        /// <summary>
        ///  Gets the properties of available backup storage redundancies.
        /// </summary>
        public IList<string> BackupStorageRedundancies { get; set; }
    }
}
