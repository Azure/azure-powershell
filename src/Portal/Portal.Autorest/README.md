<!-- region Generated -->
# Az.Portal
This directory contains the PowerShell module for the Portal service.

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
For information on how to develop for `Az.Portal`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 0dd49a444195fef7f3555cad038cb7665cbd928c
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/portal/resource-manager/Microsoft.Portal/preview/2019-01-01-preview/portal.json

metadata:
  authors: Microsoft Corporation
  owners: Microsoft Corporation
  description: 'Microsoft Azure PowerShell: Portal Dashboard cmdlets'
  copyright: Microsoft Corporation. All rights reserved.
  tags: Azure ResourceManager ARM PSModule Portal Dashboard
  companyName: Microsoft Corporation
  requireLicenseAcceptance: true
  licenseUri: https://aka.ms/azps-license
  projectUri: https://github.com/Azure/azure-powershell
  releaseNotes: Initial release of Portal Dashboard cmdlets.

module-version: 0.1.0
title: Portal
subject-prefix: $(service-name)

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - where: 
      verb: Set
      subject: Dashboard
    hide: true
  - where:
      verb: New
      subject: Dashboard
      variant: CreateViaIdentity|CreateViaIdentityExpanded
    remove: true
  - where:
      verb: Update
      subject: Dashboard
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
      

```
