### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/keyvault/resource-manager/Microsoft.KeyVault/stable/2016-10-01/keyvault.json

# subject-prefix: ''

directive:
  # hide all cmdlets
  - where:
      subject: ^VaultDeleted$|^Vault$|^VaultNameAvailability$|^VaultAccessPolicy$
    hide: true
    set:
      subject-prefix: ''
```
