# Overall
This directory contains management plane service clients of Az.SignalR module.

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
title: SignalRManagementClient
openapi-type: arm
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
clear-output-folder: true
useDateTimeOffset: true
```

###
``` yaml
commit: 8600539fa5ba6c774b4454a401d9cd3cf01a36a7
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/signalr/resource-manager/Microsoft.SignalRService/preview/2025-01-01-preview/signalr.json

output-folder: Generated

namespace: Microsoft.Azure.Management.SignalR

directive:
  - suppress: EnumInsteadOfBoolean
    from: signalr.json
    where:
    - $.definitions.NameAvailability.properties.nameAvailable
    - $.definitions.Dimension.properties.toBeExportedForShoebox
    - $.definitions.Operation.properties.isDataAction
    - $.definitions.SignalRTlsSettings.properties.clientCertEnabled
    reason:  The boolean properties 'nameAvailable' and 'isDataAction' is standard property defined by Azure API spec. 'toBeExportedForShoebox' by Geneva metrics team. Keep 'clientCertEnabled' bool to be consistent with SignalR and not break existing customers.
  - suppress: TrackedResourceListByImmediateParent
    reason: Another list APIs naming approach is used over the specs
  - suppress: AvoidNestedProperties
    from: signalr.json
    where:
    - $.definitions.SignalRFeature.properties.properties
    - $.definitions.PrivateEndpointConnection.properties.properties
    - $.definitions.ShareablePrivateLinkResourceType.properties.properties
    reason:  The 'properties' is a user-defined dictionary, cannot be flattened.
  - suppress: PutInOperationName
    where:
    - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/signalR/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}"].put.operationId
    reason: It's indeed an UPDATE operation, but PUT is required per NRP requirement.
```