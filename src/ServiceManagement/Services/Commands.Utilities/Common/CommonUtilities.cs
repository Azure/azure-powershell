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
using System.IO;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public class CommonUtilities
    {
        private static string FindServiceRootDirectory(string path)
        {
            if (FileUtilities.DataStore.GetFiles(path, Resources.ServiceDefinitionFileName, SearchOption.TopDirectoryOnly).Length == 1)
            {
                return path;
            }
            else if (FileUtilities.DataStore.GetFiles(path, "*.sln", SearchOption.TopDirectoryOnly).Length == 1)
            {
                foreach (string dirName in FileUtilities.DataStore.GetDirectories(path))
                {
                    if (FileUtilities.DataStore.GetFiles(dirName, Resources.ServiceDefinitionFileName, SearchOption.TopDirectoryOnly).Length == 1)
                    {
                        return dirName;
                    }
                }
            }

            // Find the last slash
            int slash = path.LastIndexOf('\\');
            if (slash > 0)
            {
                // Slash found trim off the last path
                path = path.Substring(0, slash);

                // Recurse
                return FindServiceRootDirectory(path);
            }

            // Couldn't locate the service root, exit
            return null;
        }

        public static ServiceSettings GetDefaultSettings(
            string rootPath,
            string inServiceName,
            string slot,
            string location,
            string affinityGroup,
            string storageName,
            string subscription,
            out string serviceName)
        {
            ServiceSettings serviceSettings;

            if (string.IsNullOrEmpty(rootPath))
            {
                serviceSettings = ServiceSettings.LoadDefault(null, slot, location, affinityGroup, subscription, storageName, inServiceName, null, out serviceName);
            }
            else
            {
                serviceSettings = ServiceSettings.LoadDefault(
                    new CloudServiceProject(rootPath, null).Paths.Settings,
                    slot,
                    location,
                    affinityGroup,
                    subscription,
                    storageName,
                    inServiceName,
                    new CloudServiceProject(rootPath, null).ServiceName,
                    out serviceName);
            }

            return serviceSettings;
        }

        /// <summary>
        /// Gets role name for the current pathif exists.
        /// </summary>
        /// <returns>The role name</returns>
        public static string GetRoleName(string rootPath, string currentPath)
        {
            bool found = false;
            string roleName = null;

            if (!(rootPath.Length >= currentPath.Length))
            {
                string difference = currentPath.Replace(rootPath, string.Empty);
                roleName = difference.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).GetValue(0).ToString();
                CloudServiceProject service = new CloudServiceProject(rootPath, null);
                found = service.Components.RoleExists(roleName);
            }

            if (!found)
            {
                throw new ArgumentException(string.Format(Resources.CannotFindRole, currentPath));
            }

            return roleName;
        }

        public static string GetServiceRootPath(string currentPath)
        {
            // Get the service path
            string servicePath = FindServiceRootDirectory(currentPath);

            // Was the service path found?
            if (servicePath == null)
            {
                throw new InvalidOperationException(Resources.CannotFindServiceRoot);
            }

            CloudServiceProject service = new CloudServiceProject(servicePath, null);
            if (service.Components.CloudConfig.Role != null)
            {
                foreach (RoleSettings role in service.Components.CloudConfig.Role)
                {
                    string roleDirectory = Path.Combine(service.Paths.RolesPath, role.name);

                    if (!FileUtilities.DataStore.DirectoryExists(roleDirectory))
                    {
                        throw new InvalidOperationException(Resources.CannotFindServiceRoot);
                    }
                }
            }

            return servicePath;
        }

        /// <summary>
        /// Tries to get service path, if not return null.
        /// </summary>
        /// <param name="currentPath">The current path</param>
        /// <returns>The service root path</returns>
        public static string TryGetServiceRootPath(string currentPath)
        {
            try { return GetServiceRootPath(currentPath); }
            catch (Exception) { return null; }
        }
    }
}
