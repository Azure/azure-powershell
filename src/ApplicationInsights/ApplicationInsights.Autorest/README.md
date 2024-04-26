<!-- region Generated -->
# Az.ApplicationInsights
This directory contains the PowerShell module for the ApplicationInsights service.

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
For information on how to develop for `Az.ApplicationInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
commit: 60be34ab72f1483aef8feede852bc9f2f1921897
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2022-06-15/webTests_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2020-02-02/components_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentApiKeys_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentAnnotations_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentFeaturesAndPricing_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2015-05-01/componentContinuousExport_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2020-03-01-preview/componentLinkedStorageAccounts_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2021-03-08/workbookOperations_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2020-11-20/workbookTemplates_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2021-03-08/myworkbooks_API.json
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/stable/2022-04-01/workbooks_API.json
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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

  # For resolve breaking change issue.
  - from: swagger-document
    where: $.definitions.WebTestProperties.properties.Kind.x-ms-enum
    transform: >-
      return {
            "name": "WebTestKindEnum",
            "modelAsString": false
          }

  # microsoft.insights is the service response.
  - from: swagger-document
    where: $
    transform: return $.replace(/providers\/Microsoft.Insights\//g, "providers/microsoft.insights/")

  - from: swagger-document
    where: $.definitions.WorkbookTemplateProperties.properties.templateData
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "Valid JSON object containing workbook template payload."
      }
  # Add 200 status code.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.insights/myWorkbooks/{resourceName}"].patch.responses
    transform: >-
      return {
          "200": {
            "description": "The private workbook definition updated.",
            "schema": {
              "$ref": "#/definitions/MyWorkbook"
            }
          },
          "201": {
            "description": "The private workbook definition updated.",
            "schema": {
              "$ref": "#/definitions/MyWorkbook"
            }
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/MyWorkbookError"
            }
          }
        }

  - where:
      subject: WebTest
      verb: Set
    remove: true

  - where:
      subject: MyWorkbook|Workbook|WorkbookTemplate
      verb: Set
    remove: true
  # Response schema does not map defined in the swagger.
  - where:
      verb: Get
      subject: WorkbookTemplate
      variant: ^List$
    remove: true
  # The resource id of the Microsoft.Insights/myworkbooks does not match the path defined in swagger. 
  - where:
      verb: Get
      subject: ^MyWorkbook$
      variant: ^GetViaIdentity$
    remove: true

  - where:
      subject: ^ApiKey$|^ContinuousExport$|LinkedStorageAccount|^WebTest$|^WebTestTag$|^Workbook$|^WorkbookTemplate$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  # The resource id of the Microsoft.Insights/myworkbooks does not match the path defined in swagger. 
  - where:
      subject: ^MyWorkbook$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^UpdateExpanded$|^UpdateViaIdentityExpanded$|^UpdateViaIdentity$|^DeleteViaIdentity$
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
  # ResourceName value will auto assign to the name on service.
  - where:
      subject: MyWorkbook|Workbook
      parameter-name: Name
    hide: true
    set:
      parameter-name: HideName

  - where:
      subject: MyWorkbook|Workbook
      parameter-name: ResourceName
    set:
      parameter-name: Name

  - where:
      subject: MyWorkbook|Workbook
      parameter-name: SourceId
    set:
      parameter-name: LinkedSourceId

  - where:
      subject: MyWorkbook|Workbook
      parameter-name: PropertiesSourceId
    set:
      parameter-name: SourceId

  - where:
      subject: MyWorkbook|Workbook
      parameter-name: PropertiesTag
    set:
      parameter-name: SourceTag

  - where:
      subject: MyWorkbook
      parameter-name: Kind
    hide: true
    set:
      default:
        script: '"user"'
  
  - where:
      subject: Workbook
      parameter-name: Kind
    hide: true
    set:
      default:
        script: '"shared"'
  # Hide command for custom command.
  - where:
      verb: New
      subject: ^WebTest$
    hide: true

  - model-cmdlet:
    - WebTestGeolocation
    - WorkbookTemplateGallery
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
  - where:
      model-name: MyWorkbook|Workbook
    set:
      format-table:
        properties:
          - ResourceGroupName
          - Name
          - DisplayName
          - Location
          - Kind
          - Category
```
