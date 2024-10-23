In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml

commit: b742395f164f1cfa43de241872c306a09f694f93
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2024-02-01/network.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2024-02-01/webapplicationfirewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2021-06-01/frontdoor.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2019-11-01/networkexperiment.json

# csharp: true
isSdkGenerator: true
powershell: true
clear-output-folder: true
openapi-type: arm
azure-arm: true
output-folder: Generated
namespace: Microsoft.Azure.Management.FrontDoor
title: FrontDoor

directive:
  - from: swagger-document
    where: $.definitions.RouteUpdatePropertiesParameters.properties.supportedProtocols
    transform: delete $.default
  - from: swagger-document
    where: $.definitions.PolicySettings.properties.logScrubbing
    transform: $['x-ms-client-flatten'] = false;
  - where:
      model-name: FrontDoor
    set:
      model-name: FrontDoorModel
