---
Module Name: Az.ServiceBus
Module Guid: f73d11ef-c690-49f3-8c2c-9000e0e4fe69
Download Help Link: https://learn.microsoft.com/powershell/module/az.servicebus
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ServiceBus Module
## Description
Microsoft Azure PowerShell: ServiceBus cmdlets

## Az.ServiceBus Cmdlets
### [Approve-AzServiceBusPrivateEndpointConnection](Approve-AzServiceBusPrivateEndpointConnection.md)
Approves a ServiceBus PrivateEndpointConnection

### [Complete-AzServiceBusMigration](Complete-AzServiceBusMigration.md)
This operation Completes Migration of entities by pointing the connection strings to Premium namespace and any entities created after the operation will be under Premium Namespace.
CompleteMigration operation will fail when entity migration is in-progress.

### [Deny-AzServiceBusPrivateEndpointConnection](Deny-AzServiceBusPrivateEndpointConnection.md)
Denies a ServiceBus PrivateEndpointConnection

### [Get-AzServiceBusAuthorizationRule](Get-AzServiceBusAuthorizationRule.md)
Gets the Authorization Rule of a ServiceBus namespace, queue or topic.

### [Get-AzServiceBusGeoDRConfiguration](Get-AzServiceBusGeoDRConfiguration.md)
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

### [Get-AzServiceBusKey](Get-AzServiceBusKey.md)
Gets the SASKey of a ServiceBus namespace, queue or topic.

### [Get-AzServiceBusMigration](Get-AzServiceBusMigration.md)
Retrieves Migration Config

### [Get-AzServiceBusNamespace](Get-AzServiceBusNamespace.md)
Gets a description for the specified namespace.

### [Get-AzServiceBusNetworkRuleSet](Get-AzServiceBusNetworkRuleSet.md)
Gets NetworkRuleSet for a Namespace.

### [Get-AzServiceBusPrivateEndpointConnection](Get-AzServiceBusPrivateEndpointConnection.md)
Gets a description for the specified Private Endpoint Connection.

### [Get-AzServiceBusPrivateLink](Get-AzServiceBusPrivateLink.md)
Gets lists of resources that supports Privatelinks.

### [Get-AzServiceBusQueue](Get-AzServiceBusQueue.md)
Returns a description for the specified queue.

### [Get-AzServiceBusRule](Get-AzServiceBusRule.md)
Retrieves the description for the specified rule.

### [Get-AzServiceBusSubscription](Get-AzServiceBusSubscription.md)
Returns a subscription description for the specified topic.

### [Get-AzServiceBusTopic](Get-AzServiceBusTopic.md)
Returns a description for the specified topic.

### [New-AzServiceBusAuthorizationRule](New-AzServiceBusAuthorizationRule.md)
Creates a ServiceBus Namespace, Queue, Topic Authorization Rule

### [New-AzServiceBusGeoDRConfiguration](New-AzServiceBusGeoDRConfiguration.md)
Creates or updates a new Alias(Disaster Recovery configuration)

### [New-AzServiceBusIPRuleConfig](New-AzServiceBusIPRuleConfig.md)
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzServiceBusNetworkRuleSet

### [New-AzServiceBusKey](New-AzServiceBusKey.md)
Regenerates the SASKey of a ServiceBus namespace, queue or topic.

### [New-AzServiceBusKeyVaultPropertiesObject](New-AzServiceBusKeyVaultPropertiesObject.md)
Create an in-memory object for KeyVaultProperties.

### [New-AzServiceBusNamespace](New-AzServiceBusNamespace.md)
Creates a new ServiceBus namespace.

### [New-AzServiceBusQueue](New-AzServiceBusQueue.md)
Creates or updates a Service Bus queue.
This operation is idempotent.

### [New-AzServiceBusRule](New-AzServiceBusRule.md)
Creates a new rule and updates an existing rule

### [New-AzServiceBusSubscription](New-AzServiceBusSubscription.md)
Creates a topic subscription.

### [New-AzServiceBusTopic](New-AzServiceBusTopic.md)
Creates a topic in the specified namespace.

### [New-AzServiceBusVirtualNetworkRuleConfig](New-AzServiceBusVirtualNetworkRuleConfig.md)
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzServiceBusNetworkRuleSet

### [Remove-AzServiceBusAuthorizationRule](Remove-AzServiceBusAuthorizationRule.md)
Removes the Authorization Rule of a ServiceBus Namespace, Queue or Topic

### [Remove-AzServiceBusGeoDRConfiguration](Remove-AzServiceBusGeoDRConfiguration.md)
Deletes an Alias(Disaster Recovery configuration)

### [Remove-AzServiceBusMigration](Remove-AzServiceBusMigration.md)
Deletes a MigrationConfiguration

### [Remove-AzServiceBusNamespace](Remove-AzServiceBusNamespace.md)
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

### [Remove-AzServiceBusPrivateEndpointConnection](Remove-AzServiceBusPrivateEndpointConnection.md)
Deletes an existing Private Endpoint Connection.

### [Remove-AzServiceBusQueue](Remove-AzServiceBusQueue.md)
Deletes a queue from the specified namespace in a resource group.

### [Remove-AzServiceBusRule](Remove-AzServiceBusRule.md)
Deletes an existing rule.

### [Remove-AzServiceBusSubscription](Remove-AzServiceBusSubscription.md)
Deletes a subscription from the specified topic.

### [Remove-AzServiceBusTopic](Remove-AzServiceBusTopic.md)
Deletes a topic from the specified namespace and resource group.

### [Set-AzServiceBusAuthorizationRule](Set-AzServiceBusAuthorizationRule.md)
Updates the authorization rule of a ServiceBus namespace, queue or topic.

### [Set-AzServiceBusGeoDRConfigurationBreakPair](Set-AzServiceBusGeoDRConfigurationBreakPair.md)
This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

### [Set-AzServiceBusGeoDRConfigurationFailOver](Set-AzServiceBusGeoDRConfigurationFailOver.md)
Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace

### [Set-AzServiceBusNamespace](Set-AzServiceBusNamespace.md)
Updates a ServiceBus namespace

### [Set-AzServiceBusNetworkRuleSet](Set-AzServiceBusNetworkRuleSet.md)
Updates the NetworkRuleSet of a ServiceBus namespace

### [Set-AzServiceBusQueue](Set-AzServiceBusQueue.md)
Updates a ServiceBus Queue

### [Set-AzServiceBusRule](Set-AzServiceBusRule.md)
Updates a ServiceBus Rule

### [Set-AzServiceBusSubscription](Set-AzServiceBusSubscription.md)
Updates a ServiceBus Subscription

### [Set-AzServiceBusTopic](Set-AzServiceBusTopic.md)
Updates a ServiceBus Topic

### [Start-AzServiceBusMigration](Start-AzServiceBusMigration.md)
Creates Migration configuration and starts migration of entities from Standard to Premium namespace

### [Stop-AzServiceBusMigration](Stop-AzServiceBusMigration.md)
This operation reverts Migration

### [Test-AzServiceBusName](Test-AzServiceBusName.md)
Checks availability of a namespace name or disaster recovery alias.

