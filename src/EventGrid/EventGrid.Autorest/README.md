<!-- region Generated -->
# Az.EventGrid
This directory contains the PowerShell module for the EventGrid service.

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
For information on how to develop for `Az.EventGrid`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 9b608455354b830777c66ad5116f45880b0e6e71
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/eventgrid/resource-manager/Microsoft.EventGrid/preview/2023-06-01-preview/EventGrid.json

title: EventGrid
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
auto-switch-view: false

use-extension: 
  "@autorest/powershell": "4.x"

directive:
  - from: swagger-document 
    where: $.definitions.TrackedResource.properties.location
    transform: >-
      return {
        "description": "Location of the resource.",
        "type": "string",
        "x-ms-mutability": [
          "read",
          "create",
          "update"
        ]
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}"].put.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/Domain"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/Domain"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{domainTopicName}"].put.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/DomainTopic"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/DomainTopic"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/{scope}/providers/Microsoft.EventGrid/eventSubscriptions/{eventSubscriptionName}"].put.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "EventSubscription CreateOrUpdate request accepted.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/{scope}/providers/Microsoft.EventGrid/eventSubscriptions/{eventSubscriptionName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "EventSubscription update request accepted.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{topicName}/eventSubscriptions/{eventSubscriptionName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}/eventSubscriptions/{eventSubscriptionName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerTopics/{partnerTopicName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK",
          "schema": {
            "$ref": "#/definitions/PartnerTopic"
          }
        },
        "201": {
          "description": "Partner Topic update request accepted.",
          "schema": {
            "$ref": "#/definitions/PartnerTopic"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}/eventSubscriptions/{eventSubscriptionName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/systemTopics/{systemTopicName}/eventSubscriptions/{eventSubscriptionName}"].put.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK",
          "schema": {
            "$ref": "#/definitions/Domain"
          }
        },
        "201": {
          "description": "Domain update request accepted.",
          "schema": {
            "$ref": "#/definitions/Domain"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/systemTopics/{systemTopicName}/eventSubscriptions/{eventSubscriptionName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerTopics/{partnerTopicName}/eventSubscriptions/{eventSubscriptionName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/EventSubscription"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerNamespaces/{partnerNamespaceName}/channels/{channelName}"].patch.responses
    transform: >-
      return {
        "200": {
          "description": "OK",
          "schema": {
            "$ref": "#/definitions/Channel"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerNamespaces/{partnerNamespaceName}"].put.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/PartnerNamespace"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/PartnerNamespace"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "NoContent"
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 404 Not Found.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}"].put.responses
    transform: >-
      return {
        "200": {
          "description": "OK.",
          "schema": {
            "$ref": "#/definitions/Topic"
          }
        },
        "201": {
          "description": "Created",
          "schema": {
            "$ref": "#/definitions/Topic"
          }
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 500 Internal Server Error."
        }
      }

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK."
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "type": "string"
            }
          }
        },
        "204": {
          "description": "NoContent"
        },
        "default": {
          "description": "*** Error Responses: ***\n\n * 400 Bad Request.\n\n * 404 Not Found.\n\n * 500 Internal Server Error."
        }
      }

  - where:
      variant: Create
      subject: DomainTopic
    set:
      variant: CreateExpanded

  - where:
      variant: Get
      subject: PartnerConfiguration
    remove: true

  - where:
      variant: ^(Create|Update|Regenerate).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true
  - where:
      verb: Set
    remove: true

  - where:
      verb: Initialize
      subject: PartnerDestination
    set:
      verb: Enable

  - where:
      verb: Initialize
      subject: PartnerTopic
    set:
      verb: Enable

  - where:
      verb: Invoke
      subject: DeactivatePartnerTopic
    set:
      verb: Disable
      subject: PartnerTopic

  - where:
      verb: Grant
      subject: PartnerConfigurationPartner
    set:
      subject: PartnerConfiguration

  - where:
      verb: Invoke
      subject: PartnerConfigurationUnauthorize
    set:
      verb: Revoke
      subject: PartnerConfiguration

  - where:
      subject: PartnerTopicEventSubscriptionFullUrl
    set:
      subject: FullUrlForPartnerTopicEventSubscription

  - where:
      subject: SystemTopicEventSubscriptionFullUrl
    set:
      subject: FullUrlForSystemTopicEventSubscription

  - where:
      subject: EventSubscription
    set:
      subject: Subscription

  - where:
      subject: EventSubscriptionDeliveryAttribute
    set:
      subject: SubscriptionDeliveryAttribute

  - where:
      subject: EventSubscriptionFullUrl
    set:
      subject: SubscriptionFullUrl

  - where:
      subject: EventSubscriptionGlobal
    set:
      subject: SubscriptionGlobal

  - where:
      subject: EventSubscriptionRegional
    set:
      subject: SubscriptionRegional

  - where:
      subject: DomainSharedAccessKey
    set:
      subject: DomainKey

  - where:
      subject: PartnerNamespaceSharedAccessKey
    set:
      subject: PartnerNamespaceKey

  - where:
      subject: TopicSharedAccessKey
    set:
      subject: TopicKey

  - where:
      subject: NamespaceSharedAccessKey
    set:
      subject: NamespaceKey

  - where:
      subject: NamespaceTopicSharedAccessKey
    set:
      subject: NamespaceTopicKey

  - no-inline:
    - EventSubscriptionDestination

  - model-cmdlet:
    - model-name: WebHookEventSubscriptionDestination
    - model-name: EventHubEventSubscriptionDestination
    - model-name: StorageQueueEventSubscriptionDestination
    - model-name: HybridConnectionEventSubscriptionDestination
    - model-name: ServiceBusQueueEventSubscriptionDestination
    - model-name: ServiceBusTopicEventSubscriptionDestination
    - model-name: AzureFunctionEventSubscriptionDestination
    - model-name: PartnerEventSubscriptionDestination
    - model-name: ResourceMoveChangeHistory
    - model-name: PrivateEndpointConnection
    - model-name: DynamicRoutingEnrichment
    - model-name: DeliveryAttributeMapping
    - model-name: StaticRoutingEnrichment
    - model-name: InboundIPRule
    - model-name: AdvancedFilter
    - model-name: Partner
    - model-name: Filter

  # CA Certificates cannot be updated. Please delete the existing CA Certificate resource and recreate it with the desired values.
  - where:
      verb: Update
      subject: CaCertificate
    remove: true

  - where:
      verb: Update
      subject: PartnerRegistration
    remove: true

# start: Modifications for disruptive changes
  - where:
      parameter-name: ResourceGroupName
    set:
      alias: ResourceGroup

  - where:
      subject: DomainTopic
      parameter-name: DomainName
    set:
      alias: Domain

  - where:
      subject: Domain
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
      alias: IdentityId

  - where:
      subject: Namespace
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
      alias: IdentityId

  - where:
      subject: NamespaceTopicEventSubscription
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
      alias: IdentityId

  - where:
      subject: PartnerTopic
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
      alias: IdentityId

  - where:
      subject: SystemTopic
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
      alias: IdentityId

  - where:
      subject: Topic
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
      alias: IdentityId

  - where:
      subject: PartnerTopic
      parameter-name: EventTypeInfoKind
    set:
      alias: EventTypeKind
  - where:
      subject: PartnerTopic
      parameter-name: EventTypeInfoInlineEventType
    set:
      alias: InlineEvent

  - where:
      subject: Channel
      parameter-name: PartnerTopicInfoSource
    set:
      alias: PartnerTopicSource
  - where:
      subject: Channel
      parameter-name: PartnerTopicInfoName
    set:
      alias: PartnerTopicName
  - where:
      subject: Channel
      parameter-name: EventTypeInfoKind
    set:
      alias: EventTypeKind
  - where:
      subject: Channel
      parameter-name: EventTypeInfoInlineEventType
    set:
      alias: InlineEvent

  - where:
      subject: PartnerConfiguration
      parameter-name: AuthorizationExpirationTimeInUtc
    set:
      alias: AuthorizationExpirationTime
  - where:
      subject: PartnerConfiguration
      parameter-name: PartnerAuthorizationDefaultMaximumExpirationTimeInDay
    set:
      alias: MaxExpirationTimeInDays
  - where:
      subject: PartnerConfiguration
      parameter-name: PartnerAuthorizationAuthorizedPartnersList
    set:
      alias: AuthorizedPartner

  - where:
      verb: Get
      subject: DomainSharedAccessKey
      parameter-name: DomainName
    set:
      alias: Name

  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: EventDeliverySchema
    set:
      alias: DeliverySchema
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: RetryPolicyEventTimeToLiveInMinute
    set:
      alias: EventTtl
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: ExpirationTimeUtc
    set:
      alias: ExpirationDate
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: FilterAdvancedFilter 
    set:
      alias: AdvancedFilter
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: FilterEnableAdvancedFilteringOnArray 
    set:
      alias: AdvancedFilteringOnArray
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: FilterIncludedEventType
    set:
      alias: IncludedEventType
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: FilterSubjectBeginsWith
    set:
      alias: SubjectBeginsWith
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: FilterSubjectEndsWith
    set:
      alias: SubjectEndsWith
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: FilterIsSubjectCaseSensitive
    set:
      alias: SubjectCaseSensitive
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: RetryPolicyMaxDeliveryAttempt
    set:
      alias: MaxDeliveryAttempt
  - where:
      subject: PartnerTopicEventSubscription
      parameter-name: EventSubscriptionName
    set:
      alias: Name

  - where:
      verb: Get
      subject: PartnerTopicEventSubscriptionDeliveryAttribute
      parameter-name: EventSubscriptionName
    set:
      alias: Name

  - where:
      verb: Get
      subject: FullUrlForPartnerTopicEventSubscription
      parameter-name: EventSubscriptionName
    set:
      alias: Name

  - where:
      subject: SystemTopicEventSubscription
      parameter-name: EventDeliverySchema
    set:
      alias: DeliverySchema
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: RetryPolicyEventTimeToLiveInMinute
    set:
      alias: EventTtl
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: ExpirationTimeUtc
    set:
      alias: ExpirationDate
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: RetryPolicyMaxDeliveryAttempt
    set:
      alias: MaxDeliveryAttempt
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: FilterAdvancedFilter
    set:
      alias: AdvancedFilter
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: FilterEnableAdvancedFilteringOnArray
    set:
      alias: AdvancedFilteringOnArray
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: FilterIncludedEventType
    set:
      alias: IncludedEventType
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: FilterSubjectBeginsWith
    set:
      alias: SubjectBeginsWith
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: FilterSubjectEndsWith
    set:
      alias: SubjectEndsWith
  - where:
      subject: SystemTopicEventSubscription
      parameter-name: FilterIsSubjectCaseSensitive
    set:
      alias: SubjectCaseSensitive

  - where:
      verb: Get
      subject: NamespaceKey
      parameter-name: NamespaceName
    set:
      alias: Name

  - where:
      verb: Get
      subject: Subscription
      parameter-name: TopicName
    set:
      alias: DomainTopicName
  - where:
      subject: Subscription
      parameter-name: FilterSubjectBeginsWith
    set:
      alias: SubjectBeginsWith
  - where:
      subject: Subscription
      parameter-name: FilterSubjectEndsWith
    set:
      alias: SubjectEndsWith
  - where:
      subject: Subscription
      parameter-name: FilterIsSubjectCaseSensitive
    set:
      alias: SubjectCaseSensitive
  - where:
      subject: Subscription
      parameter-name: FilterIncludedEventType
    set:
      alias: IncludedEventType
  - where:
      subject: Subscription
      parameter-name: RetryPolicyEventTimeToLiveInMinute
    set:
      alias: EventTtl
  - where:
      subject: Subscription
      parameter-name: RetryPolicyMaxDeliveryAttempt
    set:
      alias: MaxDeliveryAttempt
  - where:
      subject: Subscription
      parameter-name: EventDeliverySchema
    set:
      alias: DeliverySchema
  - where:
      subject: Subscription
      parameter-name: ExpirationTimeUtc
    set:
      alias: ExpirationDate
  - where:
      subject: Subscription
      parameter-name: FilterAdvancedFilter
    set:
      alias: AdvancedFilter
  - where:
      subject: Subscription
      parameter-name: FilterEnableAdvancedFilteringOnArray
    set:
      alias: AdvancedFilteringOnArray

  - where:
      verb: Get
      subject: TopicKey
      parameter-name: TopicName
    set:
      alias: Name
# end: Modifications for disruptive changes
```
