// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSRollingUpgradePolicy
    {
        internal RollingUpgradePolicy toMgmtRollingUpgradePolicy()
        {
            if (this.omObject == null)
            {
                return null;
            }

            RollingUpgradePolicy rollingUpgradePolicy = new RollingUpgradePolicy();

            rollingUpgradePolicy.EnableCrossZoneUpgrade = this.EnableCrossZoneUpgrade;
            rollingUpgradePolicy.MaxBatchInstancePercent = this.MaxBatchInstancePercent;
            rollingUpgradePolicy.MaxUnhealthyInstancePercent = this.MaxUnhealthyInstancePercent;
            rollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent = this.MaxUnhealthyUpgradedInstancePercent;
            // Convert TimeSpan to ISO 8601 duration format, handle null values
            rollingUpgradePolicy.PauseTimeBetweenBatches = this.PauseTimeBetweenBatches.HasValue
                ? XmlConvert.ToString(this.PauseTimeBetweenBatches.Value)
                : null;

            rollingUpgradePolicy.PrioritizeUnhealthyInstances = this.PrioritizeUnhealthyInstances;
            rollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach = this.RollbackFailedInstancesOnPolicyBreach;
            return rollingUpgradePolicy;
        }

        internal PSRollingUpgradePolicy fromMgmtRollingUpgradePolicy(RollingUpgradePolicy rollingUpgradePolicy)
        {
            if (rollingUpgradePolicy == null)
            {
                return null;
            }

            PSRollingUpgradePolicy psRollingUpgradePolicy = new PSRollingUpgradePolicy();

            psRollingUpgradePolicy.EnableCrossZoneUpgrade = rollingUpgradePolicy.EnableCrossZoneUpgrade;
            psRollingUpgradePolicy.MaxBatchInstancePercent = rollingUpgradePolicy.MaxBatchInstancePercent;
            psRollingUpgradePolicy.MaxUnhealthyInstancePercent = rollingUpgradePolicy.MaxUnhealthyInstancePercent;
            psRollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent = rollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent;


            // Convert ISO 8601 duration to TimeSpan, handle null/empty values
            if (!string.IsNullOrEmpty(rollingUpgradePolicy.PauseTimeBetweenBatches))
            {
                psRollingUpgradePolicy.PauseTimeBetweenBatches = XmlConvert.ToTimeSpan(rollingUpgradePolicy.PauseTimeBetweenBatches);
            }
            psRollingUpgradePolicy.PrioritizeUnhealthyInstances = rollingUpgradePolicy.PrioritizeUnhealthyInstances;
            psRollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach = rollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach;
            return psRollingUpgradePolicy;
        }
    }
}
