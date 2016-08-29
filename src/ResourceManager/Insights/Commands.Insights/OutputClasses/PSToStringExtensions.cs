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

using Hyak.Common;
using Microsoft.Azure.Insights.Models;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Text;

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

        /// <summary>
        /// A string representation of the Dimension including indentation
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <param name="localizedValue">Flag to inidicate if the localized value must be printed or not</param>
        /// <returns>A string representation of the LocalizableString</returns>
        public static string ToString(this LocalizableString inputString, bool localizedValue)
        {
            return localizedValue ? inputString.LocalizedValue : inputString.Value;
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
                output.AddSpacesInFront(indentationTabs).AppendLine("Category              : " + ruleEventDataSource.EventSource);
                output.AddSpacesInFront(indentationTabs).AppendLine("Level                 : " + ruleEventDataSource.Level);
                output.AddSpacesInFront(indentationTabs).AppendLine("OperationName         : " + ruleEventDataSource.OperationName);
                output.AddSpacesInFront(indentationTabs).AppendLine("ResourceGroupName     : " + ruleEventDataSource.ResourceGroupName);
                output.AddSpacesInFront(indentationTabs).AppendLine("ResourceProviderName  : " + ruleEventDataSource.ResourceProviderName);
                output.AddSpacesInFront(indentationTabs).AppendLine("ResourceId            : " + ruleEventDataSource.ResourceUri);
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
                output.AddSpacesInFront(indentationTabs).AppendLine("MetricName : " + ruleMetricDataSource.MetricName);
                output.AddSpacesInFront(indentationTabs).Append("ResourceId : " + ruleMetricDataSource.ResourceUri);
            }

            return output.ToString();
        }


        /// <summary>
        /// A string representation of the RuleMetricDataSource including indentation
        /// </summary>
        /// <param name="actions">The RuleAction objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of RuleAction objects including indentation</returns>
        public static string ToString(this IList<RuleAction> actions, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    output.AppendLine();
                    RuleEmailAction eMailAction = action as RuleEmailAction;
                    if (eMailAction != null)
                    {
                        output.AddSpacesInFront(indentationTabs).AppendLine("SendToServiceOwners : " + eMailAction.SendToServiceOwners);
                        output.AddSpacesInFront(indentationTabs).Append("E-mails             : " + eMailAction.CustomEmails.ToString(indentationTabs: indentationTabs + 1));
                    }
                    else
                    {
                        RuleWebhookAction webhookAction = action as RuleWebhookAction;
                        if (webhookAction != null)
                        {
                            output.AddSpacesInFront(indentationTabs).AppendLine("ServiceUri : " + webhookAction.ServiceUri);
                            output.AddSpacesInFront(indentationTabs).Append("Properties : " + webhookAction.Properties.ToString(indentationTabs: indentationTabs + 1));
                        }
                        else
                        {
                            output.AddSpacesInFront(indentationTabs).AppendLine(string.Format("Unsupported rule type <{0}>", action));
                        }
                    }
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of string including indentation
        /// </summary>
        /// <param name="strings">The list of string objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of string objects including indentation</returns>
        public static string ToString(this IList<string> strings, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AddSpacesInFront(indentationTabs).Append(string.Join(",", strings));
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
                output.AddSpacesInFront(indentationTabs).AppendLine("Minimum : " + scaleCapacity.Minimum);
                output.AddSpacesInFront(indentationTabs).Append("Maximum : " + scaleCapacity.Maximum);
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
                output.AddSpacesInFront(indentationTabs).AppendLine("MetricName       : " + metricTrigger.MetricName);
                output.AddSpacesInFront(indentationTabs).AppendLine("MetricResourceId : " + metricTrigger.MetricResourceUri);
                output.AddSpacesInFront(indentationTabs).AppendLine("Operator         : " + metricTrigger.Operator);
                output.AddSpacesInFront(indentationTabs).AppendLine("Statistic        : " + metricTrigger.Statistic);
                output.AddSpacesInFront(indentationTabs).AppendLine("Threshold        : " + metricTrigger.Threshold);
                output.AddSpacesInFront(indentationTabs).AppendLine("TimeAggregation  : " + metricTrigger.TimeAggregation);
                output.AddSpacesInFront(indentationTabs).AppendLine("TimeGrain        : " + metricTrigger.TimeGrain);
                output.AddSpacesInFront(indentationTabs).Append("TimeWindow       : " + metricTrigger.TimeWindow);
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
        /// A string representation of the list of WebhookNotification objects including indentation
        /// </summary>
        /// <param name="webhookNotifications">The list of WebhookNotification objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of WebhookNotification objects including indentation</returns>
        public static string ToString(this IList<WebhookNotification> webhookNotifications, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            webhookNotifications.ForEach(webhookNotification => output.Append(webhookNotification.ToString(indentationTabs)));

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
        /// A string representation of the AutoscaleProfile object including indentation
        /// </summary>
        /// <param name="autoscaleNotification">The AutoscaleProfile object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the AutoscaleProfile object including indentation</returns>
        public static string ToString(this AutoscaleNotification autoscaleNotification, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (autoscaleNotification != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("E-mail     : " + autoscaleNotification.Email);
                output.AddSpacesInFront(indentationTabs).AppendLine("Operation  : " + autoscaleNotification.Operation);
                output.AddSpacesInFront(indentationTabs).Append("Webhooks   : " + autoscaleNotification.Webhooks.ToString(indentationTabs + DefaultIndentationTabs));
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
        /// A string representation of the list of AutoscaleNotification objects including indentation
        /// </summary>
        /// <param name="notifications">The list of AutoscaleNotification objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of AutoscaleNotification objects including indentation</returns>
        public static string ToString(this IList<AutoscaleNotification> notifications, int indentationTabs)
        {
            var output = new StringBuilder();
            notifications.ForEach(notification => output.Append(notification.ToString(indentationTabs)));

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

        /// <summary>
        /// A string representation of the WebhookNotification including indentation
        /// </summary>
        /// <param name="webhookNotification">The WebhookNotification object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the WebhookNotification including indentation</returns>
        public static string ToString(this WebhookNotification webhookNotification, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (webhookNotification != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("ServiceUri : " + webhookNotification.ServiceUri);
                output.AddSpacesInFront(indentationTabs).Append("Properties : " + webhookNotification.Properties.ToString(indentationTabs + DefaultIndentationTabs));
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of AutoscaleNotification objects including indentation
        /// </summary>
        /// <param name="dictionary">The 'string, string' dictionary object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the 'string, string' dictionary object including indentation</returns>
        public static string ToString(this IDictionary<string, string> dictionary, int indentationTabs)
        {
            var output = new StringBuilder();
            dictionary.ForEach(notification => output.AddSpacesInFront(indentationTabs).AppendLine(string.Format("{0}: {1}", notification.Key, notification.Value)));

            return output.ToString();
        }

        #endregion

        #region Extensions for Metrics

        /// <summary>
        /// A string representation of the PSMetricValue
        /// </summary>
        /// <param name="metricValue">A PSMetricValue object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the PSMetricValue</returns>
        public static string ToString(this PSMetricValue metricValue, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AddSpacesInFront(indentationTabs).AppendLine("Average    : " + metricValue.Average);
            output.AddSpacesInFront(indentationTabs).AppendLine("Count      : " + metricValue.Count);
            output.AddSpacesInFront(indentationTabs).AppendLine("Last       : " + metricValue.Last);
            output.AddSpacesInFront(indentationTabs).AppendLine("Maximum    : " + metricValue.Maximum);
            output.AddSpacesInFront(indentationTabs).AppendLine("Minimum    : " + metricValue.Minimum);
            output.AddSpacesInFront(indentationTabs).AppendLine("Properties : " + metricValue.Properties.ToString(indentationTabs: indentationTabs + 1));
            output.AddSpacesInFront(indentationTabs).AppendLine("Timestamp  : " + metricValue.Timestamp);
            output.AddSpacesInFront(indentationTabs).Append("Total      : " + metricValue.Total);
            return output.ToString();
        }


        /// <summary>
        /// A string representation of the list of PSMetricValue objects including indentation
        /// </summary>
        /// <param name="metricValues">The list of PSMetricValue objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of PSMetricValue objects including indentation</returns>
        public static string ToString(this IList<PSMetricValue> metricValues, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            metricValues.ForEach(value => output.Append(value.ToString(indentationTabs)));

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of Dimension objects including indentation
        /// </summary>
        /// <param name="metricDimensions">The list of Dimension objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of Dimension objects including indentation</returns>
        public static string ToString(this IList<Dimension> metricDimensions, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            metricDimensions.ForEach(dimension => output.Append(dimension.ToString(indentationTabs)));

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the Dimension including indentation
        /// </summary>
        /// <param name="metricDimension">The Dimension object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the Dimension including indentation</returns>
        public static string ToString(this Dimension metricDimension, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (metricDimension != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Name   : " + metricDimension.Name.ToString(localizedValue: false));
                output.AddSpacesInFront(indentationTabs).Append("Values : " + metricDimension.Values);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of MetricAvailability objects including indentation
        /// </summary>
        /// <param name="metricAvailabilities">The list of MetricAvailability objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of MetricAvailability objects including indentation</returns>
        public static string ToString(this IList<MetricAvailability> metricAvailabilities, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            metricAvailabilities.ForEach(availability => output.Append(availability.ToString(indentationTabs)));

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the MetricAvailability including indentation
        /// </summary>
        /// <param name="metricAvailability">The MetricAvailability object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the MetricAvailability including indentation</returns>
        public static string ToString(this MetricAvailability metricAvailability, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (metricAvailability != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Location  : " + metricAvailability.Location.ToString(indentationTabs: indentationTabs + 1));
                output.AddSpacesInFront(indentationTabs).AppendLine("Retention : " + metricAvailability.Retention);
                output.AddSpacesInFront(indentationTabs).Append("Values    : " + metricAvailability.TimeGrain);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the MetricLocation including indentation
        /// </summary>
        /// <param name="metricLocation">The MetricLocation object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the MetricLocation including indentation</returns>
        public static string ToString(this MetricLocation metricLocation, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (metricLocation != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Table endpoint : " + metricLocation.TableEndpoint);
                output.AddSpacesInFront(indentationTabs).AppendLine("Table info     : " + metricLocation.TableInfo);
                output.AddSpacesInFront(indentationTabs).Append("PartitionKey   : " + metricLocation.PartitionKey);
            }

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the list of MetricTableInfo objects including indentation
        /// </summary>
        /// <param name="metricTableInfos">The list of MetricTableInfo objects</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the list of MetricTableInfo objects including indentation</returns>
        public static string ToString(this LazyList<MetricTableInfo> metricTableInfos, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            metricTableInfos.ForEach(metricTableInfo => output.Append(metricTableInfo.ToString(indentationTabs)));

            return output.ToString();
        }

        /// <summary>
        /// A string representation of the MetricTableInfo including indentation
        /// </summary>
        /// <param name="metricTableInfo">The MetricTableInfo object</param>
        /// <param name="indentationTabs">The number of tabs to insert in front of each member</param>
        /// <returns>A string representation of the MetricTableInfo including indentation</returns>
        public static string ToString(this MetricTableInfo metricTableInfo, int indentationTabs)
        {
            StringBuilder output = new StringBuilder();
            if (metricTableInfo != null)
            {
                output.AppendLine();
                output.AddSpacesInFront(indentationTabs).AppendLine("Table name                 : " + metricTableInfo.TableName);
                output.AddSpacesInFront(indentationTabs).AppendLine("Table sas token            : " + metricTableInfo.SasToken);
                output.AddSpacesInFront(indentationTabs).AppendLine("Table sas token expiration : " + metricTableInfo.SasTokenExpirationTime.ToUniversalTime().ToString("O"));
                output.AddSpacesInFront(indentationTabs).AppendLine("Start time                 : " + metricTableInfo.StartTime.ToUniversalTime().ToString("O"));
                output.AddSpacesInFront(indentationTabs).Append("End time                   : " + metricTableInfo.EndTime.ToUniversalTime().ToString("O"));
            }

            return output.ToString();
        }

        #endregion 
    }
}
