namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System;
    using System.Management.Automation;
    using Common;
    using Common.ArgumentCompleters;
    using Management.ResourceManager.Models;
    using Microsoft.Rest.Azure;
    using SdkModels.Deployments;
    using WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Gets What-If results for a deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "DeploymentWhatIf",
         DefaultParameterSetName = ParameterlessTemplateFileParameterSetName),
     OutputType(typeof(PSWhatIfOperationResult))]
    [Alias("Get-AzSubscriptionDeploymentWhatIf")]
    public class GetAzureSubscriptionDeploymentWhatIfCmdlet : ResourceWithParameterCmdletBase, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false, HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The What-If result format.")]
        public WhatIfResultFormat ResultFormat { get; set; } = WhatIfResultFormat.FullResourcePayloads;
        public object ProjectResources { get; private set; }

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
                    Location = this.Location,
                    Mode = DeploymentMode.Incremental,
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
