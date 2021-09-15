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

## Version 1.3.0
* Changed to `Allow` and `Deny` parameters of `Update-AzSignalRNetworkAcl` cmdlet:
    - Accepted `Trace` as a valid value.
    - Accepted `@()` as empty collection to clear the list.
* Supported `ResourceGroupCompleter` and `ResourceNameCompleter` in the applicable cmdlets.
* Deprecated the `HostNamePrefix` property of output type `PSSignalRResource` of following cmdlets:
    - `Get-AzSignalR`
    - `New-AzSignalR`
    - `Update-AzSignalR`

## Version 1.2.0
* Fixed `Restart-AzSignalR` and `Update-AzSignalR` help files errors
* Added cmdlets `Update-AzSignalRNetworkAcl`, `Set-AzSignalRUpstream`

## Version 1.1.1
* Update references in .psd1 to use relative path

## Version 1.1.0
* Add Update, Restart, CheckNameAvailability, GetUsage Cmdlets

## Version 1.0.3
* Fixed miscellaneous typos across module

## Version 1.0.2
* Update incorrect online help URLs

## Version 1.0.1
* Fix backward compatibility issue with Az.Accounts module

## Version 1.0.0
* General availability of `Az.SignalR` module
