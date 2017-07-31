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