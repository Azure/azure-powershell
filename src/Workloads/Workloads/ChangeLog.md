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
* The parameters of the `New-AzWorkloadsMonitor`, `New-AzWorkloadsProviderInstance` and `Update-AzWorkloadsMonitor` cmdlet will be changed by new Managed Identity settings.
    - Removed `-IdentityType` and `-IdentityUserAssignedIdentity` parameters.
    - Added `-UserAssignedIdentity` parameter. The type of `UserAssignedIdentity` is simplified to a list of strings that is used to specify the user's assigned identity.
    - Added `EnableSystemAssignedIdentity` to enable/disable system-assigned identities.

## Version 1.0.1
* Preannounced breaking changes. Please refer to https://go.microsoft.com/fwlink/?linkid=2333229

## Version 1.0.0
* General availability for module Az.Workloads
* Upgraded API version to 2024-09-01

## Version 0.4.0
* Upgraded nuget package to signed package.

## Version 0.3.0
* Split Az.Workloads into two sub-modules

## Version 0.2.1
* Fixed secrets exposure in example documentation.

## Version 0.2.0
* Added trusted access parameter in Create and Register VIS.

## Version 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.1.1
* Upgraded API version to 2023-10-01-preview

## Version 0.1.0
* First preview release for module Az.Workloads
