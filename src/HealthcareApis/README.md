<!-- region Generated -->
# Az.HealthcareApis
This directory contains the PowerShell module for the HealthcareApis service.

---
## Status
[![Az.HealthcareApis](https://img.shields.io/powershellgallery/v/Az.HealthcareApis.svg?style=flat-square&label=Az.HealthcareApis "Az.HealthcareApis")](https://www.powershellgallery.com/packages/Az.HealthcareApis/)

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
For information on how to develop for `Az.HealthcareApis`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 672281444dd67605420fc9b3bcbd170040708380
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/healthcareapis/resource-manager/Microsoft.HealthcareApis/stable/2021-11-01/healthcare-apis.json

module-version: 0.3.0
title: HealthcareApis
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true

directive:
  - where:
      subject-prefix: (^HealthcareApis)(.*)
    set:
      subject-prefix: Healthcare$2
  - from: swagger-document
    where: $
    transform: return $.replace(/ErrorDetailsInternal/g, "InternalErrorDetails")
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      subject: OperationResult
    hide: true
  - where:
      subject: PrivateEndpointConnection
    hide: true
  - where:
      subject: PrivateLinkResource
    hide: true
  - where:
      subject: WorkspacePrivateEndpointConnection
    hide: true
  - where:
      subject: WorkspacePrivateLinkResource
    hide: true
  - where:
      subject: IotConnectorFhirDestination
    hide: true
  - where:
      subject: Workspace
    set:
      subject: APIsWorkspace
  - where:
      subject: Service
    set:
      subject: APIsService
  - where:
      model-name: Workspace
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: DicomService
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: FhirService
    set:
      format-table:
        properties:
          - Location
          - Name
          - Kind
          - ResourceGroupName
  - where:
      model-name: IotConnector
    set:
      format-table:
        properties:
          - Location
          - Name
          - Kind
          - ResourceGroupName

  - from: swagger-document 
    where: $.definitions.IotMappingProperties.properties.content
    transform: >-
      return {
          "description": "The mapping.",
          "additionalProperties": true
      }
```
