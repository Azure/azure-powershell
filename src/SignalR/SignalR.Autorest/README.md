<!-- region Generated -->
# Az.SignalR
This directory contains the PowerShell module for the WebPubSub service.

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
  - $(repo)/specification/webpubsub/resource-manager/Microsoft.SignalRService/preview/2022-08-01-preview/webpubsub.json
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
# When updating the commit hash, please update all occurrences in the file
commit: 492cf91751be945ceae53cfdd53b1ff2fb878703

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
  # Get the custom domain after 'new' complete
  - where:
      verb: New
      subject: WebPubSubCustomDomain
    hide: true
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
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/492cf91751be945ceae53cfdd53b1ff2fb878703/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
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
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/492cf91751be945ceae53cfdd53b1ff2fb878703/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
            }
          }
        }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/customDomains/{name}"].put.responses
    transform: >-
      return {
          "201": {
            "description": "Created. The response describes the custom domain and contains a Location header to query the operation result.",
            "schema": {
              "$ref": "#/definitions/CustomDomain"
            }
          },
         "200": {
            "description": "The async operation to restart is finished.",
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/492cf91751be945ceae53cfdd53b1ff2fb878703/specification/common-types/resource-management/v2/types.json#/definitions/ErrorResponse"
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
  - where:
      model-name: CustomCertificate
    set:
      format-table:
        properties:
          - Name
          - KeyVaultBaseUri
          - KeyVaultSecretName
          - KeyVaultSecretVersion
          - ProvisioningState
  - where:
      model-name: CustomDomain
    set:
      format-table:
        properties:
          - Name
          - DomainName
          - ProvisioningState
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
      subject: WebPubSubHub
      parameter-name: HubName
    set:
      parameter-name: Name
      alias: HubName
  - where:
      subject: WebPubSub
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias: ResourceName
  - where:
      subject: WebPubSubCustomCertificate
      parameter-name: CertificateName
    set:
      parameter-name: Name
      alias: CertificateName
# Disable Inline on the Baseclass(Model).
  - no-inline:
    - EventListenerEndpoint
    - EventListenerFilter
```

## Azure Web PubSub custom development guidance

This chapter contains development guidance specific to Azure Web PubSub service.

### Generate error handling customization code

The default error handling logic only prints the message field of the `ErrorResponse`. However, it's usually not enough for our services where we have to combine the `target` and `message` fields to figure out how to fix the error. Therefore, we should run the script "resources\GenerateCustomErrorHandling.ps1" to generate error handling customization code for each cmdlets. If you have written other csharp customization logic, take care because the script overrides the current files.
