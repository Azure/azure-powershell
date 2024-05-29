<!-- region Generated -->
# Az.HealthcareApis
This directory contains the PowerShell module for the HealthcareApis service.

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
For information on how to develop for `Az.HealthcareApis`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 672281444dd67605420fc9b3bcbd170040708380
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/healthcareapis/resource-manager/Microsoft.HealthcareApis/stable/2021-11-01/healthcare-apis.json

module-version: 0.3.0
title: HealthcareApis
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true

metadata: 
  tags: Azure ResourceManager ARM PSModule $(service-name) HealthCare FhirService

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
      subject: Workspace
    set:
      subject: ApisWorkspace
  - where:
      subject: Service
    set:
      subject: ApisService
  - where:
      subject: ^ApisService$
      parameter-name: ResourceName
    set:
      parameter-name: Name
  - where:
      parameter-name: AccessPolicy
    set:
      parameter-name: AccessPolicyObjectId
  - where:
      parameter-name: CorConfigurationAllowCredentials
    set:
      parameter-name: AllowCorsCredential
  - where:
      parameter-name: AuthenticationConfigurationAudience
    set:
      parameter-name: Audience
  - where:
      parameter-name: AuthenticationConfigurationAuthority
    set:
      parameter-name: Authority
  - where:
      parameter-name: CorConfigurationHeader
    set:
      parameter-name: CorsHeader
  - where:
      parameter-name: CorConfigurationMaxAge
    set:
      parameter-name: CorsMaxAge
  - where:
      parameter-name: CorConfigurationMethod
    set:
      parameter-name: CorsMethod
  - where:
      parameter-name: CorConfigurationOrigin
    set:
      parameter-name: CorsOrigin
  - where:
      parameter-name: CosmoDbConfigurationOfferThroughput
    set:
      parameter-name: CosmosOfferThroughput
  - where:
      parameter-name: CosmoDbConfigurationKeyVaultKeyUri
    set:
      parameter-name: CosmosKeyVaultKeyUri
  - where:
      parameter-name: AuthenticationConfigurationSmartProxyEnabled
    set:
      parameter-name: EnableSmartProxy
  - where:
      parameter-name: ExportConfigurationStorageAccountName
    set:
      parameter-name: ExportStorageAccountName
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
      model-name: ServicesDescription
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
  - where:
      model-name: IotFhirDestination
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - from: swagger-document 
    where: $.definitions.IotMappingProperties.properties.content
    transform: >-
      return {
          "description": "The mapping.",
          "additionalProperties": true
      }
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthcareApis/services/{resourceName}"].delete.responses
    transform: >-
      return {
          "200": {
            "description": "The request was successful; the request was well-formed and received properly."
          },
          "202": {
            "description": "Accepted - Delete request accepted; the operation will complete asynchronously."
          },
          "204": {
            "description": "The resource does not exist."
          },
          "default": {
            "description": "DefaultErrorResponse",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/672281444dd67605420fc9b3bcbd170040708380/specification/healthcareapis/resource-manager/Microsoft.HealthcareApis/stable/2021-11-01/healthcare-apis.json#/definitions/ErrorDetails"
            }
          }
      }
  - where:
      verb: New
      subject: ApisService
    hide: true
  - where:
      verb: New
      subject: ApisWorkspace
    hide: true
  - where:
      verb: New
      subject: DicomService
    hide: true
  - where:
      verb: New
      subject: FhirService
    hide: true
  - where:
      verb: New
      subject: IotConnector
    hide: true
  - where:
      verb: New
      subject: IotConnectorFhirDestination
    hide: true
```
