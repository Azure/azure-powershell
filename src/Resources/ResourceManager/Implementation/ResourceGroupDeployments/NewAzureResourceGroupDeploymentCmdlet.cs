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
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Creates a new resource group deployment.
    /// </summary>
    [Cmdlet("New", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeployment",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSResourceGroupDeployment))]
    public class NewAzureResourceGroupDeploymentCmdlet : DeploymentCreateCmdlet
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

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment debug log level.")]
        [ValidateSet("RequestContent", "ResponseContent", "All", "None", IgnoreCase = true)]
        public string DeploymentDebugLogLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rollback to the last successful deployment in the resource group, should not be present if -RollBackDeploymentName is used.")]
        public SwitchParameter RollbackToLastDeployment { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Rollback to the successful deployment with the given name in the resource group, should not be used if -RollbackToLastDeployment is used.")]
        public string RollBackDeploymentName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags to put on the deployment.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The What-If result format. Applicable when the -WhatIf or -Confirm switch is set.")]
        public WhatIfResultFormat WhatIfResultFormat { get; set; } = WhatIfResultFormat.FullResourcePayloads;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated resource change types to be excluded from What-If results. Applicable when the -WhatIf or -Confirm switch is set.")]
        [ChangeTypeCompleter]
        [ValidateChangeTypes]
        public string[] WhatIfExcludeChangeType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override ConfirmImpact ConfirmImpact => ((CmdletAttribute)Attribute.GetCustomAttribute(
            typeof(NewAzureResourceGroupDeploymentCmdlet),
            typeof(CmdletAttribute))).ConfirmImpact;

        protected override PSDeploymentCmdletParameters DeploymentParameters => new PSDeploymentCmdletParameters
        {
            ScopeType = DeploymentScopeType.ResourceGroup,
            ResourceGroupName = ResourceGroupName,
            DeploymentName = Name,
            DeploymentMode = Mode,
            TemplateFile = TemplateUri ?? this.TryResolvePath(TemplateFile),
            TemplateObject = TemplateObject,
            TemplateSpecId = TemplateSpecId,
            QueryString = QueryString,
            TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
            ParameterUri = TemplateParameterUri,
            DeploymentDebugLogLevel = GetDeploymentDebugLogLevel(DeploymentDebugLogLevel),
            Tags = TagsHelper.ConvertToTagsDictionary(Tag),
            OnErrorDeployment = RollbackToLastDeployment || !string.IsNullOrEmpty(RollBackDeploymentName)
                ? new OnErrorDeployment
                {
                    Type = RollbackToLastDeployment ? OnErrorDeploymentType.LastSuccessful : OnErrorDeploymentType.SpecificDeployment,
                    DeploymentName = RollbackToLastDeployment ? null : RollBackDeploymentName
                }
                : null
        };

        protected override PSDeploymentWhatIfCmdletParameters WhatIfParameters => new PSDeploymentWhatIfCmdletParameters(
            DeploymentScopeType.ResourceGroup,
            deploymentName: this.Name,
            mode: this.Mode,
            queryString: this.QueryString,
            resourceGroupName: this.ResourceGroupName,
            templateUri: this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
            templateObject: this.TemplateObject,
            templateSpecId: TemplateSpecId,
            templateParametersUri: this.TemplateParameterUri,
            templateParametersObject: this.GetTemplateParameterObject(this.TemplateParameterObject),
            resultFormat: this.WhatIfResultFormat,
            excludeChangeTypes: this.WhatIfExcludeChangeType); 

        protected override void OnProcessRecord()
        {
            if (this.RollbackToLastDeployment && !string.IsNullOrEmpty(this.RollBackDeploymentName))
            {
                this.WriteExceptionError(new ArgumentException(Properties.Resources.InvalidRollbackParameters));
            }

            if (!this.Force && this.ShouldExecuteWhatIf())
            {
                base.OnProcessRecord();
            }
            else
            {
                this.ConfirmAction(
                    this.Force,
                    string.Format(Properties.Resources.ConfirmOnCompleteDeploymentMode, this.ResourceGroupName),
                    Properties.Resources.CreateDeployment,
                    this.ResourceGroupName,
                    this.ExecuteDeployment,
                    () => this.Mode == DeploymentMode.Complete);
            }
        }
    }
}
