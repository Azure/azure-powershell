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
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSqlPoolV3 : PSSynapseTrackedResource
    {
        public PSSynapseSqlPoolV3(SqlPoolV3 sqlPool)
            : base(sqlPool?.Location, sqlPool?.Id, sqlPool?.Name, sqlPool?.Type, sqlPool?.Tags)
        {
            this.Sku = sqlPool?.Sku != null ? new PSSynapseSku(sqlPool.Sku) : null;
            this.Kind = sqlPool?.Kind;
            this.CurrentServiceObjectiveName = sqlPool?.CurrentServiceObjectiveName;
            this.RequestedServiceObjectiveName = sqlPool?.RequestedServiceObjectiveName;
            this.SqlPoolGuid = sqlPool?.SqlPoolGuid;
            this.SystemData = sqlPool?.SystemData != null ? new PSSystemData(sqlPool.SystemData) : null;
            this.Status = sqlPool?.Status;
            this.MaxServiceObjectiveName = sqlPool?.MaxServiceObjectiveName;
            this.AutoPauseTimer = sqlPool?.AutoPauseTimer;
            this.AutoResume = sqlPool?.AutoResume;
        }

        /// <summary>
        /// Gets SQL pool SKU
        /// </summary>
        public PSSynapseSku Sku { get; private set; }

        /// <summary>
        /// Gets Kind of Sql Pool
        /// </summary>
        public string Kind { get; private set; }

        /// <summary>
        /// Gets current service objective name
        /// </summary>
        public string CurrentServiceObjectiveName { get; private set; }

        /// <summary>
        /// Gets requested service objective name
        /// </summary>
        public string RequestedServiceObjectiveName { get; private set; }

        /// <summary>
        /// Gets Sql Pool Guid
        /// </summary>
        public Guid? SqlPoolGuid { get; private set; }

        /// <summary>
        /// Gets System Data
        /// </summary>
        public PSSystemData SystemData { get; private set; }

        /// <summary>
        /// Gets resource status
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Gets or sets the max service level objective name of the sql pool.
        /// </summary>
        public string MaxServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the period of inactivity in minutes before
        /// automatically pausing the sql pool.
        /// </summary>
        public int? AutoPauseTimer { get; set; }

        /// <summary>
        /// Gets or sets indicates whether the sql pool can automatically
        /// resume when connection attempts are made.
        /// </summary>
        public bool? AutoResume { get; set; }
    }
}