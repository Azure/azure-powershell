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
  - $(this-folder)/../../specification/devcenter/resource-manager/Microsoft.DevCenter/stable/2023-04-01/commonDefinitions.json
  - $(this-folder)/../../specification/devcenter/resource-manager/Microsoft.DevCenter/stable/2023-04-01/devcenter.json
  - $(this-folder)/../../specification/devcenter/resource-manager/Microsoft.DevCenter/stable/2023-04-01/vdi.json
directive:
  - where:
      subject: ^(.*)
      parameter-name: Top
    hide: true
  - where:
      subject: ^(.*)
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
# Hide invoke name availability
  - where:
      verb: Invoke 
      subject: ExecuteCheckNameAvailability
    hide: true
  - where:
      subject: ^(.*)
# Hide Get Attached Network and Get DevBoxDefinition
  - where:
      verb: Get 
      subject:  ^(AttachedNetwork|DevBoxDefinition)$
    hide: true
# Matches any verb that is New, Update, Set
  - where:
      verb: ^(New|Update|Set)$
    hide: true
  - where:
      subject: ^(.*)
    set:
      subject-prefix: DevCenterAdmin
```
