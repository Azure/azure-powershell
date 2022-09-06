# Upcoming breaking changes in Azure PowerShell

## Az.Aks

### `Install-AzAksCliTool`

- Cmdlet breaking-change will happen to all parameter set
  The cmdlet 'Install-AzAksCliTool' is replacing this cmdlet.
  - This change will take effect on '2022/10/12'
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

### `New-AzBatchPool`

- Parameter breaking-change will happen to all parameter sets
  - `-TaskSlotsPerNode`
    - The parameter : 'MaxTasksPerComputeNode' is changing.

## Az.Billing

### `Get-AzBillingPeriod`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

## Az.EventHub

### `Approve-AzEventHubPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Deny-AzEventHubPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.
  - `-NamespaceObject`
    - The parameter : 'NamespaceObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEventHub'.

### `Get-AzEventHubApplicationGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/applicationGroups/{applicationGroupName}. Namespace resource id can no longer be used for list calls.

### `Get-AzEventHubCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-Name`
    - The alias of this parameter would change to 'ClusterName'

### `Get-AzEventHubConsumerGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzEventHubGeoDRConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IArmDisasterRecovery'.
  - `-Name`
    - 'Name' would be removed from NamespaceInputObjectSet
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzEventHubNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup'
  - The following properties are being added to the output type : 'ResourceGroupName' 'Tags'

### `Get-AzEventHubNetworkRuleSet`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzEventHubPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}. Namespace resource id can no longer be used for list calls.

### `Get-AzEventHubSchemaGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/schemagroups/{schemaGroupName}. Namespace resource id can no longer be used for list calls.

### `New-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - 'InputObject' would be removed without being replaced.

### `New-AzEventHubApplicationGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ThrottlingPolicyConfig`
    - The parameter : 'ThrottlingPolicyConfig' is being replaced by parameter : 'Policy'.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IThrottlingPolicy'.

### `New-AzEventHubAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Rights`
    - The output type of the parameter would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.AccessRights[]'

### `New-AzEventHubCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-Name`
    - 'Name' Parameter is being deprecated from ClusterResourceIdParameterSet without being replaced. ResourceId's are implicit of resource name.
  - `-ResourceId`
    - 'ResourceId' Parameter is being deprecated without being replaced.

### `New-AzEventHubGeoDRConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject would be removed without being replaced.
  - `-ResourceId`
    - ResourceId would be removed without being replaced.

### `New-AzEventHubKey`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzEventHubNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup' 'Identity'
  - The following properties are being added to the output type : 'ResourceGroupName' 'Tags' 'IdentityType'

### `Remove-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - EventhubInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubApplicationGroup`

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

### `Remove-AzEventHubPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Remove-AzEventHubSchemaGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Set-AzEventHub`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - EventhubInputObjectSet parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -EventHubObj.

### `Set-AzEventHubApplicationGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - ApplicationGroupInputObjectParameterSet parameter set is changing. Please refer the migration guide for examples.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.
  - `-ThrottlingPolicyConfig`
    - The parameter : 'ThrottlingPolicyConfig' is being replaced by parameter : 'Policy'.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IThrottlingPolicy'.

### `Set-AzEventHubAuthorizationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - AuthoRuleInputObjectSet parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -AuthRuleObj.
  - `-Rights`
    - The output type of the parameter would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.AccessRights[]'

### `Set-AzEventHubCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - ClusterInputObjectSet parameter set is changing. Please refer the migration guide for examples.
  - `-Location`
    - Location Parameter is being deprecated without being replaced
  - `-Name`
    - 'Name' Parameter is being deprecated from ClusterResourceIdParameterSet without being replaced. ResourceId's are implicit of resource name.
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

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

## Az.Monitor

### `Add-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzAutoscaleSetting' is replacing this cmdlet.

### `Disable-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzActivityLogAlert' is replacing this cmdlet.

### `Enable-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzActivityLogAlert' is replacing this cmdlet.

### `Get-AzSubscriptionDiagnosticSettingCategory`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Get-AzEventCategory' is replacing this cmdlet.

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
  - The cmdlet 'New-AzDiagnosticSettingLogSettingsObject' is replacing this cmdlet.  - The cmdlet 'New-AzDiagnosticSettingMetricSettingsObject' is replacing this cmdlet.

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

### `Remove-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzDiagnosticSettingLogSettingsObject' is replacing this cmdlet.

### `Set-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Update-AzActivityLogAlert' is replacing this cmdlet.

### `Set-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

### `Set-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

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

### `Add-AzVirtualRouterPeer`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'Add-AzRouteServerPeer' is replacing this cmdlet.

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

### `Get-AzFirewall`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' is changing
  - The following properties in the output type are being deprecated : 'publicIPAddresses'  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' is changing
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

### `New-AzExpressRouteCircuit`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
  - The following properties in the output type are being deprecated : 'AllowGlobalReach'

### `New-AzFirewall`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' is changing
  - The following properties in the output type are being deprecated : 'publicIPAddresses'  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' is changing
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

### `New-AzPrivateLinkServiceIpConfig`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.Network.Models.PSPrivateLinkServiceIpConfiguration' is changing
  - The following properties in the output type are being deprecated : 'PublicIPAddress'
  - The following properties are being added to the output type : 'Primary'

- Parameter breaking-change will happen to all parameter sets
  - `-PublicIpAddress`
    - Parameter is being deprecated without being replaced

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

### `New-AzVirtualRouter`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet 'New-AzRouteServer' is replacing this cmdlet.

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
  - The following properties in the output type are being deprecated : 'publicIPAddresses'  - The output type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' is changing
  - The following properties in the output type are being deprecated : 'IdentifyTopFatFlow'

### `Set-AzVirtualHub`

- Parameter breaking-change will happen to all parameter sets
  - `-RouteTable`
    - Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.

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

## Az.OperationalInsights

### `Get-AzOperationalInsightsCluster`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster' is changing
  - The following properties in the output type are being deprecated : 'NextLink' 'Sku'

### `New-AzOperationalInsightsCluster`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster' is changing
  - The following properties in the output type are being deprecated : 'NextLink' 'Sku'

### `Update-AzOperationalInsightsCluster`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.OperationalInsights.Models.PSCluster' is changing
  - The following properties in the output type are being deprecated : 'NextLink' 'Sku'

## Az.RecoveryServices

### `Get-AzRecoveryServicesVaultSettingsFile`

- Parameter breaking-change will happen to all parameter sets
  - `-Certificate`
    - Parameter is being deprecated without being replaced

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

### `Approve-AzServiceBusPrivateEndpointConnection`

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

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzServiceBusGeoDRConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
  - `-Name`
    - 'Name' would be removed from NamespaceInputObjectSet
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzServiceBusMigration`

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

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - The parameter : 'ResourceId' is being replaced by parameter : 'InputObject'.

### `Get-AzServiceBusPrivateEndpointConnection`

- Parameter breaking-change will happen to all parameter sets
  - `-ResourceId`
    - Format of resource id must be /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}. Namespace resource id can no longer be used for list calls.

### `Get-AzServiceBusQueue`

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzServiceBusRule`

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.

### `Get-AzServiceBusTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-MaxCount`
    - '-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzServiceBusGeoDRConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - 'InputObject' would be removed without being replaced.
  - `-ResourceId`
    - 'ResourceId' would be removed without being replaced.

### `New-AzServiceBusNamespace`

- Cmdlet breaking-change will happen to all parameter set
  - The output type 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' is changing
  - The following properties in the output type are being deprecated : 'ResourceGroup'
  - The following properties are being added to the output type : 'ResourceGroupName'

### `New-AzServiceBusQueue`

- Parameter breaking-change will happen to all parameter sets
  - `-AutoDeleteOnIdle`
    - AutoDeleteOnIdle, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DefaultMessageTimeToLive`
    - DefaultMessageTimeToLive, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DuplicateDetectionHistoryTimeWindow`
    - DuplicateDetectionHistoryTimeWindow, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-LockDuration`
    - LockDuration, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.

### `New-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-AutoDeleteOnIdle`
    - AutoDeleteOnIdle, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-DefaultMessageTimeToLive`
    - DefaultMessageTimeToLive, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.
  - `-LockDuration`
    - LockDuration, Input type of the parameter has been changed from System.String to System.Timespan. Hence, ISO 8601 format for timespan can NO longer be fed as input to these parameters. Please use New-TimeSpan cmdlet object to construct Timespan variables.

### `New-AzServiceBusTopic`

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

### `Remove-AzServiceBusMigration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSServiceBusDRConfigurationAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'.

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

### `Set-AzServiceBusAuthorizationRule`

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

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -QueueObj.

### `Set-AzServiceBusRule`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.

### `Set-AzServiceBusSubscription`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -SubscriptionObj.

### `Set-AzServiceBusTopic`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - InputObject parameter set is changing. Please refer the migration guide for examples.
    - InputObject would no longer support alias -TopicObj.
  - `-ResourceGroupName`
    - Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Stop-AzServiceBusMigration`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - The parameter : 'InputObject' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Commands.ServiceBus.Models.PSServiceBusDRConfigurationAttributes' to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IMigrationConfigProperties'.
  - `-ResourceId`
    - InputObject

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

## Az.StorageSync

### `Set-AzStorageSyncServerEndpoint`

- Parameter breaking-change will happen to all parameter sets
  - `-InputObject`
    - Alias RegisteredServer is invalid and preserved for compatibility. Alias ServerEndpoint should be used instead

## Az.Websites

### `New-AzWebAppContainerPSSession`

- Cmdlet breaking-change will happen to all parameter set
  - The cmdlet is being deprecated. There will be no replacement for it.

