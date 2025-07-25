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

using Microsoft.Azure.Management.Monitor.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.TransitionalClasses
{
    static class TransitionHelpers
    {
        static public RuleAction ToMirrorNamespace(Management.Monitor.Management.Models.RuleAction ruleAction)
        {
            var emailAction = ruleAction as Management.Monitor.Management.Models.RuleEmailAction;
            if (emailAction != null)
            {
                return new RuleEmailAction(
                    sendToServiceOwners: emailAction.SendToServiceOwners,
                    customEmails: emailAction.CustomEmails);
            }
            else
            {
                var webhookAction = ruleAction as Management.Monitor.Management.Models.RuleWebhookAction;
                if (webhookAction != null)
                {
                    return new RuleWebhookAction(
                        serviceUri: webhookAction.ServiceUri,
                        properties: webhookAction.Properties);
                }

                return null;
            }
        }

        static public Management.Monitor.Management.Models.RuleAction ToMirrorNamespace(RuleAction ruleAction)
        {
            var ruleAction1 = ruleAction as RuleEmailAction;
            if (ruleAction1 != null)
            {
                return new Management.Monitor.Management.Models.RuleEmailAction(ruleEmailAction: ruleAction1);
            }
            else
            {
                var ruleAction2 = ruleAction as RuleWebhookAction;
                if (ruleAction2 != null)
                {
                    return new Management.Monitor.Management.Models.RuleWebhookAction(ruleWebhookAction: ruleAction2);
                }

                return null;
            }
        }

        static public RuleCondition ToMirrorNamespace(Management.Monitor.Management.Models.RuleCondition ruleCondition)
        {
            var thresholdCondition = ruleCondition as Management.Monitor.Management.Models.ThresholdRuleCondition;
            if (thresholdCondition != null)
            {
                return new ThresholdRuleCondition(
                    operatorProperty: ConvertNamespace(thresholdCondition.OperatorProperty),
                    threshold: thresholdCondition.Threshold,
                    dataSource: thresholdCondition.DataSource,
                    windowSize: thresholdCondition.WindowSize,
                    timeAggregation: ConvertNamespace(thresholdCondition.TimeAggregation));
            }
            else
            {
                var locationCondition = ruleCondition as Management.Monitor.Management.Models.LocationThresholdRuleCondition;
                if (locationCondition != null)
                {
                    return new LocationThresholdRuleCondition(
                        failedLocationCount: locationCondition.FailedLocationCount,
                        dataSource: locationCondition.DataSource,
                        windowSize: locationCondition.WindowSize);
                }

                return null;
            }
        }

        static public Management.Monitor.Management.Models.RuleCondition ToMirrorNamespace(RuleCondition ruleCondition)
        {
            var thresholdCondition = ruleCondition as ThresholdRuleCondition;
            if (thresholdCondition != null)
            {
                return new Management.Monitor.Management.Models.ThresholdRuleCondition
                {
                    OperatorProperty = ConvertNamespace(thresholdCondition.OperatorProperty),
                    Threshold = thresholdCondition.Threshold,
                    DataSource = ToMirrorNamespace(thresholdCondition.DataSource),
                    WindowSize = thresholdCondition.WindowSize,
                    TimeAggregation = ConvertNamespace(thresholdCondition.TimeAggregation)
                };
            }
            else
            {
                var locationCondition = ruleCondition as LocationThresholdRuleCondition;
                if (locationCondition != null)
                {
                    return new Management.Monitor.Management.Models.LocationThresholdRuleCondition
                    {
                        FailedLocationCount = locationCondition.FailedLocationCount,
                        DataSource = ToMirrorNamespace(locationCondition.DataSource),
                        WindowSize = locationCondition.WindowSize
                    };
                }

                return null;
            }
        }

        static public RuleDataSource ToMirrorNamespace(Management.Monitor.Management.Models.RuleDataSource ruleDataSource)
        {
            if (ruleDataSource == null)
            {
                return null;
            }

            var metricDataSource = ruleDataSource as Management.Monitor.Management.Models.RuleMetricDataSource;
            if (metricDataSource != null)
            {
                return new RuleMetricDataSource(
                    resourceUri: metricDataSource.ResourceUri,
                    metricName: metricDataSource.MetricName);
            }
            else
            {
                return new RuleDataSource()
                {
                    ResourceUri = ruleDataSource.ResourceUri
                };
            }
        }

        static public Management.Monitor.Management.Models.RuleDataSource ToMirrorNamespace(RuleDataSource ruleDataSource)
        {
            if (ruleDataSource == null)
            {
                return null;
            }

            var metricDataSource = ruleDataSource as RuleMetricDataSource;
            if (metricDataSource != null)
            {
                return new Management.Monitor.Management.Models.RuleMetricDataSource
                {
                    ResourceUri = metricDataSource.ResourceUri,
                    MetricName = metricDataSource.MetricName
                };
            }
            else
            {
                return new Management.Monitor.Management.Models.RuleDataSource
                {
                    ResourceUri = ruleDataSource.ResourceUri
                };
            }
        }


        static public TimeAggregationOperator? ConvertNamespace(Management.Monitor.Management.Models.TimeAggregationOperator? operatorType)
        {
            if (operatorType.HasValue)
            {
                int value = (int)operatorType;
                return (TimeAggregationOperator)value;
            }

            return null;
        }

        static public Management.Monitor.Management.Models.ReceiverStatus? ConvertNamespace(ReceiverStatus? operatorType)
        {
            if (operatorType.HasValue)
            {
                int value = (int)operatorType;
                return (Management.Monitor.Management.Models.ReceiverStatus)value;
            }

            return null;
        }

        static public ReceiverStatus? ConvertNamespace(Management.Monitor.Management.Models.ReceiverStatus? operatorType)
        {
            if (operatorType.HasValue)
            {
                int value = (int)operatorType;
                return (ReceiverStatus)value;
            }

            return null;
        }

        static public Management.Monitor.Management.Models.TimeAggregationOperator? ConvertNamespace(TimeAggregationOperator? operatorType)
        {
            if (operatorType.HasValue)
            {
                int value = (int)operatorType;
                return (Management.Monitor.Management.Models.TimeAggregationOperator)value;
            }

            return null;
        }

        static public ConditionOperator ConvertNamespace(Management.Monitor.Management.Models.ConditionOperator operatorType)
        {
            int value = (int)operatorType;
            return (ConditionOperator)value;
        }

        static public Management.Monitor.Management.Models.ConditionOperator ConvertNamespace(ConditionOperator operatorType)
        {
            int value = (int)operatorType;
            return (Management.Monitor.Management.Models.ConditionOperator)value;
        }

        static public ComparisonOperationType ConvertNamespace(Management.Monitor.Management.Models.ComparisonOperationType operatorType)
        {
            int value = (int)operatorType;
            return (ComparisonOperationType)value;
        }

        static public Management.Monitor.Management.Models.ComparisonOperationType ConvertNamespace(ComparisonOperationType operatorType)
        {
            int value = (int)operatorType;
            return (Management.Monitor.Management.Models.ComparisonOperationType)value;
        }

        static public MetricStatisticType ConvertNamespace(Management.Monitor.Management.Models.MetricStatisticType operatorType)
        {
            int value = (int)operatorType;
            return (MetricStatisticType)value;
        }

        static public Management.Monitor.Management.Models.MetricStatisticType ConvertNamespace(MetricStatisticType operatorType)
        {
            int value = (int)operatorType;
            return (Management.Monitor.Management.Models.MetricStatisticType)value;
        }

        static public TimeAggregationType ConvertNamespace(Management.Monitor.Management.Models.TimeAggregationType operatorType)
        {
            int value = (int)operatorType;
            return (TimeAggregationType)value;
        }

        static public Management.Monitor.Management.Models.TimeAggregationType ConvertNamespace(TimeAggregationType operatorType)
        {
            int value = (int)operatorType;
            return (Management.Monitor.Management.Models.TimeAggregationType)value;
        }

        static public ScaleDirection ConvertNamespace(Management.Monitor.Management.Models.ScaleDirection operatorType)
        {
            int value = (int)operatorType;
            return (ScaleDirection)value;
        }

        static public Management.Monitor.Management.Models.ScaleDirection ConvertNamespace(ScaleDirection operatorType)
        {
            int value = (int)operatorType;
            return (Management.Monitor.Management.Models.ScaleDirection)value;
        }

        static public ScaleType ConvertNamespace(Management.Monitor.Management.Models.ScaleType operatorType)
        {
            int value = (int)operatorType;
            return (ScaleType)value;
        }

        static public Management.Monitor.Management.Models.ScaleType ConvertNamespace(ScaleType operatorType)
        {
            int value = (int)operatorType;
            return (Management.Monitor.Management.Models.ScaleType)value;
        }

        static public RecurrentSchedule ConvertNamespace(Management.Monitor.Management.Models.RecurrentSchedule recurrentSchedule)
        {
            if (recurrentSchedule == null)
            {
                return null;
            }

            RecurrentSchedule schedule = new RecurrentSchedule(
                timeZone: recurrentSchedule?.TimeZone,
                days: recurrentSchedule?.Days,
                hours: recurrentSchedule?.Hours,
                minutes: recurrentSchedule?.Minutes);
            return schedule;
        }

        static public MetricTrigger ConvertNamespace(Management.Monitor.Management.Models.MetricTrigger metricTrigger)
        {
            if (metricTrigger == null)
            {
                return null;
            }

            MetricTrigger trigger = new MetricTrigger(
                metricName: metricTrigger.MetricName,
                metricResourceUri: metricTrigger.MetricResourceUri,
                timeGrain: metricTrigger.TimeGrain,
                statistic: ConvertNamespace(metricTrigger.Statistic),
                timeWindow: metricTrigger.TimeWindow,
                timeAggregation: ConvertNamespace(metricTrigger.TimeAggregation),
                operatorProperty: ConvertNamespace(metricTrigger.OperatorProperty),
                threshold: metricTrigger.Threshold);
            return trigger;
        }

        static public ScaleAction ConvertNamespace(Management.Monitor.Management.Models.ScaleAction scaleAction)
        {
            if (scaleAction == null)
            {
                return null;
            }

            ScaleAction action = new ScaleAction(
                direction: ConvertNamespace(scaleAction.Direction),
                type: ConvertNamespace(scaleAction.Type),
                cooldown: scaleAction.Cooldown,
                value: scaleAction.Value);
            return action;
        }

        static public ScaleRule ConvertNamespace(Management.Monitor.Management.Models.ScaleRule scaleRule)
        {
            if (scaleRule == null)
            {
                return null;
            }

            return new ScaleRule
            {
                MetricTrigger = ConvertNamespace(scaleRule.MetricTrigger),
                ScaleAction = ConvertNamespace(scaleRule.ScaleAction)
            };
        }

        static public ScaleCapacity ConvertNamespace(Management.Monitor.Management.Models.ScaleCapacity scaleCapacity)
        {
            if (scaleCapacity == null)
            {
                return null;
            }

            return new ScaleCapacity(minimum: scaleCapacity.Minimum, maximum: scaleCapacity.Maximum, defaultProperty: scaleCapacity.DefaultProperty);
        }

        static public Management.Monitor.Management.Models.ScaleCapacity ConvertNamespace(ScaleCapacity scaleCapacity)
        {
            if (scaleCapacity == null)
            {
                return null;
            }

            return new Management.Monitor.Management.Models.ScaleCapacity(scaleCapacity);
        }

        static public TimeWindow ConvertNamespace(Management.Monitor.Management.Models.TimeWindow timeWindow)
        {
            if (timeWindow == null)
            {
                return null;
            }

            return new TimeWindow(start: timeWindow.Start, end: timeWindow.End, timeZone: timeWindow.TimeZone);
        }

        static public Management.Monitor.Management.Models.TimeWindow ConvertNamespace(TimeWindow timeWindow)
        {
            if (timeWindow == null)
            {
                return null;
            }

            return new Management.Monitor.Management.Models.TimeWindow(timeWindow);
        }

        static public Recurrence ConvertNamespace(Management.Monitor.Management.Models.Recurrence recurrence)
        {
            if (recurrence == null)
            {
                return null;
            }

            return new Recurrence(frequency: ConvertNamespace(recurrence.Frequency), schedule: ConvertNamespace(recurrence.Schedule));
        }

        static public Management.Monitor.Management.Models.Recurrence ConvertNamespace(Recurrence recurrence)
        {
            if (recurrence == null)
            {
                return null;
            }

            return new Management.Monitor.Management.Models.Recurrence(recurrence);
        }

        static public RecurrenceFrequency ConvertNamespace(Management.Monitor.Management.Models.RecurrenceFrequency recurrenceFrequency)
        {
            int value = (int)recurrenceFrequency;
            return (RecurrenceFrequency)value;
        }

        static public Management.Monitor.Management.Models.RecurrenceFrequency ConvertNamespace(RecurrenceFrequency recurrenceFrequency)
        {
            int value = (int)recurrenceFrequency;
            return (Management.Monitor.Management.Models.RecurrenceFrequency)value;
        }

        static public Management.Monitor.Management.Models.AutoscaleSettingResource ConvertNamespace(AutoscaleSettingResource inputObject)
        {
            return new Management.Monitor.Management.Models.AutoscaleSettingResource(inputObject);
        }

        static public Management.Monitor.Management.Models.AutoscaleNotification ConvertNamespace(AutoscaleNotification inputObject)
        {
            return new Management.Monitor.Management.Models.AutoscaleNotification(inputObject);
        }

        static public AutoscaleNotification ConvertNamespace(Management.Monitor.Management.Models.AutoscaleNotification inputObject)
        {
            if (inputObject == null)
            {
                return null;
            }

            AutoscaleNotification notification = new AutoscaleNotification(
                email: inputObject.Email,
                webhooks: inputObject.Webhooks?.Select(e => e as WebhookNotification).ToList());
            return notification;
        }

        static public Management.Monitor.Management.Models.AutoscaleProfile ConvertNamespace(AutoscaleProfile inputObject)
        {
            return new Management.Monitor.Management.Models.AutoscaleProfile(inputObject);
        }

        static public AutoscaleProfile ConvertNamespace(Management.Monitor.Management.Models.AutoscaleProfile inputObject)
        {
            if (inputObject == null)
            {
                return null;
            }

            AutoscaleProfile profile = new AutoscaleProfile(
                name: inputObject.Name,
                capacity: ConvertNamespace(inputObject.Capacity),
                rules: inputObject.Rules?.Select(ConvertNamespace).ToList(),
                fixedDate: ConvertNamespace(inputObject.FixedDate),
                recurrence: ConvertNamespace(inputObject.Recurrence));
            return profile;
        }
    }
}
