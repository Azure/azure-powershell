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
using Microsoft.Azure.Management.FrontDoor.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "RulesEngine", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet),
        OutputType(typeof(PSRulesEngine))]
    public class SetFrontDoorRulesEngine : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Rules Engine object to update.")]
        [ValidateNotNullOrEmpty]
        public PSRulesEngine InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the RulesEngine to update")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group name that the Front Door will be created in.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Front Door name.")]
        [ValidateNotNullOrEmpty]
        public string FrontDoorName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Rules engine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A list of rules that define a particular Rules Engine Configuration.")]
        public PSRulesEngineRule[] Rule { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                FrontDoorName = identifier.ParentResource.Substring(identifier.ParentResource.IndexOf("/") + 1);
                Name = InputObject.Name;
            }
            else if (ParameterSetName == ResourceIdParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                FrontDoorName = identifier.ParentResource.Substring(identifier.ParentResource.IndexOf("/") + 1);
                Name = InputObject.Name;
            }

            // Retrieve existing Rules Engine
            try
            {
                var rulesEngine = FrontDoorManagementClient.RulesEngines.Get(ResourceGroupName, FrontDoorName, Name);
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

            RulesEngine updateParameter;
            if (ParameterSetName == ObjectParameterSet)
            {
                updateParameter = InputObject.ToSdkRulesEngine();
            }
            else
            {
                updateParameter = new Management.FrontDoor.Models.RulesEngine(
                    rules: Rule?.Select(x => x.ToSdkRulesEngineRule()).ToList()
                );
            }

            if (ShouldProcess(Resources.FrontDoorTarget, string.Format(Resources.RulesEngineChangeWarning, Name, FrontDoorName)))
            {
                try
                {
                    var rulesEngine = FrontDoorManagementClient.RulesEngines.CreateOrUpdate(
                            resourceGroupName: ResourceGroupName,
                            frontDoorName: FrontDoorName,
                            rulesEngineName: Name,
                            rulesEngineParameters: updateParameter
                            );
                    WriteObject(rulesEngine.ToPSRulesEngine());
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    throw new PSArgumentException(string.Format(Resources.Error_ErrorResponseFromServer,
                                         e.Response.Content));
                }
            }
        }
    }
}
