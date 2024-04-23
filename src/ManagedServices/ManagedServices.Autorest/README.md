<!-- region Generated -->
# Az.ManagedServices
This directory contains the PowerShell module for the ManagedServices service.

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
For information on how to develop for `Az.ManagedServices`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
commit: 2d57dfad630d8a6d7e651a3df3168f7fbcb7728e
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/managedservices/resource-manager/Microsoft.ManagedServices/preview/2020-02-01-preview/managedservices.json

title: ManagedServices
module-version: 2.0.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:

  # Remove unnecessary cmdlet.
  - where:
      verb: Set
    remove: true
  
  # Delete the Registration word in the cmdlet name
  - where:
      subject: (.*)(Registration)(.*) 
    set:
      subject: $1$3

  # Remove variant of the cmdlet
  - where:
      verb: New
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # Hide cmdlet
  - where:
      verb: Get
      subject: MarketplaceDefinitionsWithoutScope|MarketplaceDefinition
    hide: true

  # Change parameter Id to Name
  - where:
      parameter-name: Id
    set:
      parameter-name: Name
  
  # Set default vaule for scope parameter
  - where:
      parameter-name: Scope
    set:
      default:
        script: '"subscriptions/" + (Get-AzContext).Subscription.Id'

  # The regex(^/(?<scope>[^/]+)/) mathch failed because the scope inlcude '/' character.
  # Replace regex to fixed it. 
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/global::System.Text.RegularExpressions.Regex\(\"\^\/\(\?\<scope\>\[\^\/\]\+\)/g, 'global::System.Text.RegularExpressions.Regex("^/(?<scope>.+)');

  # Generate memory object as parameter of the cmelet.
  - model-cmdlet:
    - Authorization
    - EligibleApprover
    # Need custom that add ArgumentCompleterAttribute for JustInTimeAccessPolicyMultiFactorAuthProvider parameter.
    # - EligibleAuthorization
  
  # The function invalid for memory cmdlet.
  # Custom cmdlet.
  # - where:
  #     verb: New
  #     subject: EligibleAuthorizationObject
  #     parameter-name: JustInTimeAccessPolicyMultiFactorAuthProvider
  #   set:
  #     default:
  #       script: '"None"'
```
