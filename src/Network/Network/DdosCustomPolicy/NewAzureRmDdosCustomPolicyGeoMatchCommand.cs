// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyGeoMatch")]
    [OutputType(typeof(PSDdosCustomPolicyGeoMatch))]
    public class NewAzureRmDdosCustomPolicyGeoMatchCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = false)]
        [PSArgumentCompleter(
            MNM.DdosContinent.Africa,
            MNM.DdosContinent.Antarctica,
            MNM.DdosContinent.Asia,
            MNM.DdosContinent.Europe,
            MNM.DdosContinent.NorthAmerica,
            MNM.DdosContinent.Oceania,
            MNM.DdosContinent.SouthAmerica)]
        public string Continent { get; set; }

        [Parameter(Mandatory = false)]
        [ValidatePattern("^[A-Z]{2}$")]
        public string CountryCode { get; set; }

        public override void Execute()
        {
            base.Execute();

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
