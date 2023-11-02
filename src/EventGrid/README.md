<!-- region Generated -->
# Az.EventGrid
This directory contains the PowerShell module for the EventGrid service.

---
## Status
[![Az.EventGrid](https://img.shields.io/powershellgallery/v/Az.EventGrid.svg?style=flat-square&label=Az.EventGrid "Az.EventGrid")](https://www.powershellgallery.com/packages/Az.EventGrid/)

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

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 9b608455354b830777c66ad5116f45880b0e6e71
require:
  - $(this-folder)/../readme.azure.noprofile.md
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
      verb: Enable
      subject: PartnerConfiguration

  - where:
      verb: Invoke
      subject: PartnerConfigurationUnauthorize
    set:
      verb: Disable
      subject: PartnerConfiguration

  - no-inline:
    - EventSubscriptionDestination

  - model-cmdlet:
    - model-name: ResourceMoveChangeHistory
    - model-name: PrivateEndpointConnection
    - model-name: DynamicRoutingEnrichment
    - model-name: StaticRoutingEnrichment
    - model-name: InboundIPRule
    - model-name: AdvancedFilter
    - model-name: Partner
    - model-name: Filter
    - model-name: WebHookEventSubscriptionDestination
    - model-name: EventHubEventSubscriptionDestination
    - model-name: StorageQueueEventSubscriptionDestination
    - model-name: HybridConnectionEventSubscriptionDestination
    - model-name: ServiceBusQueueEventSubscriptionDestination
    - model-name: ServiceBusTopicEventSubscriptionDestination
    - model-name: AzureFunctionEventSubscriptionDestination
    - model-name: PartnerEventSubscriptionDestination
```
