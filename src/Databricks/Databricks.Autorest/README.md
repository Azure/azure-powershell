<!-- region Generated -->
# Az.Databricks
This directory contains the PowerShell module for the Databricks service.

---
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
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 8dc708fdac9cb97b346ddb38106ac16e668f64cd
tag: package-2024-05-01
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/databricks/resource-manager/readme.md
try-require:
  - $(repo)/specification/databricks/resource-manager/readme.powershell.md

module-version: 1.2.0
title: Databricks
subject-prefix: $(service-name)

inlining-threshold: 100

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.definitions.EncryptionV2
    transform: delete $.required

  - from: swagger-document
    where: $.definitions.ManagedDiskEncryption
    transform: delete $.required

# Worked around this issue: https://github.com/Azure/autorest.powershell/issues/1258
  - from: EncryptionEntitiesDefinition.json.cs
    where: $
    transform: $ = $.replace('ManagedService;', '_managedService;')

  - from: EncryptionEntitiesDefinition.json.cs
    where: $
    transform: $ = $.replace('ManagedDisk;', '_managedDisk;')

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

  # Rename parameters of VNetPeering cmdlet
  - where:
      parameter-name: DatabrickAddressSpaceAddressPrefix
    set:
      parameter-name: DatabricksAddressSpacePrefix
  - where:
      parameter-name: RemoteAddressSpaceAddressPrefix
    set:
      parameter-name: RemoteAddressSpacePrefix
  - where:
      parameter-name: DatabrickVirtualNetworkId
    set:
      parameter-name: DatabricksVirtualNetworkId

  - where:
      subject: AccessConnector
      parameter-name: ConnectorName
    set:
      parameter-name: Name
  - where:
      verb: New
      subject: AccessConnector
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity

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

  # Hide the New/Update Workspace cmdlet for customization
  - where:
      verb: New|Update
      subject: Workspace
    hide: true
  # Hide the Set VNetPeering cmdlet for customization
  - where:
      verb: Set
      subject: VNetPeering
    hide: true
    set: 
      verb: Update

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
```
