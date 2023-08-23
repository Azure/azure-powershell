<!-- region Generated -->
# Az.EventHub
This directory contains the PowerShell module for the EventHub service.

---
## Status
[![Az.EventHub](https://img.shields.io/powershellgallery/v/Az.EventHub.svg?style=flat-square&label=Az.EventHub "Az.EventHub")](https://www.powershellgallery.com/packages/Az.EventHub/)

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
For information on how to develop for `Az.EventHub`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
branch: 00ff897270e1f60b5e8944b15fc35fc0f9af2598
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/AvailableClusterRegions-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/Clusters-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/namespaces-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/networkrulessets-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/AuthorizationRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/CheckNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/consumergroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/disasterRecoveryConfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/SchemaRegistry.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/eventhubs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2022-10-01-preview/ApplicationGroups.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: EventHub
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      variant: ^CreateViaIdentity$
    hide: true
  - where:
      variant: ^RegenerateExpanded$|^RegenerateViaIdentityExpanded$|^RegenerateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: Update
    remove: true
  - where:
      subject: AuthorizationRule|NamespaceAuthorizationRule
    hide: true
  - where:
      subject: Key|NamespaceKey
    hide: true
  - where:
      subject: AuthorizationRule|NamespaceAuthorizationRule
      parameter-name: AuthorizationRuleName
    set:
      parameter-name: Name
  - where:
      subject: Key|NamespaceKey
      parameter-name: AuthorizationRuleName
    set:
      parameter-name: Name

  - where:
      subject: NamespaceNetworkRuleSet
    set:
      subject: NetworkRuleSet

# Geo Disaster Recovery, cmdlet naming changes
  - where:
      subject: DisasterRecoveryConfig
      parameter-name: Alias
    set:
      parameter-name: Name

  - where:
      verb: Invoke
      subject: BreakDisasterRecoveryConfigPairing|FailDisasterRecoveryConfigOver
      parameter-name: Alias
    set:
      parameter-name: Name

  - where:
      verb: Invoke
      subject: BreakDisasterRecoveryConfigPairing
    hide: true

  - where:
      verb: Invoke
      subject: FailDisasterRecoveryConfigOver
    hide: true

  - where:
      subject: DisasterRecoveryConfig
    set:
      subject: GeoDRConfiguration

# Remove namespace cmdlets
#  - where:
#      subject: Namespace
#    remove: true

# Hide New-AzEventHubPrivateEndpointConnection
  - where:
      verb: New
      subject: PrivateEndpointConnection
    hide: true
  
  - where:
      subject: PrivateLinkResource
    set:
      subject: PrivateLink

# Renaming New-AzEventHubNamespace
  - where:
      verb: New
      subject: Namespace
      parameter-name: EncryptionRequireInfrastructureEncryption
    set:
      parameter-name: RequireInfrastructureEncryption
  - where:
      model-name: EhNamespace
      property-name: EncryptionRequireInfrastructureEncryption
    set:
      property-name: RequireInfrastructureEncryption
  
  - where:
      verb: New
      subject: Namespace
      parameter-name: EncryptionKeyVaultProperty
    set:
      parameter-name: KeyVaultProperty
  - where:
      model-name: EhNamespace
      property-name: EncryptionKeyVaultProperty
    set:
      property-name: KeyVaultProperty

  - where:
      verb: New
      subject: Namespace
      parameter-name: IsAutoInflateEnabled
    set:
      parameter-name: EnableAutoInflate
  - where:
      model-name: EhNamespace
      property-name: IsAutoInflateEnabled
    set:
      property-name: EnableAutoInflate
  
  - where:
      verb: New
      subject: Namespace
      parameter-name: EncryptionKeySource
    set:
      parameter-name: KeySource
  - where:
      model-name: EhNamespace
      property-name: EncryptionKeySource
    set:
      property-name: KeySource

  - where:
      verb: New
      subject: Namespace
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      model-name: EhNamespace
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: UserAssignedIdentity

  - where:
      model-name: EhNamespace
      property-name: IdentityPrincipalId
    set:
      property-name: PrincipalId

  - where:
      model-name: EhNamespace
      property-name: IdentityTenantId
    set:
      property-name: TenantId
    
  - where:
      verb: New
      subject: Namespace
    hide: true

  - where:
      verb: Get
      subject: Namespace
    set:
      alias: Get-AzEventHubNamespaceV2

  - where:
      verb: Remove
      subject: Namespace
    set:
      alias: Remove-AzEventHubNamespaceV2

  - where:
      model-name: KeyVaultProperties
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: UserAssignedIdentity

  - where:
      verb: Get
      subject: PrivateLink
      variant: GetViaIdentity
    remove: true

  - where:
      model-name: PrivateEndpointConnection
      property-name: PrivateLinkServiceConnectionStateStatus
    set:
      property-name: ConnectionState

  - where:
      model-name: PrivateEndpointConnection
      property-name: PrivateLinkServiceConnectionStateDescription
    set:
      property-name: Description

# Remove NSP calls
  - where:
      subject: NetworkSecurityPerimeterConfiguration
    remove: true

# Hide New-AzEventHubNetworkRuleSet 
  - where:
      verb: New
      subject: NetworkRuleSet
    hide: true
  
# Rename parameters on New-AzEventHub and it's models
  - where:
      verb: New
      subject: EventHub
      parameter-name: CaptureDescriptionEnabled
    set:
      parameter-name: CaptureEnabled
  - where:
      model-name: EventHub
      property-name: CaptureDescriptionEnabled
    set:
      property-name: CaptureEnabled
  
  - where:
      verb: New
      subject: EventHub
      parameter-name: RetentionDescriptionRetentionTimeInHour
    set:
      parameter-name: RetentionTimeInHour
  - where:
      model-name: EventHub
      property-name: RetentionDescriptionRetentionTimeInHour
    set:
      property-name: RetentionTimeInHour

  - where:
      verb: New
      subject: EventHub
      parameter-name: RetentionDescriptionCleanupPolicy
    set:
      parameter-name: CleanupPolicy
  - where:
      model-name: EventHub
      property-name: RetentionDescriptionCleanupPolicy
    set:
      property-name: CleanupPolicy

  - where:
      verb: New
      subject: EventHub
      parameter-name: CaptureDescriptionEncoding
    set:
      parameter-name: Encoding
  - where:
      model-name: EventHub
      property-name: CaptureDescriptionEncoding
    set:
      property-name: Encoding

  - where:
      verb: New
      subject: EventHub
      parameter-name: CaptureDescriptionIntervalInSecond
    set:
      parameter-name: IntervalInSeconds
  - where:
      model-name: EventHub
      property-name: CaptureDescriptionIntervalInSecond
    set:
      property-name: IntervalInSeconds

  - where:
      verb: New
      subject: EventHub
      parameter-name: CaptureDescriptionSkipEmptyArchive
    set:
      parameter-name: SkipEmptyArchive
  - where:
      model-name: EventHub
      property-name: CaptureDescriptionSkipEmptyArchive
    set:
      property-name: SkipEmptyArchive

  - where:
      verb: New
      subject: EventHub
      parameter-name: CaptureDescriptionSizeLimitInByte
    set:
      parameter-name: SizeLimitInBytes
  - where:
      model-name: EventHub
      property-name: CaptureDescriptionSizeLimitInByte
    set:
      property-name: SizeLimitInBytes

  - where:
      verb: New
      subject: EventHub
      parameter-name: DataLakeAccountName|DataLakeFolderPath|DataLakeSubscriptionId
    hide: true

  - where:
      verb: New
      subject: EventHub
      parameter-name: MessageRetentionInDay
    hide: true

  - where:
      verb: New
      subject: EventHub
      parameter-name: RetentionDescriptionTombstoneRetentionTimeInHour
    set:
      parameter-name: TombstoneRetentionTimeInHour
  - where:
      model-name: EventHub
      property-name: RetentionDescriptionTombstoneRetentionTimeInHour
    set:
      property-name: TombstoneRetentionTimeInHour

# Cluster
  - where:
      verb: New
      subject: Cluster
      parameter-name: SkuCapacity
    set:
      parameter-name: Capacity
  - where:
      model-name: Cluster
      property-name: SkuCapacity
    set:
      property-name: Capacity
  - where:
      subject: ClusterAvailableClusterRegion
    set:
      subject: ClustersAvailableRegion
  - where:
      verb: New
      subject: Cluster
      parameter-name: Capacity
    set:
      default:
        script: '1'

# Schema Group
  - where:
      verb: New|Remove|Get 
      subject: SchemaRegistry
      parameter-name: SchemaGroupName
    set:
      parameter-name: Name

  - where:
      subject: SchemaRegistry
      parameter-name: Name
    set:
      alias:
        - SchemaGroupName

  - where:
      subject: SchemaRegistry
    set:
      subject: SchemaGroup

# Name Availability
  - where:
      verb: Test
      subject: NamespaceNameAvailability
    hide: true

  - where:
      verb: Test
      subject: DisasterRecoveryConfigNameAvailability
    hide: true

# Table formatting

  - where:
      model-name: (.*)
    set:
      suppress-format: true

  - model-cmdlet:
    - KeyVaultProperties
