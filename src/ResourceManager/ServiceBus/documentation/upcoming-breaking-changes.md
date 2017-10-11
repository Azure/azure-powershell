<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes

## Release 3.0.0

    The following cmdlets were affected this release:
	
   **Get-AzureRmServiceBusTopicAuthorizationRule**
	- 'Get-AzureRmServiceBusTopicAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmServiceBusAuthorizationRule'
	
   **Get-AzureRmServiceBusTopicKey**
	- 'Get-AzureRmServiceBusTopicKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmServiceBusKey'
	
   **New-AzureRmServiceBusTopicAuthorizationRule**, 
	- 'New-AzureRmServiceBusTopicAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmServiceBusAuthorizationRule'
	
   **New-AzureRmServiceBusTopicKey**,
	- 'New-AzureRmServiceBusTopicKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmServiceBusKey'
	
   **Remove-AzureRmServiceBusTopicAuthorizationRule**, 
   - 'Remove-AzureRmServiceBusTopicAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Remove-AzureRmServiceBusAuthorizationRule'
   
   **Set-AzureRmServiceBusTopicAuthorizationRule**,
   - 'Set-AzureRmServiceBusTopicAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Set-AzureRmServiceBusAuthorizationRule'
   
   **New-AzureRmServiceBusNamespaceKey**, 
   - 'New-AzureRmServiceBusNamespaceKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmServiceBusKey'
   
   **Get-AzureRmServiceBusQueueAuthorizationRule**, 
   - 'Get-AzureRmServiceBusQueueAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmServiceBusAuthorizationRule'
   
   **Get-AzureRmServiceBusQueueKey**,
   - 'Get-AzureRmServiceBusQueueKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmServiceBusKey'
   
   **New-AzureRmServiceBusQueueAuthorizationRule**, 
   - 'New-AzureRmServiceBusQueueAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmServiceBusAuthorizationRule'
   
   **New-AzureRmServiceBusQueueKey**,
   - 'New-AzureRmServiceBusQueueKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmServiceBusKey'
   
   **Remove-AzureRmServiceBusQueueAuthorizationRule**,
   - 'Remove-AzureRmServiceBusQueueAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'GRemove-AzureRmServiceBusAuthorizationRule'
   
   **Set-AzureRmServiceBusQueueAuthorizationRule**, 
   - 'Set-AzureRmServiceBusQueueAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Set-AzureRmServiceBusAuthorizationRule'
   
   **Get-AzureRmServiceBusNamespaceAuthorizationRule**, 
   - 'Get-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmServiceBusAuthorizationRule'
   
   **Get-AzureRmServiceBusNamespaceKey**, 
   - 'Get-AzureRmServiceBusNamespaceKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmServiceBusKey'
   
   **New-AzureRmServiceBusNamespaceAuthorizationRule**,
   - 'New-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmServiceBusAuthorizationRule'
   
   **Remove-AzureRmServiceBusNamespaceAuthorizationRule**,
   - 'Remove-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Remove-AzureRmServiceBusAuthorizationRule'
   
   **Set-AzureRmServiceBusNamespaceAuthorizationRule**
   - 'Set-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Set-AzureRmServiceBusAuthorizationRule'
   
   
   The following properties are marked as obsolete in this release:
   
   ** NamespceAttributes **
   - Status
   - Enabled
   
   ```powershell
    # Old
	# The $namespace has Status and Enabled property 
    $namespace = Get-AzureRmServiceBusNamespace <parameters>
	$namespace.Status
	$namespace.Enabled
    # New

    # The call remains the same, but the returned values NameSpace object will not have the ResourceGroupName property    
    $namespace = Get-AzureRmServiceBusNamespace <parameters>
    
    ```
   
   
   ** Queue **
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
   
   ** Topic **
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

    # The call remains the same, but the returned values Topic object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
    $topic = Get-AzureRmServiceBusTopic <parameters>
    
    ```
   
   ** Subscription **
   - EntityAvailabilityStatus
   - DeadLetteringOnFilterEvaluationExceptions
   - Location
   - IsReadOnly
   
    ```powershell
   
    # Old
	# The $subscription has EntityAvailabilityStatus, EnableSubscriptionPartitioning, IsAnonymousAccessible, IsExpress, Location and FilteringMessagesBeforePublishing property 
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
   