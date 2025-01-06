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
* Added list of allowed classifications in description for Maintenance Configuration
* Fixed incorrect parameter mapping in Get-AzApplyUpdate

## Version 1.4.3
* Fixed bug where AzMaintenanceConfiguration returned a List object. [#25781]

## Version 1.4.2
* Fixed bug where rebootSettings property wasn't updating.

## Version 1.4.1
* Removed outdated upcoming breaking change warning

## Version 1.4.0
* Added support for maintenance configuration cancellation.

## Version 1.3.1
* Fixed breaking change information

## Version 1.3.0
* Added support for Resource Group and Subscription configuration assignment.

## Version 1.2.1
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## Version 1.2.0
* Added Guest patch maintenance support.

## Version 1.1.1
* Bumped API version to stable 2021-05-01.

## Version 1.1.0
* Added optional schedule related fields to `New-AzMaintenanceConfiguration`
* Added new cmdlet for `Get-AzMaintenancePublicConfiguration`

## Version 1.0.0
* Publishing release version of Maintenance cmdlets for GA

## Version 0.1.3
* Got `Az-MaintenanceConfiguration` will honor filters while listing maintenance configurations

## Version 0.1.2
* Update command will display pending updates by default
* Added sample output to help documentation of Get-AZMaintenanceUpdate

## Version 0.1.1
* Preview release of `Az.Maintenance` module

## Version 0.1.0
