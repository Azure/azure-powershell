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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.WindowsAzure.Commands.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    internal static class InteractiveSubscriptionSelectionHelper
    {
        private static string DefaultSubscriptionMark = $"{PSStyle.ForegroundColor.White}*{PSStyle.Reset}";

        internal static void SelectSubscriptionFromList(IEnumerable<IAzureSubscription> subscriptions, List<AzureTenant> queriedTenants, string tenantId, string tenantName, IAzureSubscription lastUsedSubscription,
            Func<string, string> prompt, Action<string> outputAction,
            ref IAzureSubscription defaultSubscription, ref IAzureTenant defaultTenant)
        {
            subscriptions = subscriptions?.OrderBy(s => GetDetailedTenantFromQueryHistory(queriedTenants, s.GetProperty(AzureSubscription.Property.Tenants)))?.ThenBy(s => s.Name)?.ToList();

            var markDefaultSubscription = lastUsedSubscription != null;
            int columnNoWidth = 4, columnSubNameWidth = 36, columnSubIdWidth = 40, columnTenantWidth = 26, columnIdentsWidth = 4;

            WriteSubscriptionSelectionTable(subscriptions, queriedTenants,
                outputAction, columnNoWidth, columnSubNameWidth, columnSubIdWidth, columnTenantWidth, columnIdentsWidth,
                lastUsedSubscription?.Id, markDefaultSubscription, tenantName);

            if (markDefaultSubscription)
            {
                outputAction($"{Environment.NewLine}The default is marked with an {DefaultSubscriptionMark}; " +
                    $"the default tenant is '{GetDetailedTenantFromQueryHistory(queriedTenants, lastUsedSubscription?.GetProperty(AzureSubscription.Property.Tenants))?.GetProperty(AzureTenant.Property.DisplayName)}' " +
                    $"and subscription is '{lastUsedSubscription?.Name} ({lastUsedSubscription?.Id})'.");
            }

            string input = markDefaultSubscription ? prompt($"{Environment.NewLine}{Resources.SelectTenantAndSubscriptionWithDefaultValue}") : prompt($"{Environment.NewLine}{Resources.SelectTenantAndSubscription}");
            int selectedSubIndex = -1;
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    selectedSubIndex = Convert.ToInt32(input);
                }
                if (selectedSubIndex != -1)
                {
                    defaultSubscription = subscriptions.ElementAt(selectedSubIndex - 1);
                }
                else if (selectedSubIndex == -1 && lastUsedSubscription != null)
                {
                    defaultSubscription = lastUsedSubscription;
                }
                else if (selectedSubIndex == -1 && lastUsedSubscription == null)
                {
                    throw new AzPSException(Resources.PleaseSelectSubscription, ErrorKind.UserError);
                }
                defaultTenant = GetDetailedTenantFromQueryHistory(queriedTenants, defaultSubscription?.GetProperty(AzureSubscription.Property.Tenants)) ?? new AzureTenant { Id = tenantId };
                if (!string.IsNullOrEmpty(tenantName))
                {
                    defaultTenant.ExtendedProperties.Add(AzureTenant.Property.DisplayName, tenantName);
                }
                WriteSelectedSubscriptionTable(defaultSubscription?.Name ?? defaultSubscription?.Id, 
                    defaultTenant?.GetProperty(AzureTenant.Property.DisplayName) ?? tenantName ?? defaultTenant?.Id,
                    outputAction, columnSubNameWidth, columnTenantWidth, columnIdentsWidth);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new AzPSException(Resources.SelectedSubscriptionOutOfRange, ErrorKind.UserError);
            }
            catch (FormatException)
            {
                throw new AzPSException(Resources.TypedSubscriptionNotNumber, ErrorKind.UserError);
            }
        }


        private static void WriteSubscriptionSelectionTable(IEnumerable<IAzureSubscription> subscriptions, IEnumerable<IAzureTenant> tenants,
            Action<string> outputAction, int columnNoWidth, int columnSubNameWidth, int columnSubIdWidth, int columnTenantWidth, int columnIdentsWidth,
            string defaultSubscriptionId, bool markDefaultSubscription = false, string tenantIdOrName = "")
        {
            WriteSubscriptionSelectionTableHeader(outputAction, columnNoWidth, columnSubNameWidth, columnSubIdWidth, columnTenantWidth, columnIdentsWidth);
            int subCount = 0;
            foreach (var subscription in subscriptions)
            {
                WriteSubscriptionSelectionTableRow(++subCount, subscription,
                    tenants?.Where(t => t.Id.Equals(subscription?.GetTenant()))?.FirstOrDefault()?.GetProperty(AzureTenant.Property.DisplayName) ?? tenantIdOrName,
                    outputAction, columnNoWidth, columnSubNameWidth, columnSubIdWidth, columnTenantWidth, columnIdentsWidth,
                    subscription.Id.Equals(defaultSubscriptionId), markDefaultSubscription);
            }
        }

        private static void WriteSubscriptionSelectionTableHeader(Action<string> outputAction, int columnNoWidth, int columnSubNameWidth, int columnSubIdWidth, int columnTenantWidth, int columnIdentsWidth)
        {
            string ColumnNoTab = "No", ColumnSubNameTab = "Subscription name", ColumnSubIdTab = "Subscription ID", ColumnTenantTab = "Tenant name";
            string separator = "-",
                ColumNoSeparator = new StringBuilder().Insert(0, separator, columnNoWidth).ToString(),
                ColumSubNameSeparator = new StringBuilder().Insert(0, separator, columnSubNameWidth).ToString(),
                ColumSubIdSeparator = new StringBuilder().Insert(0, separator, columnSubIdWidth).ToString(),
                ColumTenantSeparator = new StringBuilder().Insert(0, separator, columnTenantWidth).ToString();

            outputAction($"{Resources.TenantAndSubscriptionSelection}{Environment.NewLine}");
            outputAction($"{String.Format($"{{0,-{columnNoWidth + columnIdentsWidth}}}", ColumnNoTab)}" +
                $"{String.Format($"{{0,-{columnSubNameWidth + columnIdentsWidth}}}", ColumnSubNameTab)}" +
                $"{String.Format($"{{0,-{columnSubIdWidth + columnIdentsWidth}}}", ColumnSubIdTab)}" +
                $"{String.Format($"{{0,-{columnTenantWidth + columnIdentsWidth}}}", ColumnTenantTab)}");
            outputAction($"{String.Format($"{{0,-{columnNoWidth + columnIdentsWidth}}}", ColumNoSeparator)}" +
                $"{String.Format($"{{0,-{columnSubNameWidth + columnIdentsWidth}}}", ColumSubNameSeparator)}" +
                $"{String.Format($"{{0,-{columnSubIdWidth + columnIdentsWidth}}}", ColumSubIdSeparator)}" +
                $"{String.Format($"{{0,-{columnTenantWidth}}}", ColumTenantSeparator)}");
        }

        private static void WriteSubscriptionSelectionTableRow(int subIndex, IAzureSubscription subscription, string tenantName, Action<string> outputAction, int columnNoWidth, int columnSubNameWidth, int columnSubIdWidth, int columnTenantWidth, int columnIdentsWidth, bool isDefaultSubscription, bool needMarkDefaultSubscription = false)
        {
            bool markDefaultSubscription = isDefaultSubscription && needMarkDefaultSubscription;
            int markedIndexLength = markDefaultSubscription ? columnNoWidth + columnIdentsWidth - 1 + DefaultSubscriptionMark.Length : columnNoWidth + columnIdentsWidth;
            string markedSubIndex = $"[{subIndex}]{(markDefaultSubscription ? $" {DefaultSubscriptionMark} ": "")}";
            string truncatedSubName = subscription.Name?.Length > columnSubNameWidth ? $"{subscription.Name.Substring(0, columnSubNameWidth - 3)}..." : subscription.Name;
            string truncatedTenantName = tenantName?.Length > columnTenantWidth ? $"{tenantName.Substring(0, columnTenantWidth - 3)}..." : tenantName;
            string subIndexRowValue = String.Format($"{{0,-{markedIndexLength}}}", markedSubIndex),
                subNameRowValue = String.Format($"{{0,-{columnSubNameWidth + columnIdentsWidth}}}", truncatedSubName),
                subIdRowValue = String.Format($"{{0,-{columnSubIdWidth + columnIdentsWidth}}}", subscription.Id),
                tenantNameRowValue = String.Format($"{{0,-{columnTenantWidth}}}", truncatedTenantName);

            if (markDefaultSubscription)
            {
                outputAction($"{PSStyle.Bold}{subIndexRowValue}{PSStyle.BoldOff}{PSStyle.ForegroundColor.BrightCyan}{subNameRowValue}{subIdRowValue}{tenantNameRowValue}{PSStyle.Reset}");
            }
            else
            {
                outputAction($"{subIndexRowValue}{subNameRowValue}{subIdRowValue}{tenantNameRowValue}");
            }

        }

        private static void WriteSelectedSubscriptionTable(string subscription, string tenant,
            Action<string> outputAction, int columnSubNameWidth, int columnTenantWidth, int columnIdentsWidth)
        {
            string columnSubNameTab = "Subscription name", columnTenantTab = "Tenant name";
            string separator = "-",
                ColumSubNameSeparator = new StringBuilder().Insert(0, separator, columnSubNameWidth).ToString(),
                ColumTenantSeparator = new StringBuilder().Insert(0, separator, columnTenantWidth).ToString();

            outputAction("");
            outputAction($"{String.Format($"{{0,-{columnSubNameWidth + columnIdentsWidth}}}", columnSubNameTab)}" +
                $"{String.Format($"{{0,-{columnTenantWidth + columnIdentsWidth}}}", columnTenantTab)}");
            outputAction($"{String.Format($"{{0,-{columnSubNameWidth + columnIdentsWidth}}}", ColumSubNameSeparator)}" +
                $"{String.Format($"{{0,-{columnTenantWidth}}}", ColumTenantSeparator)}");
            string truncatedSubName = subscription?.Length > columnSubNameWidth ? $"{subscription.Substring(0, columnSubNameWidth - 3)}..." : subscription;
            string truncatedTenantName = tenant?.Length > columnTenantWidth ? $"{tenant.Substring(0, columnTenantWidth - 3)}..." : tenant;
            string subNameRowValue = String.Format($"{{0,-{columnSubNameWidth + columnIdentsWidth}}}", truncatedSubName),
                tenantDomainNameRowValue = String.Format($"{{0,-{columnTenantWidth}}}", truncatedTenantName);
            outputAction($"{subNameRowValue}{tenantDomainNameRowValue}");
        }

        public static IAzureTenant GetDetailedTenantFromQueryHistory(List<AzureTenant> queriedTenants, string tenantId)
        {
            return queriedTenants?.Where(t => t.Id.Equals(tenantId))?.FirstOrDefault();
        }

    }
}
