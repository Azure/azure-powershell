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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal static class Tools
    {
        private static readonly string filterParameterSeperator = " and ";

        private static readonly string filterParameterConditionEqual = " eq ";

        public static TSettings ToSettingsObject<TCmdlet, TSettings>(TCmdlet cmd, out string confirmString) where TSettings : new()
        {
            List<string> updatedSettingStrings = new List<string>();
            TSettings ret = new TSettings();
            foreach (PropertyInfo propertyInfo in typeof(TCmdlet).GetProperties().Where(_ => _.GetCustomAttributes(typeof(SettingFieldAttribute)).Any()))
            {
                var settingValue = propertyInfo.GetValue(cmd);
                if (settingValue != null)
                {
                    PropertyInfo propertyInfoInSettings = typeof(TSettings).GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfoInSettings == null)
                    {
                        throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Setting key '{0}' is not valid.", propertyInfo.Name));
                    }
                    propertyInfoInSettings.SetValue(ret, settingValue);
                    updatedSettingStrings.Add(Resources.SetServiceSettingParameter.FormatInvariantCulture(propertyInfo.Name, settingValue));
                }
            }
            confirmString = string.Join("", updatedSettingStrings);
            return ret;
        }

        public static string GenerateFilter(string[] metricNames)
        {
            string filter = string.Empty;

            if (metricNames != null && metricNames.Any())
            {
                List<string> conditions = metricNames.Select(_ => ("name.value eq '" + _ + "'")).ToList();

                if (conditions.Count > 1)
                {
                    filter = conditions.Aggregate((a, b) => a + " or " + b);
                }
                else if (conditions.Count == 1)
                {
                    filter = conditions[0];
                }
            }

            return filter;
        }

        public static string GenerateFilter(string[] metricNames, DateTime startTime, DateTime endTime,
            TimeGrain timeGrain = TimeGrain.Daily)
        {
            List<string> filters = new List<string>();

            if (metricNames != null && metricNames.Any())
            {
                List<string> conditions = metricNames.Select(_ => ("name.value eq '" + _ + "'")).ToList();

                if (conditions.Count > 1)
                {
                    string nameFilter = conditions.Aggregate((a, b) => a + " or " + b);
                    nameFilter = "(" + nameFilter + ")";
                    filters.Add(nameFilter);
                }
                else if (conditions.Count == 1)
                {
                    filters.Add(conditions[0]);
                }
            }
            string startTimeFilter = string.Format(CultureInfo.InvariantCulture, "startTime eq '{0:O}'", startTime.ToUniversalTime());

            filters.Add(startTimeFilter);

            string endTimeFilter = string.Format(CultureInfo.InvariantCulture, "endTime eq '{0:O}'", endTime.ToUniversalTime());

            filters.Add(endTimeFilter);

            string timeGrainFilter;

            switch (timeGrain)
            {
                case TimeGrain.Hourly:
                    timeGrainFilter = XmlConvert.ToString(TimeSpan.FromHours(1));
                    break;
                case TimeGrain.Minutely:
                    timeGrainFilter = XmlConvert.ToString(TimeSpan.FromMinutes(1));
                    break;
                default:
                    timeGrainFilter = XmlConvert.ToString(TimeSpan.FromDays(1));
                    break;
            }

            timeGrainFilter = string.Format(CultureInfo.InvariantCulture, "timeGrain eq '{0}'", timeGrainFilter);

            filters.Add(timeGrainFilter);

            string filter = filters.Aggregate((a, b) => a + " and " + b);

            return filter;
        }

        public static string GenerateStorageAccountsSearchFilter(List<KeyValuePair<StorageAccountSearchFilterParameter, string>> filters)
        {
            string ret = string.Empty;
            for (int i = 0; i < filters.Count; i++)
            {
                if (i != 0)
                    ret += filterParameterSeperator;
                ret += filters[i].Key.ToString();
                ret += filterParameterConditionEqual;
                ret += "'";
                ret += filters[i].Value;
                ret += "'";
            }
            return ret;
        }
    }
}
