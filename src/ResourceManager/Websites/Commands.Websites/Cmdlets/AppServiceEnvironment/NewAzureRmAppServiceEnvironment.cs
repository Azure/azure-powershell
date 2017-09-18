using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServiceEnvironment
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAppServiceEnvironment", DefaultParameterSetName = ParameterSet1Name)]
    public class NewAzureRmAppServiceEnvironment : ResourceWithParameterCmdletBase
    {
        public const string WindowsTemplateRelativePath = @"Template\Windows";
        public const string TemplateFileName = @"azuredeploy.json";
        public const string ParameterFileName = @"azuredeploy.parameters.json";
        public const string IlbTemplateFileName = @"ilb.azuredeploy.json";
        public const string IlbParameterFileName = @"ilb.azuredeploy.parameters.json";

        const string ParameterSet1Name = "S1";
        const string ParameterSet2Name = "S2";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the app service environment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The Location of the app service environment eg: West US.")]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "ARM Url reference for the virtual network that will contain the ASE.  Only Microsoft.Network is supported for ASEv2.")]
        public string VNet { get; set; }

        [Parameter(Position = 4, Mandatory = true, HelpMessage = "Subnet name that will contain the App Service Environment.")]
        public string Subnet { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Subnet name that will contain the App Service Environment.")]
        [ValidateSet("External", "ILB", IgnoreCase = true)]
        public string ASETYPE { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Used *only* when deploying an ILB enabled ASE.  Set this to the root domain associated with the ASE.  For example: contoso.com")]
        public string ILBASEDomain { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; }


        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment debug log level.")]
        [ValidateSet("RequestContent", "ResponseContent", "All", "None", IgnoreCase = true)]
        public string DeploymentDebugLogLevel { get; set; }

        public override void ExecuteCmdlet()
        {
            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            bool isIlb = !string.IsNullOrWhiteSpace(ASETYPE) && (ASETYPE.ToLower() == "ilb");

            TemplateFile = Path.Combine(assemblyFolder, WindowsTemplateRelativePath, isIlb ? IlbTemplateFileName : TemplateFileName);
            TemplateParameterFile = Path.Combine(assemblyFolder, WindowsTemplateRelativePath, isIlb ? IlbParameterFileName : ParameterFileName);

            var tempParameterFileName = "azuredeploy.parameters" + Guid.NewGuid() + ".json";

            var tempParameterFilePath = Path.Combine(Path.GetTempPath(), tempParameterFileName);

            string parameterFileContent = File.ReadAllText(TemplateParameterFile);

            parameterFileContent = parameterFileContent.Replace("{aseName}", Name).Replace("{location}", Location)
                .Replace("{subscription}", DefaultContext.Subscription.Id).Replace("{resourcegroup}", ResourceGroupName)
                .Replace("{vnet}", VNet).Replace("{subnet}", Subnet).Replace("{dnssuffix}", ILBASEDomain);

            File.WriteAllText(tempParameterFilePath, parameterFileContent);
            TemplateParameterFile = tempParameterFilePath;

            this.ConfirmAction(
                this.Force,
                string.Format(Properties.Resources.ConfirmOnCompleteDeploymentMode, this.ResourceGroupName),
                Properties.Resources.CreateDeployment,
                ResourceGroupName,
                () =>
                {
                    PSCreateResourceGroupDeploymentParameters parameters = new PSCreateResourceGroupDeploymentParameters
                        ()
                    {
                        ResourceGroupName = ResourceGroupName,
                        DeploymentName = Name,
                        DeploymentMode = Mode,
                        TemplateFile = this.TryResolvePath(TemplateFile),
                        TemplateParameterObject = GetTemplateParameterObject(TemplateParameterObject),
                        ParameterUri = tempParameterFilePath,
                        DeploymentDebugLogLevel = GetDeploymentDebugLogLevel(DeploymentDebugLogLevel)
                    };

                    if (!string.IsNullOrEmpty(parameters.DeploymentDebugLogLevel))
                    {
                        WriteWarning(Properties.Resources.WarnOnDeploymentDebugSetting);
                    }
                    WriteObject(ResourceManagerSdkClient.ExecuteDeployment(parameters));
                },
                () => this.Mode == DeploymentMode.Complete);
        }

    }
    
}
