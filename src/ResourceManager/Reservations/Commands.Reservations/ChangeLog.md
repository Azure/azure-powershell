
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

## Version 0.1.6
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.1.5
* Updated help files to include full parameter types and correct input/output types.

## Version 0.1.4
* Updated to the latest .NET SDK version 1.8.0-preview
* Updated Cmdlet Get-AzureRmReservationCatalog
    - Added parameters ReservedResourceType and Location.
    - Removed Size and Tier from Catalog response.
    - Renamed Capabilities to SkuProperties in Catalog response.
* Updated Cmdlet Update-AzureRmReservation
    - Added optional InstanceFlexibility parameter.
* Added properties to Reservation response.
* Fixed formatting of OutputType in help files

## Version 0.1.3
* Change Guid paramters to Guid type, not string
* Set minimum dependency of module to PowerShell 5.0

## Version 0.1.2
* Updated to the latest version of the Azure ClientRuntime

## Version 0.1.1
* New Cmdlet Get-AzureRmReservationOrder
    - cmdlet to retrieve azure reservation order.
* New Cmdlet Get-AzureRmReservation
    - cmdlet to retrieve azure reservation within specified reservation order.
* New Cmdlet Get-AzureRmReservationHistory
    - cmdlet to retrieve revision history of a reservation.
* New Cmdlet Update-AzureRmReservation
    - cmdlet to update applied scope of a reservation.
* New Cmdlet Merge-AzureRmReservation
    - cmdlet to merge two reservations into one reservation.
* New Cmdlet Split-AzureRmReservation
    - cmdlet to split a reservation into two reservations with specified quantity.
* New Cmdlet Get-AzureRmReservationOrderId
    - cmdlet to retrieve list of reservation order ids that are applicable to subscription.
* New Cmdlet Get-AzureRmReservationCatalog
    - cmdlet to retrieve available reservation catalog for the subscription.
* Enable subscription Auto-Registration for the reservations provider

## Version 0.1.0
* Initial Release of Resrvations cmdlets
