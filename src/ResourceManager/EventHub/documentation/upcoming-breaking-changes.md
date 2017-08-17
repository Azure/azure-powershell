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

## Release 4.3.0

    The following cmdlets were affected this release:
	
	**New-AzureRmEventHubNamespaceAuthorizationRule**
	- 'New-AzureRmEventHubNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmEventHubAuthorizationRule'
	
	**Get-AzureRmEventHubNamespaceAuthorizationRule**
	- 'Get-AzureRmEventHubNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmEventHubAuthorizationRule'
	
	**Set-AzureRmEventHubNamespaceAuthorizationRule**
	- 'Set-AzureRmEventHubNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Set-AzureRmEventHubAuthorizationRule'
	
	**Remove-AzureRmEventHubNamespaceAuthorizationRule**
	- 'Remove-AzureRmEventHubNamespaceAuthorizationRule' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Remove-AzureRmEventHubAuthorizationRule'
	
	**New-AzureRmEventHubNamespaceKey**
	- 'New-AzureRmEventHubNamespaceKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmEventHubKey'
	
	**Get-AzureRmEventHubNamespaceKey**
	- 'Get-AzureRmEventHubNamespaceKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmEventHubKey'
	
	
    **New-AzureRmEventHubNamespace**
    - The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

    ```powershell
    # Old
	# The $namespace has Status and Enabled property  
    $namespace = New-AzureRmEventHubNamespace <parameters>
	$namespace.Status
	$namespace.Enabled
	
    # New

    # The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
    $namespace = Get-AzureRmEventHubNamespace <parameters>
    
    ```
	
	**Get-AzureRmEventHubNamespace**
    - The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

    ```powershell
    # Old
	# The $namespace has Status and Enabled property 
    $namespace = Get-AzureRmEventHubNamespace <parameters>
	$namespace.Status
	$namespace.Enabled
	
    # New

    # The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
    $namespace = Get-AzureRmEventHubNamespace <parameters>
    
    ```
	
	**Set-AzureRmEventHubNamespace**
    - The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

    ```powershell
    # Old
	# The $namespace has Status and Enabled property 
    $namespace = Set-AzureRmEventHubNamespace <parameters>
	$namespace.Status
	$namespace.Enabled
	
    # New

    # The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
    $namespace = Set-AzureRmEventHubNamespace <parameters>
    
    ```	
  
  **New-AzureRmEventHubConsumerGroup**
    - The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

    ```powershell
    # Old
	# The $consumergroup has EventHubPath property 
    $consumergroup = New-AzureRmEventHubConsumerGroup <parameters>
	$consumergroup.EventHubPath
	
    # New

    # The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
    $consumergroup = New-AzureRmEventHubConsumerGroup <parameters>
    
    ```
	
	**Set-AzureRmEventHubConsumerGroup**
    - The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

    ```powershell
    # Old
	# The $consumergroup has EventHubPath property 
    $consumergroup = Set-AzureRmEventHubConsumerGroup <parameters>
	$consumergroup.EventHubPath
	
    # New

    # The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
    $consumergroup = Set-AzureRmEventHubConsumerGroup <parameters>
    
    ```
	
	**Get-AzureRmEventHubConsumerGroup**
    - The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

    ```powershell
    # Old
	# The $consumergroup has EventHubPath property 
    $consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
	$consumergroup.EventHubPath
	
    # New

    # The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
    $consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
    
    ```
	