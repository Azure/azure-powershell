<!-- region Generated -->
# Az.AppComplianceAutomation
This directory contains the PowerShell module for the AppComplianceAutomation service.

---
## Status
[![Az.AppComplianceAutomation](https://img.shields.io/powershellgallery/v/Az.AppComplianceAutomation.svg?style=flat-square&label=Az.AppComplianceAutomation "Az.AppComplianceAutomation")](https://www.powershellgallery.com/packages/Az.AppComplianceAutomation/)

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
For information on how to develop for `Az.AppComplianceAutomation`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
branch: a80de12c16d6d9c3545bdc3e2b6c1d4ca6739876
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - https://github.com/qinzhouxu/azure-rest-api-specs-pr/blob/5f310a45620b4cebdf9c243b56afe98c5d4ce2cf/specification/appcomplianceautomation/resource-manager/readme.md
try-require: 
  - https://github.com/qinzhouxu/azure-rest-api-specs-pr/blob/5f310a45620b4cebdf9c243b56afe98c5d4ce2cf/specification/appcomplianceautomation/resource-manager/readme.powershell.md
input-file:
  - https://github.com/qinzhouxu/azure-rest-api-specs-pr/blob/5f310a45620b4cebdf9c243b56afe98c5d4ce2cf/specification/appcomplianceautomation/resource-manager/Microsoft.AppComplianceAutomation/preview/2023-02-15-preview/appcomplianceautomation.json

module-version: 0.1.0
title: AppComplianceAutomation

directive:
  - where:
      variant: ^GetViaIdentity$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^DeleteViaIdentity$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true
  - where:
      verb: Set|Sync|Test
    remove: true
  - where:
      verb: Get|Invoke|New|Remove|Start|Update
    hide: true
  - from: swagger-document
    where:
      - $.paths["/providers/Microsoft.AppComplianceAutomation/onboard"].post.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/triggerEvaluation"].post.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports"].get.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}"].get.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}"].put.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}"].patch.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}"].delete.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/webhooks"].get.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/webhooks/{webhookName}"].get.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/webhooks/{webhookName}"].put.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/webhooks/{webhookName}"].patch.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/webhooks/{webhookName}"].delete.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/snapshots"].get.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/snapshots/{snapshotName}"].get.parameters
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/snapshots/{snapshotName}/download"].post.parameters
    transform: >-
      $.push({
            "name": "x-ms-aad-user-token",
            "type": "string",
            "in": "header"
          })

```
