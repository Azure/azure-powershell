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

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmWebApp", DefaultParameterSetName = SimpleParameterSet, SupportsShouldProcess = true), OutputType(typeof(Site))]
    public class NewAzureWebAppCmdlet : WebAppBaseClientCmdLet
    {
        const string CopyWebAppParameterSet = "WebAppParameterSet";
        const string SimpleParameterSet = "SimpleParameterSet";
        const int MaxFreeSites = 10;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ParameterSetName = CopyWebAppParameterSet)]
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The name of the resource group.", ParameterSetName = SimpleParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [ValidateNotNullOrEmpty]
        [Alias("WebAppName")]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The Location of the web app eg: West US.", ParameterSetName = CopyWebAppParameterSet)]
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The Location of the web app eg: West US.", ParameterSetName = SimpleParameterSet)]
        [LocationCompleter("Microsoft.Web/sites", "Microsoft.Web/serverFarms")]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the app service plan eg: Default1.")]
        public string AppServicePlan { get; set; }

        [Parameter(Position = 4, Mandatory = true, HelpMessage = "The source web app to clone", ValueFromPipeline = true, ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        public Site SourceWebApp { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Resource Id of existing traffic manager profile", ParameterSetName = CopyWebAppParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("TrafficManagerProfileName", "TrafficManagerProfileId")]
        public string TrafficManagerProfile { get; set; }


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
            if (ParameterSetName == SimpleParameterSet)
            {
                ValidateWebAppName(Name);
                if (ShouldProcess(string.Format(Microsoft.Azure.Commands.WebApps.Properties.Resources.SimpleWebAppCreateTarget, Name), Microsoft.Azure.Commands.WebApps.Properties.Resources.SimpleWebAppCreateAction))
                {
                    var adapter = new PSCmdletAdapter(this, state);
                    adapter.WaitForCompletion(CreateWithSimpleParameters);
                }
            }
            else
            {
                if (ShouldProcess(string.Format("WebApp '{0}' from WebApp '{1}'", Name, SourceWebApp?.Name), "Copy"))
                {
                    CreateWithClonedWebApp();
                }
            }

        }

        private void ValidateWebAppName(string name)
        {
#if !NETSTANDARD
            var available = WebsitesClient.WrappedWebsitesClient.GlobalModel.CheckNameAvailability(new ResourceNameAvailabilityRequest { Name = name, Type = "Site" });
            if (available.NameAvailable.HasValue && !available.NameAvailable.Value)
            {
                throw new InvalidOperationException(string.Format("Website name '{0}' is not available.  Please try a different name.", name));
            }
#else
            var available = WebsitesClient.WrappedWebsitesClient.CheckNameAvailability(name,"Site");
            if (available.NameAvailable.HasValue && !available.NameAvailable.Value)
            {
                throw new InvalidOperationException(string.Format("Website name '{0}' is not available.  Please try a different name.", name));
            }
#endif
        }

        public void CreateWithClonedWebApp()
        {
            string trafficManagerProfielId = IsResource(TrafficManagerProfile) ? TrafficManagerProfile : null;
            string trafficManagerProfileName = IsResource(TrafficManagerProfile) ? null : TrafficManagerProfile;
            CloningInfo cloningInfo = new CloningInfo
            {
                SourceWebAppId = SourceWebApp.Id,
                CloneCustomHostNames = !IgnoreCustomHostNames.IsPresent,
                CloneSourceControl = !IgnoreSourceControl.IsPresent,
                TrafficManagerProfileId = trafficManagerProfielId,
                TrafficManagerProfileName = trafficManagerProfileName,
                ConfigureLoadBalancing = !string.IsNullOrEmpty(TrafficManagerProfile),
                AppSettingsOverrides = AppSettingsOverrides == null ? null : AppSettingsOverrides.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString(), StringComparer.Ordinal)
            };

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

            WriteObject(WebsitesClient.CreateWebApp(ResourceGroupName, Name, null, Location, AppServicePlan, cloningInfo, AseName, AseResourceGroupName));

            if (cloneWebAppSlots)
            {
                WriteVerboseWithTimestamp("Cloning all deployment slots of source web app '{0}' to destination web app {1}", srcwebAppName, Name);
                CloneSlots(slotNames);
            }
        }
#if !NETSTANDARD
        private async Task<ServerFarmWithRichSku> GetDefaultServerFarm(string location)
        {
            var websiteLocation = string.IsNullOrWhiteSpace(location) ? new LocationConstraint() : new LocationConstraint(location);
            var farmResources = await ResourcesClient.ResourceManagementClient.Resources.ListAsync(new ODataQuery<GenericResourceFilter>(r => r.ResourceType == "Microsoft.Web/serverFarms"));
            ServerFarmWithRichSku defaultFarm = null;
            foreach (var resource in farmResources)
            {
                // Try to find a policy with Sku=Free and available site capacity
                var id = new ResourceIdentifier(resource.Id);
                var farm = await WebsitesClient.WrappedWebsitesClient.ServerFarms.GetServerFarmAsync(id.ResourceGroupName, id.ResourceName);
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
#else
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

#endif

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

        public async Task CreateWithSimpleParameters(ICmdletAdapter adapter)
        {
            ResourceGroupName = ResourceGroupName ?? Name;
            AppServicePlan = AppServicePlan ?? Name;
            string planResourceGroup = ResourceGroupName;
            string planName = AppServicePlan;
            var rgStrategy = ResourceGroupStrategy.CreateResourceGroupConfig(ResourceGroupName);
            ResourceConfig<ResourceGroup> planRG = rgStrategy;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(AppServicePlan)))
            {
                if (!TryGetServerFarmFromResourceId(AppServicePlan, out planResourceGroup, out planName))
                {
                    planResourceGroup = ResourceGroupName;
                    planName = AppServicePlan;
                }

                planRG = ResourceGroupStrategy.CreateResourceGroupConfig(planResourceGroup);
            }
            else
            {
                var farm = await GetDefaultServerFarm(Location);
                if (farm != null)
                {
                    planResourceGroup = farm.ResourceGroup;
#if !NETSTANDARD
                    planName = farm.ServerFarmWithRichSkuName;
#else
                    planName = farm.Name;
#endif
                    planRG = ResourceGroupStrategy.CreateResourceGroupConfig(planResourceGroup);
                }
            }


            var farmStrategy = planRG.CreateServerFarmConfig(planResourceGroup, planName);
            var siteStrategy = rgStrategy.CreateSiteConfig(farmStrategy, Name);
            var client = new WebClient(DefaultContext);

            var current = await siteStrategy.GetStateAsync(client, default(CancellationToken));
            if (!MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                Location = current.GetLocation(siteStrategy) ?? "East US";
            }

            var engine = new SdkEngine(DefaultContext.Subscription.Id);
            var target = siteStrategy.GetTargetState(current, engine, Location);
            var endState = await siteStrategy.UpdateStateAsync(client, target, default(CancellationToken), adapter, adapter.ReportTaskProgress);
            var output = endState.Get(siteStrategy) ?? current.Get(siteStrategy);
            string userName = null, password = null;
            try
            {
                var scmHostName = output.EnabledHostNames.FirstOrDefault(s => s.Contains(".scm."));
                if (!string.IsNullOrWhiteSpace(scmHostName))
                {
#if !NETSTANDARD
                    var profile = await WebsitesClient.WrappedWebsitesClient.Sites.ListSitePublishingProfileXmlAsync(output.ResourceGroup, output.SiteName, new CsmPublishingProfileOptions { Format = "WebDeploy" });
#else
                    var profile = await WebsitesClient.WrappedWebsitesClient.WebApps.ListPublishingProfileXmlWithSecretsAsync(output.ResourceGroup, output.Name, new CsmPublishingProfileOptions { Format = "WebDeploy" });
#endif
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
                    var git = new GitCommand(adapter.SessionState.Path, GitRepositoryPath);
                    var repository = await git.VerifyGitRepository();
                    if (repository != null)
                    {
                        if (!await git.CheckExistence())
                        {
                            adapter.WriteWarningAsync(git.InstallationInstructions);
                        }
                        else if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
                        {
                            await git.AddRemoteRepository("azure", $"https://{userName}:{password}@{scmHostName}");
                            adapter.WriteVerboseAsync(Microsoft.Azure.Commands.WebApps.Properties.Resources.GitRemoteMessage);
                            newOutput.GitRemoteName = "azure";
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // do not write errors for problems with adding git repository
                var repoPath = GitRepositoryPath ?? adapter?.SessionState?.Path?.CurrentFileSystemLocation?.Path;
                adapter.WriteWarningAsync(String.Format(Microsoft.Azure.Commands.WebApps.Properties.Resources.GitRemoteAddFailure, repoPath, exception.Message));
            }
            adapter.WriteObjectAsync(output);
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



