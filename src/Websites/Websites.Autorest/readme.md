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
# branch: 63274f791befe4fc3de823d18d9a26d3204a38ea
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  #- $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01/StaticSites.json
  - D:\azure-rest-api\azure-rest-api-specs\specification\web\resource-manager\Microsoft.Web\stable\2020-12-01\StaticSites.json

title: Websites
module-version: 0.1.0
subject-prefix: $(service-name)
identity-correction-for-post: true

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
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: ^(?!CustomDomain).*$
    remove: true
  - where:
      variant: ^CreateViaIdentity$
      subject: CustomDomain
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
  - where:
      subject: CustomDomainCanBeAddedToStaticSite
    set:
      subject: CustomDomain

  # Rename some parameters
  - where:
      parameter-name: BuildProperty(.*)
    set:
      parameter-name: $1

  - where:
      verb: Get
      variant: ^GetViaIdentity1$
    remove: true

  - where:
      verb: Reset
      subject: ApiKey
      variant: ^Reset$|^ResetViaIdentity$
    remove: true
  # Remove cmdlet
  - where:
      subject: (.*)PrivateEndpoint(.*)
    remove: true

  # Remove cmdlet
  - where:
      subject: (.*)PrivateLink(.*)
    remove: true  
```
