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
* Fixed the Managed Identity parameter set description of `AccountId` in `Connect-AzAccount`.
* Made the breaking change warnings about `Get-AzAccessToken` not appear when `-AsSecureString` is used.
* Fixed an issue that cmdlets may report warnings of "KeyNotFoundException". #26624
* Fixed an issue that the `-AppliesTo` parameter of `Update-AzConfig` does not work as expected.
* Upgraded Azure.Core to 1.44.1 and Azure.Identity to 1.13.0.
* Updated Azure PowerShell intercept survey prompt.

## Version 4.0.0
* [Breaking Change] Removed alias `Resolve-Error` for the cmdlet `Resolve-AzError`.
* Updated the `Get-AzAccessToken` breaking change warning message.
* Added Long Running Operation Support for Invoke-AzRest command.

## Version 3.0.5
* Fixed the issue that `Export-AzSshConfig` and `Enter-AzVM` from Az.Ssh are not able to use when WAM is enabled.
* Added breaking change preannouncement for the removal of alias `Resolve-Error`. #26189
* Integrated new detection library to expand the scope of secrets.

## Version 3.0.4
* Added customized UserAgent for ARM telemetry.
* Fixed secrets exposure in example documentation.
* Updated `Connect-AzAccount` to fix a display issue in PowerShell ISE [#24556].
* Updated the reference of Azure PowerShell Common to 1.3.100-preview.
* Used Azure.Identity and Azure.Core directly for client assertion [#22628].

## Version 3.0.3
* Reduced the frequency of displaying sign-in announcement messages.
* Upgraded Azure.Core to 1.41.0 to include the fix for `BearerTokenAuthenticationPolicy`
* Removed the informational table about selected context to avoid duplication with output table.

## Version 3.0.2
* Fixed bug handling GUID type subscription Id.
* Added a warning message in `Connect-AzAccount` to discourage the use of the username/password (a.k.a ROPC) login flow.
* Preannounced a breaking change in `Get-AzAccessToken` to change `Token` property from `String` to `SecureString`.

## Version 3.0.1
* Disable WAM when the customers login with device code flow or username password (ROPC) flow to prevent a potential issue with token cache.
* Fixed [CVE-2024-35255](https://github.com/advisories/GHSA-m5vv-6r4h-3vj9)
* Updated `Microsoft.Identity.Client.NativeInterop` to fix the WAM pop window issue in elevated mode [#24967]
* Updated the reference of Azure PowerShell Common to 1.3.98-preview.
* Limited promotional message to interactive scenarios only

## Version 3.0.0
* Web Account Manager (WAM) was set the default experience of interactive login. For more details please refer to https://go.microsoft.com/fwlink/?linkid=2272007
* Enabled secrets detection option by default.
* Fixed a null reference issue during the process of `Get-AzContext -ListAvailable` [#24854].
* Supported interactive subscription selection for user login flow. See more details at [Announcing a new login experience with Azure PowerShell and Azure CLI
](https://techcommunity.microsoft.com/t5/azure-tools-blog/announcing-a-new-login-experience-with-azure-powershell-and/ba-p/4109357)
* Added config `LoginExperienceV2` to allow customer to switch the default behavior of context selection back. Check the help document of `Update-AzConfig` for more details.
* Supported auto-discovery of the endpoint of OperationalInsights (azure-powershell-common/pull/414)
* Updated the reference of Azure PowerShell Common to 1.3.94-preview.
* [Breaking Change] Removed config `DisableErrorRecordsPersistence` to disable writing error records, error recording is now opt-in
* Added config `EnableErrorRecordsPersistence` to enable writing error records to file system

## Version 2.19.0
> [!IMPORTANT]
> Preannouncement: The default interactive login experience will change from browser based to `Web Account Manager` (WAM) based on supported platforms, [learn more](https://learn.microsoft.com/en-us/entra/msal/dotnet/acquiring-tokens/desktop-mobile/wam). Only interactive login flow is influeced by WAM. This will take effect from the release of **May 21st**.
* Fixed secrets detection issues.

## Version 2.17.0
* Enabled globally disabling instance discovery before token acquisition [#22535].
* Implemented secrets detection feature for autorest modules.
* Added `AsSecureString` to `Get-AzAccessToken` to convert the returned token to SecureString [#24190].
* Upgraded Azure.Core to 1.37.0.

## Version 2.16.0
* Added a preview feature to detect secrets and sensitive information from the output of Azure PowerShell cmdlets to prevent leakage. Enable it by `Set-AzConfig -DisplaySecretsWarning $true`. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844
* Fixed `CacheDirectory` and `CacheFile` out-of-sync issue in AzureRmContextSettings.json and the customers are not allowed to change these 2 properties.
* Redirected device code login messages from warning stream to information stream if use device authentication in `Connect-AzAccount`.

## Version 2.15.1
* Adjusted output format to be more user-friendly for `Get-AzContext/Tenant/Subscription` and `Invoke-AzRestMethod`, including
    - ordering and grouping output items to make items easy to find.
    - re-prioritizing positions for output properties to highlight valuable properties.
* Upgraded the reference of Azure PowerShell Common to 1.3.90-preview.
* Upgraded Azure.Identity to 1.10.3 [#23018].
  - Renamed token cache from `msal.cache` to `msal.cache.cae` or `masl.cache.nocae`.
* Enabled Continue Access Evaluation (CAE) for all Service Principals login methods.
* Supported signing in with Microsoft Account (MSA) via Web Account Manager (WAM). Enable it by `Set-AzConfig -EnableLoginByWam $true`.
* Fixed the multiple `x-ms-unique-id` values issue.

## Version 2.15.0
* Fixed the authentication issue when using `FederatedToken` in Sovereign Clouds. [#23742]
* Added upcoming breaking change warning for deprecation of config parameter `DisableErrorRecordsPersistence`.

## Version 2.13.2
* Enabled in-tool notification for version upgrade by default.
* Upgraded Azure.Core to 1.35.0.

## Version 2.13.1
* Added the module name in breaking change messages
* Upgraded Microsoft.ApplicationInsights version from 2.13.1 to 2.18.0

## Version 2.13.0
* Supported in-tool notification for version upgrade.
* Added an alias `Set-AzConfig` to `Update-AzConfig`
* Refilled credentials from `AzKeyStore` when run `Save-AzContext` [#22355]
* Added config `DisableErrorRecordsPersistence` to disable writing error records to file system [#21732]
* Updated Azure.Core to 1.34.0.

## Version 2.12.5
* Changed output stream from debug stream to warning stream for `CmdletPreviewAttribute`
* Decreased the prompted frequency of preview warning message to once per cmdlet in one session
* Reworded default preview message and added estimated GA date for `CmdletPreviewAttribute`
* Updated Azure.Core to 1.33.0

## Version 2.12.4
* Changed `gallery` property to be optional in ARM metadata of `Set-AzEnvironment` and `Add-AzEnvironment`[#22037].
* Enabled customers to login with an valid domain using Service Principal [#20728]

## Version 2.12.3
* Updated System.Security.Permissions to 4.7.0.

## Version 2.12.2
* Fixed `AzureSynapseAnalyticsEndpointResourceId` of `USGovernment` environment.
* Updated Azure.Core to 1.31.0.
* Updated the reference of Azure PowerShell Common to 1.3.75-preview.

## Version 2.12.1
* Fixed an issue that broke some cmdlets in Az.Synapse module.

## Version 2.12.0
* Fixed the issue that errors related to WAM are thrown when it is not enabled. [#20871] [#20824]
* Updated Azure.Core library to 1.28.0.
* Fixed an issue that the helper message about missing modules shows up at the wrong time. [#19228]
* Added a hint message for some resource creation cmdlets when there is another region which may reduce the costs.
* Supported environment initialization and auto-discovery with ArmMetadata of API version 2022-09-01.

## Version 2.11.2
* Supported Web Account Manager on ARM64-based Windows systems. Fixed an issue where `Connect-AzAccount` failed with error "Unable to load DLL 'msalruntime_arm64'". [#20700]
* Enabled credential to be found only by applicationId while tenant was not matched when acquire token. [#20484]
* When Az.Accounts ran in parallel, the waiters were allowed to wait infinitely to avoid throw exception in automation environment. [#20455]

## Version 2.11.1
* Fixed an issue where Az.Accounts cannot be imported correctly. [#20615]

## Version 2.11.0
* Supported Web Account Manager (WAM) as an opt-in interactive login experience. Enable it by `Update-AzConfig -EnableLoginByWam $true`.
* Optimized the mechanism for assembly loading.
* Enabled AzKeyStore with keyring in Linux.
* Fixed a typo in GetAzureRmContextAutosaveSetting.cs changing the cmdlet class name to GetAzureRmContextAutosaveSetting
* Removed survey on error message in `Resolve-AzError`. [#20398]

## Version 2.10.4
* Enabled caching tokens when logging in with a client assertion. This fixed the incorrectly short lifespan of tokens.
* Upgraded target framework of Microsoft.Identity.Client to net461 [#20189]
* Stored `ServicePrincipalSecret` and `CertificatePassword` into `AzKeyStore`.
* Updated the reference of Azure PowerShell Common to 1.3.67-preview.

## Version 2.10.3
* Updated `Get-AzSubscription` to retrieve subscription by Id rather than listed all the subscriptions from server if subscription Id is provided. [#19115]

## Version 2.10.2
* Upgraded Azure.Core to 1.25.0 and Azure.Identity to 1.6.1
* Upgraded Microsoft.Identity.Client to 4.46.2 and Microsoft.Identity.Client.Extensions.Msal to 2.23.0
* Upgraded Microsoft.ApplicationInsights to 2.13.1
* [Breaking Change] Changed target framework of AuthenticationAssemblyLoadContext to netcoreapp3.1.
* [Breaking Change] Removed built-in environment of Azure Germany
* Supported tenant domain as input while using `Connect-AzAccount` with parameter `Tenant`. [#19471]
* Used the ArgumentCompleter attribute to replace the dynamic parameters of `Get-AzContext`. [#18041]
* Fixed issue that module cannot be imported when required file is locked [#19624]

## Version 2.10.1
* Deduplicated subscriptions belonging to multiple tenants while using `Get-AzSubscription` with parameter `SubscriptionName`. [#19427]

## Version 2.10.0
* Supported returning all subscriptions with specified name while using `Get-AzSubscription` with parameter `SubscriptionName`. [#19295]
* Fixed null reference exception when cmdlet uses AzureRestOperation [#18104]
* Updated survey message and settings

## Version 2.9.1
* Implemented `SupportsShouldProcess` for `Invoke-AzRestMethod`
* Supported giving suggestions if an Azure PowerShell command cannot be found, for example when there is a typo in command name.

## Version 2.9.0
* Supported exporting and importing configurations by `Export-AzConfig` and `Import-AzConfig`.
* Fixed an issue that Az.Accounts may fail to be imported in parallel PowerShell processes. [#18321]
* Fixed incorrect access token [#18105]
* Upgraded version of Microsoft.Identity.Client for .NET Framework. [#18495]
* Fixed an issue that Az.Accounts failed to be imported if multiple environment variables, which only differ by case, are set. [#18304]

## Version 2.8.0
* Added a preview feature allowing user to control the following configurations by using `Get-AzConfig`, `Update-AzConfig` and `Clear-AzConfig`:
    - `DefaultSubscriptionForLogin`: Subscription name or GUID. Sets the default context for Azure PowerShell when logging in without specifying a subscription.
    - `DisplayBreakingChangeWarning`: Controls if warning messages for breaking changes are displayed or suppressed.
    - `EnableDataCollection`: When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the customer experience.
* Upgraded System.Reflection.DispatchProxy on Windows PowerShell [#17856]
* Upgraded Azure.Identity to 1.6.0 and Azure.Core to 1.24.0

## Version 2.7.6
* Upgraded Microsoft.Rest.ClientRuntime to 2.3.24

## Version 2.7.5
* Added `SshCredentialFactory` to support get ssh credential of vm from msal.
* Fixed the bug of cmdlet fails when -DefaultProfile is set to service principal login context. [#16617]
* Fixed the issue that authorization does not work in Dogfood environment

## Version 2.7.4
* Changed target framework of AuthenticationAssemblyLoadContext to netcoreapp2.1 [#17428]

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
* Add client-side telemetry info for Az 4.0 `preview`

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
