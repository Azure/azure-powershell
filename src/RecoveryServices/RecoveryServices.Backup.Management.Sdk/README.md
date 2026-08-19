# Overall
This directory contains management plane service clients of Az.RecoveryServices Backup APIs.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x --override-client-name=RecoveryServicesBackupClient
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
# Lock to the merged Swagger PR commit so SDK generation remains reproducible.
commit: 26c5d39ce59d33f9f08ebfc8205db653d6ac4bd9
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/RecoveryServicesBackup/stable/2026-07-01/bms.json

directive:
  # Normalize multiline descriptions so generated C# documentation remains well-formed.
  - from: swagger-document
    where: 
      - $..description
    transform: if (typeof $ === 'string') { $ = $.replace(/\r\n/g, ' ') }
  # Preserve the established RP acronym capitalization in generated parameter names.
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/xcludedRpList/g, 'xcludedRPList')

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.Backup
```
