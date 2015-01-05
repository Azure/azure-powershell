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
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.Scaffolding;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    using ConfigConfigurationSetting = Common.XmlSchema.ServiceConfigurationSchema.ConfigurationSetting;
    using DefinitionConfigurationSetting = Common.XmlSchema.ServiceDefinitionSchema.ConfigurationSetting;
    using Microsoft.WindowsAzure.Commands.Common;

    static class CacheConfigurationFactory
    {
        private static string CurrentVersion { get; set; }

        private static Dictionary<string, Action<string, RoleInfo>> cacheRoleConfigurationActions =
            new Dictionary<string, Action<string, RoleInfo>>()
            {
                { SDKVersion.Version180,  CacheRole180 },
                { SDKVersion.Version200,  CacheRole180 },
                { SDKVersion.Version220,  CacheRole180 },
                { SDKVersion.Version230,  CacheRole180 },
                { SDKVersion.Version240,  CacheRole180 },
                { SDKVersion.Version250,  CacheRole180 }
            };

        private static Dictionary<string, Action<CloudServiceProject, string, string>> clientRoleConfigurationActions =
            new Dictionary<string, Action<CloudServiceProject, string, string>>()
            {
                { SDKVersion.Version180,  CacheClientRole180 },
                { SDKVersion.Version200,  CacheClientRole180 },
                { SDKVersion.Version220,  CacheClientRole180 },
                { SDKVersion.Version230,  CacheClientRole180 },
                { SDKVersion.Version240,  CacheClientRole180 },
                { SDKVersion.Version250,  CacheClientRole180 }
            };

        #region Cache Role Configuration

        /// <summary>
        /// Configuration required to enable dedicated caching on a given role.
        /// </summary>
        /// <param name="rootPath">The service project root path</param>
        /// <param name="cacheRoleInfo">The cache role info</param>
        private static void CacheRole180(string rootPath, RoleInfo cacheRoleInfo)
        {
            CloudServiceProject cloudServiceProject = new CloudServiceProject(rootPath, null);

            if (!cloudServiceProject.Components.IsWebRole(cacheRoleInfo.Name))
            {
                CacheWorkerRole180(rootPath, cacheRoleInfo);
            }
        }

        private static void CacheWorkerRole180(string rootPath, RoleInfo cacheRoleInfo)
        {
            // Fetch cache role information from service definition and service configuration files.
            CloudServiceProject cloudServiceProject = new CloudServiceProject(rootPath, null);
            WorkerRole cacheWorkerRole = cloudServiceProject.Components.GetWorkerRole(cacheRoleInfo.Name);
            RoleSettings cacheRoleSettings = cloudServiceProject.Components.GetCloudConfigRole(cacheRoleInfo.Name);

            // Add caching module to the role imports
            cacheWorkerRole.Imports = GeneralUtilities.ExtendArray<Import>(
                cacheWorkerRole.Imports,
                new Import { moduleName = Resources.CachingModuleName });

            // Enable caching Diagnostic store.
            LocalStore diagnosticStore = new LocalStore
            {
                name = Resources.CacheDiagnosticStoreName,
                cleanOnRoleRecycle = false
            };
            cacheWorkerRole.LocalResources = GeneralUtilities.InitializeIfNull<LocalResources>(cacheWorkerRole.LocalResources);
            cacheWorkerRole.LocalResources.LocalStorage = GeneralUtilities.ExtendArray<LocalStore>(
                cacheWorkerRole.LocalResources.LocalStorage,
                diagnosticStore);

            // Remove input endpoints.
            cacheWorkerRole.Endpoints.InputEndpoint = null;

            // Add caching configuration settings
            AddCacheConfiguration(cloudServiceProject.Components.GetCloudConfigRole(cacheRoleInfo.Name));
            AddCacheConfiguration(
                cloudServiceProject.Components.GetLocalConfigRole(cacheRoleInfo.Name),
                Resources.EmulatorConnectionString);

            cloudServiceProject.Components.Save(cloudServiceProject.Paths);
        }

        private static void AddCacheConfiguration(RoleSettings cacheRoleSettings, string connectionString = "")
        {
            List<ConfigConfigurationSetting> cachingConfigSettings = new List<ConfigConfigurationSetting>();
            cachingConfigSettings.Add(new ConfigConfigurationSetting
            {
                name = Resources.NamedCacheSettingName,
                value = Resources.NamedCacheSettingValue
            });
            cachingConfigSettings.Add(new ConfigConfigurationSetting
            {
                name = Resources.DiagnosticLevelName,
                value = Resources.DiagnosticLevelValue
            });
            cachingConfigSettings.Add(new ConfigConfigurationSetting
            {
                name = Resources.CachingCacheSizePercentageSettingName,
                value = string.Empty
            });
            cachingConfigSettings.Add(new ConfigConfigurationSetting
            {
                name = Resources.CachingConfigStoreConnectionStringSettingName,
                value = connectionString
            });

            cacheRoleSettings.ConfigurationSettings = GeneralUtilities.ExtendArray<ConfigConfigurationSetting>(
                cacheRoleSettings.ConfigurationSettings,
                cachingConfigSettings);
        }
    
        #endregion

        #region Cache Client Role Configuration

        /// <summary>
        /// Configuration action to enable using dedicated caching on the client role.
        /// </summary>
        /// <param name="cloudServiceProject">The cloud service project instance</param>
        /// <param name="roleName">The role name</param>
        /// <param name="cacheWorkerRoleName">The dedicated cache worker role name</param>
        private static void CacheClientRole180(
            CloudServiceProject cloudServiceProject,
            string roleName,
            string cacheWorkerRoleName)
        {
            // Add MemcacheShim runtime installation.
            cloudServiceProject.AddRoleRuntime(
                cloudServiceProject.Paths,
                roleName,
                Resources.CacheRuntimeValue,
                CurrentVersion);

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

                CacheClientCommonConfiguration(
                        cloudServiceProject,
                        roleName,
                        true,
                        cacheWorkerRoleName,
                        webRole.Startup,
                        webRole.Endpoints,
                        webRole.LocalResources,
                        ref configurationSettings);
                webRole.ConfigurationSettings = configurationSettings;
            }
            else
            {
                WorkerRole workerRole = cloudServiceProject.Components.GetWorkerRole(roleName);
                workerRole.LocalResources = GeneralUtilities.InitializeIfNull<LocalResources>(workerRole.LocalResources);
                DefinitionConfigurationSetting[] configurationSettings = workerRole.ConfigurationSettings;

                CacheClientCommonConfiguration(
                        cloudServiceProject,
                        roleName,
                        false,
                        cacheWorkerRoleName,
                        workerRole.Startup,
                        workerRole.Endpoints,
                        workerRole.LocalResources,
                        ref configurationSettings);
                workerRole.ConfigurationSettings = configurationSettings;
            }

            // Save changes
            cloudServiceProject.Components.Save(cloudServiceProject.Paths);
        }

        private static void CacheClientCommonConfiguration(
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
        private static void UpdateWebConfig(string roleName, string cacheWorkerRoleName, string webConfigPath)
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

        #endregion

        /// <summary>
        /// Gets the configuration action to enable dedicated caching on a role for the given SDK version.
        /// </summary>
        /// <param name="version">The SDK version</param>
        /// <returns>Action to apply to enable dedicated caching on a role</returns>
        public static Action<string, RoleInfo> GetCacheRoleConfigurationAction(string version)
        {
            if (!cacheRoleConfigurationActions.ContainsKey(version))
            {
                throw new Exception(string.Format(Resources.AzureSdkVersionNotSupported,
                        Resources.MinSupportAzureSdkVersion, Resources.MaxSupportAzureSdkVersion));
            }

            CurrentVersion = version;
            return cacheRoleConfigurationActions[version];
        }

        /// <summary>
        /// Gets the configuration action to enable using dedicated caching on a role for the given SDK version.
        /// </summary>
        /// <param name="version">The SDK version</param>
        /// <returns>Action to apply on the client role</returns>
        public static Action<CloudServiceProject, string, string> GetClientRoleConfigurationAction(string version)
        {
            if (!clientRoleConfigurationActions.ContainsKey(version))
            {
                throw new Exception(string.Format(Resources.AzureSdkVersionNotSupported,
                        Resources.MinSupportAzureSdkVersion, Resources.MaxSupportAzureSdkVersion));
            }

            CurrentVersion = version;
            return clientRoleConfigurationActions[version];
        }
    }
}
