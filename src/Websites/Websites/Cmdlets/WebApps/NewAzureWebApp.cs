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

using Azure;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.WebApps.Strategies;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Azure.Commands.WebApps.Properties;
using Microsoft.Rest.Azure.OData;
using Microsoft.Azure.Commands.ResourceManager.Common.Utilities.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Security;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app using ARM APIs
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebApp", DefaultParameterSetName = SimpleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSite))]
    public class NewAzureWebAppCmdlet : WebAppBaseClientCmdLet
    {
        const string CopyWebAppParameterSet = "WebAppParameterSet";
        const string SimpleParameterSet = "SimpleParameterSet";
        const string PrivateRegistry = "PrivateRegistry";
        const int MaxFreeSites = 10;
        //private AppServicePlan Asp;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ParameterSetName = PrivateRegistry)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ParameterSetName = CopyWebAppParameterSet)]
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The name of the resource group.", ParameterSetName = SimpleParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [ValidateNotNullOrEmpty]
        [Alias("WebAppName")]
        public string Name { get; set; }

        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The Location of the web app eg: West US.", ParameterSetName = PrivateRegistry)]
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The Location of the web app eg: West US.", ParameterSetName = CopyWebAppParameterSet)]
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The Location of the web app eg: West US.", ParameterSetName = SimpleParameterSet)]
        [LocationCompleter("Microsoft.Web/sites", "Microsoft.Web/serverFarms")]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the app service plan eg: Default1.")]
        [ResourceNameCompleter("Microsoft.Web/serverfarms", "ResourceGroupName")]
        public string AppServicePlan { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The source web app to clone", ValueFromPipeline = true, ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSSite SourceWebApp { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Resource Id of existing traffic manager profile", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("TrafficManagerProfileName", "TrafficManagerProfileId")]
        public string TrafficManagerProfile { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Container Image Name and optional tag, for example (image:tag)", ParameterSetName = PrivateRegistry)]
        [Parameter(Mandatory = false, HelpMessage = "Container Image Name and optional tag, for example (image:tag)", ParameterSetName = SimpleParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ContainerImageName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Private Container Registry Server Url", ParameterSetName = PrivateRegistry)]
        [ValidateNotNullOrEmpty]
        public string ContainerRegistryUrl { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Private Container Registry Username", ParameterSetName = PrivateRegistry)]
        [ValidateNotNullOrEmpty]
        public string ContainerRegistryUser { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Private Container Registry Password", ParameterSetName = PrivateRegistry)]
        [ValidateNotNullOrEmpty]
        public SecureString ContainerRegistryPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables/Disables container continuous deployment webhook")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableContainerContinuousDeployment { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Ignore source control on source web app", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IgnoreSourceControl { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Ignore custom hostnames on source web app", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IgnoreCustomHostNames { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "Overrides all application settings in new web app. It works only with SourceWebApp parameter", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable AppSettingsOverrides { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "Application Service environment Name", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AseName { get; set; }

        [Parameter(Position = 8, Mandatory = false, HelpMessage = "Resource group of Application Service environment", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AseResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Clones slots associated with source web app", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeSourceWebAppSlots { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create WebApp in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Path to the GitHub repository containing the web application to deploy.", ParameterSetName = SimpleParameterSet)]
        public string GitRepositoryPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Tags are name/value pairs that enable you to categorize resources")]
        public Hashtable Tag { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                this.ExecuteSynchronouslyOrAsJob( (cmdlet) => cmdlet.ExecuteCmdletActions(this.SessionState));
            }
            catch (Exception ex) when (!IsTerminatingError(ex))
            {
                WriteExceptionError(ex);
            }
        }

        public override void ExecuteCmdlet()
        {

        }

        public void ExecuteCmdletActions(SessionState state)
        {
            if (ParameterSetName == SimpleParameterSet || ParameterSetName == PrivateRegistry)
            {
                ValidateWebAppName(Name);
                if (ShouldProcess(
                    string.Format(Properties.Resources.SimpleWebAppCreateTarget, Name),
                    Properties.Resources.SimpleWebAppCreateAction))
                {
                    this.StartAndWait(CreateWithSimpleParameters);
                }
            }
            else
            {
                if (ShouldProcess(
                    string.Format("WebApp '{0}' from WebApp '{1}'", Name, SourceWebApp?.Name),
                    "Copy"))
                {
                    CreateWithClonedWebApp();
                }
            }

        }

        private void ValidateWebAppName(string name)
        {
            if (!WebsitesClient.IsWebAppNameAvailable(name))
            {
                throw new InvalidOperationException(string.Format(
                    "Website name '{0}' is not available.  Please try a different name.", name));
            }
        }

        public void CreateWithClonedWebApp()
        {
            string trafficManagerProfielId = IsResource(TrafficManagerProfile) ? TrafficManagerProfile : null;
            string trafficManagerProfileName = IsResource(TrafficManagerProfile) ? null : TrafficManagerProfile;
            CloningInfo cloningInfo = null;
            if (SourceWebApp != null)
            {
                cloningInfo = new CloningInfo
                {
                    SourceWebAppId = SourceWebApp.Id,
                    CloneCustomHostNames = !IgnoreCustomHostNames.IsPresent,
                    SourceWebAppLocation = SourceWebApp.Location,
                    CloneSourceControl = !IgnoreSourceControl.IsPresent,
                    TrafficManagerProfileId = trafficManagerProfielId,
                    TrafficManagerProfileName = trafficManagerProfileName,
                    ConfigureLoadBalancing = !string.IsNullOrEmpty(TrafficManagerProfile),
                    AppSettingsOverrides = AppSettingsOverrides == null ? null : AppSettingsOverrides.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString(), StringComparer.Ordinal)
                };
                cloningInfo = new PSCloningInfo(cloningInfo);
            }

            var cloneWebAppSlots = false;
            string[] slotNames = null;
            string srcResourceGroupName = null;
            string srcwebAppName = null;
            string srcSlotName = null;
            if (IncludeSourceWebAppSlots.IsPresent)
            {
                CmdletHelpers.TryParseWebAppMetadataFromResourceId(SourceWebApp.Id, out srcResourceGroupName,
                    out srcwebAppName, out srcSlotName);
                var slots = WebsitesClient.ListWebApps(srcResourceGroupName, srcwebAppName);
                if (slots != null && slots.Any())
                {
                    slotNames = slots.Select(s => s.Name.Replace(srcwebAppName + "/", string.Empty)).ToArray();
                    cloneWebAppSlots = true;
                }
            }

            if (cloneWebAppSlots)
            {
                WriteVerboseWithTimestamp("Cloning source web app '{0}' to destination web app {1}", srcwebAppName, Name);
            }

            try
            {
                WriteObject(new PSSite(WebsitesClient.CreateWebApp(ResourceGroupName, Name, null, Location, AppServicePlan, cloningInfo, AseName, AseResourceGroupName, (IDictionary<string, string>)CmdletHelpers.ConvertToStringDictionary(Tag))));
            }
            catch (RequestFailedException e)
                when (e.Status == (int)System.Net.HttpStatusCode.BadRequest)
            {
                var message = e.Message + "\nIf AppServicePlan is present in other resourceGroup, please provide AppServicePlan in following format : \" /subscriptions/{subscriptionId}/resourcegroups/{resourcegroupName}/providers/Microsoft.Web/serverfarms/{serverFarmName}\"";
                WriteObject(message);
                throw new Exception(message, e);
            }

            if (cloneWebAppSlots)
            {
                WriteVerboseWithTimestamp("Cloning all deployment slots of source web app '{0}' to destination web app {1}", srcwebAppName, Name);
                CloneSlots(slotNames);
            }
        }
        private async Task<AppServicePlan> GetDefaultServerFarm(string location)
        {
            var websiteLocation = string.IsNullOrWhiteSpace(location) ? new LocationConstraint() : new LocationConstraint(location);
            var farmResources = await ResourcesClient.ResourceManagementClient.Resources.ListAsync(new ODataQuery<GenericResourceFilter>(r => r.ResourceType == "Microsoft.Web/serverFarms"));
            foreach (var resource in farmResources)
            {
                var id = new ResourceIdentifier(resource.Id);
                AppServicePlan farm;
                try
                {
                    farm = WebsitesClient.GetAppServicePlan(
                        id.ResourceGroupName,
                        id.ResourceName);
                }
                catch (RequestFailedException exception)
                    when (exception.Status == 404)
                {
                    continue;
                }

                if (websiteLocation.Match(farm.Location)
                    && string.Equals("free", farm.Sku?.Tier, StringComparison.OrdinalIgnoreCase)
                    && farm.NumberOfSites < MaxFreeSites)
                {
                    return farm;
                }
            }

            return null;
        }


        bool TryGetServerFarmFromResourceId(string serverFarm, out string resourceGroup, out string serverFarmName)
        {
            bool result = false;
            resourceGroup = null;
            serverFarmName = null;
            if (!string.IsNullOrEmpty(serverFarm) && serverFarm.ToLower().Contains("microsoft.web/serverfarms"))
            {
                var parts = serverFarm.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 7)
                {
                    resourceGroup = parts[3];
                    serverFarmName = parts[7];
                    result = !string.IsNullOrWhiteSpace(resourceGroup) && !string.IsNullOrWhiteSpace(serverFarmName);
                }
            }

            return result;
        }

        private string EnsureResourceGroup(
            string resourceGroupName,
            string location)
        {
            ResourceGroup resourceGroup = null;
            try
            {
                resourceGroup = ResourcesClient.ResourceManagementClient
                    .ResourceGroups
                    .Get(resourceGroupName);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
                when (exception.Response?.StatusCode ==
                      System.Net.HttpStatusCode.NotFound)
            {
            }

            if (resourceGroup != null)
            {
                return string.IsNullOrWhiteSpace(location)
                    ? resourceGroup.Location
                    : location;
            }

            string resourceGroupLocation = string.IsNullOrWhiteSpace(location)
                ? "eastus"
                : location;
            ResourcesClient.ResourceManagementClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup { Location = resourceGroupLocation });
            return resourceGroupLocation;
        }

        private SiteConfig GetNewConfig(AppServicePlan appServicePlan)
        {
            var siteConfig = new SiteConfig
            {
                AppSettings = new List<NameValuePair>()
            };
            bool hasConfiguration = false;

            if (ContainerImageName != null)
            {
                string containerImageName =
                    CmdletHelpers.DockerImagePrefix + ContainerImageName;
                if (appServicePlan == null ||
                    appServicePlan.IsXenon.GetValueOrDefault())
                {
                    siteConfig.WindowsFxVersion = containerImageName;
                    hasConfiguration = true;
                }
            }
            if (ContainerRegistryUrl != null)
            {
                siteConfig.AppSettings.Add(
                    new NameValuePair(
                        CmdletHelpers.DockerRegistryServerUrl,
                        ContainerRegistryUrl));
                hasConfiguration = true;
            }
            if (ContainerRegistryUser != null)
            {
                siteConfig.AppSettings.Add(
                    new NameValuePair(
                        CmdletHelpers.DockerRegistryServerUserName,
                        ContainerRegistryUser));
                hasConfiguration = true;
            }
            if (ContainerRegistryPassword != null)
            {
                siteConfig.AppSettings.Add(
                    new NameValuePair(
                        CmdletHelpers.DockerRegistryServerPassword,
                        ContainerRegistryPassword.ConvertToString()));
                hasConfiguration = true;
            }
            if (EnableContainerContinuousDeployment.IsPresent)
            {
                siteConfig.AppSettings.Add(
                    new NameValuePair(CmdletHelpers.DockerEnableCI, "true"));
                hasConfiguration = true;
            }

            return hasConfiguration ? siteConfig : null;
        }

        public async Task CreateWithSimpleParameters(IAsyncCmdlet adapter)
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = Name;
            }

            string planResourceGroup = ResourceGroupName;
            string planName = AppServicePlan ?? Name;
            AppServicePlan existingPlan = null;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(AppServicePlan)))
            {
                if (!TryGetServerFarmFromResourceId(
                        AppServicePlan,
                        out planResourceGroup,
                        out planName))
                {
                    planResourceGroup = ResourceGroupName;
                    planName = AppServicePlan;
                }
            }
            else
            {
                existingPlan = await GetDefaultServerFarm(Location);
                if (existingPlan != null)
                {
                    planResourceGroup = existingPlan.ResourceGroup;
                    planName = existingPlan.Name;
                }
            }

            if (existingPlan == null)
            {
                try
                {
                    existingPlan = WebsitesClient.GetAppServicePlan(
                        planResourceGroup,
                        planName);
                }
                catch (RequestFailedException exception)
                    when (exception.Status == 404)
                {
                }
            }

            if (existingPlan == null)
            {
                Location = EnsureResourceGroup(ResourceGroupName, Location);
                if (!string.Equals(
                        planResourceGroup,
                        ResourceGroupName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    EnsureResourceGroup(planResourceGroup, Location);
                }
                bool isXenon = ContainerImageName != null;
                string tier = isXenon ? "PremiumContainer" : "Basic";
                existingPlan = WebsitesClient.CreateOrUpdateAppServicePlan(
                    planResourceGroup,
                    planName,
                    new AppServicePlan
                    {
                        Location = Location,
                        IsXenon = isXenon,
                        Sku = new SkuDescription
                        {
                            Tier = tier,
                            Capacity = 1,
                            Name = CmdletHelpers.GetSkuName(tier, 1)
                        }
                    });
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Location))
                {
                    Location = existingPlan.Location;
                }
                Location = EnsureResourceGroup(ResourceGroupName, Location);
            }

            AppServicePlan = existingPlan.Id;
            SiteConfig newConfig = GetNewConfig(existingPlan);
            try
            {
                WebsitesClient.GetWebApp(
                    ResourceGroupName,
                    Name,
                    null);
            }
            catch (RequestFailedException exception)
                when (exception.Status == 404)
            {
            }

            var output = new PSSite(
                WebsitesClient.CreateWebApp(
                    ResourceGroupName,
                    Name,
                    null,
                    Location,
                    existingPlan.Id,
                    null,
                    null,
                    null,
                    (IDictionary<string, string>)
                        CmdletHelpers.ConvertToStringDictionary(Tag),
                    siteConfig: newConfig));

            string userName = null, password = null;
            try
            {
                var scmHostName = output.EnabledHostNames.FirstOrDefault(s => s.Contains(".scm."));
                if (!string.IsNullOrWhiteSpace(scmHostName))
                {
                    string profile = WebsitesClient.GetWebAppPublishingProfile(
                        ResourceGroupName,
                        Name,
                        null,
                        null,
                        "WebDeploy",
                        null);
                    var doc = new XmlDocument();
                    doc.LoadXml(profile);
                    userName = doc.SelectSingleNode("//publishProfile[@publishMethod=\"MSDeploy\"]/@userName").Value;
                    password = doc.SelectSingleNode("//publishProfile[@publishMethod=\"MSDeploy\"]/@userPWD").Value;
                    var newOutput = new PSSite(output)
                    {
                        GitRemoteUri = $"https://{scmHostName}",
                        GitRemoteUsername =userName,
                        GitRemotePassword = SecureStringExtensions.ConvertToSecureString(password)
                    };
                    output = newOutput;
                    var git = new GitCommand(SessionState.Path, GitRepositoryPath);
                    var repository = await git.VerifyGitRepository();
                    if (repository != null)
                    {
                        if (!await git.CheckExistence())
                        {
                            adapter.WriteWarning(git.InstallationInstructions);
                        }
                        else if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
                        {
                            await git.AddRemoteRepository("azure", $"https://{userName}:{password}@{scmHostName}");
                            adapter.WriteVerbose(Properties.Resources.GitRemoteMessage);
                            newOutput.GitRemoteName = "azure";
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // do not write errors for problems with adding git repository
                var repoPath = GitRepositoryPath ?? SessionState?.Path?.CurrentFileSystemLocation?.Path;
                adapter.WriteWarning(string.Format(
                    Properties.Resources.GitRemoteAddFailure,
                    repoPath,
                    exception.Message));
            }
            adapter.WriteObject(new PSSite(output));
        }


        private bool IsResource(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Contains("/");
        }

        private void CloneSlots(string[] slotNames)
        {
            var hostingEnvironmentProfile = WebsitesClient.CreateHostingEnvironmentProfile(ResourceGroupName, AseResourceGroupName, AseName);
            var template = DeploymentTemplateHelper.CreateSlotCloneDeploymentTemplate(Location, AppServicePlan, Name, SourceWebApp.Id,
                slotNames, hostingEnvironmentProfile, WebsitesClient.ApiVersion);

            var deployment = new Management.Internal.Resources.Models.Deployment
            {
                Properties = new DeploymentProperties
                {
                    Mode = DeploymentMode.Incremental,
                    Template = template
                }
            };

            var deploymentName = string.Format("CloneSlotsFor{0}", Name);
            ResourcesClient.ResourceManagementClient.Deployments.CreateOrUpdate(ResourceGroupName, deploymentName, deployment);
            var result = ResourcesClient.ProvisionDeploymentStatus(ResourceGroupName, deploymentName, deployment);
            WriteObject(result.ToPSResourceGroupDeployment(ResourceGroupName));
        }
    }
}
