---
Module Name: Az.ServiceBus
Module Guid: f73d11ef-c690-49f3-8c2c-9000e0e4fe69
Download Help Link: https://docs.microsoft.com/powershell/module/az.servicebus
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ServiceBus Module
## Description
Microsoft Azure PowerShell: ServiceBus cmdlets

## Az.ServiceBus Cmdlets
### [Complete-AzServiceBusMigration](Complete-AzServiceBusMigration.md)
This operation Completes Migration of entities by pointing the connection strings to Premium namespace and any entities created after the operation will be under Premium Namespace.
CompleteMigration operation will fail when entity migration is in-progress.

### [Deny-AzServiceBusPrivateEndpointConnection](Deny-AzServiceBusPrivateEndpointConnection.md)
Denies an ServiceBus PrivateEndpointConnection

### [Get-AzServiceBusAuthorizationRule](Get-AzServiceBusAuthorizationRule.md)
Gets an ServiceBus Authorization Rule

### [Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule](Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule.md)
Gets an authorization rule for a namespace by rule name.

### [Get-AzServiceBusDisasterRecoveryConfigKey](Get-AzServiceBusDisasterRecoveryConfigKey.md)
Gets the primary and secondary connection strings for the namespace.

### [Get-AzServiceBusGeoDRConfiguration](Get-AzServiceBusGeoDRConfiguration.md)
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

### [Get-AzServiceBusKey](Get-AzServiceBusKey.md)
Gets a ServiceBus SAS key

### [Get-AzServiceBusMigration](Get-AzServiceBusMigration.md)
Retrieves Migration Config

### [Get-AzServiceBusNamespace](Get-AzServiceBusNamespace.md)
Gets a description for the specified namespace.

### [Get-AzServiceBusNamespaceAuthorizationRule](Get-AzServiceBusNamespaceAuthorizationRule.md)
Gets an authorization rule for a namespace by rule name.

### [Get-AzServiceBusNamespaceKey](Get-AzServiceBusNamespaceKey.md)
Gets the primary and secondary connection strings for the namespace.

### [Get-AzServiceBusNamespaceNetworkRuleSet](Get-AzServiceBusNamespaceNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [Get-AzServiceBusPrivateEndpointConnection](Get-AzServiceBusPrivateEndpointConnection.md)
Gets a description for the specified Private Endpoint Connection.

### [Get-AzServiceBusPrivateLinkResource](Get-AzServiceBusPrivateLinkResource.md)
Gets lists of resources that supports Privatelinks.

### [Get-AzServiceBusQueue](Get-AzServiceBusQueue.md)
Returns a description for the specified queue.

### [Get-AzServiceBusQueueAuthorizationRule](Get-AzServiceBusQueueAuthorizationRule.md)
Gets an authorization rule for a queue by rule name.

### [Get-AzServiceBusQueueKey](Get-AzServiceBusQueueKey.md)
Primary and secondary connection strings to the queue.

### [Get-AzServiceBusRule](Get-AzServiceBusRule.md)
Retrieves the description for the specified rule.

### [Get-AzServiceBusSubscription](Get-AzServiceBusSubscription.md)
Returns a subscription description for the specified topic.

### [Get-AzServiceBusTopic](Get-AzServiceBusTopic.md)
Returns a description for the specified topic.

### [Get-AzServiceBusTopicAuthorizationRule](Get-AzServiceBusTopicAuthorizationRule.md)
Returns the specified authorization rule.

### [Get-AzServiceBusTopicKey](Get-AzServiceBusTopicKey.md)
Gets the primary and secondary connection strings for the topic.

### [New-AzServiceBusAuthorizationRule](New-AzServiceBusAuthorizationRule.md)
Creates an Service Bus Namespace, Queue, Topic Authorization Rule

### [New-AzServiceBusGeoDRConfiguration](New-AzServiceBusGeoDRConfiguration.md)
Creates or updates a new Alias(Disaster Recovery configuration)

### [New-AzServiceBusKey](New-AzServiceBusKey.md)
Regenerates a ServiceBus SAS key

### [New-AzServiceBusNamespace](New-AzServiceBusNamespace.md)
Creates or updates a service namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

### [New-AzServiceBusNamespaceAuthorizationRule](New-AzServiceBusNamespaceAuthorizationRule.md)
Creates or updates an authorization rule for a namespace.

### [New-AzServiceBusNamespaceKey](New-AzServiceBusNamespaceKey.md)
Regenerates the primary or secondary connection strings for the namespace.

### [New-AzServiceBusNamespaceNetworkRuleSet](New-AzServiceBusNamespaceNetworkRuleSet.md)
Create or update NetworkRuleSet for a Namespace.

### [New-AzServiceBusPrivateEndpointConnection](New-AzServiceBusPrivateEndpointConnection.md)
Creates or updates PrivateEndpointConnections of service namespace.

### [New-AzServiceBusQueue](New-AzServiceBusQueue.md)
Creates or updates a Service Bus queue.
This operation is idempotent.

### [New-AzServiceBusQueueAuthorizationRule](New-AzServiceBusQueueAuthorizationRule.md)
Creates an authorization rule for a queue.

### [New-AzServiceBusQueueKey](New-AzServiceBusQueueKey.md)
Regenerates the primary or secondary connection strings to the queue.

### [New-AzServiceBusRule](New-AzServiceBusRule.md)
Creates a new rule and updates an existing rule

### [New-AzServiceBusSubscription](New-AzServiceBusSubscription.md)
Creates a topic subscription.

### [New-AzServiceBusTopic](New-AzServiceBusTopic.md)
Creates a topic in the specified namespace.

### [New-AzServiceBusTopicAuthorizationRule](New-AzServiceBusTopicAuthorizationRule.md)
Creates an authorization rule for the specified topic.

### [New-AzServiceBusTopicKey](New-AzServiceBusTopicKey.md)
Regenerates primary or secondary connection strings for the topic.

### [Remove-AzServiceBusAuthorizationRule](Remove-AzServiceBusAuthorizationRule.md)
Removes an ServiceBus Namespace, Queue or Topic Authorization Rule

### [Remove-AzServiceBusGeoDRConfiguration](Remove-AzServiceBusGeoDRConfiguration.md)
Deletes an Alias(Disaster Recovery configuration)

### [Remove-AzServiceBusMigration](Remove-AzServiceBusMigration.md)
Deletes a MigrationConfiguration

### [Remove-AzServiceBusNamespace](Remove-AzServiceBusNamespace.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzServiceBusNamespaceAuthorizationRule](Remove-AzServiceBusNamespaceAuthorizationRule.md)
Deletes a namespace authorization rule.

### [Remove-AzServiceBusPrivateEndpointConnection](Remove-AzServiceBusPrivateEndpointConnection.md)
Deletes an existing Private Endpoint Connection.

### [Remove-AzServiceBusQueue](Remove-AzServiceBusQueue.md)
Deletes a queue from the specified namespace in a resource group.

### [Remove-AzServiceBusQueueAuthorizationRule](Remove-AzServiceBusQueueAuthorizationRule.md)
Deletes a queue authorization rule.

### [Remove-AzServiceBusRule](Remove-AzServiceBusRule.md)
Deletes an existing rule.

### [Remove-AzServiceBusSubscription](Remove-AzServiceBusSubscription.md)
Deletes a subscription from the specified topic.

### [Remove-AzServiceBusTopic](Remove-AzServiceBusTopic.md)
Deletes a topic from the specified namespace and resource group.

### [Remove-AzServiceBusTopicAuthorizationRule](Remove-AzServiceBusTopicAuthorizationRule.md)
Deletes a topic authorization rule.

### [Set-AzServiceBusAuthorizationRule](Set-AzServiceBusAuthorizationRule.md)
Sets an ServiceBus Namespace, Queue and Topic Authorization Rule

### [Set-AzServiceBusGeoDRConfigurationBreakPair](Set-AzServiceBusGeoDRConfigurationBreakPair.md)
This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

### [Set-AzServiceBusGeoDRConfigurationFailOver](Set-AzServiceBusGeoDRConfigurationFailOver.md)
Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace

### [Set-AzServiceBusQueue](Set-AzServiceBusQueue.md)
Sets a ServiceBus Queue

### [Set-AzServiceBusRule](Set-AzServiceBusRule.md)
Sets a ServiceBus Rule

### [Set-AzServiceBusSubscription](Set-AzServiceBusSubscription.md)
Sets a ServiceBus Topic

### [Set-AzServiceBusTopic](Set-AzServiceBusTopic.md)
Sets a ServiceBus Topic

### [Start-AzServiceBusMigration](Start-AzServiceBusMigration.md)
Creates Migration configuration and starts migration of entities from Standard to Premium namespace

### [Stop-AzServiceBusMigration](Stop-AzServiceBusMigration.md)
This operation reverts Migration

### [Test-AzServiceBusDisasterRecoveryConfigNameAvailability](Test-AzServiceBusDisasterRecoveryConfigNameAvailability.md)
Check the give namespace name availability.

### [Test-AzServiceBusNamespaceNameAvailability](Test-AzServiceBusNamespaceNameAvailability.md)
Check the give namespace name availability.

### [Update-AzServiceBusNamespace](Update-AzServiceBusNamespace.md)
Updates a service namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

