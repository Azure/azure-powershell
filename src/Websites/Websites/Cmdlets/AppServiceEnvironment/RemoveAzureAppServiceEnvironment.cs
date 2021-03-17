using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServiceEnvironment
{
    /// <summary>
    /// this commandlet will let you create a new Azure App Service Environment
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServiceEnvironment", SupportsShouldProcess = true, DefaultParameterSetName = InputValuesParameterSet), OutputType(typeof(Boolean))]
    public class RemoveAzureAppServiceEnvironmentCmdlet : WebAppBaseClientCmdLet
    {
        private const string InputValuesParameterSet = "InputValuesParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(ParameterSetName = InputValuesParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = InputValuesParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the app service environment.")]
        [ResourceNameCompleter("Microsoft.Web/hostingEnvironments", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return status.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The app service environment object")]
        [ValidateNotNullOrEmpty]
        public PSAppServiceEnvironment InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            var aseName = (ParameterSetName == InputValuesParameterSet) ? Name : InputObject.Name;
            var aseResourceGroup = (ParameterSetName == InputValuesParameterSet) ? ResourceGroupName : InputObject.ResourceGroupName;
            ConfirmAction(
                Force.IsPresent,
                string.Format("Are you sure you want to remove the app service environment '{0}'?", aseName),
                "Removing app service environment",
                aseName,
                () =>
                {
                    WebsitesClient.RemoveAppServiceEnvironment(aseResourceGroup, aseName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
