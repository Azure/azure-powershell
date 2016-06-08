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
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    public class ServiceComponents
    {
        public ServiceDefinition Definition { get; private set; }
        public ServiceConfiguration CloudConfig { get; private set; }
        public ServiceConfiguration LocalConfig { get; private set; }
        public ServiceSettings Settings { get; private set; }

        public ServiceComponents(CloudProjectPathInfo paths)
        {
            LoadComponents(paths);
        }

        public ServiceComponents(string cloudConfiguration)
        {
            Validate.ValidateFileFull(cloudConfiguration, Resources.ServiceConfiguration);
            CloudConfig = XmlUtilities.DeserializeXmlFile<ServiceConfiguration>(cloudConfiguration);
        }

        private void LoadComponents(CloudProjectPathInfo paths)
        {
            Validate.ValidateNullArgument(paths, string.Format(Resources.NullObjectMessage, "paths"));
            Validate.ValidateFileFull(paths.CloudConfiguration, Resources.ServiceConfiguration);
            Validate.ValidateFileFull(paths.LocalConfiguration, Resources.ServiceConfiguration);
            Validate.ValidateFileFull(paths.Definition, Resources.ServiceDefinition);

            try
            {
                Validate.ValidateFileFull(paths.Settings, Resources.ServiceSettings);
            }
            catch (FileNotFoundException)
            {
                // Try recreating the settings file
                FileUtilities.DataStore.WriteFile(paths.Settings, Resources.SettingsFileEmptyContent);
            }

            Definition = XmlUtilities.DeserializeXmlFile<ServiceDefinition>(paths.Definition);
            CloudConfig = XmlUtilities.DeserializeXmlFile<ServiceConfiguration>(paths.CloudConfiguration);
            LocalConfig = XmlUtilities.DeserializeXmlFile<ServiceConfiguration>(paths.LocalConfiguration);
            Settings = ServiceSettings.Load(paths.Settings);
        }

        public void Save(CloudProjectPathInfo paths)
        {
            // Validate directory exists and it's valid
            if (paths == null) throw new ArgumentNullException("paths");

            XmlUtilities.SerializeXmlFile(Definition, paths.Definition);
            XmlUtilities.SerializeXmlFile(CloudConfig, paths.CloudConfiguration);
            XmlUtilities.SerializeXmlFile(LocalConfig, paths.LocalConfiguration);
            Settings.Save(paths.Settings);
        }

        public void SetRoleInstances(string roleName, int instances)
        {
            Validate.ValidateStringIsNullOrEmpty(roleName, Resources.RoleName);
            if (instances <= 0 || instances > int.Parse(Resources.RoleMaxInstances))
            {
                throw new ArgumentException(string.Format(Resources.InvalidInstancesCount, roleName));
            }

            if (!RoleExists(roleName))
            {
                throw new ArgumentException(string.Format(Resources.RoleNotFoundMessage, roleName));
            }

            CloudConfig.Role.First<RoleSettings>(r => r.name.Equals(roleName, StringComparison.OrdinalIgnoreCase)).Instances.count = instances;
            LocalConfig.Role.First<RoleSettings>(r => r.name.Equals(roleName, StringComparison.OrdinalIgnoreCase)).Instances.count = instances;
        }

        /// <summary>
        /// Sets the VM size of a role
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="vmSize">The VM size</param>
        public void SetRoleVMSize(string roleName, string vmSize)
        {
            Validate.ValidateStringIsNullOrEmpty(roleName, Resources.RoleName);

            if (!RoleExists(roleName))
            {
                throw new ArgumentException(string.Format(Resources.RoleNotFoundMessage, roleName));
            }

            WebRole webRole = GetWebRole(roleName);

            if (webRole != null)
            {
                webRole.vmsize = vmSize;
            }
            else
            {
                WorkerRole workerRole = GetWorkerRole(roleName);
                workerRole.vmsize = vmSize;
            }
        }

        /// <summary>
        /// Gets the worker role if exists otherwise return null.
        /// </summary>
        /// <param name="name">The worker role name</param>
        /// <returns>The worker role object from service definition</returns>
        public WorkerRole GetWorkerRole(string name)
        {
            if (Definition.WorkerRole != null)
            {
                return Definition.WorkerRole.FirstOrDefault<WorkerRole>(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            
            return null;
        }

        /// <summary>
        /// Gets the web role if exists otherwise return null.
        /// </summary>
        /// <param name="name">The web role name</param>
        /// <returns>The web role object from service definition</returns>
        public WebRole GetWebRole(string name)
        {
            if (Definition.WebRole != null)
            {
                return Definition.WebRole.FirstOrDefault<WebRole>(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }

            return null;
        }

        /// <summary>
        /// Gets the role if exists otherwise return null.
        /// </summary>
        /// <param name="name">The role name</param>
        /// <returns>The role object from cloud configuration</returns>
        public RoleSettings GetCloudConfigRole(string name)
        {
            if (CloudConfig.Role != null)
            {
                return CloudConfig.Role.FirstOrDefault<RoleSettings>(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }

            return null;
        }

        /// <summary>
        /// Gets the role if exists otherwise return null.
        /// </summary>
        /// <param name="name">The role name</param>
        /// <returns>The role object from local configuration</returns>
        public RoleSettings GetLocalConfigRole(string name)
        {
            if (LocalConfig.Role != null)
            {
                return LocalConfig.Role.FirstOrDefault<RoleSettings>(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }

            return null;
        }

        /// <summary>
        /// Gets all role settings that matches the given name.
        /// </summary>
        /// <param name="roleNames">Role names collection</param>
        /// <returns>Matched items</returns>
        public IEnumerable<RoleSettings> GetRoles(IEnumerable<string> roleNames)
        {
            if (CloudConfig.Role != null)
            {
                return Array.FindAll<RoleSettings>(CloudConfig.Role, r => Array.Exists<string>(
                    roleNames.ToArray<string>(), s => s.Equals(r.name, StringComparison.OrdinalIgnoreCase)));
            }

            return Enumerable.Empty<RoleSettings>();
        }

        /// <summary>
        /// Gets all existing role names.
        /// </summary>
        /// <returns>All roles in the cloud service project</returns>
        public IEnumerable<string> GetRoles()
        {
            if (CloudConfig.Role != null)
            {
                return CloudConfig.Role.Select(r => r.name);
            }

            return Enumerable.Empty<string>();
        }

        /// <summary>
        /// Gets all worker roles that matches given predicate.
        /// </summary>
        /// <param name="predicate">The matching predicate</param>
        /// <returns>Matched items</returns>
        public IEnumerable<WorkerRole> GetWorkerRoles(Predicate<WorkerRole> predicate)
        {
            return Array.FindAll<WorkerRole>(Definition.WorkerRole, predicate);
        }

        /// <summary>
        /// Applied given action to all matching 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="action"></param>
        public void ForEachRoleSettings(Func<RoleSettings, bool> predicate, Action<RoleSettings> action)
        {
            if (CloudConfig.Role != null)
            {
                IEnumerable<RoleSettings> matchedRoles = CloudConfig.Role.Where<RoleSettings>(predicate);
                matchedRoles.ForEach<RoleSettings>(action);
            }
        }

        /// <summary>
        /// Gets the next available port, starts from 80.
        /// </summary>
        /// <returns>The port number</returns>
        public int GetNextPort()
        {
            if (Definition.WebRole == null && Definition.WorkerRole == null)
            {
                // First role will have port #80
                //
                return int.Parse(Resources.DefaultWebPort);
            }
            else
            {
                int maxWeb = 0;
                int maxWorker = 0;

                maxWeb = Definition.WebRole.MaxOrDefault<WebRole, int>(wr => (wr.Endpoints?? new Endpoints()).InputEndpoint.MaxOrDefault<InputEndpoint, int>(ie => ie.port, 0), 0);
                maxWorker = Definition.WorkerRole.MaxOrDefault<WorkerRole, int>(wr => (wr.Endpoints ?? new Endpoints()).InputEndpoint.MaxOrDefault<InputEndpoint, int>(ie => ie.port, 0), 0);
                int maxPort = Math.Max(maxWeb, maxWorker);

                if (maxPort == 0)
                {
                    // If this is first external endpoint, use default web role port
                    return int.Parse(Resources.DefaultWebPort);
                }
                else if (maxPort == int.Parse(Resources.DefaultWebPort))
                {
                    // This is second role to be added
                    return int.Parse(Resources.DefaultPort);
                }
                else
                {
                    // Increase max port and return it
                    return (maxPort + 1);
                }
            }
        }

        /// <summary>
        /// Adds the given role settings to the specified configuration file.
        /// </summary>
        /// <param name="role">The role settings instance</param>
        /// <param name="env">The environment</param>
        public void AddRoleToConfiguration(RoleSettings role, DevEnv env)
        {
            Validate.ValidateNullArgument(role, string.Format(Resources.NullRoleSettingsMessage, "ServiceConfiguration"));

            ServiceConfiguration config = (env == DevEnv.Cloud) ? CloudConfig : LocalConfig;

            if (config.Role == null)
            {
                config.Role = new RoleSettings[] { role };
            }
            else
            {
                config.Role = config.Role.Concat(new RoleSettings[] { role }).ToArray();
            }
        }

        /// <summary>
        /// Determines if a specified role exists in service components (*.csdef, local and cloud *cscfg) or not.
        /// </summary>
        /// <param name="roleName">Role name</param>
        /// <returns>bool value indicating whether this role is found or not </returns>
        public bool RoleExists(string roleName)
        {
            // If any one of these fields doesn't have elements then this means no roles added at all or
            // there's inconsistency between service components.
            //
            if ((Definition.WebRole == null && Definition.WorkerRole == null) || CloudConfig.Role == null || LocalConfig.Role == null)
                return false;
            else
            {
                return (GetWebRole(roleName) != null || GetWorkerRole(roleName) != null) && // exists in csdef
                       GetCloudConfigRole(roleName) != null && GetLocalConfigRole(roleName) != null; // exists in local/cloud cscfg
            }
        }

        /// <summary>
        /// Validates if given role name is valid or not
        /// </summary>
        /// <param name="roleName">Role name to be checked</param>
        /// <returns></returns>
        /// <remarks>This method doesn't check if the role exists in service components or not. To check for role existence use RoleExists</remarks>
        public static bool ValidRoleName(string roleName)
        {
            try
            {
                Validate.ValidateFileName(roleName);
                Validate.HasWhiteCharacter(roleName);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets role startup.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <returns>The role startup</returns>
        public Startup GetRoleStartup(string roleName)
        {
            if (!RoleExists(roleName))
            {
                throw new ArgumentException(string.Format(Resources.RoleNotFoundMessage, roleName));
            }

            WebRole webRole = GetWebRole(roleName);
            WorkerRole workerRole = GetWorkerRole(roleName);
            Startup startup = webRole != null ? webRole.Startup : workerRole.Startup;

            return startup;
        }

        /// <summary>
        /// Decides if the given role is web or worker role.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <returns>Boolean flag indicates if the role is web or not</returns>
        public bool IsWebRole(string roleName)
        {
            WebRole webRole = GetWebRole(roleName);
            return webRole != null ? true : false;
        }

        /// <summary>
        /// Checks if a startup task exists with specified command line.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="commandLines">The possible command line for the task</param>
        /// <returns>True if exists, false otherwise</returns>
        public bool StartupTaskExists(string roleName, params string[] commandLines)
        {
            return GetStartupTask(roleName, commandLines) != null;
        }

        /// <summary>
        /// Adds new startup task to the given role.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="commandLine">The startup task command line</param>
        /// <param name="context">The execution context</param>
        /// <param name="variables">The environment variables</param>
        public void AddStartupTask(
            string roleName,
            string commandLine,
            ExecutionContext context,
            params Variable[] variables)
        {
            Startup roleStartup = GetRoleStartup(roleName) ?? new Startup();
            Task newTask = new Task
            {
                Environment = variables,
                commandLine = commandLine,
                executionContext = context
            };

            roleStartup.Task = GeneralUtilities.ExtendArray<Task>(roleStartup.Task, newTask);
        }

        /// <summary>
        /// Searches for a startup task that matches one of the given command lines for the specified role.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="commandLines">The command line to match</param>
        /// <returns>The startup task object</returns>
        public Task GetStartupTask(string roleName, params string[] commandLines)
        {
            Startup startup = GetRoleStartup(roleName);

            foreach (string commandLine in commandLines)
            {
                if (startup != null)
                {
                    Task task = startup.Task.FirstOrDefault(t => t.commandLine.Equals(commandLine));

                    if (task != null)
                    {
                        return task;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Sets a startup task environment variable.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="name">The environment variable name</param>
        /// <param name="value">The environment variable value</param>
        /// <param name="commandLines">The command line to match task.</param>
        public void SetStartupTaskVariable(string roleName, string name, string value, params string[] commandLines)
        {
            Task task = GetStartupTask(roleName, commandLines);
            bool found = false;

            if (task != null && task.Environment != null)
            {
                for (int i = 0; i < task.Environment.Length; i++)
                {
                    if (task.Environment[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        task.Environment[i].value = value;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Variable var = new Variable() { name = name, value = value };
                    task.Environment = GeneralUtilities.ExtendArray<Variable>(task.Environment, var);
                }
            }
        }

        /// <summary>
        /// Gets startup task variable with the specified name.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="name">The variable name</param>
        /// <param name="commandLines">The startup task command line arguments</param>
        /// <returns></returns>
        public string GetStartupTaskVariable(string roleName, string name, params string[] commandLines)
        {
            Task task = GetStartupTask(roleName, commandLines);
            Variable variable = null;

            if (task != null && task.Environment != null)
            {
                variable = task.Environment.FirstOrDefault(v => v.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }

            if (variable != null)
            {
                return variable.value;
            }

            return null;
        }
    }
}