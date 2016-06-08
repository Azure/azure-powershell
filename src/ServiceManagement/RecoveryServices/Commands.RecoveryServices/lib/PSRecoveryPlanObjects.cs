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
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Azure Site Recovery Recovery Plan.
    /// </summary>
    public class ASRRecoveryPlan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRRecoveryPlan" /> class.
        /// </summary>
        public ASRRecoveryPlan()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRRecoveryPlan" /> class with required
        /// parameters.
        /// </summary>
        /// <param name="recoveryPlan">Recovery plan object</param>
        public ASRRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            this.ID = recoveryPlan.ID;
            this.Name = recoveryPlan.Name;
            this.ServerId = recoveryPlan.ServerId;
            this.TargetServerId = recoveryPlan.TargetServerId;
            this.ReplicationProvider = recoveryPlan.ReplicationProvider;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Recovery plan ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets name of the Recovery Plan.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets to Server ID.
        /// </summary>
        public string ServerId { get; set; }

        /// <summary>
        /// Gets or sets target Server ID.
        /// </summary>
        public string TargetServerId { get; set; }

        /// <summary>
        /// Gets or sets Replication provider.
        /// </summary>
        public string ReplicationProvider { get; set; }

        #endregion
    }
}