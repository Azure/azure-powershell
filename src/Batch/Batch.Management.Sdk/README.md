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
payload-flattening-threshold: 1
# title: BatchManagementClient

commit: eea7c005f673b4c72a97f4edda1a18217cfbca58
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/batch/resource-manager/Microsoft.Batch/Batch/stable/2025-06-01/openapi.json


output-folder: Generated

namespace: Microsoft.Azure.Management.Batch

directive:
  - suppress: R2001
    where: $.definitions.Operation.properties.properties
    reason: Breaking change.

  - suppress: R2017
    where:
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}"].put
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates/{certificateName}"].put
    reason: Matching service response.

  - suppress: R2063
    reason: Bug in linter

  - suppress: R2066
    where:
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates/{certificateName}/cancelDelete"].post.operationId
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/listKeys"].post.operationId
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/regenerateKeys"].post.operationId
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/syncAutoStorageKeys"].post.operationId
    reason: This is fine as long as the OperationIds are all unique (as they presently are), and fixing it would likely involve a breaking change.

  - suppress: R3018
    where:
     - $.definitions.ApplicationProperties.properties.allowUpdates
     - $.definitions.BatchAccountProperties.properties.dedicatedCoreQuotaPerVMFamilyEnforced
     - $.definitions.CheckNameAvailabilityResult.properties.nameAvailable
     - $.definitions.StartTask.properties.waitForSuccess
     - $.definitions.VMExtension.properties.autoUpgradeMinorVersion
     - $.definitions.WindowsConfiguration.properties.enableAutomaticUpdates
    reason: Breaking change.

  - suppress: R3018
    where:
     - $.definitions.Operation.properties.isDataAction
    reason: Boolean required for operations schema.

  - suppress: R4009
    where:
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}"].get
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}"].patch
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}"].put
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}"].get
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}"].patch
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}"].put
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}/versions/{versionName}"].get
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/applications/{applicationName}/versions/{versionName}"].put
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates/{certificateName}"].get
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates/{certificateName}"].patch
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates/{certificateName}"].put
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/detectors/{detectorId}"].get
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/detectors/{detectorId}"].patch
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/detectors/{detectorId}"].put
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/pools/{poolName}"].get
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/pools/{poolName}"].put
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/pools/{poolName}"].patch
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}"].patch
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}"].get
     - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/privateLinkResources/{privateLinkResourceName}"].get
    reason: Service missing headers.

  - suppress: OBJECT_MISSING_REQUIRED_PROPERTY
    where: $.definitions.UserAccount
    reason: This field contains a secret (password) and is not returned on a get (but is required on a PUT/PATCH). Previous discussions with the modelling team had said that this was the correct way to model this type of field.

  - from: swagger-document
    where: $.definitions.PrivateEndpointConnectionProvisioningState
    transform: $["x-nullable"] = false
    reason: Keep PrivateEndpointConnection.ProvisioningState non-nullable as in the 2024-07-01 SDK (the 2025-06-01 spec dropped x-nullable false). This enum is only used by that property.
```