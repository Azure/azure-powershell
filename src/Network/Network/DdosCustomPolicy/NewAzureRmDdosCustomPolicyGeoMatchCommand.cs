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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyGeoMatch", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicyGeoMatch))]
    public class NewAzureRmDdosCustomPolicyGeoMatchCommand : NetworkBaseCmdlet
    {
        [Parameter(HelpMessage = "The continent to match.")]
        [PSArgumentCompleter("Africa", "Antarctica", "Asia", "Europe", "NorthAmerica", "Oceania", "SouthAmerica")]
        public string Continent { get; set; }

        [Parameter(HelpMessage = "The uppercase two-letter ISO country or territory code to match.")]
        public string CountryCode { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!ShouldProcess("DDoS custom policy geographic match", "Create"))
            {
                return;
            }

            var geoMatch = new PSDdosCustomPolicyGeoMatch
            {
                Continent = Continent,
                CountryCode = CountryCode,
            };
            DdosCustomPolicyMitigationRuleUtils.ValidateGeoMatch(geoMatch);
            WriteObject(geoMatch);
        }
    }
}
