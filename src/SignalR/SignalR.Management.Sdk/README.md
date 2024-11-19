# Overall
This directory contains management plane service clients of Az.SignalR module.

## Run Generation
In this directory, run AutoRest:
```
rm -r Generated/*
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
payload-flattening-threshold: 2
```

###
``` yaml
commit: dad4abaabaf043b347551523185925fac5b72543
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/signalr/resource-manager/Microsoft.SignalRService/preview/2021-04-01-preview/signalr.json
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