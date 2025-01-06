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
* Updated new property ResolutionPolicy to Get, New and Set virtual network link cmdlets.
* Created autorest generated sdk in PrivateDns.Management.Sdk folder

## Version 1.0.5
* Removed the outdated deps.json file.

## Version 1.0.4
* Removed length validation for DNS TXT record to make it consistent with Azure CLI and Azure portal.

## Version 1.0.3
* Corrected verbose output string formatting for Remove-AzPrivateDnsRecordSet

## Version 1.0.2
* Update references in .psd1 to use relative path

## Version 1.0.1
* Updated PrivateDns .net sdk to version 1.0.0

## Version 1.0.0
* 1.0.0 version released

## Version 0.1.3
* Added support for linking cross-tenant Vnets to Private DNS Zones

## Version 0.1.2
* Fixed miscellaneous typos across module

## Version 0.1.1
* Rename Update- cmdlets to Set-
	- Changed Update-AzPrivateDnsZone, Update-AzDrivateDnsVirtualNetworkLink, Update-AzPrivateDnsRecordSet cmdlets to Set-AzPrivateDnsZone, Set-AzDrivateDnsVirtualNetworkLink, Set-AzPrivateDnsRecordSet.
* Add warning for Private DNS zones ending with .local suffix

## Version 0.1.0
* General availability of `Az.PrivateDns` module
