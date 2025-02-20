# Overall
This directory contains management plane service clients of Az.RecoveryServices Backup APIs.

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
```

###
``` yaml
commit: 58740206b853320974ef5e4864f7be8120b15a27
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/stable/2024-10-01/bms.json

directive:
  - from: swagger-document
    where: 
      - $..description
    transform: $ = $.replace(/\r\n/g, ' ')
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/xcludedRpList/g, 'xcludedRPList')

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.Backup
```
