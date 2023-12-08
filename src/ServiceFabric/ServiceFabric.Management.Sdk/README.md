In this directory, run AutoRest:

  ``` powershell 
    autorest --reset
    autorest --use:@autorest/powershell@4.x
  ```


``` yaml
isSdkGenerator: true
powershell: true
#csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2

use-extension:
  "@autorest/powershell": "4.x"

commit: 6963bf056ac44c592c385e84d493053bd2d5a5ee
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/application.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabric
```

Follow instructions at at <https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/coding/generate-sdk-with-autorest-powershell> for further steps.