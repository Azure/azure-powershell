<!-- region Generated -->
# Az.NetworkAnalytics
This directory contains the PowerShell module for the NetworkAnalytics service.

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
For information on how to develop for `Az.NetworkAnalytics`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: c364b64a6b412ffd7507dea71ae53251d35748c1
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/networkanalytics/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/networkanalytics/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: NetworkAnalytics
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      subject: .*(?:DataType|Catalog).*
    remove: true
  - where:
      verb: Update
      subject: ^DataProduct$
    remove: true
  - where:
      verb: Invoke
      subject: ^RotateDataProductKey$
    remove: true
  - where:
      verb: New
      subject: ^DataProductStorageAccountSasToken$
    remove: true
  - where:
      subject: DataProductUserRole
      variant: ^(Add|Remove)(?!.*?Expanded)
    remove: true
  - where:
      model-name: RoleAssignmentDetail
    set:
      format-table:
        exclude-properties:
          - DataTypeScope
  # Add 200 status code response for DataProduct delete operation.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkAnalytics/dataProducts/{dataProductName}"].delete.responses
    transform: >-
      return {
          "200": {
            "description": "Resource deleted successfully."
          },
          "204": {
            "description": "Resource deleted successfully."
          },
          "202": {
            "description": "Resource deletion accepted.",
            "headers": {
              "Retry-After": {
                "type": "integer",
                "format": "int32",
                "description": "The Retry-After header can indicate how long the client should wait before polling the operation status."
              },
              "Location": {
                "type": "string",
                "description": "The Location header contains the URL where the status of the long running operation can be checked."
              }
            }
          },
          "default": {
            "description": "An unexpected error response.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/c364b64a6b412ffd7507dea71ae53251d35748c1/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
            }
          }
        }
```
