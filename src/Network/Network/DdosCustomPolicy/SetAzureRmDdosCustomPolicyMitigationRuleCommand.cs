// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicy))]
    public class SetAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Tcp", "Udp")]
        public string TrafficScope { get; set; }

        [Parameter]
        public int? TcpPacketsPerSecond { get; set; }

        [Parameter]
        public int? TcpConnectionsPerSecond { get; set; }

        [Parameter]
        public int? UdpPacketsPerSecond { get; set; }

        [Parameter]
        [AllowEmptyCollection]
        public string[] DenyIpPrefix { get; set; }

        [Parameter]
        [AllowEmptyCollection]
        public string[] DenyGeoMatch { get; set; }

        [Parameter]
        [AllowEmptyCollection]
        public string[] PermitIpPrefix { get; set; }

        [Parameter]
        [AllowEmptyCollection]
        public string[] PermitGeoMatch { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (DdosCustomPolicy.MitigationRules == null)
            {
                throw new ArgumentException($"Mitigation rule '{Name}' was not found.");
            }

            var index = DdosCustomPolicy.MitigationRules.FindIndex(item => string.Equals(item.Name, Name, StringComparison.OrdinalIgnoreCase));
            if (index < 0)
            {
                throw new ArgumentException($"Mitigation rule '{Name}' was not found.");
            }

            if (!ShouldProcess(DdosCustomPolicy.Name, $"Set mitigation rule '{Name}'"))
            {
                WriteObject(DdosCustomPolicy);
                return;
            }

            var existing = DdosCustomPolicy.MitigationRules[index];
            var existingProperties = existing.Properties
                ?? throw new ArgumentException($"Mitigation rule '{Name}' has no properties.");
            var trafficScope = MyInvocation.BoundParameters.ContainsKey(nameof(TrafficScope))
                ? TrafficScope
                : existingProperties.TrafficScope;
            var preserveTcpLimits =
                string.Equals(existingProperties.TrafficScope, MNM.DdosMitigationTrafficScope.Tcp, StringComparison.OrdinalIgnoreCase)
                && string.Equals(trafficScope, MNM.DdosMitigationTrafficScope.Tcp, StringComparison.OrdinalIgnoreCase);
            var preserveUdpLimit =
                string.Equals(existingProperties.TrafficScope, MNM.DdosMitigationTrafficScope.Udp, StringComparison.OrdinalIgnoreCase)
                && string.Equals(trafficScope, MNM.DdosMitigationTrafficScope.Udp, StringComparison.OrdinalIgnoreCase);
            var sourcePolicyOverrides = DdosCustomPolicyMitigationRuleUtils.UpdateSourcePolicyOverrides(
                existingProperties.SourcePolicyOverrides,
                MyInvocation.BoundParameters.ContainsKey(nameof(DenyIpPrefix)),
                DenyIpPrefix,
                MyInvocation.BoundParameters.ContainsKey(nameof(DenyGeoMatch)),
                DenyGeoMatch,
                MyInvocation.BoundParameters.ContainsKey(nameof(PermitIpPrefix)),
                PermitIpPrefix,
                MyInvocation.BoundParameters.ContainsKey(nameof(PermitGeoMatch)),
                PermitGeoMatch);

            var replacement = DdosCustomPolicyMitigationRuleUtils.BuildRule(
                existing.Name,
                trafficScope,
                MyInvocation.BoundParameters.ContainsKey(nameof(TcpPacketsPerSecond))
                    ? TcpPacketsPerSecond
                    : preserveTcpLimits
                        ? existingProperties.TcpDefaultMitigations?.PerSourceRateLimiting?.PacketsPerSecond
                        : null,
                MyInvocation.BoundParameters.ContainsKey(nameof(TcpConnectionsPerSecond))
                    ? TcpConnectionsPerSecond
                    : preserveTcpLimits
                        ? existingProperties.TcpDefaultMitigations?.PerSourceConnectionRateLimiting?.ConnectionsPerSecond
                        : null,
                MyInvocation.BoundParameters.ContainsKey(nameof(UdpPacketsPerSecond))
                    ? UdpPacketsPerSecond
                    : preserveUdpLimit
                        ? existingProperties.UdpDefaultMitigations?.PerSourceRateLimiting?.PacketsPerSecond
                        : null,
                null,
                null,
                null,
                null);
            replacement.Properties.SourcePolicyOverrides = sourcePolicyOverrides;
            replacement.Id = existing.Id;
            replacement.Etag = existing.Etag;
            replacement.Type = existing.Type;
            replacement.Properties.ProvisioningState = existing.Properties?.ProvisioningState;

            var updatedRules = new List<PSDdosCustomPolicyMitigationRule>(DdosCustomPolicy.MitigationRules);
            updatedRules[index] = replacement;
            DdosCustomPolicyMitigationRuleUtils.ValidateRules(updatedRules);
            DdosCustomPolicy.MitigationRules = updatedRules;
            WriteObject(DdosCustomPolicy, true);
        }
    }
}
