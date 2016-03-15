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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public partial class PolicyHelpers
    {
        #region HydraToPSObject conversions

        #region public
        public static AzureRmRecoveryServicesLongTermRetentionPolicy GetPSLongTermRetentionPolicy(
            LongTermRetentionPolicy hydraRetPolicy)
        {
            AzureRmRecoveryServicesLongTermRetentionPolicy ltrPolicy = new AzureRmRecoveryServicesLongTermRetentionPolicy();

            // TBD

            return ltrPolicy;            
        }

        public static AzureRmRecoveryServicesLongTermRetentionPolicy GetPSSimpleRetentionPolicy(
           SimpleRetentionPolicy hydraRetPolicy)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region private

        // TBD

        #endregion

        #endregion

        #region PStoHydraObject conversions
        public static LongTermRetentionPolicy GetHydraLongTermRetentionPolicy(
            AzureRmRecoveryServicesLongTermRetentionPolicy psRetPolicy)
        {
            LongTermRetentionPolicy hydraRetPolicy = new LongTermRetentionPolicy();

            // TBD

            return hydraRetPolicy;
        }

        public static SimpleRetentionPolicy GetHydraSimpleRetentionPolicy(
            AzureRmRecoveryServicesSimpleSchedulePolicy psRetPolicy)
        {
            throw new NotImplementedException();
        }

        #region private

        // TBD

        #endregion

        #endregion
    }
}
