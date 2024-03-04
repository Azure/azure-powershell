# Overall

## RunGeneration
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
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```

###
``` yaml
commit: 33a08abd715bd9d671ade5aaf4e3810e003792f1
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/application.json

output-folder: Generated
namespace: Microsoft.Azure.Management.ServiceFabric
```

Follow instructions at at <https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/coding/generate-sdk-with-autorest-powershell> for further steps.