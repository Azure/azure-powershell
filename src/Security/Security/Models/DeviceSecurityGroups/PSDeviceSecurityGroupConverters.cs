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
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups
{
    public static class PSDeviceSecurityGroupConverters
    {
        public static PSDeviceSecurityGroup ConvertToPSType(this DeviceSecurityGroup value)
        {
            return new PSDeviceSecurityGroup()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                AllowlistRules = value.AllowlistRules?.ConvertToPSType(),
                DenylistRules = value.DenylistRules?.ConvertToPSType(),
                ThresholdRules = value.ThresholdRules?.ConvertToPSType(),
                TimeWindowRules = value.TimeWindowRules?.ConvertToPSType()
            };
        }

        public static IList<PSDeviceSecurityGroup> ConvertToPSType(this IEnumerable<DeviceSecurityGroup> value)
        {
            return value.Select(group => group.ConvertToPSType()).ToList();
        }

        public static PSAllowlistCustomAlertRule ConvertToPSType(this AllowlistCustomAlertRule value)
        {
            return new PSAllowlistCustomAlertRule()
            {
                AllowlistValues = value.AllowlistValues,
                Description = value.Description,
                DisplayName = value.DisplayName,
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType,
                ValueType = value.ValueType
            };
        }

        public static IList<PSAllowlistCustomAlertRule> ConvertToPSType(this IEnumerable<AllowlistCustomAlertRule> value)
        {
            return value.Select(rule => rule.ConvertToPSType()).ToList();
        }

        public static PSDenylistCustomAlertRule ConvertToPSType(this DenylistCustomAlertRule value)
        {
            return new PSDenylistCustomAlertRule()
            {
                Description = value.Description,
                DisplayName = value.DisplayName,
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType,
                ValueType = value.ValueType,
                DenylistValues = value.DenylistValues
            };
        }

        public static IList<PSDenylistCustomAlertRule> ConvertToPSType(this IEnumerable<DenylistCustomAlertRule> value)
        {
            return value.Select(rule => rule.ConvertToPSType()).ToList();
        }

        public static PSThresholdCustomAlertRule ConvertToPSType(this ThresholdCustomAlertRule value)
        {
            return new PSThresholdCustomAlertRule()
            {
                Description = value.Description,
                DisplayName = value.DisplayName,
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType,
                MaxThreshold = value.MaxThreshold,
                MinThreshold = value.MinThreshold
            };
        }

        public static IList<PSThresholdCustomAlertRule> ConvertToPSType(this IEnumerable<ThresholdCustomAlertRule> value)
        {
            return value.Select(rule => rule.ConvertToPSType()).ToList();
        }

        public static PSTimeWindowCustomAlertRule ConvertToPSType(this TimeWindowCustomAlertRule value)
        {
            return new PSTimeWindowCustomAlertRule()
            {
                Description = value.Description,
                DisplayName = value.DisplayName,
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType,
                MaxThreshold = value.MaxThreshold,
                MinThreshold = value.MinThreshold,
                TimeWindowSize = value.TimeWindowSize
            };
        }

        public static IList<PSTimeWindowCustomAlertRule> ConvertToPSType(this IEnumerable<TimeWindowCustomAlertRule> value)
        {
            return value.Select(rule => rule.ConvertToPSType()).ToList();
        }

        //Convert FROM Powershell type

        public static AllowlistCustomAlertRule CreatePSType(this PSAllowlistCustomAlertRule value)
        {
            return new AllowlistCustomAlertRule()
            {
                AllowlistValues = value.AllowlistValues,
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType
            };
        }

        public static IList<AllowlistCustomAlertRule> CreatePSType(this IEnumerable<PSAllowlistCustomAlertRule> value)
        {
            return value.Select(rule => rule.CreatePSType()).ToList();
        }

        public static DenylistCustomAlertRule CreatePSType(this PSDenylistCustomAlertRule value)
        {
            return new DenylistCustomAlertRule()
            {
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType,
                DenylistValues = value.DenylistValues
            };
        }

        public static IList<DenylistCustomAlertRule> CreatePSType(this IEnumerable<PSDenylistCustomAlertRule> value)
        {
            return value.Select(rule => rule.CreatePSType()).ToList();
        }

        public static ThresholdCustomAlertRule CreatePSType(this PSThresholdCustomAlertRule value)
        {
            return new ThresholdCustomAlertRule()
            {
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType,
                MaxThreshold = value.MaxThreshold,
                MinThreshold = value.MinThreshold
            };
        }

        public static IList<ThresholdCustomAlertRule> CreatePSType(this IEnumerable<PSThresholdCustomAlertRule> value)
        {
            return value.Select(rule => rule.CreatePSType()).ToList();
        }

        public static TimeWindowCustomAlertRule CreatePSType(this PSTimeWindowCustomAlertRule value)
        {
            return new TimeWindowCustomAlertRule()
            {
                IsEnabled = value.IsEnabled,
                RuleType = value.RuleType,
                MaxThreshold = value.MaxThreshold,
                MinThreshold = value.MinThreshold,
                TimeWindowSize = value.TimeWindowSize
            };
        }

        public static IList<TimeWindowCustomAlertRule> CreatePSType(this IEnumerable<PSTimeWindowCustomAlertRule> value)
        {
            return value.Select(rule => rule.CreatePSType()).ToList();
        }
    }
}
