<!-- region Generated -->
# Az.ApplicationInsights
This directory contains the PowerShell module for the ApplicationInsights service.

---
## Status
[![Az.ApplicationInsights](https://img.shields.io/powershellgallery/v/Az.ApplicationInsights.svg?style=flat-square&label=Az.ApplicationInsights "Az.ApplicationInsights")](https://www.powershellgallery.com/packages/Az.ApplicationInsights/)

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
For information on how to develop for `Az.ApplicationInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
branch: e1eca381eca8ec1f80b722e5dbf060fdeef48653
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2018-05-01-preview/webTests_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/9735d8c1580e6b56e6d4508be6ec00f46e45cb77/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2020-02-02/components_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e129012901bbd9cc0f182ec5b539bccf2440ef4a/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentApiKeys_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8f0d54f788304518eca62ddf281b8c889ad9613c/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentAnnotations_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e129012901bbd9cc0f182ec5b539bccf2440ef4a/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentFeaturesAndPricing_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e129012901bbd9cc0f182ec5b539bccf2440ef4a/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentContinuousExport_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e129012901bbd9cc0f182ec5b539bccf2440ef4a/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/aiOperations_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/88e7838a09868a51de3894114355c75929847a46/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2020-03-01-preview/componentLinkedStorageAccounts_API.json
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - from: swagger-document
    where: $.info.title
    transform: return "ApplicationInsightsManagementClient"

  #  Kind 'basic' is not supported on the server.
  - from: swagger-document
    where: $.definitions.WebTestProperties.properties.Kind.enum
    transform: >-
      return [
        "ping",
        "multistep",
        "standard"
      ]
  - from: swagger-document
    where: $.definitions.WebTestProperties.properties.Kind.description
    transform: return "The kind of web test this is, valid choices are ping, multistep, and standard."

  # microsoft.insights is the service response.
  - from: swagger-document
    where: $
    transform: return $.replace(/providers\/Microsoft.Insights\//g, "providers/microsoft.insights/")

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  # Hide ComponentCurrentBillingFeature related cmdlets
  - where:
      subject: ComponentCurrentBillingFeature|ComponentQuotaStatus
    hide: true

  # Rename ExportConfiguration to ContinuousExport
  - where:
      subject: ExportConfiguration
    set:
      subject: ContinuousExport

  # Rename parameter 'ResourceName' to 'Name'
  - where:
      subject: ApiKey
      verb: New
      parameter-name: Name
    set:
      parameter-name: Description
  - where:
      subject: ApiKey|ContinuousExport|Component
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias: 
        - ApplicationInsightsComponentName
        - ComponentName

  # Hide ApplicationInsightsComponent related cmdlets
  - where:
      subject: Component
      verb: Get|New|Clear|Set
    hide: true
  # Rename Component related cmdlets  
  - where:
      subject: (^Component$)(.*)
    set:
      subject: $2

  # Rename parameters for New|Set ApplicationInsightsExportConfiguration
  - where:
      subject: ContinuousExport
      verb: New|Set
      parameter-name: DestinationAccountId
    set:
      parameter-name: StorageAccountId
  - where:
      subject: ContinuousExport
      verb: New|Set
      parameter-name: DestinationAddress
    set:
      parameter-name: StorageSASUri
  - where:
      subject: ContinuousExport
      verb: New|Set
      parameter-name: DestinationStorageLocationId
    set:
      parameter-name: StorageLocation
  - where:
      subject: ContinuousExport
      verb: New|Set
      parameter-name: RecordTypes
    set:
      parameter-name: DocumentType
  - where:
      subject: ContinuousExport
      verb: New|Set
    hide: true

  # Rename parameters for ComponentLinkedStorageAccount
  - where:
      subject: ComponentLinkedStorageAccountAndUpdate
    set:
      subject: ComponentLinkedStorageAccount
  - where:
      subject: ComponentLinkedStorageAccount
      parameter-name: ResourceName
    set:
      parameter-name: ComponentName
  - where:
      subject: ComponentLinkedStorageAccount
      parameter-name: LinkedStorageAccount
    set:
      parameter-name: LinkedStorageAccountResourceId
  - where:
      subject: ComponentLinkedStorageAccount
    set:
      subject: LinkedStorageAccount

  # Rename parameter 'KeyId' to 'ApiKeyId'
  - where:
      subject: ApiKey
      verb: Get|Remove
      parameter-name: KeyId
    set:
      parameter-name: ApiKeyId

  # Rename parameter 'InputObject' to 'ApplicationInsightsComponent'
  - where:
      subject: ApiKey|ContinuousExport
      verb: Get|Remove
      parameter-name: InputObject
    set:
      parameter-name: ApplicationInsightsComponent

  # Hide New-AzApplicationInsightsApiKey for customization
  - where:
      subject: ApiKey
      verb: New
    hide: true

  # Hide cmdlets
  - where:
      subject: Annotation|AvailableFeature|FeatureCapability|PurgeStatus|ComponentTag
    hide: true

  # Hide the SyntheticMonitorId parameter because the default value is passed by the server.
  - where:
      verb: New
      subject: WebTest
      parameter-name: SyntheticMonitorId
    hide: true

  # Hide the Kind parameter because the WebKind override it.
  - where:
      verb: New
      subject: WebTest
      parameter-name: Kind
    set:
      parameter-name: HideKind
  - where:
      verb: New
      subject: WebTest
      parameter-name: HideKind
    hide: true
  # rename WebTestKind to Kind  
  - where:
      verb: New
      subject: WebTest
      parameter-name: WebTestKind
    set:
      parameter-name: Kind

  # Rename parameters
  - where:
      verb: Get
      subject: WebTest
      parameter-name: ComponentName
    set:
      parameter-name: AppInsightsName

  - where:
      verb: New
      subject: WebTest
      parameter-name: PropertiesLocations
    set:
      parameter-name: GeoLocation

  - where:
      verb: New
      subject: WebTest
      parameter-name: PropertiesWebTestName
    set:
      parameter-name: TestName

  - where:
      verb: New
      subject: WebTest
      parameter-name: ConfigurationWebTest
    set:
      parameter-name: Configuration

  - where:
      verb: New
      subject: WebTest
      parameter-name: ContentValidationContentMatch
    set:
      parameter-name: ContentMatch

  - where:
      verb: New
      subject: WebTest
      parameter-name: (.*)Validation(.*)
    set:
      parameter-name: $1$2
  - where:
      verb: New
      subject: WebTest
      parameter-name: RequestParseDependentRequest
    set:
      parameter-name: RequestParseDependent

  - where:
      verb: Update
      subject: WebTestTag
      parameter-name: WebTestName
    set:
      parameter-name: Name

  # Hide command for custom command.
  - where:
      verb: New
      subject: ^WebTest$
    hide: true

  - model-cmdlet:
    - WebTestGeolocation
    # Hide for custom modle cmdlet.
    # - HeaderField
  
  # format output table
  - where:
      model-name: WebTest
    set:
      format-table:
        properties:
          - Name
          - Location
          - WebTestKind
          - Enabled
```
