<!-- region Generated -->
# Az.SignalR
This directory contains the PowerShell module for the WebPubSub service.

---
## Status
[![Az.SignalR](https://img.shields.io/powershellgallery/v/Az.SignalR.svg?style=flat-square&label=Az.SignalR "Az.SignalR")](https://www.powershellgallery.com/packages/Az.SignalR/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.SignalR`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
sanitize-names: true
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/webpubsub/resource-manager/Microsoft.SignalRService/stable/2021-10-01/webpubsub.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger

# For new RP, the version is 0.1.0
module-version: 0.1.0
module-name: Az.SignalR
psm1: Az.SignalR.psm1
psm1-internal: internal/Az.SignalR.internal.psm1
psm1-custom: custom/Az.SignalR.custom.psm1
# Normally, title is the service name
title: WebPubSub
subject-prefix: ''
branch: ab0c850713dcb87f906e8f38f73d43099668a60f

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - select: command
    where:
      verb: Get
      subject: Usage
    set:
      subject-prefix: WebPubSub
  # Remove the private link resource related cmdlets
  - where:
      subject: WebPubSubPrivateEndpointConnection|WebPubSubPrivateLinkResource|WebPubSubSharedPrivateLinkResource
    remove: true
  # Customized cmdlets
  #   To make parameter 'Location', 'SkuName' mandatory
  - where:
      verb: New
      subject: WebPubSub
    hide: true
  #   To make parameter 'KeyType` mandatory, get a key after 'new' complete
  - where:
      verb: New
      subject: WebPubSubKey
    hide: true
  # Remove the unexpanded parameter set because there is only one parameter
  - where:
      variant: ^Regenerate$|^RegenerateViaIdentity$
      subject: WebPubSubKey
    remove: true
  # Remove the unexpanded parameter set with only one parameter, remove meaningless identity parameter set
  - where:
      variant: ^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
      subject: WebPubSubNameAvailability
    remove: true
  # Hide parameters
  - where:
      verb: Update
      subject: WebPubSub
      parameter-name: Location   # location cannot be updated
    hide: true
  - where:
      verb: Test
      subject: WebPubSubNameAvailability
      parameter-name: Type
    hide: true
    set:
      default:
        script: '"Microsoft.SignalRService/webPubSub"'
  # Add 200 return code to swagger in order to mitigate the issue that async operation returns 200 but not recognized by AutoRest
  # the commit or branch referenced here must be consistent with the branch property in this file
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/regenerateKey"].post.responses
    transform: >-
      return {
          "202": {
            "description": "Accepted and an async operation is executing in background to make the new key to take effect. The response contains new access keys and a Location header to query the async operation result.",
            "schema": {
              "$ref": "#/definitions/WebPubSubKeys"
            }
          },
         "200": {
            "description": "The async operation to make the new key to take effect is finished."
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ab0c850713dcb87f906e8f38f73d43099668a60f/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
            }
          }
        }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/restart"].post.responses
    transform: >-
      return {
          "202": {
            "description": "Accepted. The response indicates the restart operation is performed in the background."
          },
          "204": {
            "description": "Success. The response indicates the operation is successful and no content will be returned."
          },
         "200": {
            "description": "The async operation to restart is finished.",
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/ab0c850713dcb87f906e8f38f73d43099668a60f/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
            }
          }
        }
  # lowerCase 'webPubSub' to 'WebPubSub' so that we can piping
  - from: swagger-document
    where: $
    transform: return $.replace(/\/subscriptions\/\{subscriptionId\}\/resourceGroups\/\{resourceGroupName\}\/providers\/Microsoft\.SignalRService\/webPubSub/g, "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/WebPubSub")
  # Add enum valid values description in swagger
  - from: swagger-document
    where: $.definitions.EventHandler.properties.systemEvents.description
    transform: >-
      return "Gets ot sets the list of system events. Valid values contain: 'connect', 'connected', 'disconnected'."
  - from: swagger-document
    where: $.definitions.RegenerateKeyParameters.properties.keyType.description
    transform: >-
      return "Must be either 'primary', 'secondary' or 'salt'(case-insensitive)."
  # format output
  - where:
      model-name: WebPubSubResource
    set:
      format-table:
        properties:
          - Name
          - Location
          - SkuName
  - where:
      model-name: NameAvailability
    set:
      format-table:
        properties:
          - NameAvailable
          - Reason
          - Message
  - where:
      model-name: WebPubSubHub
    set:
      format-table:
        properties:
          - Name
          - AnonymousConnectPolicy
  - where:
      model-name: SignalRServiceUsage
    set:
      format-table:
        properties:
          - NameValue
          - CurrentValue
          - Limit
          - Unit
  - where:
      model-name: Sku
    set:
      format-table:
        properties:
          - Name
          - Tier
          - SkuCapacity
          - CapacityDefault
          - CapacityAllowedValue
          - CapacityMinimum
          - CapacityMaximum
          - CapacityScaleType
  # rename parameters
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      parameter-name: TlClientCertEnabled
    set:
      parameter-name: EnableTlsClientCert
  - where:
      parameter-name: NetworkAcLPrivateEndpoint
    set:
      parameter-name: PrivateEndpointAcl
  - where:
      parameter-name: LiveTraceConfigurationEnabled
    set:
      parameter-name: LiveTraceEnabled
  - where:
      parameter-name: LiveTraceConfigurationCategory
    set:
      parameter-name: LiveTraceCategory
  - where:
      parameter-name: ResourceLogConfigurationCategory
    set:
      parameter-name: ResourceLogCategory
  # rename model properties, usually is a mapping of the previous section
  - where:
      model-name: WebPubSubResource
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: UserAssignedIdentity
  - where:
      model-name: WebPubSubResource
      property-name: TlClientCertEnabled
    set:
      property-name: EnableTlsClientCert
  - where:
      model-name: WebPubSubResource
      property-name: NetworkAcLPrivateEndpoint
    set:
      property-name: PrivateEndpointAcl
  - where:
      model-name: WebPubSubResource
      property-name: LiveTraceConfigurationEnabled
    set:
      property-name: LiveTraceEnabled
  - where:
      model-name: WebPubSubResource
      property-name: LiveTraceConfigurationCategory
    set:
      property-name: LiveTraceCategory
  - where:
      model-name: WebPubSubResource
      property-name: ResourceLogConfigurationCategory
    set:
      property-name: ResourceLogCategory
  # remove the subject before the 'Name' when multiple *Name parameter exist
  - where:
      subject: WebPubSubEventHandler
      parameter-name: EventHandlerName
    set:
      parameter-name: Name
  - where:
      subject: WebPubSubHub
      parameter-name: HubName
    set:
      parameter-name: Name
  - where:
      subject: WebPubSub
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias: ResourceName
```
