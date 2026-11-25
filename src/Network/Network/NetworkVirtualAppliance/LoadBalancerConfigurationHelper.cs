// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    internal static class LoadBalancerConfigurationHelper
    {
        internal static PSNetworkVirtualApplianceLoadBalancerConfiguration Normalize(
            PSNetworkVirtualApplianceLoadBalancerConfiguration configuration)
        {
            if (configuration == null)
            {
                return null;
            }

            var distribution = configuration.LoadDistribution ?? "Default";
            var canonical = Array.Find(new[] { "Default", "SourceIP", "SourceIPProtocol" },
                value => string.Equals(value, distribution, StringComparison.OrdinalIgnoreCase));
            if (canonical == null)
            {
                throw new PSArgumentException("LoadDistribution must be Default, SourceIP, or SourceIPProtocol.");
            }

            var timeout = configuration.IdleTimeoutInMinutes ?? 5;
            if (timeout < 4 || timeout > 100)
            {
                throw new PSArgumentException("IdleTimeoutInMinutes must be between 4 and 100.");
            }

            return new PSNetworkVirtualApplianceLoadBalancerConfiguration
            {
                LoadDistribution = canonical,
                IdleTimeoutInMinutes = timeout
            };
        }

        internal static PSNetworkVirtualApplianceLoadBalancerConfiguration NormalizeRule(
            PSNetworkVirtualApplianceLoadBalancerConfiguration configuration, string ruleType)
        {
            if (configuration != null && !string.Equals(ruleType, "Permanent", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException("LoadBalancerConfiguration is supported only when RuleType is Permanent.");
            }

            return Normalize(configuration);
        }
    }
}
