<!-- region Generated -->
# Az.AppComplianceAutomation
This directory contains the PowerShell module for the AppComplianceAutomation service.

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
For information on how to develop for `Az.AppComplianceAutomation`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: 12ff37009808948b5c7ed4a0d384181471f3219f
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/appcomplianceautomation/resource-manager/readme.md
input-file:
  - $(repo)/specification/appcomplianceautomation/resource-manager/Microsoft.AppComplianceAutomation/stable/2024-06-27/appcomplianceautomation.json

module-version: 0.1.0
title: AppComplianceAutomation

directive:
  - where:
      variant: ^GetViaIdentity$|^GetViaIdentityReport$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^DeleteViaIdentity$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
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
  - from: swagger-document
    where:
      - $.paths["/providers/Microsoft.AppComplianceAutomation/reports/{reportName}"].delete.responses
    transform: >-
      $["200"] = {
            "description": "Success. The response indicates the resource has been deleted."
          }

```
