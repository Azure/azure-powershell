<!-- region Generated -->
# Az.Security
This directory contains the PowerShell module for the Security service.

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
For information on how to develop for `Az.Security`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

###
``` yaml
commit: 6c4497e6b0aaad8127f2dd50fa8a29aaf68f24e6
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/security/resource-manager/Microsoft.Security/preview/2022-12-01-preview/defenderForStorageSettings.json

title: Security
module-version: 1.5.1
subject-prefix: $(service-name)
enable-parent-pipeline-input: false

directive:  

  - where:
      variant: ^GetViaIdentity$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$|^Update$
    remove: true
  
  - where:
      verb: New
    remove: true

```
