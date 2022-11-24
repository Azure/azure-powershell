<!-- region Generated -->
# Az.VoiceServices
This directory contains the PowerShell module for the VoiceServices service.

---
## Status
[![Az.VoiceServices](https://img.shields.io/powershellgallery/v/Az.VoiceServices.svg?style=flat-square&label=Az.VoiceServices "Az.VoiceServices")](https://www.powershellgallery.com/packages/Az.VoiceServices/)

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
For information on how to develop for `Az.VoiceServices`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - C:\Users\v-diya\repository\azure-rest-api-specs-pr\specification\voiceservices\resource-manager\Microsoft.VoiceServices\preview\2022-12-01-preview\openapi.json

subject-prefix: $(service-name)

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

```
