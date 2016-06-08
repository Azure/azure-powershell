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
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.Scaffolding;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Utilities;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    /// <summary>
    /// Class that encapsulates all of the info about a service, to which we can add roles.  This is all in memory, so no disk operations occur.
    /// </summary>
    public class CloudServiceProject
    {
        public CloudProjectPathInfo Paths { get; private set; }

        public ServiceComponents Components { get; private set; }
        
        private string scaffoldingFolderPath;

        public string ServiceName 
        { 
            get 
            {
                if (Components.Definition != null)
                {
                    return this.Components.Definition.name;
                }
                else
                {
                    return this.Components.CloudConfig.serviceName;
                }
            } 
        }

        
        public CloudServiceProject(string rootPath, string name, string scaffoldingPath)
            : this()
        {
            Validate.ValidateDirectoryFull(rootPath, Resources.ServiceParentDirectory);
            Validate.ValidateStringIsNullOrEmpty(name, "Name");
            Validate.ValidateFileName(name, string.Format(Resources.InvalidFileName, "Name"));
            Validate.ValidateDnsName(name, "Name");

            string newServicePath = Path.Combine(rootPath, name);
            if (Directory.Exists(newServicePath))
            {
                throw new ArgumentException(string.Format(Resources.ServiceAlreadyExistsOnDisk, name, newServicePath));
            }

            SetScaffolding(scaffoldingPath);
            Paths = new PowerShellProjectPathInfo(newServicePath);
            CreateNewService(Paths.RootPath, name);
            Components = new ServiceComponents(Paths);
            ConfigureNewService(Components, Paths, name);
        }

        //for stopping the emulator none of the path info is required
        public CloudServiceProject()
        {
        }

        public CloudServiceProject(string cloudConfigurationFullPath)
        {
            Components = new ServiceComponents(cloudConfigurationFullPath);
            //since we are deploying from a prebuilt package, it doesn't matter whether
            //it comes from visual studio or powershell tools. 
            //Here we just go with powershell one, because it is simple.
            Paths = new PowerShellProjectPathInfo(Path.GetDirectoryName(cloudConfigurationFullPath));
        }

        public CloudServiceProject(string rootPath, string scaffoldingPath)
        {
            SetScaffolding(scaffoldingPath);

            if (!VisualStudioProjectPathInfo.IsVisualStudioProject(rootPath))
            {
                Paths = new PowerShellProjectPathInfo(rootPath);
            }
            else
            {
                Paths = new VisualStudioProjectPathInfo(rootPath);
            }

            Components = new ServiceComponents(Paths);
        }

        private void SetScaffolding(string scaffoldingFolderDirectory)
        {
            if (string.IsNullOrEmpty(scaffoldingFolderDirectory))
            {
                scaffoldingFolderPath = FileUtilities.GetAssemblyDirectory();
            }
            else
            {
                Validate.ValidateDirectoryExists(scaffoldingFolderDirectory);

                scaffoldingFolderPath = scaffoldingFolderDirectory;
            }
        }

        private void ConfigureNewService(ServiceComponents components, CloudProjectPathInfo paths, string serviceName)
        {
            Components.Definition.name = serviceName;
            Components.CloudConfig.serviceName = serviceName;
            Components.LocalConfig.serviceName = serviceName;
            Components.Save(paths);
        }

        private void CreateNewService(string serviceRootPath, string serviceName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters[ScaffoldParams.Slot] = string.Empty;
            parameters[ScaffoldParams.Subscription] = string.Empty;
            parameters[ScaffoldParams.Location] = string.Empty;
            parameters[ScaffoldParams.StorageAccountName] = string.Empty;
            parameters[ScaffoldParams.ServiceName] = serviceName;

            Scaffold.GenerateScaffolding(Path.Combine(scaffoldingFolderPath, Resources.GeneralScaffolding), serviceRootPath, parameters);
        }

        /// <summary>
        /// Generates scaffolding for role.
        /// </summary>
        /// <param name="scaffolding">The relative scaffolding source path</param>
        /// <param name="roleName">The role name</param>
        /// <param name="parameters">The rule parameters</param>
        public void GenerateScaffolding(string scaffolding, string roleName, Dictionary<string, object> parameters)
        {
            string scaffoldPath = Path.Combine(scaffoldingFolderPath, scaffolding);
            Scaffold.GenerateScaffolding(scaffoldPath, Path.Combine(Paths.RootPath, roleName), parameters);
        }

        /// <summary>
        /// Creates a role name, ensuring it doesn't already exist.  If null is passed in, a number will be appended to the defaultRoleName.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultName"></param>
        /// <param name="existingNames"></param>
        /// <returns></returns>
        private string GetRoleName(string name, string defaultName, IEnumerable<string> existingNames)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (existingNames.Contains(name.ToLower()))
                {
                    // Role does exist, user should pick a unique name
                    //
                    throw new ArgumentException(string.Format(Resources.AddRoleMessageRoleExists, name));
                }

                if (!ServiceComponents.ValidRoleName(name))
                {
                    // The provided name is invalid role name
                    //
                    throw new ArgumentException(string.Format(Resources.InvalidRoleNameMessage, name));
                }
            }

            if (name == null)
            {
                name = defaultName;
            }
            else
            {
                return name;
            }

            int index = 1;
            string curName = name + index.ToString();
            while (existingNames.Contains(curName.ToLower()))
            {
                curName = name + (++index).ToString();
            }
            return curName;
        }

        /// <summary>
        /// Adds the given role to both config files and the service def.
        /// </summary>
        private void AddRoleCore(string scaffolding, RoleInfo role)
        {
            Dictionary<string, object> parameters = CreateDefaultParameters(role);
            parameters[ScaffoldParams.NodeModules] = Path.Combine(
                FileUtilities.GetAssemblyDirectory(),
                Resources.NodeModulesPath);
            parameters[ScaffoldParams.NodeJsProgramFilesX86] = FileUtilities.GetWithProgramFilesPath(Resources.NodeProgramFilesFolderName, false);

            GenerateScaffolding(scaffolding, role.Name, parameters);
        }

        private Dictionary<string, object> CreateDefaultParameters(RoleInfo role)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters[ScaffoldParams.Role] = role;
            parameters[ScaffoldParams.Components] = Components;
            parameters[ScaffoldParams.RoleName] = role.Name;
            parameters[ScaffoldParams.InstancesCount] = role.InstanceCount;
            parameters[ScaffoldParams.Port] = Components.GetNextPort();
            parameters[ScaffoldParams.Paths] = Paths;
            return parameters;
        }

        public RoleInfo AddWebRole(
            string scaffolding,
            string name = null,
            int instanceCount = 1)
        {
            name = GetRoleName(name, Resources.WebRole, Components.Definition.WebRole == null ? 
                new string[0] : 
                Components.Definition.WebRole.Select(wr => wr.name.ToLower()));
            
            WebRoleInfo role = new WebRoleInfo(name, instanceCount);
            
            AddRoleCore(scaffolding, role);

            return role;
        }

        public RoleInfo AddWorkerRole(
            string scaffolding,
            string name = null,
            int instanceCount = 1)
        {
            name = GetRoleName(name, Resources.WorkerRole, Components.Definition.WorkerRole == null ? 
                new string[0] : 
                Components.Definition.WorkerRole.Select(wr => wr.name.ToLower()));
            
            WorkerRoleInfo role = new WorkerRoleInfo(name, instanceCount);
            
            AddRoleCore(scaffolding, role);

            return role;
        }

        public void ChangeRolePermissions(RoleInfo role)
        {
            string rolePath = Path.Combine(Paths.RootPath, role.Name);
            DirectoryInfo directoryInfo = new DirectoryInfo(rolePath);
            DirectorySecurity directoryAccess = directoryInfo.GetAccessControl(AccessControlSections.All);
            directoryAccess.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.NetworkServiceSid, null),
                FileSystemRights.ReadAndExecute | FileSystemRights.Write, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            directoryInfo.SetAccessControl(directoryAccess);
        }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public void CreatePackage(DevEnv type)
        {
            string standardOutput, standardError;
            VerifyCloudServiceProjectComponents();
            CsPack packageTool = new CsPack();
            packageTool.CreatePackage(Components.Definition, Paths, type, AzureTool.GetAzureSdkBinDirectory(), out standardOutput, out standardError);
            if (!string.IsNullOrWhiteSpace(standardError))
            {
                //The error of invalid xpath expression about endpoint in the configuration file is expected. Hence, we do not throw.
                if (!standardError.Contains("/RoleEnvironment/CurrentInstance/Endpoints/Endpoint[@name='HttpIn']/@port"))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.FailedToCreatePackage, standardError));
                }
            }
        }

        private void VerifyCloudServiceProjectComponents()
        {
            string CacheVersion = AzureTool.SupportAzureSdkVersion;

            foreach (string roleName in Components.GetRoles())
            {
                string value = Components.GetStartupTaskVariable(
                    roleName,
                    Resources.CacheRuntimeVersionKey,
                    Resources.WebRoleStartupTaskCommandLine,
                    Resources.WorkerRoleStartupTaskCommandLine);

                if (!string.IsNullOrEmpty(value) && !string.Equals(value, CacheVersion, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception(string.Format(Microsoft.WindowsAzure.Commands.Utilities.Properties.Resources.CacheMismatchMessage, roleName, CacheVersion));
                }
            }
        }

        /// <summary>
        /// Starts azure emulator for this service.
        /// </summary>
        /// <remarks>This methods removes all deployments already in the emulator.</remarks>
        /// <param name="launchBrowser">Switch to control opening a browser for web roles.</param>
        /// <param name="mode"></param>
        /// <param name="roleInformation"></param>
        /// <param name="warning"></param>
        public void StartEmulators(bool launchBrowser, ComputeEmulatorMode mode , out string roleInformation, out string warning)
        {
            var runTool = new CsRun(AzureTool.GetComputeEmulatorDirectory());
            runTool.StartEmulator(Paths.LocalPackage, Paths.LocalConfiguration, launchBrowser, mode);

            roleInformation = runTool.RoleInformation;

            var storageEmulator = new StorageEmulator(AzureTool.GetStorageEmulatorDirectory());
            storageEmulator.Start();

            //for now, errors related with storage emulator are treated as non-fatal  
            warning = storageEmulator.Error;
        }

        public void StopEmulators(out string warning)
        {
            var runTool = new CsRun(AzureTool.GetComputeEmulatorDirectory());
            runTool.StopComputeEmulator();

            var storageEmulator = new StorageEmulator(AzureTool.GetStorageEmulatorDirectory());
            storageEmulator.Stop();
            //for now, errors related with storage emulator are treated as non-fatal  
            warning = storageEmulator.Error;
        }

        public void ChangeServiceName(string newName, CloudProjectPathInfo paths)
        {
            Validate.ValidateDnsName(newName, "service name");

            Components.Definition.name = newName;
            Components.CloudConfig.serviceName = newName;
            Components.LocalConfig.serviceName = newName;
            Components.Save(paths);
        }

        /// <summary>
        /// Sets the role instance count
        /// </summary>
        /// <param name="paths">The service paths</param>
        /// <param name="roleName">The name of the role to change its instance count</param>
        /// <param name="instances"></param>
        public void SetRoleInstances(CloudProjectPathInfo paths, string roleName, int instances)
        {
            Components.SetRoleInstances(roleName, instances);
            Components.Save(paths);
        }

        /// <summary>
        /// Sets the role VMSize
        /// </summary>
        /// <param name="paths">The service paths</param>
        /// <param name="roleName">The name of the role to change its vm size</param>
        /// <param name="VMSize">The new role vm size</param>
        public void SetRoleVMSize(CloudProjectPathInfo paths, string roleName, string VMSize)
        {
            Components.SetRoleVMSize(roleName, VMSize);
            Components.Save(paths);
        }

        /// <summary>
        /// Retrieve currently available cloud runtimes
        /// </summary>
        /// <param name="paths">service path info</param>
        /// <param name="manifest">The manifest to use to get current runtime info - default is the cloud manifest</param>
        /// <returns></returns>
        public CloudRuntimeCollection GetCloudRuntimes(CloudProjectPathInfo paths, string manifest)
        {
            CloudRuntimeCollection collection;
            CloudRuntimeCollection.CreateCloudRuntimeCollection(out collection, manifest);
            return collection;
        }

        /// <summary>
        /// Add the specified runtime to a role, checking that the runtime and version are currently available int he cloud
        /// </summary>
        /// <param name="paths">service path info</param>
        /// <param name="roleName">Name of the role to change</param>
        /// <param name="runtimeType">The runtime identifier</param>
        /// <param name="runtimeVersion">The runtime version</param>
        /// <param name="manifest">Location fo the manifest file, default is the cloud manifest</param>
        public void AddRoleRuntime(
            CloudProjectPathInfo paths,
            string roleName,
            string runtimeType,
            string runtimeVersion,
            string manifest = null)
        {
            if (this.Components.RoleExists(roleName))
            {
                CloudRuntimeCollection collection;
                CloudRuntimeCollection.CreateCloudRuntimeCollection(out collection, manifest);
                CloudRuntime desiredRuntime = CloudRuntime.CreateCloudRuntime(runtimeType, runtimeVersion, roleName, Path.Combine(paths.RootPath, roleName));
                CloudRuntimePackage foundPackage;
                if (collection.TryFindMatch(desiredRuntime, out foundPackage))
                {
                    WorkerRole worker = (this.Components.Definition.WorkerRole == null ? null :
                        this.Components.Definition.WorkerRole.FirstOrDefault<WorkerRole>(r => string.Equals(r.name, roleName,
                            StringComparison.OrdinalIgnoreCase)));
                    WebRole web = (this.Components.Definition.WebRole == null ? null :
                        this.Components.Definition.WebRole.FirstOrDefault<WebRole>(r => string.Equals(r.name, roleName,
                            StringComparison.OrdinalIgnoreCase)));
                    desiredRuntime.CloudServiceProject = this;
                    if (worker != null)
                    {
                        desiredRuntime.ApplyRuntime(foundPackage, worker);
                    }
                    else if (web != null)
                    {
                        desiredRuntime.ApplyRuntime(foundPackage, web);
                    }

                    this.Components.Save(this.Paths);
                }
            }
        }

        /// <summary>
        /// Resolves the service runtimes into downloadable URLs.
        /// </summary>
        /// <param name="manifest">The custom manifest file</param>
        /// <returns>Warning text if any</returns>
        public string ResolveRuntimePackageUrls(string manifest = null)
        {
            ServiceSettings settings = ServiceSettings.Load(Paths.Settings);

            CloudRuntimeCollection availableRuntimePackages;

            if (!CloudRuntimeCollection.CreateCloudRuntimeCollection(out availableRuntimePackages, manifest))
            {
                throw new ArgumentException(
                    string.Format(Resources.ErrorRetrievingRuntimesForLocation,
                    settings.Location));
            }

            ServiceDefinition definition = this.Components.Definition;
            StringBuilder warningText = new StringBuilder();
            List<CloudRuntimeApplicator> applicators = new List<CloudRuntimeApplicator>();
            if (definition.WebRole != null)
            {
                foreach (WebRole role in
                    definition.WebRole.Where(role => role.Startup != null &&
                    CloudRuntime.GetRuntimeStartupTask(role.Startup) != null))
                {
                    CloudRuntime.ClearRuntime(role);
                    string rolePath = Path.Combine(this.Paths.RootPath, role.name);
                    foreach (CloudRuntime runtime in CloudRuntime.CreateRuntime(role, rolePath))
                    {
                        CloudRuntimePackage package;
                        runtime.CloudServiceProject = this;
                        if (!availableRuntimePackages.TryFindMatch(runtime, out package))
                        {
                            string warning;
                            if (!runtime.ValidateMatch(package, out warning))
                            {
                                warningText.AppendFormat("{0}\r\n", warning);
                            }
                        }

                        applicators.Add(CloudRuntimeApplicator.CreateCloudRuntimeApplicator(
                            runtime,
                            package,
                            role));
                    }
                }
            }

            if (definition.WorkerRole != null)
            {
                foreach (WorkerRole role in
                    definition.WorkerRole.Where(role => role.Startup != null &&
                    CloudRuntime.GetRuntimeStartupTask(role.Startup) != null))
                {
                    string rolePath = Path.Combine(this.Paths.RootPath, role.name);
                    CloudRuntime.ClearRuntime(role);
                    foreach (CloudRuntime runtime in CloudRuntime.CreateRuntime(role, rolePath))
                    {
                        CloudRuntimePackage package;
                        runtime.CloudServiceProject = this;
                        if (!availableRuntimePackages.TryFindMatch(runtime, out package))
                        {
                            string warning;
                            if (!runtime.ValidateMatch(package, out warning))
                            {
                                warningText.AppendFormat(warning + Environment.NewLine);
                            }
                        }
                        applicators.Add(CloudRuntimeApplicator.CreateCloudRuntimeApplicator(runtime,
                            package, role));
                    }
                }
            }

            applicators.ForEach<CloudRuntimeApplicator>(a => a.Apply());
            this.Components.Save(this.Paths);

            return warningText.ToString();
        }

        /// <summary>
        /// Reloads the cloud service project configuration from the disk.
        /// </summary>
        public void Reload()
        {
            Components = new ServiceComponents(Paths);
        }
    }
}