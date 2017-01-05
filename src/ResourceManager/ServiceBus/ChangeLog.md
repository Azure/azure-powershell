<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
    * Overview of change #1
        - Additional information about change #1
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

## Version 0.0.1
* Adds cmdlets for Azure Service Bus
    - New-AzureRmServiceBusNamespace
        - Adds a new Service Bus namespace in the existing resource group.
    - Get-AzureRmServiceBusNamespace
        - Gets a namespace or list of namespaces in the existing resource group.
    - Set-AzureRmServiceBusNamespace
        - Updates properties of an existing Service Bus namespace.
    - Remove-AzureRmServiceBusNamespace
        - Deletes an existing Service Bus namespace.
    - New-AzureRmServiceBusNamespaceAuthorizationRule
        - Adds a new authorization rule to an existing Service Bus namespace.
    - Get-AzureRmServiceBusNamespaceAuthorizationRule
        - Gets an authorization rule or list of authorization rules for the existing Service Bus namespace.
    - Set-AzureRmServiceBusNamespaceAuthorizationRule
        - Updates properties of an existing authorization rule in a Service Bus namespace.
    - New-AzureRmServiceBusNamespaceKey
        - Generates a new primary or secondary key for an authorization rule in an existing Service Bus namespace.
    - Get-AzureRmServiceBusNamespaceKey
        - Gets the primary or secondary key for an authorization rule in an existing Service Bus namespace.
    - Remove-AzureRmServiceBusNamespaceAuthorizationRule
        - Deletes an existing authorization rule in a Service Bus namespace.
    - New-AzureRmServiceBusQueue
        - Adds a new queue to an existing Service Bus namespace.
    - Get-AzureRmServiceBusQueue
        - Gets an existing queue or list of queues in an existing Service Bus namespace.
    - Set-AzureRmServiceBusQueue
        - Updates properties of an existing queue in a Service Bus namespace. 
    - Remove-AzureRmServiceBusQueue
        - Deletes an existing queue in a Service Bus namespace.
    - New-AzureRmServiceBusQueueAuthorizationRule
        - Adds a new authorization rule to an existing queue in a Service Bus namespace. 
    - Get-AzureRmServiceBusQueueAuthorizationRule
        - Gets the authorization rule or list of authorization rules in a queue. 
    - Set-AzureRmServiceBusQueueAuthorizationRule
        - Updates an authorization rule in a queue.
    - New-AzureRmServiceBusQueueKey
        - Generates a new primary or secondary key for an authorization rule in an existing Service Bus queue.
    - Get-AzureRmServiceBusQueueKey
        - Gets the primary or secondary key for an authorization rule in an existing Service Bus queue.
    - Remove-AzureRmServiceBusQueueAuthorizationRule
        - Deletes an existing authorization rule in a Service Bus queue.
    - New-AzureRmServiceBusTopic
       - Adds a new topic to an existing Service Bus namespace.
    - Get-AzureRmServiceBusTopic
       - Gets an existing topic or list of topics in an existing Service Bus namespace. 
    - Set-AzureRmServiceBusTopic
       - Updates the properties of an existing topic in a Service Bus namespace.
    - Remove-AzureRmServiceBusTopic
       - Deletes an existing topic in a Service Bus namespace. 
    - New-AzureRmServiceBusTopicAuthorizationRule
       - Adds a new authorization rule to an existing topic in a Service Bus namespace.
    - Get-AzureRmServiceBusTopicAuthorizationRule
       - Gets an authorization rule or list of authorization rules in the topic. 
    - Set-AzureRmServiceBusTopicAuthorizationRule
       - Updates an authorization rule in a topic.
    - New-AzureRmServiceBusTopicKey
       - Generates a new primary or secondary key for an authorization rule in an existing Service Bus topic.
    - Get-AzureRmServiceBusTopicKey
       - Gets the primary or secondary key for an authorization rule in an existing Service Bus topic.
    - Remove-AzureRmServiceBusTopicAuthorizationRule
       - Deletes an existing authorization rule in a Service Bus topic.
    - New-AzureRmServiceBusSubscription
       - Adds a new subscription to an existing Service Bus topic. 
    - Get-AzureRmServiceBusSubscription
        - Gets an existing subscription or list of subscriptions in an existing Service Bus topic.
    - Set-AzureRmServiceBusSubscription
        - Updates the properties of an existing subscription in a Service Bus topic. 
    - Remove-AzureRmServiceBusSubscription
        - Deletes an existing subscription in a Service Bus topic.