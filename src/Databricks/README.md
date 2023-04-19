<!-- region Generated -->
# Az.Databricks
This directory contains the PowerShell module for the Databricks service.

---
## Status
[![Az.Databricks](https://img.shields.io/powershellgallery/v/Az.Databricks.svg?style=flat-square&label=Az.Databricks "Az.Databricks")](https://www.powershellgallery.com/packages/Az.Databricks/)

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
For information on how to develop for `Az.Databricks`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
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

``` yaml
branch: 96c583e9d5d09c51fe8a21843180c51b98b4a7db
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/databricks/resource-manager/readme.md
try-require:
  - $(repo)/specification/databricks/resource-manager/readme.powershell.md

module-version: 1.1.0
title: Databricks
subject-prefix: $(service-name)

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

directive:
  # Remove cmdlet, Private link related resource should be ignored. 
  - where:
     subject: PrivateEndpointConnection|PrivateLinkResource
    remove: true
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Hide CreateViaIdentity for customization
  - where:
      variant: ^CreateViaIdentity$
    hide: true
  # Rename the parameter name to follow Azure PowerShell best practice
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku
  - where:
      parameter-name: CustomVirtualNetworkIdValue
    set:
      parameter-name: VirtualNetworkId
  - where:
      parameter-name: CustomPublicSubnetNameValue
    set:
      parameter-name: PublicSubnetName
  - where:
      parameter-name: CustomPrivateSubnetNameValue
    set:
      parameter-name: PrivateSubnetName
  - where:
      parameter-name: PrepareEncryptionValue
    set:
      parameter-name: PrepareEncryption
  - where:
      parameter-name: ValueKeySource
    set:
      parameter-name: EncryptionKeySource
  - where:
      parameter-name: ValueKeyName
    set:
      parameter-name: EncryptionKeyName
  - where:
      parameter-name: ValueKeyVersion
    set:
      parameter-name: EncryptionKeyVersion
  - where:
      parameter-name: ValueKeyVaultUri
    set:
      parameter-name: EncryptionKeyVaultUri
  - where:
      parameter-name: RequireInfrastructureEncryptionValue
    set:
      parameter-name: RequireInfrastructureEncryption
  - where:
      parameter-name: PeeringName
    set:
      parameter-name: Name
  - where:
      parameter-name: AmlWorkspaceIdValue
    set:
      parameter-name: AmlWorkspaceId

  - where:
      parameter-name: EnableNoPublicIPValue
    set:
      parameter-name: EnableNoPublicIP
  - where:
      parameter-name: PublicIPNameValue
    set:
      parameter-name: PublicIPName

  - where:
      parameter-name: KeyVaultPropertyKeyName
    set:
      parameter-name: KeyVaultKeyName
  - where:
      parameter-name: KeyVaultPropertyKeyVaultUri
    set:
      parameter-name: KeyVaultUri
  - where:
      parameter-name: KeyVaultPropertyKeyVersion
    set:
      parameter-name: KeyVaultKeyVersion

  - where:
      parameter-name: LoadBalancerBackendPoolNameValue
    set:
      parameter-name: LoadBalancerBackendPoolName
  - where:
      parameter-name: LoadBalancerIdValue
    set:
      parameter-name: LoadBalancerId

  - where:
      parameter-name: NatGatewayNameValue
    set:
      parameter-name: NatGatewayName

  - where:
      parameter-name: StorageAccountNameValue
    set:
      parameter-name: StorageAccountName

  - where:
      parameter-name: StorageAccountSkuNameValue
    set:
      parameter-name: StorageAccountSku

  - where:
      parameter-name: VnetAddressPrefixValue
    set:
      parameter-name: VnetAddressPrefix

  # Rename parameters of Set VNetPeering cmdlet
  - where:
      verb: New
      subject: VNetPeering
      parameter-name: DatabrickAddressSpaceAddressPrefix
    set:
      parameter-name: DatabricksAddressSpacePrefix
  - where:
      verb: New
      subject: VNetPeering
      parameter-name: RemoteAddressSpaceAddressPrefix
    set:
      parameter-name: RemoteAddressSpacePrefix
  - where:
      verb: New
      subject: VNetPeering
      parameter-name: DatabrickVirtualNetworkId 
    set:
      parameter-name: DatabricksVirtualNetworkId
  - where:
      subject: AccessConnector
      parameter-name: ConnectorName 
    set:
      parameter-name: Name  
  # Remove the set Workspace cmdlet
  - where:
      verb: Set
      subject: Workspace
    remove: true

  # Remove the set AccessConnector cmdlet
  - where:
      verb: Set
      subject: AccessConnector
    remove: true

  # Hide the New Workspace cmdlet for customization
  - where:
      verb: New
      subject: Workspace
    hide: true
  # Hide the Update Workspace cmdlet for customization
  - where:
      verb: Update
      subject: Workspace
    hide: true
  # Hide the Set VNetPeering cmdlet for customization
  - where:
      verb: Set
      subject: VNetPeering
    hide: true
  - where:
      model-name: Workspace
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - ManagedResourceGroupId
        labels:
          ManagedResourceGroupId: Managed Resource Group ID
  - where:
      verb: New
      subject: AccessConnector
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
      
  # Update property names related to CMK
  - where:
      model-name: Workspace
      property-name: ValueKeyName
    set:
      property-name: EncryptionKeyName
  - where:
      model-name: Workspace
      property-name: ValueKeySource
    set:
      property-name: EncryptionKeySource
  - where:
      model-name: Workspace
      property-name: ValueKeyVaultUri
    set:
      property-name: EncryptionKeyVaultUri
  - where:
      model-name: Workspace
      property-name: ValueKeyVersion
    set:
      property-name: EncryptionKeyVersion
  - where:
      model-name: Workspace
      property-name: PrepareEncryptionValue
    set:
      property-name: PrepareEncryption
  - where:
      model-name: Workspace
      property-name: RequireInfrastructureEncryptionValue
    set:
      property-name: RequireInfrastructureEncryption
  - where:
      model-name: Workspace
      property-name: EnableNoPublicIPValue
    set:
      property-name: EnableNoPublicIP
```
