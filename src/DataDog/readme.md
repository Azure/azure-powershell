<!-- region Generated -->
# Az.DataDog
This directory contains the PowerShell module for the DataDog service.

---
## Status
[![Az.DataDog](https://img.shields.io/powershellgallery/v/Az.DataDog.svg?style=flat-square&label=Az.DataDog "Az.DataDog")](https://www.powershellgallery.com/packages/Az.DataDog/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DataDog`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# branch: 28f4229b1e3b983450fd15ee8b2ec72c0b8be3ee
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - D:\azure-rest-api\azure-rest-api-specs-pr-RPSaaSMaster\specification\datadog\resource-manager\Microsoft.Datadog\preview\2020-02-01-preview\swagger.json
  # - https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/datadog/resource-manager/Microsoft.Datadog/preview/2020-02-01-preview/swagger.json 
  # - $(repo)/specification/resourcegraph/resource-manager/Microsoft.Datadog/preview/2020-02-01-preview/swagger.json

title: DataDog
module-version: 0.1.0
subject-prefix: $(service-name)
```
