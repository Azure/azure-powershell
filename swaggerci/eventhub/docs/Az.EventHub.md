---
Module Name: Az.EventHub
Module Guid: 1acab19d-6fb3-4dd9-a576-260d11cce9fb
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.eventhub
Help Version: 1.0.0.0
Locale: en-US
---

# Az.EventHub Module
## Description
Microsoft Azure PowerShell: EventHub cmdlets

## Az.EventHub Cmdlets
### [Get-AzEventHub](Get-AzEventHub.md)
Gets an Event Hubs description for the specified Event Hub.

### [Get-AzEventHubApplicationGroup](Get-AzEventHubApplicationGroup.md)
Gets an ApplicationGroup for a Namespace.

### [Get-AzEventHubAuthorizationRule](Get-AzEventHubAuthorizationRule.md)
Gets an AuthorizationRule for an Event Hub by rule name.

### [Get-AzEventHubCluster](Get-AzEventHubCluster.md)
Gets the resource description of the specified Event Hubs Cluster.

### [Get-AzEventHubClusterAvailableClusterRegion](Get-AzEventHubClusterAvailableClusterRegion.md)
List the quantity of available pre-provisioned Event Hubs Clusters, indexed by Azure region.

### [Get-AzEventHubClusterNamespace](Get-AzEventHubClusterNamespace.md)
List all Event Hubs Namespace IDs in an Event Hubs Dedicated Cluster.

### [Get-AzEventHubConfiguration](Get-AzEventHubConfiguration.md)
Get all Event Hubs Cluster settings - a collection of key/value pairs which represent the quotas and settings imposed on the cluster.

### [Get-AzEventHubConsumerGroup](Get-AzEventHubConsumerGroup.md)
Gets a description for the specified consumer group.

### [Get-AzEventHubDisasterRecoveryConfig](Get-AzEventHubDisasterRecoveryConfig.md)
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

### [Get-AzEventHubDisasterRecoveryConfigAuthorizationRule](Get-AzEventHubDisasterRecoveryConfigAuthorizationRule.md)
Gets an AuthorizationRule for a Namespace by rule name.

### [Get-AzEventHubDisasterRecoveryConfigKey](Get-AzEventHubDisasterRecoveryConfigKey.md)
Gets the primary and secondary connection strings for the Namespace.

### [Get-AzEventHubKey](Get-AzEventHubKey.md)
Gets the ACS and SAS connection strings for the Event Hub.

### [Get-AzEventHubNamespace](Get-AzEventHubNamespace.md)
Gets the description of the specified namespace.

### [Get-AzEventHubNamespaceAuthorizationRule](Get-AzEventHubNamespaceAuthorizationRule.md)
Gets an AuthorizationRule for a Namespace by rule name.

### [Get-AzEventHubNamespaceKey](Get-AzEventHubNamespaceKey.md)
Gets the primary and secondary connection strings for the Namespace.

### [Get-AzEventHubNamespaceNetworkRuleSet](Get-AzEventHubNamespaceNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [Get-AzEventHubNetworkSecurityPerimeterConfiguration](Get-AzEventHubNetworkSecurityPerimeterConfiguration.md)
Gets list of current NetworkSecurityPerimeterConfiguration for Namespace

### [Get-AzEventHubPrivateEndpointConnection](Get-AzEventHubPrivateEndpointConnection.md)
Gets a description for the specified Private Endpoint Connection name.

### [Get-AzEventHubPrivateLinkResource](Get-AzEventHubPrivateLinkResource.md)
Gets lists of resources that supports Privatelinks.

### [Get-AzEventHubSchemaRegistry](Get-AzEventHubSchemaRegistry.md)


### [Invoke-AzEventHubBreakDisasterRecoveryConfigPairing](Invoke-AzEventHubBreakDisasterRecoveryConfigPairing.md)
This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

### [Invoke-AzEventHubFailDisasterRecoveryConfigOver](Invoke-AzEventHubFailDisasterRecoveryConfigOver.md)
Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace

### [New-AzEventHub](New-AzEventHub.md)
Creates or updates a new Event Hub as a nested resource within a Namespace.

### [New-AzEventHubApplicationGroup](New-AzEventHubApplicationGroup.md)
Creates or updates an ApplicationGroup for a Namespace.

### [New-AzEventHubAuthorizationRule](New-AzEventHubAuthorizationRule.md)
Creates or updates an AuthorizationRule for the specified Event Hub.
Creation/update of the AuthorizationRule will take a few seconds to take effect.

### [New-AzEventHubCluster](New-AzEventHubCluster.md)
Creates or updates an instance of an Event Hubs Cluster.

### [New-AzEventHubConsumerGroup](New-AzEventHubConsumerGroup.md)
Creates or updates an Event Hubs consumer group as a nested resource within a Namespace.

### [New-AzEventHubDisasterRecoveryConfig](New-AzEventHubDisasterRecoveryConfig.md)
Creates or updates a new Alias(Disaster Recovery configuration)

### [New-AzEventHubKey](New-AzEventHubKey.md)
Regenerates the ACS and SAS connection strings for the Event Hub.

### [New-AzEventHubNamespace](New-AzEventHubNamespace.md)
Creates or updates a namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

### [New-AzEventHubNamespaceAuthorizationRule](New-AzEventHubNamespaceAuthorizationRule.md)
Creates or updates an AuthorizationRule for a Namespace.

### [New-AzEventHubNamespaceKey](New-AzEventHubNamespaceKey.md)
Regenerates the primary or secondary connection strings for the specified Namespace.

### [New-AzEventHubNamespaceNetworkRuleSet](New-AzEventHubNamespaceNetworkRuleSet.md)
Create or update NetworkRuleSet for a Namespace.

### [New-AzEventHubPrivateEndpointConnection](New-AzEventHubPrivateEndpointConnection.md)
Creates or updates PrivateEndpointConnections of service namespace.

### [New-AzEventHubSchemaRegistry](New-AzEventHubSchemaRegistry.md)


### [Remove-AzEventHub](Remove-AzEventHub.md)
Deletes an Event Hub from the specified Namespace and resource group.

### [Remove-AzEventHubApplicationGroup](Remove-AzEventHubApplicationGroup.md)
Deletes an ApplicationGroup for a Namespace.

### [Remove-AzEventHubAuthorizationRule](Remove-AzEventHubAuthorizationRule.md)
Deletes an Event Hub AuthorizationRule.

### [Remove-AzEventHubCluster](Remove-AzEventHubCluster.md)
Deletes an existing Event Hubs Cluster.
This operation is idempotent.

### [Remove-AzEventHubConsumerGroup](Remove-AzEventHubConsumerGroup.md)
Deletes a consumer group from the specified Event Hub and resource group.

### [Remove-AzEventHubDisasterRecoveryConfig](Remove-AzEventHubDisasterRecoveryConfig.md)
Deletes an Alias(Disaster Recovery configuration)

### [Remove-AzEventHubNamespace](Remove-AzEventHubNamespace.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzEventHubNamespaceAuthorizationRule](Remove-AzEventHubNamespaceAuthorizationRule.md)
Deletes an AuthorizationRule for a Namespace.

### [Remove-AzEventHubPrivateEndpointConnection](Remove-AzEventHubPrivateEndpointConnection.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzEventHubSchemaRegistry](Remove-AzEventHubSchemaRegistry.md)


### [Test-AzEventHubDisasterRecoveryConfigNameAvailability](Test-AzEventHubDisasterRecoveryConfigNameAvailability.md)
Check the give Namespace name availability.

### [Test-AzEventHubNamespaceNameAvailability](Test-AzEventHubNamespaceNameAvailability.md)
Check the give Namespace name availability.

### [Update-AzEventHubCluster](Update-AzEventHubCluster.md)
Modifies mutable properties on the Event Hubs Cluster.
This operation is idempotent.

### [Update-AzEventHubConfiguration](Update-AzEventHubConfiguration.md)
Replace all specified Event Hubs Cluster settings with those contained in the request body.
Leaves the settings not specified in the request body unmodified.

### [Update-AzEventHubNamespace](Update-AzEventHubNamespace.md)
Creates or updates a namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

