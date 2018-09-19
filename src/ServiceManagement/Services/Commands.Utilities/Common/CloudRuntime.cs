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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    public abstract class CloudRuntime
    {
        public CloudServiceProject CloudServiceProject { get; set; }

        public string Version
        {
            get;
            protected set;
        }

        public RuntimeType Runtime
        {
            get;
            protected set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public bool ShouldPrompt
        {
            get;
            private set;
        }

        protected CloudRuntime()
        {
        }

        /// <summary>
        /// Gets the runtime startup task regardless of its order in the startup tasks.
        /// </summary>
        /// <param name="roleStartup">The role startup tasks</param>
        /// <returns>The runtime startup task</returns>
        public static Task GetRuntimeStartupTask(Startup roleStartup)
        {
            if (roleStartup.Task != null)
            {
                return roleStartup.Task.FirstOrDefault<Task>(t =>
                t.commandLine.Equals(Resources.WebRoleStartupTaskCommandLine)
             || t.commandLine.Equals(Resources.WorkerRoleStartupTaskCommandLine));
            }

            return null;
        }

        private static CloudRuntime CreateRuntimeInternal(RuntimeType runtimeType, string roleName, string rolePath)
        {
            CloudRuntime runtime;
            switch (runtimeType)
            {
                case RuntimeType.Null:
                    runtime = new NullCloudRuntime();
                    break;
                case RuntimeType.Cache:
                    //Scaffolding for cache is no longer supported
                    throw new NotSupportedException(Resources.CacheScaffoldingIsNotSupport);
                case RuntimeType.PHP:
                    runtime = new PHPCloudRuntime();
                    break;
                case RuntimeType.IISNode:
                    runtime = new IISNodeCloudRuntime();
                    break;
                case RuntimeType.Node:
                default:
                    runtime = new NodeCloudRuntime();
                    break;
            }

            runtime.Runtime = runtimeType;
            runtime.RoleName = roleName;
            runtime.FilePath = rolePath;
            return runtime;
        }

        private static Collection<CloudRuntime> GetRuntimes(Dictionary<string, string> settings,
            string roleName, string rolePath)
        {
            Collection<CloudRuntime> runtimes = new Collection<CloudRuntime>(new List<CloudRuntime>());
            foreach (RuntimeType runtimeType in GetRuntimeTypes(settings))
            {
                CloudRuntime runtime = CreateRuntimeInternal(runtimeType, roleName, rolePath);
                runtime.Configure(settings);
                runtimes.Add(runtime);
            }

            return runtimes;
        }

        public static CloudRuntime CreateCloudRuntime(string runtimeType, string runtimeVersion, string roleName, string rolePath)
        {
            CloudRuntime runtime = CreateRuntimeInternal(GetRuntimeByType(runtimeType), roleName, rolePath);
            runtime.Version = runtimeVersion;
            return runtime;
        }

        public static RuntimeType GetRuntimeByType(string runtimeType)
        {
            if (string.Equals(runtimeType, Resources.PhpRuntimeValue, StringComparison.OrdinalIgnoreCase))
            {
                return RuntimeType.PHP;
            }
            else if (string.Equals(runtimeType, Resources.IISNodeRuntimeValue, StringComparison.OrdinalIgnoreCase))
            {
                return RuntimeType.IISNode;
            }
            else if (string.Equals(runtimeType, Resources.NodeRuntimeValue, StringComparison.OrdinalIgnoreCase))
            {
                return RuntimeType.Node;
            }
            else if (string.Equals(runtimeType, Resources.CacheRuntimeValue, StringComparison.OrdinalIgnoreCase))
            {
                return RuntimeType.Cache;
            }
            else
            {
                return RuntimeType.Null;
            }
        }

        public static Collection<CloudRuntime> CreateRuntime(WebRole webRole, string rolePath)
        {
            return GetRuntimes(GetStartupEnvironment(webRole), webRole.name, rolePath);
        }

        public static Collection<CloudRuntime> CreateRuntime(WorkerRole workerRole, string rolePath)
        {
            return GetRuntimes(GetStartupEnvironment(workerRole), workerRole.name, rolePath);
        }

        private static Collection<RuntimeType> GetRuntimeTypes(Dictionary<string, string> environmentSettings)
        {
            Collection<RuntimeType> runtimes = new Collection<RuntimeType>();
            if (environmentSettings.ContainsKey(Resources.RuntimeOverrideKey) && !string.IsNullOrEmpty(environmentSettings[Resources.RuntimeOverrideKey]))
            {
                runtimes.Add(RuntimeType.Null);
            }
            else if (environmentSettings.ContainsKey(Resources.RuntimeTypeKey) && !string.IsNullOrEmpty(environmentSettings[Resources.RuntimeTypeKey]))
            {
                foreach (string runtimeSpec in environmentSettings[Resources.RuntimeTypeKey].Split(';'))
                {
                    if (string.Equals(runtimeSpec, Resources.NodeRuntimeValue, StringComparison.OrdinalIgnoreCase))
                    {
                        runtimes.Add(RuntimeType.Node);
                    }
                    else if (string.Equals(runtimeSpec, Resources.IISNodeRuntimeValue, StringComparison.OrdinalIgnoreCase))
                    {
                        runtimes.Add(RuntimeType.IISNode);
                    }
                    else if (string.Equals(runtimeSpec, Resources.PhpRuntimeValue, StringComparison.OrdinalIgnoreCase))
                    {
                        runtimes.Add(RuntimeType.PHP);
                    }
                    else if (string.Equals(runtimeSpec, Resources.CacheRuntimeValue, StringComparison.OrdinalIgnoreCase))
                    {
                        runtimes.Add(RuntimeType.Cache);
                    }
                }
            }

            return runtimes;
        }

        private static Dictionary<string, string> GetStartupEnvironment(WebRole webRole)
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            foreach (Variable variable in GetRuntimeStartupTask(webRole.Startup).Environment)
            {
                settings[variable.name] = variable.value;
            }

            return settings;
        }

        private static Dictionary<string, string> GetStartupEnvironment(WorkerRole workerRole)
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            foreach (Variable variable in GetRuntimeStartupTask(workerRole.Startup).Environment)
            {
                settings[variable.name] = variable.value;
            }

            return settings;
        }

        /// <summary>
        /// Determine if this is a variable that should be set directly or should be merged with the new value
        /// </summary>
        /// <param name="variableToCheck"></param>
        /// <returns>True if the variable should be merged, false if the value should be replaced instead</returns>
        private static bool ShouldMerge(Variable variableToCheck)
        {
            return string.Equals(variableToCheck.name, Resources.RuntimeTypeKey,
                StringComparison.OrdinalIgnoreCase) || string.Equals(variableToCheck.name,
                Resources.RuntimeUrlKey, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Set the variable value given a new value. Replace or add the value to the variable, as appropriate
        /// </summary>
        /// <param name="inVariable">The variable to change</param>
        /// <param name="addedValue">The new value to </param>
        private static void SetVariableValue(Variable inVariable, string addedValue)
        {
            if (!string.IsNullOrEmpty(inVariable.value) && ShouldMerge(inVariable))
            {
                if (inVariable.value.IndexOf(addedValue, 0, inVariable.value.Length, StringComparison.OrdinalIgnoreCase) == -1)
                {
                    inVariable.value = string.Concat(inVariable.value, ";", addedValue);
                }
            }
            else
            {
                inVariable.value = addedValue;
            }
        }

        private static Variable[] ApplySettingChanges(Dictionary<string, string> settings, Variable[] roleVariables)
        {
            int roleVariableCount = (roleVariables == null ? 0 : roleVariables.Length);
            if (roleVariableCount > 0)
            {
                for (int j = 0; j < roleVariables.Length; ++j)
                {
                    if (settings.ContainsKey(roleVariables[j].name))
                    {
                        SetVariableValue(roleVariables[j], settings[roleVariables[j].name]);
                        settings.Remove(roleVariables[j].name);
                    }
                }
            }

            int settingsCount = (settings == null ? 0 : settings.Count);
            Variable[] newSettings = new Variable[settingsCount + roleVariableCount];
            int i = 0;
            foreach (string key in settings.Keys)
            {
                newSettings[i] = new Variable { name = key, value = settings[key] };
                ++i;
            }

            for (int j = 0; j < roleVariables.Length; ++j)
            {
                newSettings[i + j] = roleVariables[j];
            }

            return newSettings;
        }

        private static void ApplyRoleXmlChanges(Dictionary<string, string> changes, WebRole webRole)
        {
            GetRuntimeStartupTask(webRole.Startup).Environment = ApplySettingChanges(changes, GetRuntimeStartupTask(webRole.Startup).Environment);
        }

        private static void ApplyRoleXmlChanges(Dictionary<string, string> changes, WorkerRole workerRole)
        {
            GetRuntimeStartupTask(workerRole.Startup).Environment = ApplySettingChanges(changes, GetRuntimeStartupTask(workerRole.Startup).Environment);
        }

        public static void ClearRuntime(WebRole role)
        {
            Task startupTask = GetRuntimeStartupTask(role.Startup);
            if (startupTask != null)
            {
                ClearEnvironmentValue(startupTask.Environment, Resources.RuntimeUrlKey);
                ClearEnvironmentValue(startupTask.Environment, Resources.CacheRuntimeUrl);
            }
        }

        public static void ClearRuntime(WorkerRole role)
        {
             Task startupTask = GetRuntimeStartupTask(role.Startup);
             if (startupTask != null)
             {
                 ClearEnvironmentValue(startupTask.Environment, Resources.RuntimeUrlKey);
                 ClearEnvironmentValue(startupTask.Environment, Resources.CacheRuntimeUrl);
             }
        }

        static void ClearEnvironmentValue(Variable[] environment, string key)
        {
            foreach (Variable variable in environment)
            {
                if (string.Equals(key, variable.name, StringComparison.OrdinalIgnoreCase))
                {
                    variable.value = "";
                }
            }
        }

        public virtual void ApplyRuntime(CloudRuntimePackage package, WebRole webRole)
        {
            Dictionary<string, string> changes;
            if (this.GetChanges(package, out changes))
            {
                ApplyRoleXmlChanges(changes, webRole);
            }

            ApplyScaffoldingChanges(package);
        }

        public virtual void ApplyRuntime(CloudRuntimePackage package, WorkerRole workerRole)
        {
            Dictionary<string, string> changes;
            if (this.GetChanges(package, out changes))
            {
                ApplyRoleXmlChanges(changes, workerRole);
            }

            ApplyScaffoldingChanges(package);
        }

        protected virtual void ApplyScaffoldingChanges(CloudRuntimePackage package)
        {

        }

        public abstract bool Match(CloudRuntimePackage runtime);

        public virtual bool ValidateMatch(CloudRuntimePackage runtime, out string warningText)
        {
            warningText = null;
            bool result = this.Match(runtime);
            if (!result)
            {
                warningText = this.GenerateWarningText(runtime);
            }

            return result;
        }

        protected abstract void Configure(Dictionary<string, string> environment);

        protected abstract string GenerateWarningText(CloudRuntimePackage package);

        protected virtual bool GetChanges(CloudRuntimePackage package, out Dictionary<string, string> changes)
        {
            changes = new Dictionary<string, string>();
            changes[Resources.RuntimeTypeKey] = package.Runtime.ToString().ToLower();
            changes[Resources.RuntimeUrlKey] = package.PackageUri.ToString();
            return true;
        }

        private class IISNodeCloudRuntime : JavaScriptCloudRuntime
        {

            public override bool Match(CloudRuntimePackage runtime)
            {
                // here is where we would put in semver semantics
                return string.Equals(this.Version, runtime.Version, StringComparison.OrdinalIgnoreCase);
            }

            protected override string GetEngineKey()
            {
                return Resources.IISNodeEngineKey;
            }

            protected override string GetDefaultVersion()
            {
                string fileVersion = Resources.DefaultFileVersion;
                string iisnodePath = Path.Combine(GetProgramFilesDirectoryPathx86(), Path.Combine(Resources.IISNodePath, Resources.IISNodeDll));
                if (File.Exists(iisnodePath))
                {
                    fileVersion = GetFileVersion(iisnodePath);
                }

                return fileVersion;
            }

            protected override string GenerateWarningText(CloudRuntimePackage package)
            {
                return string.Format(Resources.IISNodeVersionWarningText, package.Version,
                        this.RoleName, this.Version);
            }
        }

        abstract class JavaScriptCloudRuntime : CloudRuntime
        {
            protected override void Configure(Dictionary<string, string> environment)
            {
                if (string.IsNullOrEmpty(this.Version))
                {
                    string version;
                    if (!TryGetVersionFromPackageJson(GetEngineKey(), out version))
                    {
                        version = GetDefaultVersion();
                    }

                    this.Version = version;
                }
            }

            protected abstract string GetDefaultVersion();
            protected abstract string GetEngineKey();

            protected virtual bool TryGetVersionFromPackageJson(string engineKey, out string version)
            {
                version = null;
                JavaScriptPackageHelpers.EnsurePackageJsonExists(this.FilePath, this.RoleName);
                return JavaScriptPackageHelpers.TryGetEngineVersion(this.FilePath, engineKey, out version);
            }

            public override bool Match(CloudRuntimePackage runtime)
            {
                // here is where we would put in semver semantics
                return string.Equals(this.Version, runtime.Version, StringComparison.OrdinalIgnoreCase);
            }

            protected static string GetFileVersion(string filePath)
            {
                return FileVersionInfo.GetVersionInfo(filePath).ProductVersion;
            }

            protected static string GetProgramFilesDirectoryPathx86()
            {
                string returnPath = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
                if (string.IsNullOrEmpty(returnPath))
                {
                    returnPath = GetProgramFilesDirectory();
                }

                return returnPath;
            }

            protected static string GetProgramFilesDirectory()
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }

            protected override void ApplyScaffoldingChanges(CloudRuntimePackage package)
            {
                JavaScriptPackageHelpers.EnsurePackageJsonExists(this.FilePath, this.RoleName);
                JavaScriptPackageHelpers.TrySetEngineVersion(this.FilePath, GetEngineKey(), package.Version);
            }
        }

        private class NodeCloudRuntime : JavaScriptCloudRuntime
        {
            protected override string GetEngineKey()
            {
                return Resources.NodeEngineKey;
            }

            protected override string GenerateWarningText(CloudRuntimePackage package)
            {
                return string.Format(Resources.NodeVersionWarningText, package.Version,
                        this.RoleName, this.Version);
            }

            protected override string GetDefaultVersion()
            {
                string fileVersion = Resources.DefaultFileVersion;
                string nodePath = Path.Combine(GetProgramFilesDirectoryPathx86(), Path.Combine(Resources.NodeDirectory, Resources.NodeExe));
                if (!File.Exists(nodePath))
                {
                    nodePath = Path.Combine(GetProgramFilesDirectory(), Path.Combine(Resources.NodeDirectory, Resources.NodeExe));
                }
                if (File.Exists(nodePath))
                {
                    fileVersion = GetFileVersion(nodePath);
                }

                return fileVersion;
            }
        }

        private class PHPCloudRuntime : CloudRuntime
        {
            protected override void Configure(Dictionary<string, string> environment)
            {
                this.Runtime = RuntimeType.PHP;

                if (string.IsNullOrEmpty(this.Version))
                {
                    string version = Resources.PHPDefaultRuntimeVersion;
                    environment.TryGetValue(Resources.RuntimeVersionPrimaryKey, out version);
                    this.Version = version;
                }
            }

            public override bool Match(CloudRuntimePackage runtime)
            {
                return this.Version.Equals(runtime.Version, StringComparison.OrdinalIgnoreCase);
            }

            protected override string GenerateWarningText(CloudRuntimePackage package)
            {
                return string.Format(Resources.PHPVersionWarningText, package.Version, this.RoleName,
                    this.Version);
            }

            protected override bool GetChanges(CloudRuntimePackage package, out Dictionary<string, string> changes)
            {
                bool succeed = base.GetChanges(package, out changes);
                changes[Resources.RuntimeVersionPrimaryKey] = package.Version;
                return succeed;
            }

            protected override void ApplyScaffoldingChanges(CloudRuntimePackage package)
            {
                
            }
        }

        private class NullCloudRuntime : CloudRuntime
        {
            public override bool Match(CloudRuntimePackage runtime)
            {
                return true;
            }

            protected override void Configure(Dictionary<string, string> environment)
            {
            }

            protected override string GenerateWarningText(CloudRuntimePackage package)
            {
                return null;
            }

            protected override bool GetChanges(CloudRuntimePackage package, out Dictionary<string, string> changes)
            {
                changes = null;
                return false;
            }

            protected override void ApplyScaffoldingChanges(CloudRuntimePackage package)
            {
            }
        }
    }
}
