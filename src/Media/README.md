<!-- region Generated -->
# Az.Media
This directory contains the PowerShell module for the Media service.

---
## Status
[![Az.Media](https://img.shields.io/powershellgallery/v/Az.Media.svg?style=flat-square&label=Az.Media "Az.Media")](https://www.powershellgallery.com/packages/Az.Media/)

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
For information on how to develop for `Az.Media`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: fe6e157bd3c7a7ba73a98ac492003bed60c195a8
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2022-08-01/streamingservice.json
  - $(repo)/specification/mediaservices/resource-manager/Microsoft.Media/Encoding/stable/2021-11-01/Encoding.json
  - $(repo)/specification/mediaservices/resource-manager/Microsoft.Media/Metadata/stable/2022-08-01/AccountFilters.json
  - $(repo)/specification/mediaservices/resource-manager/Microsoft.Media/Metadata/stable/2022-08-01/AssetsAndAssetFilters.json
  - $(repo)/specification/mediaservices/resource-manager/Microsoft.Media/Metadata/stable/2022-08-01/ContentKeyPolicies.json
  - $(repo)/specification/mediaservices/resource-manager/Microsoft.Media/Metadata/stable/2022-08-01/StreamingPoliciesAndStreamingLocators.json
  - $(repo)/specification/mediaservices/resource-manager/Microsoft.Media/Accounts/stable/2021-11-01/Accounts.json

module-version: 0.1.0
title: Media
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaservices/{accountName}"].put.responses.200.headers
    transform: >-
      return {
        "Retry-After": {
          "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.",
          "type": "integer",
          "format": "int32"
        }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaservices/{accountName}"].put.responses.201.headers
    transform: >-
      return {
        "Retry-After": {
          "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.",
          "type": "integer",
          "format": "int32"
        }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaservices/{accountName}"].patch.responses.202.headers
    transform: >-
      return {
        "Retry-After": {
          "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.",
          "type": "integer",
          "format": "int32"
        }
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Media/locations/{locationName}/mediaServicesOperationResults/{operationId}"].get.responses.202.headers
    transform: >-
      return {
        "Retry-After": {
          "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.",
          "type": "integer",
          "format": "int32"
        }
      }
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: Invoke
    set:
      verb: Get
  - where:
      subject: ^Mediaservice$
    set:
      subject: Service
  - where:
      subject: ^MediaserviceEdgePolicy$
    set:
      subject: ServiceEdgePolicy
  - where:
      subject: ^MediaserviceStorageKey$
    set:
      subject: ServiceStorageKey
# The following are commented out and their generated cmdlets may be renamed and custom logic
#   - model-cmdlet:
#       - StorageAccount
#       - TransformOutput
#       - TrackSelection
#       - StreamingPolicyContentKey
#       - StreamingLocatorContentKey
#       - IPRange
#       - AkamaiSignatureHeaderAuthenticationKey
#       - LiveEventEndpoint
#       - LiveEventTranscription
#       - JobOutput
#       - ContentKeyPolicyOption
#       - FilterTrackSelection
#       - TrackPropertyCondition
#       - LiveEventInputTrackSelection
#       - FilterTrackPropertyCondition
  - where:
      model-name: StorageAccount
    set:
      format-table:
        properties:
          - IdentityUseSystemAssignedIdentity
          - IdentityUserAssignedIdentity
  - where:
      model-name: MediaService
    set:
      format-table:
        properties:
          - Name
          - Location
          - ResourceGroupName
          - ProvisioningState
```
