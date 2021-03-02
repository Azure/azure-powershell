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

## Version 6.1.8
* This module is outdated and will go out of support on 29 February 2024.
* The Az.ApiManagement module has all the capabilities of AzureRM.ApiManagement and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 6.1.6
* Update dependencies for type mapping issue

## Version 6.1.5
* Fixed issue with default resource groups not being set.
* Fixed issue https://github.com/Azure/azure-powershell/issues/6603
    - Import-AzureRmApiManagementApi and *-AzureRmApiManagementCertificate cmdlets now handle relative Paths
* Fixed issue https://github.com/Azure/azure-powershell/issues/6879
    - The CertificateInformation is a settable property allowing for Set-AzureRmApiManagement cmdlet to work property. Fixed by upgrading to 
	4.0.4-preview nuget
* Fixed issue https://github.com/Azure/azure-powershell/issues/6853
    - Fixed the Odata filter for Search by Name on Product
* Fixed issue https://github.com/Azure/azure-powershell/issues/6814
    - Fixed the Odata filter for Search by Name on Api
* Added support for AzureMonitor logger
* Updated common runtime assemblies


## Version 6.1.4
* Fixed issue with default resource groups not being set.
* Fixed issue https://github.com/Azure/azure-powershell/issues/6603
    - Import-AzureRmApiManagementApi and *-AzureRmApiManagementCertificate cmdlets now handle relative Paths
* Fixed issue https://github.com/Azure/azure-powershell/issues/6879
    - The CertificateInformation is a settable property allowing for Set-AzureRmApiManagement cmdlet to work property. Fixed by upgrading to 
	4.0.4-preview nuget
* Fixed issue https://github.com/Azure/azure-powershell/issues/6853
    - Fixed the Odata filter for Search by Name on Product
* Fixed issue https://github.com/Azure/azure-powershell/issues/6814
    - Fixed the Odata filter for Search by Name on Api
* Added support for AzureMonitor logger

## Version 6.1.3
* Updated to the latest version of the Azure ClientRuntime.

## Version 6.1.2
* Updated help files to include full parameter types and correct input/output types.
* Updated to the latest version of the Azure ClientRuntime.
* Fixed issue https://github.com/Azure/azure-powershell/issues/6370
    - Fixed bug in Automapper to translate PsApiManagementApi to ApiContract
* Fixed issue https://github.com/Azure/azure-powershell/issues/6515
    - Fixed bug in File.Save to not overload with Encoding Type
* Fixed issue https://github.com/Azure/azure-powershell/issues/6560
    - Upgraded to 4.0.3 Nuget version which fixes the pattern exception on apiId

## Version 6.1.1
* Fixed formatting of OutputType in help files

## Version 6.1.0
* Added support for ApiVersions, ApiReleases and ApiRevisions
* Added suppport for ServiceFabric Backend
* Added support for Application Insights Logger
* Added support for recognizing `Basic` sku as a valid sku of Api Management service
* Added support for installing Certificates issued by private CA as Root or CA
* Added support for accepting Custom SSL certificates via KeyVault and Multiple proxy hostnames
* Added support for MSI identity
* Added support for accepting Policies via Url
NOTE: The following cmdlets will be deprecated in future release
   - Import-AzureRmApiManagementHostnameCertificate
   - New-AzureRmApiManagementHostnameConfiguration
   - Set-AzureRmApiManagementHostnames
   - Update-AzureRmApiManagementDeployment

## Version 6.0.0
* Set minimum dependency of module to PowerShell 5.0
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

## Version 5.1.2
* Updated to the latest version of the Azure ClientRuntime

## Version 5.1.1
* Fix issue with Default Resource Group in CloudShell

## Version 5.1.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmApiManagementProperty, Set-AzureRmApiManagementProperty, and New-AzureRmApiManagement

## Version 5.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 5.0.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of breaking changes introduced.
* Breaking Changes in Cmdlet to Manage Api Management Users
    - New-AzureRmApiManagementUser Parameter `Password` is changed from String to SecureString
    - Set-AzureRmApiManagementBackend Parameter `Password` is changed from String to SecureString
* Breaking Changes in Cmdlet to Create Backend Proxy Object
    - New-AzureRmApiManagementBackendProxy Parameter `Password` and `UserName` have been replaced with `ProxyCredentials` of type PSCredential
* Updated Cmdlet Get-AzureRmApiManagementUser to fix issue https://github.com/Azure/azure-powershell/issues/4510
* Updated Cmdlet New-AzureRmApiManagementApi to create Api with Empty Path https://github.com/Azure/azure-powershell/issues/4069
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 4.4.1

## Version 4.4.0

## Version 4.3.1

## Version 4.3.0

## Version 4.2.1

## Version 4.2.0

## Version 4.1.0

## Version 4.0.1

## Version 4.0.0
* Added support for configuring external groups in New-AzureRmApiManagementGroup.

## Version 3.6.0

## Version 3.5.0
* Added new cmdlets to manage Backend entity
    - New-AzureRmApiManagementBackend
    - Get-AzureRmApiManagementBackend
    - Set-AzureRmApiManagementBackend
    - Remove-AzureRmApiManagementBackend
* Created supporting cmdlets to create in-memory objects required while Creating or Updating Backend entity
    - New-AzureRmApiManagementBackendCredential
    - New-AzureRmApiManagementBackendProxy

## Version 3.4.0

## Version 3.3.0

## Version 3.2.0
* Added new cmdlets to manage external Identity Provider Configurations
    - New-AzureRmApiManagementIdentityProvider
    - Set-AzureRmApiManagementIdentityProvider
    - Get-AzureRmApiManagementIdentityProvider
    - Remove-AzureRmApiManagementIdentityProvider
* Updated the client to use .net client 3.2.0 AzureRm.ApiManagement which has RBAC support
* Updated cmdlet Import-AzureRmApiManagementApi to allow importing an Wsdl type API as either Soap Pass Through (ApiType = Http) or Soap To Rest (ApiType = Soap). Default is Soap Pass Through.
* Fixed Issue https://github.com/Azure/azure-powershell/issues/3217

## Version 3.1.0
* Fixed cmdlet Import-AzureRmApiManagementApi when importing Api by SpecificationByUrl parameter
* New-AzureRmApiManagement supports creating an ApiManagement service in a VirtualNetwork and with additional regions
