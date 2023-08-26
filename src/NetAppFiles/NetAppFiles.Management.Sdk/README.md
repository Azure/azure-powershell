# Overall
This directory contains management plane service clients of Az.NetAppFiles module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
csharp: true
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
commit: d71132a3e8bf8ad22ab77991805e033ed1b66dff
input-file:
   - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/netapp/resource-manager/Microsoft.NetApp/stable/2022-11-01/netapp.json
output-folder: Generated
namespace: Microsoft.Azure.Management.NetApp

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/volumeGroups/{volumeGroupName}

# directive:
  # remove this operation because the Snapshots_Update defines an empty object
  # - remove-operation: Snapshots_Update
```
