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
* The parameters of the `New-AzLoad` and `Update-AzLoad` cmdlets will be changed by new Managed Identity settings.
    - Removed `-IdentityType` parameters.
    - Changed `-UserAssignedIdentity` parameter type. The type of `UserAssignedIdentity` is simplified to a list of strings that is used to specify the user's assigned identity.
    - Added `EnableSystemAssignedIdentity` to enable/disable system-assigned identities.

## Version 1.1.0
* Upgraded nuget package to signed package.

## Version 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.0.0
* General availability of 'Az.LoadTesting' module

## Version 0.1.0
* First preview release for module Az.LoadTesting

