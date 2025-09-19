# Overall
This directory contains management plane service clients of Az.HDInsight module.

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
namespace: Microsoft.Azure.Management.HDInsight
modelerfour:
  flatten-payloads: false
skip-csproj: true
```



###
``` yaml
commit: 881a35f96dbb1f7cf7c83dd00ed29a628804464d
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/applications.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/configurations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/extensions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/locations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/privateEndpointConnections.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/scriptActions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2025-01-15-preview/virtualMachines.json

output-folder: Generated


directive:
  - where:
      property-name: OSType
    set:
      property-name: OsType
  - where:
      property-name: OSProfile
    set:
      property-name: OsProfile
  - where:
      property-name: DiskSizeGb
    set:
      property-name: DiskSizeGB

```
