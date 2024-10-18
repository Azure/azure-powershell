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

commit: 73046cd2b58bc600245958e40e03bd0c78379957
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/consumption/resource-manager/Microsoft.Consumption/stable/2018-01-31/consumption.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Consumption

directive:
  - suppress: R2059
    from: consumption.json
    reason: it's not actually a resource path; the validator is confused because the Billing namespace is in the URI path.
    approved-by: "@fearthecowboy"
```