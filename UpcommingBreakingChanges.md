

# Az.AnalysisServices

## Add-AzAnalysisServicesAccount
The cmdlet is being deprecated. There will be no replacement for it.

# Az.ApiManagement

## New-AzApiManagementOperation
### Responses
Change Responses.Representations.Sample to Responses.Representations.Example
### Request
Change Request.Representations.Sample to Request.Representations.Example

## Set-AzApiManagementOperation
### Responses
Change Responses.Representations.Sample to Responses.Representations.Example
### Request
Change Request.Representations.Sample Request.Representations.Example


# Az.ApplicationInsights

## New-AzApplicationInsightsApiKey
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Set-AzApplicationInsightsPricingPlan
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## New-AzApplicationInsightsLinkedStorageAccount
### InputObject
Parameter InputObject will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Remove-AzApplicationInsightsLinkedStorageAccount
### InputObject
Parameter InputObject will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Set-AzApplicationInsightsContinuousExport
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Remove-AzApplicationInsights
### ApplicationInsightsComponent
Type of ApplicationInsightsComponent will be updated to match API 2020-02-02 in Az.ApplicationInsights 2.0.0
### ResourceId
Parameter 'ResourceId' will be removed and please use it in such way: '$resourceid | Remove-AzApplicationInsights' in upcoming Az.ApplicationInsights 2.0.0

## New-AzApplicationInsightsContinuousExport
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Update-AzApplicationInsightsLinkedStorageAccount
### InputObject
Parameter InputObject will be removed in upcoming Az.ApplicationInsights 2.0.0

## Set-AzApplicationInsightsDailyCap
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Get-AzApplicationInsightsApiKey
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Remove-AzApplicationInsightsContinuousExport
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Get-AzApplicationInsightsLinkedStorageAccount
### InputObject
Parameter InputObject will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Get-AzApplicationInsightsContinuousExport
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0

## Remove-AzApplicationInsightsApiKey
### ApplicationInsightsComponent
Parameter ApplicationInsightsComponent will be removed in upcoming Az.ApplicationInsights 2.0.0
### ResourceId
Parameter ResourceId will be removed in upcoming Az.ApplicationInsights 2.0.0


# Az.Billing

## Get-AzBillingPeriod
The cmdlet is being deprecated. There will be no replacement for it.

# Az.Cdn

## Enable-AzCdnCustomDomain
The cmdlet 'Enable-AzCdnCustomDomainHttps' is replacing this cmdlet.
## Disable-AzCdnCustomDomain
The cmdlet 'Disable-AzCdnCustomDomainHttps' is replacing this cmdlet.
## Get-AzCdnEndpointResourceUsage
### EndpointName
Parameter is being deprecated in ByObjectParameterSet without being replaced


# Az.EventHub

## Get-AzEventHubNamespace

- The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
- The following properties in the output type are being deprecated : 'ResourceGroup'
- The following properties are being added to the output type : 'ResourceGroupName' 'Tags'
## Set-AzEventHubNamespace
### State
'State' Parameter is being deprecated without being replaced

- The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
- The following properties in the output type are being deprecated : 'ResourceGroup' 'IdentityUserDefined' 'Identity' 'KeyProperty'
- The following properties are being added to the output type : 'ResourceGroupName' 'Tags' 'IdentityType' 'EncryptionConfig'
## New-AzEventHubNamespace

- The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing
- The following properties in the output type are being deprecated : 'ResourceGroup' 'Identity'
- The following properties are being added to the output type : 'ResourceGroupName' 'Tags' 'IdentityType'

# Az.HDInsight

## New-AzHDInsightCluster
### RdpAccessExpiry
This parameter is being deprecated.
### RdpCredential
This parameter is being deprecated.


# Az.LogicApp

## New-AzIntegrationAccountMap
### ContentType
ContentType is being deprecated without being replaced. It will be inferred from MapType

## Set-AzIntegrationAccountMap
### ContentType
ContentType is being deprecated without being replaced. It will be inferred from MapType


# Az.NetAppFiles

## New-AzNetAppFilesBackupPolicy
### YearlyBackupsToKeep
Parameter YearlyBackupsToKeep is invalid and preserved for compatibility.

- The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
- The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'
## Get-AzNetAppFilesBackupPolicy

- The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
- The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'
## Update-AzNetAppFilesBackupPolicy
### YearlyBackupsToKeep
Parameter YearlyBackupsToKeep is invalid and preserved for compatibility.

- The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
- The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'
## Get-AzNetAppFilesVault

- The output type is changing from the existing type :'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' to the new type :'PSNetAppFilesVault'
## Set-AzNetAppFilesBackupPolicy
### YearlyBackupsToKeep
Parameter YearlyBackupsToKeep is invalid and preserved for compatibility.

- The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
- The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'
## Remove-AzNetAppFilesBackupPolicy

- The output type 'Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupPolicy' is changing
- The following properties in the output type are being deprecated : 'YearlyBackupsToKeep'
## New-AzNetAppFilesVolume
### Snapshot
Snapshot invalid and preserved for compatibility. Parameter SnapshotPolicyId should be used instead


# Az.Network

## Add-AzVirtualHubRoute
The cmdlet 'New-AzVHubRoute' is replacing this cmdlet.
## Get-AzVirtualRouter
The cmdlet 'Get-AzRouteServer' is replacing this cmdlet.
## Add-AzVirtualRouterPeer
The cmdlet 'Add-AzRouteServerPeer' is replacing this cmdlet.
## New-AzExpressRouteCircuit

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Update-AzVirtualHub
### HubVnetConnection
HubVnetConnection parameter is deprecated. Use *VirtualHubVnetConnection* commands
### RouteTable
Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.

## New-AzVirtualHubVnetConnection
### EnableInternetSecurity

- The parameter : 'EnableInternetSecurity' is changing.
The type of the parameter is changing from 'System.Management.Automation.SwitchParameter' to 'EnableInternetSecurityFlag'.

## Add-AzExpressRouteCircuitPeeringConfig

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Remove-AzVirtualRouterPeer
The cmdlet 'Remove-AzRouteServerPeer' is replacing this cmdlet.
## Update-AzVirtualRouterPeer
The cmdlet 'Update-AzRouteServerPeer' is replacing this cmdlet.
## Move-AzExpressRouteCircuit

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Update-AzVirtualRouter
The cmdlet 'Update-AzRouteServer' is replacing this cmdlet.
## New-AzApplicationGateway
### UserAssignedIdentityId

- The parameter : 'UserAssignedIdentityId' is being replaced by parameter : 'Identity'.

## Get-AzVirtualRouterPeerLearnedRoute
The cmdlet 'Get-AzRouteServerPeerLearnedRoute' is replacing this cmdlet.
## Remove-AzExpressRouteCircuitPeeringConfig

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## New-AzFirewallPolicyNetworkRule
### SourceAddress
This parameter is becoming optional as SourceIpGroup can be provided without this.

## Get-AzVirtualRouterPeerAdvertisedRoute
The cmdlet 'Get-AzRouteServerPeerAdvertisedRoute' is replacing this cmdlet.
## Set-AzExpressRouteCircuitPeeringConfig

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Remove-AzExpressRouteCircuitAuthorization

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Add-AzVirtualHubRouteTable
The cmdlet 'New-AzVHubRouteTable' is replacing this cmdlet.
## New-AzVirtualRouter
The cmdlet 'New-AzRouteServer' is replacing this cmdlet.
## Add-AzExpressRouteCircuitAuthorization

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Set-AzExpressRouteCircuitConnectionConfig

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Get-AzExpressRouteCircuit

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Set-AzVirtualHub
### RouteTable
Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.

## New-AzVirtualHubRouteTable
The cmdlet 'New-AzVHubRouteTable' is replacing this cmdlet.
## Get-AzExpressRouteCircuitAuthorization

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Remove-AzExpressRouteCircuitConnectionConfig

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## New-AzVirtualHubRoute
The cmdlet 'New-AzVHubRoute' is replacing this cmdlet.
## New-AzFirewall
### PublicIpName
This parameter will be removed in an upcoming breaking change release. After this point the Public IP Address will be provided as a list of one or more objects instead of a string.
### VirtualNetworkName
This parameter will be removed in an upcoming breaking change release. After this point the Virtual Network will be provided as an object instead of a string.

## Get-AzPrivateEndpointConnection
### Description
Parameter is being deprecated without being replaced

## Get-AzVirtualRouterPeer
The cmdlet 'Get-AzRouteServerPeer' is replacing this cmdlet.
## Add-AzExpressRouteCircuitConnectionConfig

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Remove-AzVirtualRouter
The cmdlet 'Remove-AzRouteServer' is replacing this cmdlet.
## Get-AzExpressRouteCircuitPeeringConfig

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Remove-AzVirtualHubRouteTable
The cmdlet 'Remove-AzVHubRouteTable' is replacing this cmdlet.
## Remove-AzPrivateEndpointConnection
### Description
Parameter is being deprecated without being replaced

## New-AzPrivateLinkServiceIpConfig
### PublicIpAddress
Parameter is being deprecated without being replaced

- The output type 'Microsoft.Azure.Commands.Network.Models.PSPrivateLinkServiceIpConfiguration' is changing
- The following properties in the output type are being deprecated : 'PublicIPAddress'
- The following properties are being added to the output type : 'Primary'
## New-AzFirewallPolicyApplicationRule
### SourceAddress
This parameter is becoming optional as SourceIpGroup can be provided without this.

## New-AzVirtualHub
### HubVnetConnection
HubVnetConnection parameter is deprecated. Use *VirtualHubVnetConnection* commands
### RouteTable
Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.

## Set-AzExpressRouteCircuit

- The output type 'Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit' is changing
- The following properties in the output type are being deprecated : 'AllowGlobalReach'
## Get-AzVirtualHubRouteTable
The cmdlet 'Get-AzVHubRouteTable' is replacing this cmdlet.

# Az.Resources

## Export-AzResourceGroup
### ApiVersion
Parameter is being deprecated without being replaced. Using the lastest possible API version will become the default behavior.

## Update-AzManagementGroup
### GroupName
We will replace GroupName with GroupId to make it more clear.

## Get-AzManagementGroup
### GroupName
We will replace GroupName with GroupId to make it more clear.

## New-AzPolicyAssignment
### AssignIdentity
Parameter AssignIdentity is deprecated and will be removed in future releases. Please use the 'IdentityType' parameter instead.

- The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
- The following properties are being added to the output type : 'Identity'
## New-AzManagementGroup
### GroupName
We will replace GroupName with GroupId to make it more clear.

## Remove-AzManagementGroupSubscription
### GroupName
We will replace GroupName with GroupId to make it more clear.

## Get-AzPolicyAssignment

- The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
- The following properties are being added to the output type : 'Identity'
## New-AzManagementGroupSubscription
### GroupName
We will replace GroupName with GroupId to make it more clear.

## Remove-AzManagementGroup
### GroupName
We will replace GroupName with GroupId to make it more clear.

## Set-AzPolicyAssignment
### AssignIdentity
Parameter AssignIdentity is deprecated and will be removed in future releases. Please use the 'IdentityType' parameter instead.

- The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
- The following properties are being added to the output type : 'Identity'

# Az.Security

## Set-AzSecurityAlert
### InputObject

- The parameter : 'InputObject' is changing.
The type of the parameter is changing from 'Microsoft.Azure.Commands.Security.Models.Alerts.PSSecurityAlert' to 'PSSecurityAlertV3'.

## Get-AzSecurityAlert

- The output type is changing from the existing type :'Microsoft.Azure.Commands.Security.Models.Alerts.PSSecurityAlert' to the new type :'PSSecurityAlertV3'

# Az.ServiceBus

## Get-AzServiceBusNamespace

- The output type 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' is changing
- The following properties in the output type are being deprecated : 'ResourceGroup'
- The following properties are being added to the output type : 'ResourceGroupName'
## Set-AzServiceBusNamespace

- The output type 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' is changing
- The following properties in the output type are being deprecated : 'ResourceGroup'
- The following properties are being added to the output type : 'ResourceGroupName'
## New-AzServiceBusNamespace

- The output type 'Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes' is changing
- The following properties in the output type are being deprecated : 'ResourceGroup'
- The following properties are being added to the output type : 'ResourceGroupName'

# Az.SignalR

## New-AzSignalR

- The output type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' is changing
- The following properties in the output type are being deprecated : 'HostNamePrefix'
## Update-AzSignalR

- The output type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' is changing
- The following properties in the output type are being deprecated : 'HostNamePrefix'
## Get-AzSignalR

- The output type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' is changing
- The following properties in the output type are being deprecated : 'HostNamePrefix'

# Az.Sql

## Remove-AzSqlInstance

- The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Get-AzSqlInstance

- The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## New-AzSqlInstance

- The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## New-AzSqlDatabaseCopy

- The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureSqlDatabaseCopyModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Get-AzSqlDatabase

- The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Remove-AzSqlDatabaseSecondary

- The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## New-AzSqlDatabase

- The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## New-AzSqlDatabaseSecondary

- The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Set-AzSqlDatabaseSecondary

- The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Get-AzSqlDatabaseReplicationLink

- The output type 'Microsoft.Azure.Commands.Sql.Replication.Model.AzureReplicationLinkModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Remove-AzSqlDatabase

- The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Set-AzSqlInstance

- The output type 'Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'
## Set-AzSqlDatabase

- The output type 'Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel' is changing
- The following properties in the output type are being deprecated : 'BackupStorageRedundancy'
- The following properties are being added to the output type : 'CurrentBackupStorageRedundancy' 'RequestedBackupStorageRedundancy'

# Az.StorageSync

## Set-AzStorageSyncServerEndpoint
### InputObject
Alias RegisteredServer is invalid and preserved for compatibility. Alias ServerEndpoint should be used instead

