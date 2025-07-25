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

using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSqlDatabase : PSSynapseTrackedResource
    {
        public PSSynapseSqlDatabase(SqlDatabase sqlDatabase)
            : base(sqlDatabase?.Location, sqlDatabase?.Id, sqlDatabase?.Name, sqlDatabase?.Type, sqlDatabase?.Tags)
        {
            this.Collation = sqlDatabase?.Collation;
            this.SystemData = sqlDatabase?.SystemData != null ? new PSSystemData(sqlDatabase.SystemData) : null;
            this.StorageRedundancy = sqlDatabase?.StorageRedundancy;
        }

        /// <summary>
        /// Gets System Data
        /// </summary>
        public PSSystemData SystemData { get; set; }

        /// <summary>
        /// Gets maximum size in bytes
        /// </summary>
        public long? MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets collation mode
        /// </summary>
        public string Collation { get; set; }

        /// <summary>
        /// Storage redundancy of the database.
        /// </summary>
        public string StorageRedundancy { get; set; }
    }
}