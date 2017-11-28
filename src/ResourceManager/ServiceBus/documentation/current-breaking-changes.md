<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    ## Current Breaking Changes

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

## Current Breaking Changes

### Release 0.5.0 - November 2017

The following cmdlets were affected this release:

**Get-AzureRmServiceBusTopicAuthorizationRule**
- The 'Get-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusAuthorizationRule' cmdlet.	

**Get-AzureRmServiceBusTopicKey**
- The 'Get-AzureRmServiceBusTopicKey' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusKey' cmdlet.

**New-AzureRmServiceBusTopicAuthorizationRule**
- The 'New-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmServiceBusAuthorizationRule' cmdlet.

**New-AzureRmServiceBusTopicKey**
- The 'New-AzureRmServiceBusTopicKey' cmdlet has been removed. Please use the 'New-AzureRmServiceBusKey' cmdlet.

**Remove-AzureRmServiceBusTopicAuthorizationRule**
- The 'Remove-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'Remove-AzureRmServiceBusAuthorizationRule' cmdlet.

**Set-AzureRmServiceBusTopicAuthorizationRule**
- The 'Set-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmServiceBusAuthorizationRule'cmdlet.

**New-AzureRmServiceBusNamespaceKey**
- The 'New-AzureRmServiceBusNamespaceKey' cmdlet has been removed. Please use the 'New-AzureRmServiceBusKey' cmdlet.

**Get-AzureRmServiceBusQueueAuthorizationRule**
- The 'Get-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusAuthorizationRule' cmdlet.

**Get-AzureRmServiceBusQueueKey**
- The 'Get-AzureRmServiceBusQueueKey' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusKey' cmdlet.

**New-AzureRmServiceBusQueueAuthorizationRule**
- The 'New-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmServiceBusAuthorizationRule' cmdlet.

**New-AzureRmServiceBusQueueKey**
- The 'New-AzureRmServiceBusQueueKey' cmdlet has been removed. Please use the 'New-AzureRmServiceBusKey' cmdlet.

**Remove-AzureRmServiceBusQueueAuthorizationRule**
- The 'Remove-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'GRemove-AzureRmServiceBusAuthorizationRule' cmdlet.

**Set-AzureRmServiceBusQueueAuthorizationRule**
- The 'Set-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmServiceBusAuthorizationRule' cmdlet.

**Get-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'Get-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusAuthorizationRule' cmdlet.

**Get-AzureRmServiceBusNamespaceKey**
- The 'Get-AzureRmServiceBusNamespaceKey' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusKey' cmdlet.

**New-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'New-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmServiceBusAuthorizationRule' cmdlet.

**Remove-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'Remove-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Remove-AzureRmServiceBusAuthorizationRule' cmdlet.

**Set-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'Set-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmServiceBusAuthorizationRule' cmdlet.

**Type NamespaceAttributes**
- The following properties have been removed
    - Enabled
    - Status
   
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

**Type QueueAttribute**
- The following properties are marked as obsolete:
    - EnableBatchedOperations
    - EntityAvailabilityStatus
    - IsAnonymousAccessible
    - SupportOrdering

```powershell
# Old
# The $queue has EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties
$queue = Get-AzureRmServiceBusQueue <parameters>
$queue.EntityAvailabilityStatus
$queue.EnableBatchedOperations
$queue.IsAnonymousAccessible
$queue.SupportOrdering	

# New
# The call remains the same, but the returned values Queue object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
$queue = Get-AzureRmServiceBusQueue <parameters>
```
   
**Type TopicAttribute**
- The following properties are marked as obsolete:
    - Location
    - IsExpress
    - IsAnonymousAccessible
    - FilteringMessagesBeforePublishing
    - EnableSubscriptionPartitioning
    - EntityAvailabilityStatus

```powershell
# Old
# The $topic has EntityAvailabilityStatus, EnableSubscriptionPartitioning, IsAnonymousAccessible, IsExpress, Location and FilteringMessagesBeforePublishing properties
$topic = Get-AzureRmServiceBusTopic <parameters>
$topic.EntityAvailabilityStatus
$topic.EnableSubscriptionPartitioning
$topic.IsAnonymousAccessible
$topic.IsExpress
$topic.FilteringMessagesBeforePublishing
$topic.Location

# New
# The call remains the same, but the returned values Topic object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
$topic = Get-AzureRmServiceBusTopic <parameters>
```
   
**Type SubscriptionAttribute**
- The following properties are marked as obsolete
    - DeadLetteringOnFilterEvaluationExceptions
    - EntityAvailabilityStatus
    - IsReadOnly
    - Location
   
```powershell
# Old
# The $subscription has EntityAvailabilityStatus, EnableSubscriptionPartitioning, IsAnonymousAccessible, IsExpress, Location and FilteringMessagesBeforePublishing properties
$subscription = Get-AzureRmServiceBussubscription <parameters>
$subscription.EntityAvailabilityStatus
$subscription.EnableSubscriptionPartitioning
$subscription.IsAnonymousAccessible
$subscription.IsExpress
$subscription.FilteringMessagesBeforePublishing
$subscription.Location

# New
# The call remains the same, but the returned values Topic object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
$subscription = Get-AzureRmServiceBussubscription <parameters>
```