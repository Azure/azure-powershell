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
* Az.AppConfiguration module is migrated to Autorest PowerShell v4:
  * Modified cmdlet `Clear-AzAppConfigurationDeletedStore`: Added parameter `-LocationInputObject`. Added parameter set `PurgeViaIdentityLocation`.
  * Modified cmdlet `Get-AzAppConfigurationDeletedStore`: Added parameter `-LocationInputObject`. Added parameter set `GetViaIdentityLocation`.
  * Modified cmdlet `New-AzAppConfigurationStore`: Removed parameter `-IdentityType`. Added parameters `-InputObject`, `-EnableSystemAssignedIdentity`, `-JsonFilePath` and `-JsonString`. Changed the type of parameter `-CreateMode` from `CreateMode` to `String`. Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`. Added parameter set `CreateViaJsonString`. Added parameter set `CreateViaJsonFilePath`. Added parameter set `CreateExpanded`. Added parameter set `CreateViaIdentityExpanded`.
  * Modified cmdlet `New-AzAppConfigurationStoreKey`: Added parameters `-JsonFilePath` and `-JsonString`. Added parameter set `RegenerateViaJsonString`. Added parameter set `RegenerateViaJsonFilePath`.
  * Modified cmdlet `Test-AzAppConfigurationStoreNameAvailability`: Added parameters `-JsonFilePath` and `-JsonString`. Added parameter set `CheckExpanded`. Added parameter set `CheckViaJsonFilePath`. Added parameter set `CheckViaJsonString`.
  * Modified cmdlet `Update-AzAppConfigurationStore`: Removed parameter `-IdentityType`. Added parameters `-EnableSystemAssignedIdentity` and `-SoftDeleteRetentionInDay`. Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`. Parameter set `UpdateExpanded` removed parameter `-IdentityType`. Parameter set `UpdateExpanded` added parameter `-EnableSystemAssignedIdentity`. Parameter set `UpdateExpanded` added parameter `-SoftDeleteRetentionInDay`. Parameter set `UpdateViaIdentityExpanded` removed parameter `-IdentityType`. Parameter set `UpdateViaIdentityExpanded` added parameter `-EnableSystemAssignedIdentity`. Parameter set `UpdateViaIdentityExpanded` added parameter `-SoftDeleteRetentionInDay`.

## Version 1.4.1
* The code base is going to be refactored, the following cmdlet adds a BreakingChange announcement:
  * `Get-AzAppConfigurationStore`
  * `New-AzAppConfigurationStore`
  * `Update-AzAppConfigurationStore`

## Version 1.4.0
* Upgraded nuget package to signed package.

## Version 1.3.2
* Fixed secrets exposure in example documentation.

## Version 1.3.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.3.0
* Added cmdlets to support data plane operation:
  - `Get-AzAppConfigurationKey`
  - `Get-AzAppConfigurationKeyValue`
  - `Get-AzAppConfigurationLabel`
  - `Get-AzAppConfigurationRevision`
  - `Remove-AzAppConfigurationKeyValue`
  - `Remove-AzAppConfigurationLock`
  - `Set-AzAppConfigurationKeyValue`
  - `Set-AzAppConfigurationLock`
  - `Test-AzAppConfigurationKeyValue`

## Version 1.2.0
* Added cmdlets `Get-AzAppConfigurationDeletedStore` and `Clear-AzAppConfigurationDeletedStore`
* Updated ApiVersion to 2022-05-01.

## Version 1.1.0
* Added parameter "PublicNetworkAccess" in `New-AzAppConfigurationStore` and `Update-AzAppConfigurationStore`

## Version 1.0.0
* General availability of 'Az.AppConfiguration' module

## Version 0.2.0
* Supported customer-managed keys and configuration of managed identity.

## Version 0.1.4

## Version 0.1.3

## Version 0.1.2

## Version 0.1.1

## Version 0.1.0
* the first preview release
