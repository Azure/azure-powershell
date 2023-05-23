<!-- region Generated -->
# Az.AzureStackHCI
This directory contains the PowerShell module for the StackHci service.

---
## Status
[![Az.AzureStackHCI](https://img.shields.io/powershellgallery/v/Az.AzureStackHCI.svg?style=flat-square&label=Az.AzureStackHCI "Az.AzureStackHCI")](https://www.powershellgallery.com/packages/Az.AzureStackHCI/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.AzureStackHCI`, see [how-to.md](how-to.md).
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
#branch: f53edd7d36f4bc7886cd522b2aff751a42a57352
require:
  - $(this-folder)/../../readme.azure.noprofile.md
repo: azure-rest-api-specs-pr
# lock the commit
input-file:
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/common.json
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/galleryImages.json 
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/marketplaceGalleryImages.json
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/networkInterfaces.json
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/operations.json
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/storageContainers.json
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/virtualHardDisks.json
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/virtualMachines.json
  - /mnt/e/azure-rest-api-specs-pr/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2022-12-15-preview/virtualNetworks.json

module-version: 1.1.0
title: AzureStackHCI
service-name: AzureStackHCI
subject-prefix: $(service-name)

inlining-threshold: 50
resourcegroup-append: true

directive:  
 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/virtualHardDisks/{virtualHardDiskName}"].delete.responses
    transform: >-
      return {
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "../../../../../common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            }
          },
          "200": {
            "description": "OK"
          },
          "202": {
            "description": "Accepted"
          },
          "204": {
            "description": "No content"
          }
      }
 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/virtualHardDisks/{virtualHardDiskName}"].delete
    transform: >- 
      $["x-ms-long-running-operation"] = true
   
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
    set:
      parameter-name: Tags
 -  where:
      verb: New
      subject: VirtualHardDisk
    hide: true
 -  where:
      verb: New
      subject: VirtualMachine
    hide: true
 -  where:
      verb: New
      subject: NetworkInterface
    hide: true
 -  where:
      verb: New
      subject: VirtualNetwork
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
      parameter-name: ContainerId
    set:
      parameter-name: StoragePathId
 -  where:
      verb: New
      subject: VirtualNetwork
      parameter-name: DhcpOptionDnsServer
    set:
      parameter-name: DnsServers
 -  where:
      model-name: VirtualNetworkPropertiesSubnetsItem
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
      subject: VirtualMachine
      parameter-name: DynamicMemoryConfigMaximumMemoryMb
    set:
      parameter-name: DynamicMemoryMaximumMemory
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: DynamicMemoryConfigMinimumMemoryMb
    set:
      parameter-name: DynamicMemoryMinimumMemory
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: DynamicMemoryConfigTargetMemoryBuffer
    set:
      parameter-name: DynamicMemoryTargetBuffer
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: HardwareProfileProcessor
    set:
      parameter-name: VmProcessors
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: HardwareProfileMemoryMb
    set:
      parameter-name: VmMemory
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: HardwareProfileVMSize
    set:
      parameter-name: VmSize
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: ImageReferenceId
    set:
      parameter-name: ImageId
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: OSProfileAdminPassword
    set:
      parameter-name: AdminPassword
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: OSProfileAdminUsername
    set:
      parameter-name: AdminUsername
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: OSProfileComputerName
    set:
      parameter-name: ComputerName
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: OSProfileOsType
    set:
      parameter-name: OsType
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: OSProfileAdminPassword
    set:
      parameter-name: AdminPassword
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: OSProfileAdminUsername
    set:
      parameter-name: AdminUsername
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: LinuxConfigurationDisablePasswordAuthentication
    set:
      parameter-name: DisablePasswordAuthentication
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: WindowConfigurationEnableAutomaticUpdate
    set:
      parameter-name: EnableAutomaticUpdate
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: WindowConfigurationTimeZone
    set:
      parameter-name: TimeZone
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: SecurityProfileEnableTpm
    set:
      parameter-name: EnableTpm
 -  where:
      verb: New
      subject: VirtualMachine
      parameter-name: UefiSettingSecureBootEnabled
    set:
      parameter-name: SecureBootEnabled
 -  where:
      verb: New
      subject: VirtualMachine
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
    

```
