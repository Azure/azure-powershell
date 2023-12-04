## RunGeneration

In this directory, run AutoRest:

  ``` powershell 
    autorest --reset
    autorest --use:@autorest/powershell@4.x
  ```

``` yaml

isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2

use-extension:
  "@autorest/powershell": "4.x"

commit: ce96a721d6bffa72dada8a998dee55f4c32ad0ef
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2023-03-01-preview/managedcluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2023-03-01-preview/nodetype.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2023-03-01-preview/managedapplication.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabricManagedClusters

```

Follow instructions at at <https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/coding/generate-sdk-with-autorest-powershell> for further steps.