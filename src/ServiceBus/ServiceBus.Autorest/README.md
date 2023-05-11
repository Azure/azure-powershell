<!-- region Generated -->
# Az.ServiceBus
This directory contains the PowerShell module for the ServiceBus service.

---
## Status
[![Az.ServiceBus](https://img.shields.io/powershellgallery/v/Az.ServiceBus.svg?style=flat-square&label=Az.ServiceBus "Az.ServiceBus")](https://www.powershellgallery.com/packages/Az.ServiceBus/)

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
For information on how to develop for `Az.ServiceBus`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
branch: 1e790cfc5ee4e7ff98f99dd19a3174c4dd58432b
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/Queue.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/topics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/namespace-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/AuthorizationRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/CheckNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/DisasterRecoveryConfig.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/migrationconfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/networksets.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/Rules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-10-01-preview/subscriptions.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ServiceBus
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
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
      verb: Set
    remove: true
  - where:
      verb: Update
    remove: true

# Migration Configs
  - where:
      verb: New
      subject: MigrationConfigAndStartMigration
    set:
      verb: Start
      subject: Migration
  - where:
      verb: Invoke
      subject: RevertMigrationConfig
    set:
      verb: Stop
      subject: Migration
  - where:
      subject: MigrationConfigMigration
    set:
      subject: Migration
  - where:
      subject: MigrationConfig
    set:
      subject: Migration

# Remove namespace cmdlets
#  - where:
#      subject: Namespace
#    remove: true

# Renaming New-AzServiceBusNamespace
  - where:
      verb: New
      subject: Namespace
      parameter-name: EncryptionRequireInfrastructureEncryption
    set:
      parameter-name: RequireInfrastructureEncryption
  - where:
      model-name: SbNamespace
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
      model-name: SbNamespace
      property-name: EncryptionKeyVaultProperty
    set:
      property-name: KeyVaultProperty
  
  - where:
      verb: New
      subject: Namespace
      parameter-name: EncryptionKeySource
    set:
      parameter-name: KeySource
  - where:
      model-name: SbNamespace
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
      model-name: SbNamespace
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: UserAssignedIdentity
  
  - where:
      model-name: SbNamespace
      property-name: IdentityPrincipalId
    set:
      property-name: PrincipalId

  - where:
      model-name: SbNamespace
      property-name: IdentityTenantId
    set:
      property-name: TenantId

  - where:
      model-name: KeyVaultProperties
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: UserAssignedIdentity

  - where:
      verb: New
      subject: Namespace
    hide: true

  - where:
      verb: Get
      subject: Namespace
    set:
      alias: Get-AzServiceBusNamespaceV2

  - where:
      verb: Remove
      subject: Namespace
    set:
      alias: Remove-AzServiceBusNamespaceV2

# Rules
  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterContentType
    set:
      parameter-name: ContentType
  - where:
      model-name: Rule
      property-name: CorrelationFilterContentType
    set:
      property-name: ContentType

  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterCorrelationId
    set:
      parameter-name: CorrelationId
  - where:
      model-name: Rule
      property-name: CorrelationFilterCorrelationId
    set:
      property-name: CorrelationId

  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterLabel
    set:
      parameter-name: Label
  - where:
      model-name: Rule
      property-name: CorrelationFilterLabel
    set:
      property-name: Label

  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterMessageId
    set:
      parameter-name: MessageId
  - where:
      model-name: Rule
      property-name: CorrelationFilterMessageId
    set:
      property-name: MessageId

  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterReplyTo
    set:
      parameter-name: ReplyTo
  - where:
      model-name: Rule
      property-name: CorrelationFilterReplyTo
    set:
      property-name: ReplyTo

  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterReplyToSessionId
    set:
      parameter-name: ReplyToSessionId
  - where:
      model-name: Rule
      property-name: CorrelationFilterReplyToSessionId
    set:
      property-name: ReplyToSessionId

  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterSessionId
    set:
      parameter-name: SessionId
  - where:
      model-name: Rule
      property-name: CorrelationFilterSessionId
    set:
      property-name: SessionId

  - where:
      verb: New
      subject: Rule
      parameter-name: CorrelationFilterTo
    set:
      parameter-name: To
  - where:
      model-name: Rule
      property-name: CorrelationFilterTo
    set:
      property-name: To

  - where:
      verb: New
      subject: Rule
      parameter-name: ActionCompatibilityLevel
    hide: true

  - where:
      verb: New
      subject: Rule
      parameter-name: SqlFilterCompatibilityLevel
    hide: true

  - where:
      verb: New
      subject: Rule
      parameter-name: SqlFilterSqlExpression
    set:
      parameter-name: SqlExpression
  - where:
      model-name: Rule
      property-name: SqlFilterSqlExpression
    set:
      property-name: SqlExpression

# Subscriptions
  - where:
      verb: New
      subject: Subscription
      parameter-name: ClientAffinePropertyClientId
    set:
      parameter-name: ClientId
  - where:
      model-name: SbSubscription
      property-name: ClientAffinePropertyClientId
    set:
      property-name: ClientId

  - where:
      verb: New
      subject: Subscription
      parameter-name: ClientAffinePropertyIsDurable
    set:
      parameter-name: IsDurable
  - where:
      model-name: SbSubscription
      property-name: ClientAffinePropertyIsDurable
    set:
      property-name: IsDurable

  - where:
      verb: New
      subject: Subscription
      parameter-name: ClientAffinePropertyIsShared
    set:
      parameter-name: IsShared
  - where:
      model-name: SbSubscription
      property-name: ClientAffinePropertyIsShared
    set:
      property-name: IsShared

# Authorization Rules
  - where:
      variant: ^RegenerateExpanded$|^RegenerateViaIdentityExpanded$|^RegenerateViaIdentity$
    remove: true

  - where:
      subject: QueueAuthorizationRule|NamespaceAuthorizationRule|TopicAuthorizationRule|DisasterRecoveryConfigAuthorizationRule
    hide: true

  - where:
      subject: QueueKey|NamespaceKey|TopicKey|DisasterRecoveryConfigKey
    hide: true

  - where:
      subject: QueueAuthorizationRule|NamespaceAuthorizationRule|TopicAuthorizationRule|DisasterRecoveryConfigAuthorizationRule
      parameter-name: AuthorizationRuleName
    set:
      parameter-name: Name

  - where:
      subject: QueueKey|TopicKey|NamespaceKey
      parameter-name: AuthorizationRuleName
    set:
      parameter-name: Name

# Disaster Recovery Configs
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

# Change singular names to plural
  - where:
      parameter-name: MaxMessageSizeInKilobyte
    set:
      parameter-name: MaxMessageSizeInKilobytes
  - where:
      property-name: MaxMessageSizeInKilobyte
    set:
      property-name: MaxMessageSizeInKilobytes

  - where:
      parameter-name: MaxSizeInMegabyte
    set:
      parameter-name: MaxSizeInMegabytes
  - where:
      property-name: MaxSizeInMegabyte
    set:
      property-name: MaxSizeInMegabytes

  - where:
      parameter-name: EnableBatchedOperation
    set:
      parameter-name: EnableBatchedOperations
  - where:
      property-name: EnableBatchedOperation
    set:
      property-name: EnableBatchedOperations

# Re-Write descriptions for TimeSpan objects
# Reason being the swagger descriptions specify ISO 8601 format for timespan objects which will no longer be supported by powershell
  - where:
      parameter-name: LockDuration
      verb: New|Set
      subject: Queue|Topic|Subscription
    set:
      parameter-description: Timespan duration of a peek-lock; that is, the amount of time that the message is locked for other receivers. The maximum value for LockDuration is 5 minutes; the default value is 1 minute.

  - where:
      parameter-name: DefaultMessageTimeToLive
      verb: New|Set
      subject: Queue|Topic|Subscription
    set:
      parameter-description: This is the duration after which the message expires, starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself.

  - where:
      parameter-name: DuplicateDetectionHistoryTimeWindow
      verb: New|Set
      subject: Queue|Topic|Subscription
    set:
      parameter-description: Defines the duration of the duplicate detection history. The default value is 10 minutes.

  - where:
      parameter-name: AutoDeleteOnIdle
      verb: New|Set
      subject: Queue|Topic|Subscription
    set:
      parameter-description: Idle interval after which the queue is automatically deleted. The minimum duration is 5 minutes.

# Name Availability
  - where:
      verb: Test
      subject: NamespaceNameAvailability
    hide: true

  - where:
      verb: Test
      subject: DisasterRecoveryConfigNameAvailability
    hide: true

# Hide New-AzEventHubPrivateEndpointConnection
  - where:
      verb: New
      subject: PrivateEndpointConnection
    hide: true
  
  - where:
      subject: PrivateLinkResource
    set:
      subject: PrivateLink

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

# Network Rule Sets
  - where:
      subject: NamespaceNetworkRuleSet
    set:
      subject: NetworkRuleSet

  - where:
      verb: New
      subject: NetworkRuleSet
    hide: true

# Suppress Table formats
  - where:
      model-name: (.*)
    set:
      suppress-format: true

  - where:
      subject: Subscription
      parameter-name: Id
    set:
      parameter-name: SubscriptionId
    clear-alias: true

  - model-cmdlet:
    - KeyVaultProperties
