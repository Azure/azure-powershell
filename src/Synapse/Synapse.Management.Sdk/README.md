# Overall
This directory contains management plane service clients of Az.Synapse module.

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
description: Azure Synapse Analytics Management Client
openapi-type: arm
azure-arm: true
generate-empty-classes: true
modelerfour:
  lenient-model-deduplication: true
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Microsoft.Azure.Management.Synapse
output-folder: Generated
clear-output-folder: true
batch:
 - tag: package-composite-v2
 - tag: package-sqlGen3-2020-04-01-preview
reflect-api-versions: true
commit: cecb65f56ec5291e7fe88d62048bdb717e33e834
```

### Tag: package-composite-v2

``` yaml $(tag) == 'package-composite-v2'
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
  # - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/kustoPool.json
```

### Tag: package-sqlGen3-2020-04-01-preview
``` yaml $(tag) == 'package-sqlGen3-2020-04-01-preview'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2020-04-01-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2020-04-01-preview/sqlPool.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/synapse/resource-manager/Microsoft.Synapse/preview/2020-04-01-preview/sqlDatabase.json
```

``` yaml
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
  - where:
      model-name: AzureADOnlyAuthentication
      property-name: AzureAdOnlyAuthentication
    set:
      property-name: AzureADOnlyAuthentication
  - where:
      model-name: IpFirewallRuleInfo
      property-name: EndIPAddress
    set:
      property-name: EndIpAddress
  - where:
      model-name: IpFirewallRuleInfo
      property-name: StartIPAddress
    set:
      property-name: StartIpAddress
  - where:
      model-name: IntegrationRuntimeNodeIpAddress
      property-name: IPAddress
    set:
      property-name: IpAddress
  - where:
      model-name: Key
      property-name: IsActiveCmk
    set:
      property-name: IsActiveCMK
  - where:
      model-name: SelfHostedIntegrationRuntimeStatus
      property-name: AutoUpdateEta
    set:
      property-name: AutoUpdateETA
  - where:
      model-name: Workspace
      property-name: WorkspaceUid
    set:
      property-name: WorkspaceUID
  - where:
      model-name: IntegrationRuntimeNodeMonitoringData
      property-name: AvailableMemoryInMb
    set:
      property-name: AvailableMemoryInMB
      
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/operationResults/{operationId}"].get
    transform: delete $["x-ms-long-running-operation"]
  - from: swagger-document
    where: $.definitions.IntegrationRuntimeResource.properties.properties
    transform: delete $["x-ms-client-flatten"]
  - from: swagger-document
    where: $.definitions.IntegrationRuntimeStatusResponse.properties.properties
    transform: delete $["x-ms-client-flatten"]
```