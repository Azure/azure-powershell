// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicySourcePolicyOverride", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicySourcePolicyOverride))]
    public class NewAzureRmDdosCustomPolicySourcePolicyOverrideCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The action to apply to matching traffic.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Deny", "Permit")]
        public string ActionType { get; set; }

        [Parameter(HelpMessage = "The IPv4 or IPv6 CIDR prefixes to match.")]
        public string[] IpPrefix { get; set; }

        [Parameter(HelpMessage = "The geographic matches to apply.")]
        public PSDdosCustomPolicyGeoMatch[] GeoMatch { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!ShouldProcess("DDoS custom policy source policy override", "Create"))
            {
                return;
            }

            var sourcePolicyOverride = new PSDdosCustomPolicySourcePolicyOverride
            {
                PolicyAction = new PSDdosCustomPolicySourcePolicyAction
                {
                    ActionType = ActionType,
                },
                Conditions = new PSDdosCustomPolicySourceMatchConditions
                {
                    IpPrefixes = IpPrefix == null ? null : new List<string>(IpPrefix),
                    GeoMatches = GeoMatch?.ToList(),
                },
            };

            DdosCustomPolicyMitigationRuleUtils.ValidateSourcePolicyOverride(sourcePolicyOverride);
            WriteObject(sourcePolicyOverride);
        }
    }
}
