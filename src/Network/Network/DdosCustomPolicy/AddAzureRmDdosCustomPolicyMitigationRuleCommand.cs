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
        public PSDdosCustomPolicySourcePolicyOverride[] SourcePolicyOverride { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!ShouldProcess(DdosCustomPolicy.Name, $"Add mitigation rule '{Name}'"))
            {
                WriteObject(DdosCustomPolicy);
                return;
            }

            DdosCustomPolicy.MitigationRules = DdosCustomPolicy.MitigationRules ?? new List<PSDdosCustomPolicyMitigationRule>();
            if (DdosCustomPolicy.MitigationRules.Exists(item => string.Equals(item.Name, Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Mitigation rule '{Name}' already exists.");
            }

            DdosCustomPolicy.MitigationRules.Add(DdosCustomPolicyMitigationRuleUtils.BuildRule(
                Name,
                TrafficScope,
                TcpPacketsPerSecond,
                TcpConnectionsPerSecond,
                UdpPacketsPerSecond,
                SourcePolicyOverride));
            DdosCustomPolicyMitigationRuleUtils.ValidateRules(DdosCustomPolicy.MitigationRules);
            WriteObject(DdosCustomPolicy, true);
        }
    }
}
