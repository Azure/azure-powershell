---
Module Name: Az.HorizonDB
Module Guid: 3a160bc3-6c23-4efc-9401-c92cf173fc3f
Download Help Link: https://learn.microsoft.com/powershell/module/az.horizondb
Help Version: 1.0.0.0
Locale: en-US
---

# Az.HorizonDB Module
## Description
Microsoft Azure PowerShell: HorizonDb cmdlets

## Az.HorizonDB Cmdlets
### [Add-AzHorizonDbMaintenanceEventNow](Add-AzHorizonDbMaintenanceEventNow.md)
Applies the maintenance event immediately.

### [Get-AzHorizonDbAuthentication](Get-AzHorizonDbAuthentication.md)
Lists the two service-created authentication configurations for the cluster: passwordMethod and microsoftEntra.

### [Get-AzHorizonDbCapability](Get-AzHorizonDbCapability.md)
Gets the singleton HorizonDB capability catalog entry available to a subscription in a specific region.

### [Get-AzHorizonDbChangeDataCaptureCapability](Get-AzHorizonDbChangeDataCaptureCapability.md)
Gets the singleton change data capture capability for a HorizonDB cluster.

### [Get-AzHorizonDbChangeDataCaptureConfiguration](Get-AzHorizonDbChangeDataCaptureConfiguration.md)
Gets a change data capture configuration.

### [Get-AzHorizonDbChangeDataCaptureDestination](Get-AzHorizonDbChangeDataCaptureDestination.md)
Gets a change data capture destination.

### [Get-AzHorizonDbCluster](Get-AzHorizonDbCluster.md)
Gets information about a HorizonDB cluster.

### [Get-AzHorizonDbDefaultParameterGroup](Get-AzHorizonDbDefaultParameterGroup.md)
Gets a default parameter group available for a subscription in a specific region.
Each PostgreSQL version has at most one default parameter group in a location.

### [Get-AzHorizonDbEndpoint](Get-AzHorizonDbEndpoint.md)
Gets information about a service-generated HorizonDB Cluster- or Pool-scoped Endpoint.

### [Get-AzHorizonDbFirewallRule](Get-AzHorizonDbFirewallRule.md)
Gets information about a HorizonDB pool firewall rule.

### [Get-AzHorizonDbIdentityAssignment](Get-AzHorizonDbIdentityAssignment.md)
Gets a change data capture identity assignment.

### [Get-AzHorizonDbLogCaptureConfiguration](Get-AzHorizonDbLogCaptureConfiguration.md)
Gets a log capture configuration for a HorizonDB cluster.

### [Get-AzHorizonDbLogFile](Get-AzHorizonDbLogFile.md)
Gets metadata for a captured HorizonDB log file.

### [Get-AzHorizonDbLogFileDownloadUrl](Get-AzHorizonDbLogFileDownloadUrl.md)
Gets a short-lived signed URL for downloading a captured log file.
The signed URL is returned only by this action so routine resource GET and LIST responses do not expose bearer credentials.

### [Get-AzHorizonDbMaintenanceEvent](Get-AzHorizonDbMaintenanceEvent.md)
Gets information about a maintenance event for a HorizonDB pool.

### [Get-AzHorizonDbMicrosoftEntraAdministrator](Get-AzHorizonDbMicrosoftEntraAdministrator.md)
Gets information about a PostgreSQL role that is a member of azure_pg_admin and mapped to a Microsoft Entra principal.

### [Get-AzHorizonDbMicrosoftEntraAuthentication](Get-AzHorizonDbMicrosoftEntraAuthentication.md)
Gets the service-created Microsoft Entra authentication method.

### [Get-AzHorizonDbNode](Get-AzHorizonDbNode.md)
Gets a node allocated to a HorizonDB pool.

### [Get-AzHorizonDbParameterGroup](Get-AzHorizonDbParameterGroup.md)
Gets information about a HorizonDB parameter group.

### [Get-AzHorizonDbParameterGroupConnection](Get-AzHorizonDbParameterGroupConnection.md)
Gets all connections to a parameter group.

### [Get-AzHorizonDbPasswordAuthentication](Get-AzHorizonDbPasswordAuthentication.md)
Gets the service-created PostgreSQL username-and-password authentication method.

### [Get-AzHorizonDbPool](Get-AzHorizonDbPool.md)
Gets information about a HorizonDB pool.

### [Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity](Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity.md)
Atomically activates a validated identity assignment for this destination.
If-Match is evaluated against the destination entity tag.
Activating the already-active assignment succeeds idempotently.

### [Invoke-AzHorizonDbRejectPrivateEndpointConnection](Invoke-AzHorizonDbRejectPrivateEndpointConnection.md)
Approves or rejects an existing private endpoint connection.
Approval requires the parent Cluster to contain at least one Pool.
An approval attempt when the Cluster has no Pools fails with 409 Conflict and the stable error code PrivateEndpointRequiresPool.
Rejection remains allowed when the Cluster has no Pools so that existing connections can be cleaned up.

### [Invoke-AzHorizonDbRescheduleMaintenanceEvent](Invoke-AzHorizonDbRescheduleMaintenanceEvent.md)
Reschedules a maintenance event to a new date and time.

### [New-AzHorizonDbChangeDataCaptureCapability](New-AzHorizonDbChangeDataCaptureCapability.md)
Create or replaces the singleton change data capture capability and reconciles shared engine prerequisites.

### [New-AzHorizonDbChangeDataCaptureConfiguration](New-AzHorizonDbChangeDataCaptureConfiguration.md)
Create or replaces a change data capture configuration that enrolls a PostgreSQL database for Microsoft Fabric Mirroring.

### [New-AzHorizonDbChangeDataCaptureDestination](New-AzHorizonDbChangeDataCaptureDestination.md)
Create or replaces a Microsoft Fabric change data capture destination.

### [New-AzHorizonDbCluster](New-AzHorizonDbCluster.md)
Create a new HorizonDB cluster or replaces an existing cluster.
PointInTimeRestore create the new Cluster resource and hydrates its service-owned database storage from an available source backup.
It does not clone source pools, Pool-scoped endpoints, firewall rules, parameter-group associations, or other child resources.
The new Cluster receives its service-generated Cluster-scoped Endpoint named cluster.
For restore, postgreSqlVersion must be omitted because the service obtains it from backup metadata.
During restore creation, the service ignores the requested backup.geoRedundancy value and configures the new cluster with the same geo-redundancy setting as the source cluster; this applies to both same-location and cross-location restores.
All remaining new-cluster configuration comes from the request or service defaults.
Same-location restore requires and honors pointInTimeUtc and allows creationSourceClusterLocation to be omitted.
Cross-location restore requires creationSourceClusterLocation to identify the source cluster's Azure location and requires pointInTimeUtc, but ignores the supplied timestamp and restores the latest available backup.
Cross-location responses omit pointInTimeUtc.

### [New-AzHorizonDbFirewallRule](New-AzHorizonDbFirewallRule.md)
Create or replaces a HorizonDB pool firewall rule.

### [New-AzHorizonDbIdentityAssignment](New-AzHorizonDbIdentityAssignment.md)
Create or idempotently replaces a change data capture identity assignment.
The identity resource ID is immutable and must reference a user-assigned managed identity already attached to the parent cluster.
The service also validates destination permissions, which are not granted by attaching the identity to the cluster.

### [New-AzHorizonDbMicrosoftEntraAdministrator](New-AzHorizonDbMicrosoftEntraAdministrator.md)
Create or replaces a PostgreSQL role that is a member of azure_pg_admin and mapped to a Microsoft Entra principal.

### [New-AzHorizonDbMicrosoftEntraAuthentication](New-AzHorizonDbMicrosoftEntraAuthentication.md)
Create or replaces the service-created Microsoft Entra authentication method.
State Enabled enables the feature and State Disabled disables it; no additional properties are required.
Repeating the same request is idempotent.
Disabling the feature does not remove or modify database roles or users previously created through the MicrosoftEntraAdministrators control-plane API or directly through pgaadauth extension functions.

### [New-AzHorizonDbParameterGroup](New-AzHorizonDbParameterGroup.md)
Create a new HorizonDB parameter group or replaces an existing parameter group.

### [New-AzHorizonDbPasswordAuthentication](New-AzHorizonDbPasswordAuthentication.md)
Create or replaces the service-created PostgreSQL username-and-password authentication method.

### [New-AzHorizonDbPool](New-AzHorizonDbPool.md)
Create a new HorizonDB pool or replaces an existing pool, including its node allocation, compute model, high-availability configuration, or associated parameter group.
nodeCount and highAvailability.mode are required and have no service defaults.
nodeCount must be 1 through 16.
Disabled is valid only when nodeCount is 1.
AnyZone and ZoneRedundant are valid only when nodeCount is 2 through 16.
AnyZone permits same-zone or cross-zone placement, while ZoneRedundant requires nodes to be allocated across availability zones.
Node allocation and high-availability reconfiguration are atomic: if all requested nodes or the required zonal topology cannot be provisioned, the long-running operation fails and the previous resource state is preserved.
A pool name must differ from its parent cluster name because the Cluster-scoped ReadWrite Endpoint is named after the Cluster and the Pool-scoped ReadOnly Endpoint is named after the Pool; the service rejects a request whose names would collide.
Creating a pool also create exactly one service-managed Pool-scoped ReadOnly Endpoint representing that Pool and its network boundary.
The Endpoint's associatedResourceId identifies the Pool, and the Endpoint cannot outlive or be deleted independently from it.
When the first pool is created, the service automatically designates it to host the cluster's read-write node when an eligible node is available.
A Cluster must contain at least one Pool before a private endpoint connection can be created or approved.
This API version supports at most one pool per cluster; an attempt to create another pool is rejected with 409 Conflict.
parameterGroup is optional during creation.
When omitted during creation, the service applies the default parameter group compatible with the parent cluster's PostgreSQL version.
When parameterGroup is supplied, parameterGroupResourceId and applyMethod are required.
When creating a new pool in this API version, a supplied parameterGroupResourceId must identify the corresponding default parameter group; a customer-created parameter group is rejected.
When replacing an existing pool, the request can switch its association in either direction between the corresponding default parameter group and a customer-created parameter group.
applyMethod controls when dynamic parameter changes become effective.
Static parameter changes always require a customer-initiated Restart; Stop followed by Start and scheduled maintenance do not apply pending changes.
Subtype-specific compute constraints are validated before the resource is changed.

### [Remove-AzHorizonDbChangeDataCaptureCapability](Remove-AzHorizonDbChangeDataCaptureCapability.md)
Deletes the change data capture capability after all change data capture destinations and configurations have been removed.

### [Remove-AzHorizonDbChangeDataCaptureConfiguration](Remove-AzHorizonDbChangeDataCaptureConfiguration.md)
Deletes a change data capture configuration after destination-side replication has been stopped or detached.
This operation never deletes the Microsoft Fabric mirrored-database item.

### [Remove-AzHorizonDbChangeDataCaptureDestination](Remove-AzHorizonDbChangeDataCaptureDestination.md)
Deletes a change data capture destination after all referencing configurations and identity assignments have been removed.

### [Remove-AzHorizonDbCluster](Remove-AzHorizonDbCluster.md)
Deletes a HorizonDB cluster, its Cluster-scoped Endpoint, and all remaining child resources.
For an accepted deletion, the long-running operation remains nonterminal until physical deletion completes and point GET returns 404 Not Found.

### [Remove-AzHorizonDbFirewallRule](Remove-AzHorizonDbFirewallRule.md)
Deletes a HorizonDB pool firewall rule.

### [Remove-AzHorizonDbIdentityAssignment](Remove-AzHorizonDbIdentityAssignment.md)
Deletes an inactive change data capture identity assignment.

### [Remove-AzHorizonDbMicrosoftEntraAdministrator](Remove-AzHorizonDbMicrosoftEntraAdministrator.md)
Deletes a PostgreSQL role that is a member of azure_pg_admin and mapped to a Microsoft Entra principal.

### [Remove-AzHorizonDbParameterGroup](Remove-AzHorizonDbParameterGroup.md)
Deletes a HorizonDB parameter group.
Deletion fails with a conflict when the parameter group is associated with one or more pools.

### [Remove-AzHorizonDbPool](Remove-AzHorizonDbPool.md)
Deletes a HorizonDB pool together with the Pool-scoped Endpoint whose associatedResourceId identifies that Pool and all FirewallRule children of that Endpoint.
The Endpoint cannot outlive or be deleted independently from its Pool.
When this is the Cluster's last surviving Pool, the service also disconnects every existing private endpoint connection associated with the Cluster by setting its privateLinkServiceConnectionState.status to Rejected and providing a description that the last Pool was deleted.
The HorizonDB private endpoint connection resources remain available for inspection and cleanup, and customer-owned Microsoft.Network/privateEndpoints resources are not deleted.
The delete long-running operation completes only after all required private endpoint disconnections have completed.

### [Restart-AzHorizonDbPool](Restart-AzHorizonDbPool.md)
Restarts the PostgreSQL container on all allocated nodes in a ready HorizonDB pool and applies pending dynamic and static parameter changes.
This customer-initiated Restart is the only operation that applies static parameter changes or dynamic parameter changes requested with PendingReboot; Stop followed by Start and scheduled maintenance do not apply them.
Power operations are supported only at pool scope in this API version; there is no cluster-level restart action.
When the pool has no allocated nodes, the operation succeeds without restarting any nodes, pending changes are considered applied, parameterGroup.syncStatus becomes InSync, and the resulting configuration applies to nodes allocated later.
The request fails with 409 Conflict when another operation is in progress or the pool is in any other incompatible state.

### [Start-AzHorizonDbPool](Start-AzHorizonDbPool.md)
Starts a stopped HorizonDB pool.
Power operations are supported only at pool scope in this API version; there is no cluster-level start action.
Start does not apply pending dynamic or static parameter changes; parameterGroup.syncStatus remains PendingReboot until a customer-initiated Restart.
When the pool is already Ready, the operation succeeds as a true idempotent no-op and likewise leaves pending parameter changes pending.
The operation is allowed when the pool has no allocated nodes.
After the Pool is running, its Pool-scoped ReadOnly Endpoint routes only when at least one allocated node is not currently playing the read-write role.
The request fails with 409 Conflict when another operation is in progress or the pool is in any other incompatible state.

### [Stop-AzHorizonDbPool](Stop-AzHorizonDbPool.md)
Stops a running HorizonDB pool and deallocates compute.
Power operations are supported only at pool scope in this API version; there is no cluster-level stop action.
Stop does not apply pending dynamic or static parameter changes; parameterGroup.syncStatus remains PendingReboot.
A subsequent Start also preserves those pending changes.
The operation succeeds as an idempotent no-op when the pool is already Stopped.
It is allowed when the pool has no allocated nodes.
The Pool-scoped ReadOnly Endpoint remains discoverable but has no routing destination while the Pool is Stopped.
The request fails with 409 Conflict when another operation is in progress or the pool is in any other incompatible state.

### [Update-AzHorizonDbChangeDataCaptureCapability](Update-AzHorizonDbChangeDataCaptureCapability.md)
Update mutable change data capture capability properties.
Omitted properties preserve their current values.

### [Update-AzHorizonDbChangeDataCaptureConfiguration](Update-AzHorizonDbChangeDataCaptureConfiguration.md)
Update mutable change data capture configuration properties.
Omitted properties preserve their current values.

### [Update-AzHorizonDbChangeDataCaptureDestination](Update-AzHorizonDbChangeDataCaptureDestination.md)
Update mutable change data capture destination properties.
Omitted properties preserve their current values.

### [Update-AzHorizonDbCluster](Update-AzHorizonDbCluster.md)
Replace a new HorizonDB cluster or replaces an existing cluster.
PointInTimeRestore replace the new Cluster resource and hydrates its service-owned database storage from an available source backup.
It does not clone source pools, Pool-scoped endpoints, firewall rules, parameter-group associations, or other child resources.
The new Cluster receives its service-generated Cluster-scoped Endpoint named cluster.
For restore, postgreSqlVersion must be omitted because the service obtains it from backup metadata.
During restore creation, the service ignores the requested backup.geoRedundancy value and configures the new cluster with the same geo-redundancy setting as the source cluster; this applies to both same-location and cross-location restores.
All remaining new-cluster configuration comes from the request or service defaults.
Same-location restore requires and honors pointInTimeUtc and allows creationSourceClusterLocation to be omitted.
Cross-location restore requires creationSourceClusterLocation to identify the source cluster's Azure location and requires pointInTimeUtc, but ignores the supplied timestamp and restores the latest available backup.
Cross-location responses omit pointInTimeUtc.

### [Update-AzHorizonDbFirewallRule](Update-AzHorizonDbFirewallRule.md)
Replace or replaces a HorizonDB pool firewall rule.

### [Update-AzHorizonDbIdentityAssignment](Update-AzHorizonDbIdentityAssignment.md)
Replace or idempotently replaces a change data capture identity assignment.
The identity resource ID is immutable and must reference a user-assigned managed identity already attached to the parent cluster.
The service also validates destination permissions, which are not granted by attaching the identity to the cluster.

### [Update-AzHorizonDbLogCaptureConfiguration](Update-AzHorizonDbLogCaptureConfiguration.md)
Update a log capture configuration.
Omitted properties preserve their current values.

### [Update-AzHorizonDbMicrosoftEntraAuthentication](Update-AzHorizonDbMicrosoftEntraAuthentication.md)
Update the service-created Microsoft Entra authentication method.
State Enabled enables the feature and State Disabled disables it; no additional properties are required.
Disabling the feature does not remove or modify database roles or users previously created through the MicrosoftEntraAdministrators control-plane API or directly through pgaadauth extension functions.

### [Update-AzHorizonDbParameterGroup](Update-AzHorizonDbParameterGroup.md)
Update an existing HorizonDB parameter group.
Each connected pool's applyMethod setting controls whether dynamic parameter changes become effective immediately or remain pending until a customer-initiated pool Restart.
Static parameter changes always remain pending until a customer-initiated pool Restart.
Stop followed by Start and scheduled maintenance do not apply pending changes.
The operation fails with a conflict while a previous update to this parameter group is still being processed.

### [Update-AzHorizonDbPasswordAuthentication](Update-AzHorizonDbPasswordAuthentication.md)
Update the service-created PostgreSQL username-and-password authentication method.
The request is sparse and omitted properties preserve their current values.
This API version supports enabling the method, disabling the method, and resetting its password.
For a cluster that already has an administrator but currently has password authentication disabled, state Enabled and administratorLoginPassword can be supplied together to re-enable password authentication and reset the password.
Disabling cannot include credentials and does not remove or modify existing database users or roles.
Administrator rename is not supported in this API version.

### [Update-AzHorizonDbPool](Update-AzHorizonDbPool.md)
Update an existing HorizonDB pool, including its node allocation, selected compute model properties, compute model type, high-availability configuration, or associated parameter group.
Omitted nodeCount and highAvailability.mode values preserve their existing values; the service recursively merges the PATCH before atomically validating the effective tuple.
nodeCount, when supplied, must be 1 through 16.
Disabled is valid only when the effective nodeCount is 1.
AnyZone and ZoneRedundant are valid only when the effective nodeCount is 2 through 16.
Therefore, crossing between those node-count ranges requires nodeCount and highAvailability.mode to be changed together.
AnyZone permits same-zone or cross-zone placement.
Changing from AnyZone to ZoneRedundant may allocate a replacement node in another availability zone and replace a read-only node, disconnecting connections to the replaced node.
If all requested nodes or the required zonal topology cannot be provisioned, the long-running operation fails and the previous resource state is preserved.
To deallocate runtime compute without changing the configured nodeCount, use the Pool stop action.
When parameterGroup is supplied, both parameterGroupResourceId and applyMethod are required.
The pool can switch its association in either direction between the corresponding default parameter group and a customer-created parameter group.
applyMethod controls when dynamic parameter changes become effective.
Static parameter changes always require a customer-initiated Restart; Stop followed by Start and scheduled maintenance do not apply pending changes.
Subtype-specific compute constraints are validated against the recursively merged configuration.

