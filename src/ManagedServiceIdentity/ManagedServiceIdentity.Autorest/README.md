<!-- region Generated -->
# Az.ManagedServiceIdentity
This directory contains the PowerShell module for the ManagedServiceIdentity service.

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
For information on how to develop for `Az.ManagedServiceIdentity`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 78eac0bd58633028293cb1ec1709baa200bed9e2
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/msi/resource-manager/Microsoft.ManagedIdentity/stable/2023-01-31/ManagedIdentity.json
  - $(repo)/specification/msi/resource-manager/Microsoft.ManagedIdentity/preview/2022-01-31-preview/ManagedIdentity.json

subject-prefix: ""
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true
module-version: 0.3.0

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - where:
      verb: Set
      subject: SystemAssignedIdentity|UserAssignedIdentity
    remove: true

  - where:
      verb: Get
      subject: SystemAssignedIdentity
      variant: ^GetViaIdentity$
    remove: true
    
  - where:
      subject: UserAssignedIdentity
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      subject: UserAssignedIdentity
      parameter-name: ResourceName
    set:
      parameter-name: Name

  # Associated Resources use 2022-01-31-preview API version

  - where:
      subject: UserAssignedIdentityAssociatedResource
      parameter-name: ResourceName
    set:
      parameter-name: Name

  - where:
      subject: UserAssignedIdentityAssociatedResource
    set:
      preview-announcement:
        preview-message: This is a preview version of the Associated Resources feature.

  # END

  # Federated identity credentials
  # Add *-AzFederatedIdentityCredential alias, and make alias as main index.
  - where:
      verb: Get
      subject: FederatedIdentityCredentials
    set:
      subject: FederatedIdentityCredential
      alias: Get-AzFederatedIdentityCredentials
  - where:
      verb: New
      subject: FederatedIdentityCredentials
    set:
      subject: FederatedIdentityCredential
      alias: New-AzFederatedIdentityCredentials
  - where:
      verb: Remove
      subject: FederatedIdentityCredentials
    set:
      subject: FederatedIdentityCredential
      alias: Remove-AzFederatedIdentityCredentials
  - where:
      verb: Set
      subject: FederatedIdentityCredentials
    set:
      verb: Update
      subject: FederatedIdentityCredential
      alias: Update-AzFederatedIdentityCredentials

  - where:
      subject: FederatedIdentityCredential
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      subject: FederatedIdentityCredential
      parameter-name: ResourceName
    set:
      parameter-name: IdentityName

  - where:
      subject: FederatedIdentityCredential
      parameter-name: FederatedIdentityCredentialResourceName
    set:
      parameter-name: Name

  - where:
      subject: FederatedIdentityCredential
      parameter-name: Audience
    required: true
    set:
      default:
        script: '@("api://AzureADTokenExchange")'

  - where:
      subject: FederatedIdentityCredential
      parameter-name: Issuer
    required: true

  - where:
      subject: FederatedIdentityCredential
      parameter-name: Subject
    required: true

  # END

  # Below instructions remove duplicate API methods which use 2022-01-31-preview. MUST be removed when 2022-01-31-preview is removed.

  - where:
      subject: FederatedIdentityCredential
      variant: ^Get1$|^List1$|^GetViaIdentity1$|^Create1$|^CreateExpanded1$|^CreateViaIdentity1$|^CreateViaIdentityExpanded1$|^Delete1$|^DeleteViaIdentity1$|^Update1$|^UpdateExpanded1$|^UpdateViaIdentity1$|^UpdateViaIdentityExpanded1$
    remove: true

  - where:
      verb: Get
      subject: SystemAssignedIdentity
      variant: ^Get1$|^GetViaIdentity1$
    remove: true

  - where:
      subject: UserAssignedIdentity
      variant: ^Get1$|^GetViaIdentity1$|^List2$|^List3$|^Create1$|^CreateExpanded1$|^CreateViaIdentity1$|^CreateViaIdentityExpanded1$|^Delete1$|^DeleteViaIdentity1$|^Update1$|^UpdateExpanded1$|^UpdateViaIdentity1$|^UpdateViaIdentityExpanded1$
    remove: true

  # END 

  - where:
      model-name: FederatedIdentityCredential
    set:
      format-table:
        properties:
          - Name
          - Issuer
          - Subject
          - Audience

  - where:
      model-name: SystemAssignedIdentity
    set:
      format-table:
        properties:
          - Name
          - Location
          - ResourceGroupName

  - where:
      model-name: Identity
    set:
      format-table:
        properties:
          - Name
          - Location
          - ResourceGroupName
```
