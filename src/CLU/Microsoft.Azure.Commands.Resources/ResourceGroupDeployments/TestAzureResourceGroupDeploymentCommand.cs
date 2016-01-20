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
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources.ResourceGroupDeployments
{
    /// <summary>
    /// Validate a template to see whether it's using the right syntax, resource providers, resource types, etc.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmResourceGroupDeployment", DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), 
        OutputType(typeof(PSResourceManagerError))]
    [CliCommandAlias("resource group deployment test")]
    public class TestAzureResourceGroupDeploymentCommand : ResourceWithParameterBaseCmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [Alias("group","g")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; }

        public TestAzureResourceGroupDeploymentCommand()
        {
            this.Mode = DeploymentMode.Incremental;
        }

        protected override void ProcessRecord()
        {
            ValidatePSResourceGroupDeploymentParameters parameters = new ValidatePSResourceGroupDeploymentParameters()
            {
                ResourceGroupName = ResourceGroupName,
                TemplateFile = TemplateUri ?? TemplateFile,
                TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                ParameterUri = TemplateParameterUri
            };

            WriteObject(ResourcesClient.ValidatePSResourceGroupDeployment(parameters, Mode), enumerateCollection: true);
        }
    }
}
