// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicyMitigationRule))]
    public class NewAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The mitigation rule name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The traffic protocol to which the rule applies.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Tcp", "Udp")]
        public string TrafficScope { get; set; }

        [Parameter(HelpMessage = "The maximum TCP packet rate per source IP.")]
        public int? TcpPacketsPerSecond { get; set; }

        [Parameter(HelpMessage = "The maximum new TCP connection rate per source IP.")]
        public int? TcpConnectionsPerSecond { get; set; }

        [Parameter(HelpMessage = "The maximum UDP packet rate per source IP.")]
        public int? UdpPacketsPerSecond { get; set; }

        [Parameter(HelpMessage = "The CIDR prefixes whose matching traffic is denied.")]
        public string[] DenyIpPrefix { get; set; }

        [Parameter(HelpMessage = "The geographic sources whose matching traffic is denied.")]
        public string[] DenyGeoMatch { get; set; }

        [Parameter(HelpMessage = "The CIDR prefixes that bypass source-level mitigations.")]
        public string[] PermitIpPrefix { get; set; }

        [Parameter(HelpMessage = "The geographic sources that bypass source-level mitigations.")]
        public string[] PermitGeoMatch { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!ShouldProcess(Name, "Create DDoS custom policy mitigation rule object"))
            {
                return;
            }

            WriteObject(DdosCustomPolicyMitigationRuleUtils.BuildRule(
                Name,
                TrafficScope,
                TcpPacketsPerSecond,
                TcpConnectionsPerSecond,
                UdpPacketsPerSecond,
                DenyIpPrefix,
                DenyGeoMatch,
                PermitIpPrefix,
                PermitGeoMatch));
        }
    }
}
