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

commit: 517eaf1cca58813605768f4ddc9a59ca75173493
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/517eaf1cca58813605768f4ddc9a59ca75173493/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2025-03-01-preview/servicefabricmanagedclusters.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabricManagedClusters

```

Follow instructions at at <https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/coding/generate-sdk-with-autorest-powershell> for further steps.