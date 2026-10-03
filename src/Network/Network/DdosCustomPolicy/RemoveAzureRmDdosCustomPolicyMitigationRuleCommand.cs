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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicy))]
    public class RemoveAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (DdosCustomPolicy.MitigationRules == null)
            {
                WriteObject(DdosCustomPolicy, true);
                return;
            }

            var rule = DdosCustomPolicy.MitigationRules.Find(item => string.Equals(item.Name, Name, StringComparison.OrdinalIgnoreCase));
            if (rule == null)
            {
                WriteObject(DdosCustomPolicy, true);
                return;
            }

            if (!ShouldProcess(DdosCustomPolicy.Name, $"Remove mitigation rule '{Name}'"))
            {
                WriteObject(DdosCustomPolicy);
                return;
            }

            DdosCustomPolicy.MitigationRules.Remove(rule);
            if (DdosCustomPolicy.MitigationRules.Count == 0)
            {
                DdosCustomPolicy.MitigationRules = null;
            }

            WriteObject(DdosCustomPolicy, true);
        }
    }
}
