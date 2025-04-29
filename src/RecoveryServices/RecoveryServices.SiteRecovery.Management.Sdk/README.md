# Overall
This directory contains management plane service clients of Az.RecoveryServices SiteRecovery APIs.

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
```

###
``` yaml
commit: 203d98d48deb3c3daead3101d106a1977eba2453
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicessiterecovery/resource-manager/Microsoft.RecoveryServices/stable/2024-10-01/service.json
  
output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.SiteRecovery
directive:
  - from: swagger-document
    where: $.definitions
    transform: >
      if (!$.ProtectedClustersQueryParameter) {
        $.ProtectedClustersQueryParameter = {
          "description": "Query parameters for listing protected clusters",
          "type": "object",
          "properties": {
            "sourceFabricName": {
            "description": "The source fabric name filter.",
            "type": "string"
             },
             "sourceFabricLocation": {
             "description": "The source fabric location filter.",
             "type": "string"
              },
             "instanceType": {
             "description": "The replication provider type.",
             "type": "string"
            }
          }
        };
       }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationFabrics/{fabricName}/replicationProtectionContainers/{protectionContainerName}/replicationProtectionClusters/{replicationProtectionClusterName}"].put.responses
    transform: >-
      return {
        "200":{
            "description":"OK",
            "schema":{
            "$ref":"#/definitions/ReplicationProtectionCluster"
            }
        },
        "201":{
            "description":"Created",
            "schema":{
            "$ref":"#/definitions/ReplicationProtectionCluster"
            }
        },
        "202":{
            "description":"Accepted",
            "headers":{
            "Location":{
            "type":"string"
            },
            "Azure-AsyncOperation":{
            "type":"string"
            },
            "Retry-After":{
            "type":"string"
            }
            }
        },
        "default":{
            "description":"Automation error response describing why the operation failed.",
            "schema":{
            "$ref":"../../../../../common-types/resource-management/v5/types.json#/definitions/ErrorResponse"
            }
        }
      }
```