﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.Compute.Properties;
using Microsoft.Azure.Commands.Compute.StorageServices;
using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.Management.Storage.Version2017_10_01.Models;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Tools.Vhd;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CM = Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM",SupportsShouldProcess = true,DefaultParameterSetName = "SimpleParameterSet")]
    [OutputType(typeof(PSAzureOperationResponse), typeof(PSVirtualMachine))]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
    {
        public const string DefaultParameterSet = "DefaultParameterSet";
        public const string SimpleParameterSet = "SimpleParameterSet";
        public const string DiskFileParameterSet = "DiskFileParameterSet";

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter()]
        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false)]
        [LocationCompleter("Microsoft.Compute/virtualMachines")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("VMProfile")]
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string[] Zone { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Disable BG Info Extension")]
        public SwitchParameter DisableBginfoExtension { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string LicenseType { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string AddressPrefix { get; set; } = "192.168.0.0/16";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SubnetAddressPrefix { get; set; } = "192.168.1.0/24";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string PublicIpAddressName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string DomainNameLabel { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        [ValidateSet("Static", "Dynamic")]
        public string AllocationMethod { get; set; } = "Static";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [PSArgumentCompleter(
            "CentOS",
            "CoreOS",
            "Debian",
            "openSUSE-Leap",
            "RHEL",
            "SLES",
            "UbuntuLTS",
            "Win2016Datacenter",
            "Win2012R2Datacenter",
            "Win2012Datacenter",
            "Win2008R2SP1",
            "Win10")]
        [Alias("ImageName")]
        public string Image { get; set; } = "Win2016Datacenter";

        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DiskFile { get; set; }

        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public SwitchParameter Linux { get; set; } = false;

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string Size { get; set; } = "Standard_DS1_v2";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string AvailabilitySetName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add the assign user specified identity (MSI) to the VM")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false, HelpMessage = "Use this to add the assign user specified identity (MSI) to the VM")]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] DataDiskSizeInGb { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case SimpleParameterSet:
                    this.StartAndWait(StrategyExecuteCmdletAsync);
                    break;
                case DiskFileParameterSet:
                    this.StartAndWait(StrategyExecuteCmdletAsync);
                    break;
                default:
                    DefaultExecuteCmdlet();
                    break;
            }
        }

        class Parameters : IParameters<VirtualMachine>
        {
            NewAzureVMCommand _cmdlet { get; }

            Client _client { get; }

            public Parameters(NewAzureVMCommand cmdlet, Client client)
            {
                _cmdlet = cmdlet;
                _client = client;
            }

            public ImageAndOsType ImageAndOsType { get; set; }

            public string Location
            {
                get { return _cmdlet.Location; }
                set { _cmdlet.Location = value; }
            }

            public string DefaultLocation => "eastus";

            public BlobUri DestinationUri;

            public async Task<ResourceConfig<VirtualMachine>> CreateConfigAsync()
            {
                if (_cmdlet.DiskFile == null)
                {
                    ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                        ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.Image, Location);
                }

                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.Name,
                    location: Location,
                    client: _client);

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName, addressPrefix: _cmdlet.AddressPrefix);
                var subnet = virtualNetwork.CreateSubnet(_cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);
                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    sku: PublicIPAddressStrategy.Sku.Basic,
                    zones: _cmdlet.Zone);

                _cmdlet.OpenPorts = ImageAndOsType.UpdatePorts(_cmdlet.OpenPorts);

                var networkSecurityGroup = resourceGroup.CreateNetworkSecurityGroupConfig(
                    name: _cmdlet.SecurityGroupName,
                    openPorts: _cmdlet.OpenPorts);

                bool enableAcceleratedNetwork = Utils.DoesConfigSupportAcceleratedNetwork(_client,
                    ImageAndOsType, _cmdlet.Size, Location, DefaultLocation);

                var networkInterface = resourceGroup.CreateNetworkInterfaceConfig(
                    _cmdlet.Name, subnet, publicIpAddress, networkSecurityGroup, enableAcceleratedNetwork);

                var availabilitySet = _cmdlet.AvailabilitySetName == null
                    ? null
                    : resourceGroup.CreateAvailabilitySetConfig(name: _cmdlet.AvailabilitySetName);

                if (_cmdlet.DiskFile == null)
                {
                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        imageAndOsType: ImageAndOsType,
                        adminUsername: _cmdlet.Credential.UserName,
                        adminPassword:
                            new NetworkCredential(string.Empty, _cmdlet.Credential.Password).Password,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        identity: _cmdlet.GetVMIdentityFromArgs());
                }
                else
                {
                    var disk = resourceGroup.CreateManagedDiskConfig(
                        name: _cmdlet.Name,
                        sourceUri: DestinationUri.Uri.ToString());

                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        osType: ImageAndOsType.OsType,
                        disk: disk,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        identity: _cmdlet.GetVMIdentityFromArgs());
                }
            }
        }

        async Task StrategyExecuteCmdletAsync(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(DefaultProfile.DefaultContext);

            ResourceGroupName = ResourceGroupName ?? Name;
            VirtualNetworkName = VirtualNetworkName ?? Name;
            SubnetName = SubnetName ?? Name;
            PublicIpAddressName = PublicIpAddressName ?? Name;
            SecurityGroupName = SecurityGroupName ?? Name;

            var parameters = new Parameters(this, client);


            if (DiskFile != null)
            {
                var resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);
                if (!resourceClient.ResourceGroups.CheckExistence(ResourceGroupName))
                {
                    Location = Location ?? parameters.DefaultLocation;
                    var st0 = resourceClient.ResourceGroups.CreateOrUpdate(
                        ResourceGroupName,
                        new ResourceGroup
                        {
                            Location = Location,
                            Name = ResourceGroupName
                        });
                }
                parameters.ImageAndOsType = new ImageAndOsType(
                    Linux ? OperatingSystemTypes.Linux : OperatingSystemTypes.Windows,
                    null,
                    null);
                var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);
                var st1 = storageClient.StorageAccounts.Create(
                    ResourceGroupName,
                    Name,
                    new StorageAccountCreateParameters
                {
                    Sku = new Microsoft.Azure.Management.Storage.Version2017_10_01.Models.Sku
                    {
                        Name = SkuName.PremiumLRS
                    },
                    Location = Location
                });
                var filePath = new FileInfo(SessionState.Path.GetUnresolvedProviderPathFromPSPath(DiskFile));
                using (var vds = new VirtualDiskStream(filePath.FullName))
                {
                    // 2 ^ 9 == 512
                    if (vds.DiskType == DiskType.Fixed && filePath.Length % 512 != 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "filePath",
                            string.Format("Given vhd file '{0}' is a corrupted fixed vhd", filePath));
                    }
                }
                var storageAccount = storageClient.StorageAccounts.GetProperties(ResourceGroupName, Name);
                // BlobUri destinationUri = null;
                BlobUri.TryParseUri(
                    new Uri(string.Format(
                        "{0}{1}/{2}{3}",
                        storageAccount.PrimaryEndpoints.Blob,
                        ResourceGroupName.ToLower(),
                        Name.ToLower(),
                        ".vhd")),
                    out parameters.DestinationUri);
                if (parameters.DestinationUri?.Uri == null)
                {
                    throw new ArgumentNullException("destinationUri");
                }
                var storageCredentialsFactory = new StorageCredentialsFactory(
                    ResourceGroupName, storageClient, DefaultContext.Subscription);
                var uploadParameters = new UploadParameters(parameters.DestinationUri, null, filePath, true, 2)
                {
                    Cmdlet = this,
                    BlobObjectFactory = new CloudPageBlobObjectFactory(storageCredentialsFactory, TimeSpan.FromMinutes(1))
                };
                if (!string.Equals(
                    Environment.GetEnvironmentVariable("AZURE_TEST_MODE"), "Playback", StringComparison.OrdinalIgnoreCase))
                {
                    var st2 = VhdUploaderModel.Upload(uploadParameters);
                }
            }

            var result = await client.RunAsync(client.SubscriptionId, parameters, asyncCmdlet);

            if (result != null)
            {
                var fqdn = PublicIPAddressStrategy.Fqdn(DomainNameLabel, Location);
                var psResult = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachine>(result);
                psResult.FullyQualifiedDomainName = fqdn;
                var connectionString = parameters.ImageAndOsType.GetConnectionString(
                    fqdn,
                    Credential?.UserName);
                asyncCmdlet.WriteVerbose(
                    Resources.VirtualMachineUseConnectionString,
                    connectionString);
                asyncCmdlet.WriteObject(psResult);
            }
        }

        public void DefaultExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.VM.DiagnosticsProfile == null)
            {
                var storageUri = GetOrCreateStorageAccountForBootDiagnostics();

                if (storageUri != null)
                {
                    this.VM.DiagnosticsProfile = new DiagnosticsProfile
                    {
                        BootDiagnostics = new BootDiagnostics
                        {
                            Enabled = true,
                            StorageUri = storageUri.ToString(),
                        }
                    };
                }
            }


            if (ShouldProcess(this.VM.Name, VerbsCommon.New))
            {
                ExecuteClientAction(() =>
                {
                    var parameters = new VirtualMachine
                    {
                        DiagnosticsProfile = this.VM.DiagnosticsProfile,
                        HardwareProfile = this.VM.HardwareProfile,
                        StorageProfile = this.VM.StorageProfile,
                        NetworkProfile = this.VM.NetworkProfile,
                        OsProfile = this.VM.OSProfile,
                        Plan = this.VM.Plan,
                        LicenseType = this.LicenseType ?? this.VM.LicenseType,
                        AvailabilitySet = this.VM.AvailabilitySetReference,
                        Location = this.Location ?? this.VM.Location,
                        Tags = this.Tag != null ? this.Tag.ToDictionary() : this.VM.Tags,
                        Identity = ComputeAutoMapperProfile.Mapper.Map<VirtualMachineIdentity>(this.VM.Identity),
                        Zones = this.Zone ?? this.VM.Zones,
                    };

                    var result = this.VirtualMachineClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VM.Name,
                        parameters).GetAwaiter().GetResult();
                    var psResult = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(result);

                    if (!(this.DisableBginfoExtension.IsPresent || IsLinuxOs()))
                    {
                        var currentBginfoVersion = GetBginfoExtension();

                        if (!string.IsNullOrEmpty(currentBginfoVersion))
                        {
                            var extensionParameters = new VirtualMachineExtension
                            {
                                Location = this.Location,
                                Publisher = VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher,
                                VirtualMachineExtensionType = VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                                TypeHandlerVersion = currentBginfoVersion,
                                AutoUpgradeMinorVersion = true,
                            };

                            typeof(CM.Resource).GetRuntimeProperty("Name")
                                .SetValue(extensionParameters, VirtualMachineBGInfoExtensionContext.ExtensionDefaultName);
                            typeof(CM.Resource).GetRuntimeProperty("Type")
                                .SetValue(extensionParameters, VirtualMachineExtensionType);

                            var op2 = ComputeClient.ComputeManagementClient.VirtualMachineExtensions.CreateOrUpdateWithHttpMessagesAsync(
                                this.ResourceGroupName,
                                this.VM.Name,
                                VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                                extensionParameters).GetAwaiter().GetResult();
                            psResult = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op2);
                        }
                    }
                    WriteObject(psResult);
                });
            }
        }

        /// <summary>
        /// Heres whats happening here :
        /// If "SystemAssignedIdentity" and "UserAssignedIdentity" are both present we set the type of identity to be SystemAssignedUsrAssigned and set the user 
        /// defined identity in the VM identity object.
        /// If only "SystemAssignedIdentity" is present, we just set the type of the Identity to "SystemAssigned" and no identity ids are set as its created by Azure
        /// If only "UserAssignedIdentity" is present, we set the type of the Identity to be "UserAssigned" and set the Identity in the VM identity object.
        /// If neither is present, we return a null.
        /// </summary>
        /// <returns>Returning the Identity generated form the cmdlet parameters "SystemAssignedIdentity" and "UserAssignedIdentity"</returns>
        private VirtualMachineIdentity GetVMIdentityFromArgs()
        {
            var isUserAssignedEnabled = !string.IsNullOrWhiteSpace(UserAssignedIdentity);
            return (SystemAssignedIdentity.IsPresent || isUserAssignedEnabled)
                ? new VirtualMachineIdentity
                {
                    Type = !isUserAssignedEnabled ? 
                           CM.ResourceIdentityType.SystemAssigned :
                           (SystemAssignedIdentity.IsPresent ? CM.ResourceIdentityType.SystemAssignedUserAssigned : CM.ResourceIdentityType.UserAssigned),

                    UserAssignedIdentities = isUserAssignedEnabled 
                                             ? new Dictionary<string, VirtualMachineIdentityUserAssignedIdentitiesValue>()
                                             {
                                                 { UserAssignedIdentity, new VirtualMachineIdentityUserAssignedIdentitiesValue() }
                                             }
                                             : null,
                }
                : null;
        }

        private string GetBginfoExtension()
        {
            var canonicalizedLocation = this.Location.Canonicalize();

            var publishers =
                ComputeClient.ComputeManagementClient.VirtualMachineImages.ListPublishers(canonicalizedLocation);

            var publisher = publishers.FirstOrDefault(e => e.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher));

            if (publisher == null || !publisher.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher))
            {
                return null;
            }

            var virtualMachineImageClient = ComputeClient.ComputeManagementClient.VirtualMachineExtensionImages;


            var imageTypes =
                virtualMachineImageClient.ListTypes(canonicalizedLocation,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher);

            var extensionType = imageTypes.FirstOrDefault(
                e => e.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultName));

            if (extensionType == null || !extensionType.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultName))
            {
                return null;
            }

            var bginfoVersions =
                virtualMachineImageClient.ListVersions(canonicalizedLocation,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultName);

            if (bginfoVersions != null
                && bginfoVersions.Count > 0)
            {
                return bginfoVersions.Max(ver =>
                {
                    Version result;
                    return (Version.TryParse(ver.Name, out result))
                        ? string.Format("{0}.{1}", result.Major, result.Minor)
                        : VirtualMachineBGInfoExtensionContext.ExtensionDefaultVersion;
                });
            }

            return null;
        }

        private bool IsLinuxOs()
        {
            if (this.VM == null)
            {
                return false;
            }

            if ((this.VM.StorageProfile != null)
                && (this.VM.StorageProfile.OsDisk != null)
                && (this.VM.StorageProfile.OsDisk.OsType != null))
            {
                return (this.VM.StorageProfile.OsDisk.OsType.Equals(OperatingSystemTypes.Linux));
            }

            return ((this.VM.OSProfile != null)
                    && (this.VM.OSProfile.LinuxConfiguration != null));
        }

        private string GetOrCreateStorageAccountForBootDiagnostics()
        {
            var storageAccountName = GetStorageAccountNameFromStorageProfile();
            var storageClient =
                    AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.DefaultContext,
                        AzureEnvironment.Endpoint.ResourceManager);

            if (!string.IsNullOrEmpty(storageAccountName))
            {
                try
                {
                    var storageAccountList = storageClient.StorageAccounts.List();
                    if (storageAccountList != null)
                    {
                        var osDiskStorageAccount = storageAccountList.First(e => e.Name.Equals(storageAccountName));

                        if (osDiskStorageAccount != null
                            && osDiskStorageAccount.Sku() != null
                            && !osDiskStorageAccount.SkuName().ToLowerInvariant().Contains("premium"))
                        {
                            return osDiskStorageAccount.PrimaryEndpoints.Blob;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("ResourceNotFound"))
                    {
                        WriteWarning(string.Format(
                            Properties.Resources.StorageAccountNotFoundForBootDiagnostics, storageAccountName));
                    }
                    else
                    {
                        WriteWarning(string.Format(
                            Properties.Resources.ErrorDuringGettingStorageAccountForBootDiagnostics, storageAccountName, e.Message));
                    }
                }
            }

            var storageAccount = TryToChooseExistingStandardStorageAccount(storageClient);

            if (storageAccount == null)
            {
                return CreateStandardStorageAccount(storageClient);
            }

            WriteWarning(string.Format(Properties.Resources.UsingExistingStorageAccountForBootDiagnostics, storageAccount.Name));
            return storageAccount.PrimaryEndpoints.Blob;
        }

        private string GetStorageAccountNameFromStorageProfile()
        {
            if (this.VM == null
                || this.VM.StorageProfile == null
                || this.VM.StorageProfile.OsDisk == null
                || this.VM.StorageProfile.OsDisk.Vhd == null
                || this.VM.StorageProfile.OsDisk.Vhd.Uri == null)
            {
                return null;
            }

            return GetStorageAccountNameFromUriString(this.VM.StorageProfile.OsDisk.Vhd.Uri);
        }

        private StorageAccount TryToChooseExistingStandardStorageAccount(StorageManagementClient client)
        {
            var storageAccountList = client.StorageAccounts.ListByResourceGroup(this.ResourceGroupName);
            if (storageAccountList == null || storageAccountList.Count() == 0)
            {
                storageAccountList = client.StorageAccounts.List().Where(e => e.Location.Canonicalize().Equals(this.Location.Canonicalize()));
                if (storageAccountList == null || storageAccountList.Count() == 0)
                {
                    return null;
                }
            }

            try
            {
                return storageAccountList.First(
                    e => e.Location.Canonicalize().Equals(this.Location.Canonicalize())
                      && e.Sku() != null
                      && !e.SkuName().ToLowerInvariant().Contains("premium"));
            }
            catch (InvalidOperationException e)
            {
                WriteWarning(string.Format(
                            Properties.Resources.ErrorDuringChoosingStandardStorageAccount, e.Message));
                return null;
            }
        }

        private string CreateStandardStorageAccount(StorageManagementClient client)
        {
            string storageAccountName;

            var i = 0;
            do
            {
                storageAccountName = GetRandomStorageAccountName(i);
                i++;
            }
            while (i < 10 && (bool) !client.StorageAccounts.CheckNameAvailability(storageAccountName).NameAvailable);

            var storaeAccountParameter = new StorageAccountCreateParameters
            {
                Location = this.Location ?? this.VM.Location,
            };
            storaeAccountParameter.SetAsStandardGRS();

            try
            {
                client.StorageAccounts.Create(this.ResourceGroupName, storageAccountName, storaeAccountParameter);
                var getresponse = client.StorageAccounts.GetProperties(this.ResourceGroupName, storageAccountName);
                WriteWarning(string.Format(Properties.Resources.CreatingStorageAccountForBootDiagnostics, storageAccountName));

                return getresponse.PrimaryEndpoints.Blob;
            }
            catch (Exception e)
            {
                // Failed to create a storage account for boot diagnostics.
                WriteWarning(string.Format(Properties.Resources.ErrorDuringCreatingStorageAccountForBootDiagnostics, e));
                return null;
            }
        }

        private string GetRandomStorageAccountName(int interation)
        {
            const int maxSubLength = 5;
            const int maxResLength = 6;
            const int maxVMLength = 4;

            var subscriptionName = VirtualMachineCmdletHelper.GetTruncatedStr(this.DefaultContext.Subscription.Name, maxSubLength);
            var resourcename = VirtualMachineCmdletHelper.GetTruncatedStr(this.ResourceGroupName, maxResLength);
            var vmname = VirtualMachineCmdletHelper.GetTruncatedStr(this.VM.Name, maxVMLength);
            var datetimestr = DateTime.Now.ToString("MMddHHmm");

            var output = subscriptionName + resourcename + vmname + datetimestr + interation;

            output = new string((from c in output where char.IsLetterOrDigit(c) select c).ToArray());

            return output.ToLowerInvariant();
        }

        private static string GetStorageAccountNameFromUriString(string uriStr)
        {
            Uri uri;

            if (!Uri.TryCreate(uriStr, UriKind.RelativeOrAbsolute, out uri))
            {
                return null;
            }

            var storageUri = uri.Authority;
            var index = storageUri.IndexOf('.');
            return storageUri.Substring(0, index);
        }
    }
}
