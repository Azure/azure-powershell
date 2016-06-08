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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.DiskRepository;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extensions.BGInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extensions.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extesnions.CustomScript;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extensions.SqlServer;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extesnions.VMAccess;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.ILB;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PIRCmdletInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.NetworkCmdletInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.SubscriptionCmdletInfo;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    using SM = Model;

    public class ServiceManagementCmdletTestHelper
    {
        private T RunPSCmdletAndReturnFirst<T>(PowershellCore.CmdletsInfo cmdlet, bool debug = false, bool retryOnConflict = true)
        {
            var result = default(T);
            if (retryOnConflict)
            {
                Utilities.RetryActionUntilSuccess(
                   () => result = RunPSCmdletAndReturnFirstHelper<T>(cmdlet),
                   "ConflictError", 3, 60);
            }
            else
            {
                result = RunPSCmdletAndReturnFirstHelper<T>(cmdlet);
            }
            return result;

        }

        /// <summary>
        /// Run a powershell cmdlet that returns the first PSObject as a return value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdlet"></param>
        /// <param name="debug"></param>
        /// <returns></returns>
        private T RunPSCmdletAndReturnFirstHelper<T>(PowershellCore.CmdletsInfo cmdlet, bool debug = false)
        {
            var azurePowershellCmdlet = new WindowsAzurePowershellCmdlet(cmdlet);
            Collection<PSObject> result = azurePowershellCmdlet.Run(debug);
            if (result.Count == 1)
            {
                try
                {
                    var operation = (ManagementOperationContext)result[0].BaseObject;
                    Console.WriteLine("Operation ID: {0} \nOperation Status: {1}\n", operation.OperationId, operation.OperationStatus);
                }
                catch (Exception e)
                {
                    if (e is InvalidCastException)
                    {
                        // continue
                    }
                    else
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

                return (T) result[0].BaseObject;
            }
            return default(T);
        }

        private Collection<T> RunPSCmdletAndReturnAll<T>(PowershellCore.CmdletsInfo cmdlet, bool debug = false, bool retryOnConflict = true)
        {
            var result = new Collection<T>();
            if (retryOnConflict)
            {
                Utilities.RetryActionUntilSuccess(
                   () => result = RunPSCmdletAndReturnAllHelper<T>(cmdlet),
                   "ConflictError", 3, 60);
            }
            else
            {
                result = RunPSCmdletAndReturnAllHelper<T>(cmdlet);
            }
            return result;
        }


        /// <summary>
        /// Run a powershell cmdlet that returns a collection of PSObjects as a return value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdlet"></param>
        /// <param name="debug"></param>
        /// <returns></returns>
        private Collection<T> RunPSCmdletAndReturnAllHelper<T>(PowershellCore.CmdletsInfo cmdlet, bool debug = false)
        {
            var azurePowershellCmdlet = new WindowsAzurePowershellCmdlet(cmdlet);
            Collection<PSObject> result = azurePowershellCmdlet.Run(debug);
            var resultCollection = new Collection<T>();
            foreach (PSObject re in result)
            {
                resultCollection.Add((T)re.BaseObject);
            }

            try
            {
                if (result.Count > 0)
                {
                    var operation = (ManagementOperationContext) result[0].BaseObject;
                    Console.WriteLine("Operation ID: {0} \nOperation Status: {1}\n", operation.OperationId,
                        operation.OperationStatus);
                }
            }
            catch (Exception e)
            {
                if (e is InvalidCastException)
                {
                    // continue
                }
                else
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return resultCollection;
        }

        public Collection <PSObject> RunPSScript(string script, bool debug = false)
        {
            List<string> st = new List<string>();
            st.Add(script);

            WindowsAzurePowershellScript azurePowershellCmdlet = new WindowsAzurePowershellScript(st);
            return azurePowershellCmdlet.Run(debug);
        }


        public CopyState CheckCopyBlobStatus(string destContainer, string destBlob, bool debug = false)
        {
            List<string> st = new List<string>();
            st.Add(string.Format("{0}-{1} -Container {2} -Blob {3}",
                VerbsCommon.Get, StorageNouns.CopyBlobStatus, destContainer, destBlob));

            WindowsAzurePowershellScript azurePowershellCmdlet = new WindowsAzurePowershellScript(st);
            return (CopyState)azurePowershellCmdlet.Run(debug)[0].BaseObject;
        }
        public bool TestAzureServiceName(string serviceName)
        {
            return RunPSCmdletAndReturnFirst<bool>(new TestAzureNameCmdletInfo("Service", serviceName));
        }

        public Collection<SM.LocationsContext> GetAzureLocation()
        {
            return RunPSCmdletAndReturnAll<SM.LocationsContext>(new GetAzureLocationCmdletInfo());
        }

        public string GetAzureLocationName(string[] keywords)
        {
            Collection<SM.LocationsContext> locations;

            try
            {
                locations = GetAzureLocation();
            }
            catch
            {
                Console.WriteLine("Error occurred during Get-AzureLocation...   Default location is not set.");
                return null;
            }

            if (keywords != null)
            {
                foreach (SM.LocationsContext location in locations)
                {
                    if (MatchExactWords(location.Name, keywords) >= 0)
                    {
                        return location.Name;
                    }
                }
            }
            else
            {
                if (locations.Count == 1)
                {
                    return locations[0].Name;
                }
            }
            return null;
        }

        private static int MatchExactWords(string input, string[] keywords)
        { //returns -1 for no match, 0 for exact match, and a positive number for how many keywords are matched.
            int result = 0;
            if (string.IsNullOrEmpty(input) || keywords.Length == 0)
                return -1;
            foreach (string keyword in keywords)
            {
                //For whole word match, modify pattern to be "\b{0}\b"
                if (!string.IsNullOrEmpty(keyword) && keyword.ToLowerInvariant().Equals(input.ToLowerInvariant()))
                {
                    result++;
                }
            }
            if (result == keywords.Length)
            {
                return 0;
            }
            else if (result == 0)
            {
                return -1;
            }
            else
            {
                return result;
            }
        }

        public Collection<SM.OSVersionsContext> GetAzureOSVersion()
        {
            return RunPSCmdletAndReturnAll<SM.OSVersionsContext>(new GetAzureOSVersionCmdletInfo());
        }

        #region CertificateSetting, VMConifig, ProvisioningConfig

        public SM.CertificateSetting NewAzureCertificateSetting(string store, string thumbprint)
        {
            return RunPSCmdletAndReturnFirst<SM.CertificateSetting>(new NewAzureCertificateSettingCmdletInfo(store, thumbprint));
        }

        public SM.PersistentVM NewAzureVMConfig(AzureVMConfigInfo vmConfig)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new NewAzureVMConfigCmdletInfo(vmConfig));
        }

        public SM.PersistentVM AddAzureProvisioningConfig(AzureProvisioningConfigInfo provConfig)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new AddAzureProvisioningConfigCmdletInfo(provConfig));
        }

        #endregion

        #region AzureAffinityGroup

        public ManagementOperationContext NewAzureAffinityGroup(string name, string location, string label, string description)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext> (new NewAzureAffinityGroupCmdletInfo(name, location, label, description));
        }

        public Collection<SM.AffinityGroupContext> GetAzureAffinityGroup(string name = null)
        {
            return RunPSCmdletAndReturnAll<SM.AffinityGroupContext>(new GetAzureAffinityGroupCmdletInfo(name));
        }

        public ManagementOperationContext SetAzureAffinityGroup(string name, string label, string description)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext> (new SetAzureAffinityGroupCmdletInfo(name, label, description));
        }

        public ManagementOperationContext RemoveAzureAffinityGroup(string name)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureAffinityGroupCmdletInfo(name));
        }

        #endregion

        #region AzureAvailabilitySet

        public SM.PersistentVM SetAzureAvailabilitySet(string availabilitySetName, SM.PersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureAvailabilitySetCmdletInfo(availabilitySetName, vm));
        }

        public SM.PersistentVM SetAzureAvailabilitySet(string vmName, string serviceName, string availabilitySetName)
        {
            SM.PersistentVM vm = GetAzureVM(vmName, serviceName).VM;
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureAvailabilitySetCmdletInfo(availabilitySetName, vm));
        }

        public SM.PersistentVM RemoveAzureAvailabilitySet(SM.PersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureAvailabilitySetCmdletInfo(vm));
        }

        public SM.PersistentVM RemoveAzureAvailabilitySet(string vmName, string serviceName)
        {
            SM.PersistentVM vm = GetAzureVM(vmName, serviceName).VM;
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureAvailabilitySetCmdletInfo(vm));
        }

        #endregion AzureAvailabilitySet

        #region AzureCertificate

        public ManagementOperationContext AddAzureCertificate(string serviceName, PSObject cert, string password = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new AddAzureCertificateCmdletInfo(serviceName, cert, password));
        }

        public Collection <SM.CertificateContext> GetAzureCertificate(string serviceName, string thumbprint = null, string algorithm = null)
        {
            return RunPSCmdletAndReturnAll<SM.CertificateContext> (new GetAzureCertificateCmdletInfo(serviceName, thumbprint, algorithm));
        }

        public ManagementOperationContext RemoveAzureCertificate(string serviceName, string thumbprint, string algorithm)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureCertificateCmdletInfo(serviceName, thumbprint, algorithm));
        }

        #endregion

        #region AzureDataDisk

        public SM.PersistentVM AddAzureDataDisk(AddAzureDataDiskConfig diskConfig)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new AddAzureDataDiskCmdletInfo(diskConfig));
        }

        public void AddDataDisk(string vmName, string serviceName, AddAzureDataDiskConfig [] diskConfigs)
        {
            SM.PersistentVM vm = GetAzureVM(vmName, serviceName).VM;

            foreach (AddAzureDataDiskConfig config in diskConfigs)
            {
                config.Vm = vm;
                vm = AddAzureDataDisk(config);
            }
            UpdateAzureVM(vmName, serviceName, vm);
        }

        public SM.PersistentVM SetAzureDataDisk(SetAzureDataDiskConfig discCfg)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureDataDiskCmdletInfo(discCfg));
        }

        public SM.PersistentVM SetAzureDataDisk(SetAzureDataDiskResizeConfig discCfg)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureDataDiskCmdletInfo(discCfg));
        }

        public void SetDataDisk(string vmName, string serviceName, HostCaching hc, int lun)
        {
            SetAzureDataDiskConfig config = new SetAzureDataDiskConfig(hc, lun);
            config.Vm = GetAzureVM(vmName, serviceName).VM;
            UpdateAzureVM(vmName, serviceName, SetAzureDataDisk(config));
        }

        public Collection<SM.DataVirtualHardDisk> GetAzureDataDisk(string vmName, string serviceName)
        {
            SM.PersistentVMRoleContext vmRolectx = GetAzureVM(vmName, serviceName);

            return RunPSCmdletAndReturnAll<SM.DataVirtualHardDisk>(new GetAzureDataDiskCmdletInfo(vmRolectx.VM));
        }

        public Collection<SM.DataVirtualHardDisk> GetAzureDataDisk(SM.PersistentVM vm)
        {
            return RunPSCmdletAndReturnAll<SM.DataVirtualHardDisk>(new GetAzureDataDiskCmdletInfo(vm));
        }
        public SM.PersistentVM RemoveAzureDataDisk(RemoveAzureDataDiskConfig discCfg)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureDataDiskCmdletInfo(discCfg));
        }

        public void RemoveDataDisk(string vmName, string serviceName, int [] lunSlots)
        {
            SM.PersistentVM vm = GetAzureVM(vmName, serviceName).VM;

            foreach (int lun in lunSlots)
            {
                RemoveAzureDataDiskConfig config = new RemoveAzureDataDiskConfig(lun, vm);
                RemoveAzureDataDisk(config);
            }
            UpdateAzureVM(vmName, serviceName, vm);
        }

        #endregion

        #region AzureDeployment

        public ManagementOperationContext NewAzureDeployment(string serviceName, string packagePath, string configPath,
            string slot, string label, string name, bool doNotStart, bool warning,
            ExtensionConfigurationInput config = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureDeploymentCmdletInfo(serviceName,
                    packagePath, configPath, slot, label, name, doNotStart, warning, config));
        }

        public SM.DeploymentInfoContext GetAzureDeployment(string serviceName, string slot)
        {
            return RunPSCmdletAndReturnFirst<SM.DeploymentInfoContext>(new GetAzureDeploymentCmdletInfo(serviceName, slot));
        }

        public SM.DeploymentInfoContext GetAzureDeployment(string serviceName)
        {
            return GetAzureDeployment(serviceName, SM.DeploymentSlotType.Production);
        }

        public Collection<SM.DeploymentRebootEventContext> GetAzureDeploymentEvent(string serviceName, string deploymentName, DateTime startTime, DateTime endTime)
        {
            return RunPSCmdletAndReturnAll<SM.DeploymentRebootEventContext>(new GetAzureDeploymentEventCmdletInfo(serviceName, deploymentName, startTime, endTime));
        }

        public Collection<SM.DeploymentRebootEventContext> GetAzureDeploymentEventBySlot(string serviceName, string deploymentSlot, DateTime startTime, DateTime endTime)
        {
            return RunPSCmdletAndReturnAll<SM.DeploymentRebootEventContext>(new GetAzureDeploymentEventBySlotCmdletInfo(serviceName, deploymentSlot, startTime, endTime));
        }

        private ManagementOperationContext SetAzureDeployment(SetAzureDeploymentCmdletInfo cmdletInfo)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(cmdletInfo);
        }

        public ManagementOperationContext SetAzureDeploymentStatus(string serviceName, string slot, string newStatus)
        {
            return SetAzureDeployment(SetAzureDeploymentCmdletInfo.SetAzureDeploymentStatusCmdletInfo(serviceName, slot, newStatus));
        }

        public ManagementOperationContext SetAzureDeploymentConfig(string serviceName, string slot, string configPath, ExtensionConfigurationInput extConfig = null)
        {
            return SetAzureDeployment(SetAzureDeploymentCmdletInfo.SetAzureDeploymentConfigCmdletInfo(serviceName, slot, configPath, extConfig));
        }

        public ManagementOperationContext SetAzureDeploymentUpgrade(string serviceName, string slot, string mode, string packagePath, string configPath)
        {
            return SetAzureDeployment(SetAzureDeploymentCmdletInfo.SetAzureDeploymentUpgradeCmdletInfo(serviceName, slot, mode, packagePath, configPath));
        }

        public ManagementOperationContext SetAzureDeployment(string option, string serviceName, string packagePath, string newStatus, string configName, string slot, string mode, string label, string roleName, bool force)
        {
            return SetAzureDeployment(new SetAzureDeploymentCmdletInfo(option, serviceName, packagePath, newStatus, configName, slot, mode, label, roleName, force));
        }

        public ManagementOperationContext RemoveAzureDeployment(string serviceName, string slot, bool force)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureDeploymentCmdletInfo(serviceName, slot, force));
        }

        public ManagementOperationContext MoveAzureDeployment(string serviceName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new MoveAzureDeploymentCmdletInfo(serviceName));
        }

        public ManagementOperationContext SetAzureWalkUpgradeDomain(string serviceName, string slot, int domainNumber)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureWalkUpgradeDomainCmdletInfo(serviceName, slot, domainNumber));
        }

        #endregion

        #region AzureDisk

        // Add-AzureDisk
        public SM.DiskContext AddAzureDisk(string diskName, string mediaPath, string label, string os)
        {
            SM.DiskContext result = new SM.DiskContext();
            Utilities.RetryActionUntilSuccess(
                () => result = RunPSCmdletAndReturnFirst<SM.DiskContext>(new AddAzureDiskCmdletInfo(diskName, mediaPath, label, os)),
                "409", 3, 60);
            return result;
        }

        // Get-AzureDisk
        public Collection<SM.DiskContext> GetAzureDisk(string diskName)
        {
            return GetAzureDisk(new GetAzureDiskCmdletInfo(diskName));
        }

        public Collection<SM.DiskContext> GetAzureDisk()
        {
            return GetAzureDisk(new GetAzureDiskCmdletInfo((string)null));
        }

        private Collection<SM.DiskContext> GetAzureDisk(GetAzureDiskCmdletInfo getAzureDiskCmdletInfo)
        {
            return RunPSCmdletAndReturnAll<SM.DiskContext>(getAzureDiskCmdletInfo);
        }

        public Collection<SM.DiskContext> GetAzureDiskAttachedToRoleName(string[] roleName, bool exactMatch = true)
        {
            Collection<SM.DiskContext> retDisks = new Collection<SM.DiskContext>();
            Collection<SM.DiskContext> disks = GetAzureDisk();
            foreach (SM.DiskContext disk in disks)
            {
                if (disk.AttachedTo != null && disk.AttachedTo.RoleName != null)
                {
                    if (Utilities.MatchKeywords(disk.AttachedTo.RoleName, roleName, exactMatch) >= 0)
                        retDisks.Add(disk);
                }
            }
            return retDisks;
        }

        // Remove-AzureDisk
        public ManagementOperationContext RemoveAzureDisk(string diskName, bool deleteVhd)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureDiskCmdletInfo(diskName, deleteVhd));
        }

        // Update-AzureDisk
        public SM.DiskContext UpdateAzureDisk(string diskName, string label)
        {
            return RunPSCmdletAndReturnFirst<SM.DiskContext>(new UpdateAzureDiskCmdletInfo(diskName, label, null));
        }

        public ManagementOperationContext UpdateAzureDisk(string diskName, string label, int? resizedSize)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new UpdateAzureDiskCmdletInfo(diskName, label, resizedSize));
        }

        #endregion

        #region AzureDns

        public SM.DnsServer NewAzureDns(string name, string ipAddress)
        {
            return RunPSCmdletAndReturnFirst<SM.DnsServer>(new NewAzureDnsCmdletInfo(name, ipAddress));
        }

        public SM.DnsServerList GetAzureDns(SM.DnsSettings settings, bool debug = true)
        {
            var getAzureDnsCmdletInfo = new GetAzureDnsCmdletInfo(settings);
            var azurePowershellCmdlet = new WindowsAzurePowershellCmdlet(getAzureDnsCmdletInfo);
            Collection<PSObject> result = azurePowershellCmdlet.Run(debug);
            var dnsList = new SM.DnsServerList();

            foreach (PSObject re in result)
            {
                dnsList.Add((SM.DnsServer)re.BaseObject);
            }
            return dnsList;
        }

        public ManagementOperationContext AddAzureDns(string name, string ipAddress, string serviceName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new AddAzureDnsCmdletInfo(name, ipAddress, serviceName));
        }

        public ManagementOperationContext SetAzureDns(string name, string ipAddress, string serviceName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureDnsCmdletInfo(name, ipAddress, serviceName));
        }

        public ManagementOperationContext RemoveAzureDns(string name, string ipAddress, bool force = false)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureDnsCmdletInfo(name, ipAddress, force));
        }
        

        #endregion

        #region AzureEndpoint

        public SM.PersistentVM AddAzureEndPoint(AzureEndPointConfigInfo endPointConfig)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new AddAzureEndpointCmdletInfo(endPointConfig));
        }

        public void AddEndPoint(string vmName, string serviceName, AzureEndPointConfigInfo [] endPointConfigs)
        {
            SM.PersistentVM vm = GetAzureVM(vmName, serviceName).VM;

            foreach (AzureEndPointConfigInfo config in endPointConfigs)
            {
                config.Vm = vm;
                vm = AddAzureEndPoint(config);
            }
            UpdateAzureVM(vmName, serviceName, vm);
        }

        public Collection <SM.InputEndpointContext> GetAzureEndPoint(SM.PersistentVMRoleContext vmRoleCtxt)
        {
            return RunPSCmdletAndReturnAll<SM.InputEndpointContext>(new GetAzureEndpointCmdletInfo(vmRoleCtxt));
        }

        public Collection<SM.InputEndpointContext> GetAzureEndPoint(SM.PersistentVM vm)
        {
            return RunPSCmdletAndReturnAll<SM.InputEndpointContext>(new GetAzureEndpointCmdletInfo(vm));
        }

        public void SetEndPoint(string vmName, string serviceName, AzureEndPointConfigInfo endPointConfig)
        {
            endPointConfig.Vm = GetAzureVM(vmName, serviceName).VM;
            UpdateAzureVM(vmName, serviceName, SetAzureEndPoint(endPointConfig));
        }

        public SM.PersistentVM SetAzureEndPoint(AzureEndPointConfigInfo endPointConfig)
        {
            if (null != endPointConfig)
            {
                return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureEndpointCmdletInfo(endPointConfig));
            }
            return null;
        }

        public void SetLBEndPoint(string vmName, string serviceName, AzureEndPointConfigInfo endPointConfig, AzureEndPointConfigInfo.ParameterSet paramset)
        {
            endPointConfig.Vm = GetAzureVM(vmName, serviceName).VM;
            SetAzureLoadBalancedEndPoint(endPointConfig, paramset);

            //UpdateAzureVM(vmName, serviceName, SetAzureLoadBalancedEndPoint(endPointConfig, paramset));
        }

        public ManagementOperationContext SetAzureLoadBalancedEndPoint(AzureEndPointConfigInfo endPointConfig, AzureEndPointConfigInfo.ParameterSet paramset)
        {
            if (null != endPointConfig)
            {
                return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureLoadBalancedEndpointCmdletInfo(endPointConfig, paramset));
            }
            return null;
        }

        public SM.PersistentVMRoleContext RemoveAzureEndPoint(string epName, SM.PersistentVMRoleContext vmRoleCtxt)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVMRoleContext>(new RemoveAzureEndpointCmdletInfo(epName, vmRoleCtxt));
        }

        public SM.PersistentVM RemoveAzureEndPoint(string epName, SM.PersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureEndpointCmdletInfo(epName, vm));
        }

        public void RemoveEndPoint(string vmName, string serviceName, string [] epNames)
        {
            SM.PersistentVMRoleContext vmRoleCtxt = GetAzureVM(vmName, serviceName);

            foreach (string ep in epNames)
            {
                vmRoleCtxt.VM = RemoveAzureEndPoint(ep, vmRoleCtxt).VM;
            }
            UpdateAzureVM(vmName, serviceName, vmRoleCtxt.VM);
        }

        #endregion

        #region AzureOSDisk

        public SM.PersistentVM SetAzureOSDisk(HostCaching? hc, SM.PersistentVM vm, int? resizedSize = null)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureOSDiskCmdletInfo(hc, vm, resizedSize));
        }

        public SM.OSVirtualHardDisk GetAzureOSDisk(SM.PersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.OSVirtualHardDisk>(new GetAzureOSDiskCmdletInfo(vm));
        }

        #endregion

        #region AzureRole

        public ManagementOperationContext SetAzureRole(string serviceName, string slot, string roleName, int count)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureRoleCmdletInfo(serviceName, slot, roleName, count));
        }

        public Collection<SM.RoleContext> GetAzureRole(string serviceName, string slot, string roleName, bool details)
        {
            return RunPSCmdletAndReturnAll<SM.RoleContext>(new GetAzureRoleCmdletInfo(serviceName, slot, roleName, details));
        }

        #endregion

        #region AzureQuickVM

        public ManagementOperationContext NewAzureQuickVM(OS os, string name, string serviceName, string imageName,
            string userName, string password, string locationName, string instanceSize)
        {
            ManagementOperationContext result = new ManagementOperationContext();
            try
            {
                result = RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureQuickVMCmdletInfo(os, name, serviceName, imageName, userName, password, locationName, instanceSize));
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("409"))
                {
                    Utilities.RetryActionUntilSuccess(
                        () => result = RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureQuickVMCmdletInfo(os, name, serviceName, imageName, userName, password, null, instanceSize)),
                        "409", 4, 60);
                }
                else
                {
                    Console.WriteLine(e.InnerException.ToString());
                    throw;
                }
            }
            return result;
        }

        public ManagementOperationContext NewAzureQuickVM(OS os, string name, string serviceName, string imageName,
            string userName, string password, string locationName, string instanceSize, bool disableWinRMHttps,
            string reservedIpName = null, string vnetName = null)
        {
            var result = new ManagementOperationContext();
            try
            {
                result = RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureQuickVMCmdletInfo(
                    os, name, serviceName, imageName, userName, password, locationName,
                    instanceSize, disableWinRMHttps, reservedIpName, vnetName));
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("Service already exists") ||
                    (e.InnerException != null && e.InnerException.ToString().Contains("Service already exists")))
                {
                    RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureQuickVMCmdletInfo(
                        os, name, serviceName, imageName, userName, password, null,
                        instanceSize, disableWinRMHttps, reservedIpName, vnetName));
                }
                else
                {
                    Console.WriteLine(e.ToString());
                    if (e.InnerException != null)
                    {
                        Console.WriteLine(e.InnerException.ToString());
                    }
                    throw;
                }
            }
            return result;
        }

        public ManagementOperationContext NewAzureQuickVM(OS os, string name, string serviceName, string imageName,
            string userName = null, string password = null, string locationName = null)
        {
            return NewAzureQuickVM(os, name, serviceName, imageName, userName, password, locationName, null);
        }

        public ManagementOperationContext NewAzureQuickVM(OS os, string name, string serviceName, string imageName, string[] subnetNames,
            InstanceSize instanceSize, string userName, string password, string vNetName, string affinityGroup, string reservedIP = null)
        {
            var result = new ManagementOperationContext();
            try
            {
                result = RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureQuickVMCmdletInfo(
                    os, name, serviceName, imageName, instanceSize.ToString(), userName, password,
                    vNetName, subnetNames, affinityGroup, reservedIP));
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("Service already exists") ||
                    (e.InnerException != null && e.InnerException.ToString().Contains("Service already exists")))
                {
                    RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureQuickVMCmdletInfo(
                        os, name, serviceName, imageName, instanceSize.ToString(), userName, password,
                        vNetName, subnetNames, null, reservedIP));
                }
                else
                {
                    Console.WriteLine(e.ToString());
                    if (e.InnerException != null)
                    {
                        Console.WriteLine(e.InnerException.ToString());
                    }
                    throw;
                }
            }
            return result;
        }
        #endregion

        #region WinRM

        public Uri GetAzureWinRMUri(string servicename, string name)
        {
            Uri result = null;
            try
            {
                result = RunPSCmdletAndReturnFirst<Uri>(new WinRMCmdletInfo(servicename, name));
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("409"))
                {
                    Utilities.RetryActionUntilSuccess(
                        () => result = RunPSCmdletAndReturnFirst<Uri>(new WinRMCmdletInfo(servicename, name)),
                        "409", 4, 60);
                }
                else
                {
                    Console.WriteLine(e.InnerException.ToString());
                    throw;
                }
            }
            return result;
        }      


        #endregion WinRM 

        #region AzurePlatformExtension

        internal ExtensionCertificateConfig NewAzurePlatformExtensionCertificateConfig(
            string storeLocation, string storeName, string thumbAlgorithm, bool thumbRequired = false)
        {
            return RunPSCmdletAndReturnFirst<ExtensionCertificateConfig>(
                new NewAzurePlatformExtensionCertificateConfigCmdletInfo(storeLocation, storeName, thumbAlgorithm, thumbRequired));
        }

        internal ExtensionEndpointConfigSet NewAzurePlatformExtensionEndpointConfigSet()
        {
            return RunPSCmdletAndReturnFirst<ExtensionEndpointConfigSet>(
                new NewAzurePlatformExtensionEndpointConfigSetCmdletInfo());
        }

        internal ExtensionEndpointConfigSet SetAzurePlatformExtensionEndpoint(
            ExtensionEndpointConfigSet endpointConfig, string inputEndpoint,
            string protocol, int port, string localPort)
        {
            return RunPSCmdletAndReturnFirst<ExtensionEndpointConfigSet>(
                new SetAzurePlatformExtensionEndpointCmdletInfo(endpointConfig,
                    inputEndpoint, null, null, protocol, port, localPort, null, null));
        }
        internal ExtensionEndpointConfigSet SetAzurePlatformExtensionEndpoint(
            ExtensionEndpointConfigSet endpointConfig, string internalEndpoint,
            string protocol, int port)
        {
            return RunPSCmdletAndReturnFirst<ExtensionEndpointConfigSet>(
                new SetAzurePlatformExtensionEndpointCmdletInfo(endpointConfig,
                    null, internalEndpoint, null, protocol, port, null, null, null));
        }
        internal ExtensionEndpointConfigSet SetAzurePlatformExtensionEndpoint(
            ExtensionEndpointConfigSet endpointConfig, string instanceInputEndpoint,
            string protocol, string localPort, int portMax, int portMin)
        {
            return RunPSCmdletAndReturnFirst<ExtensionEndpointConfigSet>(
                new SetAzurePlatformExtensionEndpointCmdletInfo(endpointConfig,
                    null, null, instanceInputEndpoint, protocol, null, localPort, portMax, portMin));
        }

        internal ExtensionEndpointConfigSet RemoveAzurePlatformExtensionEndpoint(
            ExtensionEndpointConfigSet endpointConfig, string epName, string kind)
        {
            return RunPSCmdletAndReturnFirst<ExtensionEndpointConfigSet>(
                new RemoveAzurePlatformExtensionEndpointCmdletInfo(endpointConfig, epName, kind));
        }

        internal ExtensionLocalResourceConfigSet NewAzurePlatformExtensionLocalResourceConfigSet()
        {
            return RunPSCmdletAndReturnFirst<ExtensionLocalResourceConfigSet>(
                new NewAzurePlatformExtensionLocalResourceConfigSetCmdletInfo());
        }

        internal ExtensionLocalResourceConfigSet SetAzurePlatformExtensionLocalResource(
            ExtensionLocalResourceConfigSet lrConfig, string name, int sizeInMb)
        {
            return RunPSCmdletAndReturnFirst<ExtensionLocalResourceConfigSet>(
                new SetAzurePlatformExtensionLocalResourceCmdletInfo(lrConfig, name, sizeInMb));
        }

        internal ExtensionLocalResourceConfigSet RemoveAzurePlatformExtensionLocalResource(
            ExtensionLocalResourceConfigSet lrConfig, string name)
        {
            return RunPSCmdletAndReturnFirst<ExtensionLocalResourceConfigSet>(
                new RemoveAzurePlatformExtensionLocalResourceCmdletInfo(lrConfig, name));
        }

        internal ManagementOperationContext PublishAzurePlatformExtension(
            string extensionName, string publisher, string version, string hr,
            Uri media, string label, string description, string company,
            ExtensionCertificateConfig certConfig, ExtensionEndpointConfigSet epConfig, ExtensionLocalResourceConfigSet lrConfig,
            DateTime publishDate, string publicSchema, string privateSchema, string sample,
            string eula,  Uri privacyUri, Uri homepage, string os, string regions,
            bool blockRole, bool disallowUpgrade, bool xmlExtension, bool force)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                new PublishAzurePlatformExtensionCmdletInfo(
                    extensionName, publisher, version, hr,
                    media, label, description, company,
                    certConfig, epConfig, lrConfig,
                    publishDate, publicSchema, privateSchema, sample,
                    eula, privacyUri, homepage, os, regions,
                    blockRole, disallowUpgrade, xmlExtension, force));
        }

        internal ManagementOperationContext UnpublishAzurePlatformExtension(
            string extensionName, string publisher, string version, bool force)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                new UnpublishAzurePlatformExtensionCmdletInfo(extensionName, publisher, version, force));
        }

        #endregion

        #region AzurePlatformVMImage

        internal ComputeImageConfig NewAzurePlatformComputeImageConfig(string offer, string sku, string version)
        {
            return RunPSCmdletAndReturnFirst<ComputeImageConfig>(new NewAzurePlatformComputeImageConfigCmdletInfo(offer, sku, version));
        }

        internal MarketplaceImageConfig NewAzurePlatformMarketplaceImageConfig(string planName, string product, string publisher, string publisherId)
        {
            return RunPSCmdletAndReturnFirst<MarketplaceImageConfig>(new NewAzurePlatformMarketplaceImageConfigCmdletInfo(planName, product, publisher, publisherId));
        }

        internal ManagementOperationContext SetAzurePlatformVMImageReplicate(string imageName, string[] locations, ComputeImageConfig compCfg, MarketplaceImageConfig marketCfg)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new  SetAzurePlatformVMImageCmdletInfo(imageName, null, locations, compCfg, marketCfg));
        }

        internal ManagementOperationContext SetAzurePlatformVMImagePublic(string imageName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzurePlatformVMImageCmdletInfo(imageName, "Public", null));
        }

        internal ManagementOperationContext SetAzurePlatformVMImagePrivate(string imageName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzurePlatformVMImageCmdletInfo(imageName, "Private", null));
        }

        internal OSImageDetailsContext GetAzurePlatformVMImage(string imageName)
        {
            return RunPSCmdletAndReturnFirst<OSImageDetailsContext>(new GetAzurePlatformVMImageCmdletInfo(imageName));
        }

        internal ManagementOperationContext RemoveAzurePlatformVMImage(string imageName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzurePlatformVMImageCmdletInfo(imageName));
        }

        #endregion

        #region AzureReservedIP

        internal ManagementOperationContext NewAzureReservedIP(string name, string location, string label = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureReservedIPCmdletInfo(name, location, label));
        }

        internal ManagementOperationContext NewAzureReservedIP(string name, string location, string serviceName, string label = null, string slot = SM.DeploymentSlotType.Production)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureReservedIPCmdletInfo(name, location, serviceName, slot, label));
        }

        internal ManagementOperationContext SetAzureReservedIPAssociation(string reservedIpName, string serviceName, string slot = SM.DeploymentSlotType.Production)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureReservedIPAssociationCmdletInfo(reservedIpName, serviceName, slot));
        }

        internal ManagementOperationContext RemoveAzureReservedIPAssociation(string reservedIpName, string serviceName, bool force, string slot = SM.DeploymentSlotType.Production)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureReservedIPAssociationCmdletInfo(reservedIpName, serviceName, slot, force));
        }

        internal Collection<SM.ReservedIPContext> GetAzureReservedIP(string name = null)
        {
            return RunPSCmdletAndReturnAll<SM.ReservedIPContext>(new GetAzureReservedIPCmdletInfo(name));
        }

        internal ManagementOperationContext RemoveAzureReservedIP(string name, bool force = false)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureReservedIPCmdletInfo(name, force));
        }
        internal ManagementOperationContext AddAzureVirtualIP(string virtualIPName, string serviceName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new AddAzureVirtualIPCmdletInfo(virtualIPName, serviceName));
        }
        internal ManagementOperationContext RemoveAzureVirtualIP(string virtualIPName, string serviceName, bool force = true)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureVirtualIPCmdletInfo(virtualIPName, serviceName, force));
        }

        #endregion

        #region AzurePublishSettingsFile

        internal void ImportAzurePublishSettingsFile()
        {
            this.ImportAzurePublishSettingsFile(CredentialHelper.PublishSettingsFile);
        }

        internal void ImportAzurePublishSettingsFile(string publishSettingsFile, bool debug = false)
        {
            (new WindowsAzurePowershellCmdlet(new ImportAzurePublishSettingsFileCmdletInfo(publishSettingsFile))).Run(debug);
        }

        internal void ImportAzurePublishSettingsFile(string publishSettingsFile, string env, bool debug = false)
        {
            (new WindowsAzurePowershellCmdlet(new ImportAzurePublishSettingsFileCmdletInfo(publishSettingsFile, env))).Run(debug);
        }

        #endregion

        #region AzureSubscription

        public Collection<PSAzureSubscriptionExtended> GetAzureSubscription(bool extendedDetails = true)
        {
            return RunPSCmdletAndReturnAll<PSAzureSubscriptionExtended>(new GetAzureSubscriptionCmdletInfo(null, false, false, extendedDetails));
        }

        public PSAzureSubscriptionExtended GetAzureSubscription(string subscriptionId, bool extendedDetails = true)
        {
            return RunPSCmdletAndReturnFirst<PSAzureSubscriptionExtended>(new GetAzureSubscriptionCmdletInfo(subscriptionId, false, false, extendedDetails));
        }

        public PSAzureSubscriptionExtended GetCurrentAzureSubscription(bool extendedDetails = true)
        {
            return RunPSCmdletAndReturnFirst<PSAzureSubscriptionExtended>(new GetAzureSubscriptionCmdletInfo(null, true, false, extendedDetails));
        }

        public PSAzureSubscriptionExtended SetAzureSubscription(string subscriptionId, string currentStorageAccountName, bool debug = false)
        {
            var setAzureSubscriptionCmdlet = new SetAzureSubscriptionCmdletInfo(subscriptionId, currentStorageAccountName);
            SelectAzureSubscription(subscriptionId);
            var azurePowershellCmdlet = new WindowsAzurePowershellCmdlet(setAzureSubscriptionCmdlet);
            azurePowershellCmdlet.Run(debug);

            return GetAzureSubscription(subscriptionId);
        }

        public PSAzureSubscriptionExtended SetDefaultAzureSubscription(string subscriptionId, bool debug = false)
        {
            SelectAzureSubscription(subscriptionId);
            return GetAzureSubscription(subscriptionId);
        }

        public AzureSubscription SelectAzureSubscription(string subscriptionId, bool isDefault = true)
        {
            return RunPSCmdletAndReturnFirst<AzureSubscription>(new SelectAzureSubscriptionCmdletInfo(subscriptionId, isDefault));
        }

        #endregion

        #region AzureSubnet

        public SM.SubnetNamesCollection GetAzureSubnet(SM.PersistentVM vm, bool debug = true)
        {
            var getAzureSubnetCmdlet = new GetAzureSubnetCmdletInfo(vm);
            var azurePowershellCmdlet = new WindowsAzurePowershellCmdlet(getAzureSubnetCmdlet);
            Collection <PSObject> result = azurePowershellCmdlet.Run(debug);

            var subnets = new SM.SubnetNamesCollection();
            foreach (PSObject re in result)
            {
                subnets.Add((string)re.BaseObject);
            }
            return subnets;
        }

        public SM.PersistentVM SetAzureSubnet(SM.PersistentVM vm, string[] subnetNames)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureSubnetCmdletInfo(vm, subnetNames));
        }

        #endregion

        #region AzureStorageAccount

        public ManagementOperationContext NewAzureStorageAccount(string storageName, string locationName, string affinity, string label, string description)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureStorageAccountCmdletInfo(storageName, locationName, affinity, label, description, null));
        }

        public ManagementOperationContext NewAzureStorageAccount(string storageName, string locationName, string affinity, string label, string description, string accountType)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureStorageAccountCmdletInfo(storageName, locationName, affinity, label, description, accountType));
        }

        public SM.StorageServicePropertiesOperationContext NewAzureStorageAccount(string storageName, string locationName)
        {
            NewAzureStorageAccount(storageName, locationName, null, null, null);

            Collection<SM.StorageServicePropertiesOperationContext> storageAccounts = GetAzureStorageAccount(null);
            foreach (SM.StorageServicePropertiesOperationContext storageAccount in storageAccounts)
            {
                if (storageAccount.StorageAccountName == storageName)
                    return storageAccount;
            }
            return null;
        }

        public Collection<SM.StorageServicePropertiesOperationContext> GetAzureStorageAccount(string accountName)
        {
            return RunPSCmdletAndReturnAll<SM.StorageServicePropertiesOperationContext>(new GetAzureStorageAccountCmdletInfo(accountName));
        }

        public ManagementOperationContext SetAzureStorageAccount(string accountName, string label, string description, bool? geoReplication)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureStorageAccountCmdletInfo(accountName, label, description, geoReplication));
        }

        public ManagementOperationContext SetAzureStorageAccount(string accountName, string label, string description, string accountType)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureStorageAccountCmdletInfo(accountName, label, description, accountType));
        }

        public void RemoveAzureStorageAccount(string storageAccountName)
        {
            Utilities.RetryActionUntilSuccess(
                () => RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureStorageAccountCmdletInfo(storageAccountName)),
                "409", 3, 60);
        }

        #endregion

        #region AzureStorageKey

        public SM.StorageServiceKeyOperationContext GetAzureStorageAccountKey(string stroageAccountName)
        {
            return RunPSCmdletAndReturnFirst<SM.StorageServiceKeyOperationContext>(new GetAzureStorageKeyCmdletInfo(stroageAccountName));
        }

        public SM.StorageServiceKeyOperationContext NewAzureStorageAccountKey(string stroageAccountName, string keyType)
        {
            return RunPSCmdletAndReturnFirst<SM.StorageServiceKeyOperationContext>(new NewAzureStorageKeyCmdletInfo(stroageAccountName, keyType));
        }

        #endregion

        #region AzureService

        public ManagementOperationContext NewAzureService(string serviceName, string location)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureServiceCmdletInfo(serviceName, location));
        }

        public ManagementOperationContext NewAzureService(string serviceName, string serviceLabel, string locationName, string affinityGroup = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new NewAzureServiceCmdletInfo(serviceName, serviceLabel, locationName, affinityGroup));
        }

        public bool RemoveAzureService(string serviceName, bool deleteAll = false)
        {
            bool result = false;
            Utilities.RetryActionUntilSuccess(
                () => result = RunPSCmdletAndReturnFirst<bool>(new RemoveAzureServiceCmdletInfo(serviceName, deleteAll), false),
                "ConflictError", 3, 60);
            return result;
        }

        public SM.HostedServiceDetailedContext GetAzureService(string serviceName)
        {
            return RunPSCmdletAndReturnFirst<SM.HostedServiceDetailedContext>(new GetAzureServiceCmdletInfo(serviceName));
        }

        #endregion

        #region AzureServiceDiagnosticsExtension

        // New-AzureServiceDiagnosticsExtensionConfig
        public ExtensionConfigurationInput NewAzureServiceDiagnosticsExtensionConfig(string storage, XmlDocument config = null, string[] roles = null)
        {
            return RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(new NewAzureServiceDiagnosticsExtensionConfigCmdletInfo(storage, config, roles));
        }

        public ExtensionConfigurationInput NewAzureServiceDiagnosticsExtensionConfig
            (string storage, X509Certificate2 cert, XmlDocument config = null, string[] roles = null)
        {
            return RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>
                (new NewAzureServiceDiagnosticsExtensionConfigCmdletInfo(storage, cert, config, roles));
        }

        public ExtensionConfigurationInput NewAzureServiceDiagnosticsExtensionConfig
            (string storage, string thumbprint, string algorithm = null, XmlDocument config = null, string[] roles = null)
        {
            return RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>
                (new NewAzureServiceDiagnosticsExtensionConfigCmdletInfo(storage, thumbprint, algorithm, config, roles));
        }

        // Set-AzureServiceDiagnosticsExtension
        public ManagementOperationContext SetAzureServiceDiagnosticsExtension
            (string service, AzureStorageContext storageContext, string config = null, string[] roles = null, string slot = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureServiceDiagnosticsExtensionCmdletInfo(service, storageContext, config, roles, slot));
        }

        public ManagementOperationContext SetAzureServiceDiagnosticsExtension(string service, AzureStorageContext storageContext, X509Certificate2 cert, string config = null, string[] roles = null, string slot = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureServiceDiagnosticsExtensionCmdletInfo(service, storageContext, cert, config, roles, slot));
        }

        public ManagementOperationContext SetAzureServiceDiagnosticsExtension(string service, AzureStorageContext storageContext, string thumbprint, string algorithm = null, string config = null, string[] roles = null, string slot = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureServiceDiagnosticsExtensionCmdletInfo(service, storageContext, thumbprint, algorithm, config, roles, slot));
        }

        // Get-AzureServiceDiagnosticsExtension
        public Collection <DiagnosticExtensionContext> GetAzureServiceDiagnosticsExtension(string serviceName, string slot = null)
        {
            return RunPSCmdletAndReturnAll<DiagnosticExtensionContext>(new GetAzureServiceDiagnosticsExtensionCmdletInfo(serviceName, slot));
        }

        // Remove-AzureServiceDiagnosticsExtension
        public ManagementOperationContext RemoveAzureServiceDiagnosticsExtension(string serviceName, bool uninstall = false, string[] roles = null, string slot = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureServiceDiagnosticsExtensionCmdletInfo(serviceName, uninstall, roles, slot));
        }

        #endregion

        #region AzureServiceRemoteDesktopExtension

        // New-AzureServiceRemoteDesktopExtensionConfig
        public ExtensionConfigurationInput NewAzureServiceRemoteDesktopExtensionConfig
            (PSCredential cred, DateTime? exp = null, string[] roles = null, string version  = null)
        {
            return RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>
                (new NewAzureServiceRemoteDesktopExtensionConfigCmdletInfo(cred, exp, roles, version));
        }

        public ExtensionConfigurationInput NewAzureServiceRemoteDesktopExtensionConfig
            (PSCredential cred, X509Certificate2 cert, string alg = null, DateTime? exp = null, string[] roles = null, string version = null)
        {
            return RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>
                (new NewAzureServiceRemoteDesktopExtensionConfigCmdletInfo(cred, cert, alg, exp, roles, version));
        }

        public ExtensionConfigurationInput NewAzureServiceRemoteDesktopExtensionConfig
            (PSCredential cred, string thumbprint, string algorithm = null, DateTime? exp = null, string[] roles = null, string version = null)
        {
            return RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>
                (new NewAzureServiceRemoteDesktopExtensionConfigCmdletInfo(cred, thumbprint, algorithm, exp, roles, version));
        }

        // Set-AzureServiceRemoteDesktopExtension
        public ManagementOperationContext SetAzureServiceRemoteDesktopExtension
            (string serviceName, PSCredential cred, DateTime? exp = null, string[] roles = null, string slot = null, string version = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>
                (new SetAzureServiceRemoteDesktopExtensionCmdletInfo(serviceName, cred, exp, roles, slot, version));
        }

        public ManagementOperationContext SetAzureServiceRemoteDesktopExtension
            (string serviceName, PSCredential credential, X509Certificate2 cert, DateTime? expiration = null, string[] roles = null, string slot = null, string version = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>
                (new SetAzureServiceRemoteDesktopExtensionCmdletInfo(serviceName, credential, cert, expiration, roles, slot, version));
        }

        public ManagementOperationContext SetAzureServiceRemoteDesktopExtension
            (string serviceName, PSCredential credential, string thumbprint, string algorithm = null, DateTime? expiration = null, string[] roles = null, string slot = null, string version = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>
                (new SetAzureServiceRemoteDesktopExtensionCmdletInfo(serviceName, credential, thumbprint, algorithm, expiration, roles, slot, version));
        }

        // Get-AzureServiceRemoteDesktopExtension
        public Collection <RemoteDesktopExtensionContext> GetAzureServiceRemoteDesktopExtension(string serviceName, string slot = null)
        //public RemoteDesktopExtensionContext GetAzureServiceRemoteDesktopExtension(string serviceName, string slot = null)
        {
            return RunPSCmdletAndReturnAll<RemoteDesktopExtensionContext>(new GetAzureServiceRemoteDesktopExtensionCmdletInfo(serviceName, slot));
            //return RunPSCmdletAndReturnFirst<RemoteDesktopExtensionContext>(new GetAzureServiceRemoteDesktopExtensionCmdletInfo(serviceName, slot));
        }

        // Remove-AzureServiceRemoteDesktopExtension
        public ManagementOperationContext RemoveAzureServiceRemoteDesktopExtension(string serviceName, bool uninstall = false, string[] roles = null, string slot = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureServiceRemoteDesktopExtensionCmdletInfo(serviceName, uninstall, roles, slot));
        }

        #endregion

        #region AzureServiceExtension

        // New-AzureServiceExtensionConfig
        public ExtensionConfigurationInput NewAzureServiceExtensionConfig(string extensionName, string providerNamespace,
            string publicConfig, string privateConfig, string[] roles = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(
                    new NewAzureServiceExtensionConfigCmdletInfo(roles, extensionName, providerNamespace,
                        publicConfig, privateConfig, version));
        }

        public ExtensionConfigurationInput NewAzureServiceExtensionConfig(string extensionName, string providerNamespace,
            string publicConfig, string privateConfig, X509Certificate2 cert, string alg = null, string[] roles = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(new NewAzureServiceExtensionConfigCmdletInfo(
                    cert, alg, roles, extensionName, providerNamespace, publicConfig, privateConfig, version));
        }

        public ExtensionConfigurationInput NewAzureServiceExtensionConfig(string extensionName, string providerNamespace,
            string publicConfig, string privateConfig, string thumbprint, string algorithm = null, string[] roles = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(
                    new NewAzureServiceExtensionConfigCmdletInfo(thumbprint, algorithm, roles, extensionName,
                        providerNamespace, publicConfig, privateConfig, version));
        }

        public ExtensionConfigurationInput NewAzureServiceExtensionConfig(string extensionId, string extensionStatus,
            string [] roles = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(
                    new NewAzureServiceExtensionConfigCmdletInfo(extensionId, extensionStatus, roles));
        }

        // Set-AzureServiceExtension
        public ManagementOperationContext SetAzureServiceExtension(string serviceName, string extensionName,
            string providerNamespace, string publicConfig, string privateConfig, string[] roles = null, string slot = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceExtensionCmdletInfo(serviceName, roles, slot, extensionName, providerNamespace,
                        publicConfig, privateConfig, version));
        }

        public ManagementOperationContext SetAzureServiceExtension(string serviceName, string extensionName,
            string providerNamespace, string publicConfig, string privateConfig, X509Certificate2 cert, string[] roles = null, string slot = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceExtensionCmdletInfo(serviceName, cert, roles, slot, extensionName,
                        providerNamespace, publicConfig, privateConfig, version));
        }

        public ManagementOperationContext SetAzureServiceExtension(string serviceName, string extensionName,
            string providerNamespace, string publicConfig, string privateConfig, string thumbprint, string algorithm = null, string[] roles = null, string slot = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceExtensionCmdletInfo(serviceName, thumbprint, algorithm, roles, slot,
                        extensionName, providerNamespace, publicConfig, privateConfig, version));
        }

        // Get-AzureServiceExtension
        public Collection<ExtensionContext> GetAzureServiceExtension(string serviceName, string slot = null, string extensionName = null, string providerNamespace = null)
        {
            return
                RunPSCmdletAndReturnAll<ExtensionContext>(new GetAzureServiceExtensionCmdletInfo(serviceName, slot,
                    extensionName, providerNamespace));
        }

        // Remove-AzureServiceExtension
        public ManagementOperationContext RemoveAzureServiceExtension(string serviceName, string extensionName,
            string providerNamespace, bool uninstall = false, string[] roles = null, string slot = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new RemoveAzureServiceExtensionCmdletInfo(serviceName, uninstall, roles, slot, extensionName,
                        providerNamespace));
        }

        // Get-AzureServiceAvailableExtension
        public Collection<ExtensionImageContext> GetAzureServiceAvailableExtension(string extensionName = null,
            string providerNamespace = null, string version = null, bool allVersion = false)
        {
            return
                RunPSCmdletAndReturnAll<ExtensionImageContext>(
                    new GetAzureServiceAvailableExtensionCmdletInfo(extensionName, providerNamespace, version,
                        allVersion));
        }

        #endregion

        #region AzureVM

        internal Collection<ManagementOperationContext> NewAzureVM(string serviceName, SM.PersistentVM[] VMs, string location = null, bool waitForBoot = false)
        {
            return NewAzureVM(serviceName, VMs, null, null, null, null, null, null, location,waitForBoot: waitForBoot);
        }

        internal Collection<ManagementOperationContext> NewAzureVMWithAG(string serviceName, SM.PersistentVM[] VMs, string affGroupName)
        {
            return NewAzureVM(serviceName, VMs, null, null, null, null, null, null, null, affGroupName);
        }

        internal Collection<ManagementOperationContext> NewAzureVMWithReservedIP(string serviceName, SM.PersistentVM[] VMs,
            string reservedIPName, string affGroupName = null)
        {
            return NewAzureVM(serviceName, VMs, null, null, null, null, null, null, null, affGroupName, reservedIPName);
        }

        internal Collection<ManagementOperationContext> NewAzureVMWithInternalLoadBalancer(string serviceName, SM.PersistentVM[] VMs, SM.InternalLoadBalancerConfig ilbConfig, string vnet = null, string location = null)
        {
            return NewAzureVM(serviceName, VMs, vnet, null, null, null, null, null, location, null, null, ilbConfig);
        }

        internal Collection<ManagementOperationContext> NewAzureVM(string serviceName, SM.PersistentVM[] vms,
            string vnetName, SM.DnsServer[] dnsSettings,
            string serviceLabel = null, string serviceDescription = null, string deploymentLabel = null, string deploymentDescription = null,
            string location = null, string affinityGroup = null, string reservedIPName = null, SM.InternalLoadBalancerConfig internalLoadBalancerConfig = null, bool waitForBoot = false)
        {
            Collection<ManagementOperationContext> result = new Collection<ManagementOperationContext>();
            Utilities.RetryActionUntilSuccess(
                () =>
                    result =
                        RunPSCmdletAndReturnAll<ManagementOperationContext>(new NewAzureVMCmdletInfo(serviceName, vms,
                            vnetName, dnsSettings, serviceLabel, serviceDescription, deploymentLabel,
                            deploymentDescription, location, affinityGroup, reservedIPName, internalLoadBalancerConfig, waitForBoot)),
                "409", 5, 60);
            return result;
        }

        public Collection<SM.PersistentVMRoleListContext> GetAzureVM(string serviceName = null)
        {
            return RunPSCmdletAndReturnAll<SM.PersistentVMRoleListContext>(new GetAzureVMCmdletInfo(null, serviceName));
        }

        public SM.PersistentVMRoleContext GetAzureVM(string vmName, string serviceName)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVMRoleContext>(new GetAzureVMCmdletInfo(vmName, serviceName));
        }

        public ManagementOperationContext RemoveAzureVM(string vmName, string serviceName, bool deleteVhd = false, bool whatif = false)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureVMCmdletInfo(vmName, serviceName, deleteVhd, whatif));
        }

        public ManagementOperationContext StartAzureVM(string vmName, string serviceName)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new StartAzureVMCmdletInfo(vmName, serviceName));
        }

        public ManagementOperationContext StopAzureVM(SM.PersistentVM vm, string serviceName, bool stay = false, bool force = false)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new StopAzureVMCmdletInfo(vm, serviceName, stay, force));
        }

        public ManagementOperationContext StopAzureVM(string vmName, string serviceName, bool stay = false, bool force = false)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new StopAzureVMCmdletInfo(vmName, serviceName, stay, force));
        }

        public void RestartAzureVM(string vmName, string serviceName)
        {
            RunPSCmdletAndReturnAll<ManagementOperationContext>(new RestartAzureVMCmdletInfo(vmName, serviceName));
        }

        public SM.PersistentVMRoleContext ExportAzureVM(string vmName, string serviceName, string path)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVMRoleContext>(new ExportAzureVMCmdletInfo(vmName, serviceName, path));
        }

        public Collection<SM.PersistentVM> ImportAzureVM(string path)
        {
            return RunPSCmdletAndReturnAll<SM.PersistentVM>(new ImportAzureVMCmdletInfo(path));
        }

        public ManagementOperationContext UpdateAzureVM(string vmName, string serviceName, SM.PersistentVM persistentVM)
        {
            ManagementOperationContext result = new ManagementOperationContext();
            result = RunPSCmdletAndReturnFirst<ManagementOperationContext>(new UpdateAzureVMCmdletInfo(vmName, serviceName, persistentVM));
            return result;
        }

        #endregion

        #region AzureVMImage

        public SM.OSImageContext AddAzureVMImage(string imageName, string mediaLocation, OS os, string label = null, string recommendedSize = null, string iconUri = null, string smallIconUri = null, bool showInGui = false)
        {
            SM.OSImageContext result = new SM.OSImageContext();
            Utilities.RetryActionUntilSuccess(
                () => result = RunPSCmdletAndReturnFirst<SM.OSImageContext>(new AddAzureVMImageCmdletInfo(imageName, mediaLocation, os, label, recommendedSize, iconUri, smallIconUri, showInGui)),
                "409", 3, 60);
            return result;
        }

        public void AddAzureVMImage(
            string imageName,
            string label,
            SM.VirtualMachineImageDiskConfigSet diskConfig,
            string description = null,
            string eula = null,
            string imageFamily = null,
            DateTime? publishedDate = null,
            string privacyUri = null,
            string recommendedVMSize = null,
            string iconName = null,
            string smallIconName = null,
            bool? showInGui = null)
        {
            var cmdletInfo = new AddAzureVMImageCmdletInfo(
                imageName,
                label,
                diskConfig,
                description,
                eula,
                imageFamily,
                publishedDate,
                privacyUri,
                recommendedVMSize,
                iconName,
                smallIconName,
                showInGui);

            RunPSCmdletAndReturnFirst<ManagementOperationContext>(cmdletInfo);
        }

        public SM.OSImageContext UpdateAzureVMImage(string imageName, string label, string recommendedSize = null)
        {
            return RunPSCmdletAndReturnFirst<SM.OSImageContext>(new UpdateAzureVMImageCmdletInfo(imageName, label, recommendedSize, null, null));
        }
        
        public SM.OSImageContext UpdateAzureVMImage(string imageName, string label, bool dontShowInGui)
        {
            return RunPSCmdletAndReturnFirst<SM.OSImageContext>(new UpdateAzureVMImageCmdletInfo(imageName, label, null, null, dontShowInGui));
        }

        public void UpdateAzureVMImage(string imageName, string label, SM.VirtualMachineImageDiskConfigSet diskConfig, string recommendedSize = null)
        {
            RunPSCmdletAndReturnFirst<ManagementOperationContext>(new UpdateAzureVMImageCmdletInfo(imageName, label, recommendedSize, diskConfig, null));
        }

        public void UpdateAzureVMImage(string imageName, string label, string imageFamily, bool showInGui = false, string recommendedSize = null,
            string description = null, string eula = null, Uri privacyUri = null, DateTime? publishedDate = null, string language = null, string iconUri = null,
            string smallIconUri = null)
        {
            RunPSCmdletAndReturnFirst<ManagementOperationContext>(new UpdateAzureVMImageCmdletInfo(imageName, label, recommendedSize, description, eula, imageFamily,
                privacyUri, publishedDate.Value, language, iconUri, smallIconUri, showInGui));
        }

        public ManagementOperationContext RemoveAzureVMImage(string imageName, bool deleteVhd = false)
        {
            ManagementOperationContext result = new ManagementOperationContext();
            Utilities.RetryActionUntilSuccess(
                () => result = RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureVMImageCmdletInfo(imageName, deleteVhd)),
                "409", 3, 60);
            return result;
        }

        public void SaveAzureVMImage(string serviceName, string vmName, string newImageName, string osState = null, string newImageLabel = null, bool debug = false, bool retryOnConflict = false)
        {
            RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SaveAzureVMImageCmdletInfo(serviceName, vmName, newImageName, newImageLabel, osState), debug, retryOnConflict);
        }

        public Collection<SM.OSImageContext> GetAzureVMImage(string imageName = null)
        {
            return RunPSCmdletAndReturnAll<SM.OSImageContext>(new GetAzureVMImageCmdletInfo(imageName));
        }

        public Collection<SM.VMImageContext> GetAzureVMImageReturningVMImages(string imageName = null)
        {
            Collection<SM.OSImageContext> images = GetAzureVMImage(imageName);
            Collection<SM.VMImageContext> vmImages = new Collection<SM.VMImageContext>();
            foreach (SM.OSImageContext image in images)
            {
                if (image is SM.VMImageContext)
                {
                    vmImages.Add((SM.VMImageContext)image);
                }
            }

            return vmImages;
        }

        public string GetAzureVMImageName(string[] keywords, bool exactMatch = true, int? diskSize = null)
        {
            Collection<SM.OSImageContext> vmImages = GetAzureVMImage();
            foreach (SM.OSImageContext image in vmImages)
            {
                if (Utilities.MatchKeywords(image.ImageName, keywords, exactMatch) >= 0
                    && ((diskSize == null) || (image.LogicalSizeInGB <= diskSize))
                    && image.Location.Contains(CredentialHelper.Location))
                    return image.ImageName;
            }
            foreach (SM.OSImageContext image in vmImages)
            {
                if (Utilities.MatchKeywords(image.OS, keywords, exactMatch) >= 0
                    && ((diskSize == null) || (image.LogicalSizeInGB <= diskSize))
                    && image.Location.Contains(CredentialHelper.Location))
                    return image.ImageName;
            }
            return null;
        }

        #endregion

        #region AzureVhd

        public string AddAzureVhdStop(FileInfo localFile, string destination, int ms)
        {
            WindowsAzurePowershellCmdlet azurePowershellCmdlet = new WindowsAzurePowershellCmdlet(new AddAzureVhdCmdletInfo(destination, localFile.FullName, null, false, null));
            return azurePowershellCmdlet.RunAndStop(ms).ToString();
        }

        public SM.VhdUploadContext AddAzureVhd(FileInfo localFile, string destination)
        {
            return AddAzureVhd(localFile, destination, null);
        }

        public SM.VhdUploadContext AddAzureVhd(FileInfo localFile, string destination, string baseImage)
        {
            return AddAzureVhd(localFile, destination, null, false, baseImage);
        }

        public SM.VhdUploadContext AddAzureVhd(FileInfo localFile, string destination, bool overwrite)
        {
            return AddAzureVhd(localFile, destination, null, overwrite);
        }

        public SM.VhdUploadContext AddAzureVhd(FileInfo localFile, string destination, int? numberOfUploaderThreads, bool overWrite = false, string baseImage = null)
        {
            SM.VhdUploadContext result = new SM.VhdUploadContext();
            Utilities.RetryActionUntilSuccess(
                () => result = RunPSCmdletAndReturnFirst<SM.VhdUploadContext>(new AddAzureVhdCmdletInfo(destination, localFile.FullName, numberOfUploaderThreads, overWrite, baseImage)),
                "pipeline is already running", 3, 30);
            return result;
        }

        public SM.VhdDownloadContext SaveAzureVhd(Uri source, FileInfo localFilePath, int? numThreads, string storageKey, bool overwrite)
        {
            SM.VhdDownloadContext result = new SM.VhdDownloadContext();
            Utilities.RetryActionUntilSuccess(
                () => result = RunPSCmdletAndReturnFirst<SM.VhdDownloadContext>(new SaveAzureVhdCmdletInfo(source, localFilePath, numThreads, storageKey, overwrite)),
                "pipeline is already running", 3, 30);
            return result;
        }

        public string SaveAzureVhdStop(Uri source, FileInfo localFilePath, int? numThreads, string storageKey, bool overwrite, int ms)
        {
            SaveAzureVhdCmdletInfo saveAzureVhdCmdletInfo = new SaveAzureVhdCmdletInfo(source, localFilePath, numThreads, storageKey, overwrite);
            WindowsAzurePowershellCmdlet azurePowershellCmdlet = new WindowsAzurePowershellCmdlet(saveAzureVhdCmdletInfo);
            return azurePowershellCmdlet.RunAndStop(ms).ToString();
        }

        #endregion

        #region AzureVnetConfig

        public Collection<SM.VirtualNetworkConfigContext> GetAzureVNetConfig(string filePath)
        {
            return RunPSCmdletAndReturnAll<SM.VirtualNetworkConfigContext>(new GetAzureVNetConfigCmdletInfo(filePath));
        }

        public ManagementOperationContext SetAzureVNetConfig(string filePath)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureVNetConfigCmdletInfo(filePath));
        }

        public ManagementOperationContext RemoveAzureVNetConfig()
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureVNetConfigCmdletInfo());
        }

        #endregion

        #region AzureVNetGateway

        public GatewayGetOperationStatusResponse NewAzureVNetGateway(string vnetName)
        {
            return RunPSCmdletAndReturnFirst<GatewayGetOperationStatusResponse>(new NewAzureVNetGatewayCmdletInfo(vnetName));
        }

        public Collection<Microsoft.WindowsAzure.Commands.ServiceManagement.Network.VirtualNetworkGatewayContext> GetAzureVNetGateway(string vnetName)
        {
            return RunPSCmdletAndReturnAll<Microsoft.WindowsAzure.Commands.ServiceManagement.Network.VirtualNetworkGatewayContext>(new GetAzureVNetGatewayCmdletInfo(vnetName));
        }

        public GatewayGetOperationStatusResponse SetAzureVNetGateway(string option, string vnetName, string localNetwork)
        {
            return RunPSCmdletAndReturnFirst<GatewayGetOperationStatusResponse>(new SetAzureVNetGatewayCmdletInfo(option, vnetName, localNetwork));
        }

        public GatewayGetOperationStatusResponse RemoveAzureVNetGateway(string vnetName)
        {
            return RunPSCmdletAndReturnFirst<GatewayGetOperationStatusResponse>(new RemoveAzureVNetGatewayCmdletInfo(vnetName));
        }

        public SharedKeyContext GetAzureVNetGatewayKey(string vnetName, string localnet)
        {
            return RunPSCmdletAndReturnFirst<SharedKeyContext>(new GetAzureVNetGatewayKeyCmdletInfo(vnetName, localnet));
        }

        #endregion

        #region AzureVNet

        public IEnumerable<GatewayConnectionContext> GetAzureVNetConnection(string vnetName)
        {
            return RunPSCmdletAndReturnFirst<IEnumerable<GatewayConnectionContext>>(new GetAzureVNetConnectionCmdletInfo(vnetName));
        }

        public Collection<SM.VirtualNetworkSiteContext> GetAzureVNetSite(string vnetName)
        {
            return RunPSCmdletAndReturnAll<SM.VirtualNetworkSiteContext>(new GetAzureVNetSiteCmdletInfo(vnetName));
        }

        #endregion

        #region AzureRoleSize

        public Collection<SM.RoleSizeContext> GetAzureRoleSize(string instanceSize = null)
        {
            return RunPSCmdletAndReturnAll<SM.RoleSizeContext>(new GetAzureRoleSizeCmdletInfo(instanceSize));
        }

        #endregion


        public ManagementOperationContext GetAzureRemoteDesktopFile(string vmName, string serviceName, string localPath, bool launch)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new GetAzureRemoteDesktopFileCmdletInfo(vmName, serviceName, localPath, launch));
        }

        public ManagementOperationContext ResetAzureRoleInstance(string serviceName,string instanceName,string slotType,bool reboot=false,bool reimage=false)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new ResetAzureRoleInstanceCmdletInfo(serviceName,instanceName,slotType,reboot,reimage));
        }

        internal SM.PersistentVM GetPersistentVM(PersistentVMConfigInfo configInfo)
        {
            SM.PersistentVM vm = null;

            if (null != configInfo)
            {
                if (configInfo.VmConfig != null)
                {
                    vm = NewAzureVMConfig(configInfo.VmConfig);
                }

                if (configInfo.ProvConfig != null)
                {
                    configInfo.ProvConfig.Vm = vm;
                    vm = AddAzureProvisioningConfig(configInfo.ProvConfig);
                }

                if (configInfo.DiskConfig != null)
                {
                    configInfo.DiskConfig.Vm = vm;
                    vm = AddAzureDataDisk(configInfo.DiskConfig);
                }

                if (configInfo.EndPointConfig != null)
                {
                    configInfo.EndPointConfig.Vm = vm;
                    vm = AddAzureEndPoint(configInfo.EndPointConfig);
                }
            }

            return vm;
        }

        internal void AddVMDataDisks(string vmName, string serviceName, AddAzureDataDiskConfig[] diskConfig)
        {
            SM.PersistentVMRoleContext vmRolectx = GetAzureVM(vmName, serviceName);

            foreach (AddAzureDataDiskConfig discCfg in diskConfig)
            {
                discCfg.Vm = vmRolectx.VM;
                vmRolectx.VM = AddAzureDataDisk(discCfg);
            }

            UpdateAzureVM(vmName, serviceName, vmRolectx.VM);
        }

        internal void SetVMDataDisks(string vmName, string serviceName, SetAzureDataDiskConfig[] diskConfig)
        {
            SM.PersistentVMRoleContext vmRolectx = GetAzureVM(vmName, serviceName);

            foreach (SetAzureDataDiskConfig discCfg in diskConfig)
            {
                discCfg.Vm = vmRolectx.VM;
                vmRolectx.VM = SetAzureDataDisk(discCfg);
            }

            UpdateAzureVM(vmName, serviceName, vmRolectx.VM);
        }

        internal void SetVMSize(string vmName, string serviceName, SetAzureVMSizeConfig vmSizeConfig)
        {
            SM.PersistentVMRoleContext vmRolectx = GetAzureVM(vmName, serviceName);

            vmSizeConfig.Vm = vmRolectx.VM;
            vmRolectx.VM = SetAzureVMSize(vmSizeConfig);

            UpdateAzureVM(vmName, serviceName, vmRolectx.VM);
        }

        public SM.PersistentVM SetAzureVMSize(SetAzureVMSizeConfig sizeCfg)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMSizeCmdletInfo(sizeCfg));
        }

        internal void AddVMDataDisksAndEndPoint(string vmName, string serviceName, AddAzureDataDiskConfig[] dataDiskConfig, AzureEndPointConfigInfo endPointConfig)
        {
            AddVMDataDisks(vmName, serviceName, dataDiskConfig);

            AddEndPoint(vmName, serviceName, new [] {endPointConfig});
        }

        public void RemoveAzureSubscriptions()
        {
            // Remove all subscriptions.  SAS Uri should work without a subscription.
            try
            {
                RunPSScript("Get-AzureSubscription | Remove-AzureSubscription -Force");
            }
            catch
            {
                Console.WriteLine("Subscriptions cannot be removed");
            }

            // Check if all subscriptions are removed.
            try
            {
                Assert.AreEqual(0, GetAzureSubscription().Count, "Subscription was not removed");
            }
            catch (Exception e)
            {
                if (e is AssertFailedException)
                {
                    throw;
                }
            }
        }

        public void RemoveAzureSubscription(string Name, bool force, bool debug = false)
        {
            var removeAzureSubscriptionCmdletInfo = new RemoveAzureSubscriptionCmdletInfo(Name, null, force);
            var removeAzureSubscriptionCmdlet = new WindowsAzurePowershellCmdlet(removeAzureSubscriptionCmdletInfo);
            removeAzureSubscriptionCmdlet.Run(debug);
        }

        public List<PSAzureEnvironment> GetAzureEnvironment(string name = null, string subscriptionDataFile = null, bool debug = false)
        {
            var envList = new List<PSAzureEnvironment>();
            RunPSCmdletAndReturnAll<PSAzureEnvironment>(new GetAzureEnvironmentCmdletInfo(name, subscriptionDataFile))
                .ForEach(a => envList.Add(a));
            return envList;
        }

        internal SM.NetworkAclObject NewAzureAclConfig()
        {
            return RunPSCmdletAndReturnFirst<SM.NetworkAclObject>(new NewAzureAclConfigCmdletInfo());
        }

        // Set-AzureAclConfig -AddRule -ACL $acl2 -Order 100 -Action Deny -RemoteSubnet "172.0.0.0/8" -Description "notes3"
        //   vmPowershellCmdlets.SetAzureAclConfig(SetACLConfig.AddRule, aclObj, 100, ACLAction.Permit,  "172.0.0.0//8", "Desc");
        internal void SetAzureAclConfig(SetACLConfig aclConfig, SM.NetworkAclObject aclObj, int order, ACLAction aclAction, string remoteSubnet, string desc)
        {
            RunPSCmdletAndReturnAll<SM.NetworkAclObject>(new SetAzureAclConfigCmdletInfo(aclConfig.ToString(), aclObj, order,
                                                                              aclAction.ToString(), remoteSubnet, desc,
                                                                              null));
        }

        internal SM.NetworkAclObject GetAzureAclConfig(SM.PersistentVM vm, string ep = null)
        {
            return RunPSCmdletAndReturnFirst<SM.NetworkAclObject>(new GetAzureAclConfigCmdletInfo(vm, ep));
        }

        #region AzureServiceDomainJoinExtension

        #region NewAzureServiceDomainJoinExtensionConfig

        // WorkgroupThumbprintParameterSet
        public ExtensionConfigurationInput NewAzureServiceDomainJoinExtensionConfig(string workGroupName,
            string certificateThumbprint, string[] role, bool restart, string thumbprintAlgorithm,
            PSCredential credential = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(
                    new NewAzureServiceDomainJoinExtensionConfigCmdletInfo(workGroupName, certificateThumbprint, role,
                        thumbprintAlgorithm, restart, credential, version));
        }

        // WorkgroupParameterSet
        public ExtensionConfigurationInput NewAzureServiceDomainJoinExtensionConfig(string workGroupName,
            X509Certificate2 x509Certificate, bool restart = true, string thumbprintAlgorithm = null,
            string[] role = null, PSCredential credential = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(
                    new NewAzureServiceDomainJoinExtensionConfigCmdletInfo(workGroupName, x509Certificate, role,
                        thumbprintAlgorithm, restart, credential, version));
        }

        // DomainParameterSet
        public ExtensionConfigurationInput NewAzureServiceDomainJoinExtensionConfig(string domainName,
            X509Certificate2 x509Certificate, JoinOptions? options = null, string oUPath = null,
            PSCredential unjoinDomainCredential = null, string[] role = null, string thumbprintAlgorithm = null,
            bool restart = true, PSCredential credential = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(
                    new NewAzureServiceDomainJoinExtensionConfigCmdletInfo(domainName, x509Certificate, options, oUPath,
                        unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version));
        }

        // DomainJoinOptionThumbprintParameterSet
        public ExtensionConfigurationInput NewAzureServiceDomainJoinExtensionConfig(string domainName,
            string certificateThumbprint, string oUPath = null, PSCredential unjoinDomainCredential = null,
            string[] role = null, string thumbprintAlgorithm = null, uint? joinOption = null, bool restart = true,
            PSCredential credential = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ExtensionConfigurationInput>(
                    new NewAzureServiceDomainJoinExtensionConfigCmdletInfo(domainName, certificateThumbprint, joinOption,
                        oUPath, unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version));
        }

        #endregion NewAzureServiceDiagnosticsExtensionConfig

        #region SetAzureServiceDomainJoinExtensionCmdletInfo

        // WorkgroupParameterSet
        public ManagementOperationContext SetAzureServiceDomainJoinExtension
            (string workGroupName,
                string serviceName,  string slot = SM.DeploymentSlotType.Production, string[] role = null,
                X509Certificate2 x509Certificate = null, bool restart = true, string thumbprintAlgorithm = null,
                 PSCredential credential = null, string version = null)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new SetAzureServiceDomainJoinExtensionCmdletInfo(
                workGroupName, x509Certificate, role, slot, serviceName,restart, thumbprintAlgorithm, credential, version));
        }

        // WorkgroupThumbprintParameterSet
        public ManagementOperationContext SetAzureServiceDomainJoinExtension
            (string workGroupName,
                string serviceName,  string slot, string[] role,
                string certificateThumbprint, string thumbprintAlgorithm = null,
                bool restart = true, PSCredential credential = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceDomainJoinExtensionCmdletInfo(workGroupName, certificateThumbprint, role, slot,
                        serviceName, thumbprintAlgorithm, restart, credential, version));
        }

        // DomainJoinOptionThumprintParameterSet
        public ManagementOperationContext SetAzureServiceDomainJoinExtension
            (string domainName, PSCredential credential, uint joinOption, bool restart,
            string serviceName, string slot, string[] role,
            string certificateThumbprint, string thumbprintAlgorithm = null,
                PSCredential unjoinDomainCredential = null, string oUPath = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceDomainJoinExtensionCmdletInfo(domainName, certificateThumbprint, joinOption,
                        unjoinDomainCredential,
                        role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version));
        }

        // DomainThumprintParameterSet
        public ManagementOperationContext SetAzureServiceDomainJoinExtension
            (string domainName, PSCredential credential, JoinOptions? options, bool restart,
            string serviceName, string slot, string[] role,
            string certificateThumbprint, string thumbprintAlgorithm = null,
                PSCredential unjoinDomainCredential = null, string oUPath = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceDomainJoinExtensionCmdletInfo(domainName, certificateThumbprint, options,
                        unjoinDomainCredential,
                        role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version));
        }

        // DomainParameterSet
        public ManagementOperationContext SetAzureServiceDomainJoinExtension
            (string domainName, PSCredential credential, JoinOptions? options, bool restart,
                string serviceName, string slot, string[] role,
                X509Certificate2 x509Certificate = null, string thumbprintAlgorithm = null,
                PSCredential unjoinDomainCredential = null, string oUPath = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceDomainJoinExtensionCmdletInfo(domainName, x509Certificate, options,
                        unjoinDomainCredential,
                        role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version));
        }

        // DomainJoinOptionParameterSet
        public ManagementOperationContext SetAzureServiceDomainJoinExtension
            (string domainName, PSCredential credential, uint joinOption, bool restart,
            string serviceName, string slot, string[] role = null,
            X509Certificate2 x509Certificate = null, string thumbprintAlgorithm = null,
            PSCredential unjoinDomainCredential = null, string oUPath = null, string version = null)
        {
            return
                RunPSCmdletAndReturnFirst<ManagementOperationContext>(
                    new SetAzureServiceDomainJoinExtensionCmdletInfo(domainName, x509Certificate, joinOption,
                        unjoinDomainCredential,
                        role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version));
        }

        #endregion SetAzureServiceDomainJoinExtensionCmdletInfo

        #region GetAzureServiceDomainJoinExtension
        public ADDomainExtensionContext GetAzureServiceDomainJoinExtension(string serviceName = null, string slot = null)
        {
            return RunPSCmdletAndReturnFirst<ADDomainExtensionContext>(new GetAzureServiceDomainJoinExtensionCmdletInfo(serviceName, slot));
        }
        #endregion GetAzureServiceDomainJoinExtension

        #region RemoveAzureServiceDomainJoinExtension
        public ManagementOperationContext RemoveAzureServiceDomainJoinExtension(string serviceName, string slot, string[] role = null, bool uninstallConfiguration = false)
        {
            return RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureServiceDomainJoinExtensionCmdletInfo(serviceName, slot, role, uninstallConfiguration));
        }
        #endregion RemoveAzureServiceDomainJoinExtension

        #endregion AzureServiceDomainJoinExtension

        #region StaticCA
        public SM.VirtualNetworkStaticIPAvailabilityContext TestAzureStaticVNetIP(string vNetName, string iPAddress)
        {
            return RunPSCmdletAndReturnFirst<SM.VirtualNetworkStaticIPAvailabilityContext>(new TestAzureStaticVNetIPCmdletInfo(vNetName, iPAddress));
        }

        public SM.PersistentVM SetAzureStaticVNetIP(string iPAddress, SM.IPersistentVM vM)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureStaticVNetIPCmdletInfo(iPAddress, vM));
        }

        public SM.VirtualNetworkStaticIPContext GetAzureStaticVNetIP(SM.IPersistentVM vM)
        {
            return RunPSCmdletAndReturnFirst<SM.VirtualNetworkStaticIPContext>(new GetAzureStaticVNetIPCmdletInfo(vM));
        }

        public SM.PersistentVM RemoveAzureStaticVNetIP(SM.IPersistentVM vM)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureStaticVNetIPCmdletInfo(vM));
        }
        #endregion StaticCA

        #region AzureVM BGInfo Extension
        public VirtualMachineBGInfoExtensionContext GetAzureVMBGInfoExtension(SM.IPersistentVM vm, string version = null, string referenceName = null)
        {
            return RunPSCmdletAndReturnFirst<VirtualMachineBGInfoExtensionContext>(new GetAzureVMBGInfoExtensionCmdletInfo(vm, version, referenceName));
        }

        public SM.PersistentVM SetAzureVMBGInfoExtension(SM.IPersistentVM vm, string version = null, string referenceName = null, bool disable = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMBGInfoExtensionCmdletInfo(vm, version, referenceName, disable));
        }

        public SM.PersistentVM RemoveAzureVMBGInfoExtension(SM.IPersistentVM vm, string version = null, string referenceName = null)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureVMBGInfoExtensionCmdletInfo(vm, version, referenceName));
        }
        #endregion AzureVM BGInfo Extension

        #region Generic VM Extension cmdlets
        public SM.PersistentVM SetAzureVMExtension(SM.IPersistentVM vm,
            string extensionName, string publisher,
            string version, string referenceName = null,
            string publicConfiguration = null, string privateConfiguration = null,
            string publicConfigKey = null, string privateConfigKey = null,
            string publicConfigPath = null, string privateConfigPath = null,
            bool disable = false, bool forceUpdate = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMExtensionCmdletInfo(vm,
                extensionName, publisher,
                version, referenceName,
                publicConfiguration, privateConfiguration,
                publicConfigKey, privateConfigKey,
                publicConfigPath, privateConfigPath,
                disable, forceUpdate));
        }

        public SM.PersistentVM RemoveAzureVMExtension(SM.PersistentVM vm,
            string extensionName, string publisher,
            string referenceName = null, bool removeAll = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureVMExtensionCmdletInfo(vm,
                extensionName, publisher,
                referenceName, removeAll));
        }

        public Collection<VirtualMachineExtensionContext> GetAzureVMExtension(SM.PersistentVM vm, string extensionName = null, string publisher = null, string version = null, string referenceName = null)
        {
            return RunPSCmdletAndReturnAll<VirtualMachineExtensionContext>(new GetAzureVMExtensionCmdletInfo(vm, extensionName, publisher, version, referenceName));
        }

        // ListAllVersionsParamSetName -> ExtensionName,Publisher,AllVersions
        public Collection<VirtualMachineExtensionImageContext> GetAzureVMAvailableExtension(string extensionName, string publisher, bool allVersions)
        {
            return RunPSCmdletAndReturnAll<VirtualMachineExtensionImageContext>(new GetAzureVMAvailableExtensionCmdletInfo(extensionName, publisher, allVersions));
        }

        //ListLatestExtensionsParamSet -> ExtensionName,Publisher
        public Collection<VirtualMachineExtensionImageContext> GetAzureVMAvailableExtension(string extensionName = null, string publisher = null)
        {
            return RunPSCmdletAndReturnAll<VirtualMachineExtensionImageContext>(new GetAzureVMAvailableExtensionCmdletInfo(extensionName, publisher));
        }

        //ListSingleVersionParamSetName -> ExtensionName,Publisher,Version
        public Collection<VirtualMachineExtensionImageContext> GetAzureVMAvailableExtension(string extensionName, string publisher, string version)
        {
            return RunPSCmdletAndReturnAll<VirtualMachineExtensionImageContext>(new GetAzureVMAvailableExtensionCmdletInfo(extensionName, publisher, version));
        }
        #endregion Generic VM Extension cmdlets

        #region AzureVMAccessExtension cmdlets

        public Collection<VirtualMachineAccessExtensionContext> GetAzureVMAccessExtension(SM.IPersistentVM vm,string userName= null, string password = null, string version= null,string referenceName= null)
        {
            return RunPSCmdletAndReturnAll<VirtualMachineAccessExtensionContext>(new GetAzureVMAccessExtensionCmdletInfo(vm, userName, password, version, referenceName));
        }

        public SM.PersistentVM SetAzureVMAccessExtension(
            SM.IPersistentVM vm,
            string userName= null,
            string password=null,
            string version = null,
            string referenceName =null,
            bool disable = false,
            bool forceUpdate = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMAccessExtensionCmdletInfo(
                vm,  userName,  password,  version,  referenceName, disable, forceUpdate));
        }

        public SM.PersistentVM RemoveAzureVMAccessExtension(SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureVMAccessExtensionCmdleteInfo(vm));
        }

        #endregion AzureVMAccessExtension cmdlets

        #region AzureVMCustomScriptExtensionCmdlets
        // SetCustomScriptExtensionByUrisParamSetName
        internal SM.PersistentVM SetAzureVMCustomScriptExtension(
            SM.PersistentVM vm,
            string[] fileUri,
            bool sseSaSKeys,
            string run = null,
            string referenceName = null,
            string version = null,
            string argument = null,
            bool forceUpdate = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMCustomScriptExtensionCmdletInfo(
                vm, referenceName, version, fileUri, run, argument, forceUpdate));
        }

        // DisableCustomScriptExtensionParamSetName
        internal SM.PersistentVM SetAzureVMCustomScriptExtension(
            SM.PersistentVM vm,
            bool disable,
            string referenceName = null,
            string version = null,
            bool forceUpdate = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMCustomScriptExtensionCmdletInfo(
                vm, referenceName, version, disable, forceUpdate));
        }

        // SetCustomScriptExtensionByContainerBlobsParamSetName
        internal SM.PersistentVM SetAzureVMCustomScriptExtension(
            SM.PersistentVM vm,
            string[] fileName,
            string run = null,
            string storageAccountName = null,
            string StorageEndpointSuffix = null,
            string containerName = null,
            string StorageAccountKey = null,
            string referenceName = null,
            string version = null,
            string argument = null,
            bool forceUpdate = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMCustomScriptExtensionCmdletInfo(
                vm, fileName, storageAccountName, StorageEndpointSuffix, containerName,
                    StorageAccountKey, run, argument, referenceName, version, forceUpdate));
        }

        internal VirtualMachineCustomScriptExtensionContext GetAzureVMCustomScriptExtension(SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<VirtualMachineCustomScriptExtensionContext>(new GetAzureVMCustomScriptExtensionCmdletInfo(vm));
        }

        internal SM.PersistentVM RemoveAzureVMCustomScriptExtension(SM.PersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureVMCustomScriptExtensionCmdletInfo(vm));
        }
        #endregion AzureVMCustomScriptExtensionCmdlets

        #region AzureVMSqlServerExtensionCmdlets

        public VirtualMachineSqlServerExtensionContext GetAzureVMSqlServerExtension(SM.IPersistentVM vm, string version = null, string referenceName = null)
        {
            return RunPSCmdletAndReturnFirst<VirtualMachineSqlServerExtensionContext>(new GetAzureVMSqlServerExtensionCmdletInfo(vm, version, referenceName));
        }

        public SM.PersistentVM SetAzureVMSqlServerExtension(SM.IPersistentVM vm, string version = null, string referenceName = null, bool disable = false)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new SetAzureVMSqlServerExtensionCmdletInfo(vm, version, referenceName, disable));
        }

        public SM.PersistentVM RemoveAzureVMSqlServerExtension(SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.PersistentVM>(new RemoveAzureVMSqlServerExtensionCmdletInfo(vm));
        }

        #endregion AzureVMAccessExtension cmdlets

        internal SM.LinuxProvisioningConfigurationSet.SSHPublicKey NewAzureSSHKey(NewAzureSshKeyType option, string fingerprint, string path)
        {
            return RunPSCmdletAndReturnFirst<SM.LinuxProvisioningConfigurationSet.SSHPublicKey>(new NewAzureSSHKeyCmdletInfo(option, fingerprint, path));
        }

        internal SM.VirtualMachineImageDiskConfigSet GetAzureVMImageDiskConfigSet(SM.VMImageContext imageContext)
        {
            return RunPSCmdletAndReturnFirst<SM.VirtualMachineImageDiskConfigSet>(new GetAzureVMImageDiskConfigSetCmdletInfo(imageContext));
        }

        internal SM.VirtualMachineImageDiskConfigSet SetAzureVMImageDataDiskConfig(SM.VirtualMachineImageDiskConfigSet diskConfig, string dataDiskName, int lun, string hostCaching)
        {
            return RunPSCmdletAndReturnFirst<SM.VirtualMachineImageDiskConfigSet>(new SetAzureVMImageDataDiskConfigInfo(diskConfig, dataDiskName, lun, hostCaching));
        }

        internal SM.VirtualMachineImageDiskConfigSet SetAzureVMImageOSDiskConfig(SM.VirtualMachineImageDiskConfigSet diskConfigSet, string osHostCaching)
        {
            return RunPSCmdletAndReturnFirst<SM.VirtualMachineImageDiskConfigSet>(new SetAzureVMImageOSDiskConfigInfo(diskConfigSet, osHostCaching));
        }

        internal SM.VirtualMachineImageDiskConfigSet NewAzureVMImageDiskConfigSet()
        {
            return RunPSCmdletAndReturnFirst<SM.VirtualMachineImageDiskConfigSet>(new NewAzureVMImageDiskConfigSetCmdletInfo());
        }

        //Internal Load Balancer
        internal SM.InternalLoadBalancerConfig NewAzureInternalLoadBalancerConfig(string ilbName, string subnet = null, IPAddress staticVnetIpAddress = null)
        {
            return RunPSCmdletAndReturnFirst<SM.InternalLoadBalancerConfig>(new NewAzureInternalLoadBalancerConfigCmdletInfo(ilbName, subnet, staticVnetIpAddress));
        }

        internal void AddAzureInternalLoadBalancer(string internalLoadBalancerName, string serviceName, string subnetName, IPAddress staticVNetIPAddress)
        {
            RunPSCmdletAndReturnFirst<ManagementOperationContext>(new AddAzureInternalLoadBalancerCmdletInfo(internalLoadBalancerName, serviceName, subnetName, staticVNetIPAddress));
        }

        internal void RemoveAzureInternalLoadBalancer(string serviceName)
        {
            RunPSCmdletAndReturnFirst<ManagementOperationContext>(new RemoveAzureInternalLoadBalancerCmdletInfo(serviceName));
        }

        internal SM.InternalLoadBalancerContext GetAzureInternalLoadBalancer(string serviceName)
        {
            return RunPSCmdletAndReturnFirst<SM.InternalLoadBalancerContext>(new GetAzureInternalLoadBalancerCmdletInfo(serviceName));
        }

        internal SM.IPersistentVM SetAzurePublicIp(string publicIpName, SM.IPersistentVM vm, string domainNameLabel = null)
        {
            return RunPSCmdletAndReturnFirst<SM.IPersistentVM>(new SetAzurePublicIPCmdletInfo(publicIpName, vm, domainNameLabel));
        }

        internal SM.AssignPublicIP GetAzurePublicIpName(string publicIpName, SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.AssignPublicIP>(new GetAzurePublicIPCmdletInfo(publicIpName, vm));
        }

        internal SM.IPersistentVM AddAzureNetworkInterfaceConfig(string name, string subnetName, string staticVnetIpAddress, SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.IPersistentVM>(new AddAzureNetworkInterfaceConfigCmdletInfo(name, subnetName, staticVnetIpAddress, vm));
        }

        internal SM.IPersistentVM AddAzureNetworkInterfaceConfig(string name, string subnetName, SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.IPersistentVM>(new AddAzureNetworkInterfaceConfigCmdletInfo(name, subnetName, null, vm));
        }

        internal SM.IPersistentVM SetAzureNetworkInterfaceConfig(string name, string subnetName, string staticVnetIpAddress, SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.IPersistentVM>(new SetAzureNetworkInterfaceConfigCmdletInfo(name, subnetName, staticVnetIpAddress, vm));
        }

        internal SM.IPersistentVM SetAzureNetworkInterfaceConfig(string name, string subnetName, SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.IPersistentVM>(new SetAzureNetworkInterfaceConfigCmdletInfo(name, subnetName, null, vm));
        }

        internal SM.NetworkInterface GetAzureNetworkInterfaceConfig(string name, SM.PersistentVMRoleContext vm)
        {
            return RunPSCmdletAndReturnFirst<SM.NetworkInterface>(new GetAzureNetworkInterfaceConfigCmdletInfo(name, vm));
        }

        internal SM.IPersistentVM RemoveAzureNetworkInterfaceConfig(string name, SM.IPersistentVM vm)
        {
            return RunPSCmdletAndReturnFirst<SM.IPersistentVM>(new RemoveAzureNetworkInterfaceConfigCmdletInfo(name, vm));
        }
    }
}
