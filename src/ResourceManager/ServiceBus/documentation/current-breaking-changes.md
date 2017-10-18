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