// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule")]
    [OutputType(typeof(PSDdosCustomPolicyMitigationRule))]
    public class GetAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(HelpMessage = "The mitigation rule name. Omit to return every rule.")]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (DdosCustomPolicy.MitigationRules == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                WriteObject(DdosCustomPolicy.MitigationRules, true);
                return;
            }

            var rule = DdosCustomPolicy.MitigationRules.Find(item => string.Equals(item.Name, Name, StringComparison.OrdinalIgnoreCase));
            if (rule == null)
            {
                throw new ArgumentException($"Mitigation rule '{Name}' was not found.");
            }

            WriteObject(rule);
        }
    }
}
