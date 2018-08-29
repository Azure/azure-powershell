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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    public class ASRRecoveryPlanGroup
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanGroup class.
        public ASRRecoveryPlanGroup() {
        }
        
        //
        // Summary:
        //     Gets or sets the group type. Possible values include: 'Shutdown', 'Boot', 'Failover'
        public ASRRecoveryPlanGroupType GroupType { get; set; }
        //
        // Summary:
        //     Gets or sets the list of protected items.
        public IList<ASRRecoveryPlanProtectedItem> ReplicationProtectedItems { get; set; }
        //
        // Summary:
        //     Gets or sets the start group actions.
        public IList<ASRRecoveryPlanAction> StartGroupActions { get; set; }
        //
        // Summary:
        //     Gets or sets the end group actions.
        public IList<ASRRecoveryPlanAction> EndGroupActions { get; set; }
    }

    //
    // Summary:
    //     Defines values for RecoveryPlanGroupType.
    public enum ASRRecoveryPlanGroupType
    {
        Shutdown = 0,
        Boot = 1,
        Failover = 2
    }
}
