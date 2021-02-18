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

<<<<<<< HEAD
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
=======
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Common;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Management.Automation;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Validate a template to see whether it's using the right syntax, resource providers, resource types, etc.
    /// </summary>
<<<<<<< HEAD
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeployment", DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSResourceManagerError))]
    public class TestAzureResourceGroupDeploymentCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
=======
    [Cmdlet("Test", AzureRMConstants.AzureRMPrefix + "ResourceGroupDeployment", DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSResourceManagerError))]
    public class TestAzureResourceGroupDeploymentCmdlet : TestDeploymentCmdletBase
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rollback to the last successful deployment in the resource group, should not be present if -RollBackDeploymentName is used.")]
        public SwitchParameter RollbackToLastDeployment { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Rollback to the successful deployment with the given name in the resource group, should not be used if -RollbackToLastDeployment is used.")]
        public string RollBackDeploymentName { get; set; }

        public string DeploymentName { get; set; }

        public TestAzureResourceGroupDeploymentCmdlet()
        {
            this.Mode = DeploymentMode.Incremental;
        }

<<<<<<< HEAD
        public override void ExecuteCmdlet()
=======
        protected override void OnProcessRecord()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            if (RollbackToLastDeployment && !string.IsNullOrEmpty(RollBackDeploymentName))
            {
                WriteExceptionError(new ArgumentException(ProjectResources.InvalidRollbackParameters));
            }

            PSDeploymentCmdletParameters parameters = new PSDeploymentCmdletParameters()
            {
<<<<<<< HEAD
                DeploymentName = DeploymentName ?? Guid.NewGuid().ToString(),
                ResourceGroupName = ResourceGroupName,
                TemplateFile = TemplateUri ?? this.ResolvePath(TemplateFile),
                TemplateObject = TemplateObject,
=======
                ScopeType = DeploymentScopeType.ResourceGroup,
                DeploymentName = DeploymentName ?? Guid.NewGuid().ToString(),
                ResourceGroupName = ResourceGroupName,
                DeploymentMode = Mode,
                TemplateFile = TemplateUri ?? this.ResolvePath(TemplateFile),
                TemplateObject = TemplateObject,
                QueryString = QueryString,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                ParameterUri = TemplateParameterUri,
                OnErrorDeployment = RollbackToLastDeployment || !string.IsNullOrEmpty(RollBackDeploymentName)
                    ? new OnErrorDeployment
                    {
                        Type = RollbackToLastDeployment ? OnErrorDeploymentType.LastSuccessful : OnErrorDeploymentType.SpecificDeployment,
                        DeploymentName = RollbackToLastDeployment ? null : RollBackDeploymentName
                    }
                    : null
            };

<<<<<<< HEAD
            WriteObject(ResourceManagerSdkClient.ValidateDeployment(parameters, Mode));
=======
            WriteObject(ResourceManagerSdkClient.ValidateDeployment(parameters));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
