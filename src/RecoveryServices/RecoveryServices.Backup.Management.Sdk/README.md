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
override-client-name: RecoveryServicesBackupClient
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
commit: 53fc184a55bd2214e3bec2f1d9098501072e7d1e
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
