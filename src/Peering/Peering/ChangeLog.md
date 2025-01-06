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

## Version 0.4.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.4.0
* Supports API Version 2022-10-01 stable

## Version 0.3.1
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## Version 0.3.0
* Added support for cdn peering prefixes

## Version 0.2.0
* Adding support for Received routes

## Version 0.1.9
* Adding support for Received routes

## Version 0.1.8
* Adding support for Peering Registered Prefix
* Adding support for Peering Registered ASN
* Adding filter to Legacy Peering
* Adding filter to Peering Service Countries
* Adding contact details to peer asn
* Bug fixes

## Version 0.1.7
* Update references in .psd1 to use relative path

## Version 0.1.6
* Fixed bug in Peering location 
* Added tests to direct connection

## Version 0.1.5
* Added Peering Service events
* Removed UseForPeeringService at the Peering level
* Updated to SDK 1.0.1-preview
* Supports API Version 2019-09-01-preview

## Version 0.1.4
* Added Peering Service Operations
* Updated Documentation
* Updated to SDK 1.0.0-preview
* Supports API Version 2019-08-01-preview

## Version 0.1.3
* Bug fix in set connection for exchange that caused CDIR notation
* Allowed adding connections during legacy convert
* Added tests for set Exchange operations
* Bug fix in set connection
* Added Connection Identifier to Connection object.
* Updated to SDK 0.10.0-preview
* Supports api-version 06-01-2019-preview for Microsoft.Peering
* Fixed miscellaneous typos across module

## Version 0.1.2
* Bug fix in IP Prefix validation to allow 0/30 for DirectConnection
* Bug fix to handle error messages from ARM and ERM
* Added Verbose comments for debugging
## Version 0.1.1
* Update version of AutoMapper library used
* Fix case sensitivity bug in `Get-AzPeeringLocation` for `-Kind` parameter
## Version 0.1.0
* Preview release for Microsoft Peering Service module
