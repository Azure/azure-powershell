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
```



###
``` yaml
commit: 9dbff8c6f75666257e65d40ef2cf9d58063514e0
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/attestation/resource-manager/Microsoft.Attestation/preview/2018-09-01-preview/attestation.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Attestation

directive:
  - where:
      model-name: JsonWebKeySet
    set:
      model-name: JSONWebKeySet
  - where:
      model-name: JsonWebKey
    set:
      model-name: JSONWebKey
  - where:
      model-name:  JSONWebKey
      property-name: X5C
    set:
      property-name: X5c
```