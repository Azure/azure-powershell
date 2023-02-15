<!-- region Generated -->
# Az.ManagedServiceIdentity
This directory contains the PowerShell module for the ManagedServiceIdentity service.

---
## Status
[![Az.ManagedServiceIdentity](https://img.shields.io/powershellgallery/v/Az.ManagedServiceIdentity.svg?style=flat-square&label=Az.ManagedServiceIdentity "Az.ManagedServiceIdentity")](https://www.powershellgallery.com/packages/Az.ManagedServiceIdentity/)

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
branch: main
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/msi/resource-manager/Microsoft.ManagedIdentity/preview/2022-01-31-preview/ManagedIdentity.json

subject-prefix: ""
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true
module-version: 0.2.0

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

  # Associated Resources

  - where:
      subject: UserAssignedIdentityAssociatedResource
      parameter-name: ResourceName
    set:
      parameter-name: Name

  - where:
      subject: UserAssignedIdentityAssociatedResource
    set:
      preview-message: This is a preview version of the Associated Resources feature.

  # Federated identity credentials

  - where:
      verb: Set
      subject: FederatedIdentityCredentials
    set:
      verb: Update
      subject: FederatedIdentityCredentials
    
  - where:
      subject: FederatedIdentityCredentials
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      subject: FederatedIdentityCredentials
      parameter-name: ResourceName
    set:
      parameter-name: IdentityName

  - where:
      subject: FederatedIdentityCredentials
      parameter-name: FederatedIdentityCredentialResourceName
    set:
      parameter-name: Name

  - where:
      subject: FederatedIdentityCredentials
      parameter-name: Audience
    required: true
    set:
      default:
        script: '@("api://AzureADTokenExchange")'

  - where:
      subject: FederatedIdentityCredentials
      parameter-name: Issuer
    required: true

  - where:
      subject: FederatedIdentityCredentials
      parameter-name: Subject
    required: true

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
      subject: FederatedIdentityCredentials
    set:
      preview-message: This is a preview version of the Federated Identity Credentials feature.
```
