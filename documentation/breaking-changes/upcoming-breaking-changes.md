# Upcoming breaking changes in Azure PowerShell

## Az.Accounts

### `Resolve-AzError`

- Cmdlet breaking-change will happen to all parameter set
  - The `Resolve-Error` alias will be removed in a future release.  Please change any scripts that use this alias to use `Resolve-AzError` instead.

## Az.Aks

### `Install-AzAksCliTool`

- Cmdlet breaking-change will happen to all parameter set
  The cmdlet 'Install-AzAksCliTool' is replacing this cmdlet.
  - This change will take effect on '10/12/2022'
  - The change is expected to take effect from the version : '9.0.0'

## Az.AnalysisServices

### `Add-AzAnalysisServicesAccount`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

## Az.ApiManagement

### `Add-AzApiManagementRegion`

- Parameter breaking-change will happen to all parameter sets
  - `-Sku`
    - The parameter : 'Sku' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'String'.

### `New-AzApiManagement`

- Parameter breaking-change will happen to all parameter sets
  - `-Sku`
    - The parameter : 'Sku' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'String'.

### `New-AzApiManagementOperation`

- Parameter breaking-change will happen to all parameter sets
  - `-Request`
    - Change Request.Representations.Sample to Request.Representations.Example
  - `-Responses`
    - Change Responses.Representations.Sample to Responses.Representations.Example

### `Set-AzApiManagementOperation`

- Parameter breaking-change will happen to all parameter sets
  - `-Request`
    - Change Request.Representations.Sample Request.Representations.Example
  - `-Responses`
    - Change Responses.Representations.Sample to Responses.Representations.Example

### `Update-AzApiManagementRegion`

- Parameter breaking-change will happen to all parameter sets
  - `-Sku`
    - The parameter : 'Sku' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'String'.

## Az.Batch

### `Get-AzBatchAccountKey`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchAccountKeys alias will be removed in an upcoming breaking change release

### `Get-AzBatchJobStatistic`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchJobStatistics alias will be removed in an upcoming breaking change release

### `Get-AzBatchLocationQuota`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchLocationQuotas alias will be removed in an upcoming breaking change release

### `Get-AzBatchPoolNodeCount`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchPoolNodeCounts alias will be removed in an upcoming breaking change release

### `Get-AzBatchPoolStatistic`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchPoolStatistics alias will be removed in an upcoming breaking change release

### `Get-AzBatchPoolUsageMetric`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchPoolUsageMetrics alias will be removed in an upcoming breaking change release

### `Get-AzBatchRemoteLoginSetting`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchRemoteLoginSettings alias will be removed in an upcoming breaking change release

### `Get-AzBatchTaskCount`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzBatchTaskCounts alias will be removed in an upcoming breaking change release

### `New-AzBatchPool`

- Parameter breaking-change will happen to all parameter sets
  - `-TaskSlotsPerNode`
    - The parameter : 'MaxTasksPerComputeNode' is changing.

## Az.Billing

### `Get-AzBillingPeriod`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

## Az.CognitiveServices

### `Get-AzCognitiveServicesAccountSku`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzCognitiveServicesAccountSkus alias will be removed in an upcoming breaking change release

## Az.Compute

### `New-AzDisk`

- Cmdlet breaking-change will happen to all parameter set
  - Starting on 10/12/2022 the "New-AzDisk" cmdlet will deploy with the Trusted Launch configuration by default. This includes defaulting the "HyperVGeneration" parameter to "v2". To know more about Trusted Launch, please visit https://docs.microsoft.com/en-us/azure/virtual-machines/trusted-launch

### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter set
  - Starting on 10/12/2022 the "New-AzVM" cmdlet will deploy with the Trusted Launch configuration by default. To know more about Trusted Launch, please visit https://docs.microsoft.com/en-us/azure/virtual-machines/trusted-launch
  - It is recommended to use parameter "-PublicIpSku Standard" in order to create a new VM with a Standard public IP.Specifying zone(s) using the "-Zone" parameter will also result in a Standard public IP.If "-Zone" and "-PublicIpSku" are not specified, the VM will be created with a Basic public IP instead.Please note that the Standard SKU IPs will become the default behavior for VM creation in the future

### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter set
  - Starting on 10/12/2022 the "New-AzVmss" cmdlet will deploy with the Trusted Launch configuration by default. To know more about Trusted Launch, please visit https://docs.microsoft.com/en-us/azure/virtual-machines/trusted-launch

## Az.DataLakeStore

### `Export-AzDataLakeStoreChildItemProperty`

- Cmdlet breaking-change will happen to all parameter set
  - Export-AzDataLakeStoreChildItemProperties alias will be removed in an upcoming breaking change release

### `Export-AzDataLakeStoreItem`

- Cmdlet breaking-change will happen to all parameter set
  - For store side export failures, Export-AzDataLakeStoreItem will throw exception instead of printing message on screen

### `Import-AzDataLakeStoreItem`

- Cmdlet breaking-change will happen to all parameter set
  - For store side import failures, Import-AzDataLakeStoreItem will throw exception instead of printing message on screen

## Az.DataShare

### `Get-AzDataShare`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareAccount`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareDataSet`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareDataSetMapping`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareInvitation`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareProviderShareSubscription`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareReceivedInvitation`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareSourceDataSet`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareSubscription`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareSubscriptionSynchronization`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareSubscriptionSynchronizationDetail`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareSynchronization`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareSynchronizationDetail`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareSynchronizationSetting`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Get-AzDataShareTrigger`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Grant-AzDataShareSubscriptionAccess`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShare`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShareAccount`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShareDataSet`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShareDataSetMapping`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShareInvitation`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShareSubscription`

- Cmdlet breaking-change will happen to all parameter set
  - Parameter SourceShareLocation is mandatory to support cross region share subscription creation.
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShareSynchronizationSetting`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `New-AzDataShareTrigger`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShare`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShareAccount`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShareDataSet`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShareDataSetMapping`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShareInvitation`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShareSubscription`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShareSynchronizationSetting`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Remove-AzDataShareTrigger`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Revoke-AzDataShareSubscriptionAccess`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Set-AzDataShare`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Start-AzDataShareSubscriptionSynchronization`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

### `Stop-AzDataShareSubscriptionSynchronization`

- Cmdlet breaking-change will happen to all parameter set
  - DataShare APIs cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

## Az.EventHub

### `Add-AzEventHubIPRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzEventHubNetworkRuleSet.

### `Add-AzEventHubVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzEventHubNetworkRuleSet.

### `Approve-AzEventHubPrivateEndpointConnection`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IPrivateEndpointConnection'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Deny-AzEventHubPrivateEndpointConnection`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IPrivateEndpointConnection'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzEventHub`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEventHub'

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.
  - `-NamespaceObject`
    - The parameter : 'NamespaceObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEventHub'.

### `Get-AzEventHubApplicationGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to `Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IApplicationGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/applicationGroups/{applicationGroupName}. Namespace resource id can no longer be used for list calls.

### `Get-AzEventHubAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAuthorizationRule'

### `Get-AzEventHubCluster`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.ICluster'

- Parameter breaking-change will happen to all parameter sets
  - `-Name`
    - The alias of this parameter would change to 'ClusterName'

### `Get-AzEventHubClustersAvailableRegion`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAvailableCluster'

### `Get-AzEventHubConsumerGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IConsumerGroup'

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzEventHubGeoDRConfiguration`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IArmDisasterRecovery'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IArmDisasterRecovery'.
  - `-Name`
    - 'Name' would be removed from NamespaceInputObjectSet
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzEventHubKey`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAccessKeys'

### `Get-AzEventHubNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup'
  - The following properties are being added to the output type : 'ResourceGroupName' 'Tags'

### `Get-AzEventHubNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INetworkRuleSet'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzEventHubPrivateEndpointConnection`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IPrivateEndpointConnection'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}. Namespace resource id can no longer be used for list calls.

### `Get-AzEventHubPrivateLink`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IPrivateLinkResourcesListResult'

### `Get-AzEventHubSchemaGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.ISchemaGroup'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/schemagroups/{schemaGroupName}. Namespace resource id can no longer be used for list calls.

### `New-AzEventHub`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEventHub'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - 'InputObject' would be removed without being replaced.

### `New-AzEventHubApplicationGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to `Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IApplicationGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ThrottlingPolicyConfig`
    - The parameter : 'ThrottlingPolicyConfig' is being replaced by parameter : 'Policy'.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IThrottlingPolicy'.

### `New-AzEventHubAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAuthorizationRule'

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The output type of the parameter would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.AccessRights[]'

### `New-AzEventHubCluster`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.ICluster'

- Parameter breaking-change will happen to all parameter sets
  - `-Name`
    - 'Name' Parameter is being deprecated from ClusterResourceIdParameterSet without being replaced. ResourceId's are implicit of resource name.
  - `-ResourceId`
    - 'ResourceId' Parameter is being deprecated without being replaced.

### `New-AzEventHubConsumerGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IConsumerGroup'

### `New-AzEventHubGeoDRConfiguration`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IArmDisasterRecovery'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject would be removed without being replaced.
  - `-ResourceId`
    - ResourceId would be removed without being replaced.

### `New-AzEventHubKey`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAccessKeys'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzEventHubNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup' 'Identity'
  - The following properties are being added to the output type : 'ResourceGroupName' 'Tags' 'IdentityType'

### `New-AzEventHubSchemaGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.ISchemaGroup'

### `New-AzEventHubThrottlingPolicyConfig`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to `Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IThrottlingPolicy`

### `Remove-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - EventhubInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubApplicationGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - ApplicationGroupInputObjectParameterSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Force`
    - Parameter -Force would be removed without being replaced

### `Remove-AzEventHubCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - ClusterInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubConsumerGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - ConsumergroupInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubGeoDRConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - GeoDRConfigurationInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubIPRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzEventHubNetworkRuleSet.

### `Remove-AzEventHubNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzEventHubNetworkRuleSet.

### `Remove-AzEventHubPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubSchemaGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzEventHubNetworkRuleSet.

### `Set-AzEventHub`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEventHub'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - EventhubInputObjectSet parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -EventHubObj.

### `Set-AzEventHubApplicationGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to `Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IApplicationGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - ApplicationGroupInputObjectParameterSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.
  - `-ThrottlingPolicyConfig`
    - The parameter : 'ThrottlingPolicyConfig' is being replaced by parameter : 'Policy'.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IThrottlingPolicy'.

### `Set-AzEventHubAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAuthorizationRule'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - AuthoRuleInputObjectSet parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -AuthRuleObj.
  - `-Rights`
    - The output type of the parameter would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.AccessRights[]'

### `Set-AzEventHubCluster`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.ICluster'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - ClusterInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-Location`
    - Location Parameter is being deprecated without being replaced
  - `-Name`
    - 'Name' Parameter is being deprecated from ClusterResourceIdParameterSet without being replaced. ResourceId's are implicit of resource name.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Set-AzEventHubConsumerGroup`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IConsumerGroup'

### `Set-AzEventHubGeoDRConfigurationBreakPair`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - GeoDRConfigurationInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Set-AzEventHubGeoDRConfigurationFailOver`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - GeoDRConfigurationInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Set-AzEventHubNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup' 'IdentityUserDefined' 'Identity' 'KeyProperty'
  - The following properties are being added to the output type : 'ResourceGroupName' 'Tags' 'IdentityType' 'EncryptionConfig'

### `Set-AzEventHubNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INetworkRuleSet'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - NetwrokruleSetInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-IPRule`
    - The parameter : 'IPRule' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSNWRuleSetIpRulesAttributes[]' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INwRuleSetIPRules[]'.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.
  - `-VirtualNetworkRule`
    - The parameter : 'VirtualNetworkRule' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSNWRuleSetVirtualNetworkRulesAttributes[]' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INwRuleSetVirtualNetworkRules[]'.

### `Test-AzEventHubName`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204690 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.ICheckNameAvailabilityResult'

## Az.HDInsight

### `New-AzHDInsightCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-RdpAccessExpiry`
    - This parameter is being deprecated.
  - `-RdpCredential`
    - This parameter is being deprecated.

## Az.LogicApp

### `New-AzIntegrationAccountMap`

- Parameter breaking-change will happen to all parameter sets
  - `-ContentType`
    - ContentType is being deprecated without being replaced. It will be inferred from MapType

### `Set-AzIntegrationAccountMap`

- Parameter breaking-change will happen to all parameter sets
  - `-ContentType`
    - ContentType is being deprecated without being replaced. It will be inferred from MapType

## Az.MachineLearning

### `Get-AzMlWebServiceKey`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzMlWebServiceKeys alias will be removed in an upcoming breaking change release

## Az.MarketplaceOrdering

### `Get-AzMarketplaceTerms`

- Cmdlet breaking-change will happen to all parameter set
  - Cmdlet will call GET /subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/offerTypes/{offerType}/publishers/{publisherId}/offers/{offerId}/plans/{planId}/agreements/current by default in an upcoming breaking change release.

## Az.Media

### `Get-AzMediaServiceKey`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzMediaServiceKeys alias will be removed in an upcoming breaking change release

### `Sync-AzMediaServiceStorageKey`

- Cmdlet breaking-change will happen to all parameter set
  - Sync-AzMediaServiceStorageKeys alias will be removed in an upcoming breaking change release

## Az.Monitor

### `Add-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzAutoscaleSetting' is replacing this cmdlet.
  - API version bump up to 2022-10-01, input/output type will be also updated to match the new API version

### `Disable-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzActivityLogAlert' is replacing this cmdlet.

### `Enable-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzActivityLogAlert' is replacing this cmdlet.

### `Get-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2020-10-01, output type will be also updated to match the new API version

### `Get-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2022-10-01, output type will be also updated to match the new API version

### `Get-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2021-05-01-preview, output type will be also updated to match the new API version

### `Get-AzDiagnosticSettingCategory`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2021-05-01-preview, output type will be also updated to match the new API version

### `Get-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2021-08-01, output type will be also updated to match the new API version

### `Get-AzSubscriptionDiagnosticSettingCategory`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Get-AzEventCategory' is replacing this cmdlet.

### `New-AzActionGroup`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2020-10-01, input/output type will be also updated to match the new API version

### `New-AzActivityLogAlertCondition`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject' is replacing this cmdlet.

### `New-AzAutoscaleNotification`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzAutoscaleNotificationObject' is replacing this cmdlet.

### `New-AzAutoscaleProfile`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzAutoscaleProfileObject' is replacing this cmdlet.

### `New-AzAutoscaleRule`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzAutoscaleScaleRuleObject' is replacing this cmdlet.

### `New-AzAutoscaleWebhook`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzAutoscaleWebhookNotificationObject' is replacing this cmdlet.

### `New-AzDiagnosticDetailSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzDiagnosticSettingLogSettingsObject' is replacing this cmdlet.
  - The cmdlet 'New-AzDiagnosticSettingMetricSettingsObject' is replacing this cmdlet.

### `New-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2021-05-01-preview, input/output type will be also updated to match the new API version

### `New-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2021-08-01, input/output type will be also updated to match the new API version

### `New-AzScheduledQueryRuleAlertingAction`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `New-AzScheduledQueryRuleAznsActionGroup`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `New-AzScheduledQueryRuleLogMetricTrigger`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `New-AzScheduledQueryRuleSchedule`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `New-AzScheduledQueryRuleSource`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `New-AzScheduledQueryRuleTriggerCondition`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `Remove-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2020-10-01, output type will be also updated to match the new API version

### `Remove-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2022-10-01, output type will be also updated to match the new API version

### `Remove-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzDiagnosticSettingLogSettingsObject' is replacing this cmdlet.
  - API version bump up to 2021-05-01-preview, output type will be also updated to match the new API version

### `Remove-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2021-08-01, output type will be also updated to match the new API version

### `Set-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzActivityLogAlert' is replacing this cmdlet.

### `Set-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `Set-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `Update-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter set
  - API version bump up to 2021-08-01, input/output type will be also updated to match the new API version

## Az.NetAppFiles

### `Get-AzNetAppFilesBackupPolicy`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
  - The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'

### `Get-AzNetAppFilesVault`

- Cmdlet breaking-change will happen to all parameter set
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' to the new type :'PSNetAppFilesVault'

### `New-AzNetAppFilesBackupPolicy`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
  - The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'

- Parameter breaking-change will happen to all parameter sets
  - `-YearlyBackupsToKeep`
    - Parameter YearlyBackupsToKeep is invalid and preserved for compatibility.

### `New-AzNetAppFilesVolume`

- Parameter breaking-change will happen to all parameter sets
  - `-Snapshot`
    - Snapshot invalid and preserved for compatibility. Parameter SnapshotPolicyId should be used instead
  - `-UnixPermission`
    - Parameter Alias UnixPermissions will be removed, please use UnixPermission.

### `Remove-AzNetAppFilesBackupPolicy`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
  - The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'

### `Set-AzNetAppFilesBackupPolicy`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
  - The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'

- Parameter breaking-change will happen to all parameter sets
  - `-YearlyBackupsToKeep`
    - Parameter YearlyBackupsToKeep is invalid and preserved for compatibility.

### `Update-AzNetAppFilesBackupPolicy`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
  - The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'

- Parameter breaking-change will happen to all parameter sets
  - `-YearlyBackupsToKeep`
    - Parameter YearlyBackupsToKeep is invalid and preserved for compatibility.

## Az.Network

### `Add-AzApplicationGatewayBackendHttpSetting`

- Cmdlet breaking-change will happen to all parameter set
  - Add-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release

### `Add-AzExpressRouteCircuitAuthorization`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Add-AzExpressRouteCircuitConnectionConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Add-AzExpressRouteCircuitPeeringConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Add-AzVirtualHubRoute`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzVHubRoute' is replacing this cmdlet.

### `Add-AzVirtualHubRouteTable`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzVHubRouteTable' is replacing this cmdlet.

### `Add-AzVirtualNetworkSubnetConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - Update Property Name
  - `-ResourceId`
    - Update Property Name

### `Add-AzVirtualRouterPeer`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Add-AzRouteServerPeer' is replacing this cmdlet.

### `Get-AzApplicationGatewayAvailableSslOption`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzApplicationGatewayAvailableSslOptions alias will be removed in an upcoming breaking change release

### `Get-AzApplicationGatewayAvailableWafRuleSet`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzApplicationGatewayAvailableWafRuleSets alias will be removed in an upcoming breaking change release

### `Get-AzApplicationGatewayBackendHttpSetting`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release

### `Get-AzExpressRouteCircuit`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Get-AzExpressRouteCircuitAuthorization`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Get-AzExpressRouteCircuitPeeringConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Get-AzExpressRouteCircuitStat`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzExpressRouteCircuitStats alias will be removed in an upcoming breaking change release

### `Get-AzFirewall`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' is changing
  - The following properties in the output type are being deprecated : 'publicIPAddresses'
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' is changing
  - The following properties in the output type are being deprecated : 'IdentifyTopFatFlow'

### `Get-AzPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-Description`
    - Parameter is being deprecated without being replaced

### `Get-AzVirtualHubRouteTable`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Get-AzVHubRouteTable' is replacing this cmdlet.

### `Get-AzVirtualRouter`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Get-AzRouteServer' is replacing this cmdlet.

### `Get-AzVirtualRouterPeer`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Get-AzRouteServerPeer' is replacing this cmdlet.

### `Get-AzVirtualRouterPeerAdvertisedRoute`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Get-AzRouteServerPeerAdvertisedRoute' is replacing this cmdlet.

### `Get-AzVirtualRouterPeerLearnedRoute`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Get-AzRouteServerPeerLearnedRoute' is replacing this cmdlet.

### `Move-AzExpressRouteCircuit`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `New-AzApplicationGateway`

- Parameter breaking-change will happen to all parameter sets
  - `-UserAssignedIdentityId`
    - The parameter : 'UserAssignedIdentityId' is being replaced by parameter : 'Identity'.

### `New-AzApplicationGatewayBackendHttpSetting`

- Cmdlet breaking-change will happen to all parameter set
  - New-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release

### `New-AzExpressRouteCircuit`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `New-AzFirewall`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' is changing
  - The following properties in the output type are being deprecated : 'publicIPAddresses'
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' is changing
  - The following properties in the output type are being deprecated : 'IdentifyTopFatFlow'

- Parameter breaking-change will happen to all parameter sets
  - `-IdentifyTopFatFlow`
    - The parameter : 'IdentifyTopFatFlow' is being replaced by parameter : 'EnableFatFlowLogging'.
  - `-PublicIpName`
    - This parameter will be removed in an upcoming breaking change release. After this point the Public IP Address will be provided as a list of one or more objects instead of a string.
  - `-VirtualNetworkName`
    - This parameter will be removed in an upcoming breaking change release. After this point the Virtual Network will be provided as an object instead of a string.

### `New-AzFirewallHubIpAddress`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' is changing
  - The following properties in the output type are being deprecated : 'publicIPAddresses'

### `New-AzFirewallPolicyApplicationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-SourceAddress`
    - This parameter is becoming optional as SourceIpGroup can be provided without this.

### `New-AzFirewallPolicyNetworkRule`

- Parameter breaking-change will happen to all parameter sets
  - `-SourceAddress`
    - This parameter is becoming optional as SourceIpGroup can be provided without this.

### `New-AzLoadBalancer`

- Cmdlet breaking-change will happen to all parameter set
  - It is recommended to use parameter '-Sku Standard' to create new IP address. Please note that it will become the default behavior for IP address creation in the future.

### `New-AzLoadBalancerFrontendIpConfig`

- Cmdlet breaking-change will happen to all parameter set
  - Default behaviour of Zone will be changed

### `New-AzPrivateLinkServiceIpConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSPrivateLinkServiceIpConfiguration' is changing
  - The following properties in the output type are being deprecated : 'PublicIPAddress'
  - The following properties are being added to the output type : 'Primary'

- Parameter breaking-change will happen to all parameter sets
  - `-PublicIpAddress`
    - Parameter is being deprecated without being replaced

### `New-AzPublicIpAddress`

- Cmdlet breaking-change will happen to all parameter set
  - Default behaviour of Zone will be changed
  - It is recommended to use parameter '-Sku Standard' to create new IP address. Please note that it will become the default behavior for IP address creation in the future.

### `New-AzPublicIpPrefix`

- Cmdlet breaking-change will happen to all parameter set
  - Default behaviour of Zone will be changed

### `New-AzVirtualHub`

- Parameter breaking-change will happen to all parameter sets
  - `-HubVnetConnection`
    - HubVnetConnection parameter is deprecated. Use *VirtualHubVnetConnection* commands
  - `-PreferredRoutingGateway`
    - PreferredRoutingGateway parameter is deprecated. Use *HubRoutingPreference* property
  - `-RouteTable`
    - Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.

### `New-AzVirtualHubRoute`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzVHubRoute' is replacing this cmdlet.

### `New-AzVirtualHubRouteTable`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzVHubRouteTable' is replacing this cmdlet.

### `New-AzVirtualHubVnetConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-EnableInternetSecurity`
    - The parameter : 'EnableInternetSecurity' is changing.
    The type of the parameter is changing from 'System.Management.Automation.SwitchParameter' to 'EnableInternetSecurityFlag'.

### `New-AzVirtualNetworkSubnetConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - Update Property Name
  - `-ResourceId`
    - Update Property Name

### `New-AzVirtualRouter`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzRouteServer' is replacing this cmdlet.

### `Remove-AzApplicationGatewayBackendHttpSetting`

- Cmdlet breaking-change will happen to all parameter set
  - Remove-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release

### `Remove-AzExpressRouteCircuitAuthorization`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Remove-AzExpressRouteCircuitConnectionConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Remove-AzExpressRouteCircuitPeeringConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Remove-AzPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-Description`
    - Parameter is being deprecated without being replaced

### `Remove-AzVirtualHubRouteTable`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Remove-AzVHubRouteTable' is replacing this cmdlet.

### `Remove-AzVirtualRouter`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Remove-AzRouteServer' is replacing this cmdlet.

### `Remove-AzVirtualRouterPeer`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Remove-AzRouteServerPeer' is replacing this cmdlet.

### `Set-AzApplicationGatewayBackendHttpSetting`

- Cmdlet breaking-change will happen to all parameter set
  - Set-AzApplicationGatewayBackendHttpSettings alias will be removed in an upcoming breaking change release

### `Set-AzExpressRouteCircuit`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Set-AzExpressRouteCircuitConnectionConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Set-AzExpressRouteCircuitPeeringConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `Set-AzFirewall`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' is changing
  - The following properties in the output type are being deprecated : 'publicIPAddresses'
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' is changing
  - The following properties in the output type are being deprecated : 'IdentifyTopFatFlow'

### `Set-AzVirtualHub`

- Parameter breaking-change will happen to all parameter sets
  - `-RouteTable`
    - Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.

### `Set-AzVirtualNetworkSubnetConfig`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - Update Property Name
  - `-ResourceId`
    - Update Property Name

### `Update-AzVirtualHub`

- Parameter breaking-change will happen to all parameter sets
  - `-HubVnetConnection`
    - HubVnetConnection parameter is deprecated. Use *VirtualHubVnetConnection* commands
  - `-PreferredRoutingGateway`
    - PreferredRoutingGateway parameter will be deprecated. Use *HubRoutingPreference* parameter
  - `-RouteTable`
    - Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.

### `Update-AzVirtualRouter`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzRouteServer' is replacing this cmdlet.

### `Update-AzVirtualRouterPeer`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzRouteServerPeer' is replacing this cmdlet.

## Az.NotificationHubs

### `Get-AzNotificationHubAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzNotificationHubAuthorizationRules alias will be removed in an upcoming breaking change release

### `Get-AzNotificationHubListKey`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzNotificationHubListKeys alias will be removed in an upcoming breaking change release

### `Get-AzNotificationHubPNSCredential`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzNotificationHubPNSCredentials alias will be removed in an upcoming breaking change release

### `Get-AzNotificationHubsNamespaceAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzNotificationHubsNamespaceAuthorizationRules alias will be removed in an upcoming breaking change release

### `Get-AzNotificationHubsNamespaceListKey`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzNotificationHubsNamespaceListKeys alias will be removed in an upcoming breaking change release

### `New-AzNotificationHubAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - New-AzNotificationHubAuthorizationRules alias will be removed in an upcoming breaking change release

### `New-AzNotificationHubsNamespaceAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - New-AzNotificationHubsNamespaceAuthorizationRules alias will be removed in an upcoming breaking change release

### `Remove-AzNotificationHubAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - Remove-AzNotificationHubAuthorizationRules alias will be removed in an upcoming breaking change release

### `Remove-AzNotificationHubsNamespaceAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - Remove-AzNotificationHubsNamespaceAuthorizationRules alias will be removed in an upcoming breaking change release

### `Set-AzNotificationHubAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - Set-AzNotificationHubAuthorizationRules alias will be removed in an upcoming breaking change release

### `Set-AzNotificationHubsNamespaceAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - Set-AzNotificationHubsNamespaceAuthorizationRules alias will be removed in an upcoming breaking change release

## Az.OperationalInsights

### `Get-AzOperationalInsightsCluster`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster' is changing
  - The following properties in the output type are being deprecated : 'NextLink' 'Sku'

### `Get-AzOperationalInsightsIntelligencePack`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzOperationalInsightsIntelligencePacks alias will be removed in an upcoming breaking change release

### `Get-AzOperationalInsightsWorkspaceManagementGroup`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzOperationalInsightsWorkspaceManagementGroups alias will be removed in an upcoming breaking change release

### `Get-AzOperationalInsightsWorkspaceSharedKey`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzOperationalInsightsWorkspaceSharedKeys alias will be removed in an upcoming breaking change release

### `New-AzOperationalInsightsCluster`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster' is changing
  - The following properties in the output type are being deprecated : 'NextLink' 'Sku'

### `Update-AzOperationalInsightsCluster`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster' is changing
  - The following properties in the output type are being deprecated : 'NextLink' 'Sku'

## Az.PowerBIEmbedded

### `Get-AzPowerBIWorkspaceCollectionAccessKey`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzPowerBIWorkspaceCollectionAccessKeys alias will be removed in an upcoming breaking change release

### `Reset-AzPowerBIWorkspaceCollectionAccessKey`

- Cmdlet breaking-change will happen to all parameter set
  - Reset-AzPowerBIWorkspaceCollectionAccessKeys alias will be removed in an upcoming breaking change release

## Az.RecoveryServices

### `Get-AzRecoveryServicesVaultSettingsFile`

- Parameter breaking-change will happen to all parameter sets
  - `-Certificate`
    - Parameter is being deprecated without being replaced

## Az.RedisCache

### `Remove-AzRedisCacheDiagnostic`

- Cmdlet breaking-change will happen to all parameter set
  - Remove-AzRedisCacheDiagnostics alias will be removed in an upcoming breaking change release

### `Set-AzRedisCacheDiagnostic`

- Cmdlet breaking-change will happen to all parameter set
  - Set-AzRedisCacheDiagnostics alias will be removed in an upcoming breaking change release

## Az.Resources

### `Export-AzResourceGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ApiVersion`
    - Parameter is being deprecated without being replaced. Using the lastest possible API version will become the default behavior.

### `Get-AzManagementGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Get-AzManagementGroupHierarchySetting`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Get-AzManagementGroupNameAvailability`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Get-AzManagementGroupSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Get-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties are being added to the output type : 'Identity'

### `New-AzManagementGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `New-AzManagementGroupHierarchySetting`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `New-AzManagementGroupSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `New-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties are being added to the output type : 'Identity'

- Parameter breaking-change will happen to all parameter sets
  - `-AssignIdentity`
    - Parameter AssignIdentity is deprecated and will be removed in future releases. Please use the 'IdentityType' parameter instead.

### `Remove-AzManagementGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Remove-AzManagementGroupHierarchySetting`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Remove-AzManagementGroupSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Set-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties are being added to the output type : 'Identity'

- Parameter breaking-change will happen to all parameter sets
  - `-AssignIdentity`
    - Parameter AssignIdentity is deprecated and will be removed in future releases. Please use the 'IdentityType' parameter instead.

### `Update-AzManagementGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

### `Update-AzManagementGroupHierarchySetting`

- Parameter breaking-change will happen to all parameter sets
  - `-GroupName`
    - We will replace GroupName with GroupId to make it more clear.

## Az.Security

### `Get-AzSecurityAlert`

- Cmdlet breaking-change will happen to all parameter set
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.Security.Models.Alerts.PSSecurityAlert' to the new type :'PSSecurityAlertV3'

### `Set-AzSecurityAlert`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.Security.Models.Alerts.PSSecurityAlert' to 'PSSecurityAlertV3'.

## Az.ServiceBus

### `Add-AzServiceBusIPRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzServiceBusNetworkRuleSet.

### `Add-AzServiceBusVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzServiceBusNetworkRuleSet.

### `Approve-AzServiceBusPrivateEndpointConnection`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IPrivateEndpointConnection'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Complete-AzServiceBusMigration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSServiceBusDRConfigurationAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'.
  - `-ResourceId`
    - InputObject

### `Deny-AzServiceBusPrivateEndpointConnection`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IPrivateEndpointConnection'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzServiceBusAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbAuthorizationRule'

### `Get-AzServiceBusGeoDRConfiguration`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IArmDisasterRecovery'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
  - `-Name`
    - 'Name' would be removed from NamespaceInputObjectSet
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzServiceBusKey`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IAccessKeys'

### `Get-AzServiceBusMigration`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'.

### `Get-AzServiceBusNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup'
  - The following properties are being added to the output type : 'ResourceGroupName'

### `Get-AzServiceBusNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.INetworkRuleSet'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzServiceBusPrivateEndpointConnection`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IPrivateEndpointConnection'

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}. Namespace resource id can no longer be used for list calls.

### `Get-AzServiceBusPrivateLink`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IPrivateLinkResourcesListResult'

### `Get-AzServiceBusQueue`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbQueue'

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzServiceBusRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IRule'

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzServiceBusSubscription`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbSubscription'

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzServiceBusTopic`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbTopic'

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzServiceBusAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbAuthorizationRule'

### `New-AzServiceBusGeoDRConfiguration`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IArmDisasterRecovery'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - 'InputObject' would be removed without being replaced.
  - `-ResourceId`
    - 'ResourceId' would be removed without being replaced.

### `New-AzServiceBusKey`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IAccessKeys'

### `New-AzServiceBusNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup'
  - The following properties are being added to the output type : 'ResourceGroupName'

### `New-AzServiceBusQueue`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbQueue'

- Parameter breaking-change will happen to all parameter sets
  - `-AutoDeleteOnIdle`
    - AutoDeleteOnIdle, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DefaultMessageTimeToLive`
    - DefaultMessageTimeToLive, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DuplicateDetectionHistoryTimeWindow`
    - DuplicateDetectionHistoryTimeWindow, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-LockDuration`
    - LockDuration, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.

### `New-AzServiceBusRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IRule'

### `New-AzServiceBusSubscription`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbSubscription'

- Parameter breaking-change will happen to all parameter sets
  - `-AutoDeleteOnIdle`
    - AutoDeleteOnIdle, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DefaultMessageTimeToLive`
    - DefaultMessageTimeToLive, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-LockDuration`
    - LockDuration, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.

### `New-AzServiceBusTopic`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbTopic'

- Parameter breaking-change will happen to all parameter sets
  - `-AutoDeleteOnIdle`
    - AutoDeleteOnIdle, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DefaultMessageTimeToLive`
    - DefaultMessageTimeToLive, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DuplicateDetectionHistoryTimeWindow`
    - DuplicateDetectionHistoryTimeWindow, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Remove-AzServiceBusAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Force`
    - Parameter -Force would be removed without being replaced
  - `-InputObject`
    - AuthoRuleInputObjectSet parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -AuthRuleObj.

### `Remove-AzServiceBusGeoDRConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSServiceBusDRConfigurationAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IArmDisasterRecovery'.
  - `-ResourceId`
    - InputObject

### `Remove-AzServiceBusIPRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzServiceBusNetworkRuleSet.

### `Remove-AzServiceBusMigration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSServiceBusDRConfigurationAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'.

### `Remove-AzServiceBusNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzServiceBusNetworkRuleSet.

### `Remove-AzServiceBusPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzServiceBusQueue`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSQueueAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbQueue'.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzServiceBusRule`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSTopicAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IRule'.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSSubscriptionAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbSubscription'.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzServiceBusTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSTopicAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbTopic'.
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzServiceBusVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter set
  - This cmdlet would be deprecated in a future release. Please use Set-AzServiceBusNetworkRuleSet.

### `Set-AzServiceBusAuthorizationRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbAuthorizationRule'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - AuthoRuleInputObjectSet parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -AuthRuleObj.

### `Set-AzServiceBusGeoDRConfigurationBreakPair`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - GeoDRConfigurationInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - InputObject

### `Set-AzServiceBusGeoDRConfigurationFailOver`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - GeoDRConfigurationInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - InputObject

### `Set-AzServiceBusNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup'
  - The following properties are being added to the output type : 'ResourceGroupName'

### `Set-AzServiceBusNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.INetworkRuleSet'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - NetworkRuleSetInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-IPRule`
    - The parameter : 'IPRule' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSNWRuleSetIpRulesAttributes[]' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.INwRuleSetIPRules[]'.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.
  - `-VirtualNetworkRule`
    - The parameter : 'VirtualNetworkRule' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSNWRuleSetVirtualNetworkRulesAttributes[]' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.INwRuleSetVirtualNetworkRules[]'.

### `Set-AzServiceBusQueue`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbQueue'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -QueueObj.

### `Set-AzServiceBusRule`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IRule'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.

### `Set-AzServiceBusSubscription`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbSubscription'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -SubscriptionObj.

### `Set-AzServiceBusTopic`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbTopic'

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -TopicObj.
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Start-AzServiceBusMigration`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'

### `Stop-AzServiceBusMigration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSServiceBusDRConfigurationAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'.
  - `-ResourceId`
    - InputObject

### `Test-AzServiceBusName`

- Cmdlet breaking-change will happen to all parameter set
  - PLEASE REFER OUR MIGRATION GUIDE https://go.microsoft.com/fwlink/?linkid=2204584 TO KNOW MORE ABOUT BREAKING CHANGES.
  - Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ICheckNameAvailabilityResult'

## Az.SignalR

### `Get-AzSignalR`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' is changing
  - The following properties in the output type are being deprecated : 'HostNamePrefix'

### `New-AzSignalR`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' is changing
  - The following properties in the output type are being deprecated : 'HostNamePrefix'

### `Update-AzSignalR`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' is changing
  - The following properties in the output type are being deprecated : 'HostNamePrefix'

## Az.Sql

### `Clear-AzSqlDatabaseAdvancedThreatProtectionSetting`

- Cmdlet breaking-change will happen to all parameter set
  - Clear-AzSqlDatabaseAdvancedThreatProtectionSetting cmdlet will be removed in an upcoming breaking change release

### `Clear-AzSqlServerAdvancedThreatProtectionSetting`

- Cmdlet breaking-change will happen to all parameter set
  - Clear-AzSqlServerAdvancedThreatProtectionSetting cmdlet will be removed in an upcoming breaking change release

### `Disable-AzSqlServerAdvancedDataSecurity`

- Cmdlet breaking-change will happen to all parameter set
  - Disable-AzSqlServerAdvancedThreatProtection alias will be removed in an upcoming breaking change release

### `Enable-AzSqlServerAdvancedDataSecurity`

- Cmdlet breaking-change will happen to all parameter set
  - Enable-AzSqlServerAdvancedThreatProtection alias will be removed in an upcoming breaking change release

### `Get-AzSqlDatabase`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Get-AzSqlDatabaseAdvancedThreatProtectionSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DatabaseThreatDetectionPolicyModel' to the new type :'DatabaseAdvancedThreatProtectionSettingsModel'

### `Get-AzSqlDatabaseReplicationLink`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Get-AzSqlInstance`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Get-AzSqlServerAdvancedDataSecurityPolicy`

- Cmdlet breaking-change will happen to all parameter set
  - Get-AzSqlServerAdvancedThreatProtectionPolicy alias will be removed in an upcoming breaking change release

### `Get-AzSqlServerAdvancedThreatProtectionSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The output type is changing from the existing type :'Microsoft.Azure.Commands.Sql.ThreatDetection.Model.ServerThreatDetectionPolicyModel' to the new type :'ServerAdvancedThreatProtectionSettingsModel'

### `New-AzSqlDatabase`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `New-AzSqlDatabaseCopy`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureSqlDatabaseCopyModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `New-AzSqlDatabaseSecondary`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `New-AzSqlInstance`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Remove-AzSqlDatabase`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Remove-AzSqlDatabaseSecondary`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Remove-AzSqlInstance`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Set-AzSqlDatabase`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Set-AzSqlDatabaseSecondary`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Set-AzSqlInstance`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
  - The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
  - The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

### `Update-AzSqlDatabaseAdvancedThreatProtectionSetting`

- Parameter breaking-change will happen to all parameter sets
  - `-EmailAdmins`
    - The parameter : 'EmailAdmins' is changing.
  - `-ExcludedDetectionType`
    - The parameter : 'ExcludedDetectionType' is changing.
  - `-NotificationRecipientsEmails`
    - The parameter : 'NotificationRecipientsEmails' is changing.
  - `-RetentionInDays`
    - The parameter : 'RetentionInDays' is changing.
  - `-StorageAccountName`
    - The parameter : 'StorageAccountName' is changing.

### `Update-AzSqlServerAdvancedThreatProtectionSetting`

- Parameter breaking-change will happen to all parameter sets
  - `-EmailAdmins`
    - The parameter : 'EmailAdmins' is changing.
  - `-ExcludedDetectionType`
    - The parameter : 'ExcludedDetectionType' is changing.
  - `-NotificationRecipientsEmails`
    - The parameter : 'NotificationRecipientsEmails' is changing.
  - `-RetentionInDays`
    - The parameter : 'RetentionInDays' is changing.
  - `-StorageAccountName`
    - The parameter : 'StorageAccountName' is changing.

## Az.Storage

### `Get-AzStorageBlob`

- Cmdlet breaking-change will happen to all parameter set
  - The returned blob properties will be moved from ICloudBlob.Properties to BlobProperties in a future release.

### `Get-AzStorageFileContent`

- Cmdlet breaking-change will happen to all parameter set
  - The returned file properties will be moved from CloudFile to FileProperties in a future release.

### `Get-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter set
  - The returned share properties will be moved from CloudFileShare.Properties to ShareProperties (with '-Name'), or ListShareProperties (without '-Name') in a future release.

### `New-AzStorageDirectory`

- Cmdlet breaking-change will happen to all parameter set
  - The returned Directory properties will be moved from CloudFileDirectory to ShareDirectoryProperties in a future release.

### `New-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter set
  - The returned share properties will be moved from CloudFileShare.Properties to ShareProperties in a future release.

### `Remove-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter set
  - The returned share properties will be moved from CloudFileShare.Properties to ShareProperties in a future release.

### `Set-AzStorageFileContent`

- Cmdlet breaking-change will happen to all parameter set
  - The returned file properties will be moved from CloudFile to FileProperties in a future release.

### `Set-AzStorageShareQuota`

- Cmdlet breaking-change will happen to all parameter set
  - The returned share properties will be moved from CloudFileShare.Properties to ShareProperties.

### `Start-AzStorageFileCopy`

- Cmdlet breaking-change will happen to all parameter set
  - The returned file properties will be moved from CloudFile to FileProperties in a future release.

## Az.StorageSync

### `Set-AzStorageSyncServerEndpoint`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - Alias RegisteredServer is invalid and preserved for compatibility. Alias ServerEndpoint should be used instead

## Az.Websites

### `New-AzWebAppContainerPSSession`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

