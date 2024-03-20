<!-- region Generated -->
# Az.DevCenter
This directory contains the PowerShell module for the DevCenter service.

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
For information on how to develop for `Az.DevCenter`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: b5e14f2fcc1e0de74c4dcf1d6e518f9faf743417
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/preview/2023-10-01-preview/commonDefinitions.json
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/preview/2023-10-01-preview/devcenter.json
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/preview/2023-10-01-preview/vdi.json
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}/sync"].post.responses
    transform: >
      $['200'] = {
        "description": "OK. Successfully initiated sync."
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/galleries/{galleryName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/Gallery"}
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/attachednetworks/{attachedNetworkConnectionName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/AttachedNetworkConnection"}
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}"].put.responses
    transform: >
      $['200'] = {
        "description": "OK. The request has succeeded.",
        "schema": {"$ref": "#/definitions/Catalog"}
      }
  - where:
      parameter-name: Top
    hide: true
  - where:
      parameter-name: Filter
    hide: true
  - where:
      subject: Schedule
      parameter-name: Frequency
    hide: true
    set:
      default:
        script: '"Daily"'
  - where:
      subject: Schedule
      parameter-name: PropertiesType
    hide: true
    set:
      default:
        script: '"StopDevBox"'
  - where:
      subject: Schedule
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'
  - where:
      subject: Schedule
    hide: true
  - where:
      subject: Pool
      parameter-name: LicenseType
    hide: true
    set:
      default:
        script: '"Windows_Client"'
  - where:
      verb: New
      subject: Pool
      parameter-name: LicenseType
    hide: true
    set:
      default:
        script: '"Windows_Client"'
  - where:
      subject: DevCenter
      parameter-name: CustomerManagedKeyEncryptionKeyUrl
    hide: true
  - where:
      subject: DevCenter
      parameter-name: KeyEncryptionKeyIdentityDelegatedIdentityClientId
    hide: true
  - where:
      subject: DevCenter
      parameter-name: KeyEncryptionKeyIdentityType
    hide: true
  - where:
      subject: DevCenter
      parameter-name: KeyEncryptionKeyIdentityUserAssignedIdentityResourceId
    hide: true
# Remove Set per design review
  - where:
      verb: Set
    remove: true
# Remove extra input object variant 
  - where:
      verb: Get 
      subject:  ^(AttachedNetwork|DevBoxDefinition|NetworkConnectionHealthDetail)$
      variant: GetViaIdentity1
    remove: true
  - where:
      verb: Get 
      subject:  NetworkConnectionHealthDetail
      variant: Get
    remove: true
# Matches any verb that is set
  - where:
      verb: Set
    hide: true
# Hide schedule commands
  - where:
      subject: Schedule
    hide: true
# Remove body variant
  - where:
      verb: Update
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: New
      variant: ^Create$|^CreateViaIdentity$
    remove: true
  - where:
      verb: Invoke
      subject: ExecuteCheckNameAvailability
      variant: ^Execute$|^ExecuteViaIdentity$
    remove: true
# Set required parameters    
  - where:
      verb: New
      subject:  AttachedNetwork
      parameter-name: NetworkConnectionId
    required: true
# Remove parameter
  - where:
      verb: Update
      parameter-name: Location
    hide: true
  - where:
      verb: Update
      subject: Project
      parameter-name: DevCenterId
    hide: true
  - where:
      verb: New
      subject: ^AttachedNetwork$|^Catalog$|^DevBoxDefinition$|^Gallery$|^NetworkConnection$|^Pool$|^Project$|^ProjectEnvironmentType$
    hide: true
  - where:
      subject: ^CatalogDevBoxDefinition$|^CatalogDevBoxDefinitionErrorDetail$|^CustomizationTask|^CustomizationTaskErrorDetail$
    hide: true
  - where:
      verb: Connect
      subject: Catalog
    hide: true
  - where:
      subject: OperationStatuses
    set:
      subject: OperationStatus
  - where:
      subject: ^(.*)
    set:
      subject-prefix: DevCenterAdmin
```
