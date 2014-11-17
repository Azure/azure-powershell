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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Creates a new resource group.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureResourceGroup", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(PSResourceGroup))]
    public class NewAzureResourceGroupCommand : ResourceWithParameterBaseCmdlet, IDynamicParameters
    {
        [Alias("ResourceGroupName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "An array of hashtables which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters
            {
                ResourceGroupName = Name,
                Location = Location,
                DeploymentName = DeploymentName,
                GalleryTemplateIdentity = GalleryTemplateIdentity,
                TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                TemplateVersion = TemplateVersion,
                StorageAccountName = StorageAccountName,
                Force = Force.IsPresent,
                Tag = Tag,
                ConfirmAction = ConfirmAction
            };

            WriteObject(ResourcesClient.CreatePSResourceGroup(parameters));
        }
    }
}
