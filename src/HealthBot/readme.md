<!-- region Generated -->
# Az.HealthBot
This directory contains the PowerShell module for the HealthBot service.

---
## Status
[![Az.HealthBot](https://img.shields.io/powershellgallery/v/Az.HealthBot.svg?style=flat-square&label=Az.HealthBot "Az.HealthBot")](https://www.powershellgallery.com/packages/Az.HealthBot/)

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
For information on how to develop for `Az.HealthBot`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
Branch: 1aceb59fc10a1f9cf8b8da8d2a17dc5ce693604a
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/healthbot/resource-manager/Microsoft.HealthBot/stable/2020-12-08/healthbot.json

module-version: 0.1.0
title: HealthBot
service-name: HealthBot
subject-prefix: $(service-name)
identity-correction-for-post: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
```
