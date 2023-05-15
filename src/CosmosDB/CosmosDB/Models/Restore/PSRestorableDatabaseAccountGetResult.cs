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

using System.Linq;

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableDatabaseAccountGetResult
    {
        public PSRestorableDatabaseAccountGetResult()
        {
        }

        public PSRestorableDatabaseAccountGetResult(RestorableDatabaseAccountGetResult restorableDatabaseAccountGetResult)
        {
            if (restorableDatabaseAccountGetResult == null)
            {
                return;
            }

            Id = restorableDatabaseAccountGetResult.Id;
            DatabaseAccountInstanceId = restorableDatabaseAccountGetResult.Name;
            Location = restorableDatabaseAccountGetResult.Location;
            DatabaseAccountName = restorableDatabaseAccountGetResult.AccountName;
            CreationTime = restorableDatabaseAccountGetResult.CreationTime;
            DeletionTime = restorableDatabaseAccountGetResult.DeletionTime;
            OldestRestorableTime = restorableDatabaseAccountGetResult.OldestRestorableTime;
            ApiType = restorableDatabaseAccountGetResult.ApiType;
            RestorableLocations = restorableDatabaseAccountGetResult.RestorableLocations?.Select(restorableLocation => new PSRestorableLocationResource(restorableLocation)).ToArray();
        }

        //
        // Summary:
        //     Gets or sets the Id of the CosmosDB Restorable database Account
        public string Id { get; set; }
        //
        //
        // Summary:
        //     Gets or sets the Instance Id of the CosmosDB Account
        public string DatabaseAccountInstanceId { get; set; }

        /// <summary>
        /// Gets or sets Location of the Cosmos DB CosmosDB Account
        /// </summary>
        public string Location { get; set; }

        //
        // Summary:
        //      Gets or sets the name of the global database account 
        public string DatabaseAccountName { get; set; }

        //
        // Summary:
        //      Gets or sets the creation time of the CosmosDB restorable database account
        //      (ISO-8601 format).
        public System.DateTime? CreationTime { get; set; }

        //
        // Summary:
        //      Gets or sets the time at which the CosmosDB Restorable database account has
        //      been deleted (ISO-8601 format).
        public System.DateTime? DeletionTime { get; set; }

        //
        // Summary:
        //      Gets or sets the oldest time at which the CosmosDB Restorable database account
        //      can be restored to (ISO-8601 format).
        public System.DateTime? OldestRestorableTime { get; set; }

        //
        // Summary:
        //      Gets or sets the Api Type of the global database account 
        public string ApiType { get; set; }

        //
        // Summary:
        //     Gets or sets list of regions where the of the database account can be restored from.
        public PSRestorableLocationResource[] RestorableLocations { get; set; }
    }
}
