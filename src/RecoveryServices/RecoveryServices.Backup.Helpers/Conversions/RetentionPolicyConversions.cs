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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
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

        #region public

        /// <summary>
        /// Helper function to convert ps long term retention policy from service response.
        /// </summary>
        public static LongTermRetentionPolicy GetPSLongTermRetentionPolicy(
            ServiceClientModel.LongTermRetentionPolicy serviceClientRetPolicy, string timeZone, string backupManagementType="")
        {
            if (serviceClientRetPolicy == null)
            {
                return null;
            }

            LongTermRetentionPolicy ltrPolicy = new LongTermRetentionPolicy();

            if (serviceClientRetPolicy.DailySchedule != null)
            {
                ltrPolicy.IsDailyScheduleEnabled = true;
                ltrPolicy.DailySchedule = GetPSLTRDailySchedule(serviceClientRetPolicy.DailySchedule, timeZone);
                ltrPolicy.DailySchedule.BackupManagementType = backupManagementType;
            }

            if (serviceClientRetPolicy.WeeklySchedule != null)
            {
                ltrPolicy.IsWeeklyScheduleEnabled = true;
                ltrPolicy.WeeklySchedule = GetPSLTRWeeklySchedule(serviceClientRetPolicy.WeeklySchedule, timeZone);
                ltrPolicy.WeeklySchedule.BackupManagementType = backupManagementType;
            }

            if (serviceClientRetPolicy.MonthlySchedule != null)
            {
                ltrPolicy.IsMonthlyScheduleEnabled = true;
                ltrPolicy.MonthlySchedule = GetPSLTRMonthlySchedule(serviceClientRetPolicy.MonthlySchedule, timeZone);
                ltrPolicy.MonthlySchedule.BackupManagementType = backupManagementType;
            }

            if (serviceClientRetPolicy.YearlySchedule != null)
            {
                ltrPolicy.IsYearlyScheduleEnabled = true;
                ltrPolicy.YearlySchedule = GetPSLTRYearlySchedule(serviceClientRetPolicy.YearlySchedule, timeZone);
                ltrPolicy.YearlySchedule.BackupManagementType = backupManagementType;
            }

            ltrPolicy.BackupManagementType = backupManagementType;
            return ltrPolicy;
        }

        public static SimpleRetentionPolicy GetPSSimpleRetentionPolicy(
           ServiceClientModel.SimpleRetentionPolicy hydraRetPolicy, string timeZone, string provider)
        {
            if (hydraRetPolicy == null)
            {
                return null;
            }

            SimpleRetentionPolicy simplePolicy = new SimpleRetentionPolicy();

            if (hydraRetPolicy.RetentionDuration != null)
            {
                simplePolicy.RetentionDurationType = EnumUtils.GetEnum<RetentionDurationType>(
                    hydraRetPolicy.RetentionDuration.DurationType.ToString());
                simplePolicy.RetentionCount = hydraRetPolicy.RetentionDuration.Count.HasValue ?
                    (int)hydraRetPolicy.RetentionDuration.Count : default(int);
            }

            if (string.Compare(provider, "AzureSql") == 0)
            {
                int weeklyLimit = PolicyConstants.MaxAllowedRetentionDurationCountWeeklySql;
                int monthlyLimit = PolicyConstants.MaxAllowedRetentionDurationCountMonthlySql;
                int yearlyLimit = PolicyConstants.MaxAllowedRetentionDurationCountYearlySql;

                if ((simplePolicy.RetentionDurationType == RetentionDurationType.Days) ||
                    (simplePolicy.RetentionDurationType == RetentionDurationType.Weeks &&
                        (simplePolicy.RetentionCount <= 0 || simplePolicy.RetentionCount > weeklyLimit)) ||
                    (simplePolicy.RetentionDurationType == RetentionDurationType.Months &&
                        (simplePolicy.RetentionCount <= 0 || simplePolicy.RetentionCount > monthlyLimit)) ||
                    (simplePolicy.RetentionDurationType == RetentionDurationType.Years &&
                        (simplePolicy.RetentionCount <= 0 || simplePolicy.RetentionCount > yearlyLimit)))
                {
                    throw new ArgumentException(Resources.AllowedSqlRetentionRange);
                }
            }

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
                    daysCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count);
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    daysCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                            * PolicyConstants.NumOfDaysInWeek;
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    daysCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                            * PolicyConstants.NumOfDaysInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    daysCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                * PolicyConstants.NumOfDaysInYear;
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
                    weeksCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                / PolicyConstants.NumOfDaysInWeek;
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    weeksCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count);
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    weeksCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                * PolicyConstants.NumOfWeeksInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    weeksCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                * PolicyConstants.NumOfWeeksInYear;
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
                    monthsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                  / PolicyConstants.NumOfDaysInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    monthsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                  / PolicyConstants.NumOfWeeksInMonth;
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    monthsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count);
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    monthsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                  * PolicyConstants.NumOfMonthsInYear;
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
                    yearsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                 / PolicyConstants.NumOfDaysInYear;
                    break;

                case ServiceClientModel.RetentionDurationType.Weeks:
                    yearsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                  / PolicyConstants.NumOfWeeksInYear;
                    break;

                case ServiceClientModel.RetentionDurationType.Months:
                    yearsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count)
                                  / PolicyConstants.NumOfMonthsInYear;
                    break;

                case ServiceClientModel.RetentionDurationType.Years:
                    yearsCount = GetIntegerFromNullableIntgerValue(retentionDuration.Count);
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return yearsCount;
        }

        private static DailyRetentionSchedule GetPSLTRDailySchedule(ServiceClientModel.DailyRetentionSchedule serviceClientDaily,
            string timeZone)
        {
            if (serviceClientDaily == null)
            {
                return null;
            }

            DailyRetentionSchedule psDaily = new DailyRetentionSchedule();

            psDaily.DurationCountInDays = GetRetentionDurationInDays(serviceClientDaily.RetentionDuration);
            psDaily.RetentionTimes = ParseDateTimesToUTC(serviceClientDaily.RetentionTimes, timeZone);

            return psDaily;
        }

        private static WeeklyRetentionSchedule GetPSLTRWeeklySchedule(ServiceClientModel.WeeklyRetentionSchedule serviceClientWeekly,
            string timeZone)
        {
            if (serviceClientWeekly == null)
            {
                return null;
            }

            WeeklyRetentionSchedule psWeekly = new WeeklyRetentionSchedule();

            psWeekly.DurationCountInWeeks = GetRetentionDurationInWeeks(serviceClientWeekly.RetentionDuration);
            psWeekly.RetentionTimes = ParseDateTimesToUTC(serviceClientWeekly.RetentionTimes, timeZone);
            psWeekly.DaysOfTheWeek =
                HelperUtils.EnumListConverter<ServiceClientModel.DayOfWeek?, DayOfWeek>(
                    serviceClientWeekly.DaysOfTheWeek);

            return psWeekly;
        }

        private static MonthlyRetentionSchedule GetPSLTRMonthlySchedule(ServiceClientModel.MonthlyRetentionSchedule serviceClientMonthly,
            string timeZone)
        {
            if (serviceClientMonthly == null)
            {
                return null;
            }

            MonthlyRetentionSchedule psMonthly = new MonthlyRetentionSchedule();

            psMonthly.DurationCountInMonths = GetRetentionDurationInMonths(serviceClientMonthly.RetentionDuration);
            psMonthly.RetentionTimes = ParseDateTimesToUTC(serviceClientMonthly.RetentionTimes, timeZone);
            psMonthly.RetentionScheduleFormatType =
                serviceClientMonthly.RetentionScheduleFormatType.ToEnum<RetentionScheduleFormat>();
            psMonthly.RetentionScheduleDaily = GetPSLTRDailyRetentionFormat(serviceClientMonthly.RetentionScheduleDaily);
            psMonthly.RetentionScheduleWeekly = GetPSLTRWeeklyRetentionFormat(serviceClientMonthly.RetentionScheduleWeekly);

            return psMonthly;
        }

        private static YearlyRetentionSchedule GetPSLTRYearlySchedule(ServiceClientModel.YearlyRetentionSchedule serviceClientYearly,
            string timeZone)
        {
            if (serviceClientYearly == null)
            {
                return null;
            }

            YearlyRetentionSchedule psYearly = new YearlyRetentionSchedule();

            psYearly.DurationCountInYears = GetRetentionDurationInYears(serviceClientYearly.RetentionDuration);
            psYearly.RetentionTimes = ParseDateTimesToUTC(serviceClientYearly.RetentionTimes, timeZone);
            psYearly.RetentionScheduleFormatType =
                serviceClientYearly.RetentionScheduleFormatType.ToEnum<RetentionScheduleFormat>();
            psYearly.RetentionScheduleDaily = GetPSLTRDailyRetentionFormat(serviceClientYearly.RetentionScheduleDaily);
            psYearly.RetentionScheduleWeekly = GetPSLTRWeeklyRetentionFormat(serviceClientYearly.RetentionScheduleWeekly);
            psYearly.MonthsOfYear =
                HelperUtils.EnumListConverter<ServiceClientModel.MonthOfYear?, Month>(
                    serviceClientYearly.MonthsOfYear);

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
                        Date = GetIntegerFromNullableIntgerValue(serviceClientDay.Date),
                        IsLast = serviceClientDay.IsLast.HasValue ?
                                 (bool)serviceClientDay.IsLast : default(bool)
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
                psFormat.DaysOfTheWeek =
                    HelperUtils.EnumListConverter<ServiceClientModel.DayOfWeek?, DayOfWeek>(
                        serviceClientFormat.DaysOfTheWeek);
            }
            if (serviceClientFormat.WeeksOfTheMonth != null)
            {
                psFormat.WeeksOfTheMonth =
                    HelperUtils.EnumListConverter<ServiceClientModel.WeekOfMonth?, WeekOfMonth>(
                        serviceClientFormat.WeeksOfTheMonth);
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

                simpleRetPolicy.RetentionDuration = new ServiceClientModel.RetentionDuration();
                simpleRetPolicy.RetentionDuration.DurationType =
                    ServiceClientHelpers.GetServiceClientRetentionDurationType(psRetPolicy.RetentionDurationType);
                simpleRetPolicy.RetentionDuration.Count = psRetPolicy.RetentionCount;

                return simpleRetPolicy;
            }
        }

        /// <summary>
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

        /// <summary>
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

            serviceClientDaily.RetentionTimes = GetNullableDateTimeListFromDateTimeList
                                                (psDaily.RetentionTimes);

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
            serviceClientWeekly.RetentionTimes =
                GetNullableDateTimeListFromDateTimeList(psWeekly.RetentionTimes);
            serviceClientWeekly.DaysOfTheWeek =
                HelperUtils.EnumListConverter<DayOfWeek, ServiceClientModel.DayOfWeek>(
                    psWeekly.DaysOfTheWeek).Cast<ServiceClientModel.DayOfWeek?>().ToList();

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
            serviceClientMonthly.RetentionTimes = GetNullableDateTimeListFromDateTimeList(
                                                  psMonthly.RetentionTimes);

            serviceClientMonthly.RetentionScheduleFormatType =
                ServiceClientHelpers.GetServiceClientRetentionScheduleFormat(
                    psMonthly.RetentionScheduleFormatType);

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
            serviceClientYearly.RetentionTimes = GetNullableDateTimeListFromDateTimeList(
                                                 psYearly.RetentionTimes);

            serviceClientYearly.RetentionScheduleFormatType =
                    ServiceClientHelpers.GetServiceClientRetentionScheduleFormat(
                    psYearly.RetentionScheduleFormatType);

            if (psYearly.RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
            {
                serviceClientYearly.RetentionScheduleDaily = GetServiceClientLTRDailyRetentionFormat(psYearly.RetentionScheduleDaily);
            }
            else if (psYearly.RetentionScheduleFormatType == RetentionScheduleFormat.Weekly)
            {
                serviceClientYearly.RetentionScheduleWeekly = GetServiceClientLTRWeeklyRetentionFormat(psYearly.RetentionScheduleWeekly);
            }
            serviceClientYearly.MonthsOfYear =
                HelperUtils.EnumListConverter<Month, ServiceClientModel.MonthOfYear>(
                    psYearly.MonthsOfYear).Cast<ServiceClientModel.MonthOfYear?>().ToList();

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
                serviceClientFormat.DaysOfTheWeek =
                    HelperUtils.EnumListConverter<DayOfWeek, ServiceClientModel.DayOfWeek>(
                        psFormat.DaysOfTheWeek).Cast<ServiceClientModel.DayOfWeek?>().ToList();
            }
            if (psFormat.WeeksOfTheMonth != null)
            {
                serviceClientFormat.WeeksOfTheMonth =
                    HelperUtils.EnumListConverter<WeekOfMonth, ServiceClientModel.WeekOfMonth>(
                        psFormat.WeeksOfTheMonth).Cast<ServiceClientModel.WeekOfMonth?>().ToList();
            }

            return serviceClientFormat;
        }

        #endregion

        #endregion

        private static int GetIntegerFromNullableIntgerValue(int? value)
        {
            return (value.HasValue ? (int)value : default(int));
        }
    }
}
