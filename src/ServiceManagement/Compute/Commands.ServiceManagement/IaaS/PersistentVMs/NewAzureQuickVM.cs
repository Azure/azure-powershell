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

using AutoMapper;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using ConfigurationSet = Microsoft.WindowsAzure.Commands.ServiceManagement.Model.ConfigurationSet;
using InputEndpoint = Microsoft.WindowsAzure.Commands.ServiceManagement.Model.InputEndpoint;
using OSVirtualHardDisk = Microsoft.WindowsAzure.Commands.ServiceManagement.Model.OSVirtualHardDisk;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.PersistentVMs
{
    /// <summary>
    /// Creates a VM without advanced provisioning configuration options
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureQuickVM", DefaultParameterSetName = WindowsParamSet), OutputType(typeof(ManagementOperationContext))]
    public class NewQuickVM : IaaSDeploymentManagementCmdletBase
    {
        protected const string WindowsParamSet = "Windows";
        protected const string LinuxParamSet = "Linux";

        private bool _isVMImage;
        private bool _isOSImage;

        [Parameter(Mandatory = true, ParameterSetName = WindowsParamSet, HelpMessage = "Create a Windows VM")]
        public SwitchParameter Windows { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = LinuxParamSet, HelpMessage = "Create a Linux VM")]
        public SwitchParameter Linux { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Service Name")]
        [ValidateNotNullOrEmpty]
        override public string ServiceName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Virtual Machine Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Reference to a platform stock image or a user image from the image repository.")]
        [ValidateNotNullOrEmpty]
        public string ImageName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Administrator password to use for the role.")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Dns address to which the cloud service’s IP address resolves when queried using a reverse Dns query.")]
        [ValidateNotNullOrEmpty]
        public string ReverseDnsFqdn{ get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Use when creating the first virtual machine in a cloud service (or specify affinity group).  The data center region where the cloud service will be created.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Use when creating the first virtual machine in a cloud service (or specify location). The name of an existing affinity group associated with this subscription.")]
        [ValidateNotNullOrEmpty]
        public string AffinityGroup { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParamSet, HelpMessage = "User to Create")]
        [ValidateNotNullOrEmpty]
        public string LinuxUser { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "Specifies the Administrator to create.")]
        [ValidateNotNullOrEmpty]
        public string AdminUsername { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "Set of certificates to install in the VM.")]
        [ValidateNotNullOrEmpty]
        public Model.CertificateSettingList Certificates { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Waits for VM to boot")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter WaitForBoot { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "Disables WinRM on https")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableWinRMHttps { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "Enables WinRM over http")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableWinRMHttp { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "Certificate that will be associated with WinRM endpoint")]
        [ValidateNotNullOrEmpty]
        public X509Certificate2 WinRMCertificate { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "X509Certificates that will be deployed")]
        [ValidateNotNullOrEmpty]
        public X509Certificate2[] X509Certificates { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "Prevents the private key from being uploaded")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NoExportPrivateKey { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WindowsParamSet, HelpMessage = "Prevents the WinRM endpoint from being added")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NoWinRMEndpoint { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParamSet, HelpMessage = "SSH Public Key List")]
        public Model.LinuxProvisioningConfigurationSet.SSHPublicKeyList SSHPublicKeys { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = LinuxParamSet, HelpMessage = "SSH Key Pairs")]
        public Model.LinuxProvisioningConfigurationSet.SSHKeyPairList SSHKeyPairs { get; set; }

        [Parameter(HelpMessage = "Virtual network name.")]
        public string VNetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of subnet names.")]
        [AllowEmptyCollection]
        [AllowNull]
        public string[] SubnetNames { get; set; }

        [Parameter(HelpMessage = "DNS Settings for Deployment.")]
        [ValidateNotNullOrEmpty]
        public Model.DnsServer[] DnsSettings { get; set; }

        [Parameter(HelpMessage = "Controls the platform caching behavior of the OS disk.")]
        [ValidateSet("ReadWrite", "ReadOnly", IgnoreCase = true)]
        public String HostCaching { get; set; }

        [Parameter(HelpMessage = "The name of the availability set.")]
        [ValidateNotNullOrEmpty]
        public string AvailabilitySetName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Represents the size of the machine.")]
        [ValidateNotNullOrEmpty]
        public string InstanceSize { get; set; }

        [Parameter(HelpMessage = "Location where the VHD should be created. This link refers to a blob in a storage account. If not specified the VHD will be created in the current storage account in the vhds container.")]
        [ValidateNotNullOrEmpty]
        public string MediaLocation { get; set; }

        [Parameter(HelpMessage = "To disable IaaS provision guest agent.")]
        public SwitchParameter DisableGuestAgent { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Path to filename that contains custom data that will execute inside the VM after boot")]
        public string CustomDataFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the reserved IP.")]
        [ValidateNotNullOrEmpty]
        public string ReservedIPName { get; set; }

        public void NewAzureVMProcess()
        {
            AzureSubscription currentSubscription = Profile.Context.Subscription;
            CloudStorageAccount currentStorage = null;
            try
            {
                currentStorage = currentSubscription.GetCloudStorageAccount(Profile);
            }
            catch (Exception ex) // couldn't access
            {
                throw new ArgumentException(Resources.CurrentStorageAccountIsNotAccessible, ex);
            }
            if (currentStorage == null) // not set
            {
                throw new ArgumentException(Resources.CurrentStorageAccountIsNotSet);
            }

            bool serviceExists = DoesCloudServiceExist(this.ServiceName);

            if (!string.IsNullOrEmpty(this.Location))
            {
                if (serviceExists)
                {
                    HostedServiceGetResponse existingSvc = null;
                    try
                    {
                        existingSvc = ComputeClient.HostedServices.Get(this.ServiceName);
                    }
                    catch
                    {
                        throw new ApplicationException(Resources.ServiceExistsLocationCanNotBeSpecified);
                    }

                    if (existingSvc == null ||
                        existingSvc.Properties == null ||
                        !this.Location.Equals(existingSvc.Properties.Location))
                    {
                        throw new ApplicationException(Resources.ServiceExistsLocationCanNotBeSpecified);
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.AffinityGroup))
            {
                if (serviceExists)
                {
                    HostedServiceGetResponse existingSvc = null;
                    try
                    {
                        existingSvc = ComputeClient.HostedServices.Get(this.ServiceName);
                    }
                    catch
                    {
                        throw new ApplicationException(Resources.ServiceExistsAffinityGroupCanNotBeSpecified);
                    }

                    if (existingSvc == null ||
                        existingSvc.Properties == null ||
                        !this.AffinityGroup.Equals(existingSvc.Properties.AffinityGroup))
                    {
                        throw new ApplicationException(Resources.ServiceExistsAffinityGroupCanNotBeSpecified);
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.ReverseDnsFqdn))
            {
                if (serviceExists)
                {
                    throw new ApplicationException(Resources.ServiceExistsReverseDnsFqdnCanNotBeSpecified);
                }
            }

            if (!serviceExists)
            {
                try
                {
                    //Implicitly created hosted service2012-05-07 23:12 

                    // Create the Cloud Service when
                    // Location or Affinity Group is Specified
                    // or VNET is specified and the service doesn't exist
                    var parameter = new HostedServiceCreateParameters
                    {
                        AffinityGroup = this.AffinityGroup,
                        Location = this.Location,
                        ServiceName = this.ServiceName,
                        Description = String.Format("Implicitly created hosted service{0}", DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm")),
                        Label = this.ServiceName,
                        ReverseDnsFqdn = this.ReverseDnsFqdn
                    };

                    ExecuteClientActionNewSM(
                        parameter,
                        CommandRuntime + Resources.QuickVMCreateCloudService,
                        () => this.ComputeClient.HostedServices.Create(parameter));
                }
                catch (CloudException ex)
                {
                    WriteExceptionError(ex);
                    return;
                }
            }

            if (ParameterSetName.Equals(WindowsParamSet, StringComparison.OrdinalIgnoreCase))
            {
                if (WinRMCertificate != null)
                {
                    if (!CertUtilsNewSM.HasExportablePrivateKey(WinRMCertificate))
                    {
                        throw new ArgumentException(Resources.WinRMCertificateDoesNotHaveExportablePrivateKey);
                    }

                    var operationDescription = string.Format(Resources.QuickVMUploadingWinRMCertificate, CommandRuntime, WinRMCertificate.Thumbprint);
                    var parameters = CertUtilsNewSM.Create(WinRMCertificate);

                    ExecuteClientActionNewSM(
                        null,
                        operationDescription,
                        () => this.ComputeClient.ServiceCertificates.Create(this.ServiceName, parameters),
                        (s, r) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(r, s));
                }

                if (X509Certificates != null)
                {
                    var certificateFilesWithThumbprint = from c in X509Certificates
                                                         select new
                                                         {
                                                             c.Thumbprint,
                                                             CertificateFile = CertUtilsNewSM.Create(c, this.NoExportPrivateKey.IsPresent)
                                                         };
                    foreach (var current in certificateFilesWithThumbprint.ToList())
                    {
                        var operationDescription = string.Format(Resources.QuickVMUploadingCertificate, CommandRuntime, current.Thumbprint);
                        ExecuteClientActionNewSM(
                            null,
                            operationDescription,
                            () => this.ComputeClient.ServiceCertificates.Create(this.ServiceName, current.CertificateFile),
                            (s, r) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(r, s));
                    }
                }
            }

            var vm = CreatePersistenVMRole(currentStorage);

            try
            {
                if (CurrentDeploymentNewSM == null)
                {
                    // If the current deployment doesn't exist set it create it
                    var parameters = new VirtualMachineCreateDeploymentParameters
                    {
                        DeploymentSlot     = DeploymentSlot.Production,
                        Name               = this.ServiceName,
                        Label              = this.ServiceName,
                        VirtualNetworkName = this.VNetName,
                        Roles              = { vm },
                        ReservedIPName     = this.ReservedIPName,
                        DnsSettings        = this.DnsSettings == null ? null : new Microsoft.WindowsAzure.Management.Compute.Models.DnsSettings
                                             {
                                                 DnsServers = (from dns in this.DnsSettings
                                                               select new Management.Compute.Models.DnsServer
                                                               {
                                                                   Name = dns.Name,
                                                                   Address = dns.Address
                                                               }).ToList()
                                             }
                    };

                    ExecuteClientActionNewSM(
                        parameters,
                        string.Format(Resources.QuickVMCreateDeploymentWithVM, CommandRuntime, vm.RoleName),
                        () => this.ComputeClient.VirtualMachines.CreateDeployment(this.ServiceName, parameters));
                }
                else
                {
                    if (!string.IsNullOrEmpty(VNetName) || DnsSettings != null)
                    {
                        WriteWarning(Resources.VNetNameOrDnsSettingsCanOnlyBeSpecifiedOnNewDeployments);
                    }

                    // Only create the VM when a new VM was added and it was not created during the deployment phase.
                    ExecuteClientActionNewSM(
                        vm,
                        string.Format(Resources.QuickVMCreateVM, CommandRuntime, vm.RoleName),
                        () => this.ComputeClient.VirtualMachines.Create(
                            this.ServiceName,
                            this.ServiceName,
                            new VirtualMachineCreateParameters
                            {
                                AvailabilitySetName         = vm.AvailabilitySetName,
                                OSVirtualHardDisk           = vm.OSVirtualHardDisk,
                                DataVirtualHardDisks        = vm.DataVirtualHardDisks,
                                RoleName                    = vm.RoleName,
                                RoleSize                    = vm.RoleSize,
                                VMImageName                 = vm.VMImageName,
                                MediaLocation               = vm.MediaLocation,
                                ProvisionGuestAgent         = vm.ProvisionGuestAgent,
                                ResourceExtensionReferences = vm.ResourceExtensionReferences,
                                ConfigurationSets           = vm.ConfigurationSets
                            }));
                }

                if (WaitForBoot.IsPresent)
                {
                    WaitForRoleToBoot(vm.RoleName);
                }
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception(Resources.ServiceDoesNotExistSpecifyLocationOrAffinityGroup);
                }

                WriteExceptionError(ex);
            }
        }

        private Management.Compute.Models.Role CreatePersistenVMRole(CloudStorageAccount currentStorage)
        {
            var vm = new Management.Compute.Models.Role
            {
                AvailabilitySetName         = AvailabilitySetName,
                RoleName                    = String.IsNullOrEmpty(Name) ? ServiceName : Name, // default like the portal
                RoleSize                    = InstanceSize,
                RoleType                    = "PersistentVMRole",
                Label                       = ServiceName,
                OSVirtualHardDisk           = _isVMImage ? null : Mapper.Map<Management.Compute.Models.OSVirtualHardDisk>(
                                              new OSVirtualHardDisk
                                              {
                                                  DiskName        = null,
                                                  SourceImageName = ImageName,
                                                  MediaLink       = string.IsNullOrEmpty(MediaLocation) ? null : new Uri(MediaLocation),
                                                  HostCaching     = HostCaching
                                              }),
                VMImageName                 = _isVMImage ? this.ImageName : null,
                MediaLocation               = _isVMImage && !string.IsNullOrEmpty(this.MediaLocation) ? new Uri(this.MediaLocation) : null,
                ProvisionGuestAgent         = !this.DisableGuestAgent,
                ResourceExtensionReferences = this.DisableGuestAgent ? null : Mapper.Map<List<Management.Compute.Models.ResourceExtensionReference>>(
                    new VirtualMachineExtensionImageFactory(this.ComputeClient).MakeList(
                        VirtualMachineBGInfoExtensionCmdletBase.ExtensionDefaultPublisher,
                        VirtualMachineBGInfoExtensionCmdletBase.ExtensionDefaultName,
                        VirtualMachineBGInfoExtensionCmdletBase.ExtensionDefaultVersion)),
                DebugSettings = new Management.Compute.Models.DebugSettings
                {
                    BootDiagnosticsEnabled = true
                }
            };

            if (!_isVMImage && vm.OSVirtualHardDisk.MediaLink == null && String.IsNullOrEmpty(vm.OSVirtualHardDisk.Name))
            {
                var mediaLinkFactory = new MediaLinkFactory(currentStorage, this.ServiceName, vm.RoleName);
                vm.OSVirtualHardDisk.MediaLink = mediaLinkFactory.Create();
            }
            
            string customDataBase64Str = null;
            if (!string.IsNullOrEmpty(this.CustomDataFile))
            {
                string fileName = this.TryResolvePath(this.CustomDataFile);
                customDataBase64Str = PersistentVMHelper.ConvertCustomDataFileToBase64(fileName);
            }

            var configurationSets = new Collection<ConfigurationSet>();
            var netConfig = CreateNetworkConfigurationSet();

            if (ParameterSetName.Equals(WindowsParamSet, StringComparison.OrdinalIgnoreCase))
            {
                if (this.AdminUsername != null && this.Password != null)
                {
                    var windowsConfig = new Microsoft.WindowsAzure.Commands.ServiceManagement.Model.WindowsProvisioningConfigurationSet
                    {
                        AdminUsername = this.AdminUsername,
                        AdminPassword = SecureStringHelper.GetSecureString(Password),
                        ComputerName = string.IsNullOrEmpty(Name) ? ServiceName : Name,
                        EnableAutomaticUpdates = true,
                        ResetPasswordOnFirstLogon = false,
                        StoredCertificateSettings = CertUtilsNewSM.GetCertificateSettings(this.Certificates, this.X509Certificates),
                        WinRM = GetWinRmConfiguration(),
                        CustomData = customDataBase64Str
                    };

                    if (windowsConfig.StoredCertificateSettings == null)
                    {
                        windowsConfig.StoredCertificateSettings = new Model.CertificateSettingList();
                    }

                    configurationSets.Add(windowsConfig);
                }

                netConfig.InputEndpoints.Add(new InputEndpoint {LocalPort = 3389, Protocol = "tcp", Name = "RemoteDesktop"});
                if (!this.NoWinRMEndpoint.IsPresent && !this.DisableWinRMHttps.IsPresent)
                {
                    netConfig.InputEndpoints.Add(new InputEndpoint {LocalPort = WinRMConstants.HttpsListenerPort, Protocol = "tcp", Name = WinRMConstants.EndpointName});
                }

                configurationSets.Add(netConfig);
            }
            else if (ParameterSetName.Equals(LinuxParamSet, StringComparison.OrdinalIgnoreCase))
            {
                if (this.LinuxUser != null && this.Password != null)
                {
                    var linuxConfig = new Microsoft.WindowsAzure.Commands.ServiceManagement.Model.LinuxProvisioningConfigurationSet
                    {
                        HostName = string.IsNullOrEmpty(this.Name) ? this.ServiceName : this.Name,
                        UserName = this.LinuxUser,
                        UserPassword = SecureStringHelper.GetSecureString(this.Password),
                        DisableSshPasswordAuthentication = false,
                        CustomData = customDataBase64Str
                    };

                    if (this.SSHKeyPairs != null && this.SSHKeyPairs.Count > 0 ||
                        this.SSHPublicKeys != null && this.SSHPublicKeys.Count > 0)
                    {
                        linuxConfig.SSH = new Microsoft.WindowsAzure.Commands.ServiceManagement.Model.LinuxProvisioningConfigurationSet.SSHSettings
                        {
                            PublicKeys = this.SSHPublicKeys,
                            KeyPairs = this.SSHKeyPairs
                        };
                    }

                    configurationSets.Add(linuxConfig);
                }

                var rdpEndpoint = new InputEndpoint {LocalPort = 22, Protocol = "tcp", Name = "SSH"};
                netConfig.InputEndpoints.Add(rdpEndpoint);
                configurationSets.Add(netConfig);
            }

            PersistentVMHelper.MapConfigurationSets(configurationSets).ForEach(c => vm.ConfigurationSets.Add(c));

            return vm;
        }

        private Model.NetworkConfigurationSet CreateNetworkConfigurationSet()
        {
            var netConfig = new Model.NetworkConfigurationSet
            {
                InputEndpoints = new Collection<InputEndpoint>()
            };

            if (SubnetNames != null)
            {
                netConfig.SubnetNames = new Model.SubnetNamesCollection();
                foreach (var subnet in SubnetNames)
                {
                    netConfig.SubnetNames.Add(subnet);
                }
            }

            return netConfig;
        }

        private Model.WindowsProvisioningConfigurationSet.WinRmConfiguration GetWinRmConfiguration()
        {
            if(this.DisableWinRMHttps.IsPresent)
            {
                return null;
            }

            var builder = new WinRmConfigurationBuilder();
            if(this.EnableWinRMHttp.IsPresent)
            {
                builder.AddHttpListener();
            }

            builder.AddHttpsListener(WinRMCertificate);
            return builder.Configuration;
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!string.IsNullOrEmpty(this.ImageName))
            {
                var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(this.ImageName);
                _isOSImage = imageType.HasFlag(VirtualMachineImageType.OSImage);
                _isVMImage = imageType.HasFlag(VirtualMachineImageType.VMImage);

                if (_isOSImage && _isVMImage)
                {
                    var errorMsg = string.Format(Resources.DuplicateNamesFoundInBothVMAndOSImages, this.ImageName);
                    WriteError(new ErrorRecord(new Exception(errorMsg), string.Empty, ErrorCategory.CloseError, null));
                }
            }

            try
            {
                ServiceManagementProfile.Initialize();
                this.ValidateParameters();
                this.NewAzureVMProcess();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected bool DoesCloudServiceExist(string serviceName)
        {
            try
            {
                WriteVerboseWithTimestamp(string.Format(Resources.QuickVMBeginOperation, CommandRuntime));
                var response = this.ComputeClient.HostedServices.CheckNameAvailability(serviceName);
                WriteVerboseWithTimestamp(string.Format(Resources.QuickVMCompletedOperation, CommandRuntime));
                return !response.IsAvailable;
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                WriteExceptionError(ex);
            }

            return false;
        }

        protected void ValidateParameters()
        {
            if (this.DnsSettings != null && string.IsNullOrEmpty(this.VNetName))
            {
                throw new ArgumentException(Resources.VNetNameRequiredWhenSpecifyingDNSSettings);
            }

            if (!string.IsNullOrEmpty(this.VNetName) && (this.SubnetNames == null || this.SubnetNames.Length == 0))
            {
                WriteWarning(Resources.SubnetShouldBeSpecifiedIfVnetPresent);
            }

            if (this.ParameterSetName.Contains(LinuxParamSet) && this.Password != null && !ValidationHelpers.IsLinuxPasswordValid(this.Password))
            {
                throw new ArgumentException(Resources.PasswordNotComplexEnough);
            }

            if (this.ParameterSetName.Contains(WindowsParamSet) && this.Password != null && !ValidationHelpers.IsWindowsPasswordValid(this.Password))
            {
                throw new ArgumentException(Resources.PasswordNotComplexEnough);
            }

            if (this.ParameterSetName.Contains(LinuxParamSet))
            {
                bool valid = false;
                if (string.IsNullOrEmpty(this.Name))
                {
                    valid = ValidationHelpers.IsLinuxHostNameValid(this.ServiceName); // uses servicename if name not specified
                }
                else
                {
                    valid = ValidationHelpers.IsLinuxHostNameValid(this.Name); 
                }
                if (valid == false)
                {
                    throw new ArgumentException(Resources.InvalidHostName);
                }
            }

            if (string.IsNullOrEmpty(this.Name) == false)
            {
                if (this.ParameterSetName.Contains(WindowsParamSet) && !ValidationHelpers.IsWindowsComputerNameValid(this.Name))
                {
                    throw new ArgumentException(Resources.InvalidComputerName);
                }
            }
            else
            {
                if (this.ParameterSetName.Contains(WindowsParamSet) && !ValidationHelpers.IsWindowsComputerNameValid(this.ServiceName))
                {
                    throw new ArgumentException(Resources.InvalidComputerName);
                }
            }

            if (!string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.AffinityGroup))
            {
                throw new ArgumentException(Resources.EitherLocationOrAffinityGroupBeSpecified);
            }
        }
    }
}
