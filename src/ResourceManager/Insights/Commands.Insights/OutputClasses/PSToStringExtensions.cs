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
using System.Text;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Extensions to the ToString methods to allow for indentation to be added when displying the results
    /// </summary>
    public static class PSToStringExtensions
    {
        private const int DefaultIndentationTabs = 1;

        /// <summary>
        /// Add spaces into the string builder
        /// </summary>
        /// <param name="output">The string builder</param>
        /// <param name="indentationTabs">The number of tab chars to insert</param>
        /// <returns>The input string builder with the tabs appended</returns>
        public static StringBuilder AddSpacesInFront(this StringBuilder output, int indentationTabs)
        {
            for (int i = 0; i < indentationTabs; i++)
            {
                output.Append('\t');
            }

            return output;
        }

        #region Extensions for Alerts

        /// <summary>
        /// A string representation of the ScaleCapacity including indentation
        /// </summary>
        /// <param name="ruleEventDataSource">The RuleManagementEventDataSource object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the ScaleCapacity including indentation</returns>
        public static string ToString(this RuleManagementEventDataSource ruleEventDataSource, int indentationTabs)
        {
            //RuleManagementEventDataSource
            StringBuilder output = new StringBuilder();
            if (ruleEventDataSource != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("EventName             : " + ruleEventDataSource.EventName);
                output.AddSpacesInFront(indentationTabs).AppendLine("EventSource           : " + ruleEventDataSource.EventSource);
                output.AddSpacesInFront(indentationTabs).AppendLine("Level                 : " + ruleEventDataSource.Level);
                output.AddSpacesInFront(indentationTabs).AppendLine("OperationName         : " + ruleEventDataSource.OperationName);
                output.AddSpacesInFront(indentationTabs).AppendLine("ResourceGroupName     : " + ruleEventDataSource.ResourceGroupName);
                output.AddSpacesInFront(indentationTabs).AppendLine("ResourceProviderName  : " + ruleEventDataSource.ResourceProviderName);
                output.AddSpacesInFront(indentationTabs).AppendLine("ResourceUri           : " + ruleEventDataSource.ResourceUri);
                output.AddSpacesInFront(indentationTabs).AppendLine("Status                : " + ruleEventDataSource.Status);
                output.AddSpacesInFront(indentationTabs).AppendLine("SubStatus             : " + ruleEventDataSource.SubStatus);
                output.AddSpacesInFront(indentationTabs).Append("Claims                : " + ruleEventDataSource.Claims);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the ManagementEventAggregationCondition including indentation
        /// </summary>
        /// <param name="aggregatedCondition">The ManagementEventAggregationCondition object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the ManagementEventAggregationCondition including indentation</returns>
        public static string ToString(this ManagementEventAggregationCondition aggregatedCondition, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (aggregatedCondition != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Operator            : " + aggregatedCondition.Operator);
                output.AddSpacesInFront(indentationTabs).AppendLine("Threshold           : " + aggregatedCondition.Threshold);
                output.AddSpacesInFront(indentationTabs).Append("Window size         : " + aggregatedCondition.WindowSize);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the RuleMetricDataSource including indentation
        /// </summary>
        /// <param name="ruleMetricDataSource">The RuleMetricDataSource object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the RuleMetricDataSource including indentation</returns>
        public static string ToString(this RuleMetricDataSource ruleMetricDataSource, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (ruleMetricDataSource != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("MetricName  : " + ruleMetricDataSource.MetricName);
                output.AddSpacesInFront(indentationTabs).Append("ResourceUri : " + ruleMetricDataSource.ResourceUri);
            }

            return output.ToString();
        }

        #endregion

        #region Extensions for Autoscale

        /// <summary>
        /// A string representation of the ScaleCapacity including indentation
        /// </summary>
        /// <param name="scaleCapacity">The ScaleCapacity object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the ScaleCapacity including indentation</returns>
        public static string ToString(this ScaleCapacity scaleCapacity, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (scaleCapacity != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Default : " + scaleCapacity.Default);
                output.AddSpacesInFront(indentationTabs).AppendLine("Minimum : " + scaleCapacity.Maximum);
                output.AddSpacesInFront(indentationTabs).Append("Maximum : " + scaleCapacity.Minimum);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the ScaleAction including indentation
        /// </summary>
        /// <param name="scaleAction">The ScaleAction object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the ScaleAction including indentation</returns>
        public static string ToString(this ScaleAction scaleAction, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (scaleAction != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Cooldown  : " + scaleAction.Cooldown);
                output.AddSpacesInFront(indentationTabs).AppendLine("Direction : " + scaleAction.Direction);
                output.AddSpacesInFront(indentationTabs).AppendLine("Type      : " + scaleAction.Type);
                output.AddSpacesInFront(indentationTabs).Append("Value     : " + scaleAction.Value);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the MetricTrigger including indentation
        /// </summary>
        /// <param name="metricTrigger">The metricTrigger object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the MetricTrigger including indentation</returns>
        public static string ToString(this MetricTrigger metricTrigger, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (metricTrigger != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("MetricName        : " + metricTrigger.MetricName);
                output.AddSpacesInFront(indentationTabs).AppendLine("MetricResourceUri : " + metricTrigger.MetricResourceUri);
                output.AddSpacesInFront(indentationTabs).AppendLine("Operator          : " + metricTrigger.Operator);
                output.AddSpacesInFront(indentationTabs).AppendLine("Statistic         : " + metricTrigger.Statistic);
                output.AddSpacesInFront(indentationTabs).AppendLine("Threshold         : " + metricTrigger.Threshold);
                output.AddSpacesInFront(indentationTabs).AppendLine("TimeAggregation   : " + metricTrigger.TimeAggregation);
                output.AddSpacesInFront(indentationTabs).AppendLine("TimeGrain         : " + metricTrigger.TimeGrain);
                output.AddSpacesInFront(indentationTabs).Append("TimeWindow        : " + metricTrigger.TimeWindow);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the TimeWindow including indentation
        /// </summary>
        /// <param name="timeWindow">The TimeWindow object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the TimeWindow including indentation</returns>
        public static string ToString(this TimeWindow timeWindow, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (timeWindow != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Start    : " + timeWindow.Start.ToString("o"));
                output.AddSpacesInFront(indentationTabs).AppendLine("End      : " + timeWindow.End.ToString("o"));
                output.AddSpacesInFront(indentationTabs).Append("TimeZone : " + timeWindow.TimeZone);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the Recurrence including indentation
        /// </summary>
        /// <param name="recurrence">The Recurrence object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the Recurrence including indentation</returns>
        public static string ToString(this Recurrence recurrence, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (recurrence != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Frequency : " + recurrence.Frequency);
                output.AddSpacesInFront(indentationTabs).Append("Schedule  : " + recurrence.Schedule.ToString(indentationTabs + DefaultIndentationTabs));
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of ScaleRule objects including indentation
        /// </summary>
        /// <param name="scaleRules">The list of ScaleRule objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of ScaleRule objects including indentation</returns>
        public static string ToString(this IList<ScaleRule> scaleRules, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            scaleRules.ForEach(scaleRule => output.Append(scaleRule.ToString(indentationTabs)));

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the AutoscaleProfile object including indentation
        /// </summary>
        /// <param name="autoscaleProfile">The AutoscaleProfile object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the AutoscaleProfile object including indentation</returns>
        public static string ToString(this AutoscaleProfile autoscaleProfile, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (autoscaleProfile != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Name       : " + autoscaleProfile.Name);
                output.AddSpacesInFront(indentationTabs).AppendLine("Capacity   : " + autoscaleProfile.Capacity.ToString(indentationTabs + DefaultIndentationTabs));
                output.AddSpacesInFront(indentationTabs).AppendLine("FixedDate  : " + autoscaleProfile.FixedDate.ToString(indentationTabs + DefaultIndentationTabs));
                output.AddSpacesInFront(indentationTabs).AppendLine("Recurrence : " + autoscaleProfile.Recurrence.ToString(indentationTabs + DefaultIndentationTabs));
                output.AddSpacesInFront(indentationTabs).Append("Rules      : " + autoscaleProfile.Rules.ToString(indentationTabs + DefaultIndentationTabs));
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of AutoscaleProfile objects including indentation
        /// </summary>
        /// <param name="profiles">The list of AutoscaleProfile objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of AutoscaleProfile objects including indentation</returns>
        public static string ToString(this IList<AutoscaleProfile> profiles, int indentationTabs)
        {
            var output = new StringBuilder();
            profiles.ForEach(profile => output.Append(profile.ToString(indentationTabs)));

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the RecurrentSchedule including indentation
        /// </summary>
        /// <param name="recurrentSchedule">The RecurrentSchedule object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the RecurrentSchedule including indentation</returns>
        public static string ToString(this RecurrentSchedule recurrentSchedule, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (recurrentSchedule != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Days     : " + string.Join(",", recurrentSchedule.Days));
                output.AddSpacesInFront(indentationTabs).AppendLine("Hours    : " + string.Join(",", recurrentSchedule.Hours));
                output.AddSpacesInFront(indentationTabs).AppendLine("Minutes  : " + string.Join(",", recurrentSchedule.Minutes));
                output.AddSpacesInFront(indentationTabs).Append("Timezone : " + recurrentSchedule.TimeZone);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the ScaleRule including indentation
        /// </summary>
        /// <param name="scaleRule">The ScaleRule object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the ScaleRule including indentation</returns>
        public static string ToString(this ScaleRule scaleRule, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (scaleRule != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("MetricTrigger : " + scaleRule.MetricTrigger.ToString(indentationTabs + DefaultIndentationTabs));
                output.AddSpacesInFront(indentationTabs).Append("ScaleAction   : " + scaleRule.ScaleAction.ToString(indentationTabs + DefaultIndentationTabs));
            }

            return output.ToString();
        }

        #endregion
    }
}
