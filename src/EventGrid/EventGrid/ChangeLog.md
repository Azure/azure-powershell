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

## Version 1.2.1
* Fix typo in `New-AzEventGridSubscription` documentation

## Version 1.2.0
* Updated to use the 2019-06-01 API version.
* New cmdlets:
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
    - New-AzureRmEventGridDomainTopic:
        - Creates a new Azure Event Grid Domain Topic.
    - Get-AzureRmEventGridDomainTopic
        - Gets the details of an Event Grid Domain Topic, or gets a list of all Event Grid Domain Topics under specific Event Grid Domain in the current Azure 
    - Remove-AzureRmEventGridDomainTopic:
        - Removes an existing Azure Event Grid Domain Topic.
* Updated cmdlets:
    - New-AzureRmEventGridSubscription/Update-AzureRmEventGridSubscription:
        - Add new mandatory parameters to support piping for the new Event Grid Domain and Event Grid Domain Topic to allow creating new event subscription under these resources.
        - Add new mandatory parameters for specifying the new Event Grid Domain name and/or Event Grid Domain Topic name to allow creating new event subscription under these resources.
        - Add new Parameter sets for domains and domain topics to allow reusing existing parameters (e.g., EndPointType, SubjectBeginsWith, etc).
        - Add new optional parameters for specifying:
            - Event subscription expiration date,
            - Advanced filtering parameters.
        - Add new enum for servicebusqueue as destination.
        - Disallow usage of "All" in -IncludedEventType option and replace it with $null
    - Get-AzEventGridTopic, Get-AzEventGridDomain, Get-AzEventGridDomainTopic, Get-AzEventGridSubscription:
        - Add new optional parameters (Top, ODataQuery and NextLink) to support results pagination and filtering.
    - Remove-AzureRmEventGridSubscription
        - Add new mandatory parameters to support piping for Event Grid Domain and Event Grid Domain Topic to allow removing existing event subscription under these resources.
        - Add new mandatory parameters for specifying the Event Grid Domain name and/or Event Grid Domain Topic name to allow removing existing event subscription under these resources.

## Version 1.1.1
* Updated the help text for endpoint to indicate that resources should be created before using the create/update event subscription cmdlets.

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
