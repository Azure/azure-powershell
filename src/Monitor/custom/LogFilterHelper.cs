using Microsoft.Azure.PowerShell.Cmdlets.Monitor.custom;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.Cmdlets
{
    public static class LogFilterHelper
    {
        public static readonly TimeSpan DefaultQueryTimeRange = TimeSpan.FromDays(7);

        public static string GetFilterParameter(Dictionary<string, object> parameters)
        {
            string filterQuery = GetTimeFilterQuery(parameters);
            filterQuery = AddFilterConditionIfExists(parameters, filterQuery, "status");
            filterQuery = AddFilterConditionIfExists(parameters, filterQuery, "caller");
            filterQuery = AddFilterConditionIfExists(parameters, filterQuery, "correlationId");
            filterQuery = AddFilterConditionIfExists(parameters, filterQuery, "resourceGroupName");
            filterQuery = AddFilterConditionIfExists(parameters, filterQuery, "resourceId", "resourceUri");
            filterQuery = AddFilterConditionIfExists(parameters, filterQuery, "resourceProvider");
            // For the tenant level log filter only
            filterQuery = AddFilterConditionIfExists(parameters, filterQuery, "eventChannel", "eventChannels");
           
            return filterQuery;
        }

        private static string GetTimeFilterQuery(Dictionary<string, object> parameters)
        {
            // Time
            DateTime currentDateTime = DateTime.Now;

            // EndTime is optional
            object value;
            DateTime endDateTime = parameters.TryGetValue("EndTime", out value) ? (DateTime)value : currentDateTime.AddDays(1).Date;

            // StartTime is optional
            DateTime startDateTime = parameters.TryGetValue("StartTime", out value) ? (DateTime)value : endDateTime.Subtract(DefaultQueryTimeRange);

            // Check the value of startDateTime
            if (startDateTime > currentDateTime)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForLogFilterCmdlets.StartDateLaterThanNow, startDateTime, currentDateTime));
            }

            // Check that the dateTime range makes sense
            if (endDateTime < startDateTime)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForLogFilterCmdlets.EndDateEarlierThanStartDate, endDateTime, startDateTime));
            }

            return String.Format("eventTimestamp ge '{0:o}' and eventTimestamp le '{1:o}'", startDateTime.ToUniversalTime(), endDateTime.ToUniversalTime());
        }

        private static string AddConditions(string condition1, string condition2)
        {
            return condition1 + " and " + condition2;
        }

        private static string FormatCondition(string name, string value)
        {
            return name + " eq " + value;
        }

        private static string AddFilterConditionIfExists(Dictionary<string, object> parameters, string query, string parameter, string filterParameter = null)
        {
            if (filterParameter == null) filterParameter = parameter;
            if (parameters.ContainsKey(parameter)) {
                string newFormattedCondition = FormatCondition(filterParameter, (string)parameters[parameter]);
                if (!String.IsNullOrWhiteSpace(query)) {
                    return AddConditions(query, newFormattedCondition);
                } else {
                    return newFormattedCondition;
                }
            } else {
                return query;
            }
        }

    }
}