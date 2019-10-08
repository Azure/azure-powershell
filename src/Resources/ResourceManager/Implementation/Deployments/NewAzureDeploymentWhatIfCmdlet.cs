namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Deployments
{
    using System;
    using System.Management.Automation;
    using Common.ArgumentCompleters;
    using Formatters;
    using Management.ResourceManager.Models;
    using SdkModels.Deployments;
    using WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Creates a new deployment what-if.
    /// </summary>
    [Cmdlet(VerbsCommon.New,
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentWhatIf", SupportsShouldProcess = true,
         DefaultParameterSetName = SubscriptionAndTenantParameterSetWithParameterlessTemplateFile),
     OutputType(typeof(PSWhatIfOperationResult))]
    public class NewAzureDeploymentWhatIfCmdlet : DeploymentCmdletWithParameters, IDynamicParameters
    {
        [Alias("DeploymentName")]
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the deployment it's going to create. Only valid when a template is used. When a template is used, if the user doesn't specify a deployment name, use the current time, like \"20131223140835\".")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The deployment scope type.")]
        public DeploymentWhatIfScopeType ScopeType { get; set; }

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
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "The result format.")]
        public WhatIfResultFormat ResultFormat { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            var parameters = new PSDeploymentWhatIfCmdletParameters
            {
                DeploymentName = this.Name,
                Location = this.Location,
                ScopeType = this.ScopeType,
                Mode = this.Mode,
                ResourceGroupName = this.ResourceGroupName,
                TemplateUri = Uri.IsWellFormedUriString(this.TemplateFile, UriKind.Absolute)
                    ? this.TemplateFile
                    : this.TryResolvePath(this.TemplateFile),
                TemplateParametersUri = this.TemplateParameterFile,
                TemplateObject = this.TemplateObject,
                TemplateParametersObject = this.GetTemplateParameterObject(this.TemplateParameterObject),
                ResultFormat = this.ResultFormat
            };

            try
            {
                parameters.Validate();
            }
            catch (Exception e)
            {
                WriteExceptionError(e);
            }

            // Write status.
            var statusMessage = "- Running... -";
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var tags = new[] { "PSHOST" };
            this.WriteInformation(information, tags);

            PSWhatIfOperationResult result = ResourceManagerSdkClient.ExecuteDeploymentWhatIf(parameters);

            // Clear status before writing result.
            var clearMessage = new string(' ', statusMessage.Length);
            information = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            this.WriteInformation(information, tags);

            this.WriteObject(result);
        }
    }
}
