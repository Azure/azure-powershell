<!-- region Generated -->
# Az.Orbital
This directory contains the PowerShell module for the Orbital service.

---
## Status
[![Az.Orbital](https://img.shields.io/powershellgallery/v/Az.Orbital.svg?style=flat-square&label=Az.Orbital "Az.Orbital")](https://www.powershellgallery.com/packages/Az.Orbital/)

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
For information on how to develop for `Az.Orbital`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: eb606ec7a7abadc78ded1423ddbea9e8f49e72c3
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/orbital/resource-manager/Microsoft.Orbital/stable/2022-03-01/orbital.json

module-version: 0.1.0
title: Orbital
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  - from: swagger-document 
    where: $.definitions.SpacecraftsProperties.properties.provisioningState
    transform: >-
      return {
        "type": "string",
        "readOnly": true,
        "allOf": [
          {
            "$ref": "#/definitions/ProvisioningState"
          }
        ],
        "description": "The current state of the resource's creation, deletion, or modification."
      }
  - from: swagger-document 
    where: $.definitions.ContactsProperties.properties.provisioningState
    transform: >-
      return {
        "type": "string",
        "readOnly": true,
        "allOf": [
          {
            "$ref": "#/definitions/ProvisioningState"
          }
        ],
        "description": "The current state of the resource's creation, deletion, or modification."
      }
  - from: swagger-document 
    where: $.definitions.ContactProfilesProperties.properties.provisioningState
    transform: >-
      return {
        "type": "string",
        "readOnly": true,
        "allOf": [
          {
            "$ref": "#/definitions/ProvisioningState"
          }
        ],
        "description": "The current state of the resource's creation, deletion, or modification."
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Orbital/locations/{location}/operationResults/{operationId}"].get
    transform: >-
      return {
        "tags": [
          "OperationResults"
        ],
        "description": "Returns operation results.",
        "operationId": "OperationsResults_Get",
        "x-ms-examples": {
          "KustoOperationResultsGet": {
            "$ref": "./examples/OperationResultsGet.json"
          }
        },
        "parameters": [
          {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/eb606ec7a7abadc78ded1423ddbea9e8f49e72c3/specification/common-types/resource-management/v3/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "#/parameters/apiVersionParameter"
          },
          {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/eb606ec7a7abadc78ded1423ddbea9e8f49e72c3/specification/common-types/resource-management/v3/types.json#/parameters/LocationParameter"
          },
          {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/eb606ec7a7abadc78ded1423ddbea9e8f49e72c3/specification/common-types/resource-management/v3/types.json#/parameters/OperationIdParameter"
          }
        ],
        "responses": {
          "200": {
            "description": "Successfully retrieved the operation result.",
            "schema": {
              "$ref": "#/definitions/OperationResult"
            }
          },
          "202": {
            "description": "The operation is still in progress.",
            "headers": {
              "Location": {
                "type": "string",
                "description": "URL for determining when an operation has completed."
              }
            }
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/CloudError"
            }
          }
        }
      }
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      subject: OperationsResult
    remove: true
  - where:
      subject: Contact
    set:
      subject: SpacecraftContact
  - where:
      subject: SpacecraftAvailableContact
    set:
      subject: AvailableSpacecraftContact
  - where:
      subject: ContactProfileTag
    set:
      subject: ContactProfile
  - where:
      subject: SpacecraftTag
    set:
      subject: Spacecraft
  - where:
      verb: Update
      subject: ContactProfile
      parameter-name: ContactProfileName
    set:
      parameter-name: Name
  - where:
      verb: Update
      subject: Spacecraft
      parameter-name: SpacecraftName
    set:
      parameter-name: Name
  - where:
      subject: AvailableSpacecraftContact
      parameter-name: SpacecraftName
    set:
      parameter-name: Name
      alias: SpacecraftName
  - where:
      subject: AvailableGroundStation
      parameter-name: GroundStationName
    set:
      parameter-name: Name
      alias: GroundStationName
  # The following are commented out and their generated cmdlets may be renamed and custom logic
  # - model-cmdlet:
  #     - ContactProfileLinkChannel
  #     - SpacecraftLink
  #     - ContactProfileLink
  - where:
      model-name: Spacecraft
    set:
      format-table:
        properties:
          - Name
          - Location
          - NoradId
          - TitleLine
          - ResourceGroupName
  - where:
      model-name: ContactProfile
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: Contact
    set:
      format-table:
        properties:
          - Name
          - GroundStationName
          - Status
          - ReservationStartTime
          - ReservationEndTime
          - ResourceGroupName
  - where:
      model-name: AvailableGroundStation
    set:
      format-table:
        properties:
          - Location
          - Name
          - ProviderName
          - City
  - where:
      model-name: AvailableContacts
    set:
      format-table:
        properties:
          - GroundStationName
          - StartAzimuthDegree
          - EndAzimuthDegree
          - StartElevationDegree
          - EndElevationDegree
          - MaximumElevationDegree
          - RxStartTime
          - RxEndTime
```
