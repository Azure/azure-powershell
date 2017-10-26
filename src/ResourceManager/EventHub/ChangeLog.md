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

The following cmdlets were affected this release:
	
	**New-AzureRmEventHubNamespaceAuthorizationRule**
	- 'New-AzureRmEventHubNamespaceAuthorizationRule' cmdlet removed in this build. Please use the New cmdlet 'New-AzureRmEventHubAuthorizationRule'
	
	**Get-AzureRmEventHubNamespaceAuthorizationRule**
	- 'Get-AzureRmEventHubNamespaceAuthorizationRule' cmdlet removed in this build. Please use the New cmdlet 'Get-AzureRmEventHubAuthorizationRule'
	
	**Set-AzureRmEventHubNamespaceAuthorizationRule**
	- 'Set-AzureRmEventHubNamespaceAuthorizationRule' cmdlet removed in this build. Please use the New cmdlet 'Set-AzureRmEventHubAuthorizationRule'
	
	**Remove-AzureRmEventHubNamespaceAuthorizationRule**
	- 'Remove-AzureRmEventHubNamespaceAuthorizationRule' cmdlet removed in this build. Please use the New cmdlet 'Remove-AzureRmEventHubAuthorizationRule'
	
	**New-AzureRmEventHubNamespaceKey**
	- 'New-AzureRmEventHubNamespaceKey' cmdlet removed in this build. Please use the New cmdlet 'New-AzureRmEventHubKey'
	
	**Get-AzureRmEventHubNamespaceKey**
	- 'Get-AzureRmEventHubNamespaceKey' cmdlet removed in this build. Please use the New cmdlet 'Get-AzureRmEventHubKey'
		
    **New-AzureRmEventHubNamespace**
	
    - The property 'Status' and 'Enabled' from the NamespceAttributes is removed. 

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
    - The property 'Status' and 'Enabled' from the NamespceAttributes is removed. 

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
    - The property 'Status' and 'Enabled' from the NamespceAttributes is removed. 

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
    - The property 'EventHubPath' from the ConsumerGroupAttributes is removed.

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
    - The property 'EventHubPath' from the ConsumerGroupAttributes is removed.

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
    - The property 'EventHubPath' from the ConsumerGroupAttributes is removed.

    ```powershell
    # Old
	# The $consumergroup has EventHubPath property 
    $consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
	$consumergroup.EventHubPath
	
    # New

    # The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
    $consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
    
    ```

## Version 0.4.7

## Version 0.4.6

## Version 0.4.4

## Version 0.4.3
* added ResourceGroup property to NamespaceAttributes
    - 'ResourceGroup' Gets the name of the resource group the Namespace is in

* updated commandlets with new parameter and parameter alias
	- below cmdlets updated with Parametersets for Namespace and EventHub for operation of AuthorizationRule

    - New-AzureRmEventHubAuthorizationRule
        - Adds a new AuthorizationRule to the existing NameSpace or EventHub.
    - Get-AzureRmEventHubAuthorizationRule
        - Gets AuthorizationRule / List of AuthorizationRules for the existing NameSpace or EventHub.
    - Set-AzureRmEventHubAuthorizationRule
        - Updates properties of existing AuthorizationRule of EventHub NameSpace.
    - Remove-AzureRmEventHubAuthorizationRule
        - Deletes the existing AuthorizationRule of existing NameSpace or EventHub.    
    - New-AzureRmEventHubKey
        - Generates a new Primary/Secondary Key for AuthorizationRule of existing NameSpace or EventHub.
    - Get-AzureRmEventHubKey
        - Gets Primary/Secondary Key for AuthorizationRule of existing NameSpace or EventHub.

## Version 0.4.2
		
## Version 0.4.1

## Version 0.4.0

## Version 0.3.1

## Version 0.3.0
* Bug fix : 
	- Fix for Set-AzureRmEventHubNamespace cmdlet error  - 'Tier' cannot be null, where it should be 'SkuName' 
    - Set-AzureRmEventHub - Fix 'Object reference not set to an instance of an object' error while updating EventHub  

## Version 0.2.0

## Version 0.1.0

## Version 0.0.3
* Future Breaking Change Notification: We've added a warning about removing property 'ResourceGroupName' from the returned NamespceAttributes from cmdlets New-AzureRmEventHubNamespace, Get-AzureRmEvnetHubNamespace and Set-AzureRmEvnetHubNamespace

## Version 0.0.2

## Version 0.0.1
* Adds commandlets for the Azure EventHub

    - New-AzureRmEventHubNamespace
        - Adds a New EventHub NameSpace in the existing Resource Group.
    - Get-AzureRmEventHubNamespace
        - Gets Eventhub NameSpace/list of NameSpaces of existing Resource Group.
    - Set-AzureRmEventHubNamespace
        - Updates properties of existing EventHub NameSpace.
    - Remove-AzureRmEventHubNamespace
        - Deletes the existing EventHub NameSpace.
    - New-AzureRmEventHubNamespaceAuthorizationRule
        - Adds a new AuthorizationRule to the existing EventHub NameSpace.
    - Get-AzureRmEventHubNamespaceAuthorizationRule
        - Gets AuthorizationRule / List of AuthorizationRules for the existing EventHub NameSpace.
    - Set-AzureRmEventHubNamespaceAuthorizationRule
        - Updates properties of existing AuthorizationRule of EventHub NameSpace.
    - New-AzureRmEventHubNamespaceKey
        - Generates a new Primary/Secondary Key for AuthorizationRule of existing EventHub NameSpace.
    - Get-AzureRmEventHubNamespaceKey
        - Gets Primary/Secondary Key for AuthorizationRule of existing EventHub NameSpace.
    - Remove-AzureRmEventHubNamespaceAuthorizationRule
        - Deletes the existing AuthorizationRule of EventHub NameSpace.
    - New-AzureRmEventHub
        - Adds a new EventHub to the existing NameSpace.
    - Get-AzureRmEventHub
        - Gets existing Queue/ List of EventHub of the existing NameSpace.
    - Set-AzureRmEventHub
        - Updates properties of existing EventHub of NameSpace.
    - Remove-AzureRmEventHub
        - Deletes existing EventHub of NameSpace.
    - New-AzureRmEventHubAuthorizationRule
        - Adds a new AuthorizationRule to the existing EventHub of NameSpace.
    - Get-AzureRmEventHubAuthorizationRule
        - Gets the AuthorizationRule / List of AuthorizationRules of the EventHub. 
    - Set-AzureRmEventHubAuthorizationRule
        - Updates the AuthorizationRule of the EventHub.
    - New-AzureRmEventHubKey
        - Generates a new Primary/Secondary Key for AuthorizationRule of existing EventHub.
    - Get-AzureRmEventHubKey
        - Gets Primary/Secondary Key for AuthorizationRule of existing EventHub.
    - Remove-AzureRmEventHubAuthorizationRule
        - Deletes the existing AuthorizationRule of EventHub.
    - New-AzureRmEventHubConsumerGroup
        - Adds a new ConsumerGroup to the existing EventHub
    - Get-AzureRmEventHubConsumerGroup
        - Gets existing ConsumerGroup/ List of ConsumerGroups of the existing EventHub.
    - Set-AzureRmEventHubConsumerGroup
        - Updates properties of existing ConsumerGroup of EventHub.
    - Remove-AzureRmEventHubConsumerGroup
        - Deletes existing ConsumerGroup of EventHub.