---
Module Name: Az.ServiceBus
Module Guid: cc69c625-e961-43f4-8b50-0061eba6e4b6
Download Help Link: https://docs.microsoft.com/powershell/module/az.servicebus
Help Version: 4.0.0.0
Locale: en-US
---

# Az.ServiceBus Module
## Description
This topic displays help topics for the Azure Service Bus cmdlets.

## Az.ServiceBus Cmdlets
### [Complete-AzServiceBusMigration](Complete-AzServiceBusMigration.md)
Cmdlets set the Migration from Standard to premium namespace as complete and connection strings of standard namespace now point to Premium namespace

### [Get-AzServiceBusAuthorizationRule](Get-AzServiceBusAuthorizationRule.md)
Gets a description of the specified authorization rule for a given Namespace or Queue or Topic or Alias (GeoDR Configurations). 

### [Get-AzServiceBusGeoDRConfiguration](Get-AzServiceBusGeoDRConfiguration.md)
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

### [Get-AzServiceBusKey](Get-AzServiceBusKey.md)
Gets the primary and secondary connection strings for the given Namespace or Queue or Topic or Alias (GeoDR Configurations).

### [Get-AzServiceBusMigration](Get-AzServiceBusMigration.md)
Retrieves MigrationConfiguration for the namespace

### [Get-AzServiceBusNamespace](Get-AzServiceBusNamespace.md)
Gets a description for the specified Service Bus namespace within the resource group.

### [Get-AzServiceBusOperation](Get-AzServiceBusOperation.md)
List supported ServiceBus Operations

### [Get-AzServiceBusQueue](Get-AzServiceBusQueue.md)
Returns a description for the specified Service Bus queue.

### [Get-AzServiceBusRule](Get-AzServiceBusRule.md)
Creates a new rule for a given Subscription of Topic. 

### [Get-AzServiceBusSubscription](Get-AzServiceBusSubscription.md)
Returns a subscription description for the specified topic.

### [Get-AzServiceBusTopic](Get-AzServiceBusTopic.md)
Returns a description for the specified Service Bus topic.

### [New-AzServiceBusAuthorizationRule](New-AzServiceBusAuthorizationRule.md)
Creates a new authorization rule for the specified Service Bus given Namespace or Queue or Topic.

### [New-AzServiceBusAuthorizationRuleSASToken](New-AzServiceBusAuthorizationRuleSASToken.md)
Generates a SAS tolen for Azure serviucebus authorization rule of namespace/queue/topic. 

### [New-AzServiceBusGeoDRConfiguration](New-AzServiceBusGeoDRConfiguration.md)
Creates an new Alias(Disaster Recovery configuration)

### [New-AzServiceBusKey](New-AzServiceBusKey.md)
Regenerates the primary or secondary connection strings for the Service Bus namespace or queue or topic.

### [New-AzServiceBusNamespace](New-AzServiceBusNamespace.md)
Creates a new Service Bus namespace.

### [New-AzServiceBusQueue](New-AzServiceBusQueue.md)
Creates a Service Bus queue in the specified Service Bus namespace.

### [New-AzServiceBusRule](New-AzServiceBusRule.md)
Creates a new rule for a given Subscription of Topic. 

### [New-AzServiceBusSubscription](New-AzServiceBusSubscription.md)
Creates a subscription to the specified Service Bus topic.

### [New-AzServiceBusTopic](New-AzServiceBusTopic.md)
Creates a new Service Bus topic in  the specified Service Bus namespace.

### [Remove-AzServiceBusAuthorizationRule](Remove-AzServiceBusAuthorizationRule.md)
Removes the authorization rule of a Service Bus namespace or queue or topic from the specified resource group.

### [Remove-AzServiceBusGeoDRConfiguration](Remove-AzServiceBusGeoDRConfiguration.md)
Deletes an Alias(Disaster Recovery configuration)

### [Remove-AzServiceBusMigration](Remove-AzServiceBusMigration.md)
Cmdlet deletes the Migration configuration for Standard to Premium namespaces

### [Remove-AzServiceBusNamespace](Remove-AzServiceBusNamespace.md)
Removes the namespace from the specified resource group. 

### [Remove-AzServiceBusQueue](Remove-AzServiceBusQueue.md)
Removes the queue from the specified Service Bus namespace.

### [Remove-AzServiceBusRule](Remove-AzServiceBusRule.md)
Removes the specified rule of a given subscription .

### [Remove-AzServiceBusSubscription](Remove-AzServiceBusSubscription.md)
Removes the subscription to a topic from the specified Service Bus namespace.

### [Remove-AzServiceBusTopic](Remove-AzServiceBusTopic.md)
Removes the topic from the specified Service Bus namespace.

### [Set-AzServiceBusAuthorizationRule](Set-AzServiceBusAuthorizationRule.md)
Updates the specified authorization rule description for the given Service Bus namespace or queue or topic.

### [Set-AzServiceBusGeoDRConfigurationBreakPair](Set-AzServiceBusGeoDRConfigurationBreakPair.md)
This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

### [Set-AzServiceBusGeoDRConfigurationFailOver](Set-AzServiceBusGeoDRConfigurationFailOver.md)
Invokes GEO DR failover and reconfigure the alias to point to the secondary namespace

### [Set-AzServiceBusNamespace](Set-AzServiceBusNamespace.md)
Updates the description of an existing Service Bus namespace.

### [Set-AzServiceBusQueue](Set-AzServiceBusQueue.md)
Updates the description of a Service Bus queue in the specified Service Bus namespace.

### [Set-AzServiceBusRule](Set-AzServiceBusRule.md)
Updates the specified rule description for the given subscription.

### [Set-AzServiceBusSubscription](Set-AzServiceBusSubscription.md)
Updates a subscription description for a Service Bus topic in the specified Service Bus namespace.

### [Set-AzServiceBusTopic](Set-AzServiceBusTopic.md)
Updates the description of a Service Bus topic in the specified Service Bus namespace.

### [Start-AzServiceBusMigration](Start-AzServiceBusMigration.md)
Creates a new Migration configuration and starts migrating entities from Standard to Premium namespaces

### [Stop-AzServiceBusMigration](Stop-AzServiceBusMigration.md)
{{Fill in the Synopsis}}

### [Test-AzServiceBusName](Test-AzServiceBusName.md)
Checks the Availability of the given NameSpace Name or Alias (DR Configuration Name) 

