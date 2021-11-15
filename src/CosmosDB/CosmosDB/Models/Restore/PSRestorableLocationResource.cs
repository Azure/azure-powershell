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

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableLocationResource
    {
        public PSRestorableLocationResource()
        {
        }

        public PSRestorableLocationResource(RestorableLocationResource restorableLocationResource)
        {
            if (restorableLocationResource == null)
            {
                return;
            }

            LocationName = restorableLocationResource.LocationName;
            RegionalDatabaseAccountInstanceId = restorableLocationResource.RegionalDatabaseAccountInstanceId;
            CreationTime = restorableLocationResource.CreationTime;
            DeletionTime = restorableLocationResource.DeletionTime;
        }

        //
        // Summary:
        //     Gets or sets the location of the regional restorable account.
        public string LocationName { get; set; }

        //
        // Summary:
        //     Gets or sets the instance id of the regional restorable account.
        public string RegionalDatabaseAccountInstanceId { get; set; }

        //
        // Summary:
        //     Gets or sets the creation time of the regional restorable database account (ISO-8601
        //     format).
        public System.DateTime? CreationTime { get; set; }

        //
        // Summary:
        //     Gets or sets the time at which the regional restorable database account has been deleted
        //     (ISO-8601 format).
        public System.DateTime? DeletionTime { get; set; }
    }
}
