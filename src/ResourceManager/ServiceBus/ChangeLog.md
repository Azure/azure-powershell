<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
    * Overview of change #1
        - Additional information about change #1
        - Added ServiceBus NameSpace, Queue, Topic and Subscription cmdlets #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Current Release

The following cmdlets were affected this release:
	
   **Get-AzureRmServiceBusTopicAuthorizationRule**
	- 'Get-AzureRmServiceBusTopicAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Get-AzureRmServiceBusAuthorizationRule'
	
   **Get-AzureRmServiceBusTopicKey**
	- 'Get-AzureRmServiceBusTopicKey' cmdlet is removed in current build. Please use the New cmdlet 'Get-AzureRmServiceBusKey'
	
   **New-AzureRmServiceBusTopicAuthorizationRule**, 
	- 'New-AzureRmServiceBusTopicAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'New-AzureRmServiceBusAuthorizationRule'
	
   **New-AzureRmServiceBusTopicKey**,
	- 'New-AzureRmServiceBusTopicKey' cmdlet is removed in current build. Please use the New cmdlet 'New-AzureRmServiceBusKey'
	
   **Remove-AzureRmServiceBusTopicAuthorizationRule**, 
   - 'Remove-AzureRmServiceBusTopicAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Remove-AzureRmServiceBusAuthorizationRule'
   
   **Set-AzureRmServiceBusTopicAuthorizationRule**,
   - 'Set-AzureRmServiceBusTopicAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Set-AzureRmServiceBusAuthorizationRule'
   
   **New-AzureRmServiceBusNamespaceKey**, 
   - 'New-AzureRmServiceBusNamespaceKey' cmdlet is removed in current build. Please use the New cmdlet 'New-AzureRmServiceBusKey'
   
   **Get-AzureRmServiceBusQueueAuthorizationRule**, 
   - 'Get-AzureRmServiceBusQueueAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Get-AzureRmServiceBusAuthorizationRule'
   
   **Get-AzureRmServiceBusQueueKey**,
   - 'Get-AzureRmServiceBusQueueKey' cmdlet is removed in current build. Please use the New cmdlet 'Get-AzureRmServiceBusKey'
   
   **New-AzureRmServiceBusQueueAuthorizationRule**, 
   - 'New-AzureRmServiceBusQueueAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'New-AzureRmServiceBusAuthorizationRule'
   
   **New-AzureRmServiceBusQueueKey**,
   - 'New-AzureRmServiceBusQueueKey' cmdlet is removed in current build. Please use the New cmdlet 'New-AzureRmServiceBusKey'
   
   **Remove-AzureRmServiceBusQueueAuthorizationRule**,
   - 'Remove-AzureRmServiceBusQueueAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'GRemove-AzureRmServiceBusAuthorizationRule'
   
   **Set-AzureRmServiceBusQueueAuthorizationRule**, 
   - 'Set-AzureRmServiceBusQueueAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Set-AzureRmServiceBusAuthorizationRule'
   
   **Get-AzureRmServiceBusNamespaceAuthorizationRule**, 
   - 'Get-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Get-AzureRmServiceBusAuthorizationRule'
   
   **Get-AzureRmServiceBusNamespaceKey**, 
   - 'Get-AzureRmServiceBusNamespaceKey' cmdlet is removed in current build. Please use the New cmdlet 'Get-AzureRmServiceBusKey'
   
   **New-AzureRmServiceBusNamespaceAuthorizationRule**,
   - 'New-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'New-AzureRmServiceBusAuthorizationRule'
   
   **Remove-AzureRmServiceBusNamespaceAuthorizationRule**,
   - 'Remove-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Remove-AzureRmServiceBusAuthorizationRule'
   
   **Set-AzureRmServiceBusNamespaceAuthorizationRule**
   - 'Set-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is removed in current build. Please use the New cmdlet 'Set-AzureRmServiceBusAuthorizationRule'
   
   
   The following properties are removed in this release:
   
   **NamespceAttributes**
   - Status
   - Enabled
   
   ```powershell
    # Old
	# The $namespace has Status and Enabled property 
    $namespace = Get-AzureRmServiceBusNamespace <parameters>
	$namespace.Status
	$namespace.Enabled
	
    # New
    # The call remains the same, but the returned values NameSpace object will not have the Enabled and Status properties   
    $namespace = Get-AzureRmServiceBusNamespace <parameters>
```
   
   **Queue**
   - EntityAvailabilityStatus
   - EnableBatchedOperations
   - IsAnonymousAccessible
   - SupportOrdering
   
   ```powershell
   
    # Old
	# The $queue has EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering property 
    $queue = Get-AzureRmServiceBusQueue <parameters>
	$queue.EntityAvailabilityStatus
	$queue.EnableBatchedOperations
	$queue.IsAnonymousAccessible
	$queue.SupportOrdering	

    # New
    # The call remains the same, but the returned values Queue object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
    $queue = Get-AzureRmServiceBusQueue <parameters>
```
   
   **Topic**
   - Location
   - IsExpress
   - IsAnonymousAccessible
   - FilteringMessagesBeforePublishing
   - EnableSubscriptionPartitioning
   - EntityAvailabilityStatus
   
   ```powershell
   
    # Old
    # The $topic has EntityAvailabilityStatus, EnableSubscriptionPartitioning, IsAnonymousAccessible, IsExpress, Location and FilteringMessagesBeforePublishing property 
    $topic = Get-AzureRmServiceBusTopic <parameters>
	$topic.EntityAvailabilityStatus
	$topic.EnableSubscriptionPartitioning
	$topic.IsAnonymousAccessible
	$topic.IsExpress
	$topic.FilteringMessagesBeforePublishing
	$topic.Location

    # New
    # The call remains the same, but the returned values Topic object will not have the EntityAvailabilityStatus, EnableSubscriptionPartitioning, IsAnonymousAccessible, IsExpress, FilteringMessagesBeforePublishing and Location properties    
    $topic = Get-AzureRmServiceBusTopic <parameters>
```
   
   **Subscription**
   - EntityAvailabilityStatus
   - DeadLetteringOnFilterEvaluationExceptions
   - Location
   - IsReadOnly
   
   ```powershell
   
    # Old
	# The $subscription has EntityAvailabilityStatus, DeadLetteringOnFilterEvaluationExceptions, Location, and IsReadOnly property 
    $subscription = Get-AzureRmServiceBussubscription <parameters>
	$subscription.EntityAvailabilityStatus
	$subscription.DeadLetteringOnFilterEvaluationExceptions
	$subscription.Location
	$subscription.IsReadOnly

    # New
    # The call remains the same, but the returned values Topic object will not have the EntityAvailabilityStatus, DeadLetteringOnFilterEvaluationExceptions, Location, and IsReadOnly properties    
    $subscription = Get-AzureRmServiceBussubscription <parameters>
```

## Version 0.4.7

## Version 0.4.6

## Version 0.4.4

## Version 0.4.3
* Added below new commandlets for AuthorizationRules for NameSpace, Queue and Topic. according to parameter set the authorization rule orperations are perfomed. 
 - New-AzureRmServiceBusAuthorizationRule
   - Adds a new AuthorizationRule to the existing ServiceBus NameSpace/Queue/Topic.
 - Get-AzureRmServiceBusAuthorizationRule
   - Gets AuthorizationRule / List of AuthorizationRules for the existing ServiceBus NameSpace/Queue/Topic.
 - Set-AzureRmServiceBusAuthorizationRule
   - Updates properties of existing AuthorizationRule of Servicebus NameSpace/Queue/Topic.
 - New-AzureRmServiceBusKey
   - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace/Queue/Topic.
 - Get-AzureRmServiceBusKey
   - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace/Queue/Topic.   
 - Remove-AzureRmServiceBusNamespaceAuthorizationRule
   - Deletes the existing AuthorizationRule of ServiceBus NameSpace/Queue/Topic.   
* Added Resource Group property to NamespceAttributes

## Version 0.4.2

## Version 0.4.1

## Version 0.4.0

## Version 0.3.1

## Version 0.3.0

* Bug Fix: ServiceBus Queue object property values were set to null, the object is used as input parameter in Set-AzureRmServiceBusQueue cmdlet to update Queue. 
  - Properties affected are LockDuration, EntityAvailabilityStatus, DuplicateDetectionHistoryTimeWindow, MaxDeliveryCount and MessageCount 

## Version 0.2.0

## Version 0.1.0

## Version 0.0.3

## Version 0.0.2
* Add SkuCapacity parameter to Set-AzureRmServiceBusNamespace
    - User will be able to update the SkuCapacity(Messaging units in case of a premium namespace) of the SeriveBus NameSpace

* Future Breaking Change Notification: We've added a warning about removing property 'ResourceGroupName' from the returned NamespceAttributes from cmdlets New-AzureRmServiceBusNamespace, Get-AzureRmServiceBusNamespace and Set-AzureRmServiceBusNamespace
    -The call remains the same, but the returned values NameSpace object will not have the ResourceGroupName property  

## Version 0.0.1

* Adds commandlets for the Azure ServiceBus
 - New-AzureRmServiceBusNamespace
   - Adds a New ServiceBus NameSpace in the existing Resource Group.

 - Get-AzureRmServiceBusNamespace
   - Gets NameSpace/list of NameSpaces of existing Resource Group.

 - Set-AzureRmServiceBusNamespace
   - Updates properties of existing Servicebus NameSpace.

 - Remove-AzureRmServiceBusNamespace
   - Deletes the existing ServiceBus NameSpace.

 - New-AzureRmServiceBusNamespaceAuthorizationRule
   - Adds a new AuthorizationRule to the existing ServiceBus NameSpace.

 - Get-AzureRmServiceBusNamespaceAuthorizationRule
   - Gets AuthorizationRule / List of AuthorizationRules for the existing ServiceBus NameSpace.

 - Set-AzureRmServiceBusNamespaceAuthorizationRule
   - Updates properties of existing AuthorizationRule of Servicebus NameSpace.

 - New-AzureRmServiceBusNamespaceKey
   - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace.

 - Get-AzureRmServiceBusNamespaceKey
   - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace.
   
 - Remove-AzureRmServiceBusNamespaceAuthorizationRule
   - Deletes the existing AuthorizationRule of ServiceBus NameSpace.

 - New-AzureRmServiceBusQueue
   - Adds a new Queue to the existing ServiceBus NameSpace.

 - Get-AzureRmServiceBusQueue
   - Gets existing Queue/ List of Queues of the existing ServiceBus NameSpace.

 - Set-AzureRmServiceBusQueue
   - Updates properties of existing Queue of ServiceBus NameSpace.

 - Remove-AzureRmServiceBusQueue
   - Deletes existing Queue of ServiceBus NameSpace.

 - New-AzureRmServiceBusQueueAuthorizationRule
   - Adds a new AuthorizationRule to the existing Queue of ServiceBus NameSpace.

 - Get-AzureRmServiceBusQueueAuthorizationRule
   - Gets the AuthorizationRule / List of AuthorizationRules of the Queue 
   
 - Set-AzureRmServiceBusQueueAuthorizationRule
   - Updates the AuthorizationRule of the Queue.

 - New-AzureRmServiceBusQueueKey
   - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus Queue.

 - Get-AzureRmServiceBusQueueKey
   - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus Queue.

 - Remove-AzureRmServiceBusQueueAuthorizationRule
   - Deletes the existing AuthorizationRule of ServiceBus Queue.

 - New-AzureRmServiceBusTopic
   - Adds a new Topic to the existing ServiceBus NameSpace.

 - Get-AzureRmServiceBusTopic
   - Gets existing Topic/ List of Topics of the existing ServiceBus NameSpace.

 - Set-AzureRmServiceBusTopic
   - Updates properties of existing Topic of ServiceBus NameSpace.

 - Remove-AzureRmServiceBusTopic
   - Deletes existing Topic of ServiceBus NameSpace.

 - New-AzureRmServiceBusTopicAuthorizationRule
   - Adds a new AuthorizationRule to the existing Topic of ServiceBus NameSpace.

 - Get-AzureRmServiceBusTopicAuthorizationRule
   - Gets the AuthorizationRule / List of AuthorizationRules of the Topic.
   
 - Set-AzureRmServiceBusTopicAuthorizationRule
   - Updates the AuthorizationRule of the Topic.

 - New-AzureRmServiceBusTopicKey
   - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus Topic.

 - Get-AzureRmServiceBusTopicKey
   - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus Topic.

 - Remove-AzureRmServiceBusTopicAuthorizationRule
   - Deletes the existing AuthorizationRule of ServiceBus Topic.
   
 - New-AzureRmServiceBusSubscription
   - Adds a new Subscription to the existing ServiceBus Topic.

 - Get-AzureRmServiceBusSubscription
   - Gets existing Subscription/ List of Subscriptions of the existing ServiceBus Topic.

 - Set-AzureRmServiceBusSubscription
   - Updates properties of existing Subscription of ServiceBus Topic.

 - Remove-AzureRmServiceBusSubscription
   - Deletes existing Subscription of ServiceBus Topic.
