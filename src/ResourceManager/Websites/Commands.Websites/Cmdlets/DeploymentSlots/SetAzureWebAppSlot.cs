﻿// ----------------------------------------------------------------------------------
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


using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.DeploymentSlots
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app using ARM APIs
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppSlot"), OutputType(typeof(PSSite))]
    public class SetAzureWebAppSlotCmdlet : WebAppSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the app service plan eg: Default1.")]
        public string AppServicePlan { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Default documents for web app")]
        [ValidateNotNullOrEmpty]
        public string[] DefaultDocuments { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = ".NET Framework version")]
        [ValidateNotNullOrEmpty]
        public string NetFrameworkVersion { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "PHP version")]
        [ValidateNotNullOrEmpty]
        public string PhpVersion { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "Whether or not request tracing is enabled")]
        [ValidateNotNullOrEmpty]
        public bool RequestTracingEnabled { get; set; }

        [Parameter(Position = 8, Mandatory = false, HelpMessage = "Whether or not http logging is enabled")]
        [ValidateNotNullOrEmpty]
        public bool HttpLoggingEnabled { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = "Whether or not detailed error logging is enabled")]
        [ValidateNotNullOrEmpty]
        public bool DetailedErrorLoggingEnabled { get; set; }

        [Parameter(Position = 10, Mandatory = false, HelpMessage = "Web app settings")]
        [ValidateNotNullOrEmpty]
        public Hashtable AppSettings { get; set; }

        [Parameter(Position = 11, Mandatory = false, HelpMessage = "Web app connection strings")]
        [ValidateNotNullOrEmpty]
        public Hashtable ConnectionStrings { get; set; }

        [Parameter(Position = 12, Mandatory = false, HelpMessage = "Web app handler mappings")]
        [ValidateNotNullOrEmpty]
        public IList<HandlerMapping> HandlerMappings { get; set; }

        [Parameter(Position = 13, Mandatory = false, HelpMessage = "Web app managed pipeline mode. Allowed Values [Classic|Integrated]")]
        [ValidateSet("Classic", "Integrated")]
        public string ManagedPipelineMode { get; set; }

        [Parameter(Position = 14, Mandatory = false, HelpMessage = "Whether or not detailed error logging is enabled")]
        [ValidateNotNullOrEmpty]
        public bool WebSocketsEnabled { get; set; }

        [Parameter(Position = 15, Mandatory = false, HelpMessage = "Whether or not to use 32-bit worker process. By default worker process is 64-bit")]
        [ValidateNotNullOrEmpty]
        public bool Use32BitWorkerProcess { get; set; }
        [Parameter(Mandatory = false, HelpMessage = "Destination slot name for auto swap")]

        public string AutoSwapSlotName { get; set; }
        [Parameter(Mandatory = false, HelpMessage = "The number of workers to be allocated", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public int NumberOfWorkers { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Container Image Name", ParameterSetName = ParameterSet1Name)]
        [ValidateNotNullOrEmpty]
        public string ContainerImageName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Private Container Registry Server Url", ParameterSetName = ParameterSet1Name)]
        [ValidateNotNullOrEmpty]
        public string ContainerRegistryUrl { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Private Container Registry Username", ParameterSetName = ParameterSet1Name)]
        [ValidateNotNullOrEmpty]
        public string ContainerRegistryUser { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Private Container Registry Password", ParameterSetName = ParameterSet1Name)]
        [ValidateNotNullOrEmpty]
        public SecureString ContainerRegistryPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables/Disables container continuous deployment webhook", ParameterSetName = ParameterSet1Name)]
        public bool EnableContainerContinuousDeployment  { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "Enable MSI on an existing azure webapp")]
        public bool AssignIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "Enable/disable redirecting all traffic to HTTPS on an existing azure webapp")]
        public bool HttpsOnly { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            SiteConfig siteConfig = null;
            Site site = null;
            string location = null;
            switch (ParameterSetName)
            {
                case ParameterSet1Name:
                    WebApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, Slot));
                    location = WebApp.Location;
                    var parameters = new HashSet<string>(MyInvocation.BoundParameters.Keys, StringComparer.OrdinalIgnoreCase);
                    if (parameters.Any(p => CmdletHelpers.SiteConfigParameters.Contains(p)))
                    {
                        siteConfig = new SiteConfig
                        {
                            DefaultDocuments = parameters.Contains("DefaultDocuments") ? DefaultDocuments : null,
                            NetFrameworkVersion = parameters.Contains("NetFrameworkVersion") ? NetFrameworkVersion : null,
                            PhpVersion = parameters.Contains("PhpVersion") ? PhpVersion.ToLower() == "off" ? "" : PhpVersion : null,
                            RequestTracingEnabled =
                                parameters.Contains("RequestTracingEnabled") ? (bool?)RequestTracingEnabled : null,
                            HttpLoggingEnabled = parameters.Contains("HttpLoggingEnabled") ? (bool?)HttpLoggingEnabled : null,
                            DetailedErrorLoggingEnabled =
                                parameters.Contains("DetailedErrorLoggingEnabled") ? (bool?)DetailedErrorLoggingEnabled : null,
                            HandlerMappings = parameters.Contains("HandlerMappings") ? HandlerMappings : null,
                            ManagedPipelineMode =
                                parameters.Contains("ManagedPipelineMode")
                                    ? (ManagedPipelineMode?)Enum.Parse(typeof(ManagedPipelineMode), ManagedPipelineMode)
                                    : null,
                            WebSocketsEnabled = parameters.Contains("WebSocketsEnabled") ? (bool?)WebSocketsEnabled : null,
                            Use32BitWorkerProcess =
                                parameters.Contains("Use32BitWorkerProcess") ? (bool?)Use32BitWorkerProcess : null,
                            AutoSwapSlotName = parameters.Contains("AutoSwapSlotName") ? AutoSwapSlotName : null,
                            NumberOfWorkers = parameters.Contains("NumberOfWorkers") ? NumberOfWorkers : WebApp.SiteConfig.NumberOfWorkers
                        };
                    }

                    Hashtable appSettings = AppSettings ?? new Hashtable();

                    if (siteConfig == null)
                    {
                        siteConfig = WebApp.SiteConfig;
                    }

                    //According to current implementation if AppSettings paramter is provided we are overriding existing AppSettings
                    if (WebApp.SiteConfig.AppSettings != null && AppSettings == null)
                    {
                        foreach (var setting in WebApp.SiteConfig.AppSettings)
                        {
                            appSettings[setting.Name] = setting.Value;
                        }
                    }

                    if (ContainerImageName != null)
                    {
                        string dockerImage = CmdletHelpers.DockerImagePrefix + ContainerImageName;
                        if (WebApp.IsXenon.GetValueOrDefault())
                        {
                            siteConfig.WindowsFxVersion = dockerImage;
                        }
                        else if (WebApp.Reserved.GetValueOrDefault())
                        {
                            siteConfig.LinuxFxVersion = dockerImage;
                        }
                    }
                    

                    if (ContainerRegistryUrl != null)
                    {
                        appSettings[CmdletHelpers.DocerRegistryServerUrl] = ContainerRegistryUrl;
                    }
                    if (ContainerRegistryUser != null)
                    {
                        appSettings[CmdletHelpers.DocerRegistryServerUserName] = ContainerRegistryUser;
                    }
                    if (ContainerRegistryPassword != null)
                    {
                        appSettings[CmdletHelpers.DocerRegistryServerPassword] = ContainerRegistryPassword.ConvertToString();
                    }

                    if (parameters.Contains("EnableContainerContinuousDeployment"))
                    {
                        if (EnableContainerContinuousDeployment )
                        {
                            appSettings[CmdletHelpers.DockerEnableCI] = "true";
                        }
                        else
                        {
                            appSettings.Remove(CmdletHelpers.DockerEnableCI);

                        }
                    }
                    // Update web app configuration
                    WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, location, Name, Slot, siteConfig, appSettings.ConvertToStringDictionary(), ConnectionStrings.ConvertToConnectionStringDictionary());

                    //update reference to WebApp object after site configuration update
                    WebApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, Slot));

                    if (parameters.Any(p => CmdletHelpers.SiteParameters.Contains(p)))
                    {

                        site = new Site
                        {
                            Location = location,
                            ServerFarmId = WebApp.ServerFarmId,
                            Identity = parameters.Contains("AssignIdentity") ? AssignIdentity ? new ManagedServiceIdentity("SystemAssigned", null, null) : new ManagedServiceIdentity("None", null, null) : WebApp.Identity,
                            HttpsOnly = parameters.Contains("HttpsOnly") ? HttpsOnly : WebApp.HttpsOnly
                        };

                        WebsitesClient.UpdateWebApp(ResourceGroupName, location, Name, Slot, WebApp.ServerFarmId, new PSSite(site));
                    }

                    if (parameters.Contains("AppServicePlan"))
                    {
                        WebsitesClient.UpdateWebApp(ResourceGroupName, location, Name, Slot, AppServicePlan);
                    }

                    break;
                case ParameterSet2Name:
                    // Web app is direct or pipeline input
                    string servicePlanName;
                    string rg;
                    location = WebApp.Location;
                    siteConfig = WebApp.SiteConfig;

                    // Update web app configuration
                    WebsitesClient.UpdateWebAppConfiguration(
                        ResourceGroupName, 
                        location, 
                        Name, 
                        Slot, 
                        siteConfig, 
                        WebApp.SiteConfig == null ? 
                            null : 
                            WebApp.SiteConfig.AppSettings
                                .ToDictionary(
                                    nvp => nvp.Name, 
                                    nvp => nvp.Value, 
                                    StringComparer.OrdinalIgnoreCase), 
                        WebApp.SiteConfig == null ? 
                            null : 
                            WebApp.SiteConfig.ConnectionStrings
                                .ToDictionary(
                                nvp => nvp.Name, 
                                nvp => new ConnStringValueTypePair
                                {
                                    Type = nvp.Type.Value,
                                    Value = nvp.ConnectionString
                                }, 
                                StringComparer.OrdinalIgnoreCase));

                    CmdletHelpers.TryParseAppServicePlanMetadataFromResourceId(WebApp.ServerFarmId, out rg, out servicePlanName);
                    WebsitesClient.UpdateWebApp(ResourceGroupName, location, Name, Slot, servicePlanName);
                    break;
            }

            WriteObject(new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, Slot)));
        }
    }
}
