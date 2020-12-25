<!-- region Generated -->
# Az.Healthbot
This directory contains the PowerShell module for the Healthbot service.

---
## Status
[![Az.Healthbot](https://img.shields.io/powershellgallery/v/Az.Healthbot.svg?style=flat-square&label=Az.Healthbot "Az.Healthbot")](https://www.powershellgallery.com/packages/Az.Healthbot/)

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
For information on how to develop for `Az.Healthbot`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  # - https://github.com/guy-microsoft/azure-rest-api-specs/blob/healthbot-new-api/specification/healthbot/resource-manager/Microsoft.HealthBot/stable/2020-12-08/healthbot.json
  - $(this-folder)/resources/HealthBot.json

module-version: 0.1.0
title: Healthbot
service-name: Healthbot
subject-prefix: $(service-name)
identity-correction-for-post: true
```
