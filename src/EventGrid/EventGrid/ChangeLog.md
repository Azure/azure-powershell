<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
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
## Upcoming Release

## Version 1.1.1-preview
* Updated to use the 2019-02-01-preview API version.
* New commands:
    - New-AzureRmEventGridDomainTopic:
        - Creates a new Azure Event Grid Domain Topic.
    - Remove-AzureRmEventGridDomainTopic:
        - Removes an existing Azure Event Grid Domain Topic.

* Update the following cmdlets to support new scenarios in 2019-02-01-preview API version
    - New-AzureRmEventGridSubscription/Update-AzureRmEventGridSubscription:
        - Add new enum for servicebusqueue as destination.
        - Disallow usage of "All" in -IncludedEventType option and replace it with $null
    - Get-AzEventGridTopic, Get-AzEventGridDomain, Get-AzEventGridDomainTopic, Get-AzEventGridSubscription:
        - Add new optional parameters (Top, ODataQuery and NextLink) to support results pagination.

## Version 1.1.0
* Updated to use the 2019-01-01 API version.
* Update the following cmdlets to support new scenario in 2019-01-01 API version
    - New-AzureRmEventGridSubscription: Add new optional parameters for specifying:
        - Event Time-To-Live,
        - Maximum number of delivery attempts for the events,
        - Dead letter endpoint.
    - Update-AzureRmEventGridSubscription: Add new optional parameters for specifying:
        - Event Time-To-Live,
        - Maximum number of delivery attempts for the events,
        - Dead letter endpoint.
* Add new enum values (namely, storageQueue and hybridConnection) for EndpointType option in New-AzureRmEventGridSubscription and Update-AzureRmEventGridSubscription cmdlets.
* Show warning message if creating or updating the event subscription is expected to entail manual action from user.

## Version 1.0.0
* General availability of `Az.EventGrid` module

## Version 0.4.1-preview
* Updated to use the 2018-09-15-preview API version.
* Added new cmdlets to manage the resources in Azure Event Grid service.
    - New-AzureRmEventGridDomain
        - Creates a new Azure Event Grid Domain.
    - Get-AzureRmEventGridDomain
        - Gets the details of an Event Grid Domain, or gets a list of all Event Grid Domains in the current Azure subscription.
    - Remove-AzureRmEventGridDomain
        - Removes an Azure Event Grid Domain.
    - New-AzureRmEventGridDomainKey
        - Regenerates the shared access key for an Azure Event Grid Domain.
    - Get-AzureRmEventGridDomainKey
        - Gets the shared access keys used to publish events to an Event Grid Domain.
    - Get-AzureRmEventGridDomainTopic
        - Gets the details of an Event Grid Domain Topic, or gets a list of all Event Grid Domain Topics under specific Event Grid Domain in the current Azure subscription.
* Updated the following cmdlets to support new scenarios in 2018-09-15-preview API version
    - New-AzureRmEventGridSubscription:
        - Add new mandatory parameters to support piping for the new Event Grid Domain and Event Grid Domain Topic to allow creating new event subscription under these resources.
        - Add new mandatory parameters for specifying the new Event Grid Domain name and/or Event Grid Domain Topic name to allow creating new event subscription under these resources.
        - Add new Parameter sets for domains and domain topics to allow reusing existing parameters (e.g., EndPointType, SubjectBeginsWith, etc).
        - Add new optional parameters for specifying:
            - Event subscription expiration date,
            - Advanced filtering parameters.
    - Update-AzureRmEventGridSubscription: Add new optional parameters for specifying:
        - Similar as New-AzureRmEventGridSubscription.
    - Remove-AzureRmEventGridSubscription
        - Add new mandatory parameters to support piping for Event Grid Domain and Event Grid Domain Topic to allow removing existing event subscription under these resources.
        - Add new mandatory parameters for specifying the Event Grid Domain name and/or Event Grid Domain Topic name to allow removing existing event subscription under these resources.

## Version 0.4.0-preview
* Set minimum dependency of module to PowerShell 5.0
* Update the following cmdlets to support new scenario in 2018-05-01-preview API version
	- New-AzureRmEventGridTopic: Add new optional parameters for specifying:
		- Input schema.
		- Input mapping fields
		- Input mapping default values.
	- New-AzureRmEventGridSubscription: Add new optional parameters for specifying:
		- Event Time-To-Live,
		- Maximum number of delivery attempts for the events,
		- The delivery schema
		- Dead letter endpoint.
	- Update-AzureRmEventGridSubscription: Add new optional parameters for specifying:
		- Event Time-To-Live,
		- Maximum number of delivery attempts for the events,
		- Dead letter endpoint.
* Show warning message if creating or updating the event subscription is expected to entail manual action from user.
