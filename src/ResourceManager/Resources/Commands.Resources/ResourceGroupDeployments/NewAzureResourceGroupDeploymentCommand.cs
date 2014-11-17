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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Creates a new resource group deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureResourceGroupDeployment", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(PSResourceGroupDeployment))]
    public class NewAzureResourceGroupDeploymentCommand : ResourceWithParameterBaseCmdlet, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            CreatePSResourceGroupDeploymentParameters parameters = new CreatePSResourceGroupDeploymentParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DeploymentName = Name,
                GalleryTemplateIdentity = GalleryTemplateIdentity,
                TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                TemplateVersion = TemplateVersion,
                StorageAccountName = StorageAccountName
            };

            WriteObject(ResourcesClient.ExecuteDeployment(parameters));
        }
    }
}
