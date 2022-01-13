<!-- region Generated -->
# Az.Monitor
This directory contains the PowerShell module for the Monitor service.

---
## Status
[![Az.Monitor](https://img.shields.io/powershellgallery/v/Az.Monitor.svg?style=flat-square&label=Az.Monitor "Az.Monitor")](https://www.powershellgallery.com/packages/Az.Monitor/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Monitor`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: b5667f3860aa0f739a35cd5a61dcc8e0a7086284
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2020-10-01/activityLogAlerts_API.json

module-version: 0.1.0
title: Monitor
subject-prefix: $(service-name)
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$|^Set$|^AddViaIdentity$|^Add$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
      subject: Account
    remove: true
```
