﻿// ----------------------------------------------------------------------------------
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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentWhatIfResult",
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName),
    OutputType(typeof(PSWhatIfOperationResult))]
    public class GetAzureResourceGroupDeploymentWhatIfResultCmdlet : DeploymentWhatIfCmdlet
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deployment it's going to create. If not specified, defaults to the template file name when a template file is provided; defaults to the current time when a template object is provided, e.g. \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; } = DeploymentMode.Incremental;

        [Parameter(Mandatory = false, HelpMessage = "The What-If result format.")]
        public WhatIfResultFormat ResultFormat { get; set; } = WhatIfResultFormat.FullResourcePayloads;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated resource change types to be excluded from What-If results.")]
        [ChangeTypeCompleter]
        [ValidateChangeTypes]
        public string[] ExcludeChangeType { get; set; }

        protected override PSDeploymentWhatIfCmdletParameters WhatIfParameters => new PSDeploymentWhatIfCmdletParameters(
            DeploymentScopeType.ResourceGroup,
            deploymentName: this.Name,
            mode: this.Mode,
            resourceGroupName: this.ResourceGroupName,
            templateUri: this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
            templateObject: this.TemplateObject,
            templateSpecId: TemplateSpecId,
            templateParametersUri: this.TemplateParameterUri,
            templateParametersObject: GetTemplateParameterObject(this.TemplateParameterObject),
            resultFormat: this.ResultFormat,
            excludeChangeTypes: this.ExcludeChangeType);
    }
}
