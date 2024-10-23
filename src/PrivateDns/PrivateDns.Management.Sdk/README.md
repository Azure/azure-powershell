# Overall
This directory contains management plane service clients of Az.Dns module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
use-extension:
  "@autorest/powershell": "4.x"
```

###
``` yaml
commit: f4cabaa4f22f7ae7c4b804617d16aeb17d166ba6
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/privatedns/resource-manager/Microsoft.Network/stable/2024-06-01/privatedns.json

output-folder: Generated

namespace: Microsoft.Azure.Management.PrivateDns
```
