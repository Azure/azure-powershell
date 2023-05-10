---
Module Name: Az.EventHub
Module Guid: 9e121baf-ee5e-4cb7-bb95-fff6bb4ee003
Download Help Link: https://learn.microsoft.com/powershell/module/az.eventhub
Help Version: 1.0.0.0
Locale: en-US
---

# Az.EventHub Module
## Description
Microsoft Azure PowerShell: EventHub cmdlets

## Az.EventHub Cmdlets
### [Approve-AzEventHubPrivateEndpointConnection](Approve-AzEventHubPrivateEndpointConnection.md)
Approves an EventHub PrivateEndpointConnection

### [Deny-AzEventHubPrivateEndpointConnection](Deny-AzEventHubPrivateEndpointConnection.md)
Denies an EventHub PrivateEndpointConnection

### [Get-AzEventHub](Get-AzEventHub.md)
Gets an Event Hubs description for the specified Event Hub.

### [Get-AzEventHubApplicationGroup](Get-AzEventHubApplicationGroup.md)
Gets an ApplicationGroup for a Namespace.

### [Get-AzEventHubAuthorizationRule](Get-AzEventHubAuthorizationRule.md)
Gets an EventHub Authorization Rule

### [Get-AzEventHubCluster](Get-AzEventHubCluster.md)
Gets the resource description of the specified Event Hubs Cluster.

### [Get-AzEventHubClusterNamespace](Get-AzEventHubClusterNamespace.md)
List all Event Hubs Namespace IDs in an Event Hubs Dedicated Cluster.

### [Get-AzEventHubClustersAvailableRegion](Get-AzEventHubClustersAvailableRegion.md)
List the quantity of available pre-provisioned Event Hubs Clusters, indexed by Azure region.

### [Get-AzEventHubConsumerGroup](Get-AzEventHubConsumerGroup.md)
Gets a description for the specified consumer group.

### [Get-AzEventHubGeoDRConfiguration](Get-AzEventHubGeoDRConfiguration.md)
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

### [Get-AzEventHubKey](Get-AzEventHubKey.md)
Gets an EventHub SAS key

### [Get-AzEventHubNamespaceV2](Get-AzEventHubNamespaceV2.md)
Gets the description of the specified namespace.

### [Get-AzEventHubNetworkRuleSet](Get-AzEventHubNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [Get-AzEventHubPrivateEndpointConnection](Get-AzEventHubPrivateEndpointConnection.md)
Gets a description for the specified Private Endpoint Connection name.

### [Get-AzEventHubPrivateLink](Get-AzEventHubPrivateLink.md)
Gets lists of resources that supports Privatelinks.

### [Get-AzEventHubSchemaGroup](Get-AzEventHubSchemaGroup.md)
Gets the details of an EventHub schema group.

### [New-AzEventHub](New-AzEventHub.md)
Creates or updates a new Event Hub as a nested resource within a Namespace.

### [New-AzEventHubApplicationGroup](New-AzEventHubApplicationGroup.md)
Creates or updates an ApplicationGroup for a Namespace.

### [New-AzEventHubAuthorizationRule](New-AzEventHubAuthorizationRule.md)
Creates an EventHub Authorization Rule

### [New-AzEventHubCluster](New-AzEventHubCluster.md)
Creates or updates an instance of an Event Hubs Cluster.

### [New-AzEventHubConsumerGroup](New-AzEventHubConsumerGroup.md)
Creates or updates an Event Hubs consumer group as a nested resource within a Namespace.

### [New-AzEventHubGeoDRConfiguration](New-AzEventHubGeoDRConfiguration.md)
Creates or updates a new Alias(Disaster Recovery configuration)

### [New-AzEventHubIPRuleConfig](New-AzEventHubIPRuleConfig.md)
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet

### [New-AzEventHubKey](New-AzEventHubKey.md)
Regenerates an EventHub SAS key

### [New-AzEventHubKeyVaultPropertiesObject](New-AzEventHubKeyVaultPropertiesObject.md)
Create an in-memory object for KeyVaultProperties.

### [New-AzEventHubNamespaceV2](New-AzEventHubNamespaceV2.md)
Creates an EventHub Namespace

### [New-AzEventHubSchemaGroup](New-AzEventHubSchemaGroup.md)
Creates or Updates an EventHub schema group.

### [New-AzEventHubThrottlingPolicyConfig](New-AzEventHubThrottlingPolicyConfig.md)
Constructs an IThrottlingPolicy object that can be fed as input to New-AzEventHubApplicationGroup or Set-AzEventHubApplicationGroup

### [New-AzEventHubVirtualNetworkRuleConfig](New-AzEventHubVirtualNetworkRuleConfig.md)
Constructs an INwRuleSetVirtualNetworkRules object that can be fed as input to Set-AzEventHubNetworkRuleSet

### [Remove-AzEventHub](Remove-AzEventHub.md)
Deletes an Event Hub from the specified Namespace and resource group.

### [Remove-AzEventHubApplicationGroup](Remove-AzEventHubApplicationGroup.md)
Deletes an ApplicationGroup for a Namespace.

### [Remove-AzEventHubAuthorizationRule](Remove-AzEventHubAuthorizationRule.md)
Removes an EventHub Authorization Rule

### [Remove-AzEventHubCluster](Remove-AzEventHubCluster.md)
Deletes an existing Event Hubs Cluster.
This operation is idempotent.

### [Remove-AzEventHubConsumerGroup](Remove-AzEventHubConsumerGroup.md)
Deletes a consumer group from the specified Event Hub and resource group.

### [Remove-AzEventHubGeoDRConfiguration](Remove-AzEventHubGeoDRConfiguration.md)
Deletes an Alias(Disaster Recovery configuration)

### [Remove-AzEventHubNamespaceV2](Remove-AzEventHubNamespaceV2.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzEventHubPrivateEndpointConnection](Remove-AzEventHubPrivateEndpointConnection.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzEventHubSchemaGroup](Remove-AzEventHubSchemaGroup.md)
Deletes an EventHub schema group.

### [Set-AzEventHub](Set-AzEventHub.md)
Updates an EventHub Entity

### [Set-AzEventHubApplicationGroup](Set-AzEventHubApplicationGroup.md)
Sets an EventHub Application Group

### [Set-AzEventHubAuthorizationRule](Set-AzEventHubAuthorizationRule.md)
Sets an EventHub Authorization Rule

### [Set-AzEventHubCluster](Set-AzEventHubCluster.md)
Sets an EventHub Cluster

### [Set-AzEventHubConsumerGroup](Set-AzEventHubConsumerGroup.md)
Sets an EventHub Consumer Group

### [Set-AzEventHubGeoDRConfigurationBreakPair](Set-AzEventHubGeoDRConfigurationBreakPair.md)
This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

### [Set-AzEventHubGeoDRConfigurationFailOver](Set-AzEventHubGeoDRConfigurationFailOver.md)
Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace

### [Set-AzEventHubNamespaceV2](Set-AzEventHubNamespaceV2.md)
Updates an EventHub Namespace

### [Set-AzEventHubNetworkRuleSet](Set-AzEventHubNetworkRuleSet.md)
Sets an EventHub Namespace Network Rule Set

### [Test-AzEventHubName](Test-AzEventHubName.md)
Checks availability of a namespace name or disaster recovery alias.

