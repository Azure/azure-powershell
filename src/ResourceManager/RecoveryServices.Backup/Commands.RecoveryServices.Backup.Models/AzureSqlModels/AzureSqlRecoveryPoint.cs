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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure Sql specific recovery point class.
    /// </summary>
    public class AzureSqlRecoveryPoint : RecoveryPointBase
    {
        /// <summary>
        /// Type of recovery point (appConsistent\CrashConsistent etc) 
        /// </summary>
        public String RecoveryPointType { get; set; }

        /// <summary>
        /// Time when this recovery point was created
        /// </summary>
        public DateTime RecoveryPointTime { get; set; }

        /// <summary>
        /// Additional info associated with this recovery point serialized into a string.
        /// </summary>
        public string RecoveryPointAdditionalInfo { get; set; }

        /// <summary>
        /// FriendlyName of recovery point
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// ARM ID of the Azure SQL server represented by the recovery point
        /// </summary>
        public string SourceResourceId { get; set; }
    }
}
