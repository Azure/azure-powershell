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

## Version 2.0.0
* Improved user experience and consistency. This may introduce breaking changes. Please refer to [here](https://go.microsoft.com/fwlink/?linkid=2340249).
* The parameters of the `New-AzNginxDeployment` and `Update-AzNginxDeployment` cmdlets will be changed by new Managed Identity settings.

## Version 1.2.1
* Added breaking change announcement for below cmdlets from fixed array to list.
  - `Get-AzNginxConfiguration`
  - `New-AzNginxConfiguration`
  - `Get-AzNginxDeployment`
  - `New-AzNginxDeployment`
  - `Update-AzNginxDeployment`
  - `Invoke-AzNginxAnalysisConfiguration`
  - `New-AzNginxNetworkProfileObject`
* Added breaking change announcement for `New-AzNginxDeployment` and `Update-AzNginxDeployment` cmdlets.
    - Removed `-IdentityType` parameter to support new Managed Identity settings.
    - Removed `-IdentityUserAssignedIdentity`.
* The parameters of the `New-AzNginxDeployment` and `Update-AzNginxDeployment` cmdlets will be changed by new Managed Identity settings.
    - Added `-UserAssignedIdentity` parameter. The type of `UserAssignedIdentity` is simplified to a list of strings that is used to specify the user's assigned identity.
    - Added `EnableSystemAssignedIdentity` to enable/disable system-assigned identities.

## Version 1.2.0
* Upgraded nuget package to signed package.

## Version 1.1.0
* Added feature for auto scaling and upgradeprofile, and nginx configuration analysis

## Version 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.0.0
* General availability of 'Az.Nginx' module

## Version 0.1.0
* First preview release for module Az.Nginx
