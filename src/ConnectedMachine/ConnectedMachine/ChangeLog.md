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

## Version 1.1.0
* Updated preview version api of HybridCompute to 2024-07-31

## Version 1.0.0
* General availability for module Az.ConnectedMachine

## Version 0.10.0
* Updated stable version api of HybridCompute to 2024-07-10

## Version 0.9.0
* Updated the API version to 2024-05-20-preview.

## Version 0.8.0
* Updated the API version to 2024-03-31-preview.
* Added cmdlets `Get-AzConnectedLicense`, `Get-AzConnectedNetworkSecurityPerimeterConfiguration`, `New-AzConnectedLicense`, `New-AzConnectedLicenseDetail`, `Remove-AzConnectedLicense` and `Set-AzConnectedLicense`.

## Version 0.7.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.7.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.7.0
* Added `ScriptLocalPath` to `New-AzConnectedMachineRunCommand` to let users add script files locally
* Added `MachineName` parameter to the McahineExtension and MachineRunCommand models

## Version 0.6.0
* This release, aimed at version 2023-10-03-preview of ConnectedMachine, introduces new commands alongside the existing ones
    - Get-AzConnectedMachineRunCommand: Retrieve run commands for an Azure Arc-Enabled Server
    - New-AzConnectedMachineRunCommand: Create a run command for an Azure Arc-Enabled Server
    - Remove-AzConnectedMachineRunCommand: Delete a run command for an Azure Arc-Enabled Server
    - Update-AzConnectedMachineRunCommand: Modify a run command for an Azure Arc-Enabled Server

## Version 0.5.2
* Removed the version check in MachineExtensionProperties

## Version 0.5.0
* Updated the API version to stable 2022-12-27
* Added cmdlet `Install-AzConnectedMachinePatch`, `Invoke-AzConnectedAssessMachinePatch` and `Get-AzConnectedExtensionMetadata`

## Version 0.4.1
* Fixed issue with Connect-AzConnectedMachine throwing errors when onboarding multiple machines at once

## Version 0.4.0
* Updated the API version to stable 2022-03-10
* Added cmdlet Update-AzConnectedMachine
* Added ResourceGroup to the display table
* Fixed the issue of extension settings not being able to serialize correctly
* Fixed issue with Connect-AzConnectedMachine throwing errors when onboarding multiple machines at once

## Version 0.3.0
* Upgraded API version to 2021-05-20
    - Added cmdlets for private link scope scenarios
        - `New-AzConnectedPrivateLinkScope`
        - `Get-AzConnectedPrivateLinkScope`
        - `Set-AzConnectedPrivateLinkScope`
        - `Remove-AzConnectedPrivateLinkScope`
        - `Update-AzConnectedPrivateLinkScopeTag`
    - Added cmdlets for extension upgrade
        - `Update-AzConnectedExtension`

## Version 0.2.0
* Bug fix

## Version 0.1.0
* First preview release for module Az.ConnectedMachine
