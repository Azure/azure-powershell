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
* Fixed the bug of cmdlet fails when -DefaultProfile is set to service principal login context. [#16617]
* Fixed the issue that authorization does not work in Dogfood environment

## Version 2.7.3
* Fixed the issue that authorization does not work in customized environment [#17157]
* Enabled Continue Access Evaluation for MSGraph
* Improved error message when login is blocked by AAD
* Improved error message when silent reauthentication failed
* Loaded System.Private.ServiceModel and System.ServiceModel.Primitives on Windows PowerShell [#17087]

## Version 2.7.2
* Removed legacy assembly System.Private.ServiceModel and System.ServiceModel.Primitives [#16063]

## Version 2.7.1
* Copied `ServicePrincipalSecret` and `CertificatePassword` from Az.Accounts buildin profile to customer set profile. [#16617]
* Updated help message and help markdown for parameter `Tenant` of the cmdlet `Set-AzContext`. [#16515]
* Fixed the issue that Azure PowerShell could not work in a workflow. [#16408]
* Fixed the doubled Api Version in the URI of the underlying request issued by `Invoke-AzRestMethod`. [#16615]

## Version 2.7.0
* Removed `ServicePrincipalSecret` and `CertificatePassword` in `PSAzureRmAccount` [#15427]
* Added optional parameter `MicrosoftGraphAccessToken` to `Connect-AzAccount`
* Added optional parameters `MicrosoftGraphEndpointResourceId`, `MicrosoftGraphUrl` to `Add-AzEnvironment` and `Set-AzEnvironment`
* Added `-AccountId` property to `UserWithSubscriptionId` parameter set of `Connect-AzAccount` which allows a user name to be pre-selected for interactive logins
* Added `-Uri` and `-ResourceId` to `Invoke-AzRestMethod`
* Added Environment auto completer to the following cmdlets: Connect-AzAccount, Get-AzEnvironment, Set-AzEnvironment, and Remove-AzEnvironment [#15991]
* Added module name and version to User-Agent string [#16291]

## Version 2.6.2
* Upgraded Azure.Identity to 1.5.0

## Version 2.6.1
* Added new version of AAD service client using Microsoft Graph API

## Version 2.6.0
* Added `-FederatedToken` on `Connect-AzAccount`
* Updated Azure.Core from 1.19.0 to 1.20.0.

## Version 2.5.4
* Supported getting the access token for Microsoft Graph.
* Added AuthorizeRequestDelegate to allow service module to adjust token audience.
* Utilized [AssemblyLoadContext](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext) to resolve assembly conflict issues in PowerShell.
* Updated Azure.Core from 1.16.0 to 1.19.0.

## Version 2.5.3
* Corrected the URLs to Azure Portal in the results of `Get-AzEnvironment` and `Get-AzContext`. [#15429]
* Made infrastructural changes to support overriding default subscription via a `-SubscriptionId <String>` parameter.
    - [Az.Aks](https://docs.microsoft.com/powershell/module/az.aks/get-azakscluster) is the first module that supports it.

## Version 2.5.2
* Disabled context auto saving when token cache persistence fails on Windows and macOS
* Added PowerShell version into telemetry record
* Upgraded Microsoft.ApplicationInsights from 2.4.0 to 2.12.0
* Updated Azure.Core to 1.16.0

## Version 2.5.1
* Fixed access error when subscripiton has no `Tags` property [#15425].

## Version 2.5.0
* Added Tags, AuthorizationSource to PSAzureSusbscripiton and added TenantType, DefaultDomain, TenantBrandingLogoUrl, CountryCode to PSAzureTenant [#15220]
* Upgraded subscription client to 2021-01-01 [#15220]
* Removed Interactive mode check in common lib
* Added endpoint of OperationalInsights to environment AzureChinaCloud [#15305]
* Printed auto generated modules' default logs to verbose stream

## Version 2.4.0
* Added cmdlet `Open-AzSurveyLink`
* Supported certificate file as input parameter of Connect-AzAccount

## Version 2.3.0
* Upgraded Azure.Identity to 1.4 and MSAL to 4.30.1
* Removed obsolete parameters `ManagedServiceHostName`, `ManagedServicePort` and `ManagedServiceSecret` of cmdlet `Connect-AzAccount`, environment variables `MSI_ENDPOINT` and `MSI_SECRET` could be used instead
* Customized display format of PSAzureRmAccount to hide secret of service principal [#14208]
* Added optional parameter `AuthScope` to `Connect-AzAccount` to support enhanced authentication of data plane features
* Set retry times by environment variable [#14748]
* Supported subject name issuer authentication

## Version 2.2.8
* Fallback to first valid context if current default context key is "Default" which is invalid

## Version 2.2.7
* Fixed incorrect warning message on Windows PowerShell [#14556]
* Set Azure Environment variable `AzureKeyVaultServiceEndpointResourceId` according to the value of `AzureKeyVaultDnsSuffix` when discovering environment

## Version 2.2.6
* Upgrade Azure.Identity to fix the issue that Connect-AzAccount fails when ADFS credential is used [#13560]

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
