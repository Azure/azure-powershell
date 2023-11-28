<!-- region Generated -->
# Az.ChangeAnalysis
This directory contains the PowerShell module for the ChangeAnalysis service.

---
## Status
[![Az.ChangeAnalysis](https://img.shields.io/powershellgallery/v/Az.ChangeAnalysis.svg?style=flat-square&label=Az.ChangeAnalysis "Az.ChangeAnalysis")](https://www.powershellgallery.com/packages/Az.ChangeAnalysis/)

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
For information on how to develop for `Az.ChangeAnalysis`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
branch: 4b131739f528aea3da3ee4f6874da20602629432
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/changeanalysis/resource-manager/Microsoft.ChangeAnalysis/stable/2021-04-01/changeanalysis.json

title: ChangeAnalysis
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  - from: swagger-document 
    where: $.paths["/{resourceId}/providers/Microsoft.ChangeAnalysis/resourceChanges"].post.summary
    transform: >-
      return "Customer data is always masked if query at subscription or resource group level. For query on a single resource, customer data is masked if the user doesn’t have access."
      
  # Merged cmdlet because the response of two get-* cmdlet are same.
  - from: swagger-document 
    where: $.paths["/{resourceId}/providers/Microsoft.ChangeAnalysis/resourceChanges"].post.operationId
    transform: >-
      return "ChangeAnalysis_ListByResourceId"
 
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ChangeAnalysis/changes"].get.operationId
    transform: >-
      return "ChangeAnalysis_ListByResourceGroup"

  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.ChangeAnalysis/changes"].get.operationId
    transform: >-
      return "ChangeAnalysis_ListBySubscription"
  
```
