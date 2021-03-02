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

## Version 0.6.14
* This module is outdated and will go out of support on 29 February 2024.
* The Az.ServiceBus module has all the capabilities of AzureRM.ServiceBus and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.6.13
* Added MigrationState read-only property to PSServiceBusMigrationConfigurationAttributes which will help to know the Migration state.

## Version 0.6.12
* Fixed issue
	- https://github.com/Azure/azure-powershell/issues/7161

## Version 0.6.11
* Fixed issues
	- https://github.com/Azure/azure-powershell/issues/5058
	- https://github.com/Azure/azure-powershell/issues/5055
	- https://github.com/Azure/azure-powershell/issues/6891
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 0.6.10
* Fixed issue with default resource groups not being set.
* Fix for issues
	- https://github.com/Azure/azure-powershell/issues/5058
	- https://github.com/Azure/azure-powershell/issues/5055
	- https://github.com/Azure/azure-powershell/issues/6891

## Version 0.6.9
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.6.8
* Updated all help files to include full parameter types and correct input/output types.
* Updated piping for InputObject and ResourceId in remove cmdlets
* fixed few issues
	- https://github.com/Azure/azure-powershell/issues/3780
	- https://github.com/Azure/azure-powershell/issues/4340

## Version 0.6.7
* Added top and skip parameter to list cmdlets
* Added Standard to Premium NameSpace migration cmdlets :
	- Start-AzureRmServiceBusMigration
	- Get-AzureRmServiceBusMigration
	- Complete-AzureRmServiceBusMigration
	- Stop-AzureRmServiceBusMigration
	- Remove-AzureRmServiceBusMigration
* Added a readonly property 'PendingReplicationOperationsCount' to PSServiceBusDRConfigurationAttributes class, which gives the pending replication operations count while replication is in progress

## Version 0.6.6
* Added optional Parameter -KeyValue to New-AzureRmServiceBusKey cmdlet, which enables user to provide KeyValue.
* Fixed formatting of OutputType in help files

## Version 0.6.5
* Set minimum dependency of module to PowerShell 5.0

## Version 0.6.4
* Added 'properties' in CorrelationFilter of Rules to support customproperties
* updated New-AzureRmServiceBusGeoDRConfiguration help and fixed Rules cmdlet output
* Fixed auto-forward properties in New-AzureRmServiceBusQueue and New-AzureRmServiceBusSubscription cmdlet
* Updated to the latest version of the Azure ClientRuntime

## Version 0.6.3
* Fix issue with Default Resource Group in CloudShell

## Version 0.6.2
* Added EnableBatchedOperations property to Queue
* Added DeadLetteringOnFilterEvaluationExceptions property to Subscriptions

## Version 0.6.1
* Added functionality fix for Remove-AzureRmServiceBusRule and Get-AzureRmServiceBusKey

## Version 0.6.0
* Added below new commandlets for Geo Disaster Recovery operations.
	-Creating a new Alias(Disaster Recovery configuration):
		- New-AzureRmServiceBusDRConfigurations [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-PartnerNamespace] <String> [-WhatIf] [-Confirm]
	-Retrieve Alias(Disaster Recovery configuration) :
		- Get-AzureRmServiceBusDRConfigurations [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
	-Disabling the Disaster Recovery and stops replicating changes from primary to secondary namespaces
		- Set-AzureRmServiceBusDRConfigurationsBreakPairing [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Invoking Disaster Recovery failover and reconfigure the alias to point to the secondary namespace
		- Set-AzureRmServiceBusDRConfigurationsFailOver [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Deleting an Alias(Disaster Recovery configuration)
		- Remove-AzureRmServiceBusDRConfigurations [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-WhatIf] [-Confirm]
* Updated Test-AzureRmServiceBusName commandlets to support Geo Disaster Recovery - Alias name check availability operations.
	-Check the Availability of Namespace name or Alias(Disaster Recovery configuration) name:
		- Test-AzureRmServiceBusName [-ResourceGroupName] <String> [-Namespace] <String> [-AliasName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]

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
