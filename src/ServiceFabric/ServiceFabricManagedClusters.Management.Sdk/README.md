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
  "@autorest/powershell": "~4.0.0-dev"

commit: da459cd725e11aa72e7fbc3b65d523b6e2b6453b
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2023-03-01-preview/managedcluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2023-03-01-preview/nodetype.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/preview/2023-03-01-preview/managedapplication.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabricManagedClusters

```