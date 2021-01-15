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
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServiceEnvironment", SupportsShouldProcess = true)]
    public class RemoveAzureAppServiceEnvironmentCmdlet : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the app service environment.")]
        [ResourceNameCompleter("Microsoft.Web/hostingEnvironments", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format("Are you sure you want to remove the app service environment '{0}'?", Name),
                "Removing app service environment",
                Name,
                () =>
                {
                    WebsitesClient.RemoveAppServiceEnvironment(ResourceGroupName, Name);
                });
        }
    }
}
