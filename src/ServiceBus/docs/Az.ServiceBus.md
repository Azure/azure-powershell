---
Module Name: Az.ServiceBus
Module Guid: 23b7f05e-3f54-4644-39ea-c8c772c84aad
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.servicebus
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ServiceBus Module
## Description
Microsoft Azure PowerShell: ServiceBus cmdlets

## Az.ServiceBus Cmdlets
### [Complete-AzServiceBusMigrationConfigMigration](Complete-AzServiceBusMigrationConfigMigration.md)
This operation Completes Migration of entities by pointing the connection strings to Premium namespace and any entities created after the operation will be under Premium Namespace.
CompleteMigration operation will fail when entity migration is in-progress.

### [Get-AzServiceBusAuthorizationRule](Get-AzServiceBusAuthorizationRule.md)
Gets an authorization rule for a namespace by rule name.

### [Get-AzServiceBusDisasterRecoveryConfig](Get-AzServiceBusDisasterRecoveryConfig.md)
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

### [Get-AzServiceBusEventHub](Get-AzServiceBusEventHub.md)
Gets all the Event Hubs in a service bus Namespace.

### [Get-AzServiceBusKey](Get-AzServiceBusKey.md)
Gets the primary and secondary connection strings for the namespace.

### [Get-AzServiceBusMigrationConfig](Get-AzServiceBusMigrationConfig.md)
Retrieves Migration Config

### [Get-AzServiceBusNamespace](Get-AzServiceBusNamespace.md)
Gets a description for the specified namespace.

### [Get-AzServiceBusNamespaceIPFilterRule](Get-AzServiceBusNamespaceIPFilterRule.md)
Gets an IpFilterRule for a Namespace by rule name.

### [Get-AzServiceBusNamespaceNetworkRuleSet](Get-AzServiceBusNamespaceNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [Get-AzServiceBusNamespaceVirtualNetworkRule](Get-AzServiceBusNamespaceVirtualNetworkRule.md)
Gets an VirtualNetworkRule for a Namespace by rule name.

### [Get-AzServiceBusPremiumMessagingRegion](Get-AzServiceBusPremiumMessagingRegion.md)
Gets the available premium messaging regions for servicebus

### [Get-AzServiceBusQueue](Get-AzServiceBusQueue.md)
Returns a description for the specified queue.

### [Get-AzServiceBusRegion](Get-AzServiceBusRegion.md)
Gets the available Regions for a given sku

### [Get-AzServiceBusRule](Get-AzServiceBusRule.md)
Retrieves the description for the specified rule.

### [Get-AzServiceBusSubscription](Get-AzServiceBusSubscription.md)
Returns a subscription description for the specified topic.

### [Get-AzServiceBusTopic](Get-AzServiceBusTopic.md)
Returns a description for the specified topic.

### [Invoke-AzServiceBusBreakDisasterRecoveryConfigPairing](Invoke-AzServiceBusBreakDisasterRecoveryConfigPairing.md)
This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

### [Invoke-AzServiceBusFailDisasterRecoveryConfigOver](Invoke-AzServiceBusFailDisasterRecoveryConfigOver.md)
Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace

### [Invoke-AzServiceBusRevertMigrationConfig](Invoke-AzServiceBusRevertMigrationConfig.md)
This operation reverts Migration

### [Move-AzServiceBusNamespace](Move-AzServiceBusNamespace.md)
This operation Migrate the given namespace to provided name type

### [New-AzServiceBusAuthorizationRule](New-AzServiceBusAuthorizationRule.md)
Creates or updates an authorization rule for a namespace.

### [New-AzServiceBusDisasterRecoveryConfig](New-AzServiceBusDisasterRecoveryConfig.md)
Creates or updates a new Alias(Disaster Recovery configuration)

### [New-AzServiceBusKey](New-AzServiceBusKey.md)
Regenerates the primary or secondary connection strings for the namespace.

### [New-AzServiceBusMigrationConfigAndStartMigration](New-AzServiceBusMigrationConfigAndStartMigration.md)
Creates Migration configuration and starts migration of entities from Standard to Premium namespace

### [New-AzServiceBusNamespace](New-AzServiceBusNamespace.md)
Creates or updates a service namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

### [New-AzServiceBusNamespaceIPFilterRule](New-AzServiceBusNamespaceIPFilterRule.md)
Creates or updates an IpFilterRule for a Namespace.

### [New-AzServiceBusNamespaceNetworkRuleSet](New-AzServiceBusNamespaceNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [New-AzServiceBusNamespaceVirtualNetworkRule](New-AzServiceBusNamespaceVirtualNetworkRule.md)
Creates or updates an VirtualNetworkRule for a Namespace.

### [New-AzServiceBusQueue](New-AzServiceBusQueue.md)
Creates or updates a Service Bus queue.
This operation is idempotent.

### [New-AzServiceBusRule](New-AzServiceBusRule.md)
Creates a new rule and updates an existing rule

### [New-AzServiceBusSubscription](New-AzServiceBusSubscription.md)
Creates a topic subscription.

### [New-AzServiceBusTopic](New-AzServiceBusTopic.md)
Creates a topic in the specified namespace.

### [Remove-AzServiceBusAuthorizationRule](Remove-AzServiceBusAuthorizationRule.md)
Deletes a namespace authorization rule.

### [Remove-AzServiceBusDisasterRecoveryConfig](Remove-AzServiceBusDisasterRecoveryConfig.md)
Deletes an Alias(Disaster Recovery configuration)

### [Remove-AzServiceBusMigrationConfig](Remove-AzServiceBusMigrationConfig.md)
Deletes a MigrationConfiguration

### [Remove-AzServiceBusNamespace](Remove-AzServiceBusNamespace.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzServiceBusNamespaceIPFilterRule](Remove-AzServiceBusNamespaceIPFilterRule.md)
Deletes an IpFilterRule for a Namespace.

### [Remove-AzServiceBusNamespaceVirtualNetworkRule](Remove-AzServiceBusNamespaceVirtualNetworkRule.md)
Deletes an VirtualNetworkRule for a Namespace.

### [Remove-AzServiceBusQueue](Remove-AzServiceBusQueue.md)
Deletes a queue from the specified namespace in a resource group.

### [Remove-AzServiceBusRule](Remove-AzServiceBusRule.md)
Deletes an existing rule.

### [Remove-AzServiceBusSubscription](Remove-AzServiceBusSubscription.md)
Deletes a subscription from the specified topic.

### [Remove-AzServiceBusTopic](Remove-AzServiceBusTopic.md)
Deletes a topic from the specified namespace and resource group.

### [Set-AzServiceBusAuthorizationRule](Set-AzServiceBusAuthorizationRule.md)
Creates or updates an authorization rule for a namespace.

### [Set-AzServiceBusDisasterRecoveryConfig](Set-AzServiceBusDisasterRecoveryConfig.md)
Creates or updates a new Alias(Disaster Recovery configuration)

### [Set-AzServiceBusNamespace](Set-AzServiceBusNamespace.md)
Creates or updates a service namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

### [Set-AzServiceBusNamespaceIPFilterRule](Set-AzServiceBusNamespaceIPFilterRule.md)
Creates or updates an IpFilterRule for a Namespace.

### [Set-AzServiceBusNamespaceNetworkRuleSet](Set-AzServiceBusNamespaceNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [Set-AzServiceBusNamespaceVirtualNetworkRule](Set-AzServiceBusNamespaceVirtualNetworkRule.md)
Creates or updates an VirtualNetworkRule for a Namespace.

### [Set-AzServiceBusQueue](Set-AzServiceBusQueue.md)
Creates or updates a Service Bus queue.
This operation is idempotent.

### [Set-AzServiceBusRule](Set-AzServiceBusRule.md)
Creates a new rule and updates an existing rule

### [Set-AzServiceBusSubscription](Set-AzServiceBusSubscription.md)
Creates a topic subscription.

### [Set-AzServiceBusTopic](Set-AzServiceBusTopic.md)
Creates a topic in the specified namespace.

### [Test-AzServiceBusDisasterRecoveryConfigNameAvailability](Test-AzServiceBusDisasterRecoveryConfigNameAvailability.md)
Check the give namespace name availability.

### [Test-AzServiceBusNamespaceNameAvailability](Test-AzServiceBusNamespaceNameAvailability.md)
Check the give namespace name availability.

### [Update-AzServiceBusNamespace](Update-AzServiceBusNamespace.md)
Updates a service namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

