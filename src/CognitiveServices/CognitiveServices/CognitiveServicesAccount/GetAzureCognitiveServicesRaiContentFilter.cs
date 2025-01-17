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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get or list Cognitive Services Account RaiContentFilter.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesRaiContentFilter", DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(RaiContentFilter))]
    public class GetAzureCognitiveServicesRaiContentFilterCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string DefaultParameterSet = "DefaultParameterSet";

        [Parameter(
            Position = 0,
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services RaiContentFilter Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                
                if (string.IsNullOrEmpty(this.Name))
                {
                    var raiContentFilters = new List<RaiContentFilter>(this.CognitiveServicesClient.RaiContentFilters.List(Location));
                    if (raiContentFilters != null)
                    {
                        WriteObject(raiContentFilters, true);
                    }
                }
                else
                {
                    var raiContentFilter = CognitiveServicesClient.RaiContentFilters.Get(Location, Name);
                    WriteObject(raiContentFilter);
                }
            });
        }
    }
}