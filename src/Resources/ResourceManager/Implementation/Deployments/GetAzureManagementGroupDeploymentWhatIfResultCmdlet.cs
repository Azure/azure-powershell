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
    using System.Management.Automation;
    using Common;
    using Common.ArgumentCompleters;
    using Management.Resources.Models;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Gets What-If results for a tenant-level deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentWhatIfResult",
         DefaultParameterSetName = ParameterlessTemplateFileParameterSetName),
     OutputType(typeof(PSWhatIfOperationResult))]
    public class GetAzureManagementGroupDeploymentWhatIfResultCmdlet : DeploymentWhatIfCmdlet
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, HelpMessage = "The name of the deployment it's going to create. If not specified, defaults to the template file name when a template file is provided; defaults to the current time when a template object is provided, e.g. \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The management group ID.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The What-If result format.")]
        public WhatIfResultFormat ResultFormat { get; set; } = WhatIfResultFormat.FullResourcePayloads;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated list of resource change types to be excluded from What-If results.")]
        [ChangeTypeCompleter]
        [ValidateChangeTypes]
        public string[] ExcludeChangeType { get; set; }

        protected override PSDeploymentWhatIfCmdletParameters BuildWhatIfParameters() => new PSDeploymentWhatIfCmdletParameters(
            scopeType: DeploymentScopeType.ManagementGroup,
            managementGroupId: this.ManagementGroupId,
            deploymentName: this.Name,
            location: this.Location,
            mode: DeploymentMode.Incremental,
            templateUri: this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
            templateObject: this.TemplateObject,
            templateParametersUri: this.TemplateParameterUri,
            templateParametersObject: GetTemplateParameterObject(),
            resultFormat: this.ResultFormat,
            excludeChangeTypes: this.ExcludeChangeType,
            validationLevel: this.ValidationLevel);
    }
}


