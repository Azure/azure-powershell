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
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Backup policy conversion helper
    /// </summary>
    public partial class PolicyHelpers
    {
        #region ServiceClientToPSObject conversions

        #region public

        // <summary>
        /// Helper function to convert ps long term retention policy from service response.
        /// </summary>
        public static LongTermRetentionPolicy GetPSLongTermRetentionPolicy(
            ServiceClientModel.LongTermRetentionPolicy serviceClientRetPolicy)
        {
            if (serviceClientRetPolicy == null)
            {
                return null;
            }

            LongTermRetentionPolicy ltrPolicy = new LongTermRetentionPolicy();

            if (serviceClientRetPolicy.DailySchedule != null)
            {
                ltrPolicy.IsDailyScheduleEnabled = true;
                ltrPolicy.DailySchedule = GetPSLTRDailySchedule(serviceClientRetPolicy.DailySchedule);
            }

            if (serviceClientRetPolicy.WeeklySchedule != null)
            {
                ltrPolicy.IsWeeklyScheduleEnabled = true;
                ltrPolicy.WeeklySchedule = GetPSLTRWeeklySchedule(serviceClientRetPolicy.WeeklySchedule);
            }

            if (serviceClientRetPolicy.MonthlySchedule != null)
            {
                ltrPolicy.IsMonthlyScheduleEnabled = true;
                ltrPolicy.MonthlySchedule = GetPSLTRMonthlySchedule(serviceClientRetPolicy.MonthlySchedule);
            }

            if (serviceClientRetPolicy.YearlySchedule != null)
            {
                ltrPolicy.IsYearlyScheduleEnabled = true;
                ltrPolicy.YearlySchedule = GetPSLTRYearlySchedule(serviceClientRetPolicy.YearlySchedule);
            }

            // safe side validate
            ltrPolicy.Validate();

            return ltrPolicy;
        }

        public static SimpleRetentionPolicy GetPSSimpleRetentionPolicy(
           ServiceClientModel.SimpleRetentionPolicy hydraRetPolicy)
        {
            if (hydraRetPolicy == null)
            {
                return null;
            }

            SimpleRetentionPolicy simplePolicy = new SimpleRetentionPolicy();

            if (hydraRetPolicy.RetentionDuration != null)
            {
                simplePolicy.RetentionDurationType = EnumUtils.GetEnum<RetentionDurationType>(
                    hydraRetPolicy.RetentionDuration.DurationType);
                simplePolicy.RetentionCount = hydraRetPolicy.RetentionDuration.Count;
            }

            simplePolicy.Validate();
            return simplePolicy;
        }

        #endregion

        #region private

        private static int GetRetentionDurationInDays(ServiceClientModel.RetentionDuration retentionDuration)
        {
            int daysCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModel.RetentionDurationType.Days:
                    daysCount = retentionDuration.Count;
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInWeek;
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return daysCount;
        }

        private static int GetRetentionDurationInWeeks(ServiceClientModel.RetentionDuration retentionDuration)
        {
            int weeksCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModel.RetentionDurationType.Days:
                    weeksCount = retentionDuration.Count / PolicyConstants.NumOfDaysInWeek;
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    weeksCount = retentionDuration.Count;
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    weeksCount = retentionDuration.Count * PolicyConstants.NumOfWeeksInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    weeksCount = retentionDuration.Count * PolicyConstants.NumOfWeeksInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return weeksCount;
        }

        private static int GetRetentionDurationInMonths(ServiceClientModel.RetentionDuration retentionDuration)
        {
            int monthsCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModel.RetentionDurationType.Days:
                    monthsCount = retentionDuration.Count / PolicyConstants.NumOfDaysInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    monthsCount = retentionDuration.Count / PolicyConstants.NumOfWeeksInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    monthsCount = retentionDuration.Count;
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    monthsCount = retentionDuration.Count * PolicyConstants.NumOfMonthsInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return monthsCount;
        }

        private static int GetRetentionDurationInYears(ServiceClientModel.RetentionDuration retentionDuration)
        {
            int yearsCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModel.RetentionDurationType.Days:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfDaysInYear;
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfWeeksInYear;
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfMonthsInYear;
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    yearsCount = retentionDuration.Count;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return yearsCount;
        }

        private static DailyRetentionSchedule GetPSLTRDailySchedule(ServiceClientModel.DailyRetentionSchedule serviceClientDaily)
        {
            if (serviceClientDaily == null)
            {
                return null;
            }

            DailyRetentionSchedule psDaily = new DailyRetentionSchedule();

            psDaily.DurationCountInDays = GetRetentionDurationInDays(serviceClientDaily.RetentionDuration);
            psDaily.RetentionTimes = ParseDateTimesToUTC(serviceClientDaily.RetentionTimes);

            return psDaily;
        }

        private static WeeklyRetentionSchedule GetPSLTRWeeklySchedule(ServiceClientModel.WeeklyRetentionSchedule serviceClientWeekly)
        {
            if (serviceClientWeekly == null)
            {
                return null;
            }

            WeeklyRetentionSchedule psWeekly = new WeeklyRetentionSchedule();

            psWeekly.DurationCountInWeeks = GetRetentionDurationInWeeks(serviceClientWeekly.RetentionDuration);
            psWeekly.RetentionTimes = ParseDateTimesToUTC(serviceClientWeekly.RetentionTimes);
            psWeekly.DaysOfTheWeek = HelperUtils.GetEnumListFromStringList<DayOfWeek>(serviceClientWeekly.DaysOfTheWeek);

            return psWeekly;
        }

        private static MonthlyRetentionSchedule GetPSLTRMonthlySchedule(ServiceClientModel.MonthlyRetentionSchedule serviceClientMonthly)
        {
            if (serviceClientMonthly == null)
            {
                return null;
            }

            MonthlyRetentionSchedule psMonthly = new MonthlyRetentionSchedule();

            psMonthly.DurationCountInMonths = GetRetentionDurationInMonths(serviceClientMonthly.RetentionDuration);
            psMonthly.RetentionTimes = ParseDateTimesToUTC(serviceClientMonthly.RetentionTimes);
            psMonthly.RetentionScheduleFormatType = (RetentionScheduleFormat)Enum.Parse(typeof(RetentionScheduleFormat),
                                                                                   serviceClientMonthly.RetentionScheduleFormatType);
            psMonthly.RetentionScheduleDaily = GetPSLTRDailyRetentionFormat(serviceClientMonthly.RetentionScheduleDaily);
            psMonthly.RetentionScheduleWeekly = GetPSLTRWeeklyRetentionFormat(serviceClientMonthly.RetentionScheduleWeekly);

            return psMonthly;
        }

        private static YearlyRetentionSchedule GetPSLTRYearlySchedule(ServiceClientModel.YearlyRetentionSchedule serviceClientYearly)
        {
            if (serviceClientYearly == null)
            {
                return null;
            }

            YearlyRetentionSchedule psYearly = new YearlyRetentionSchedule();

            psYearly.DurationCountInYears = GetRetentionDurationInYears(serviceClientYearly.RetentionDuration);
            psYearly.RetentionTimes = ParseDateTimesToUTC(serviceClientYearly.RetentionTimes);
            psYearly.RetentionScheduleFormatType = (RetentionScheduleFormat)Enum.Parse(typeof(RetentionScheduleFormat),
                                                                                   serviceClientYearly.RetentionScheduleFormatType);
            psYearly.RetentionScheduleDaily = GetPSLTRDailyRetentionFormat(serviceClientYearly.RetentionScheduleDaily);
            psYearly.RetentionScheduleWeekly = GetPSLTRWeeklyRetentionFormat(serviceClientYearly.RetentionScheduleWeekly);
            psYearly.MonthsOfYear = HelperUtils.GetEnumListFromStringList<Month>(serviceClientYearly.MonthsOfYear);

            return psYearly;
        }

        private static DailyRetentionFormat GetPSLTRDailyRetentionFormat(
                                            ServiceClientModel.DailyRetentionFormat serviceClientFormat)
        {
            if (serviceClientFormat == null)
            {
                return null;
            }

            DailyRetentionFormat psFormat = new DailyRetentionFormat();

            if (serviceClientFormat.DaysOfTheMonth != null)
            {
                psFormat.DaysOfTheMonth = new List<Day>();

                foreach (ServiceClientModel.Day serviceClientDay in serviceClientFormat.DaysOfTheMonth)
                {
                    Day psDay = new Day()
                    {
                        Date = serviceClientDay.Date,
                        IsLast = serviceClientDay.IsLast
                    };

                    psFormat.DaysOfTheMonth.Add(psDay);
                }
            }

            return psFormat;
        }

        private static WeeklyRetentionFormat GetPSLTRWeeklyRetentionFormat(
                                             ServiceClientModel.WeeklyRetentionFormat serviceClientFormat)
        {
            if (serviceClientFormat == null)
            {
                return null;
            }

            WeeklyRetentionFormat psFormat = new WeeklyRetentionFormat();
            if (serviceClientFormat.DaysOfTheWeek != null)
            {
                psFormat.DaysOfTheWeek = HelperUtils.GetEnumListFromStringList<DayOfWeek>(serviceClientFormat.DaysOfTheWeek);
            }
            if (serviceClientFormat.WeeksOfTheMonth != null)
            {
                psFormat.WeeksOfTheMonth = HelperUtils.GetEnumListFromStringList<WeekOfMonth>(serviceClientFormat.WeeksOfTheMonth);
            }

            return psFormat;
        }

        #endregion

        #endregion

        #region PStoServiceClientObject conversions

        public static ServiceClientModel.SimpleRetentionPolicy
            GetServiceClientSimpleRetentionPolicy(SimpleRetentionPolicy psRetPolicy)
        {
            if (psRetPolicy == null)
            {
                return null;
            }
            else
            {
                ServiceClientModel.SimpleRetentionPolicy simpleRetPolicy = 
                    new ServiceClientModel.SimpleRetentionPolicy();

                string durationType = psRetPolicy.RetentionDurationType.ToString();
                simpleRetPolicy.RetentionDuration = new ServiceClientModel.RetentionDuration();
                simpleRetPolicy.RetentionDuration.DurationType = durationType;
                simpleRetPolicy.RetentionDuration.Count = psRetPolicy.RetentionCount;

                return simpleRetPolicy;
            }
        }

        // <summary>
        /// Helper function to convert service long term retention policy from ps retention policy.
        /// </summary>
        public static ServiceClientModel.LongTermRetentionPolicy GetServiceClientLongTermRetentionPolicy(
            LongTermRetentionPolicy psRetPolicy)
        {
            if (psRetPolicy == null)
            {
                return null;
            }

            ServiceClientModel.LongTermRetentionPolicy serviceClientRetPolicy = new ServiceClientModel.LongTermRetentionPolicy();

            if (psRetPolicy.IsDailyScheduleEnabled)
            {
                serviceClientRetPolicy.DailySchedule = GetServiceClientLTRDailySchedule(psRetPolicy.DailySchedule);
            }

            if (psRetPolicy.IsWeeklyScheduleEnabled)
            {
                serviceClientRetPolicy.WeeklySchedule = GetServiceClientLTRWeeklySchedule(psRetPolicy.WeeklySchedule);
            }

            if (psRetPolicy.IsMonthlyScheduleEnabled)
            {
                serviceClientRetPolicy.MonthlySchedule = GetServiceClientLTRMonthlySchedule(psRetPolicy.MonthlySchedule);
            }

            if (psRetPolicy.IsYearlyScheduleEnabled)
            {
                serviceClientRetPolicy.YearlySchedule = GetServiceClientLTRYearlySchedule(psRetPolicy.YearlySchedule);
            }

            return serviceClientRetPolicy;
        }

        // <summary>
        /// Helper function to convert service simple retention policy from ps simple policy.
        /// </summary>
        public static ServiceClientModel.SimpleRetentionPolicy GetServiceClientSimpleRetentionPolicy(
            SimpleSchedulePolicy psRetPolicy)
        {
            throw new NotSupportedException();
        }

        #region private
        private static ServiceClientModel.DailyRetentionSchedule GetServiceClientLTRDailySchedule(DailyRetentionSchedule psDaily)
        {
            if (psDaily == null)
            {
                return null;
            }

            ServiceClientModel.DailyRetentionSchedule serviceClientDaily = new ServiceClientModel.DailyRetentionSchedule();

            serviceClientDaily.RetentionDuration = new ServiceClientModel.RetentionDuration()
            {
                Count = psDaily.DurationCountInDays,
                DurationType = ServiceClientModel.RetentionDurationType.Days
            };

            serviceClientDaily.RetentionTimes = psDaily.RetentionTimes;

            return serviceClientDaily;
        }

        private static ServiceClientModel.WeeklyRetentionSchedule GetServiceClientLTRWeeklySchedule(WeeklyRetentionSchedule psWeekly)
        {
            if (psWeekly == null)
            {
                return null;
            }

            ServiceClientModel.WeeklyRetentionSchedule serviceClientWeekly = new ServiceClientModel.WeeklyRetentionSchedule();

            serviceClientWeekly.RetentionDuration = new ServiceClientModel.RetentionDuration()
            {
                Count = psWeekly.DurationCountInWeeks,
                DurationType = ServiceClientModel.RetentionDurationType.Weeks
            };
            serviceClientWeekly.RetentionTimes = psWeekly.RetentionTimes;
            serviceClientWeekly.DaysOfTheWeek = HelperUtils.GetStringListFromEnumList<DayOfWeek>(psWeekly.DaysOfTheWeek);

            return serviceClientWeekly;
        }

        private static ServiceClientModel.MonthlyRetentionSchedule GetServiceClientLTRMonthlySchedule(MonthlyRetentionSchedule psMonthly)
        {
            if (psMonthly == null)
            {
                return null;
            }

            ServiceClientModel.MonthlyRetentionSchedule serviceClientMonthly = new ServiceClientModel.MonthlyRetentionSchedule();

            serviceClientMonthly.RetentionDuration = new ServiceClientModel.RetentionDuration()
            {
                Count = psMonthly.DurationCountInMonths,
                DurationType = ServiceClientModel.RetentionDurationType.Months
            };
            serviceClientMonthly.RetentionTimes = psMonthly.RetentionTimes;

            serviceClientMonthly.RetentionScheduleFormatType = psMonthly.RetentionScheduleFormatType.ToString();
            if (psMonthly.RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
            {
                serviceClientMonthly.RetentionScheduleDaily = GetServiceClientLTRDailyRetentionFormat(psMonthly.RetentionScheduleDaily);
            }
            else if (psMonthly.RetentionScheduleFormatType == RetentionScheduleFormat.Weekly)
            {
                serviceClientMonthly.RetentionScheduleWeekly = GetServiceClientLTRWeeklyRetentionFormat(psMonthly.RetentionScheduleWeekly);
            }

            return serviceClientMonthly;
        }

        private static ServiceClientModel.YearlyRetentionSchedule GetServiceClientLTRYearlySchedule(YearlyRetentionSchedule psYearly)
        {
            if (psYearly == null)
            {
                return null;
            }

            ServiceClientModel.YearlyRetentionSchedule serviceClientYearly = new ServiceClientModel.YearlyRetentionSchedule();

            serviceClientYearly.RetentionDuration = new ServiceClientModel.RetentionDuration()
            {
                Count = psYearly.DurationCountInYears,
                DurationType = ServiceClientModel.RetentionDurationType.Years
            };
            serviceClientYearly.RetentionTimes = psYearly.RetentionTimes;

            serviceClientYearly.RetentionScheduleFormatType = psYearly.RetentionScheduleFormatType.ToString();
            if (psYearly.RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
            {
                serviceClientYearly.RetentionScheduleDaily = GetServiceClientLTRDailyRetentionFormat(psYearly.RetentionScheduleDaily);
            }
            else if (psYearly.RetentionScheduleFormatType == RetentionScheduleFormat.Weekly)
            {
                serviceClientYearly.RetentionScheduleWeekly = GetServiceClientLTRWeeklyRetentionFormat(psYearly.RetentionScheduleWeekly);
            }
            serviceClientYearly.MonthsOfYear = HelperUtils.GetStringListFromEnumList<Month>(psYearly.MonthsOfYear);

            return serviceClientYearly;
        }

        private static ServiceClientModel.DailyRetentionFormat GetServiceClientLTRDailyRetentionFormat(
                                             DailyRetentionFormat psFormat)
        {
            if (psFormat == null)
            {
                return null;
            }

            ServiceClientModel.DailyRetentionFormat serviceClientFormat = new ServiceClientModel.DailyRetentionFormat();

            if (psFormat.DaysOfTheMonth != null)
            {
                serviceClientFormat.DaysOfTheMonth = new List<ServiceClientModel.Day>();

                foreach (Day psDay in psFormat.DaysOfTheMonth)
                {
                    ServiceClientModel.Day serviceClientDay = new ServiceClientModel.Day()
                    {
                        Date = psDay.Date,
                        IsLast = psDay.IsLast
                    };

                    serviceClientFormat.DaysOfTheMonth.Add(serviceClientDay);
                }
            }

            return serviceClientFormat;
        }

        private static ServiceClientModel.WeeklyRetentionFormat GetServiceClientLTRWeeklyRetentionFormat(
                                              WeeklyRetentionFormat psFormat)
        {
            if (psFormat == null)
            {
                return null;
            }

            ServiceClientModel.WeeklyRetentionFormat serviceClientFormat = new ServiceClientModel.WeeklyRetentionFormat();
            if (psFormat.DaysOfTheWeek != null)
            {
                serviceClientFormat.DaysOfTheWeek = HelperUtils.GetStringListFromEnumList<DayOfWeek>(psFormat.DaysOfTheWeek);
            }
            if (psFormat.WeeksOfTheMonth != null)
            {
                serviceClientFormat.WeeksOfTheMonth = HelperUtils.GetStringListFromEnumList<WeekOfMonth>(psFormat.WeeksOfTheMonth);
            }

            return serviceClientFormat;
        }

        #endregion

        #endregion
    }
}
