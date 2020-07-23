### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/msi/resource-manager/Microsoft.ManagedIdentity/stable/2018-11-30/ManagedIdentity.json

subject-prefix: ''

directive:
  # Remove unnedded cmdlets
  - where:
      subject: ^Operation$
    remove: true

  # Hide Storage Account cmdlets
  - where:
      subject: ^UserAssignedIdentity.*
    hide: true
  - where:
      subject: ^UserAssignedIdentity.*
    set:
      subject-prefix: ''
  
```
