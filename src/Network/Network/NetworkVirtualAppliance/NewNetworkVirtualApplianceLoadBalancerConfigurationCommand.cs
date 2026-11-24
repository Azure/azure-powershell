// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkVirtualApplianceLoadBalancerConfiguration",
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSNetworkVirtualApplianceLoadBalancerConfiguration))]
    public class NewNetworkVirtualApplianceLoadBalancerConfigurationCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The load distribution policy. Defaults to Default (five-tuple hash).")]
        [ValidateSet("Default", "SourceIP", "SourceIPProtocol", IgnoreCase = true)]
        public string LoadDistribution { get; set; } = "Default";

        [Parameter(Mandatory = false, HelpMessage = "The idle timeout in minutes, from 4 through 100. Defaults to 5.")]
        [ValidateRange(4, 100)]
        public int IdleTimeoutInMinutes { get; set; } = 5;

        public override void Execute()
        {
            base.Execute();
            WriteObject(LoadBalancerConfigurationHelper.Normalize(new PSNetworkVirtualApplianceLoadBalancerConfiguration
            {
                LoadDistribution = this.LoadDistribution,
                IdleTimeoutInMinutes = this.IdleTimeoutInMinutes
            }));
        }
    }
}
