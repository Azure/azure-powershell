# Overall
This directory contains management plane service clients of Az.Dns module.

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
use-extension:
  "@autorest/powershell": "4.x"
```

###
``` yaml
commit: cec544f453df388ab20b552ee92cb16f52f78cc8
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/dns/resource-manager/Microsoft.Network/Dns/preview/2023-07-01-preview/dns.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Dns

directive:
  # The DNS swagger defines its own CloudError schema. Remove it so autorest falls
  # back to the standard Microsoft.Rest.Azure.CloudException, which (a) avoids the
  # ambiguous reference between Microsoft.Azure.Management.Dns.Models.CloudError
  # and Microsoft.Rest.Azure.CloudError, and (b) preserves the friendly error-message
  # propagation (ex = new CloudException(body.Message)) that newer autorest emit
  # patterns drop for service-specific error classes.
  - from: swagger-document
    where: $.paths.*.*.responses
    transform: >
      for (const code of Object.keys($)) {
        const r = $[code];
        if (r && r.schema && r.schema.$ref === "#/definitions/CloudError") {
          delete r.schema;
        }
      }
      return $;
  - from: swagger-document
    where: $.definitions
    transform: >
      delete $.CloudError;
      delete $.CloudErrorBody;
      return $;
```
