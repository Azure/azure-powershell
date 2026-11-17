<!-- region Generated -->
# Az.ServiceGroups
This directory contains the PowerShell module for the ServiceGroups service.

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
For information on how to develop for `Az.ServiceGroups`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
# Pin to the commit containing the ServiceGroups swagger spec
commit: 7d9690b822b9c2c470e8fd89a781bdcd4a890731
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/management/resource-manager/Microsoft.Management/ServiceGroups/stable/2026-08-01/serviceGroups.json
# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ServiceGroups
# Remove subject-prefix to simplify cmdlet names
# e.g. Get-AzServiceGroupsServiceGroup becomes Get-AzServiceGroup
subject-prefix: ''

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # Remove the Set-* cmdlets as they are not supported
  - where:
      verb: Set
    remove: true
```
