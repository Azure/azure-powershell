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
using System.Text;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRestorableDroppedSqlPool : PSSynapseProxyResource
    {
        public PSRestorableDroppedSqlPool(RestorableDroppedSqlPool restorableDroppedSqlPool)
            : base(restorableDroppedSqlPool?.Id, restorableDroppedSqlPool?.Name, restorableDroppedSqlPool?.Type)
        {
            this.Location = restorableDroppedSqlPool.Location;
            this.SqlpoolName = restorableDroppedSqlPool.DatabaseName;
            this.Edition = restorableDroppedSqlPool.Edition;
            this.MaxSizeBytes = restorableDroppedSqlPool.MaxSizeBytes;
            this.ServiceLevelObjective = restorableDroppedSqlPool.ServiceLevelObjective;
            this.ElasticPoolName = restorableDroppedSqlPool.ElasticPoolName;
            this.CreationDate = restorableDroppedSqlPool.CreationDate;
            this.DeletionDate = restorableDroppedSqlPool.DeletionDate;
            this.EarliestRestoreDate = restorableDroppedSqlPool.EarliestRestoreDate;
        }

        //
        // Summary:
        //     Gets the geo-location where the resource lives
        public string Location { get; }

        //
        // Summary:
        //     Gets the name of the database
        public string SqlpoolName { get; }

        //
        // Summary:
        //     Gets the edition of the database
        public string Edition { get; }

        //
        // Summary:
        //     Gets the max size in bytes of the database
        public string MaxSizeBytes { get; }

        //
        // Summary:
        //     Gets the service level objective name of the database
        public string ServiceLevelObjective { get; }

        //
        // Summary:
        //     Gets the elastic pool name of the database
        public string ElasticPoolName { get; }

        //
        // Summary:
        //     Gets the creation date of the database (ISO8601 format)
        public DateTime? CreationDate { get; }

        //
        // Summary:
        //     Gets the deletion date of the database (ISO8601 format)
        public DateTime? DeletionDate { get; }

        //
        // Summary:
        //     Gets the earliest restore date of the database (ISO8601 format)
        public DateTime? EarliestRestoreDate { get; }
    }
}