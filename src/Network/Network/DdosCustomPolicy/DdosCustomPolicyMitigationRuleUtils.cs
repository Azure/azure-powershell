// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    internal static class DdosCustomPolicyMitigationRuleUtils
    {
        internal static PSDdosCustomPolicyMitigationRule BuildRule(
            string name,
            string trafficScope,
            int? tcpPacketsPerSecond,
            int? tcpConnectionsPerSecond,
            int? udpPacketsPerSecond,
            IEnumerable<string> denyIpPrefixes,
            IEnumerable<string> denyGeoMatches,
            IEnumerable<string> permitIpPrefixes,
            IEnumerable<string> permitGeoMatches)
        {
            var rule = new PSDdosCustomPolicyMitigationRule
            {
                Name = name,
                Properties = new PSDdosCustomPolicyMitigationRuleProperties
                {
                    TrafficScope = trafficScope,
                    SourcePolicyOverrides = BuildSourcePolicyOverrides(
                        denyIpPrefixes,
                        denyGeoMatches,
                        permitIpPrefixes,
                        permitGeoMatches),
                },
            };

            if (tcpPacketsPerSecond.HasValue || tcpConnectionsPerSecond.HasValue)
            {
                rule.Properties.TcpDefaultMitigations = new PSDdosCustomPolicyTcpDefaultMitigations
                {
                    PerSourceRateLimiting = tcpPacketsPerSecond.HasValue
                        ? new PSDdosCustomPolicyTcpPerSourceRateLimitPolicy { PacketsPerSecond = tcpPacketsPerSecond.Value }
                        : null,
                    PerSourceConnectionRateLimiting = tcpConnectionsPerSecond.HasValue
                        ? new PSDdosCustomPolicyTcpPerSourceConnectionRateLimitPolicy { ConnectionsPerSecond = tcpConnectionsPerSecond.Value }
                        : null,
                };
            }

            if (udpPacketsPerSecond.HasValue)
            {
                rule.Properties.UdpDefaultMitigations = new PSDdosCustomPolicyUdpDefaultMitigations
                {
                    PerSourceRateLimiting = new PSDdosCustomPolicyUdpPerSourceRateLimitPolicy
                    {
                        PacketsPerSecond = udpPacketsPerSecond.Value,
                    },
                };
            }

            ValidateRule(rule);
            return rule;
        }

        internal static void ValidateRules(IList<PSDdosCustomPolicyMitigationRule> rules)
        {
            if (rules == null)
            {
                return;
            }

            var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var rule in rules)
            {
                ValidateRule(rule);
                if (!names.Add(rule.Name))
                {
                    throw new ArgumentException($"Duplicate mitigation rule name '{rule.Name}'.");
                }
            }
        }

        internal static void ValidateRule(PSDdosCustomPolicyMitigationRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentException("MitigationRule cannot contain null entries.");
            }

            if (string.IsNullOrWhiteSpace(rule.Name))
            {
                throw new ArgumentException("MitigationRule.Name is required.");
            }

            if (rule.Properties == null)
            {
                throw new ArgumentException("MitigationRule.Properties is required.");
            }

            var scope = rule.Properties.TrafficScope;
            if (string.IsNullOrWhiteSpace(scope))
            {
                throw new ArgumentException("MitigationRule.Properties.TrafficScope is required.");
            }

            var tcpPackets = rule.Properties.TcpDefaultMitigations?.PerSourceRateLimiting?.PacketsPerSecond;
            var tcpConnections = rule.Properties.TcpDefaultMitigations?.PerSourceConnectionRateLimiting?.ConnectionsPerSecond;
            var udpPackets = rule.Properties.UdpDefaultMitigations?.PerSourceRateLimiting?.PacketsPerSecond;

            if (udpPackets.HasValue
                && !string.Equals(scope, MNM.DdosMitigationTrafficScope.Udp, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("UdpPacketsPerSecond can only be used with a UDP mitigation rule.");
            }

            if ((tcpPackets.HasValue || tcpConnections.HasValue)
                && !string.Equals(scope, MNM.DdosMitigationTrafficScope.Tcp, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("TCP rate limits can only be used with a TCP mitigation rule.");
            }
        }

        internal static List<PSDdosCustomPolicySourcePolicyOverride> UpdateSourcePolicyOverrides(
            IList<PSDdosCustomPolicySourcePolicyOverride> existing,
            bool denyIpPrefixesBound,
            IEnumerable<string> denyIpPrefixes,
            bool denyGeoMatchesBound,
            IEnumerable<string> denyGeoMatches,
            bool permitIpPrefixesBound,
            IEnumerable<string> permitIpPrefixes,
            bool permitGeoMatchesBound,
            IEnumerable<string> permitGeoMatches)
        {
            var updateDeny = denyIpPrefixesBound || denyGeoMatchesBound;
            var updatePermit = permitIpPrefixesBound || permitGeoMatchesBound;
            var updated = existing?
                .Where(item =>
                    !(updateDeny && IsAction(item, MNM.DdosSourcePolicyActionType.Deny))
                    && !(updatePermit && IsAction(item, MNM.DdosSourcePolicyActionType.Permit)))
                .ToList()
                ?? new List<PSDdosCustomPolicySourcePolicyOverride>();

            if (updateDeny)
            {
                AddSourcePolicyOverride(
                    updated,
                    MNM.DdosSourcePolicyActionType.Deny,
                    denyIpPrefixesBound ? denyIpPrefixes : GetIpPrefixes(existing, MNM.DdosSourcePolicyActionType.Deny),
                    denyGeoMatchesBound ? denyGeoMatches : GetGeoMatches(existing, MNM.DdosSourcePolicyActionType.Deny));
            }

            if (updatePermit)
            {
                AddSourcePolicyOverride(
                    updated,
                    MNM.DdosSourcePolicyActionType.Permit,
                    permitIpPrefixesBound ? permitIpPrefixes : GetIpPrefixes(existing, MNM.DdosSourcePolicyActionType.Permit),
                    permitGeoMatchesBound ? permitGeoMatches : GetGeoMatches(existing, MNM.DdosSourcePolicyActionType.Permit));
            }

            return updated.Count == 0 ? null : updated;
        }

        internal static List<string> GetIpPrefixes(
            IEnumerable<PSDdosCustomPolicySourcePolicyOverride> overrides,
            string actionType)
        {
            return overrides?
                .Where(item => IsAction(item, actionType))
                .SelectMany(item => item.Conditions?.IpPrefixes ?? Enumerable.Empty<string>())
                .ToList()
                ?? new List<string>();
        }

        internal static List<string> GetGeoMatches(
            IEnumerable<PSDdosCustomPolicySourcePolicyOverride> overrides,
            string actionType)
        {
            return overrides?
                .Where(item => IsAction(item, actionType))
                .SelectMany(item => item.Conditions?.GeoMatches ?? Enumerable.Empty<PSDdosCustomPolicyGeoMatch>())
                .Select(FormatGeoMatch)
                .ToList()
                ?? new List<string>();
        }

        internal static MNM.DdosMitigationRule ToSdk(PSDdosCustomPolicyMitigationRule rule)
        {
            ValidateRule(rule);
            var properties = rule.Properties;
            return new MNM.DdosMitigationRule(
                rule.Name,
                new MNM.DdosMitigationRulePropertiesFormat(
                    properties.TrafficScope,
                    tcpDefaultMitigations: ToSdk(properties.TcpDefaultMitigations),
                    udpDefaultMitigations: ToSdk(properties.UdpDefaultMitigations),
                    sourcePolicyOverrides: properties.SourcePolicyOverrides?.Select(ToSdk).ToList()),
                rule.Id,
                rule.Etag,
                rule.Type);
        }

        internal static PSDdosCustomPolicyMitigationRule FromSdk(MNM.DdosMitigationRule rule)
        {
            if (rule == null)
            {
                return null;
            }

            return new PSDdosCustomPolicyMitigationRule
            {
                Id = rule.Id,
                Name = rule.Name,
                Etag = rule.Etag,
                Type = rule.Type,
                Properties = new PSDdosCustomPolicyMitigationRuleProperties
                {
                    ProvisioningState = rule.Properties?.ProvisioningState,
                    TrafficScope = rule.Properties?.TrafficScope,
                    TcpDefaultMitigations = FromSdk(rule.Properties?.TcpDefaultMitigations),
                    UdpDefaultMitigations = FromSdk(rule.Properties?.UdpDefaultMitigations),
                    SourcePolicyOverrides = rule.Properties?.SourcePolicyOverrides?.Select(FromSdk).ToList(),
                },
            };
        }

        private static MNM.DdosTcpDefaultMitigations ToSdk(PSDdosCustomPolicyTcpDefaultMitigations value)
        {
            return value == null
                ? null
                : new MNM.DdosTcpDefaultMitigations(
                    value.PerSourceRateLimiting == null ? null : new MNM.DdosTcpPerSourceRateLimitPolicy(value.PerSourceRateLimiting.PacketsPerSecond),
                    value.PerSourceConnectionRateLimiting == null ? null : new MNM.DdosTcpPerSourceConnectionRateLimitPolicy(value.PerSourceConnectionRateLimiting.ConnectionsPerSecond));
        }

        private static MNM.DdosUdpDefaultMitigations ToSdk(PSDdosCustomPolicyUdpDefaultMitigations value)
        {
            return value == null
                ? null
                : new MNM.DdosUdpDefaultMitigations(
                    value.PerSourceRateLimiting == null ? null : new MNM.DdosUdpPerSourceRateLimitPolicy(value.PerSourceRateLimiting.PacketsPerSecond));
        }

        private static MNM.DdosSourcePolicyOverride ToSdk(PSDdosCustomPolicySourcePolicyOverride value)
        {
            return new MNM.DdosSourcePolicyOverride(
                value.PolicyAction == null ? null : new MNM.DdosSourcePolicyAction(value.PolicyAction.ActionType),
                value.Conditions == null
                    ? null
                    : new MNM.DdosSourceMatchConditions(
                        value.Conditions.IpPrefixes,
                        value.Conditions.GeoMatches?.Select(item => new MNM.DdosGeoMatch(item?.Continent, item?.CountryCode)).ToList()));
        }

        private static PSDdosCustomPolicyTcpDefaultMitigations FromSdk(MNM.DdosTcpDefaultMitigations value)
        {
            return value == null
                ? null
                : new PSDdosCustomPolicyTcpDefaultMitigations
                {
                    PerSourceRateLimiting = value.PerSourceRateLimiting == null
                        ? null
                        : new PSDdosCustomPolicyTcpPerSourceRateLimitPolicy { PacketsPerSecond = value.PerSourceRateLimiting.PacketsPerSecond },
                    PerSourceConnectionRateLimiting = value.PerSourceConnectionRateLimiting == null
                        ? null
                        : new PSDdosCustomPolicyTcpPerSourceConnectionRateLimitPolicy { ConnectionsPerSecond = value.PerSourceConnectionRateLimiting.ConnectionsPerSecond },
                };
        }

        private static PSDdosCustomPolicyUdpDefaultMitigations FromSdk(MNM.DdosUdpDefaultMitigations value)
        {
            return value == null
                ? null
                : new PSDdosCustomPolicyUdpDefaultMitigations
                {
                    PerSourceRateLimiting = value.PerSourceRateLimiting == null
                        ? null
                        : new PSDdosCustomPolicyUdpPerSourceRateLimitPolicy { PacketsPerSecond = value.PerSourceRateLimiting.PacketsPerSecond },
                };
        }

        private static PSDdosCustomPolicySourcePolicyOverride FromSdk(MNM.DdosSourcePolicyOverride value)
        {
            return value == null
                ? null
                : new PSDdosCustomPolicySourcePolicyOverride
                {
                    PolicyAction = new PSDdosCustomPolicySourcePolicyAction
                    {
                        ActionType = value.PolicyAction?.ActionType,
                    },
                    Conditions = new PSDdosCustomPolicySourceMatchConditions
                    {
                        IpPrefixes = value.Conditions?.IPPrefixes?.ToList(),
                        GeoMatches = value.Conditions?.GeoMatches?.Select(item => new PSDdosCustomPolicyGeoMatch
                        {
                            Continent = item.Continent,
                            CountryCode = item.CountryCode,
                        }).ToList(),
                    },
                };
        }

        private static List<PSDdosCustomPolicySourcePolicyOverride> BuildSourcePolicyOverrides(
            IEnumerable<string> denyIpPrefixes,
            IEnumerable<string> denyGeoMatches,
            IEnumerable<string> permitIpPrefixes,
            IEnumerable<string> permitGeoMatches)
        {
            var overrides = new List<PSDdosCustomPolicySourcePolicyOverride>();
            AddSourcePolicyOverride(overrides, MNM.DdosSourcePolicyActionType.Deny, denyIpPrefixes, denyGeoMatches);
            AddSourcePolicyOverride(overrides, MNM.DdosSourcePolicyActionType.Permit, permitIpPrefixes, permitGeoMatches);
            return overrides.Count == 0 ? null : overrides;
        }

        private static void AddSourcePolicyOverride(
            ICollection<PSDdosCustomPolicySourcePolicyOverride> overrides,
            string actionType,
            IEnumerable<string> ipPrefixes,
            IEnumerable<string> geoMatches)
        {
            var prefixes = ipPrefixes?.ToList();
            var matches = geoMatches?.Select(ParseGeoMatch).ToList();
            if ((prefixes == null || prefixes.Count == 0) && (matches == null || matches.Count == 0))
            {
                return;
            }

            overrides.Add(new PSDdosCustomPolicySourcePolicyOverride
            {
                PolicyAction = new PSDdosCustomPolicySourcePolicyAction { ActionType = actionType },
                Conditions = new PSDdosCustomPolicySourceMatchConditions
                {
                    IpPrefixes = prefixes,
                    GeoMatches = matches,
                },
            });
        }

        private static PSDdosCustomPolicyGeoMatch ParseGeoMatch(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Geographic matches cannot contain null or empty entries.");
            }

            var parts = value.Split('.');
            if (parts.Length > 2 || parts.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException(
                    $"Geographic match '{value}' must use <Country>, <Continent>, or <Continent>.<Country> format.");
            }

            return parts.Length == 2
                ? new PSDdosCustomPolicyGeoMatch { Continent = parts[0], CountryCode = parts[1] }
                : parts[0].Length == 2
                    ? new PSDdosCustomPolicyGeoMatch { CountryCode = parts[0] }
                    : new PSDdosCustomPolicyGeoMatch { Continent = parts[0] };
        }

        private static string FormatGeoMatch(PSDdosCustomPolicyGeoMatch value)
        {
            if (value == null)
            {
                return null;
            }

            return !string.IsNullOrEmpty(value.Continent) && !string.IsNullOrEmpty(value.CountryCode)
                ? $"{value.Continent}.{value.CountryCode}"
                : value.CountryCode ?? value.Continent;
        }

        private static bool IsAction(PSDdosCustomPolicySourcePolicyOverride value, string actionType)
        {
            return string.Equals(value?.PolicyAction?.ActionType, actionType, StringComparison.OrdinalIgnoreCase);
        }
    }
}
