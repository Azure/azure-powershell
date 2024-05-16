<!-- region Generated -->
# Az.StackHCIVM
This directory contains the PowerShell module for the StackHcivm service.

---
## Status
[![Az.StackHCIVM](https://img.shields.io/powershellgallery/v/Az.StackHCIVM.svg?style=flat-square&label=Az.StackHCIVM "Az.StackHCIVM")](https://www.powershellgallery.com/packages/Az.StackHCIVM/)

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
For information on how to develop for `Az.StackHCIVM`, see [how-to.md](how-to.md).
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
commit: 812f964651d5f1f7148b54ed2cc35cb97be12523
require:
  - $(this-folder)/../../readme.azure.noprofile.md
repo: azure-rest-api-specs

input-file:
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/common.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/galleryImages.json 
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/marketplaceGalleryImages.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/networkInterfaces.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/storageContainers.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/virtualHardDisks.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/virtualMachineInstances.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2024-01-01/logicalNetworks.json
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/preview/2023-03-15-preview/HybridCompute.json

module-version: 0.1.0
title: StackHCIVM
service-name: StackHCIVM
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

 -  from: swagger-document 
    where: $.paths["/{resourceUri}/providers/Microsoft.AzureStackHCI/virtualMachineInstances/default"].delete.responses
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
    where: $.paths["/{resourceUri}/providers/Microsoft.AzureStackHCI/virtualMachineInstances/default"].delete
    transform: >- 
      $["x-ms-long-running-operation"] = true

 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/logicalNetworks/{logicalNetworkName}"].get
    transform: >-
      $["description"] = "Gets a logical network"

 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/logicalNetworks/{logicalNetworkName}"].delete.responses
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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/logicalNetworks/{logicalNetworkName}"].delete
    transform: >- 
      $["x-ms-long-running-operation"] = true

 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/storageContainers/{storageContainerName}"].delete.responses
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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/storageContainers/{storageContainerName}"].delete
    transform: >- 
      $["x-ms-long-running-operation"] = true

 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/networkInterfaces/{networkInterfaceName}"].delete.responses
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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/networkInterfaces/{networkInterfaceName}"].delete
    transform: >- 
      $["x-ms-long-running-operation"] = true

 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/marketplaceGalleryImages/{marketplaceGalleryImageName}"].delete.responses
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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/marketplaceGalleryImages/{marketplaceGalleryImageName}"].delete
    transform: >- 
      $["x-ms-long-running-operation"] = true

 -  from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/galleryImages/{galleryImageName}"].delete.responses
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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/galleryImages/{galleryImageName}"].delete
    transform: >- 
      $["x-ms-long-running-operation"] = true
   
   
  # Remove the unexpanded parameter set
 -  where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^GetViaIdentity$
    remove: true
 -  where:
      parameter-name: DefaultProfile
    hide: true
 -  where:
      parameter-name: Break
    hide: true
 -  where:
      parameter-name: HttpPipelineAppend
    hide: true
 -  where:
      parameter-name: HttpPipelinePrepend
    hide: true
 -  where:
      parameter-name: Proxy
    hide: true
 -  where:
      parameter-name: ProxyCredential
    hide: true
 -  where:
      parameter-name: ProxyUseDefaultCredentials
    hide: true
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
      parameter-name: ContainerId
    set:
      parameter-name: StoragePathId
 -  where:
      verb: New
      subject: GalleryImage
      parameter-name: ContainerId
    set:
      parameter-name: StoragePathId
 -  where:
      verb: New
      subject: MarketplaceGalleryImage
      parameter-name: ContainerId
    set:
      parameter-name: StoragePathId
 -  where:
      verb: New
      subject: LogicalNetwork
      parameter-name: DhcpOptionDnsServer
    set:
      parameter-name: DnsServer
 -  where:
      model-name: Subnet
      property-name: PropertiesAddressPrefixes  
    set:
      property-name: AddressPrefixes 
 -  where:
      verb: New
      subject: NetworkInterface
      parameter-name: DnsSettingDnsServer
    set:
      parameter-name: DnsServer
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
      subject: VirtualMachineInstance
      parameter-name: DynamicMemoryConfigMaximumMemoryMb
    set:
      parameter-name: DynamicMemoryMaximumMemoryInMb
 -  where:
      subject: VirtualMachineInstance
      parameter-name: DynamicMemoryConfigMinimumMemoryMb
    set:
      parameter-name: DynamicMemoryMinimumMemoryInMb
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
      parameter-name: VmProcessor
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
 -  where:
      verb: Set
    hide: true
 -  where:
      subject: Machine
    hide: true
 -  where:
      subject: Extension
    hide: true
 -  where:
      subject-prefix: StackHciVM
    set:
      subject-prefix: StackHCIVM

```
