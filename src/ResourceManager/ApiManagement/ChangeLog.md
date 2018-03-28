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
