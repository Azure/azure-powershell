// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Management.Automation;

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

        [Parameter(Mandatory = true)]
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
        public PSDdosCustomPolicySourcePolicyOverride[] SourcePolicyOverride { get; set; }

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
            var replacement = DdosCustomPolicyMitigationRuleUtils.BuildRule(
                existing.Name,
                TrafficScope,
                TcpPacketsPerSecond,
                TcpConnectionsPerSecond,
                UdpPacketsPerSecond,
                SourcePolicyOverride);
            replacement.Id = existing.Id;
            replacement.Etag = existing.Etag;
            replacement.Type = existing.Type;
            replacement.Properties.ProvisioningState = existing.Properties?.ProvisioningState;

            DdosCustomPolicy.MitigationRules[index] = replacement;
            DdosCustomPolicyMitigationRuleUtils.ValidateRules(DdosCustomPolicy.MitigationRules);
            WriteObject(DdosCustomPolicy, true);
        }
    }
}
