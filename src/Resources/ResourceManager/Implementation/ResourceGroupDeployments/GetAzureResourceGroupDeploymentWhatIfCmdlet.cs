namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentWhatIf",
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName),
    OutputType(typeof(PSWhatIfOperationResult))]
    public class GetAzureResourceGroupDeploymentWhatIfCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
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

        public override void ExecuteCmdlet()
        {
            const string statusMessage = "Getting the latest status of all resources...";
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };

            try
            {
                // Write status message.
                this.WriteInformation(information, tags);

                var parameters = new PSDeploymentWhatIfCmdletParameters
                {
                    DeploymentName = this.Name,
                    Mode = this.Mode,
                    ResourceGroupName = this.ResourceGroupName,
                    TemplateUri = TemplateUri ?? this.TryResolvePath(TemplateFile),
                    TemplateObject = this.TemplateObject,
                    TemplateParametersUri = this.TemplateParameterUri,
                    TemplateParametersObject = GetTemplateParameterObject(this.TemplateParameterObject),
                    ResultFormat = this.ResultFormat
                };

                PSWhatIfOperationResult whatIfResult = ResourceManagerSdkClient.ExecuteDeploymentWhatIf(parameters);

                // Clear status before returning result.
                this.WriteInformation(clearInformation, tags);
                this.WriteObject(whatIfResult);
            }
            catch (CloudException ce)
            {
                // Clear status before handling exception.
                this.WriteInformation(clearInformation, tags);
                this.HandleException(ce);
            }
            catch (Exception e)
            {
                // Clear status before handling exception.
                this.WriteInformation(clearInformation, tags);
                this.HandleException(e);
            }
        }
    }
}
