### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: 2d973fccf9f28681a481e9760fa12b2334216e21
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/readme.azure.noprofile.md
  - $(repo)/specification/edgezones/resource-manager/readme.md

try-require: 
  - $(repo)/specification/edgezones/resource-manager/readme.powershell.md
```