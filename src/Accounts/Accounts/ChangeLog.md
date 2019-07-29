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
* Fixed miscellaneous typos across module

## Version 1.6.1
* Update common code to use latest version of ClientRuntime

## Version 1.6.0
* Add support for profile cmdlets
* Add support for environments and data planes in generated cmdlets
* Update common packages to include new PolicyInsights library * Fix bug where incorrect endpoint was being used in some cases for data plane cmdlets in Windows PowerShell

## Version 1.5.3
* Fix bug with incorrect URL being used in some cases for Functions calls
    - More information here: https://github.com/Azure/azure-powershell/issues/8983
* Fix Issue with aliases from AzureRM to Az cmdlets
  - Set-AzureRmVMBootDiagnostics -> Set-AzVMBootDiagnostic
  - Export-AzureRMLogAnalyticThrottledRequests -> Export-AzLogAnalyticThrottledRequest

## Version 1.5.2
* Update Authentication Library to fix ADFS issues with username/password auth

## Version 1.5.1
* Update Uninstall-AzureRm to correctly delete modules in Mac

## Version 1.5.0
* Updated Add-AzEnvironment and Set-AzEnvironment to accept parameter AzureAnalysisServicesEndpointResourceId

## Version 1.4.0
* Add 'Register-AzModule' command to support AutoRest generated cmdlets
* Update examples for Connect-AzAccount

## Version 1.3.1
* Add additional framework extensions for .Net Framework execution
* Update common packages to include new wildcard support functions

## Version 1.3.0
* Update to latest version of ClientRuntime

## Version 1.2.1
* Release with correct version of Authentication
* Enable MSI Authentication in Azure Functions and WebApps

## Version 1.2.0
* Add interactive and username/password authentication for Windows PowerShell 5.1 only
* Update incorrect online help URLs
* Add warning message in PS Core for Uninstall-AzureRm

## Version 1.1.0
* Add 'Local' Scope to Enable-AzureRmAlias
* Bug fix for missing path in Uninstall-AzureRm

## Version 1.0.0
* General availability of `Az.Accounts` module
