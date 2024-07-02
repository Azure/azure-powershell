# Overall

## RunGeneration
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
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 1
```

###
``` yaml
commit: 5539bbe1f023b10ffa3b61c9106cb8d34a27038e
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/stable/2024-04-01/managedcluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/stable/2024-04-01/nodetype.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/stable/2024-04-01/managedapplication.json

directive:
  - from: managedapplication.json
    where: $.definitions
    transform: >
      $.HealthCheckWaitDuration['x-ms-format'] = 'duration-constant';
      $.HealthCheckStableDuration['x-ms-format'] = 'duration-constant';
      $.HealthCheckRetryTimeout['x-ms-format'] = 'duration-constant';
      $.UpgradeDomainTimeout['x-ms-format'] = 'duration-constant';
      $.UpgradeTimeout['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.replicaRestartWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.quorumLossWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.standByReplicaKeepDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.servicePlacementTimeLimit['x-ms-format'] = 'duration-constant';

output-folder: Generated
namespace: Microsoft.Azure.Management.ServiceFabricManagedClusters
```

Follow instructions at at <https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/devguide/azps/coding/generate-sdk-with-autorest-powershell> for further steps.
