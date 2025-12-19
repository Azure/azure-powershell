<!-- region Generated -->
# Az.StreamAnalytics
This directory contains the PowerShell module for the StreamAnalytics service.

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
For information on how to develop for `Az.StreamAnalytics`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: f7fd049bbc0089ad8faa7dc1c89610ca8ad78c83
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2020-03-01-preview/clusters.json
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/streamingjobs.json 
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/functions.json 
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/outputs.json
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/inputs.json
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/transformations.json
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/subscriptions.json
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/operations.json

title: StreamAnalytics
module-version: 2.0.0
subject-prefix: StreamAnalytics
disable-transform-identity-type-for-operation:
  - StreamingJobs_Update

directive:
  - from: swagger-document
    where: $
    transform: $ = $.replace(/\/subscriptions\/\{subscriptionId\}\/resourcegroups\/\{resourceGroupName\}/g, "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}")

  # Deleted etag of the properties, because the etag exist in the response header.
  - from: swagger-document
    where: $.definitions.FunctionProperties.properties
    transform: delete $.etag
  - from: swagger-document
    where: $.definitions.InputProperties.properties
    transform: delete $.etag
  - from: swagger-document
    where: $.definitions.OutputProperties.properties
    transform: delete $.etag
  - from: swagger-document
    where: $.definitions.StreamingJobProperties.properties
    transform: delete $.etag
  - from: swagger-document
    where: $.definitions.TransformationProperties.properties
    transform: delete $.etag
# Modified the property name to readonly.  
  - from: swagger-document
    where: $.definitions.SubResource.properties
    transform: >-
      return {
        "id": {
          "readOnly": true,
          "type": "string",
          "description": "Resource Id"
        },
        "name": {
          "readOnly": true,
          "type": "string",
          "description": "Resource name"
        },
        "type": {
          "readOnly": true,
          "type": "string",
          "description": "Resource type"
        }
      }
  # Renaming executeEndpoint to endpoint
  - from: swagger-document
    where: $.definitions.AzureMachineLearningServiceFunctionBindingRetrievalProperties.properties
    transform: >-
      return {
        "endpoint": {
          "type": "string",
          "description": "The Request-Response execute endpoint of the Azure Machine Learning web service."
        },
        "udfType": {
          "$ref": "#/definitions/UdfType",
          "description": "The function type."
        }
      }
  # Fix the issue that remove operation finally result is that StatusCode is 404 and status is deleting.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StreamAnalytics/clusters/{clusterName}"].delete.responses
    transform: >-
      return {
          "200": {
            "description": "The cluster was successfully deleted."
          },
          "202": {
            "description": "The delete request was successfully initiated."
          },
          "204": {
            "description": "The cluster does not exist."
          },
          "404": {
            "description": "The cluster does not found."
          },
          "default": {
            "description": "Error.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/f7fd049bbc0089ad8faa7dc1c89610ca8ad78c83/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/common/v1/definitions.json#/definitions/Error"
            }
          }
        }

  # Changed csharp code
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/case "canceled":/g, 'case "canceled":\ncase "testsucceeded":\ncase "deleting":')
  
# Remove cmdlets
  - where:
      verb: Set
    remove: true

# Rename cmdlet name
  - where:
      verb: Get|New|Remove|Update|Start|Stop
      subject: ^StreamingJob$
    set:
      subject: Job
  - where:
      verb: Get
      subject: ^FunctionDefaultDefinition$
    set:
      subject: DefaultFunctionDefinition

# Hide cmdlets for custom
  - where:
      verb: New|Update
      subject: Job$
    hide: true
  - where:
      verb: New|Update
      subject: Function$
    hide: true
  - where:
      verb: New|Update
      subject: Input$
    hide: true
  - where:
      verb: New|Update
      subject: Output$
    hide: true
  - where:
      verb: Get
      subject: DefaultFunctionDefinition$
    hide: true
  - where:
      verb: Test
      subject: Input$
    hide: true
  - where:
      verb: Test
      subject: Output$
    hide: true
  - where:
      verb: Test
      subject: Function$
    hide: true

# Remove variant of cmdlet
  - where:
      verb: Start
      subject: Job$
      variant: ^Start$|^StartViaIdentity$
    remove: true
# Remove Create and update unexpanded variant of cmdlets
  - where:
      subject: ^Job$|Cluster$|Transformation$
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))|^CreateViaIdentityExpanded$
    remove: true

# Rename parameter name
  - where:
      verb: Get
      subject: DefaultFunctionDefinition$
      parameter-name: FunctionName
    set:
      parameter-name: Name
  - where:
      verb: Get|New|Remove|Update|Start|Stop
      subject: Job$
      parameter-name: JobName
    set:
      parameter-name: Name
  - where:
      verb: Get
      subject: SubscriptionQuota$
    set:
      subject: Quota

  - no-inline:
      - FunctionConfiguration
      - InputProperties
      - OutputDataSource
# Breaking Change
  - where:
      verb: Get
      subject: DefaultFunctionDefinition
    set:
        breaking-change:
          deprecated-output-properties:
            - Input
          new-output-properties:
            - Input
          change-description: The type of property Input will be changed from fixed array to 'List'.
          deprecated-by-version: 3.0.0
          deprecated-by-azversion: 15.0.0
          change-effective-date: 2025/11
  - where:
      verb: Get
      subject: Input
    set:
        breaking-change:
          deprecated-output-properties:
            - Condition
          new-output-properties:
            - Condition
          change-description: The type of property Condition will be changed from fixed array to 'List'.
          deprecated-by-version: 3.0.0
          deprecated-by-azversion: 15.0.0
          change-effective-date: 2025/11
  - where:
      verb: Get
      subject: Job
    set:
        breaking-change:
          deprecated-output-properties:
            - Input
            - Output
          new-output-properties:
            - Input
            - Output
          change-description: The types of the properties Input and Output will be changed from fixed array to 'List'.
          deprecated-by-version: 3.0.0
          deprecated-by-azversion: 15.0.0
          change-effective-date: 2025/11
  - where:
      verb: Get|New|Update
      subject: Output
    set:
        breaking-change:
          deprecated-output-properties:
            - DiagnosticCondition
          new-output-properties:
            - DiagnosticCondition
          change-description: The type of property DiagnosticCondition will be changed from fixed array to 'List'.
          deprecated-by-version: 3.0.0
          deprecated-by-azversion: 15.0.0
          change-effective-date: 2025/11
  - where:
      verb: Get
      subject: Quota
    set:
        breaking-change:
          deprecated-output-properties:
            - ISubscriptionQuota
          new-output-properties:
            - ISubscriptionQuotasListResult
          change-description: The type of property Quota will be changed from fixed array to 'List'.
          deprecated-by-version: 3.0.0
          deprecated-by-azversion: 15.0.0
          change-effective-date: 2025/11
  - where:
      verb: Update
      subject: Cluster
      parameter-name: Location
    set:
        breaking-change:
          change-description: The parameter Location will be removed.
          deprecated-by-version: 3.0.0
          deprecated-by-azversion: 15.0.0
          change-effective-date: 2025/11
```
