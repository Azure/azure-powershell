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
* Fix bug in Get-AzureRmEventHubGeoDRConfiguration help

## Version 0.6.0
* Added below new commands for Geo Disaster Recovery operations. 
	-Creating a new Alias(Disaster Recovery configuration): 
		- New-AzureRmEventHubGeoDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-PartnerNamespace] <String> [-WhatIf] [-Confirm]
	-Retrieve Alias(Disaster Recovery configuration) : 
		- Get-AzureRmEventHubGeoDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
	-Disabling the Disaster Recovery and stops replicating changes from primary to secondary namespaces
		- Set-AzureRmEventHubGeoDRConfigurationBreakPair [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Invoking Disaster Recovery failover and reconfigure the alias to point to the secondary namespace
		- Set-AzureRmEventHubGeoDRConfigurationFailOver [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Deleting an Alias(Disaster Recovery configuration)
		- Remove-AzureRmEventHubGeoDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-WhatIf] [-Confirm]

* Added below new commands for checking the Namespace Name and GeoDr Configuration Name - Alias availability. 
	-Check the Availability of Namespace name or Alias(Disaster Recovery configuration) name: 
		- Test-AzureRmEventHubName [-ResourceGroupName] <String> [-Namespace] <String> [-AliasName] <String>
		
## Version 0.5.1
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
		
## Version 0.5.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of breaking changes introduced.
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

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
