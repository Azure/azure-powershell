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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Backup policy conversion helper
    /// </summary>
    public partial class PolicyHelpers
    {
        #region ServiceClientToPSObject conversions

        /// <summary>
        /// Helper function to convert ps simple schedule policy from service response.
        /// </summary>
        public static SimpleSchedulePolicy GetPSSimpleSchedulePolicy(
            ServiceClientModel.SimpleSchedulePolicy serviceClientPolicy, string timeZone)
        {
            if (serviceClientPolicy == null)
            {
                return null;
            }

            SimpleSchedulePolicy psPolicy = new SimpleSchedulePolicy();

            psPolicy.ScheduleRunDays = HelperUtils.EnumListConverter<ServiceClientModel.DayOfWeek?, DayOfWeek>(serviceClientPolicy.ScheduleRunDays);

            psPolicy.ScheduleRunFrequency = (ScheduleRunType)Enum.Parse(typeof(ScheduleRunType), serviceClientPolicy.ScheduleRunFrequency.ToString());
            psPolicy.ScheduleRunTimes = ParseDateTimesToUTC(serviceClientPolicy.ScheduleRunTimes, timeZone);

            if (psPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
            {
                int offset = psPolicy.ScheduleRunTimes[0].DayOfWeek.GetHashCode() -
                    serviceClientPolicy.ScheduleRunTimes[0].Value.DayOfWeek.GetHashCode();

                for (int index = 0; index < psPolicy.ScheduleRunDays.Count(); index++)
                {
                    if (offset == -1)
                    {
                        int value = psPolicy.ScheduleRunDays[index].GetHashCode() - 1;
                        if (value == -1)
                        {
                            value = 6;
                        }
                        psPolicy.ScheduleRunDays[index] = (DayOfWeek)value;
                    }
                    else if (offset == 1)
                    {
                        int value = psPolicy.ScheduleRunDays[index].GetHashCode() + 1;
                        if (value == 7)
                        {
                            value = 0;
                        }
                        psPolicy.ScheduleRunDays[index] = (DayOfWeek)value;
                    }
                }
            }
            
            if(psPolicy.ScheduleRunFrequency == ScheduleRunType.Hourly)
            {
                // multiple backups per day 
                psPolicy.ScheduleInterval = serviceClientPolicy.HourlySchedule.Interval;
                psPolicy.ScheduleWindowStartTime = serviceClientPolicy.HourlySchedule.ScheduleWindowStartTime;
                psPolicy.ScheduleWindowDuration = serviceClientPolicy.HourlySchedule.ScheduleWindowDuration;
                psPolicy.ScheduleRunTimeZone = timeZone;
            }
            else
            {
                psPolicy.ScheduleRunTimeZone = timeZone;
            }

            // safe side validation
            psPolicy.Validate();       
                        
            return psPolicy;
        }

        /// <summary>
        /// Helper function to convert ps simple schedule policy from service response.
        /// </summary>
        public static SimpleSchedulePolicyV2 GetPSSimpleSchedulePolicyV2(
            ServiceClientModel.SimpleSchedulePolicyV2 serviceClientPolicy, string timeZone)
        {
            if (serviceClientPolicy == null)
            {
                return null;
            }
                        
            SimpleSchedulePolicyV2 psPolicy = new SimpleSchedulePolicyV2();
            
            psPolicy.ScheduleRunFrequency = (ScheduleRunType)Enum.Parse(typeof(ScheduleRunType), serviceClientPolicy.ScheduleRunFrequency.ToString());

            if (psPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
            {   
                psPolicy.WeeklySchedule = new WeeklySchedule();
                                
                int offset = 0;
                if (serviceClientPolicy.WeeklySchedule != null)
                {
                    psPolicy.WeeklySchedule.ScheduleRunDays = HelperUtils.EnumListConverter<ServiceClientModel.DayOfWeek?, DayOfWeek>(serviceClientPolicy.WeeklySchedule.ScheduleRunDays);                    
                    psPolicy.WeeklySchedule.ScheduleRunTimes = ParseDateTimesToUTC(serviceClientPolicy.WeeklySchedule.ScheduleRunTimes, timeZone);

                    offset = psPolicy.WeeklySchedule.ScheduleRunTimes[0].DayOfWeek.GetHashCode() - serviceClientPolicy.WeeklySchedule.ScheduleRunTimes[0].Value.DayOfWeek.GetHashCode();
                }

                for (int index = 0; index < psPolicy.WeeklySchedule.ScheduleRunDays.Count(); index++)
                {
                    if (offset == -1)
                    {
                        int value = psPolicy.WeeklySchedule.ScheduleRunDays[index].GetHashCode() - 1;
                        if (value == -1)
                        {
                            value = 6;
                        }
                        
                        psPolicy.WeeklySchedule.ScheduleRunDays[index] = (DayOfWeek)value;
                    }
                    else if (offset == 1)
                    {
                        int value = psPolicy.WeeklySchedule.ScheduleRunDays[index].GetHashCode() + 1;
                        if (value == 7)
                        {
                            value = 0;
                        }
                        psPolicy.WeeklySchedule.ScheduleRunDays[index] = (DayOfWeek)value;
                    }
                }                
            }
            else if (psPolicy.ScheduleRunFrequency == ScheduleRunType.Hourly)
            {   
                psPolicy.HourlySchedule = new HourlySchedule();
                
                // multiple backups per day 
                psPolicy.HourlySchedule.Interval = serviceClientPolicy.HourlySchedule.Interval;
                psPolicy.HourlySchedule.WindowStartTime = serviceClientPolicy.HourlySchedule.ScheduleWindowStartTime;
                psPolicy.HourlySchedule.WindowDuration = serviceClientPolicy.HourlySchedule.ScheduleWindowDuration;
            }
            else
            {
                psPolicy.DailySchedule = new DailySchedule();
                psPolicy.DailySchedule.ScheduleRunTimes = (serviceClientPolicy.DailySchedule != null) ? ParseDateTimesToUTC(serviceClientPolicy.DailySchedule.ScheduleRunTimes, timeZone) : null;
            }

            psPolicy.ScheduleRunTimeZone = timeZone;

            // safe side validation
            psPolicy.Validate();
            
            return psPolicy;
        }

        /// <summary>
        /// Helper function to convert ps log schedule policy from service response.
        /// </summary>
        public static LogSchedulePolicy GetPSLogSchedulePolicy(
            ServiceClientModel.LogSchedulePolicy serviceClientPolicy, string timeZone)
        {
            if (serviceClientPolicy == null)
            {
                return null;
            }

            LogSchedulePolicy psPolicy = new LogSchedulePolicy();
            psPolicy.ScheduleFrequencyInMins = serviceClientPolicy.ScheduleFrequencyInMins;

            // safe side validation
            psPolicy.Validate();

            return psPolicy;
        }

        #endregion

        #region PStoServiceClientObject conversions

        /// <summary>
        /// Helper function to parse utc time from local time.
        /// </summary>
        public static List<DateTime> ParseDateTimesToUTC(IList<DateTime?> localTimes, string timeZone)
        {
            if (localTimes == null || localTimes.Count == 0)
            {
                return null;
            }

            List<DateTime> utcTimes = new List<DateTime>();
            DateTime temp;

            foreach (DateTime localTime in localTimes)
            {
                if (localTime == null)
                {
                    throw new ArgumentNullException("Policy date time object is null");
                }
                temp = localTime;
                if (!string.IsNullOrEmpty(timeZone))
                {
                    TimeZoneInfo timeZoneInfo = TimeZoneConverter.TZConvert.GetTimeZoneInfo(timeZone);
                    temp = DateTime.SpecifyKind(temp, DateTimeKind.Unspecified);
                    temp = TimeZoneInfo.ConvertTimeToUtc(temp, timeZoneInfo);
                }
                utcTimes.Add(temp);
            }

            return utcTimes;
        }

        /// <summary>
        /// Helper function to convert service simple schedule policy from ps schedule policy.
        /// </summary>
        public static ServiceClientModel.SchedulePolicy GetServiceClientSimpleSchedulePolicy(
            SchedulePolicyBase psPolicy)
        {
            if (psPolicy == null)
            {
                return null;
            }

            if (psPolicy.GetType() == typeof(SimpleSchedulePolicy))
            {
                SimpleSchedulePolicy schPolicy = (SimpleSchedulePolicy)psPolicy;
                ServiceClientModel.SimpleSchedulePolicy serviceClientPolicy = new ServiceClientModel.SimpleSchedulePolicy();

                serviceClientPolicy.ScheduleRunFrequency = ServiceClientHelpers.GetServiceClientScheduleRunType(schPolicy.ScheduleRunFrequency);

                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    serviceClientPolicy.ScheduleRunDays = HelperUtils.EnumListConverter<DayOfWeek, ServiceClientModel.DayOfWeek>(
                            schPolicy.ScheduleRunDays).Cast<ServiceClientModel.DayOfWeek?>().ToList();
                }

                if (schPolicy.ScheduleRunFrequency != ScheduleRunType.Hourly)
                {
                    serviceClientPolicy.ScheduleRunTimes = schPolicy.ScheduleRunTimes.ConvertAll(dateTime => (DateTime?)dateTime);
                }
                else
                {
                    serviceClientPolicy.HourlySchedule = new ServiceClientModel.HourlySchedule();
                    serviceClientPolicy.HourlySchedule.Interval = schPolicy.ScheduleInterval;
                    serviceClientPolicy.HourlySchedule.ScheduleWindowDuration = schPolicy.ScheduleWindowDuration;
                    serviceClientPolicy.HourlySchedule.ScheduleWindowStartTime = schPolicy.ScheduleWindowStartTime;
                }
                return serviceClientPolicy;
            }

            else if (psPolicy.GetType() == typeof(SimpleSchedulePolicyV2))
            {
                SimpleSchedulePolicyV2 schPolicyV2 = (SimpleSchedulePolicyV2)psPolicy;
                ServiceClientModel.SimpleSchedulePolicyV2 serviceClientPolicyV2 = new ServiceClientModel.SimpleSchedulePolicyV2();

                serviceClientPolicyV2.ScheduleRunFrequency = ServiceClientHelpers.GetServiceClientScheduleRunType(schPolicyV2.ScheduleRunFrequency);

                if (schPolicyV2.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    serviceClientPolicyV2.WeeklySchedule = new ServiceClientModel.WeeklySchedule();
                    serviceClientPolicyV2.WeeklySchedule.ScheduleRunDays = HelperUtils.EnumListConverter<DayOfWeek, ServiceClientModel.DayOfWeek>(
                            schPolicyV2.WeeklySchedule.ScheduleRunDays).Cast<ServiceClientModel.DayOfWeek?>().ToList(); 

                    serviceClientPolicyV2.WeeklySchedule.ScheduleRunTimes = schPolicyV2.WeeklySchedule.ScheduleRunTimes.ConvertAll(dateTime => (DateTime?)dateTime);
                }
                else if (schPolicyV2.ScheduleRunFrequency == ScheduleRunType.Daily)
                {
                    serviceClientPolicyV2.DailySchedule = new ServiceClientModel.DailySchedule();
                    serviceClientPolicyV2.DailySchedule.ScheduleRunTimes = schPolicyV2.DailySchedule.ScheduleRunTimes.ConvertAll(dateTime => (DateTime?)dateTime); 
                }
                else if(schPolicyV2.ScheduleRunFrequency == ScheduleRunType.Hourly)
                {
                    serviceClientPolicyV2.HourlySchedule = new ServiceClientModel.HourlySchedule();
                    serviceClientPolicyV2.HourlySchedule.Interval = schPolicyV2.HourlySchedule.Interval;
                    serviceClientPolicyV2.HourlySchedule.ScheduleWindowDuration = schPolicyV2.HourlySchedule.WindowDuration;
                    serviceClientPolicyV2.HourlySchedule.ScheduleWindowStartTime = schPolicyV2.HourlySchedule.WindowStartTime;
                }
                return serviceClientPolicyV2;
            }

            return null;
        }

        public static ServiceClientModel.LogSchedulePolicy GetServiceClientLogSchedulePolicy(
            LogSchedulePolicy psPolicy)
        {
            if (psPolicy == null)
            {
                return null;
            }

            ServiceClientModel.LogSchedulePolicy serviceClientPolicy = new ServiceClientModel.LogSchedulePolicy();
            serviceClientPolicy.ScheduleFrequencyInMins = psPolicy.ScheduleFrequencyInMins;
            return serviceClientPolicy;
        }

        /// <summary>
        /// Helper function to get nullable date time list from date time list.
        /// </summary>
        public static List<DateTime?> GetNullableDateTimeListFromDateTimeList(
            IList<DateTime> localTimes)
        {
            if (localTimes == null || localTimes.Count == 0)
            {
                return null;
            }

            List<DateTime?> convertedTime = new List<DateTime?>();

            foreach (DateTime localTime in localTimes)
            {
                convertedTime.Add(localTime);
            }

            return convertedTime;
        }
        #endregion
    }
}
