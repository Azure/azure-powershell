<!-- region Generated -->
# Az.ComputeLimit
This directory contains the PowerShell module for the ComputeLimit service.

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
For information on how to develop for `Az.ComputeLimit`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 661354eacb7c1e697aa2d7be980c7ebe02255138

require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/computelimit/resource-manager/Microsoft.ComputeLimit/ComputeLimit/readme.md

module-version: 0.1.0
title: ComputeLimit
# No service-name prefix: cmdlets are Get-AzSharedLimit, not Get-AzComputeLimitSharedLimit
subject-prefix: ''

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
auto-switch-view: false

inlining-threshold: 50

use-extension:
  "@autorest/powershell": "4.x"

directive:
  # 1. Remove Set-* cmdlets (AutoRest generates both New- and Set- for PUT;
  #    we only want Add-)
  - where:
      verb: Set
    remove: true

  # 2. Remove Update-* cmdlets (no PATCH operations needed)
  - where:
      verb: Update
    remove: true

  # 3. Remove Operations_List cmdlet (internal Azure infra, not user-facing)
  - where:
      subject: Operation
    remove: true

  # 4. Rename New- to Add- for SharedLimit
  #    (swagger PUT "SharedLimits_Create" maps to New-, but desired verb is Add-)
  - where:
      verb: New
      subject: SharedLimit
    set:
      verb: Add

  # 5. Rename New- to Add- for GuestSubscription
  #    (swagger PUT "GuestSubscriptions_Create" maps to New-, but desired verb is Add-)
  - where:
      verb: New
      subject: GuestSubscription
    set:
      verb: Add

  # 6. Remove JsonFilePath and JsonString variants
  #    (keep only Expanded parameter sets for a clean experience)
  - where:
      variant: ^(Create|Update)(?=.*?(JsonFilePath|JsonString))
    remove: true

```
