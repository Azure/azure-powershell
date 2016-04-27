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
using ServiceClientModels = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public partial class PolicyHelpers
    {
        #region ServiceClientToPSObject conversions

        #region public
        public static AzureRmRecoveryServicesBackupLongTermRetentionPolicy GetPSLongTermRetentionPolicy(
            ServiceClientModels.LongTermRetentionPolicy serviceClientRetPolicy)
        {
            if(serviceClientRetPolicy == null)
            {
                return null;
            }

            AzureRmRecoveryServicesBackupLongTermRetentionPolicy ltrPolicy = new AzureRmRecoveryServicesBackupLongTermRetentionPolicy();

            if(serviceClientRetPolicy.DailySchedule != null)
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

        public static AzureRmRecoveryServicesBackupLongTermRetentionPolicy GetPSSimpleRetentionPolicy(
           ServiceClientModels.SimpleRetentionPolicy serviceClientRetPolicy)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region private

        private static int GetRetentionDurationInDays(ServiceClientModels.RetentionDuration retentionDuration)
        {
            int daysCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModels.RetentionDurationType.Days:
                    daysCount = retentionDuration.Count;
                    break;

                case ServiceClientModels.RetentionDurationType.Weeks:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInWeek;
                    break;

                case ServiceClientModels.RetentionDurationType.Months:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInMonth;
                    break;

                case ServiceClientModels.RetentionDurationType.Years:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return daysCount;
        }

        private static int GetRetentionDurationInWeeks(ServiceClientModels.RetentionDuration retentionDuration)
        {
            int weeksCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModels.RetentionDurationType.Days:
                    weeksCount = retentionDuration.Count / PolicyConstants.NumOfDaysInWeek;
                    break;

                case ServiceClientModels.RetentionDurationType.Weeks:
                    weeksCount = retentionDuration.Count;
                    break;

                case ServiceClientModels.RetentionDurationType.Months:
                    weeksCount = retentionDuration.Count * PolicyConstants.NumOfWeeksInMonth;
                    break;

                case ServiceClientModels.RetentionDurationType.Years:
                    weeksCount = retentionDuration.Count * PolicyConstants.NumOfWeeksInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return weeksCount;
        }

        private static int GetRetentionDurationInMonths(ServiceClientModels.RetentionDuration retentionDuration)
        {
            int monthsCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModels.RetentionDurationType.Days:
                    monthsCount = retentionDuration.Count / PolicyConstants.NumOfDaysInMonth;
                    break;

                case ServiceClientModels.RetentionDurationType.Weeks:
                    monthsCount = retentionDuration.Count / PolicyConstants.NumOfWeeksInMonth;
                    break;

                case ServiceClientModels.RetentionDurationType.Months:
                    monthsCount = retentionDuration.Count;
                    break;

                case ServiceClientModels.RetentionDurationType.Years:
                    monthsCount = retentionDuration.Count * PolicyConstants.NumOfMonthsInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return monthsCount;
        }

        private static int GetRetentionDurationInYears(ServiceClientModels.RetentionDuration retentionDuration)
        {
            int yearsCount = 0;

            switch (retentionDuration.DurationType)
            {
                case ServiceClientModels.RetentionDurationType.Days:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfDaysInYear;
                    break;

                case ServiceClientModels.RetentionDurationType.Weeks:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfWeeksInYear;
                    break;

                case ServiceClientModels.RetentionDurationType.Months:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfMonthsInYear;
                    break;

                case ServiceClientModels.RetentionDurationType.Years:
                    yearsCount = retentionDuration.Count;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return yearsCount;
        }       

        private static DailyRetentionSchedule GetPSLTRDailySchedule(ServiceClientModels.DailyRetentionSchedule serviceClientDaily)
        {
            if(serviceClientDaily == null)
            {
                return null;
            }

            DailyRetentionSchedule psDaily = new DailyRetentionSchedule();

            psDaily.DurationCountInDays = GetRetentionDurationInDays(serviceClientDaily.RetentionDuration);
            psDaily.RetentionTimes = ParseDateTimesToUTC(serviceClientDaily.RetentionTimes);

            return psDaily;
        }

        private static WeeklyRetentionSchedule GetPSLTRWeeklySchedule(ServiceClientModels.WeeklyRetentionSchedule serviceClientWeekly)
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

        private static MonthlyRetentionSchedule GetPSLTRMonthlySchedule(ServiceClientModels.MonthlyRetentionSchedule serviceClientMonthly)
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

        private static YearlyRetentionSchedule GetPSLTRYearlySchedule(ServiceClientModels.YearlyRetentionSchedule serviceClientYearly)
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
                                            ServiceClientModels.DailyRetentionFormat serviceClientFormat)
        {
            if (serviceClientFormat == null)
            {
                return null;
            }

            DailyRetentionFormat psFormat = new DailyRetentionFormat();

            if (serviceClientFormat.DaysOfTheMonth != null)
            {
                psFormat.DaysOfTheMonth = new List<Day>();

                foreach (ServiceClientModels.Day serviceClientDay in serviceClientFormat.DaysOfTheMonth)
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
                                             ServiceClientModels.WeeklyRetentionFormat serviceClientFormat)
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
        public static ServiceClientModels.LongTermRetentionPolicy GetServiceClientLongTermRetentionPolicy(
            AzureRmRecoveryServicesBackupLongTermRetentionPolicy psRetPolicy)
        {
            if(psRetPolicy == null)
            {
                return null;
            }

            ServiceClientModels.LongTermRetentionPolicy serviceClientRetPolicy = new ServiceClientModels.LongTermRetentionPolicy();

            if(psRetPolicy.IsDailyScheduleEnabled)
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

        public static ServiceClientModels.SimpleRetentionPolicy GetServiceClientSimpleRetentionPolicy(
            AzureRmRecoveryServicesBackupSimpleSchedulePolicy psRetPolicy)
        {
            throw new NotSupportedException();
        }

        #region private
        private static ServiceClientModels.DailyRetentionSchedule GetServiceClientLTRDailySchedule(DailyRetentionSchedule psDaily)
        {
            if (psDaily == null)
            {
                return null;
            }

            ServiceClientModels.DailyRetentionSchedule serviceClientDaily = new ServiceClientModels.DailyRetentionSchedule();

            serviceClientDaily.RetentionDuration = new ServiceClientModels.RetentionDuration()
            {
                Count = psDaily.DurationCountInDays,
                DurationType = ServiceClientModels.RetentionDurationType.Days
            };

            serviceClientDaily.RetentionTimes = psDaily.RetentionTimes;

            return serviceClientDaily;
        }

        private static ServiceClientModels.WeeklyRetentionSchedule GetServiceClientLTRWeeklySchedule(WeeklyRetentionSchedule psWeekly)
        {
            if (psWeekly == null)
            {
                return null;
            }

            ServiceClientModels.WeeklyRetentionSchedule serviceClientWeekly = new ServiceClientModels.WeeklyRetentionSchedule();

            serviceClientWeekly.RetentionDuration = new ServiceClientModels.RetentionDuration()
            {
                Count = psWeekly.DurationCountInWeeks,
                DurationType = ServiceClientModels.RetentionDurationType.Weeks
            };
            serviceClientWeekly.RetentionTimes = psWeekly.RetentionTimes;
            serviceClientWeekly.DaysOfTheWeek = HelperUtils.GetStringListFromEnumList<DayOfWeek>(psWeekly.DaysOfTheWeek);

            return serviceClientWeekly;
        }

        private static ServiceClientModels.MonthlyRetentionSchedule GetServiceClientLTRMonthlySchedule(MonthlyRetentionSchedule psMonthly)
        {
            if (psMonthly == null)
            {
                return null;
            }

            ServiceClientModels.MonthlyRetentionSchedule serviceClientMonthly = new ServiceClientModels.MonthlyRetentionSchedule();

            serviceClientMonthly.RetentionDuration = new ServiceClientModels.RetentionDuration()
            {
                Count = psMonthly.DurationCountInMonths,
                DurationType = ServiceClientModels.RetentionDurationType.Months
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

        private static ServiceClientModels.YearlyRetentionSchedule GetServiceClientLTRYearlySchedule(YearlyRetentionSchedule psYearly)
        {
            if (psYearly == null)
            {
                return null;
            }

            ServiceClientModels.YearlyRetentionSchedule serviceClientYearly = new ServiceClientModels.YearlyRetentionSchedule();

            serviceClientYearly.RetentionDuration = new ServiceClientModels.RetentionDuration()
            {
                Count = psYearly.DurationCountInYears,
                DurationType = ServiceClientModels.RetentionDurationType.Years
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

        private static ServiceClientModels.DailyRetentionFormat GetServiceClientLTRDailyRetentionFormat(
                                             DailyRetentionFormat psFormat)
        {
            if (psFormat == null)
            {
                return null;
            }

            ServiceClientModels.DailyRetentionFormat serviceClientFormat = new ServiceClientModels.DailyRetentionFormat();

            if (psFormat.DaysOfTheMonth != null)
            {
                serviceClientFormat.DaysOfTheMonth = new List<ServiceClientModels.Day>();

                foreach (Day psDay in psFormat.DaysOfTheMonth)
                {
                    ServiceClientModels.Day serviceClientDay = new ServiceClientModels.Day()
                    {
                        Date =  psDay.Date,
                        IsLast = psDay.IsLast
                    };

                    serviceClientFormat.DaysOfTheMonth.Add(serviceClientDay);
                }
            }

            return serviceClientFormat;
        }

        private static ServiceClientModels.WeeklyRetentionFormat GetServiceClientLTRWeeklyRetentionFormat(
                                              WeeklyRetentionFormat psFormat)
        {
            if (psFormat == null)
            {
                return null;
            }

            ServiceClientModels.WeeklyRetentionFormat serviceClientFormat = new ServiceClientModels.WeeklyRetentionFormat();
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
