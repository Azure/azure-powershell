<!-- region Generated -->
# Az.StackHCIVm
This directory contains the PowerShell module for the StackHciVM service.

---
## Status
[![Az.StackHCIVm](https://img.shields.io/powershellgallery/v/Az.StackHCIVm.svg?style=flat-square&label=Az.StackHCIVm "Az.StackHCIVm")](https://www.powershellgallery.com/packages/Az.StackHCIVm/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.StackHCIVm`, see [how-to.md](how-to.md).
<!-- endregion -->

---

## Generation Requirements

Use of the beta version of `autorest.powershell` generator requires the following:

- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It _will not work_ with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
    > If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation

In this directory, run AutoRest:

> `autorest-beta`

---

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
require:
  - E:/testing/readme.azure.noprofile.md
repo: azure-rest-api-specs-pr
# lock the commit
input-file:
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/common.json
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/galleryImages.json 
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/marketplaceGalleryImages.json
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/networkInterfaces.json
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/storageContainers.json
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/virtualHardDisks.json
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/virtualMachineInstances.json
  - E:/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/logicalNetworks.json
  - E:/azure-rest-api-specs-pr/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/preview/2023-03-15-preview/HybridCompute.json

module-version: 1.1.0
title: StackHCIVm
service-name: StackHCIVm
subject-prefix: $(service-name)

inlining-threshold: 50
resourcegroup-append: true
directive:  
  # Remove the unexpanded parameter set
 -  where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
 -  where:
      verb: New
      parameter-name: ExtendedLocationName
    set:
      parameter-name: CustomLocationId
 -  where:
      verb: New
      parameter-name: ExtendedLocationType
    hide: true
    set:
      default:
        script: '"CustomLocation"'
 -  where:
      parameter-name: SubscriptionId
    set:
      default:
        name: SubscriptionId Default
        description: Gets the SubscriptionId from the current context.
        script: '(Get-AzContext).Subscription.Id'
 -  where:
      verb: New
      parameter-name: IdentifierOffer
    set:
      parameter-name: Offer
 -  where:
      verb: New
      parameter-name: IdentifierPublisher
    set:
      parameter-name: Publisher
 -  where:
      verb: New
      parameter-name: IdentifierSku
    set:
      parameter-name: Sku
 -  where:
      verb: New
      parameter-name: VersionName
    set:
      parameter-name: Version
 -  where:
      verb: New
      parameter-name: Tag
    set:
      parameter-name: Tags
 -  where:
      verb: Update
      parameter-name: Tag
 -  where:
      verb: New
      subject: GalleryImage
    hide: true
 -  where:
      verb: New
      subject: MarketplaceGalleryImage
    hide: true
 -  where:
      verb: Get
      subject: GalleryImage
    hide: true
 -  where:
      verb: Get
      subject: MarketplaceGalleryImage
    hide: true
 -  where:
      verb: Remove
      subject: GalleryImage
    hide: true
 -  where:
      verb: Remove
      subject: MarketplaceGalleryImage
    hide: true
 -  where:
      verb: Update
      subject: GalleryImage
    hide: true
 -  where:
      verb: Update
      subject: MarketplaceGalleryImage
    hide: true
 -  where:
      verb: New
      subject: VirtualHardDisk
    hide: true
 -  where:
      verb: New
      subject: NetworkInterface
    hide: true
 -  where:
      verb: New
      subject: LogicalNetwork
    hide: true
 -  where:
      verb: New
      subject: VirtualHardDisk
      parameter-name: DiskSizeGb
    set:
      parameter-name: SizeGb
 -  where:
      verb: New
      subject: VirtualHardDisk
      parameter-name: BlockSizeByte
    set:
      parameter-name: BlockSizeBytes
 -  where:
      verb: New
      subject: VirtualHardDisk
      parameter-name: LogicalSectorByte
    set:
      parameter-name: LogicalSectorBytes
 -  where:
      verb: New
      subject: VirtualHardDisk
      parameter-name: PhysicalSectorByte
    set:
      parameter-name: PhysicalSectorBytes
 -  where:
      verb: New
      subject: VirtualHardDisk
      parameter-name: ContainerId
    set:
      parameter-name: StoragePathId
 -  where:
      verb: New
      subject: LogicalNetwork
      parameter-name: DhcpOptionDnsServer
    set:
      parameter-name: DnsServers
 -  where:
      model-name: LogicalNetworkPropertiesSubnetsItem
      property-name: PropertiesAddressPrefixes  
    set:
      property-name: AddressPrefixes 
 -  where:
      verb: New
      subject: NetworkInterface
      parameter-name: DnsSettingDnsServer
    set:
      parameter-name: DnsServers
 -  where:
      model-name: IPConfiguration
      property-name: PrivateIPAddress
    set:
      property-name: IPAddress 
 -  where:
      model-name: IPConfiguration
      property-name: PrivateIPAllocationMethod
    set:
      property-name: IPAllocationMethod
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: DynamicMemoryConfigMaximumMemoryMb
    set:
      parameter-name: DynamicMemoryMaximumMemory
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: DynamicMemoryConfigMinimumMemoryMb
    set:
      parameter-name: DynamicMemoryMinimumMemory
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: DynamicMemoryConfigTargetMemoryBuffer
    set:
      parameter-name: DynamicMemoryTargetBuffer
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: HardwareProfileProcessor
    set:
      parameter-name: VmProcessors
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: HardwareProfileMemoryMb
    set:
      parameter-name: VmMemory
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: HardwareProfileVMSize
    set:
      parameter-name: VmSize
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: ImageReferenceId
    set:
      parameter-name: ImageId
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: OSProfileAdminPassword
    set:
      parameter-name: AdminPassword
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: OSProfileAdminUsername
    set:
      parameter-name: AdminUsername
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: OSProfileComputerName
    set:
      parameter-name: ComputerName
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: OSProfileOsType
    set:
      parameter-name: OsType
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: OSProfileAdminPassword
    set:
      parameter-name: AdminPassword
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: OSProfileAdminUsername
    set:
      parameter-name: AdminUsername
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: LinuxConfigurationDisablePasswordAuthentication
    set:
      parameter-name: DisablePasswordAuthentication
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: WindowConfigurationEnableAutomaticUpdate
    set:
      parameter-name: EnableAutomaticUpdate
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: WindowConfigurationTimeZone
    set:
      parameter-name: TimeZone
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: SecurityProfileEnableTpm
    set:
      parameter-name: EnableTpm
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: UefiSettingSecureBootEnabled
    set:
      parameter-name: SecureBootEnabled
 -  where:
      verb: New
      subject: VirtualMachineInstance
      parameter-name: StorageProfileVMConfigStoragePathId
    set:
      parameter-name: StoragePathId
 -  where:
      verb: New
      subject: StorageContainer
    set:
      subject: StoragePath
    hide: true
 -  where:
      verb: Get
      subject: StorageContainer
    set:
      subject: StoragePath
 -  where:
      verb: Remove
      subject: StorageContainer
    set:
      subject: StoragePath
 -  where:
      verb: Update
      subject: StorageContainer
    set:
      subject: StoragePath
 -  where:
      verb: Remove
      subject: VirtualHardDisk
    hide: true
 -  where:
      verb: Remove
      subject: VirtualMachineInstance
    set:
      subject: VirtualMachine
    hide: true
 -  where:
      verb: Start
      subject: VirtualMachineInstance
    set:
      subject: VirtualMachine
    hide: true
 -  where:
      verb: Stop
      subject: VirtualMachineInstance
    set:
      subject: VirtualMachine
    hide: true
 -  where:
      verb: Restart
      subject: VirtualMachineInstance
    set:
      subject: VirtualMachine
    hide: true
 -  where:
      verb: Get
      subject: VirtualMachineInstance
    set:
      subject: VirtualMachine
    hide: true
 -  where:
      verb: New
      subject: VirtualMachineInstance
    set:
      subject: VirtualMachine
    hide: true
 -  where:
      verb: Update
      subject: VirtualMachineInstance
    set:
      subject: VirtualMachine
    hide: true
 -  where:
      verb: Remove
      subject: NetworkInterface
    hide: true
 -  where:
      verb: Remove
      subject: LogicalNetwork
    hide: true
 -  where:
      verb: New
      subject: LogicalNetwork
    hide: true
 -  where:
      verb: Remove
      subject: StoragePath
    hide: true
 -  where:
      model-name: LogicalNetwork
      property-name: Subnet
    set:
      property-name: Subnets
 -  where:
      subject: AgentVersion
    hide: true
 -  where:
      subject: ExtensionMetadata
    hide: true
 -  where:
      subject: GuestAgent
    hide: true
 -  where:
      subject: HybridIdentityMetadata
    hide: true
 -  where:
      subject: MachineExtension
    hide: true
 -  where:
      subject: NetworkProfile
    hide: true

```
