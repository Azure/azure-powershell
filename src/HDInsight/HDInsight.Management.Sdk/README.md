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
commit: f22b814a1a30517cb6612c8fe071cfbcc64e3a2c
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/applications.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/configurations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/extensions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/locations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/privateEndpointConnections.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/scriptActions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2024-08-01-preview/virtualMachines.json

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
