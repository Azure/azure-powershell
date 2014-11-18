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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources.ResourceGroupDeployments
{
    /// <summary>
    /// Validate a template to see whether it's using the right syntax, resource providers, resource types, etc.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "AzureResourceGroupTemplate", DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(List<PSResourceManagerError>))]
    public class TestAzureResourceGroupTemplateCommand : ResourceWithParameterBaseCmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            ValidatePSResourceGroupDeploymentParameters parameters = new ValidatePSResourceGroupDeploymentParameters()
            {
                ResourceGroupName = ResourceGroupName,
                GalleryTemplateIdentity = GalleryTemplateIdentity,
                TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
                TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                TemplateVersion = TemplateVersion,
                StorageAccountName = StorageAccountName
            };

            WriteObject(ResourcesClient.ValidatePSResourceGroupDeployment(parameters));
        }
    }
}
