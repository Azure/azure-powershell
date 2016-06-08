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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    public class CmdletTestCloudServiceBase : CmdletTestBase
    {
        protected class Cmdlets
        {
            public const string NewWAPackCloudService = "New-WAPackCloudService";
            public const string NewWAPackVMRole = "New-WAPackVMRole";
            public const string GetWAPackCloudService = "Get-WAPackCloudService";
            public const string GetWAPackVMRole = "Get-WAPackVMRole";
            public const string SetWAPackVMRole = "Set-WAPackVMRole";
            public const string RemoveWAPackCloudService = "Remove-WAPackCloudService";
            public const string RemoveWAPackVMRole = "Remove-WAPackVMRole";
        }

        // CloudService
        protected const string cloudServiceName = "TestCloudService";
        protected const string cloudServiceLabel = "Label - TestCloudService";

        protected List<PSObject> createdCloudServices;

        // VMRole
        protected const string vmRoleNameFromCloudService = "TestVMRoleFromCloudService";
        protected const string vmRoleNameFromQuickCreate = "TestVMRoleFromQuickCreate";
        protected const string vmRoleLabelToCreate = "Label - TestVMRole";

        protected List<PSObject> createdVMRolesFromQuickCreate;
        protected List<PSObject> createdVMRolesFromCloudService;

        // Error handling
        protected const string nonExistantResourceExceptionMessage = "The remote server returned an error: (404) Not Found.";
        protected const string assertFailedNonExistantRessourceExceptionMessage = "Assert.IsFalse failed. " + nonExistantResourceExceptionMessage;

        protected CmdletTestCloudServiceBase()
        {
            this.createdCloudServices = new List<PSObject>();
            this.createdVMRolesFromQuickCreate = new List<PSObject>();
            this.createdVMRolesFromCloudService = new List<PSObject>();
        }

        protected void CreateCloudService()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", cloudServiceName},
                {"Label", cloudServiceLabel}
            };
            var createdCloudService = this.InvokeCmdlet(Cmdlets.NewWAPackCloudService, inputParams);
            Assert.AreEqual(1, createdCloudService.Count, string.Format("Actual CloudServices found - {0}, Expected CloudServices - {1}", createdCloudService.Count, 1));

            var readCloudServiceName = createdCloudService.First().Properties["Name"].Value;
            Assert.AreEqual(cloudServiceName, readCloudServiceName, string.Format("Actual CloudService name - {0}, Expected CloudService name- {1}", readCloudServiceName, cloudServiceName));

            var readCloudServiceLabel = createdCloudService.First().Properties["Label"].Value;
            Assert.AreEqual(cloudServiceLabel, readCloudServiceLabel, string.Format("Actual CloudService Label - {0}, Expected CloudService Label- {1}", readCloudServiceLabel, cloudServiceLabel));

            var readCloudServiceProvisioningState = createdCloudService.First().Properties["ProvisioningState"].Value;
            Assert.AreEqual("Provisioned", readCloudServiceProvisioningState, string.Format("Actual CloudService Provisionning State - {0}, Expected CloudService name- {1}", readCloudServiceProvisioningState, "Provisioned"));

            this.createdCloudServices.AddRange(createdCloudService);
        }

        protected void CloudServicePreTestCleanup()
        {
            try
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"Name", cloudServiceName}
                };
                var existingCloudServices = this.InvokeCmdlet(Cmdlets.GetWAPackCloudService ,inputParams);

                if (existingCloudServices != null && existingCloudServices.Any())
                {
                    this.createdCloudServices.AddRange(existingCloudServices);
                    this.RemoveCloudServices();
                }
            }
            catch (AssertFailedException e)
            {
                Assert.AreEqual(assertFailedNonExistantRessourceExceptionMessage, e.Message);
            }
        }

        protected void RemoveCloudServices()
        {
            foreach (var cloudService in this.createdCloudServices)
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"CloudService", cloudService},
                    {"Force", null},
                    {"PassThru", null}
                };
                var isDeleted = this.InvokeCmdlet(Cmdlets.RemoveWAPackCloudService, inputParams, null);
                Assert.AreEqual(1, isDeleted.Count);
                Assert.AreEqual(true, isDeleted.First());

                inputParams = new Dictionary<string, object>()
                {
                    {"Name", cloudServiceName}
                };
                var deletedCloudService = this.InvokeCmdlet(Cmdlets.GetWAPackCloudService, inputParams, nonExistantResourceExceptionMessage);
                Assert.AreEqual(0, deletedCloudService.Count);
            }

            this.createdCloudServices.Clear();
        }

        protected void CreateVMRoleFromQuickCreate()
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>()
            {
                {"Name", vmRoleNameFromQuickCreate},
                {"Label", vmRoleLabelToCreate},
                {"ResourceDefinition", GetBasicResDef()}
            };
            var createdVMRole = this.InvokeCmdlet(Cmdlets.NewWAPackVMRole, inputParams, null);

            Assert.AreEqual(1, createdVMRole.Count, string.Format("Actual VMRoles found - {0}, Expected VMRoles - {1}", createdVMRole.Count, 1));
            var createdVMRoleName = createdVMRole.First().Properties["Name"].Value;

            Assert.AreEqual(vmRoleNameFromQuickCreate, createdVMRoleName, string.Format("Actual VMRoles Name - {0}, Expected VMRoles Name- {1}", createdVMRoleName, vmRoleNameFromQuickCreate));
            this.createdVMRolesFromQuickCreate.AddRange(createdVMRole);
        }

        protected void CreateVMRoleFromCloudService()
        {
            this.CreateCloudService();

            Dictionary<string, object> inputParams = new Dictionary<string, object>()
            {
                {"Name", vmRoleNameFromCloudService},
                {"Label", vmRoleLabelToCreate},
                {"CloudService", this.createdCloudServices.First()},
                {"ResourceDefinition", GetBasicResDef()}
            };
            var createdVMRole = this.InvokeCmdlet(Cmdlets.NewWAPackVMRole, inputParams, null);

            Assert.AreEqual(1, createdVMRole.Count, string.Format("Actual VMRoles found - {0}, Expected VMRoles - {1}", createdVMRole.Count, 1));
            var createdVMRoleName = createdVMRole.First().Properties["Name"].Value;

            Assert.AreEqual(vmRoleNameFromCloudService, createdVMRoleName, string.Format("Actual VMRoles Name - {0}, Expected VMRoles Name- {1}", createdVMRoleName, vmRoleNameFromCloudService));
            this.createdVMRolesFromCloudService.AddRange(createdVMRole);
        }

        protected void VMRolePreTestCleanup()
        {
            // Cleaning up VMRole on cloudservice having the same name as the VMRole (QuickCreateVMRole)
            try
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"Name", vmRoleNameFromQuickCreate}
                };
                var existingVMRoles = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams, null);

                if (existingVMRoles != null && existingVMRoles.Any())
                {
                    this.createdVMRolesFromQuickCreate.AddRange(existingVMRoles);
                }

                this.RemoveVMRoles();
            }
            catch (AssertFailedException e)
            {
                Assert.AreEqual(assertFailedNonExistantRessourceExceptionMessage, e.Message);
            }

            // Cleaning up VMRole created on existing CloudServices
            try
            {
                if (this.createdCloudServices.Any())
                {
                    var inputParams = new Dictionary<string, object>()
                    {
                        {"Name", vmRoleNameFromCloudService},
                        {"CloudService", this.createdCloudServices.First()}
                    };
                    var existingVMRoles = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams, null);

                    if (existingVMRoles != null && existingVMRoles.Any())
                    {
                        this.createdVMRolesFromCloudService.AddRange(existingVMRoles);
                    }

                    this.RemoveVMRoles();
                }
            }
            catch (AssertFailedException e)
            {
                Assert.AreEqual(assertFailedNonExistantRessourceExceptionMessage, e.Message);
            }
        }

        protected void RemoveVMRoles()
        {
            foreach (var vmRole in this.createdVMRolesFromQuickCreate)
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"VMRole", vmRole},
                    {"Force", null},
                    {"PassThru", null}
                };
                var isDeleted = this.InvokeCmdlet(Cmdlets.RemoveWAPackVMRole, inputParams, null);
                Assert.AreEqual(1, isDeleted.Count);
                Assert.AreEqual(true, isDeleted.First());

                inputParams = new Dictionary<string, object>()
                {
                    {"Name", vmRoleNameFromQuickCreate}
                };
                var deletedVMRole = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams, nonExistantResourceExceptionMessage);
                Assert.AreEqual(0, deletedVMRole.Count);                
            }

            foreach (var vmRole in this.createdVMRolesFromCloudService)
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"VMRole", vmRole},
                    {"CloudServiceName", cloudServiceName},
                    {"Force", null},
                    {"PassThru", null}
                };
                var isDeleted = this.InvokeCmdlet(Cmdlets.RemoveWAPackVMRole, inputParams, null);
                Assert.AreEqual(1, isDeleted.Count);
                Assert.AreEqual(true, isDeleted.First());

                inputParams = new Dictionary<string, object>()
                {
                    {"Name", vmRoleNameFromCloudService},
                    {"CloudServiceName", cloudServiceName}
                };
                var deletedVMRole = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams, nonExistantResourceExceptionMessage);
                Assert.AreEqual(0, deletedVMRole.Count);          
            }

            this.createdVMRolesFromQuickCreate.Clear();
        }

        protected VMRoleResourceDefinition GetBasicResDef()
        {
            var resdef = new VMRoleResourceDefinition();

            // Resdef
            resdef.Name = "NoAppIPv6";
            resdef.Publisher = "Microsoft";
            resdef.SchemaVersion = "1.0";
            resdef.Version = "1.0.0.0";
            resdef.Type = "Microsoft.Compute/VMRole/1.0";

            // Hardware Profile
            resdef.IntrinsicSettings.HardwareProfile.VMSize = "ExtraSmall";

            // Network Profile
            var ip1 = new IPAddress();
            ip1.AllocationMethod = "Dynamic";
            ip1.Type = "IPV4";
            ip1.ConfigurationName = "SampleIPV4Config";

            var networkAdapter = new NetworkAdapter();
            networkAdapter.Name = "Nic1";
            networkAdapter.IPAddresses.Add(ip1);

            resdef.IntrinsicSettings.NetworkProfile.NetworkAdapters.Add(networkAdapter);

            // Operating System Profile
            resdef.IntrinsicSettings.OperatingSystemProfile = null;

            // Scaleout Settings
            resdef.IntrinsicSettings.ScaleOutSettings.InitialInstanceCount = "1";
            resdef.IntrinsicSettings.ScaleOutSettings.MaximumInstanceCount = "5";
            resdef.IntrinsicSettings.ScaleOutSettings.MinimumInstanceCount = "1";
            resdef.IntrinsicSettings.ScaleOutSettings.UpgradeDomainCount = "1";

            // Storage Profile
            resdef.IntrinsicSettings.StorageProfile.OSVirtualHardDiskImage = WAPackConfigurationFactory.LinuxOSVirtualHardDiskImage;

            return resdef;
        }
    }
}
