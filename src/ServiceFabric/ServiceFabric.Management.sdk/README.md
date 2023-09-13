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

commit: 52b1c1b978341a3905075dc0cdd2189ac795faf8
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabric/resource-manager/Microsoft.ServiceFabric/stable/2021-06-01/application.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ServiceFabric

```