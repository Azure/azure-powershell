# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
description: Azure Synapse Analytics Management Client
generate-empty-classes: true
modelerfour:
  lenient-model-deduplication: true
```



###
``` yaml
commit: 74ca59fc8cb6563d5a9d66fb533b8622522143eb
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/azureADOnlyAuthentication.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/checkNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/firewallRule.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/keys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privateEndpointConnections.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privatelinkhub.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/sqlPool.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/sqlServer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/workspace.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/bigDataPool.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/library.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/integrationRuntime.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/sparkConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/kustoPool.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Synapse

directive:
  - suppress: EnumInsteadOfBoolean
    reason: This boolean values are actually boolean in the model.
  - suppress: TrackedResourceListByImmediateParent
    reason: Does not apply to workspace/operationStatus and workspace/operationResults .
  - suppress: PostOperationIdContainsUrlVerb
    reason: ReplaceAllIpFirewallRules has a nonstandard verb ReplaceAll.
  - suppress: TrackedResourceListByResourceGroup
    reason: Does not apply to sqlPool and bigDataPool as they are nested tracked resources
  - suppress: TrackedResourceListBySubscription
    reason: Does not apply to sqlPool and bigDataPool as they are nested tracked resources
  - from: Microsoft.Synapse/preview/2019-06-01-preview/sqlPool.json
    where:
        - $.definitions.SqlPoolVulnerabilityAssessmentRuleBaseline
        - $.definitions.DataMaskingPolicy
        - $.definitions.DataWarehouseUserActivities
        - $.definitions.SqlPoolConnectionPolicy
        - $.definitions.TransparentDataEncryption
    suppress:
        - R4015
    reason: SQL doesn't support 'list' operation everywhere, so we cannot support List for certain Sql pool operations
  - from: Microsoft.Synapse/preview/2019-06-01-preview/sqlPool.json
    where :
        - '$.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/restorePoints/{restorePointName}"].delete.responses'
    suppress:
        - R4011
    reason: SQL Pools APIs are proxy APIs that call SQL DB APIs. The SQL DB delete restore points API only supports return method 200, so we cannot support 204. It is not possible for the SQL DB team to add 204 support for delete restore points.
  - suppress: AllResourcesMustHaveGetOperation
    from: Microsoft.Synapse/preview/2019-06-01-preview/sqlPool.json
    where:
      - $.definitions.DataMaskingRule
      - $.definitions.SqlPoolOperation
  - suppress: R4015
    reason: Needs implementation
    from: Microsoft.Synapse/preview/2019-06-01-preview/workspace_managedIdentity.json
    where:
      - $.definitions.ManagedIdentitySqlControlSettingsInfo
  - suppress: R2010
    reason: x-ms-long-running-operation-options not available in datafactory swagger
    from: Microsoft.Synapse/preview/2019-06-01-preview/integrationRuntime.json
  - suppress: AvoidNestedProperties
    reason: Existing models
    from: Microsoft.Synapse/preview/2019-06-01-preview/integrationRuntime.json
    where:
      - $.definitions.IntegrationRuntimeResource.properties.properties
      - $.definitions.IntegrationRuntimeStatusResponse.properties.properties
      - $.definitions.SsisObjectMetadataStatusResponse.properties.properties
  - from: Microsoft.Synapse/stable/2020-12-01/sqlPool.json
    where:
        - $.definitions.SqlPoolVulnerabilityAssessmentRuleBaseline
        - $.definitions.DataMaskingPolicy
        - $.definitions.DataWarehouseUserActivities
        - $.definitions.SqlPoolConnectionPolicy
        - $.definitions.TransparentDataEncryption
    suppress:
        - R4015
    reason: SQL doesn't support 'list' operation everywhere, so we cannot support List for certain Sql pool operations
  - from: Microsoft.Synapse/stable/2020-12-01/sqlPool.json
    where :
        - '$.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/restorePoints/{restorePointName}"].delete.responses'
    suppress:
        - R4011
    reason: SQL Pools APIs are proxy APIs that call SQL DB APIs. The SQL DB delete restore points API only supports return method 200, so we cannot support 204. It is not possible for the SQL DB team to add 204 support for delete restore points.
  - suppress: AllResourcesMustHaveGetOperation
    from: Microsoft.Synapse/stable/2020-12-01/sqlPool.json
    where:
      - $.definitions.DataMaskingRule
      - $.definitions.SqlPoolOperation
  - suppress: R4015
    reason: Needs implementation
    from: Microsoft.Synapse/stable/2020-12-01/workspace_managedIdentity.json
    where:
      - $.definitions.ManagedIdentitySqlControlSettingsInfo
  - suppress: R2010
    reason: x-ms-long-running-operation-options not available in datafactory swagger
    from: Microsoft.Synapse/stable/2020-12-01/integrationRuntime.json
  - suppress: AvoidNestedProperties
    reason: Existing models
    from: Microsoft.Synapse/stable/2020-12-01/integrationRuntime.json
    where:
      - $.definitions.IntegrationRuntimeResource.properties.properties
      - $.definitions.IntegrationRuntimeStatusResponse.properties.properties
      - $.definitions.SsisObjectMetadataStatusResponse.properties.properties
  - suppress: R4009
    reason: systemData will be in the next API version
    from: Microsoft.Synapse/stable/2020-12-01/library.json
```