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
branch: 6f0c7d58c0a923917c2b3467ee756f21dbd2f8e2
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/Queue.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/topics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/namespace-preview.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/AuthorizationRules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/CheckNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/DisasterRecoveryConfig.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/migrationconfigs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/networksets.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/Rules.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicebus/resource-manager/Microsoft.ServiceBus/preview/2022-01-01-preview/subscriptions.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ServiceBus
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

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
  - where:
      verb: Invoke
      subject: BreakDisasterRecoveryConfigPairing
    set:
      verb: Set
      subject: GeoDRConfigurationBreakPair
  - where:
      verb: Invoke
      subject: FailDisasterRecoveryConfigOver
    set:
      verb: Set
      subject: GeoDRConfigurationFailOver
  - where:
      subject: DisasterRecoveryConfig
    set:
      subject: GeoDRConfiguration

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
      parameter-name: SqlFilterSqlExpression
    set:
      parameter-name: SqlExpression
  - where:
      model-name: Rule
      property-name: SqlFilterSqlExpression
    set:
      property-name: SqlExpression

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