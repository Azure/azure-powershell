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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.DevSpaces.Models;
using Microsoft.Azure.Commands.DevSpaces.Properties;
using Microsoft.Azure.Commands.DevSpaces.Utils;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.DevSpaces.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DevSpacesController", DefaultParameterSetName = ListDevSpacesControllerParameterSet)]
    [OutputType(typeof(PSController))]
    public class GetAzureRmDevSpacesController : DevSpacesCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ListDevSpacesControllerParameterSet,
            HelpMessage = "Resource group name")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DevSpacesControllerNameParameterSet,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DevSpacesControllerNameParameterSet,
            HelpMessage = "DevSpaces controller name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdLet(() => {
                switch (ParameterSetName)
                {
                    case ListDevSpacesControllerParameterSet:
                        ListDevSpacesController();
                        break;

                    case DevSpacesControllerNameParameterSet:
                        ShowDevSpacesController();
                        break;

                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
            });
        }

        private void ListDevSpacesController()
        {
            var controllers = Client.Controllers.ListAllPSController(ResourceGroupName);
            WriteObject(controllers, true);
        }

        private void ShowDevSpacesController()
        {
            var controller = Client.Controllers.GetPSController(ResourceGroupName, Name);
            WriteObject(controller);
        }
    }
}
