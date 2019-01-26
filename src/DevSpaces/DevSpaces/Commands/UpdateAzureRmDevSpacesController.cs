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
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.DevSpaces.Models;
using Microsoft.Azure.Commands.DevSpaces.Properties;
using Microsoft.Azure.Commands.DevSpaces.Utils;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.DevSpaces;
using Microsoft.Azure.Management.DevSpaces.Models;

namespace Microsoft.Azure.Commands.DevSpaces.Commands
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DevSpacesController", DefaultParameterSetName = DevSpacesControllerNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSController))]
    public class UpdateAzureRmDevSpacesController : DevSpacesCmdletBase
    {
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

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The DevSpaces resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSController InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var msg = $"{Name} in {ResourceGroupName}";
            if (ShouldProcess(msg, Resources.UpdatingADevSpacesController))
            {
                RunCmdLet(UpdateDevSpacesControllerAction);
            }
        }

        private void UpdateDevSpacesControllerAction()
        {
            switch (ParameterSetName)
            {
                case DevSpacesControllerNameParameterSet:
                    UpdateDevSpacesController();
                    break;

                case ResourceIdParameterSet:
                    string resourceGroup, name;
                    if (!ConversionUtils.TryParseResourceId(ResourceId, ConversionUtils.DevSpacesControllerResourceTypeName, out resourceGroup, out name))
                    {
                        WriteError(new ErrorRecord(new PSArgumentException(Resources.InvalidDevSpacesControllerResourceIdErrorMessage, "ResourceId"), string.Empty, ErrorCategory.InvalidArgument, null));
                    }

                    ResourceGroupName = resourceGroup;
                    Name = name;
                    UpdateDevSpacesController();
                    break;

                case InputObjectParameterSet:
                    if (string.IsNullOrEmpty(InputObject.ResourceGroupName))
                    {
                        WriteError(new ErrorRecord(new PSArgumentException(Resources.InvalidDevSpacesControllerResourceGroupNameErrorMessage, "ResourceId"), string.Empty, ErrorCategory.InvalidArgument, null));
                    }

                    if (string.IsNullOrEmpty(InputObject.Name))
                    {
                        WriteError(new ErrorRecord(new PSArgumentException(Resources.InvalidDevSpacesControllerNameErrorMessage, "ResourceId"), string.Empty, ErrorCategory.InvalidArgument, null));
                    }

                    ResourceGroupName = InputObject.ResourceGroupName;
                    Name = InputObject.Name;
                    UpdateDevSpacesController();
                    break;

                default:
                    throw new ArgumentException(Resources.ParameterSetError);
            }
        }

        private void UpdateDevSpacesController()
        {
            Controller updatedController = Client.Controllers.Update(ResourceGroupName, Name, TagsConversionHelper.CreateTagDictionary(Tag, true));
            WriteObject(new PSController(updatedController));
        }
    }
}
