# Overall
This directory contains management plane service clients of Az.NetAppFiles module.

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
title: NetAppManagementClient
description: Microsoft NetApp Files Azure Resource Provider specification
```


###
``` yaml
commit: fdc2e7b8efa15b521c7af6b041f226d5a090d5e1
input-file:
   ## - C:\Users\audunn\source\repos\azure\azure-rest-api-specs\specification\netapp\resource-manager\Microsoft.NetApp\stable\2023-11-01\netapp.json
   - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/netapp/resource-manager/Microsoft.NetApp/stable/2023-11-01/netapp.json
output-folder: Generated
namespace: Microsoft.Azure.Management.NetApp

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/volumeGroups/{volumeGroupName}

directive:
  # remove this operation because the Snapshots_Update defines an empty object
  # - remove-operation: Snapshots_Update
  # CodeGen don't support some definitions in v4 & v5 common types, in v4 and v5 subscriptionId has the format of uuid, but the generator is not correctly handling it right now
  - from: types.json
    where: $.parameters.SubscriptionIdParameter
    transform: >
      delete $.format;

```
