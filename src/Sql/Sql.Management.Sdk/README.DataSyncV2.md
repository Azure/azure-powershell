# Overall
This directory contains the service clients of Az.Sql module for the Sql Data Sync V2 API version 2025-02-01.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest README.DataSyncV2.md --use:@autorest/powershell@4.x
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
title: SqlManagementClient
use-extension:
  "@autorest/powershell": "4.x"
```

###
``` yaml
commit: 37d29762e68000fc58e03dcefada999f3876f0af // TODO - Update with commit # of Azure-rest-api-specs
input-file:
      - SyncGroups.json // TODO - Replace with the actual file names
      - SyncMembers.json // TODO - Replace with the actual file names

output-folder: GeneratedSqlDataSync_2025_02_01

namespace: Microsoft.Azure.Management.Sql.DataSyncV2
```
