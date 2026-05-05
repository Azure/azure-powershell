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
commit: a52080de43d785c4aaf3048e84e6a215d6267333
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/dns/resource-manager/Microsoft.Network/Dns/preview/2023-07-01-preview/dns.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Dns
```
