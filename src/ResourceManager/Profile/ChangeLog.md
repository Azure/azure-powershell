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

## Version 3.2.1
- Fix issue with non-interactive user authentication in RDFE (link)[https://github.com/Azure/azure-powershell/issues/4299]

## Version 3.2.0
* Fixed error when using Import-AzureRmContext or Save-AzureRmContext
    - More information can be found in this issue: https://github.com/Azure/azure-powershell/issues/3954

## Version 3.1.0
* Resolve-AzureRmError
  * New cmdlet to show details of errors and exceptions thrown by cmdlets, including server request/response data
* Send-Feedback
  * Enabled sending feedback without logging in
* Get-AzureRmSubscription
  * Fix bug in retrieving CSP subscriptions

## Version 3.0.1
* Add-AzureRmAccount
  * Added `-EnvironmentName` parameter alis for backward compatibility with 2.x versions of AzureRM.profile

## Version 3.0.0
* Added `Send-Feedback` cmdlet: allows a user to initiate a set of prompts which sends feedback to the Azure PowerShell team.
* The following aliases have been removed as they conflicted with existing cmdlet names in the Azure module:
    - `Enable-AzureDataCollection` (supported by `Enable-AzureRmDataCollection`)
    - `Disable-AzureDataCollection` (supported by `Disable-AzureRmDataCollection`)

## Version 2.8.0
* *Obsolete*: Save-AzureRmProfile is renamed to Save-AzureRmContext, there is an alias to the old cmdlet name, the alias will be removed in the next release.
* *Obsolete*: Select-AzureRmProfile is renamed to Import-AzureRmContext, there is an alias to the old cmdlet name, the alias will be removed in the next release.
* The PSAzureContext and PSAzureProfile output types of profile cmdlets will be changed in the next release.
* The Save-AzureRmContext cmdlet will have no OutputType in the next release.
* Fix bug in cmdlet common code to use FIPS-compliant algorithm for data hashes: https://github.com/Azure/azure-powershell/issues/3651 

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
* Add-AzureRmAccount
    - Add position for Credential parameter so the following command is allowed: Add-AzureRmAccount (Get-Credential)
    - Updated parameter sets so the SubscriptionId and SubscriptionName are mutually exclusive