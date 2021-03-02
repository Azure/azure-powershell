<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release

## Version 5.8.4
* This module is outdated and will go out of support on 29 February 2024.
* The Az.Profile module has all the capabilities of AzureRM.Profile and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 5.8.3
* Bug Fix for TokenCache initialization when importing a context

## Version 5.8.1
* Update common code to use latest version of ClientRuntime

## Version 5.8.0
* Update common code to use latest version of ClientRuntime
* Rename param TenantId in cmdlet Connect-AzureRmAccount to Tenant and add an alias for TenantId
* Updated TenantId description for Connect-AzureRmAccount
* Fix error message for failed login when providing tenant domain
    - https://github.com/Azure/azure-powershell/issues/6936
* Fix issue with context name clashing for accounts with no subscriptions in tenant
    - https://github.com/Azure/azure-powershell/issues/7453
* Fix issue with DataLake endpoints when using MSI
    - https://github.com/Azure/azure-powershell/issues/7462
* Fix issue where `Disconnect-AzureRmAccount` would throw if not connected
    - https://github.com/Azure/azure-powershell/issues/7167

## Version 5.7.0
* Fix issue with Get-AzureRmSubscription in CloudShell
* Update common code to use latest version of ClientRuntime

## Version 5.6.0
* Minor changes to the storage common code
* Updated help files to include full parameter types.
- Changed -ServicePrincipal to non-mandatory in the ServicePrincipalCertificateWithSubscriptionId parameter set

## Version 5.5.1
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 5.5.0
* Added expiration property to tokens returned during Connect-AzureRmAccount

## Version 5.4.0
* Updated to the latest version of the Azure ClientRuntime.
* Add user id to default context name to avoid context clashing
    - https://github.com/Azure/azure-powershell/issues/6489
* Fix issues with Clear-AzureRmContext that caused issues with selecting a context #6398
* Enable tenant domain to be passed to `-TenantId` parameter for `Connect-AzureRmAccount`
    - https://github.com/Azure/azure-powershell/issues/3974
    - https://github.com/Azure/azure-powershell/issues/6709

## Version 5.3.4
* Updated Common.Strategy library to be able to validate that the current config for a resource is compatible with the target resource. Default is always true, individual resources and overridet the default.
* Updated all help files to include full parameter types and correct input/output types.
* Added ps1xml types to Common.Storage

## Version 5.3.3
* Updated help for `Get-AzureRmContextAutosaveSetting`

## Version 5.3.2
* Common code changes to enable cmdlets to request an Auxilary Auth header with tokens for multiple tenants given a list of resource IDs.

## Version 5.3.1
* Fixed formatting of OutputType in help files
* Ps1Xml attribute added to the basic output types

## Version 5.3.0
* Updated error messages for Enable-AzureRmContextAutoSave
* Create a context for each subscription when running `Connect-AzureRmAccount` with no previous context
* Extracted ARM sdk to common library to be reused by AzureRM.DevSpaces and AzureRM.AKS

## Version 5.2.0
* Added the following three values to the telemetry:
  - Inner exception types
  - ParameterSetName
  - InvocationName
* Fix issue where version 10.0.3 of Newtonsoft.Json wasn't being loaded on module import
* Retry TaskCanceledException appropriately when connections are left open.

## Version 5.1.0
* Fix issue where running `Clear-AzureRmContext` would keep an empty context with the name of the previous default context, which prevented the user from creating a new context with the old name

## Version 5.0.1
* Fix issue where default environments weren''t being retrieved without a default context set

## Version 5.0.0
* Set minimum dependency of module to PowerShell 5.0
* Enable context autosave by default
* Add USGovernmentOperationalInsightsEndpoint and USGovernmentOperationalInsightsEndpointResourceId properties to Azure environment for US Gov.

## Version 4.6.0
* Updated to the latest version of the Azure ClientRuntime

## Version 4.5.0
* Enable MSI authentication in unsupported scenarios
* Add support for user-defined Managed Service Identity

## Version 4.4.0
* Fixed issue with importing aliases
* Load version 10.0.3 of Newtonsoft.Json side-by-side with version 6.0.8

## Version 4.3.1
* Fix concurrent module import issue in PowerShell Workflow and Azure Automation

## Version 4.3.0
* Added deprecation warning for PowerShell 3 and 4
* 'Add-AzureRmAccount' has been renamed as 'Connect-AzureRmAccount'; an alias has been added for the old cmdlet name, and other aliases ('Login-AzAccount' and 'Login-AzureRmAccount') have been redirected to the new cmdlet name.
* 'Remove-AzureRmAccount' has been renamed as 'Disconnect-AzureRmAccount'; an alias has been added for the old cmdlet name, and other aliases ('Logout-AzAccount' and 'Logout-AzureRmAccount') have been redirected to the new cmdlet name.
* Corrected Resource Strings to use Connect-AzureRmAccount instead of Login-AzureRmAccount
* Add-AzureRmEnvironment and Set-AzureRmEnvironment
  - Added -AzureOperationalInsightsEndpoint and -AzureOperationalInsightsEndpointResourceId as parameters for use with OperationalInsights data plane RP.

## Version 4.2.0
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Add-AzureRmAccount
  * Added -MSI login for authenticationg using the credentials of the Managed Service Identity of the current VM / Service
  * Fixed KeyVault Authentication when logging in with user-provided access tokens

## Version 4.1.1
- Updated USGovernmentActiveDirectoryEndpoint to https://login.microsoftonline.us/
    - For more information about the Azure Government endpoint mappings, please see the following: https://docs.microsoft.com/en-us/azure/azure-government/documentation-government-developer-guide#endpoint-mapping
- Added -AsJob support for cmdlets, enabling selected cmdlets to execute in the background and return a job to track and control progress
- Added -AsJob parameter to Get-AzureRmSubscription cmdlet

## Version 4.0.0
- Set-AzureRmDefault
    - Use this cmdlet to set a default resource group.  This will make the -ResourceGroup parameter optional for some cmdlets, and will use the default when a resource group is not specified
    - ```Set-AzureRmDefault -ResourceGroupName "ExampleResourceGroup"```
    - If resource group specified exists in the subscription, this resource group will be set to default.  Otherwise, the resource group will be created and then set to default.
- Get-AzureRmDefault
    - Use this cmdlet to get the current default resource group (and other defaults in the future).
    - ```Get-AzureRmDefault -ResourceGroup```
- Clear-AzureRmDefault
    - Use this cmdlet to remove the current default resource group
    - ```Clear-AzureRmDefault -ResourceGroup```
- Add-AzureRmEnvironment and Set-AzureRmEnvironment
    - Add the BatchAudience parameter, which allows you to specify the Azure Batch Active Directory audience to use when acquiring authentication tokens for the Batch service.
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1
* LocationCompleterAttribute added and available for cmdlets which use the -Location parameter
    - Use this feature by adding LocationCompleter(string[] validResourceTypes) onto the Location parameter

## Version 3.4.0
* Start-Job Support for AzureRm cmdlets.
    * All AzureRmCmdlets add -AzureRmContext parameter, which can accept a context (output of a Context cmdlet).
      - Common pattern for jobs with context persistence DISABLED: ```Start-Job {param ($context) New-AzureRmVM -AzureRmContext $context [... other parameters]} -ArgumentList (Get-AzureRmContext)```
      - Common pattern for jobs with context persistence ENABLED:```Start-Job {New-AzureRmVM [... other parameters]}```
    * Persist login information across sessions, new cmdlets:
      - Enable-AzureRmContextAutosave - Enable login persistence across sessions.
      - Disable-AzureRmContextAutosave - Disable login persistence across sessions.
    * Manage context information, new cmdets
      - Select-AzureRmContext - Select the active named context.
      - Rename-AzureRmContext - Rename an exsiting context for easy reference.
      - Remove-AzureRmContext - Remove an existing context.
      - Remove-AzureRmAccount - Remove all credentials, subscriptions, and tenants associated with an account.
    * Manage context information, cmdlet changes:
      - Added Scope = (Process | CurrentUser) to all cmdlets that change credentials
      - Get-AzureRmContext - Added ListAvailable parameter to list all saved contexts

## Version 3.3.1

## Version 3.3.0
- Data collection has been enabled by default. Usage data is collected by Microsoft in order to improve the user experience. The data is anonymous and does not include command-line argument values.
    - Use the Disable-AzureRmDataCollection cmdlet to turn the feature off
    - Use the Enable-AzureRmDataCollection cmdlet to turn this feature on

## Version 3.2.1
- Fix issue with non-interactive user authentication in RDFE (link)[https://github.com/Azure/azure-powershell/issues/4299]

## Version 3.2.0
* Fixed error when using Import-AzureRmContext or Save-AzureRmContext
    - More information can be found in this issue: https://github.com/Azure/azure-powershell/issues/3954

## Version 3.1.0
* Resolve-AzureRmError
  * New cmdlet to show details of errors and exceptions thrown by cmdlets, including server request/response data
* Send-Feedback
  * Enabled sending feedback without logging in
* Get-AzureRmSubscription
  * Fix bug in retrieving CSP subscriptions

## Version 3.0.1
* Add-AzureRmAccount
  * Added `-EnvironmentName` parameter alis for backward compatibility with 2.x versions of AzureRM.profile

## Version 3.0.0
* Added `Send-Feedback` cmdlet: allows a user to initiate a set of prompts which sends feedback to the Azure PowerShell team.
* The following aliases have been removed as they conflicted with existing cmdlet names in the Azure module:
    - `Enable-AzureDataCollection` (supported by `Enable-AzureRmDataCollection`)
    - `Disable-AzureDataCollection` (supported by `Disable-AzureRmDataCollection`)

## Version 2.8.0
* *Obsolete*: Save-AzureRmProfile is renamed to Save-AzureRmContext, there is an alias to the old cmdlet name, the alias will be removed in the next release.
* *Obsolete*: Select-AzureRmProfile is renamed to Import-AzureRmContext, there is an alias to the old cmdlet name, the alias will be removed in the next release.
* The PSAzureContext and PSAzureProfile output types of profile cmdlets will be changed in the next release.
* The Save-AzureRmContext cmdlet will have no OutputType in the next release.
* Fix bug in cmdlet common code to use FIPS-compliant algorithm for data hashes: https://github.com/Azure/azure-powershell/issues/3651

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
* Add-AzureRmAccount
    - Add position for Credential parameter so the following command is allowed: Add-AzureRmAccount (Get-Credential)
    - Updated parameter sets so the SubscriptionId and SubscriptionName are mutually exclusive
