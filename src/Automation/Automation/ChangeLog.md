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

## Version 1.10.0
* Updated Module operation cmdlets to support Powershell 7.2

## Version 1.9.1
* Fixed bug: Runbooks Name Pattern failures. 

## Version 1.9.0
* Updated Example: Start-AzAutomationRunbook should pass ordered dictionary for parameters [#20408]

## Version 1.8.0
* Added cmdlets for Hybrid Runbook Worker group management
  * `Remove-AzAutomationHybridRunbookWorker`
  * `Remove-AzAutomationHybridRunbookWorkerGroup`
  * `Set-AzAutomationHybridRunbookWorkerGroup`
  * `Get-AzAutomationHybridRunbookWorker`
  * `Get-AzAutomationHybridRunbookWorkerGroup`
  * `Move-AzAutomationHybridRunbookWorker`
  * `New-AzAutomationHybridRunbookWorker`
  * `New-AzAutomationHybridRunbookWorkerGroup`

## Version 1.7.4
* Fixed bug: Export-AzAutomationRunbook no longer adds extra '\' to file names [#11101]
* Fixed bug: Get-AzAutomationDscCompilationJobOutput returns complete summaries [#12322]
* Fixed bug: Get-AzAutomationDscNode [#10404]
* Fixed bug: Get-AzAutomationJob fails for some jobIds

## Version *
* Added logic of returning error if insufficient user permissions are there for `GetAgentRegistrationInfo`

## Version 1.7.3
* `New-AzAutomationSchedule` allows defnining StartTime with offsets.
*  Fixed bug: updated 'Set-AzAutomationModule' to use PUT call while updating modules with specific versions   [#12552]

## Version 1.7.2
* Fixed example in reference doc for `Remove-AzAutomationHybridWorkerGroup`

## Version 1.7.1
* Fixed bug: Add Schedule name validation in New-AzAutomationSchedule

## Version 1.7.1
* Fixed bug: Closing in input file handle in Import-AzAutomationRunbook

## Version 1.7.0
* Added support for User Assigned Identities and PublicNetworkAccess flag

## Version 1.6.0
* Added support for Customer Managed Key Encryption with System Assigned Identity
* Fixed issue that disables the schedule for update deployment if schedule was re-created with same name

## Version 1.5.2
* Fixed the issue for starting Python3 runbooks with parameters
* Fixed time zone issue while creating an update deployment schedule.

## Version 1.5.1
* Fixed te issue that complex object cannot be serialized correctly. [#14431]

## Version 1.5.0
* Fixed the issue that string cannot be serialized correctly. [#14215]
* Added Support for Python3 Runbook Type

## Version 1.4.3
* Fixed the issue of processing `PSCustomObject` and `Array`.

## Version 1.4.2
* Fixed issue where description was not populated for update management schedules

## Version 1.4.1
* Fixed issue that parameters of `Start-AzAutomationRunbook` cannot convert PSObject wrapped string to JSON string [#13240]
* Fixed location completer for New-AzAutomationUpdateManagementAzureQuery cmdlet

## Version 1.4.0
* Added `-RunOn` parameters to `Set-AzAutomationWebhook` to specify a Hybrid Worker Group

## Version 1.3.7
* Fixed the issue that string with escape chars cannot be converted into json object.

## Version 1.3.6
* Fixed typo in Example 1 in reference documentation for `New-AzAutomationSoftwareUpdateConfiguration`

## Version 1.3.5
* Update references in .psd1 to use relative path

## Version 1.3.4

* Fixed New-AzureAutomationSoftwareUpdateConfiguration cmdlet for Linux reboot setting parameter. 

## Version 1.3.3
* Fixed example typo in reference documentation for `Register-AzAutomationDscNode`
* Added clarification on OS restriction to Register-AzAutomationDSCNode
* Fixed Start-AzAutomationRunbook cmdlet Null reference exception for -Wait option.

## Version 1.3.2
* Fixed miscellaneous typos across module

## Version 1.3.1
* Fix typo in resource string

## Version 1.3.0
* Fixed Set-AzAutomationConnectionFieldValue cmdlet bug to handle string value.
* Added text to description for Register-AzAutomationDscNode to explain cross-sub

## Version 1.2.2
* Updated Get-AzAutomationJobOutputRecord to handle JSON and Text record values.
    - Fix for issue https://github.com/Azure/azure-powershell/issues/7977
    - Fix for issue https://github.com/Azure/azure-powershell/issues/8600
* Bug fix for NewAZAutomationUpdateManagementAzureQuery
* Changed behavior for Start-AzAutomationDscCompilationJob to just start the job instead of waiting for its completion.
    * Fix for issue https://github.com/Azure/azure-powershell/issues/8347
* Fix for Get-AzAutomationDscNode when using -Name returns all node. Now it returns matching node only.
* Fixed Start-AzAutomationDscNodeConfigurationDeployment cmdlet to allow multiple executions

## Version 1.2.1
* Fixed New-AzAutomationSoftwareUpdateConfiguration cmdlet bug for Inclusions. Now parameter IncludedKbNumber and IncludedPackageNameMask should work.
* Bug fix for azure automation update management dynamic group

## Version 1.2.0
* Azure automation update management change to support the following new features :
    * Dynamic grouping
    * Pre-Post script
    * Reboot Setting

## Version 1.1.2
* Fixed issue when retreiving certain monthly schedules in several Azure Automation cmdlets
* Fix Get-AzAutomationDscNode returning just top 20 nodes. Now it returns all nodes

## Version 1.1.1
* Update help for Import-AzAutomationDscNodeConfiguration
* Added configuration name validation to Import-AzAutomationDscConfiguration cmdlet
* Improved error handling for Import-AzAutomationDscConfiguration cmdlet

## Version 1.1.0
* Added support for Python 2 runbooks
* Update incorrect online help URLs

## Version 1.0.0
* General availability of `Az.Automation` module
