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

## Version 2.2.5
* Tracked CloudError code in exception
* Raised 'ContextCleared' event when `Clear-AzContext` was executed

## Version 2.2.4
* Shown correct client request id on debug message [#13745]
* Added common Azure PowerShell exception type
* Supported storage API 2019-06-01

## Version 2.2.3
* Fixed the issue that Http proxy is not respected in Windows PowerShell [#13647]
* Improved debug log of long running operations in generated modules

## Version 2.2.2
* Managed to parse ExpiresOn time from raw token if could not get from underlying library
* Improved warning message if Interactive authentication is unavailable

## Version 2.2.1
* Fixed the issue that using Task.Result incorrectly causes unclear error message if browser is not available for Interactive auth

## Version 2.2.0
* Fixed an issue that TenantId may be not respected if using `Connect-AzAccount -DeviceCode`[#13477]
* Added new cmdlet `Get-AzAccessToken`
* Fixed an issue that error happens if user profile path is inaccessible
* Fixed an issue causing Write-Object error during Connect-AzAccount [#13419]
* Added parameter "ContainerRegistryEndpointSuffix" to: `Add-AzEnvironment`, `Set-AzEnvironment` 
* Supported interrupting login by hitting <kbd>CTRL</kbd>+<kbd>C</kbd>
* Fixed an issue causing `Connect-AzAccount -KeyVaultAccessToken` not working [#13127]
* Fixed null reference and method case insensitive in `Invoke-AzRestMethod`

## Version 2.1.2
* Fixed one issue related to MSI

## Version 2.1.1
* Fixed the issue that token is not renewed after expiring for LRO [#13367]
* Fixed the issue that AccountId is not respected in MSI [#13376]
* Fixed the issue that error message is unclear if browser is not avaialable for Interactive auth [#13340]

## Version 2.1.0
* [Breaking Change] Removed `Get-AzProfile` and `Select-AzProfile`
* Replaced Azure Directory Authentication Library with Microsoft Authentication Library(MSAL)

## Version 1.9.5
* Fixed DateTime parse issue in common libraries [#13045]

## Version 1.9.4
* Formatted the upcoming breaking change messages
* Updated Azure.Core to 1.4.1

## Version 1.9.3
* Loaded all public cloud environments when discovery endpoint doesn't return default AzureCloud or other public environments [#12633]
* Exposed SubscriptionPolicies in `Get-AzSubscription` [#12551]

## Version 1.9.2
* Updated `Connect-AzAccount` to accept parameter `MaxContextPopulation` [#9865]
* Updated SubscriptionClient version to 2019-06-01 and display tenant domains [#9838]
* Supported home tenant and managedBy tenant information of subscription
* Corrected module name, version info in telemetry data
* Adjusted SqlDatabaseDnsSuffix and ServiceManagementUrl if environment metadata endpoint returns incompatible value

## Version 1.9.1
* Added new cmdlet `Invoke-AzRestMethod`
* Fixed an issue that may cause authentication errors in multi-process scenarios such as running multiple Azure PowerShell cmdlets using `Start-Job` [#9448]

## Version 1.9.0
* Supported discovering environment setting by default and adding environment via `Add-AzEnvironment`
* Update preloaded assemblies [#12024], [#11976]
* Updated Azure.Core assembly
* Fixed an issue that may cause `Connect-AzAccount` to fail in multi-threaded execution [#11201]

## Version 1.8.1
* Fixed an issue that may cause Az to skip logs in Azure Automation or PowerShell jobs [#11492]

## Version 1.8.0
* Updated `Add-AzEnvironment` and `Set-AzEnvironment` to accept parameters `AzureSynapseAnalyticsEndpointResourceId` and `AzureSynapseAnalyticsEndpointSuffix`
* Added Azure.Core related assemblies into Az.Accounts, supported PowerShell platforms include Windows PowerShell 5.1, PowerShell Core 6.2.4, PowerShell 7+

## Version 1.7.5
* Updated Azure PowerShell survey URL in `Resolve-AzError` [#11507]

## Version 1.7.4
* Fixed `Get-AzTenant`/`Get-AzDefault`/`Set-AzDefault` throw NullReferenceException when not login [#10292]

## Version 1.7.3
* Open Azure PowerShell survey page in `Send-Feedback` [#11020]
* Display Azure PowerShell survey URL in `Resolve-Error` [#11021]
* Added Az version in UserAgent

## Version 1.7.2
* Added SubscriptionId, TenantId, and execution time into data of client side telemetry

## Version 1.7.1
* Disable context auto saving when AzureRmContext.json not available
* Update the reference to Azure Powershell Common to 1.3.5-preview

## Version 1.7.0
* Updated Add-AzEnvironment and Set-AzEnvironment to accept parameters AzureAttestationServiceEndpointResourceId and AzureAttestationServiceEndpointSuffix

## Version 1.6.6
* Add client-side telemetry info for Az 4.0 preview

## Version 1.6.5
* Update references in .psd1 to use relative path
* Set correct UserAgent for client-side telemetry for Az 4.0 preview
* Display user friendly error message when context is null in Az 4.0
* Add endpoints for attestation service

## Version 1.6.4
* Add a deprecation message for `Resolve-Error` alias.

## Version 1.6.3
* Update telemetry and url rewriting for generated modules, fix windows unit tests.

## Version 1.6.2
* Fixed miscellaneous typos across module
* Support user-assigned MSI in Azure Functions Authentication (#9479)

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
