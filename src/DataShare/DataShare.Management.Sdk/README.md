# Overall
This directory contains management plane service clients of Az.DataShare module.

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
commit: 9505236faa86b99b6dc58b5655d8e1c4a758d89c
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datashare/resource-manager/Microsoft.DataShare/stable/2019-11-01/DataShare.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DataShare

directive:
  - where:
      model-name: AdlsGen1FileDataSet
    set:
      model-name: ADLSGen1FileDataSet
  - where:
      model-name: AdlsGen1FolderDataSet
    set:
      model-name: ADLSGen1FolderDataSet
  - where:
      model-name: AdlsGen2FileDataSet
    set:
      model-name: ADLSGen2FileDataSet
  - where:
      model-name: AdlsGen2FileDataSetMapping
    set:
      model-name: ADLSGen2FileDataSetMapping
  - where:
      model-name: AdlsGen2FileSystemDataSet
    set:
      model-name: ADLSGen2FileSystemDataSet
  - where:
      model-name: AdlsGen2FolderDataSet
    set:
      model-name: ADLSGen2FolderDataSet
  - where:
      model-name: AdlsGen2FileSystemDataSetMapping
    set:
      model-name: ADLSGen2FileSystemDataSetMapping
  - where:
      model-name: AdlsGen2FolderDataSetMapping
    set:
      model-name: ADLSGen2FolderDataSetMapping
  - where:
      property-name: (.*)DurationMS
    set:
      property-name: DurationMs
```