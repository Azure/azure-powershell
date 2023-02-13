<!-- region Generated -->
# Az.Workloads
This directory contains the PowerShell module for the Workloads service.

---
## Status
[![Az.Workloads](https://img.shields.io/powershellgallery/v/Az.Workloads.svg?style=flat-square&label=Az.Workloads "Az.Workloads")](https://www.powershellgallery.com/packages/Az.Workloads/)

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
For information on how to develop for `Az.Workloads`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - C:/Users/v-diya/repository/azure-rest-api-specs-pr/specification/workloads/resource-manager/readme.md

try-require: 
  - C:/Users/v-diya/repository/azure-rest-api-specs-pr/specification/workloads/resource-manager/readme.powershell.md

identity-correction-for-post: true
nested-object-to-string: true
inlining-threshold: 50

directive:

- no-inline:  # choose ONE of these models to disable inlining
  - Monitor
  - MonitorProperties
  - Error
  - ErrorInnerError
```
