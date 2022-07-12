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

## Version 0.4.0
* Updated the API version to stable 2022-03-10
* Added cmdlet Update-AzConnectedMachine
* Added ResourceGroup to the display table
* Fixed the issue of extension settings not being able to serialize correctly

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
