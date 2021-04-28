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

# Remove the cmdlet
  - where:
      verb: Set
    remove: true

  - where:
      subject: (.*)PrivateLink(.*)
    remove: true

  - where:
      subject: (.*)PrivateEndpoint(.*)
    remove: true

  # swagger definiition incorrect.
  - where:
      subject: PreviewWorkflow
    remove: true

  # Server not implement.
  - where:
      subject: ZipDeployment
    remove: true

# Rename cmdlet
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

  - where:
      subject: ^AppSetting$
    set:
      subject: Setting

# Remove variant
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^CreateViaIdentityExpanded$|^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: CustomDomain

    remove: true
  - where:
      verb: Test
      variant: ^Validate$|^ValidateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: CustomDomain
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: BuildAppSetting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: FunctionAppSetting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: Setting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: BuildFunctionAppSetting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: UserRoleInvitationLink
    remove: true

  - where:
      verb: New
      subject: ^$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  - where:
      verb: Update
      subjet: null
      variant: ^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Reset
      subject: ApiKey
      variant: ^Reset$|^ResetViaIdentity$
    remove: true

  - where:
      verb: Register
      subject: UserProvidedFunctionApp
      variant: ^Register$|^Register1$|^RegisterViaIdentity$|^RegisterViaIdentity1$|^RegisterViaIdentityExpanded$|^RegisterViaIdentityExpanded1$
    remove: true
# Rename cmdlet
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

# Rename parameters
  - where:
      parameter-name: BuildProperty(.*)
    set:
      parameter-name: $1
      
```
