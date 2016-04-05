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
using HydraModels = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public partial class PolicyHelpers
    {
        #region HydraToPSObject conversions

        #region public
        public static AzureRmRecoveryServicesLongTermRetentionPolicy GetPSLongTermRetentionPolicy(
            HydraModels.LongTermRetentionPolicy hydraRetPolicy)
        {
            if(hydraRetPolicy == null)
            {
                return null;
            }

            AzureRmRecoveryServicesLongTermRetentionPolicy ltrPolicy = new AzureRmRecoveryServicesLongTermRetentionPolicy();

            if(hydraRetPolicy.DailySchedule != null)
            {
                ltrPolicy.IsDailyScheduleEnabled = true;
                ltrPolicy.DailySchedule = GetPSLTRDailySchedule(hydraRetPolicy.DailySchedule);
            }

            if (hydraRetPolicy.WeeklySchedule != null)
            {
                ltrPolicy.IsWeeklyScheduleEnabled = true;
                ltrPolicy.WeeklySchedule = GetPSLTRWeeklySchedule(hydraRetPolicy.WeeklySchedule);
            }

            if (hydraRetPolicy.MonthlySchedule != null)
            {
                ltrPolicy.IsMonthlyScheduleEnabled = true;
                ltrPolicy.MonthlySchedule = GetPSLTRMonthlySchedule(hydraRetPolicy.MonthlySchedule);
            }

            if (hydraRetPolicy.YearlySchedule != null)
            {
                ltrPolicy.IsYearlyScheduleEnabled = true;
                ltrPolicy.YearlySchedule = GetPSLTRYearlySchedule(hydraRetPolicy.YearlySchedule);
            }

            // safe side validate
            ltrPolicy.Validate();

            return ltrPolicy;            
        }

        public static AzureRmRecoveryServicesLongTermRetentionPolicy GetPSSimpleRetentionPolicy(
           HydraModels.SimpleRetentionPolicy hydraRetPolicy)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region private

        private static int GetRetentionDurationInDays(HydraModels.RetentionDuration retentionDuration)
        {
            int daysCount = 0;

            switch (retentionDuration.DurationType)
            {
                case HydraModels.RetentionDurationType.Days:
                    daysCount = retentionDuration.Count;
                    break;

                case HydraModels.RetentionDurationType.Weeks:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInWeek;
                    break;

                case HydraModels.RetentionDurationType.Months:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInMonth;
                    break;

                case HydraModels.RetentionDurationType.Years:
                    daysCount = retentionDuration.Count * PolicyConstants.NumOfDaysInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return daysCount;
        }

        private static int GetRetentionDurationInWeeks(HydraModels.RetentionDuration retentionDuration)
        {
            int weeksCount = 0;

            switch (retentionDuration.DurationType)
            {
                case HydraModels.RetentionDurationType.Days:
                    weeksCount = retentionDuration.Count / PolicyConstants.NumOfDaysInWeek;
                    break;

                case HydraModels.RetentionDurationType.Weeks:
                    weeksCount = retentionDuration.Count;
                    break;

                case HydraModels.RetentionDurationType.Months:
                    weeksCount = retentionDuration.Count * PolicyConstants.NumOfWeeksInMonth;
                    break;

                case HydraModels.RetentionDurationType.Years:
                    weeksCount = retentionDuration.Count * PolicyConstants.NumOfWeeksInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return weeksCount;
        }

        private static int GetRetentionDurationInMonths(HydraModels.RetentionDuration retentionDuration)
        {
            int monthsCount = 0;

            switch (retentionDuration.DurationType)
            {
                case HydraModels.RetentionDurationType.Days:
                    monthsCount = retentionDuration.Count / PolicyConstants.NumOfDaysInMonth;
                    break;

                case HydraModels.RetentionDurationType.Weeks:
                    monthsCount = retentionDuration.Count / PolicyConstants.NumOfWeeksInMonth;
                    break;

                case HydraModels.RetentionDurationType.Months:
                    monthsCount = retentionDuration.Count;
                    break;

                case HydraModels.RetentionDurationType.Years:
                    monthsCount = retentionDuration.Count * PolicyConstants.NumOfMonthsInYear;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return monthsCount;
        }

        private static int GetRetentionDurationInYears(HydraModels.RetentionDuration retentionDuration)
        {
            int yearsCount = 0;

            switch (retentionDuration.DurationType)
            {
                case HydraModels.RetentionDurationType.Days:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfDaysInYear;
                    break;

                case HydraModels.RetentionDurationType.Weeks:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfWeeksInYear;
                    break;

                case HydraModels.RetentionDurationType.Months:
                    yearsCount = retentionDuration.Count / PolicyConstants.NumOfMonthsInYear;
                    break;

                case HydraModels.RetentionDurationType.Years:
                    yearsCount = retentionDuration.Count;
                    break;

                default:
                    throw new ArgumentException(Resources.InvalidDurationTypeException,
                                                retentionDuration.DurationType.ToString());
            }

            return yearsCount;
        }       

        private static DailyRetentionSchedule GetPSLTRDailySchedule(HydraModels.DailyRetentionSchedule hydraDaily)
        {
            if(hydraDaily == null)
            {
                return null;
            }

            DailyRetentionSchedule psDaily = new DailyRetentionSchedule();

            psDaily.DurationCountInDays = GetRetentionDurationInDays(hydraDaily.RetentionDuration);
            psDaily.RetentionTimes = ParseDateTimesToUTC(hydraDaily.RetentionTimes);

            return psDaily;
        }

        private static WeeklyRetentionSchedule GetPSLTRWeeklySchedule(HydraModels.WeeklyRetentionSchedule hydraWeekly)
        {
            if (hydraWeekly == null)
            {
                return null;
            }

            WeeklyRetentionSchedule psWeekly = new WeeklyRetentionSchedule();

            psWeekly.DurationCountInWeeks = GetRetentionDurationInWeeks(hydraWeekly.RetentionDuration);
            psWeekly.RetentionTimes = ParseDateTimesToUTC(hydraWeekly.RetentionTimes);
            psWeekly.DaysOfTheWeek = HelperUtils.GetEnumListFromStringList<DayOfWeek>(hydraWeekly.DaysOfTheWeek);

            return psWeekly;
        }

        private static MonthlyRetentionSchedule GetPSLTRMonthlySchedule(HydraModels.MonthlyRetentionSchedule hydraMonthly)
        {
            if (hydraMonthly == null)
            {
                return null;
            }

            MonthlyRetentionSchedule psMonthly = new MonthlyRetentionSchedule();

            psMonthly.DurationCountInMonths = GetRetentionDurationInMonths(hydraMonthly.RetentionDuration);
            psMonthly.RetentionTimes = ParseDateTimesToUTC(hydraMonthly.RetentionTimes);
            psMonthly.RetentionScheduleFormatType = (RetentionScheduleFormat)Enum.Parse(typeof(RetentionScheduleFormat),
                                                                                   hydraMonthly.RetentionScheduleFormatType);
            psMonthly.RetentionScheduleDaily = GetPSLTRDailyRetentionFormat(hydraMonthly.RetentionScheduleDaily);
            psMonthly.RetentionScheduleWeekly = GetPSLTRWeeklyRetentionFormat(hydraMonthly.RetentionScheduleWeekly);

            return psMonthly;
        }

        private static YearlyRetentionSchedule GetPSLTRYearlySchedule(HydraModels.YearlyRetentionSchedule hydraYearly)
        {
            if (hydraYearly == null)
            {
                return null;
            }

            YearlyRetentionSchedule psYearly = new YearlyRetentionSchedule();

            psYearly.DurationCountInYears = GetRetentionDurationInYears(hydraYearly.RetentionDuration);
            psYearly.RetentionTimes = ParseDateTimesToUTC(hydraYearly.RetentionTimes);
            psYearly.RetentionScheduleFormatType = (RetentionScheduleFormat)Enum.Parse(typeof(RetentionScheduleFormat),
                                                                                   hydraYearly.RetentionScheduleFormatType);
            psYearly.RetentionScheduleDaily = GetPSLTRDailyRetentionFormat(hydraYearly.RetentionScheduleDaily);
            psYearly.RetentionScheduleWeekly = GetPSLTRWeeklyRetentionFormat(hydraYearly.RetentionScheduleWeekly);
            psYearly.MonthsOfYear = HelperUtils.GetEnumListFromStringList<Month>(hydraYearly.MonthsOfYear);

            return psYearly;
        }

        private static DailyRetentionFormat GetPSLTRDailyRetentionFormat(
                                            HydraModels.DailyRetentionFormat hydraFormat)
        {
            if (hydraFormat == null)
            {
                return null;
            }

            DailyRetentionFormat psFormat = new DailyRetentionFormat();

            if (hydraFormat.DaysOfTheMonth != null)
            {
                psFormat.DaysOfTheMonth = new List<Day>();

                foreach (HydraModels.Day hydraDay in hydraFormat.DaysOfTheMonth)
                {
                    Day psDay = new Day()
                    {
                        Date = hydraDay.Date,
                        IsLast = hydraDay.IsLast
                    };

                    psFormat.DaysOfTheMonth.Add(psDay);
                }
            }

            return psFormat;
        }

        private static WeeklyRetentionFormat GetPSLTRWeeklyRetentionFormat(
                                             HydraModels.WeeklyRetentionFormat hydraFormat)
        {
            if (hydraFormat == null)
            {
                return null;
            }

            WeeklyRetentionFormat psFormat = new WeeklyRetentionFormat();
            if (hydraFormat.DaysOfTheWeek != null)
            {
                psFormat.DaysOfTheWeek = HelperUtils.GetEnumListFromStringList<DayOfWeek>(hydraFormat.DaysOfTheWeek);
            }
            if (hydraFormat.WeeksOfTheMonth != null)
            {
                psFormat.WeeksOfTheMonth = HelperUtils.GetEnumListFromStringList<WeekOfMonth>(hydraFormat.WeeksOfTheMonth);
            }

            return psFormat;
        }

        #endregion

        #endregion

        #region PStoHydraObject conversions
        public static HydraModels.LongTermRetentionPolicy GetHydraLongTermRetentionPolicy(
            AzureRmRecoveryServicesLongTermRetentionPolicy psRetPolicy)
        {
            if(psRetPolicy == null)
            {
                return null;
            }

            HydraModels.LongTermRetentionPolicy hydraRetPolicy = new HydraModels.LongTermRetentionPolicy();

            if(psRetPolicy.IsDailyScheduleEnabled)
            {
                hydraRetPolicy.DailySchedule = GetHydraLTRDailySchedule(psRetPolicy.DailySchedule);
            }

            if (psRetPolicy.IsWeeklyScheduleEnabled)
            {
                hydraRetPolicy.WeeklySchedule = GetHydraLTRWeeklySchedule(psRetPolicy.WeeklySchedule);
            }

            if (psRetPolicy.IsMonthlyScheduleEnabled)
            {
                hydraRetPolicy.MonthlySchedule = GetHydraLTRMonthlySchedule(psRetPolicy.MonthlySchedule);
            }

            if (psRetPolicy.IsYearlyScheduleEnabled)
            {
                hydraRetPolicy.YearlySchedule = GetHydraLTRYearlySchedule(psRetPolicy.YearlySchedule);
            }            
                        
            return hydraRetPolicy;
        }

        public static HydraModels.SimpleRetentionPolicy GetHydraSimpleRetentionPolicy(
            AzureRmRecoveryServicesSimpleSchedulePolicy psRetPolicy)
        {
            throw new NotSupportedException();
        }

        #region private
        private static HydraModels.DailyRetentionSchedule GetHydraLTRDailySchedule(DailyRetentionSchedule psDaily)
        {
            if (psDaily == null)
            {
                return null;
            }

            HydraModels.DailyRetentionSchedule hydraDaily = new HydraModels.DailyRetentionSchedule();

            hydraDaily.RetentionDuration = new HydraModels.RetentionDuration()
            {
                Count = psDaily.DurationCountInDays,
                DurationType = HydraModels.RetentionDurationType.Days
            };

            hydraDaily.RetentionTimes = psDaily.RetentionTimes;

            return hydraDaily;
        }

        private static HydraModels.WeeklyRetentionSchedule GetHydraLTRWeeklySchedule(WeeklyRetentionSchedule psWeekly)
        {
            if (psWeekly == null)
            {
                return null;
            }

            HydraModels.WeeklyRetentionSchedule hydraWeekly = new HydraModels.WeeklyRetentionSchedule();

            hydraWeekly.RetentionDuration = new HydraModels.RetentionDuration()
            {
                Count = psWeekly.DurationCountInWeeks,
                DurationType = HydraModels.RetentionDurationType.Weeks
            };
            hydraWeekly.RetentionTimes = psWeekly.RetentionTimes;
            hydraWeekly.DaysOfTheWeek = HelperUtils.GetStringListFromEnumList<DayOfWeek>(psWeekly.DaysOfTheWeek);

            return hydraWeekly;
        }

        private static HydraModels.MonthlyRetentionSchedule GetHydraLTRMonthlySchedule(MonthlyRetentionSchedule psMonthly)
        {
            if (psMonthly == null)
            {
                return null;
            }

            HydraModels.MonthlyRetentionSchedule hydraMonthly = new HydraModels.MonthlyRetentionSchedule();

            hydraMonthly.RetentionDuration = new HydraModels.RetentionDuration()
            {
                Count = psMonthly.DurationCountInMonths,
                DurationType = HydraModels.RetentionDurationType.Months
            };
            hydraMonthly.RetentionTimes = psMonthly.RetentionTimes;

            hydraMonthly.RetentionScheduleFormatType = psMonthly.RetentionScheduleFormatType.ToString();
            if (psMonthly.RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
            {
                hydraMonthly.RetentionScheduleDaily = GetHydraLTRDailyRetentionFormat(psMonthly.RetentionScheduleDaily);
            }
            else if (psMonthly.RetentionScheduleFormatType == RetentionScheduleFormat.Weekly)
            {
                hydraMonthly.RetentionScheduleWeekly = GetHydraLTRWeeklyRetentionFormat(psMonthly.RetentionScheduleWeekly);
            }

            return hydraMonthly;
        }

        private static HydraModels.YearlyRetentionSchedule GetHydraLTRYearlySchedule(YearlyRetentionSchedule psYearly)
        {
            if (psYearly == null)
            {
                return null;
            }

            HydraModels.YearlyRetentionSchedule hydraYearly = new HydraModels.YearlyRetentionSchedule();

            hydraYearly.RetentionDuration = new HydraModels.RetentionDuration()
            {
                Count = psYearly.DurationCountInYears,
                DurationType = HydraModels.RetentionDurationType.Years
            };
            hydraYearly.RetentionTimes = psYearly.RetentionTimes;

            hydraYearly.RetentionScheduleFormatType = psYearly.RetentionScheduleFormatType.ToString();
            if (psYearly.RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
            {
                hydraYearly.RetentionScheduleDaily = GetHydraLTRDailyRetentionFormat(psYearly.RetentionScheduleDaily);
            }
            else if (psYearly.RetentionScheduleFormatType == RetentionScheduleFormat.Weekly)
            {
                hydraYearly.RetentionScheduleWeekly = GetHydraLTRWeeklyRetentionFormat(psYearly.RetentionScheduleWeekly);
            }
            hydraYearly.MonthsOfYear = HelperUtils.GetStringListFromEnumList<Month>(psYearly.MonthsOfYear);

            return hydraYearly;
        }

        private static HydraModels.DailyRetentionFormat GetHydraLTRDailyRetentionFormat(
                                             DailyRetentionFormat psFormat)
        {
            if (psFormat == null)
            {
                return null;
            }

            HydraModels.DailyRetentionFormat hydraFormat = new HydraModels.DailyRetentionFormat();

            if (psFormat.DaysOfTheMonth != null)
            {
                hydraFormat.DaysOfTheMonth = new List<HydraModels.Day>();

                foreach (Day psDay in psFormat.DaysOfTheMonth)
                {
                    HydraModels.Day hydraDay = new HydraModels.Day()
                    {
                        Date =  psDay.Date,
                        IsLast = psDay.IsLast
                    };

                    hydraFormat.DaysOfTheMonth.Add(hydraDay);
                }
            }

            return hydraFormat;
        }

        private static HydraModels.WeeklyRetentionFormat GetHydraLTRWeeklyRetentionFormat(
                                              WeeklyRetentionFormat psFormat)
        {
            if (psFormat == null)
            {
                return null;
            }

            HydraModels.WeeklyRetentionFormat hydraFormat = new HydraModels.WeeklyRetentionFormat();
            if (psFormat.DaysOfTheWeek != null)
            {
                hydraFormat.DaysOfTheWeek = HelperUtils.GetStringListFromEnumList<DayOfWeek>(psFormat.DaysOfTheWeek);
            }
            if (psFormat.WeeksOfTheMonth != null)
            {
                hydraFormat.WeeksOfTheMonth = HelperUtils.GetStringListFromEnumList<WeekOfMonth>(psFormat.WeeksOfTheMonth);
            }

            return hydraFormat;
        }        

        #endregion

        #endregion
    }
}
