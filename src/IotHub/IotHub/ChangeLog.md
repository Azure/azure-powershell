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

## Version 2.0.1
* Update references in .psd1 to use relative path

## Version 2.0.0

* Breaking changes:
    - The cmdlet 'Add-AzIotHubEventHubConsumerGroup' no longer supports the parameter 'EventHubEndpointName' and no alias was found for the original parameter name.
    - The parameter set '__AllParameterSets' for cmdlet 'Add-AzIotHubEventHubConsumerGroup' has been removed.
    - The cmdlet 'Get-AzIotHubEventHubConsumerGroup' no longer supports the parameter 'EventHubEndpointName' and no alias was found for the original parameter name.
    - The parameter set '__AllParameterSets' for cmdlet 'Get-AzIotHubEventHubConsumerGroup' has been removed.
    - The property 'OperationsMonitoringProperties' of type 'Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHubProperties' has been removed.
    - The property 'OperationsMonitoringProperties' of type 'Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHubInputProperties' has been removed.
    - The cmdlet 'New-AzIotHubExportDevice' no longer supports the alias 'New-AzIotHubExportDevices'.
    - The cmdlet 'New-AzIotHubImportDevice' no longer supports the alias 'New-AzIotHubImportDevices'.
    - The cmdlet 'Remove-AzIotHubEventHubConsumerGroup' no longer supports the parameter 'EventHubEndpointName' and no alias was found for the original parameter name.
    - The parameter set '__AllParameterSets' for cmdlet 'Remove-AzIotHubEventHubConsumerGroup' has been removed.
    - The cmdlet 'Set-AzIotHub' no longer supports the parameter 'OperationsMonitoringProperties' and no alias was found for the original parameter name.
    - The parameter set 'UpdateOperationsMonitoringProperties' for cmdlet 'Set-AzIotHub' has been removed.

## Version 1.3.1
* Add new routing source: DigitalTwinChangeEvents
* Minor bug fix: Get-AzIothub not returning subscriptionId 

## Version 1.3.0
* Add support to invoke failover for an IotHub to the geo-paired disaster recovery region.
* Add support to manage message enrichment for an IotHub. New cmdlets are:
	- Add-AzIotHubMessageEnrichment
	- Get-AzIotHubMessageEnrichment
	- Remove-AzIotHubMessageEnrichment
	- Set-AzIotHubMessageEnrichment

## Version 1.2.1
* Fixed miscellaneous typos across module

## Version 1.2.0
* Add support to regenerate authorization policy keys.

## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.2
* Add Encoding format to Add-IotHubRoutingEndpoint cmdlet.

## Version 1.0.1
* Updated to the latest version of the IotHub SDK

## Version 1.0.0
* General availability of `Az.IotHub` module
