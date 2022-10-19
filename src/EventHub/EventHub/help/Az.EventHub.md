---
Module Name: Az.EventHub
Module Guid: 5728d353-7ad5-42d8-b00a-46aaecf07b91
Download Help Link: https://docs.microsoft.com/powershell/module/az.eventhub
Help Version: 4.0.0.0
Locale: en-US
---

# Az.EventHub Module
## Description
This topic displays help for the Azure Event Hub PowerShell resource manager cmdlets.

## Az.EventHub Cmdlets
### [Add-AzEventHubIPRule](Add-AzEventHubIPRule.md)
Add a single IP rule to the NetworkRuleSet of the given Namespace

### [Add-AzEventHubVirtualNetworkRule](Add-AzEventHubVirtualNetworkRule.md)
Add a single VirtualNetworkRule to NetworkRuleSet for the given Namespace

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

### [Get-AzEventHubNamespace](Get-AzEventHubNamespace.md)
Gets the details of an Event Hubs namespace, or gets a list of all Event Hubs namespaces in the current Azure subscription.

### [Get-AzEventHubNetworkRuleSet](Get-AzEventHubNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [Get-AzEventHubPrivateEndpointConnection](Get-AzEventHubPrivateEndpointConnection.md)
Gets a description for the specified Private Endpoint Connection name.

### [Get-AzEventHubPrivateLink](Get-AzEventHubPrivateLink.md)
Gets lists of resources that supports Privatelinks.

### [Get-AzEventHubSchemaGroup](Get-AzEventHubSchemaGroup.md)


### [New-AzEventHub](New-AzEventHub.md)
Creates or updates a new Event Hub as a nested resource within a Namespace.

### [New-AzEventHubApplicationGroup](New-AzEventHubApplicationGroup.md)
Creates or updates an ApplicationGroup for a Namespace.

### [New-AzEventHubAuthorizationRule](New-AzEventHubAuthorizationRule.md)
Creates an EventHub Authorization Rule

### [New-AzEventHubAuthorizationRuleSASToken](New-AzEventHubAuthorizationRuleSASToken.md)
Generates a SAS token for Azure eventhub authorization rule of namespace/eventhub. 

### [New-AzEventHubCluster](New-AzEventHubCluster.md)
Creates or updates an instance of an Event Hubs Cluster.

### [New-AzEventHubConsumerGroup](New-AzEventHubConsumerGroup.md)
Creates or updates an Event Hubs consumer group as a nested resource within a Namespace.

### [New-AzEventHubEncryptionConfig](New-AzEventHubEncryptionConfig.md)
Creates an in memory object instance of PSEncryptionConfigAttributes which can then be given as input to New-AzEventHubNamespace and Set-AzEventHubNamespace to enable encryption 

### [New-AzEventHubGeoDRConfiguration](New-AzEventHubGeoDRConfiguration.md)
Creates or updates a new Alias(Disaster Recovery configuration)

### [New-AzEventHubIPRuleConfig](New-AzEventHubIPRuleConfig.md)
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet

### [New-AzEventHubKey](New-AzEventHubKey.md)
Regenerates an EventHub SAS key

### [New-AzEventHubNamespace](New-AzEventHubNamespace.md)
Creates an Event Hubs namespace.

### [New-AzEventHubSchemaGroup](New-AzEventHubSchemaGroup.md)


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

### [Remove-AzEventHubIPRule](Remove-AzEventHubIPRule.md)
Remove a single IP rule to the NetworkRuleSet of the given Namespace

### [Remove-AzEventHubNamespace](Remove-AzEventHubNamespace.md)
Removes the specified Event Hubs namespace.

### [Remove-AzEventHubNetworkRuleSet](Remove-AzEventHubNetworkRuleSet.md)
Removes the NetworkRuleSet for the Given Namespace

### [Remove-AzEventHubPrivateEndpointConnection](Remove-AzEventHubPrivateEndpointConnection.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzEventHubSchemaGroup](Remove-AzEventHubSchemaGroup.md)


### [Remove-AzEventHubVirtualNetworkRule](Remove-AzEventHubVirtualNetworkRule.md)
Removes the single given VirtualNetworkRule for the NetworkRuleSet of the Namespace

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

### [Set-AzEventHubNamespace](Set-AzEventHubNamespace.md)
Updates the specified Event Hubs namespace.

### [Set-AzEventHubNetworkRuleSet](Set-AzEventHubNetworkRuleSet.md)
Sets an EventHub Namespace Network Rule Set

### [Test-AzEventHubName](Test-AzEventHubName.md)
Checks availability of a namespace name or disaster recovery alias.

