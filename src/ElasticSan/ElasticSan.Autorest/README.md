<!-- region Generated -->
# Az.ElasticSan
This directory contains the PowerShell module for the ElasticSan service.

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
For information on how to develop for `Az.ElasticSan`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: 72c69a0cf561d41ae99fe6810c426a874d3a8372
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/elasticsan/resource-manager/Microsoft.ElasticSan/stable/2024-05-01/elasticsan.json

# Normally, title is the service name
title: ElasticSan
# For new RP, the version is 0.1.0
module-version: 0.3.0
subject-prefix: $(service-name)
disable-transform-identity-type: true
flatten-userassignedidentity: false

enable-parent-pipeline-input: true

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  - where:
      variant: ^(Create|Update)(?!.*?Expanded)
    remove: true
  - model-cmdlet:
      - model-name: VirtualNetworkRule
        cmdlet-name: New-AzElasticSanVirtualNetworkRuleObject
  - where:
      model-name: ElasticSan|Volume|VolumeGroup|Snapshot
    set:
      suppress-format: true
  # Set alias for Name paramaters
  - where:
      subject: ElasticSan
      parameter-name: Name
    set:
      alias: ElasticSanName
  - where:
      subject: VolumeGroup
      parameter-name: Name
    set:
      alias: VolumeGroupName
  - where:
      subject: Volume
      parameter-name: Name
    set:
      alias: VolumeName
  - where:
      parameter-name: ^XmsDeleteSnapshot$
    set:
      parameter-name: DeleteSnapshot
  - where:
      parameter-name: ^XmsForceDelete$
    set:
      parameter-name: ForceDelete
  - where:
      parameter-name: SnapshotName
    set:
      parameter-name: Name
  - where:
      property-name: TotalIop
    set:
      property-name: TotalIops
  - where:
      verb: Get
      subject: Sku
    set:
      subject: SkuList
  - where:
      subject: Volume
      parameter-name: GroupName
    clear-alias: true
  - where:
      subject: Volume
      parameter-name: GroupName
    set:
      parameter-name: VolumeGroupName
  - where:
      subject: VolumeSnapshot
      verb: Update
    remove: true
  - where:
      parameter-name: EncryptionIdentityEncryptionUserAssignedIdentity
    set:
      parameter-name: EncryptionUserAssignedIdentity
  - where:
      parameter-name: KeyVaultPropertyKeyName
    set:
      parameter-name: KeyName
  - where:
      parameter-name: KeyVaultPropertyKeyVaultUri
    set:
      parameter-name: KeyVaultUri
  - where:
      parameter-name: KeyVaultPropertyKeyVersion
    set:
      parameter-name: KeyVersion
  # Change the description of cmdlets that correspond to multiple APIs
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}"].get
    transform: $["description"] = "Get either a list of Elastic SANs from a subscription or a resource group, or get a single Elastic SAN."
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}"].get
    transform: $["description"] = "Get either a list of all volume groups from an Elastic SAN or get a single volume group from an Elastic SAN."
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}"].get
    transform: $["description"] = "Get either a list of all volumes from a volume group or get a single volume from a volume group."
  - where:
      subject: ^PrivateEndpointConnection$|^PrivateLinkResource$
    hide: true
  - where:
      verb: ^New$|^Update$
      subject: ^VolumeGroup$
    hide: true
  - where:
      verb: ^New$|^Update$
      subject: Volume
      parameter-name: ManagedByResourceId
    hide: true
  - from: IdentityUserAssignedIdentities.dictionary.cs
    where: $
    transform: $ = $.replace('null != property.Key && null != property.Value', 'null != property.Key');
```
