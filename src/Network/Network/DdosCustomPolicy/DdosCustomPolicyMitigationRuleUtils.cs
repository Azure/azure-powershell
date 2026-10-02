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
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    internal static class DdosCustomPolicyMitigationRuleUtils
    {
        private static readonly Regex CountryCodePattern = new Regex("^[A-Z]{2}$", RegexOptions.CultureInvariant);

        internal static PSDdosCustomPolicyMitigationRule BuildRule(
            string name,
            string trafficScope,
            int? tcpPacketsPerSecond,
            int? tcpConnectionsPerSecond,
            int? udpPacketsPerSecond,
            IEnumerable<PSDdosCustomPolicySourcePolicyOverride> sourcePolicyOverrides)
        {
            var rule = new PSDdosCustomPolicyMitigationRule
            {
                Name = name,
                Properties = new PSDdosCustomPolicyMitigationRuleProperties
                {
                    TrafficScope = trafficScope,
                    SourcePolicyOverrides = sourcePolicyOverrides?.ToList(),
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
            var scopes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var rule in rules)
            {
                ValidateRule(rule);
                if (!names.Add(rule.Name))
                {
                    throw new ArgumentException($"Duplicate mitigation rule name '{rule.Name}'.");
                }

                if (!scopes.Add(rule.Properties.TrafficScope))
                {
                    throw new ArgumentException($"Duplicate mitigation traffic scope '{rule.Properties.TrafficScope}'.");
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

            ValidatePositive(tcpPackets, "TcpPacketsPerSecond");
            ValidateNonNegative(tcpConnections, "TcpConnectionsPerSecond");
            ValidatePositive(udpPackets, "UdpPacketsPerSecond");

            if (string.Equals(scope, MNM.DdosMitigationTrafficScope.Tcp, StringComparison.OrdinalIgnoreCase) && udpPackets.HasValue)
            {
                throw new ArgumentException("UdpPacketsPerSecond cannot be used with a TCP mitigation rule.");
            }

            if (string.Equals(scope, MNM.DdosMitigationTrafficScope.Udp, StringComparison.OrdinalIgnoreCase)
                && (tcpPackets.HasValue || tcpConnections.HasValue))
            {
                throw new ArgumentException("TCP rate limits cannot be used with a UDP mitigation rule.");
            }

            ValidateOverrides(rule.Properties.SourcePolicyOverrides);

            if (!tcpPackets.HasValue
                && !tcpConnections.HasValue
                && !udpPackets.HasValue
                && (rule.Properties.SourcePolicyOverrides == null || rule.Properties.SourcePolicyOverrides.Count == 0))
            {
                throw new ArgumentException("A mitigation rule requires an applicable rate limit or at least one source policy override.");
            }
        }

        internal static void ValidateGeoMatch(PSDdosCustomPolicyGeoMatch geoMatch)
        {
            if (geoMatch == null)
            {
                throw new ArgumentException("GeoMatch cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(geoMatch.Continent) && string.IsNullOrWhiteSpace(geoMatch.CountryCode))
            {
                throw new ArgumentException("A geographic match requires a continent, a country code, or both.");
            }

            if (!string.IsNullOrWhiteSpace(geoMatch.CountryCode) && !CountryCodePattern.IsMatch(geoMatch.CountryCode))
            {
                throw new ArgumentException($"Country code '{geoMatch.CountryCode}' must be an uppercase two-letter ISO code.");
            }
        }

        internal static void ValidateSourcePolicyOverride(PSDdosCustomPolicySourcePolicyOverride sourcePolicyOverride)
        {
            if (sourcePolicyOverride?.PolicyAction == null || string.IsNullOrWhiteSpace(sourcePolicyOverride.PolicyAction.ActionType))
            {
                throw new ArgumentException("SourcePolicyOverride.PolicyAction.ActionType is required.");
            }

            if (sourcePolicyOverride.Conditions == null)
            {
                throw new ArgumentException("SourcePolicyOverride.Conditions is required.");
            }

            var prefixes = sourcePolicyOverride.Conditions.IpPrefixes;
            var geoMatches = sourcePolicyOverride.Conditions.GeoMatches;
            if ((prefixes == null || prefixes.Count == 0) && (geoMatches == null || geoMatches.Count == 0))
            {
                throw new ArgumentException("A source policy override requires at least one IP prefix or geographic match.");
            }

            if (prefixes != null)
            {
                foreach (var prefix in prefixes)
                {
                    ValidateCidr(prefix);
                }
            }

            if (geoMatches != null)
            {
                foreach (var geoMatch in geoMatches)
                {
                    ValidateGeoMatch(geoMatch);
                }
            }
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
            ValidateSourcePolicyOverride(value);
            return new MNM.DdosSourcePolicyOverride(
                new MNM.DdosSourcePolicyAction(value.PolicyAction.ActionType),
                new MNM.DdosSourceMatchConditions(
                    value.Conditions.IpPrefixes,
                    value.Conditions.GeoMatches?.Select(item => new MNM.DdosGeoMatch(item.Continent, item.CountryCode)).ToList()));
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

        private static void ValidateOverrides(IList<PSDdosCustomPolicySourcePolicyOverride> overrides)
        {
            if (overrides == null)
            {
                return;
            }

            var actions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var sourcePolicyOverride in overrides)
            {
                ValidateSourcePolicyOverride(sourcePolicyOverride);
                if (!actions.Add(sourcePolicyOverride.PolicyAction.ActionType))
                {
                    throw new ArgumentException($"Duplicate source policy action '{sourcePolicyOverride.PolicyAction.ActionType}'.");
                }
            }
        }

        private static void ValidatePositive(int? value, string parameterName)
        {
            if (value.HasValue && value.Value <= 0)
            {
                throw new ArgumentException($"{parameterName} must be greater than zero.");
            }
        }

        private static void ValidateNonNegative(int? value, string parameterName)
        {
            if (value.HasValue && value.Value < 0)
            {
                throw new ArgumentException($"{parameterName} cannot be negative.");
            }
        }

        private static void ValidateCidr(string prefix)
        {
            var parts = prefix?.Split('/');
            if (parts == null
                || parts.Length != 2
                || !IPAddress.TryParse(parts[0], out var address)
                || !int.TryParse(parts[1], out var prefixLength))
            {
                throw new ArgumentException($"'{prefix}' is not a valid IPv4 or IPv6 CIDR prefix.");
            }

            var maximum = address.AddressFamily == AddressFamily.InterNetwork ? 32 : 128;
            if (prefixLength < 0 || prefixLength > maximum)
            {
                throw new ArgumentException($"'{prefix}' is not a valid IPv4 or IPv6 CIDR prefix.");
            }
        }
    }
}
