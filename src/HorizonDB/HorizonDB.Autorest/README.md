<!-- region Generated -->
# Az.HorizonDB
This directory contains the PowerShell module for the HorizonDB service.

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
For information on how to develop for `Az.HorizonDB`, see [how-to.md](how-to.md).
<!-- endregion -->

---
### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# Pin the API specifications for reproducible generation.
commit: 72b226daeb4cc47c55d8a50a7211c881fe98bf23

require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/horizondb/resource-manager/readme.md

try-require:
  - $(repo)/specification/horizondb/resource-manager/readme.powershell.md

input-file:
  - $(repo)/specification/horizondb/resource-manager/Microsoft.HorizonDb/HorizonDb/preview/2026-10-01-preview/openapi.json

module-version: 0.1.0

title: HorizonDB
service-name: HorizonDB
subject-prefix: $(service-name)

directive:
  # Avoid credential-scanner false positives in generated password-authentication parameter help.
  - where:
      subject: PasswordAuthentication
      parameter-name: State
    set:
      parameter-description: Specifies whether PostgreSQL credential-based authentication is enabled or disabled.

  # Keep expanded and JSON input variants instead of model-based create/update variants.
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true

  # Exclude create-via-identity variants from the initial cmdlet surface.
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # Use Update cmdlets rather than exposing replacement-style Set cmdlets.
  - where:
      verb: Set
    remove: true
```
