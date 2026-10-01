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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    internal static class DdosCustomPolicyMitigationRuleUtils
    {
        private static readonly Regex CountryCodePattern = new Regex("^[A-Z]{2}$", RegexOptions.CultureInvariant);

        internal static PSDdosCustomPolicyMitigationRule CreateRule(
            string name,
            string trafficScope,
            int? tcpPacketsPerSecond,
            int? tcpConnectionsPerSecond,
            int? udpPacketsPerSecond,
            PSDdosCustomPolicySourcePolicyOverride[] sourcePolicyOverrides)
        {
            var rule = new PSDdosCustomPolicyMitigationRule
            {
                Name = name,
                Properties = new PSDdosCustomPolicyMitigationRuleProperties
                {
                    TrafficScope = trafficScope,
                    TcpDefaultMitigations = tcpPacketsPerSecond.HasValue || tcpConnectionsPerSecond.HasValue
                        ? new PSDdosCustomPolicyTcpDefaultMitigations
                        {
                            PerSourceRateLimiting = tcpPacketsPerSecond.HasValue
                                ? new PSDdosCustomPolicyTcpPerSourceRateLimitPolicy { PacketsPerSecond = tcpPacketsPerSecond.Value }
                                : null,
                            PerSourceConnectionRateLimiting = tcpConnectionsPerSecond.HasValue
                                ? new PSDdosCustomPolicyTcpPerSourceConnectionRateLimitPolicy { ConnectionsPerSecond = tcpConnectionsPerSecond.Value }
                                : null,
                        }
                        : null,
                    UdpDefaultMitigations = udpPacketsPerSecond.HasValue
                        ? new PSDdosCustomPolicyUdpDefaultMitigations
                        {
                            PerSourceRateLimiting = new PSDdosCustomPolicyUdpPerSourceRateLimitPolicy
                            {
                                PacketsPerSecond = udpPacketsPerSecond.Value,
                            },
                        }
                        : null,
                    SourcePolicyOverrides = sourcePolicyOverrides?.ToList(),
                },
            };

            ValidateRule(rule);
            return rule;
        }

        internal static void ValidateRule(PSDdosCustomPolicyMitigationRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentException("MitigationRule cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(rule.Name))
            {
                throw new ArgumentException("MitigationRule.Name is required.");
            }

            if (rule.Properties == null)
            {
                throw new ArgumentException("MitigationRule.Properties is required.");
            }

            if (string.IsNullOrWhiteSpace(rule.Properties.TrafficScope))
            {
                throw new ArgumentException("MitigationRule.Properties.TrafficScope is required.");
            }

            int? tcpPacketsPerSecond = rule.Properties.TcpDefaultMitigations?.PerSourceRateLimiting?.PacketsPerSecond;
            int? tcpConnectionsPerSecond = rule.Properties.TcpDefaultMitigations?.PerSourceConnectionRateLimiting?.ConnectionsPerSecond;
            int? udpPacketsPerSecond = rule.Properties.UdpDefaultMitigations?.PerSourceRateLimiting?.PacketsPerSecond;
            bool isTcp = string.Equals(rule.Properties.TrafficScope, MNM.DdosMitigationTrafficScope.Tcp, StringComparison.OrdinalIgnoreCase);
            bool isUdp = string.Equals(rule.Properties.TrafficScope, MNM.DdosMitigationTrafficScope.Udp, StringComparison.OrdinalIgnoreCase);

            if (isTcp && udpPacketsPerSecond.HasValue)
            {
                throw new ArgumentException("UdpPacketsPerSecond cannot be used with a TCP mitigation rule.");
            }

            if (isUdp && (tcpPacketsPerSecond.HasValue || tcpConnectionsPerSecond.HasValue))
            {
                throw new ArgumentException("TCP rate parameters cannot be used with a UDP mitigation rule.");
            }

            if (!isTcp && !isUdp &&
                (tcpPacketsPerSecond.HasValue || tcpConnectionsPerSecond.HasValue || udpPacketsPerSecond.HasValue))
            {
                throw new ArgumentException("Protocol-specific rate parameters can only be used with Tcp or Udp traffic scopes.");
            }

            ValidatePositiveRate(tcpPacketsPerSecond, "TcpPacketsPerSecond");
            ValidatePositiveRate(tcpConnectionsPerSecond, "TcpConnectionsPerSecond");
            ValidatePositiveRate(udpPacketsPerSecond, "UdpPacketsPerSecond");

            ValidateSourcePolicyOverrides(rule.Properties.SourcePolicyOverrides);

            bool hasDefaultMitigation =
                (isTcp && (tcpPacketsPerSecond.HasValue || tcpConnectionsPerSecond.HasValue)) ||
                (isUdp && udpPacketsPerSecond.HasValue);
            bool hasSourceOverride = rule.Properties.SourcePolicyOverrides != null && rule.Properties.SourcePolicyOverrides.Count > 0;

            if (!hasDefaultMitigation && !hasSourceOverride)
            {
                throw new ArgumentException("A mitigation rule requires an applicable rate limit or at least one source policy override.");
            }
        }

        internal static void ValidatePolicyRules(IList<PSDdosCustomPolicyMitigationRule> rules)
        {
            if (rules == null)
            {
                return;
            }

            var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var trafficScopes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var rule in rules)
            {
                ValidateRule(rule);

                if (!names.Add(rule.Name))
                {
                    throw new ArgumentException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Duplicate mitigation rule name '{0}'.",
                        rule.Name));
                }

                if (!trafficScopes.Add(rule.Properties.TrafficScope))
                {
                    throw new ArgumentException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Duplicate mitigation rule traffic scope '{0}'.",
                        rule.Properties.TrafficScope));
                }
            }
        }

        internal static void ValidateSourcePolicyOverride(PSDdosCustomPolicySourcePolicyOverride sourceOverride)
        {
            if (sourceOverride == null)
            {
                throw new ArgumentException("SourcePolicyOverride cannot be null.");
            }

            if (sourceOverride.PolicyAction == null || string.IsNullOrWhiteSpace(sourceOverride.PolicyAction.ActionType))
            {
                throw new ArgumentException("SourcePolicyOverride.PolicyAction.ActionType is required.");
            }

            if (sourceOverride.Conditions == null)
            {
                throw new ArgumentException("SourcePolicyOverride.Conditions is required.");
            }

            bool hasIpPrefixes = sourceOverride.Conditions.IpPrefixes != null && sourceOverride.Conditions.IpPrefixes.Count > 0;
            bool hasGeoMatches = sourceOverride.Conditions.GeoMatches != null && sourceOverride.Conditions.GeoMatches.Count > 0;

            if (!hasIpPrefixes && !hasGeoMatches)
            {
                throw new ArgumentException("A source policy override requires at least one IP prefix or geographic match.");
            }

            if (sourceOverride.Conditions.IpPrefixes != null)
            {
                foreach (string prefix in sourceOverride.Conditions.IpPrefixes)
                {
                    ValidateIpPrefix(prefix);
                }
            }

            if (sourceOverride.Conditions.GeoMatches != null)
            {
                foreach (var geoMatch in sourceOverride.Conditions.GeoMatches)
                {
                    ValidateGeoMatch(geoMatch);
                }
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
                throw new ArgumentException("CountryCode must contain exactly two uppercase ASCII letters.");
            }
        }

        internal static List<MNM.DdosMitigationRule> ToSdkRules(IList<PSDdosCustomPolicyMitigationRule> rules)
        {
            if (rules == null)
            {
                return null;
            }

            ValidatePolicyRules(rules);
            return rules.Select(ToSdkRule).ToList();
        }

        internal static MNM.DdosMitigationRule ToSdkRule(PSDdosCustomPolicyMitigationRule rule)
        {
            ValidateRule(rule);

            var properties = new MNM.DdosMitigationRulePropertiesFormat(rule.Properties.TrafficScope)
            {
                SourcePolicyOverrides = rule.Properties.SourcePolicyOverrides?.Select(ToSdkSourcePolicyOverride).ToList(),
            };

            if (rule.Properties.TcpDefaultMitigations != null)
            {
                properties.TcpDefaultMitigations = new MNM.DdosTcpDefaultMitigations
                {
                    PerSourceRateLimiting = rule.Properties.TcpDefaultMitigations.PerSourceRateLimiting != null
                        ? new MNM.DdosTcpPerSourceRateLimitPolicy(rule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond)
                        : null,
                    PerSourceConnectionRateLimiting = rule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting != null
                        ? new MNM.DdosTcpPerSourceConnectionRateLimitPolicy(rule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond)
                        : null,
                };
            }

            if (rule.Properties.UdpDefaultMitigations?.PerSourceRateLimiting != null)
            {
                properties.UdpDefaultMitigations = new MNM.DdosUdpDefaultMitigations(
                    new MNM.DdosUdpPerSourceRateLimitPolicy(rule.Properties.UdpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond));
            }

            return new MNM.DdosMitigationRule(rule.Name, properties);
        }

        internal static PSDdosCustomPolicyMitigationRule ToPowerShellRule(MNM.DdosMitigationRule rule)
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
                Properties = rule.Properties == null
                    ? null
                    : new PSDdosCustomPolicyMitigationRuleProperties
                    {
                        ProvisioningState = rule.Properties.ProvisioningState,
                        TrafficScope = rule.Properties.TrafficScope,
                        TcpDefaultMitigations = rule.Properties.TcpDefaultMitigations == null
                            ? null
                            : new PSDdosCustomPolicyTcpDefaultMitigations
                            {
                                PerSourceRateLimiting = rule.Properties.TcpDefaultMitigations.PerSourceRateLimiting == null
                                    ? null
                                    : new PSDdosCustomPolicyTcpPerSourceRateLimitPolicy
                                    {
                                        PacketsPerSecond = rule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond,
                                    },
                                PerSourceConnectionRateLimiting = rule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting == null
                                    ? null
                                    : new PSDdosCustomPolicyTcpPerSourceConnectionRateLimitPolicy
                                    {
                                        ConnectionsPerSecond = rule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond,
                                    },
                            },
                        UdpDefaultMitigations = rule.Properties.UdpDefaultMitigations?.PerSourceRateLimiting == null
                            ? null
                            : new PSDdosCustomPolicyUdpDefaultMitigations
                            {
                                PerSourceRateLimiting = new PSDdosCustomPolicyUdpPerSourceRateLimitPolicy
                                {
                                    PacketsPerSecond = rule.Properties.UdpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond,
                                },
                            },
                        SourcePolicyOverrides = rule.Properties.SourcePolicyOverrides?.Select(ToPowerShellSourcePolicyOverride).ToList(),
                    },
            };
        }

        private static void ValidateSourcePolicyOverrides(IList<PSDdosCustomPolicySourcePolicyOverride> sourcePolicyOverrides)
        {
            if (sourcePolicyOverrides == null)
            {
                return;
            }

            var actions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var sourceOverride in sourcePolicyOverrides)
            {
                ValidateSourcePolicyOverride(sourceOverride);
                if (!actions.Add(sourceOverride.PolicyAction.ActionType))
                {
                    throw new ArgumentException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Duplicate source policy action '{0}'.",
                        sourceOverride.PolicyAction.ActionType));
                }
            }
        }

        private static void ValidateIpPrefix(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("IP prefixes cannot contain null or empty entries.");
            }

            string[] parts = prefix.Split('/');
            IPAddress address;
            int prefixLength;
            if (parts.Length != 2 ||
                !IPAddress.TryParse(parts[0], out address) ||
                !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out prefixLength))
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "'{0}' is not a valid IPv4 or IPv6 CIDR prefix.",
                    prefix));
            }

            int maximumPrefixLength = address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? 32 : 128;
            if (prefixLength < 0 || prefixLength > maximumPrefixLength)
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "'{0}' is not a valid IPv4 or IPv6 CIDR prefix.",
                    prefix));
            }
        }

        private static void ValidatePositiveRate(int? rate, string propertyName)
        {
            if (rate.HasValue && rate.Value <= 0)
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "{0} must be greater than zero.",
                    propertyName));
            }
        }

        private static MNM.DdosSourcePolicyOverride ToSdkSourcePolicyOverride(PSDdosCustomPolicySourcePolicyOverride sourceOverride)
        {
            return new MNM.DdosSourcePolicyOverride(
                new MNM.DdosSourcePolicyAction(sourceOverride.PolicyAction.ActionType),
                new MNM.DdosSourceMatchConditions(
                    sourceOverride.Conditions.IpPrefixes,
                    sourceOverride.Conditions.GeoMatches?.Select(ToSdkGeoMatch).ToList()));
        }

        private static MNM.DdosGeoMatch ToSdkGeoMatch(PSDdosCustomPolicyGeoMatch geoMatch)
        {
            return new MNM.DdosGeoMatch(geoMatch.Continent, geoMatch.CountryCode);
        }

        private static PSDdosCustomPolicySourcePolicyOverride ToPowerShellSourcePolicyOverride(MNM.DdosSourcePolicyOverride sourceOverride)
        {
            return new PSDdosCustomPolicySourcePolicyOverride
            {
                PolicyAction = sourceOverride.PolicyAction == null
                    ? null
                    : new PSDdosCustomPolicySourcePolicyAction
                    {
                        ActionType = sourceOverride.PolicyAction.ActionType,
                    },
                Conditions = sourceOverride.Conditions == null
                    ? null
                    : new PSDdosCustomPolicySourceMatchConditions
                    {
                        IpPrefixes = sourceOverride.Conditions.IPPrefixes?.ToList(),
                        GeoMatches = sourceOverride.Conditions.GeoMatches?.Select(
                            geoMatch => new PSDdosCustomPolicyGeoMatch
                            {
                                Continent = geoMatch.Continent,
                                CountryCode = geoMatch.CountryCode,
                            }).ToList(),
                    },
            };
        }
    }
}
