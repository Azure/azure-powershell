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
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.CloudService
{
    using TestResources = Commands.Common.Test.Properties.Resources;

    public class RuntimePackageHelper
    {
        /// <summary>
        /// Write out the test manifest file to a directory under the rootPath
        /// </summary>
        /// <param name="helper">The file system helper being used for the test</param>
        /// <returns>The path to the test manifest file</returns>
        public static string GetTestManifest(FileSystemHelper helper)
        {
            string filePath = helper.CreateEmptyFile("testruntimemanifest.xml");
            File.WriteAllText(filePath, TestResources.testruntimemanifest);
            return filePath;
        }

        /// <summary>
        /// Set the runtime properties for a role
        /// </summary>
        /// <param name="definition">The service containing the role</param>
        /// <param name="roleName">The name of the role to change</param>
        /// <param name="path">The path to the service</param>
        /// <param name="version">The version of the runtime to be installed</param>
        /// <param name="overrideUrl">The value of the override url, if the user wants to opt out of the system</param>
        /// <returns>true if the settings were successfully changed</returns>
        public static bool SetRoleRuntime(ServiceDefinition definition, string roleName, CloudProjectPathInfo path, string version = null, string overrideUrl = null)
        {
            bool changed = false;
            Variable[] environment = GetRoleRuntimeEnvironment(definition, roleName);
            if (version != null)
            {
                string filePath = Path.Combine(path.RootPath, roleName, "package.json");
                File.WriteAllText(filePath, string.Format(TestResources.ValidPackageJson, "testapp", version));
                changed = true;
            }


            if (overrideUrl != null)
            {
                environment = SetRuntimeEnvironment(environment, Resources.RuntimeOverrideKey, overrideUrl);
                changed = true;
            }

            return changed && ApplyRuntimeChanges(definition, roleName, environment);
        }

        /// <summary>
        /// Get the resolved runtime url for the runtime that will be installed on the given role
        /// </summary>
        /// <param name="definition">The service definition containing the role</param>
        /// <param name="roleName">The name of the role</param>
        /// <returns>The resolved runtime url for the runtime package to be installed on the role</returns>
        public static string GetRoleRuntimeUrl(ServiceDefinition definition, string roleName)
        {
            Variable v = GetRoleRuntimeEnvironment(definition, roleName).FirstOrDefault<Variable>(
                variable => string.Equals(variable.name, Resources.RuntimeUrlKey));
            return (null == v ? null : v.value);
        }

        /// <summary>
        /// Get the override url for the specified role
        /// </summary>
        /// <param name="definition">The service definition containing the role</param>
        /// <param name="roleName">The name of the role</param>
        /// <returns>The user-specified url of a privately hosted runtime to be insytalled on the role (if any) </returns>
        public static string GetRoleRuntimeOverrideUrl(ServiceDefinition definition, string roleName)
        {
            Variable v = GetRoleRuntimeEnvironment(definition, roleName).FirstOrDefault<Variable>(
                variable => string.Equals(variable.name, Resources.RuntimeOverrideKey));
            return (null == v ? null : v.value);
        }

        /// <summary>
        /// Validate that the actual role runtime values for the given role match the given expected values
        /// </summary>
        /// <param name="definition">The service definition containing the role to validate</param>
        /// <param name="roleName">The name of the role to validate</param>
        /// <param name="runtimeUrl">The resolved runtime url for the role</param>
        /// <param name="overrideUrl">The override url for the role runtime</param>
        public static void ValidateRoleRuntime(ServiceDefinition definition, string roleName, string runtimeUrl,
            string overrideUrl)
        {
            string actualRuntimeUrl = GetRoleRuntimeUrl(definition, roleName);
            string actualOverrideUrl = GetRoleRuntimeOverrideUrl(definition, roleName);
            Assert.IsTrue(VerifySetting(runtimeUrl, actualRuntimeUrl), string.Format(
                "Actual runtime URL '{0}' does not match expected runtime URL '{1}'", actualRuntimeUrl, runtimeUrl));
            Assert.IsTrue(VerifySetting(overrideUrl, actualOverrideUrl), string.Format(
                "Actual override URL '{0}' does not match expected override URL '{1}'", actualOverrideUrl, overrideUrl));
        }

        /// <summary>
        /// Asserts that given environment variable exists with it's associated value.
        /// </summary>
        /// <param name="roleStartup">The role startup</param>
        /// <param name="variableName">The environment variable name</param>
        /// <param name="expectedValue">The expected value</param>
        public static void ValidateRoleRuntimeVariable(Startup roleStartup, string variableName, string expectedValue)
        {
            string actualValue;
            Assert.IsTrue(TryGetEnvironmentValue(roleStartup.Task, variableName, out actualValue));
            Assert.AreEqual<string>(expectedValue, actualValue);
        }

        /// <summary>
        /// Verify that a given role variable setting matches expectations, null, blank, empty and whitespace only values 
        /// are counted as equivalent
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value (from the definition)</param>
        /// <returns>True if the expected and actaul values match</returns>
        private static bool VerifySetting(string expected, string actual)
        {
            if (string.IsNullOrWhiteSpace(expected))
            {
                return string.IsNullOrWhiteSpace(actual);
            }

            return string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Apply the specified Variable values to the specified role's startup task environment
        /// </summary>
        /// <param name="definition">The service definition containing the role</param>
        /// <param name="roleName">The name of the role to change</param>
        /// <param name="environment">The Variables containing the changes</param>
        /// <returns>true if the variables environment is successfully changed</returns>
        private static bool ApplyRuntimeChanges(ServiceDefinition definition, string roleName, Variable[] environment)
        {
            WebRole webRole;
            if (TryGetWebRole(definition, roleName, out webRole))
            {
                CloudRuntime.GetRuntimeStartupTask(webRole.Startup).Environment = environment;
                return true;
            }

            WorkerRole workerRole;
            if (TryGetWorkerRole(definition, roleName, out workerRole))
            {
                CloudRuntime.GetRuntimeStartupTask(workerRole.Startup).Environment = environment;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds the specified runtime environment setting to the specified runtime environment - either changes the setting in 
        /// the environment if the setting already exists, or adds a new setting if it does not
        /// </summary>
        /// <param name="environment">The source runtime environment</param>
        /// <param name="keyName">The variable key</param>
        /// <param name="keyValue">The variable value</param>
        /// <returns>The runtime environment with the given setting applied</returns>
        private static Variable[] SetRuntimeEnvironment(IEnumerable<Variable> environment, string keyName, string keyValue)
        {
            Variable v = environment.FirstOrDefault<Variable>(variable => string.Equals(variable.name, keyName,
                StringComparison.OrdinalIgnoreCase));
            if (v != null)
            {
                v.value = keyValue;
                return environment.ToArray<Variable>();
            }
            else
            {
                v = new Variable { name = keyName, value = keyValue };
                return environment.Concat<Variable>(new List<Variable> { v }).ToArray<Variable>();
            }
        }

        /// <summary>
        /// Get the startup task environment settings for the given role
        /// </summary>
        /// <param name="definition">The definition containign the role</param>
        /// <param name="roleName">The name of the role</param>
        /// <returns>The environment settings for the role, or null if the role is not found</returns>
        private static Variable[] GetRoleRuntimeEnvironment(ServiceDefinition definition, string roleName)
        {
            WebRole webRole;
            if (TryGetWebRole(definition, roleName, out webRole))
            {
                return CloudRuntime.GetRuntimeStartupTask(webRole.Startup).Environment;
            }

            WorkerRole workerRole;
            if (TryGetWorkerRole(definition, roleName, out workerRole))
            {
                return CloudRuntime.GetRuntimeStartupTask(workerRole.Startup).Environment;
            }

            return null;
        }

        /// <summary>
        /// Try to get the specified web role from the given definiiton
        /// </summary>
        /// <param name="definition">The service definiiton</param>
        /// <param name="roleName">The name of the role</param>
        /// <param name="role">output variable where the webRole is returned</param>
        /// <returns>true if the web role is found in the given definition</returns>
        private static bool TryGetWebRole(ServiceDefinition definition, string roleName, out WebRole role)
        {
            role = definition.WebRole.FirstOrDefault<WebRole>(r => string.Equals(r.name, roleName,
                StringComparison.OrdinalIgnoreCase));
            return role != null;
        }

        /// <summary>
        /// Try to get the specified worker role from the given definiiton
        /// </summary>
        /// <param name="definition">The service definiiton</param>
        /// <param name="roleName">The name of the role</param>
        /// <param name="role">output variable where the worker role is returned</param>
        /// <returns>true if the web role is found in the given definition</returns>
        private static bool TryGetWorkerRole(ServiceDefinition definition, string roleName, out WorkerRole role)
        {
            role = definition.WorkerRole.FirstOrDefault<WorkerRole>(r => string.Equals(r.name, roleName,
                StringComparison.OrdinalIgnoreCase));
            return role != null;
        }

        /// <summary>
        /// Return the value for the specified setting, if it exists in the given runtime environment
        /// </summary>
        /// <param name="environment">The runtime environment to search</param>
        /// <param name="key">The name of the setting</param>
        /// <param name="value">The value of the setting, if it is found, null otherwise</param>
        /// <returns>true if the setting is found in the given environment</returns>
        private static bool TryGetEnvironmentValue(Task[] tasks, string key, out string value)
        {
            value = string.Empty;

            foreach (Task task in tasks)
            {
                Variable[] environment = task.Environment;
                value = null;
                if (environment != null)
                {
                    foreach (Variable setting in environment)
                    {
                        if (string.Equals(setting.name, key, StringComparison.OrdinalIgnoreCase))
                        {
                            value = setting.value;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static XmlDocument GetManifest(string manifest)
        {
            XmlDocument document = new XmlDocument();
            document.Load(XmlReader.Create(new MemoryStream(File.ReadAllBytes(manifest))));
            return document;
        }

        private static List<CloudRuntimePackage> GetNodesFromManifest(string manifestFile, string runtimeType = null)
        {
            List<CloudRuntimePackage> packages = new List<CloudRuntimePackage>();
            XmlDocument document = new XmlDocument();
            XmlReader reader = XmlReader.Create(new MemoryStream(File.ReadAllBytes(manifestFile)));
            document.Load(reader);
            XmlNodeList items = document.SelectNodes("/runtimemanifest/runtimes/runtime");
            foreach (XmlNode node in items)
            {
                if (string.IsNullOrEmpty(runtimeType) || string.Equals(node.Attributes["type"].Value, runtimeType, StringComparison.OrdinalIgnoreCase))
                {
                    packages.Add(new CloudRuntimePackage(node, "http://DATACENTER/"));
                }
            }

            reader.Close();
            return packages;
        }

        public static void ValidateRuntimesMatchManifest(string manifestFile, IEnumerable<CloudRuntimePackage> packages, string runtimeType = null)
        {
            List<CloudRuntimePackage> allPackages = GetNodesFromManifest(manifestFile, runtimeType);
            foreach (CloudRuntimePackage package in packages)
            {
                Assert.AreEqual(1, allPackages.Count<CloudRuntimePackage>(
                    p => p.Runtime.Equals(package.Runtime) && string.Equals(p.Version, package.Version,
                        StringComparison.OrdinalIgnoreCase)));

            }
        }
    }
}
