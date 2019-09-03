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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    /// <summary>
    /// Validate a template to see whether it's using the right syntax, resource providers, resource types, etc.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Deployment", 
        DefaultParameterSetName = SubscriptionAndTenantParameterSetWithParameterlessTemplateFile), OutputType(typeof(PSResourceManagerError))]
    public class TestAzureDeploymentCmdlet : DeploymentCmdletWithParameters, IDynamicParameters
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The deployment scope type.")]
        public DeploymentScopeType ScopeType { get; set; }

        [Parameter(ParameterSetName = SubscriptionAndTenantParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = SubscriptionAndTenantParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = SubscriptionAndTenantParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = SubscriptionAndTenantParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = SubscriptionAndTenantParameterSetWithParameterlessTemplateObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = SubscriptionAndTenantParameterSetWithParameterlessTemplateFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithParameterlessTemplateObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithParameterlessTemplateFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The management group id.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The management group id.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The management group id.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The management group id.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithParameterlessTemplateObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The management group id.")]
        [Parameter(ParameterSetName = ManagementGroupParameterSetWithParameterlessTemplateFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The management group id.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithParameterlessTemplateObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithParameterlessTemplateFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rollback to the last successful deployment in the resource group, should not be present if -RollBackDeploymentName is used.")]
        public SwitchParameter RollbackToLastDeployment { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Rollback to the successful deployment with the given name in the resource group, should not be used if -RollbackToLastDeployment is used.")]
        public string RollBackDeploymentName { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ValidateCmdletParameters();

            var parameters = new PSDeploymentCmdletParameters()
            {
                ScopeType = this.ScopeType,
                DeploymentName = Guid.NewGuid().ToString(),
                Location = this.Location,
                ManagementGroupId = this.ManagementGroupId,
                ResourceGroupName = this.ResourceGroupName,
                DeploymentMode = this.Mode,
                TemplateFile = Uri.IsWellFormedUriString(this.TemplateFile, UriKind.Absolute) ? this.TemplateFile : this.TryResolvePath(this.TemplateFile),
                TemplateObject = this.TemplateObject,
                TemplateParameterObject = GetTemplateParameterObject(this.TemplateParameterObject),
                ParameterUri = Uri.IsWellFormedUriString(this.TemplateParameterFile, UriKind.Absolute) ? this.TemplateParameterFile : null,
                OnErrorDeployment = this.RollbackToLastDeployment || !string.IsNullOrEmpty(this.RollBackDeploymentName)
                    ? new OnErrorDeployment
                    {
                        Type = this.RollbackToLastDeployment ? OnErrorDeploymentType.LastSuccessful : OnErrorDeploymentType.SpecificDeployment,
                        DeploymentName = this.RollbackToLastDeployment ? null : this.RollBackDeploymentName
                    }
                    : null
            };

            var validationResult = ResourceManagerSdkClient.ValidateDeployment(parameters);

            WriteObject(validationResult);
        }

        private void ValidateCmdletParameters()
        {
            this.ValidateScopeTypeMatches();

            if (this.ScopeType != DeploymentScopeType.ResourceGroup && this.Mode == DeploymentMode.Complete)
            {
                WriteExceptionError(new ArgumentException(ProjectResources.InvalidDeploymentMode));
            }

            if (this.RollbackToLastDeployment && !string.IsNullOrEmpty(this.RollBackDeploymentName))
            {
                WriteExceptionError(new ArgumentException(ProjectResources.InvalidRollbackParameters));
            }
        }

        private void ValidateScopeTypeMatches()
        {
            if (this.ScopeType == DeploymentScopeType.ResourceGroup && string.IsNullOrEmpty(this.ResourceGroupName))
            {
                WriteExceptionError(new ArgumentException(ProjectResources.InvalidParameterForResourceGroupScope));
            }

            if (this.ScopeType == DeploymentScopeType.ManagementGroup && string.IsNullOrEmpty(this.ManagementGroupId))
            {
                WriteExceptionError(new ArgumentException(ProjectResources.InvalidParameterForManagementGroupScope));
            }

            if ((this.ScopeType == DeploymentScopeType.Subscription || this.ScopeType == DeploymentScopeType.Tenant)
                && (!string.IsNullOrEmpty(this.ResourceGroupName) || !string.IsNullOrEmpty(this.ManagementGroupId)))
            {
                WriteExceptionError(new ArgumentException(string.Format(ProjectResources.InvalidParameterForTenantAndSubscriptionScope, this.ScopeType.ToString())));
            }
        }
    }
}
