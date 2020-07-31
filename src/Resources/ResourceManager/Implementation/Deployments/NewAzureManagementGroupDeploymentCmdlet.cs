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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Creates a new deployment at a management group.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "ManagementGroupDeployment", SupportsShouldProcess = true,
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeployment))]
    public class NewAzureManagementGroupDeploymentCmdlet : DeploymentCreateCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The management group ID.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        protected override ConfirmImpact ConfirmImpact => ((CmdletAttribute)Attribute.GetCustomAttribute(
            typeof(NewAzureManagementGroupDeploymentCmdlet),
            typeof(CmdletAttribute))).ConfirmImpact;

        protected override PSDeploymentCmdletParameters DeploymentParameters => new PSDeploymentCmdletParameters()
        {
            ScopeType = DeploymentScopeType.ManagementGroup,
            ManagementGroupId = this.ManagementGroupId,
            Location = this.Location,
            DeploymentName = this.Name,
            DeploymentMode = DeploymentMode.Incremental,
            TemplateFile = this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
            TemplateObject = this.TemplateObject,
            TemplateParameterObject = this.GetTemplateParameterObject(this.TemplateParameterObject),
            ParameterUri = this.TemplateParameterUri,
            DeploymentDebugLogLevel = this.GetDeploymentDebugLogLevel(this.DeploymentDebugLogLevel),
            Tags = TagsHelper.ConvertToTagsDictionary(this.Tag)
        };

        protected override PSDeploymentWhatIfCmdletParameters WhatIfParameters => new PSDeploymentWhatIfCmdletParameters(
            DeploymentScopeType.ManagementGroup,
            managementGroupId: this.ManagementGroupId,
            deploymentName: this.Name,
            location: this.Location,
            mode: DeploymentMode.Incremental,
            templateUri: this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
            templateObject: this.TemplateObject,
            templateParametersUri: this.TemplateParameterUri,
            templateParametersObject: GetTemplateParameterObject(this.TemplateParameterObject),
            resultFormat: this.WhatIfResultFormat,
            excludeChangeTypes: this.WhatIfExcludeChangeType);
    }
}
