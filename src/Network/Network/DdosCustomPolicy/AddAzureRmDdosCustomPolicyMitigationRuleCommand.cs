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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicy))]
    public class AddAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
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
        public string[] DenyIpPrefix { get; set; }

        [Parameter]
        public string[] DenyGeoMatch { get; set; }

        [Parameter]
        public string[] PermitIpPrefix { get; set; }

        [Parameter]
        public string[] PermitGeoMatch { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!ShouldProcess(DdosCustomPolicy.Name, $"Add mitigation rule '{Name}'"))
            {
                WriteObject(DdosCustomPolicy);
                return;
            }

            var existingRules = DdosCustomPolicy.MitigationRules ?? new List<PSDdosCustomPolicyMitigationRule>();
            if (existingRules.Exists(item => string.Equals(item.Name, Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Mitigation rule '{Name}' already exists.");
            }

            var updatedRules = new List<PSDdosCustomPolicyMitigationRule>(existingRules)
            {
                DdosCustomPolicyMitigationRuleUtils.BuildRule(
                    Name,
                    TrafficScope,
                    TcpPacketsPerSecond,
                    TcpConnectionsPerSecond,
                    UdpPacketsPerSecond,
                    DenyIpPrefix,
                    DenyGeoMatch,
                    PermitIpPrefix,
                    PermitGeoMatch),
            };
            DdosCustomPolicyMitigationRuleUtils.ValidateRules(updatedRules);
            DdosCustomPolicy.MitigationRules = updatedRules;
            WriteObject(DdosCustomPolicy, true);
        }
    }
}
