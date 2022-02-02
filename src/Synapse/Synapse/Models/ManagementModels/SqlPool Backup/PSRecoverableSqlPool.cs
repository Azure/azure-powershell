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
    public class PSRecoverableSqlPool : PSSynapseProxyResource
    {
        public PSRecoverableSqlPool(RecoverableSqlPool recoverableSqlPool)
            : base(recoverableSqlPool?.Id, recoverableSqlPool?.Name, recoverableSqlPool?.Type)
        {
            this.Edition = recoverableSqlPool.Edition;
            this.ServiceLevelObjective = recoverableSqlPool.ServiceLevelObjective;
            this.ElasticPoolName = recoverableSqlPool.ElasticPoolName;
            this.LastAvailableBackupDate = recoverableSqlPool.LastAvailableBackupDate;
        }

        public string Edition { get; set; }

        //
        // Summary:
        //     Gets the service level objective name of the database
        public string ServiceLevelObjective { get; set; }

        //
        // Summary:
        //     Gets the elastic pool name of the database
        public string ElasticPoolName { get; set; }

        //
        // Summary:
        //     Gets the last available backup date of the database (ISO8601 format)
        public DateTime? LastAvailableBackupDate { get; set; }
    }
}

