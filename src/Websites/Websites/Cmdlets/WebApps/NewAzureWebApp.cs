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

using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Common.Strategies.Resources;
using Microsoft.Azure.Commands.Common.Strategies.WebApps;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.WebApps.Strategies;
using System.Threading;
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

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "Overrides all application settings in new web app", ParameterSetName = CopyWebAppParameterSet)]
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

        [Parameter(Mandatory = false, HelpMessage = "Path to the GitHub repository containign the web application to deploy.", ParameterSetName = SimpleParameterSet)]
        public string GitRepositoryPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Tags are name/value pairs that enable you to categorize resources", ParameterSetName = SimpleParameterSet)]
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
            var available = WebsitesClient.WrappedWebsitesClient.CheckNameAvailability(name,"Site");
            if (available.NameAvailable.HasValue && !available.NameAvailable.Value)
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
                WriteObject(new PSSite(WebsitesClient.CreateWebApp(ResourceGroupName, Name, null, Location, AppServicePlan, cloningInfo, AseName, AseResourceGroupName)));
            }
            catch (Exception e)
            {
                if(e.Message.Contains("Operation returned an invalid status code \'BadRequest\'"))
                {
                    var message = e.Message + "\nIf AppServicePlan is present in other resourceGroup, please provide AppServicePlan in following format : \" /subscriptions/{subscriptionId}/resourcegroups/{resourcegroupName}/providers/Microsoft.Web/serverfarms/{serverFarmName}\"";
                    WriteObject(message);
                    throw new Exception(message, e);
                }
                throw e;
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
            AppServicePlan defaultFarm = null;
            foreach (var resource in farmResources)
            {
                // Try to find a policy with Sku=Free and available site capacity
                var id = new ResourceIdentifier(resource.Id);
                var farm = await WebsitesClient.WrappedWebsitesClient.AppServicePlans.GetAsync(id.ResourceGroupName, id.ResourceName);
                if (websiteLocation.Match(farm.Location)
                    && string.Equals("free", farm.Sku?.Tier?.ToLower(), StringComparison.OrdinalIgnoreCase)
                    && farm.NumberOfSites < MaxFreeSites)
                {
                    defaultFarm = farm;
                    break;
                }

            }

            return defaultFarm;
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

        sealed class Parameters : IParameters<Site>
        {
            readonly NewAzureWebAppCmdlet _cmdlet;
            readonly WebsitesClient _websitesClient;

            public Parameters(NewAzureWebAppCmdlet cmdlet, WebsitesClient websitesClient)
            {
                _cmdlet = cmdlet;
                _websitesClient = websitesClient;
            }

            public string DefaultLocation => "eastus";

            public string Location
            {
                get { return _cmdlet.Location; }
                set { _cmdlet.Location = value; }
            }
            private SiteConfig GetNewConfig(AppServicePlan appServiceplan)
            {
                bool newConfigAdded = false;
                SiteConfig siteConfig = new SiteConfig();
                siteConfig.AppSettings = new List<NameValuePair>();

                string containerImageName = _cmdlet.ContainerImageName;
                if (containerImageName != null)
                {
                    containerImageName = CmdletHelpers.DockerImagePrefix + containerImageName;
                    if (appServiceplan == null || appServiceplan.IsXenon.GetValueOrDefault())
                    {
                        siteConfig.WindowsFxVersion = containerImageName;
                        newConfigAdded = true;
                    }
                }
                if (_cmdlet.ContainerRegistryUrl != null)
                {
                    siteConfig.AppSettings.Add(new NameValuePair(CmdletHelpers.DockerRegistryServerUrl, _cmdlet.ContainerRegistryUrl));
                    newConfigAdded = true;
                }
                if (_cmdlet.ContainerRegistryUser != null)
                {
                    siteConfig.AppSettings.Add(new NameValuePair(CmdletHelpers.DockerRegistryServerUserName, _cmdlet.ContainerRegistryUser));
                    newConfigAdded = true;
                }
                if (_cmdlet.ContainerRegistryPassword != null)
                {
                    siteConfig.AppSettings.Add(new NameValuePair(CmdletHelpers.DockerRegistryServerPassword, _cmdlet.ContainerRegistryPassword.ConvertToString()));
                    newConfigAdded = true;
                }
                if (_cmdlet.EnableContainerContinuousDeployment.IsPresent)
                {
                    siteConfig.AppSettings.Add(new NameValuePair(CmdletHelpers.DockerEnableCI, "true"));
                    newConfigAdded = true;
                }
                return newConfigAdded ? siteConfig : null;
            }
            public async Task<ResourceConfig<Site>> CreateConfigAsync()
            {
                _cmdlet.ResourceGroupName = _cmdlet.ResourceGroupName ?? _cmdlet.Name;
                _cmdlet.AppServicePlan = _cmdlet.AppServicePlan ?? _cmdlet.Name;

                var planResourceGroup = _cmdlet.ResourceGroupName;
                var planName = _cmdlet.AppServicePlan;

                var rgStrategy = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var planRG = rgStrategy;
                if (_cmdlet.MyInvocation.BoundParameters.ContainsKey(nameof(AppServicePlan)))
                {
                    if (!_cmdlet.TryGetServerFarmFromResourceId(_cmdlet.AppServicePlan, out planResourceGroup, out planName))
                    {
                        planResourceGroup = _cmdlet.ResourceGroupName;
                        planName = _cmdlet.AppServicePlan;
                    }

                    planRG = ResourceGroupStrategy.CreateResourceGroupConfig(planResourceGroup);
                }
                else
                {
                    var farm = await _cmdlet.GetDefaultServerFarm(Location);
                    if (farm != null)
                    {
                        planResourceGroup = farm.ResourceGroup;
                        planName = farm.Name;
                        planRG = ResourceGroupStrategy.CreateResourceGroupConfig(planResourceGroup);
                    }
                }
                AppServicePlan appServiceplan = _websitesClient.GetAppServicePlan(planResourceGroup, planName);

                // If ContainerImageName is specified and appservice plan doesn’t exist (appServiceplan == null) we will try to create plan with windows container 
                var farmStrategy = planRG.CreateServerFarmConfig(planResourceGroup, planName, appServiceplan == null && _cmdlet.ContainerImageName != null);

                return rgStrategy.CreateSiteConfig(farmStrategy, _cmdlet.Name, this.GetNewConfig(appServiceplan)
                    , (IDictionary<string, string>)CmdletHelpers.ConvertToStringDictionary(_cmdlet.Tag));
            }
        }

        public async Task CreateWithSimpleParameters(IAsyncCmdlet adapter)
        {
            var parameters = new Parameters(this, WebsitesClient);
            var client = new WebClient(DefaultContext);
            var output = await client.RunAsync(client.SubscriptionId, parameters, adapter);

            output.SiteConfig = WebsitesClient
                .WrappedWebsitesClient
                .WebApps()
                .GetConfiguration(output.ResourceGroup, output.Name)
                .ConvertToSiteConfig();

            try
            {
                var appSettings = WebsitesClient
                    .WrappedWebsitesClient
                    .WebApps()
                    .ListApplicationSettings(output.ResourceGroup, output.Name);
                output.SiteConfig.AppSettings = appSettings
                    .Properties
                    .Select(s => new NameValuePair { Name = s.Key, Value = s.Value })
                    .ToList();
                var connectionStrings = WebsitesClient.WrappedWebsitesClient.WebApps().ListConnectionStrings(
                    output.ResourceGroup, output.Name);
                output.SiteConfig.ConnectionStrings = connectionStrings
                    .Properties
                    .Select(s => new ConnStringInfo()
                    {
                        Name = s.Key,
                        ConnectionString = s.Value.Value,
                        Type = s.Value.Type
                    }).ToList();
            }
            catch
            {
                //ignore if this call fails as it will for reader RBAC
            }

            string userName = null, password = null;
            try
            {
                var scmHostName = output.EnabledHostNames.FirstOrDefault(s => s.Contains(".scm."));
                if (!string.IsNullOrWhiteSpace(scmHostName))
                {
                    var profile = await WebsitesClient.WrappedWebsitesClient.WebApps.ListPublishingProfileXmlWithSecretsAsync(output.ResourceGroup, output.Name, new CsmPublishingProfileOptions { Format = "WebDeploy" });
                    var doc = new XmlDocument();
                    doc.Load(profile);
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
                slotNames, hostingEnvironmentProfile, WebsitesClient.WrappedWebsitesClient.ApiVersion());

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
