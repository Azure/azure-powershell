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