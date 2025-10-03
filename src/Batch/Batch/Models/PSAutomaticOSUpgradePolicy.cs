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
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSAutomaticOSUpgradePolicy
    {
        internal AutomaticOSUpgradePolicy toMgmtAutomaticOSUpgradePolicy()
        {
           if (this.omObject != null)
           {
                AutomaticOSUpgradePolicy policy = new AutomaticOSUpgradePolicy();
                policy.EnableAutomaticOSUpgrade = this.EnableAutomaticOSUpgrade;
                policy.DisableAutomaticRollback = this.DisableAutomaticRollback;
                policy.OSRollingUpgradeDeferral = this.OsRollingUpgradeDeferral;
                policy.UseRollingUpgradePolicy = this.UseRollingUpgradePolicy;

                return policy;
            }
            else
            {
                return null;
            }
        }

        internal PSAutomaticOSUpgradePolicy ToPSAutomaticOSUpgradePolicy(Microsoft.Azure.Management.Batch.Models.AutomaticOSUpgradePolicy mgmtPolicy)
        {
            if (mgmtPolicy != null)
            {
                PSAutomaticOSUpgradePolicy policy = new PSAutomaticOSUpgradePolicy();

                policy.EnableAutomaticOSUpgrade = mgmtPolicy.EnableAutomaticOSUpgrade;
                policy.DisableAutomaticRollback = mgmtPolicy.DisableAutomaticRollback;
                policy.OsRollingUpgradeDeferral = mgmtPolicy.OSRollingUpgradeDeferral;
                policy.UseRollingUpgradePolicy = mgmtPolicy.UseRollingUpgradePolicy;
                return policy;
            }
            else
            {
                return null;
            }
        }
    }
}