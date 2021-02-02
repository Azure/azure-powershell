<!-- region Generated -->
# Az.Websites
This directory contains the PowerShell module for the Websites service.

---
## Status
[![Az.Websites](https://img.shields.io/powershellgallery/v/Az.Websites.svg?style=flat-square&label=Az.Websites "Az.Websites")](https://www.powershellgallery.com/packages/Az.Websites/)

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
For information on how to develop for `Az.Websites`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 2806c3488e4bf5ea397f1e41ec24f2beda4cb6cb
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2020-06-01/StaticSites.json

title: Websites
module-version: 0.1.0
subject-prefix: $(service-name)

directive:
  # Use "StaticWebApp" as subject prefix
  - where:
      subject-prefix: Websites
      subject: StaticSite(.*)
    set:
      subject-prefix: StaticWebApp
      subject: $1

  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Rename `Invoke-` cmdlets, using better verbs
  - where:
      verb: Invoke
      subject: Detach
    set:
      verb: Remove
      subject: AttachedRepository
      # alternatives:
      # Remove-AzStaticWebAppAttachedRepository
      # Remove-AzStaticWebAppAttachedRepo
      # Remove-AzStaticWebAppRepository
  - where:
      verb: Invoke
      subject: WorkflowPreview|PreviewWorkflow
    set:
      verb: New
      subject: PreviewWorkflow
      # alternatives:
      # New-AzStaticWebAppPreviewWorkflow
      # New-AzStaticWebAppWorkflowPreview

  # Rename some parameters
  - where:
      parameter-name: BuildProperty(.*)
    set:
      parameter-name: $1
```
