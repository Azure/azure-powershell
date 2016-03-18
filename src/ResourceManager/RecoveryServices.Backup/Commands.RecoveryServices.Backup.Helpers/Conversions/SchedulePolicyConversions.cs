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

        public static AzureRmRecoveryServicesSimpleSchedulePolicy GetPSSimpleSchedulePolicyPolicy(
            SimpleSchedulePolicy hydraPolicy)
        {
            if (hydraPolicy == null)
            {
                return null;
            }

            AzureRmRecoveryServicesSimpleSchedulePolicy psPolicy = new AzureRmRecoveryServicesSimpleSchedulePolicy();

            psPolicy.ScheduleRunDays = HelperUtils.GetEnumListFromStringList<DayOfWeek>(hydraPolicy.ScheduleRunDays);
            psPolicy.ScheduleRunFrequency = (ScheduleRunType)Enum.Parse(typeof(ScheduleRunType),
                                                                        hydraPolicy.ScheduleRunFrequency);
            psPolicy.ScheduleRunTimes = (List<DateTime>)hydraPolicy.ScheduleRunTimes;

            // safe side validation
            psPolicy.Validate();

            return psPolicy;
        }

        #endregion

        #region PStoHydraObject conversions

        public static SimpleSchedulePolicy GetHydraSimpleSchedulePolicy(
            AzureRmRecoveryServicesSimpleSchedulePolicy psPolicy)
        {
            if (psPolicy == null)
            {
                return null;
            }

            SimpleSchedulePolicy hydraPolicy = new SimpleSchedulePolicy();            
            hydraPolicy.ScheduleRunFrequency = psPolicy.ScheduleRunFrequency.ToString();
            if (psPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
            {
                hydraPolicy.ScheduleRunDays = HelperUtils.GetStringListFromEnumList<DayOfWeek>(psPolicy.ScheduleRunDays);
            }

            return hydraPolicy;
        }

        #endregion
    }
}
