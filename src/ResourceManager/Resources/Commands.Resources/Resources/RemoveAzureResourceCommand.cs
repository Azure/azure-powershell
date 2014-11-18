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

using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Deletes an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureResource", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureResourceCommand : ResourceBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Version of the resource provider API.")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            BasePSResourceParameters parameters = new BasePSResourceParameters()
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                ResourceType = ResourceType,
                ParentResource = ParentResource,
                ApiVersion = ApiVersion
            };

            ConfirmAction(
                Force.IsPresent,
                string.Format(ProjectResources.RemovingResource, Name),
                ProjectResources.RemoveResourceMessage,
                Name,
                () => ResourcesClient.DeleteResource(parameters));

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
