<!-- region Generated -->
# Az.StreamAnalytics
This directory contains the PowerShell module for the StreamAnalytics service.

---
## Status
[![Az.StreamAnalytics](https://img.shields.io/powershellgallery/v/Az.StreamAnalytics.svg?style=flat-square&label=Az.StreamAnalytics "Az.StreamAnalytics")](https://www.powershellgallery.com/packages/Az.StreamAnalytics/)

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
For information on how to develop for `Az.StreamAnalytics`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2cba2ff0953d431b88a9fd4922de76157119e0/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2020-03-01-preview/clusters.json
  - https://github.com/Azure/azure-rest-api-specs/blob/f7fd049bbc0089ad8faa7dc1c89610ca8ad78c83/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/streamingjobs.json 
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2cba2ff0953d431b88a9fd4922de76157119e0/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/functions.json 
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2cba2ff0953d431b88a9fd4922de76157119e0/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/outputs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2cba2ff0953d431b88a9fd4922de76157119e0/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/inputs.json
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2cba2ff0953d431b88a9fd4922de76157119e0/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/transformations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2cba2ff0953d431b88a9fd4922de76157119e0/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/subscriptions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2cba2ff0953d431b88a9fd4922de76157119e0/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2017-04-01-preview/operations.json

title: StreamAnalytics
module-version: 2.0.1
subject-prefix: StreamAnalytics

directive:
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
# Hide cmdlets
  - where:
      verb: Set
    remove: true
# Rename cmdlet name
  - where:
      verb: Get|New|Remove|Update|Start|Stop
      subject: ^StreamingJob$
    set:
      subject: Job
# Rename parameter name
  - where:
      verb: Get
      subject: FunctionDefaultDefinition$
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
```
