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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "RulesEngine"), OutputType(typeof(PSRulesEngine))]
    public class GetFrontDoorRulesEngine : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The resource group name that the Front Door will be created in.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Front Door name.")]
        [ValidateNotNullOrEmpty]
        public string FrontDoorName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rules engine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.Name))
            {
                // Retrieve specified Rules Engine
                try
                {
                    var rulesEngine = FrontDoorManagementClient.RulesEngines.Get(ResourceGroupName, FrontDoorName, Name);
                    WriteObject(rulesEngine.ToPSRulesEngine());
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    if (e.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        throw new PSArgumentException(string.Format(Resources.Error_RulesEngineNotFound,
                            Name,
                            FrontDoorName));
                    }
                }
            }
            else
            {
                // Retrieve all Rules Engines for specified FrontDoor
                try
                {
                    List<PSRulesEngine> allRulesEngines = new List<PSRulesEngine>();
                    string nextPageLink;
                    do
                    {
                        var pageResult = FrontDoorManagementClient.RulesEngines.ListByFrontDoor(ResourceGroupName, FrontDoorName);
                        foreach (var rulesEngine in pageResult)
                        {
                            allRulesEngines.Add(rulesEngine.ToPSRulesEngine());
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    while (!string.IsNullOrEmpty(nextPageLink));

                    WriteObject(allRulesEngines);
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    if (e.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        throw new PSArgumentException(string.Format(Resources.Error_RulesEngineNotFound,
                            Name,
                            FrontDoorName));
                    }
                }
            }
        }
    }
}
