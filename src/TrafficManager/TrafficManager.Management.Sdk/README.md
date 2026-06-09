# Overall
This directory contains management plane service clients of Az.Storage module.

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
commit: 28e08376806422730d28d8dd90479d0ad68397ac
directive:
  - from: trafficmanager.json
    where: $.definitions
    transform: >
      $.ProfileProperties.properties.maxReturn['x-nullable'] = true;
      $.EndpointProperties.properties.minChildEndpoints['x-nullable'] = true;
      $.EndpointProperties.properties.minChildEndpointsIPv4['x-nullable'] = true;
      $.EndpointProperties.properties.minChildEndpointsIPv6['x-nullable'] = true;
  - from: trafficmanager.json
    where: $.paths..parameters[?(@.name === "heatMapType")]
    transform: >
      $['x-ms-enum'] = {
        "name": "HeatMapType",
        "modelAsString": true
      }
  - from: trafficmanager.json
    where: $.paths..delete.responses["200"]
    transform: >
      delete $["schema"]
  - from: trafficmanager.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}"]..parameters[?(@.name === "endpointType")]
    transform: >
      delete $["enum"];
      delete $["x-ms-enum"];
    reason: The path parameter endpointType is defined as string in stable version, we can't change it to an enumeration.
 
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/trafficmanager/resource-manager/Microsoft.Network/TrafficManager/preview/2024-04-01-preview/trafficmanager.json
output-folder: Generated

namespace: Microsoft.Azure.Management.TrafficManager
```