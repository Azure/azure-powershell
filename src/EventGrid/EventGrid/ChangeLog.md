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
* upgraded nuget package to signed package.

## Version 2.1.0
* Fixed an issue that caused some commands ending in `Object` to not work properly.

## Version 2.0.0
* Updated to use the 2023-06-01-preview API version.

## Version 1.6.1
* Added breaking change messages due to structure update:
  - The cmdlet `Set-AzEventGridTopic` will be removed.
  - In the `Remove-AzEventGridSubscription` parameters will be deprecated.
  - In the `Get-AzEventGrid*` the parameter `ODataQuery`, `NextLink`, `ResourceId` will be removed.
  - In the `New/Update-AzEventGrid*` parameters will be deprecated.

## Version 1.6.0
* Added fix for DeliveryAttributeMapping
* Added validation for StorageQueueTtl

## Version 1.5.0
* Updated to use the 2022-06-15 API version.
* Added new features:
    - Partner topics
    - Partner topic event subscriptions
    - Partner namespaces
    - Partner namespace keys
    - Partner configurations
    - Partner registrations
    - Verified partners
    - Channels

## Version 1.4.1
* Add remaining advanced filters
  * StringNotContains
  * StringNotBeginsWith
  * StringNotEndsWith
  * NumberInRange
  * NumberNotInRange
  * IsNullOrUndefined
  * IsNotNull

## Version 1.4.0
* Updated to use the 2021-12-01 API version.
* Added new features:
    - System topic
    - System topic event subscription
    - System topic event subscription delivery attributes
* Updated cmdlets:
    - `New-AzEventGridDomain`:
        - Add new optional parameters to support auto creation of topic with first subscription.
        - Add new optional parameters to support auto deletion of topic with last subscription.
        - Add optional parameters to support azure managed identity
    - `New-AzEventGridTopic`/`Update-AzEventGridTopic` :
        - Add optional parameters to support azure managed identity
    - `New-AzEventGridSubscription `/`Update-AzEventGridSubscription `:
        - Add new optional parameters to support advanced filtering on arrays.
        - Add new optional parameters to support delivery attribute mapping.
        - Add new optional parameters to support storage queue message ttl.

## Version 1.3.0
* Updated to use the 2020-06-01 API version.
* Added new features:
    - Input mapping
    - Event Delivery Schema
    - Private Link
    - Cloud Event V10 Schema
    - Service Bus Topic As Destination
    - Azure Function As Destination
    - WebHook Batching
    - Secure webhook (AAD support)
    - IpFiltering
* Updated cmdlets:
    - `New-AzEventGridSubscription`/`Update-AzEventGridSubscription`:
        - Add new optional parameters to support webhook batching.
        - Add new optional parameters to support secured webhook using AAD.
        - Add new enum for EndpointType parameter to support azure function and service bus topic as new destinations.
        - Add new optional parameter for delivery schema.
    - `New-AzEventGridTopic`/`Update-AzEventGridTopic` and `New-AzEventGridDomain`/`Update-AzEventGridDomain`:
        - Add new optional parameters to support IpFiltering.
    - `New-AzEventGridTopic`/`New-AzEventGridDomain`:
        - Add new optional parameters to support Input mapping.

## Version 1.2.3
* Update references in .psd1 to use relative path

## Version 1.2.2
* Fixed miscellaneous typos across module

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
