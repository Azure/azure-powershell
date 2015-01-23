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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.Scaffolding;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development
{
    using ConfigConfigurationSetting = Utilities.Common.XmlSchema.ServiceConfigurationSchema.ConfigurationSetting;
    using DefinitionConfigurationSetting = Utilities.Common.XmlSchema.ServiceDefinitionSchema.ConfigurationSetting;
    using Microsoft.WindowsAzure.Commands.Common;

    /// <summary>
    /// Enables memcache for specific role.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "AzureMemcacheRole"), OutputType(typeof(bool))]
    public class EnableAzureMemcacheRoleCommand : AzurePSCmdlet
    {
        /// <summary>
        /// The role name to edit.
        /// </summary>
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("rn")]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        /// <summary>
        /// The dedicated caching worker role name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("cn")]
        [ValidateNotNullOrEmpty]
        public string CacheWorkerRoleName { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Cache runtime version
        /// </summary>
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("cv")]
        public string CacheRuntimeVersion { get; set; }

        public EnableAzureMemcacheRoleCommand()
        {
            CacheRuntimeVersion = AzureTool.GetAzureSdkVersion();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            WriteWarning("This cmdlet will be removed in a future release as we are retiring Managed Cache scaffolding support.");
            string rootPath = CommonUtilities.GetServiceRootPath(CurrentPath());
            RoleName = string.IsNullOrEmpty(RoleName) ? CommonUtilities.GetRoleName(rootPath, CurrentPath()) : RoleName;

            EnableAzureMemcacheRoleProcess(this.RoleName, this.CacheWorkerRoleName, CommonUtilities.GetServiceRootPath(CurrentPath()));
        }

        /// <summary>
        /// Process for enabling memcache for web roles.
        /// </summary>
        /// <param name="roleName">The web role name</param>
        /// <param name="cacheWorkerRoleName">The cache worker role name</param>
        /// <param name="rootPath">The root path of the services</param>
        /// <returns>The resulted message</returns>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public WebRole EnableAzureMemcacheRoleProcess(string roleName, string cacheWorkerRoleName, string rootPath)
        {
            CloudServiceProject cloudServiceProject = new CloudServiceProject(rootPath, null);

            if (string.IsNullOrEmpty(cacheWorkerRoleName))
            {
                WorkerRole defaultCache = cloudServiceProject.Components.Definition.WorkerRole.FirstOrDefault<WorkerRole>(
                    w => w.Imports != null && w.Imports.Any(i => i.moduleName.Equals(Resources.CachingModuleName)));

                if (defaultCache == null)
                {
                    throw new Exception(Resources.NoCacheWorkerRoles);
                }

                cacheWorkerRoleName = defaultCache.name;
            }

            // Verify cache worker role exists
            if (!cloudServiceProject.Components.RoleExists(cacheWorkerRoleName))
            {
                throw new Exception(string.Format(Resources.RoleNotFoundMessage, cacheWorkerRoleName));
            }

            WorkerRole cacheWorkerRole = cloudServiceProject.Components.GetWorkerRole(cacheWorkerRoleName);

            // Verify that the cache worker role has proper caching configuration.
            if (!IsCacheWorkerRole(cacheWorkerRole))
            {
                throw new Exception(string.Format(Resources.NotCacheWorkerRole, cacheWorkerRoleName));
            }

            // Verify that user is not trying to enable cache on a cache worker role.
            if (roleName.Equals(cacheWorkerRole))
            {
                throw new Exception(string.Format(Resources.InvalidCacheRoleName, roleName));
            }

            // Verify role to enable cache on exists
            if (!cloudServiceProject.Components.RoleExists(roleName))
            {
                throw new Exception(string.Format(Resources.RoleNotFoundMessage, roleName));
            }

            // Verify that caching is not enabled for the role
            if (IsCacheEnabled(cloudServiceProject.Components.GetRoleStartup(roleName)))
            {
                throw new Exception(string.Format(Resources.CacheAlreadyEnabledMessage, roleName));
            }

            // All validations passed, enable caching.
            //EnableMemcache(roleName, cacheWorkerRoleName, ref message, ref cloudServiceProject);
            var applyConfiguration = CacheConfigurationFactory.GetClientRoleConfigurationAction(CacheRuntimeVersion);
            applyConfiguration(cloudServiceProject, roleName, cacheWorkerRoleName);
            string message = string.Format(
                Resources.EnableMemcacheMessage,
                roleName,
                cacheWorkerRoleName,
                Resources.MemcacheEndpointPort);

            WriteVerbose(message);

            if (PassThru)
            {
                SafeWriteOutputPSObject(typeof(RoleSettings).FullName, Parameters.RoleName, roleName);
            }

            return cloudServiceProject.Components.GetWebRole(roleName);
        }

        /// <summary>
        /// Main entry for enabling memcache.
        /// </summary>
        /// <param name="roleName">The web role name</param>
        /// <param name="cacheWorkerRoleName">The cache worker role name</param>
        /// <param name="rootPath">The service root path</param>
        /// <param name="message">The resulted message</param>
        /// <param name="cloudServiceProject">The azure service instance</param>
        /// <param name="webRole">The web role to enable caching one</param>
        private void EnableMemcache(string roleName, string cacheWorkerRoleName, ref string message, ref CloudServiceProject cloudServiceProject)
        {
            // Add MemcacheShim runtime installation.
            cloudServiceProject.AddRoleRuntime(cloudServiceProject.Paths, roleName, Resources.CacheRuntimeValue, CacheRuntimeVersion);

            // Fetch web role information.
            Startup startup = cloudServiceProject.Components.GetRoleStartup(roleName);

            // Assert that cache runtime is added to the runtime startup.
            Debug.Assert(Array.Exists<Variable>(CloudRuntime.GetRuntimeStartupTask(startup).Environment,
                v => v.name.Equals(Resources.RuntimeTypeKey) && v.value.Contains(Resources.CacheRuntimeValue)));

            if (cloudServiceProject.Components.IsWebRole(roleName))
            {
                WebRole webRole = cloudServiceProject.Components.GetWebRole(roleName);
                webRole.LocalResources = GeneralUtilities.InitializeIfNull<LocalResources>(webRole.LocalResources);
                DefinitionConfigurationSetting[] configurationSettings = webRole.ConfigurationSettings;

                CachingConfigurationFactoryMethod(
                        cloudServiceProject,
                        roleName,
                        true,
                        cacheWorkerRoleName,
                        webRole.Startup,
                        webRole.Endpoints,
                        webRole.LocalResources,
                        ref configurationSettings,
                        CacheRuntimeVersion);
                webRole.ConfigurationSettings = configurationSettings;
            }
            else
            {
                WorkerRole workerRole = cloudServiceProject.Components.GetWorkerRole(roleName);
                workerRole.LocalResources = GeneralUtilities.InitializeIfNull<LocalResources>(workerRole.LocalResources);
                DefinitionConfigurationSetting[] configurationSettings = workerRole.ConfigurationSettings;

                CachingConfigurationFactoryMethod(
                        cloudServiceProject,
                        roleName,
                        false,
                        cacheWorkerRoleName,
                        workerRole.Startup,
                        workerRole.Endpoints,
                        workerRole.LocalResources,
                        ref configurationSettings,
                        CacheRuntimeVersion);
                workerRole.ConfigurationSettings = configurationSettings;
            }

            // Save changes
            cloudServiceProject.Components.Save(cloudServiceProject.Paths);

            message = string.Format(Resources.EnableMemcacheMessage, roleName, cacheWorkerRoleName, Resources.MemcacheEndpointPort);
        }

        /// <summary>
        /// Factory method to apply memcache required configuration based on the installed SDK version.
        /// </summary>
        /// <param name="cloudServiceProject">The azure service instance</param>
        /// <param name="webRole">The web role to enable caching on</param>
        /// <param name="isWebRole">Flag indicating if the provided role is web or not</param>
        /// <param name="cacheWorkerRole">The memcache worker role name</param>
        /// <param name="startup">The role startup</param>
        /// <param name="endpoints">The role endpoints</param>
        /// <param name="localResources">The role local resources</param>
        /// <param name="configurationSettings">The role configuration settings</param>
        /// <param name="sdkVersion">The current SDK version</param>
        private void CachingConfigurationFactoryMethod(
            CloudServiceProject cloudServiceProject,
            string roleName,
            bool isWebRole,
            string cacheWorkerRole,
            Startup startup,
            Endpoints endpoints,
            LocalResources localResources,
            ref DefinitionConfigurationSetting[] configurationSettings,
            string sdkVersion)
        {
            switch (sdkVersion)
            {
                case SDKVersion.Version180:
                    Version180Configuration(
                        cloudServiceProject,
                        roleName,
                        isWebRole,
                        cacheWorkerRole,
                        startup,
                        endpoints,
                        localResources,
                        ref configurationSettings);
                    break;

                default:
                    throw new Exception(string.Format(Resources.AzureSdkVersionNotSupported,
                        Resources.MinSupportAzureSdkVersion, Resources.MaxSupportAzureSdkVersion));
            }
        }

        /// <summary>
        /// Applies required configuration for enabling cache in SDK 1.8.0 version by:
        /// * Add MemcacheShim runtime installation.
        /// * Add startup task to install memcache shim on the client side.
        /// * Add default memcache internal endpoint.
        /// * Add cache diagnostic to local resources.
        /// * Add ClientDiagnosticLevel setting to service configuration.
        /// * Adjust web.config to enable auto discovery for the caching role.
        /// </summary>
        /// <param name="cloudServiceProject">The azure service instance</param>
        /// <param name="webRole">The web role to enable caching on</param>
        /// <param name="isWebRole">Flag indicating if the provided role is web or not</param>
        /// <param name="cacheWorkerRole">The memcache worker role name</param>
        /// <param name="startup">The role startup</param>
        /// <param name="endpoints">The role endpoints</param>
        /// <param name="localResources">The role local resources</param>
        /// <param name="configurationSettings">The role configuration settings</param>
        private void Version180Configuration(
            CloudServiceProject cloudServiceProject,
            string roleName,
            bool isWebRole,
            string cacheWorkerRole,
            Startup startup,
            Endpoints endpoints,
            LocalResources localResources,
            ref DefinitionConfigurationSetting[] configurationSettings)
        {
            if (isWebRole)
            {
                // Generate cache scaffolding for web role
                cloudServiceProject.GenerateScaffolding(Path.Combine(Resources.CacheScaffolding, RoleType.WebRole.ToString()),
                    roleName, new Dictionary<string, object>());

                // Adjust web.config to enable auto discovery for the caching role.
                string webCloudConfigPath = Path.Combine(cloudServiceProject.Paths.RootPath, roleName, Resources.WebCloudConfig);
                string webConfigPath = Path.Combine(cloudServiceProject.Paths.RootPath, roleName, Resources.WebConfigTemplateFileName);

                UpdateWebConfig(roleName, cacheWorkerRole, webCloudConfigPath);
                UpdateWebConfig(roleName, cacheWorkerRole, webConfigPath);
            }
            else
            {
                // Generate cache scaffolding for worker role
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters[ScaffoldParams.RoleName] = cacheWorkerRole;

                cloudServiceProject.GenerateScaffolding(Path.Combine(Resources.CacheScaffolding, RoleType.WorkerRole.ToString()),
                    roleName, parameters);
            }

            // Add default memcache internal endpoint.
            InternalEndpoint memcacheEndpoint = new InternalEndpoint
            {
                name = Resources.MemcacheEndpointName,
                protocol = InternalProtocol.tcp,
                port = Resources.MemcacheEndpointPort
            };
            endpoints.InternalEndpoint = GeneralUtilities.ExtendArray<InternalEndpoint>(endpoints.InternalEndpoint, memcacheEndpoint);

            // Enable cache diagnostic
            LocalStore localStore = new LocalStore
            {
                name = Resources.CacheDiagnosticStoreName,
                cleanOnRoleRecycle = false
            };
            localResources.LocalStorage = GeneralUtilities.ExtendArray<LocalStore>(localResources.LocalStorage, localStore);

            DefinitionConfigurationSetting diagnosticLevel = new DefinitionConfigurationSetting { name = Resources.CacheClientDiagnosticLevelAssemblyName };
            configurationSettings = GeneralUtilities.ExtendArray<DefinitionConfigurationSetting>(configurationSettings, diagnosticLevel);

            // Add ClientDiagnosticLevel setting to service configuration.
            AddClientDiagnosticLevelToConfig(cloudServiceProject.Components.GetCloudConfigRole(roleName));
            AddClientDiagnosticLevelToConfig(cloudServiceProject.Components.GetLocalConfigRole(roleName));
        }

        private static void AddClientDiagnosticLevelToConfig(RoleSettings roleSettings)
        {
            ConfigConfigurationSetting clientDiagnosticLevel = new ConfigConfigurationSetting { name = Resources.ClientDiagnosticLevelName, value = Resources.ClientDiagnosticLevelValue };
            roleSettings.ConfigurationSettings = GeneralUtilities.ExtendArray<ConfigConfigurationSetting>(roleSettings.ConfigurationSettings, clientDiagnosticLevel);
        }

        /// <summary>
        /// Updates the web.cloud.config with to auto-discover the cache role.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="cacheWorkerRoleName">The cache worker role name</param>
        /// <param name="cloudServiceProject">The azure service instance for the role</param>
        private void UpdateWebConfig(string roleName, string cacheWorkerRoleName, string webConfigPath)
        {
            XDocument webConfig = XDocument.Load(webConfigPath);

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters[ScaffoldParams.RoleName] = cacheWorkerRoleName;
            string autoDiscoveryConfig = Scaffold.ReplaceParameter(Resources.CacheAutoDiscoveryConfig, parameters);

            // Adding the auto-discovery is sensetive to the placement of the nodes. The first node which is <configSections>
            // must be added at the first and the last node which is dataCacheClients must be added as last element.
            XElement autoDiscoverXElement = XElement.Parse(autoDiscoveryConfig);
            webConfig.Element("configuration").AddFirst(autoDiscoverXElement.FirstNode);
            webConfig.Element("configuration").Add(autoDiscoverXElement.LastNode);
            Debug.Assert(webConfig.Element("configuration").FirstNode.Ancestors("section").Attributes("name") != null);
            Debug.Assert(webConfig.Element("configuration").LastNode.Ancestors("tracing").Attributes("sinkType") != null);
            webConfig.Save(webConfigPath);
        }

        /// <summary>
        /// Checks if memcache is already enabled or not for the given role startup.
        /// It does this by checking the role startup task.
        /// </summary>
        /// <param name="startup">The role startup</param>
        /// <returns>Either enabled or not</returns>
        private bool IsCacheEnabled(Startup startup)
        {
            if (startup.Task != null)
            {
                return Array.Exists<Variable>(CloudRuntime.GetRuntimeStartupTask(startup).Environment,
                v => v.name.Equals(Resources.RuntimeTypeKey) && v.value.Contains(Resources.CacheRuntimeValue));
            }

            return false;
        }

        /// <summary>
        /// Checks if the worker role is configured as caching worker role.
        /// </summary>
        /// <param name="workerRole">The worker role object</param>
        /// <returns>True if its caching worker role, false if not</returns>
        private bool IsCacheWorkerRole(WorkerRole workerRole)
        {
            if (workerRole.Imports != null)
            {
                return Array.Exists<Import>(workerRole.Imports, i => i.moduleName == Resources.CachingModuleName);
            }

            return false;
        }
    }
}
