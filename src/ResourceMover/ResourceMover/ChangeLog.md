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
* Introduced various new features by upgrading code generator. Please see details [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).
* The parameters of the `New-AzResourceMoverMoveCollection` and `New-AzResourceMoverMoveCollection` cmdlets will be changed by new Managed Identity settings.
    - Removed `-IdentityType` and `-IdentityUserAssignedIdentity` parameters.
    - Added `-UserAssignedIdentity` parameter. The type of `UserAssignedIdentity` is simplified to a list of strings that is used to specify the user's assigned identity.
    - Added `EnableSystemAssignedIdentity` to enable/disable system-assigned identities.

## Version 1.3.0
* Upgraded nuget package to signed package.

## Version 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.2.0
* Upgraded API version to 2023-08-01.
* Improved error reporting to the customer using custom cmdlets to handle the error in a better manner.

## Version 1.1.0
* Added support for Tags in azure resource mover
* Added support for SystemData in azure resource mover
* Released 2021-08-01 api-version

## Version 1.0.0
* General availability of 'Az.ResourceMover' module

## Version 0.2.0
* Added new cmdlets `Invoke-AzResourceMoverBulkRemove`, `Get-AzResourceMoverRequiredForResources`
* Added alias to `Add-AzResourceMoverMoveResource`: `Update-AzResourceMoverMoveResource`
* Flattened object "ResourceSettings"

## Version 0.1.0
* First preview release for module Az.ResourceMover

