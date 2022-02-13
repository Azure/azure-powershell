using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServiceEnvironment
{
    /// <summary>
    /// this commandlet will let you create a new Azure App Service Environment
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServiceEnvironment", SupportsShouldProcess = true), OutputType(typeof(PSAppServiceEnvironment))]
    public class GetAzureAppServiceEnvironmentCmdlet : WebAppBaseClientCmdLet
    {
        private const string NameParameterSet = "NameParameterSet";

        [Parameter(ParameterSetName = NameParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NameParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the app service environment.")]
        [ResourceNameCompleter("Microsoft.Web/hostingEnvironments", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]

        public string Name { get; set; }
        public override void ExecuteCmdlet()
        {
            var ase = WebsitesClient.GetAppServiceEnvironment(ResourceGroupName, Name);
            WriteObject(new PSAppServiceEnvironment(ase), true);
        }
    }
}
