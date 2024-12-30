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
* Removed "Microsoft.Azure.Management.IotHub" Version "4.2.0" PackageReference

## Version 2.7.7
* Fixed secrets exposure in example documentation.

## Version 2.7.6
* Removed the outdated deps.json file.

## Version 2.7.5
* Updated IoT Hub Management SDK to version 4.2.0 (api-version 2021-07-02)
* Fixed `Get-AzIoTHub` to work with DigiCert hubs

## Version 2.7.4
* Updated IoT Hub Management SDK to version 4.1.0 (api-version 2021-07-10)

## Version 2.7.3
* Updated IoT Hub Management SDK and models to version 3.0.0 (api-version 2020-03-01)

## Version 2.7.2
* Fixed a regression regarding SAS token generation

## Version 2.7.1
* Fixed an issue of SAS token.

## Version 2.7.0
* Allowed tags in IoT Hub create cmdlet.

## Version 2.6.0
* Updated devices sdk.

## Version 2.5.0
* Added cmdlet to invoke a query in an IoT hub to retrieve information using a SQL-like language.
* Fix issue that `Add-AzIotHubDevice` fails to create Edge Enabled Device without child devices [#11597]
* Added cmdlet to generate SAS token for Iot Hub, device or module.
* Added cmdlet to invoke configuration metrics query.
* Manage IoT Edge automatic deployment at scale. New cmdlets are:
    - `Add-AzIotHubDeployment`
    - `Get-AzIotHubDeployment`
    - `Remove-AzIotHubDeployment`
    - `Set-AzIotHubDeployment`
* Added cmdlet to invoke an IoT Edge deployment metrics query.
* Added cmdlet to apply the configuration content to the specified edge device.

## Version 2.4.0
* Manage IoT device twin configuration, New cmdlets are:
    - `Get-AzIotHubDeviceTwin`
    - `Update-AzIotHubDeviceTwin`
* Added cmdlet to invoke direct method on a device in an Iot Hub.
* Manage IoT device module twin configuration, New cmdlets are:
    - `Get-AzIotHubModuleTwin`
    - `Update-AzIotHubModuleTwin`
* Manage IoT automatic device management configuration at scale. New cmdlets are:
    - `Add-AzIotHubConfiguration`
    - `Get-AzIotHubConfiguration`
    - `Remove-AzIotHubConfiguration`
    - `Set-AzIotHubConfiguration`
* Added cmdlet to invoke an edge module method in an Iot Hub.

## Version 2.3.0
* Added support to manage distributed settings per-device. New Cmdlets are:
    - `Get-AzIotHubDistributedTracing`
    - `Set-AzIotHubDistributedTracing`

## Version 2.2.0
* Added support to manage devices in an Iot Hub. New Cmdlets are:
	- `Add-AzIotHubDevice`
	- `Get-AzIotHubDevice`
	- `Remove-AzIotHubDevice`
	- `Set-AzIotHubDevice`
* Added support to manage modules on a target Iot device in an Iot Hub. New Cmdlets are:
	- `Add-AzIotHubModule`
	- `Get-AzIotHubModule`
	- `Remove-AzIotHubModule`
	- `Set-AzIotHubModule`
* Added cmdlet to get the connection string of a target IoT device in an Iot Hub.
* Added cmdlet to get the connection string of a module on a target IoT device in an Iot Hub.
* Added support to get/set parent device of an IoT device. New Cmdlets are:
    - `Get-AzIotHubDeviceParent`
    - `Set-AzIotHubDeviceParent`
* Added support to manage device parent-child relationship.

## Version 2.1.0
* Added support to manage devices in an Iot Hub. New Cmdlets are:
	- `Add-AzIotHubDevice`
	- `Get-AzIotHubDevice`
	- `Remove-AzIotHubDevice`
	- `Set-AzIotHubDevice`

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
