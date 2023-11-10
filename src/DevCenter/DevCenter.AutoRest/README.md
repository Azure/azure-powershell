<!-- region Generated -->
# Az.DevCenter
This directory contains the PowerShell module for the DevCenter service.

---
## Status
[![Az.DevCenter](https://img.shields.io/powershellgallery/v/Az.DevCenter.svg?style=flat-square&label=Az.DevCenter "Az.DevCenter")](https://www.powershellgallery.com/packages/Az.DevCenter/)

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
branch: 4f6418dca8c15697489bbe6f855558bb79ca5bf5
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/stable/2023-04-01/commonDefinitions.json
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/stable/2023-04-01/devcenter.json
  - $(repo)/specification/devcenter/resource-manager/Microsoft.DevCenter/stable/2023-04-01/vdi.json
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
# Remove Set per design review
  - where:
      verb: Set
    remove: true
# API not available yet
  - where:
      verb: Start
      subject: PoolHealthCheck
    hide: true
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
      subject: OperationStatuses
    set:
      subject: OperationStatus
  - where:
      subject: ^(.*)
    set:
      subject-prefix: DevCenterAdmin
```
