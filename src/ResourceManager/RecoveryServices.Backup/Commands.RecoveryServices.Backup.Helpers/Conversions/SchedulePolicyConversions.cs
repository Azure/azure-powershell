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
using ServiceClientModel  =Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Backup policy conversion helper
    /// </summary>
    public partial class PolicyHelpers
    {
        #region ServiceClientToPSObject conversions

        // <summary>
        /// Helper function to convert ps simple schedule policy from service response.
        /// </summary>
        public static SimpleSchedulePolicy GetPSSimpleSchedulePolicy(
            ServiceClientModel.SimpleSchedulePolicy serviceClientPolicy)
        {
            if (serviceClientPolicy == null)
            {
                return null;
            }

            SimpleSchedulePolicy psPolicy = new SimpleSchedulePolicy();

            psPolicy.ScheduleRunDays = HelperUtils.GetEnumListFromStringList<DayOfWeek>(serviceClientPolicy.ScheduleRunDays);
            psPolicy.ScheduleRunFrequency = (ScheduleRunType)Enum.Parse(typeof(ScheduleRunType),
                                                                        serviceClientPolicy.ScheduleRunFrequency);
            psPolicy.ScheduleRunTimes = ParseDateTimesToUTC(serviceClientPolicy.ScheduleRunTimes);

            // safe side validation
            psPolicy.Validate();

            return psPolicy;
        }

        #endregion

        #region PStoServiceClientObject conversions

        // <summary>
        /// Helper function to parse utc time from local time.
        /// </summary>
        public static List<DateTime> ParseDateTimesToUTC(IList<DateTime> localTimes)
        {
            if (localTimes == null || localTimes.Count == 0)
            {
                return null;
            }

            List<DateTime> utcTimes = new List<DateTime>();
            DateTime temp;

            foreach (DateTime localTime in localTimes)
            {
                temp = localTime;
                if (localTime.Kind != DateTimeKind.Utc)
                {
                    temp = localTime.ToUniversalTime();
                }                
                utcTimes.Add(temp);
            }

            return utcTimes;
        }

        // <summary>
        /// Helper function to convert service simple schedule policy from ps schedule policy.
        /// </summary>
        public static ServiceClientModel.SimpleSchedulePolicy GetServiceClientSimpleSchedulePolicy(
            SimpleSchedulePolicy psPolicy)
        {
            if (psPolicy == null)
            {
                return null;
            }

            ServiceClientModel.SimpleSchedulePolicy serviceClientPolicy = new ServiceClientModel.SimpleSchedulePolicy();            
            serviceClientPolicy.ScheduleRunFrequency = psPolicy.ScheduleRunFrequency.ToString();
            if (psPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
            {
                serviceClientPolicy.ScheduleRunDays = HelperUtils.GetStringListFromEnumList<DayOfWeek>(psPolicy.ScheduleRunDays);
            }
            serviceClientPolicy.ScheduleRunTimes = psPolicy.ScheduleRunTimes;

            return serviceClientPolicy;
        }

        #endregion
    }
}
