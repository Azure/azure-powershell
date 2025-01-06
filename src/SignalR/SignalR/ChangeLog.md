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
* Removed "Microsoft.Azure.Management.SignalR" Version "1.1.2-preview" PackageReference

## Version 2.0.2
* Fixed secrets exposure in example documentation.
* Improve the doc for `Test-AzSignalRName`.

## Version 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 2.0.0
* Breaking change:
    - Removed `HostNamePrefix` property of output type `PSSignalRResource` of following cmdlets:
        - `Get-AzSignalR`
        - `New-AzSignalR`
        - `Update-AzSignalR`

## Version 1.5.0
* Updated to API version 2022-08-01-preview
  - Added support for custom domain. Added new cmdlets New-AzWebPubSubCustomCertificate, Get-AzWebPubSubCustomCertificate, Remove-AzWebPubSubCustomCertificate, New-AzWebPubSubCustomDomain, Get-AzWebPubSubCustomDomain, Remove-AzWebPubSubCustomDomain.
  - Added support for event listeners in hub settings. Added new cmdlets New-AzWebPubSubEventHubEndpointObject, New-AzWebPubSubEventNameFilterObject.

## Version 1.4.1
* Fixed the bug of "Update-AzSignalR" cmdlet that resets the resource states by mistake.

## Version 1.4.0
* Added Web PubSub cmdlets
  - `New-AzWebPubSub`
  - `Get-AzWebPubSub`
  - `Update-AzWebPubSub`
  - `Restart-AzWebPubSub`
  - `Remove-AzWebPubSub`
  - `New-AzWebPubSubHub`
  - `Get-AzWebPubSubHub`
  - `Remove-AzWebPubSubHub`
  - `New-AzWebPubSubKey`
  - `Get-AzWebPubSubKey`
  - `Get-AzWebPubSubSku`
  - `Get-AzWebPubSubUsage`
  - `Test-AzWebPubSubNameAvailability`

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
