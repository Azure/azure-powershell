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

## Version 0.5.12
* This module is outdated and will go out of support on 29 February 2024.
* The Az.DataFactoryV2 module has all the capabilities of AzureRM.DataFactoryV2 and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 0.5.11
* Updated the ADF .Net SDK version to 2.3.0.

## Version 0.5.10
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 0.5.9
* Fixed issue with default resource groups not being set.

## Version 0.5.8
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.5.7
* Updated all help files to include full parameter types and correct input/output types.
* Updated the ADF .Net SDK version to 2.0.0.
* Support self-hosted integration runtime sharing across data factories.
     - Add new parameter ``SharedIntegrationRuntimeResourceId`` to Set-AzureRmDataFactoryV2IntegrationRuntime cmdlet.
     - Add new optional parameter ``LinkedDataFactoryName`` to Remove-AzureRmDataFactoryV2IntegrationRuntime cmdlet.

## Version 0.5.6
* Fixed formatting of OutputType in help files

## Version 0.5.5
* Updated the ADF .Net SDK version to 0.8.0-preview containing following changes:
    - Added Configure factory repository operation
    - Updated QuickBooks LinkedService to expose consumerKey and consumerSecret properties
    - Updated Several model types from SecretBase to Object
    - Added Blob Events trigger

## Version 0.5.4
* Set minimum dependency of module to PowerShell 5.0
* Updated the ADF .Net SDK version to 0.7.0-preview containing following changes:
    - Added execution parameters and connection managers property on ExecuteSSISPackage Activity
    - Updated PostgreSql, MySql llinked service to use full connection string instead of server, database, schema, username and password
    - Removed the schema from DB2 linked service
    - Removed schema property from Teradata linked service
    - Added LinkedService, Dataset, CopySource for Responsys

## Version 0.5.3
* Updated to the latest version of the Azure ClientRuntime

## Version 0.5.2
* Updated the ADF .Net SDK to version 0.6.0-preview containing the following changes:
    - Added new AzureDatabricks LinkedService and DatabricksNotebook Activity
    - Added headNodeSize and dataNodeSize properties in HDInsightOnDemand LinkedService
    - Added LinkedService, Dataset, CopySource for SalesforceMarketingCloud
    - Added support for SecureOutput on all activities
    - Added new BatchCount property on ForEach activity which control how many concurrent activities to run
    - Added new Filter Activity
    - Added Linked Service Parameters support

## Version 0.5.1
* Add parameter 'SetupScriptContainerSasUri' and 'Edition' for 'Set-AzureRmDataFactoryV2IntegrationRuntime' cmd to enable custom setup and edition selection functionality
* Fix credential encryption issue that caused no meaningful error for some encryption operations.
* Enable integration runtime to be shared across data factory

## Version 0.5.0
* Enabled Azure Key Vault support for all data store linked services
* Added license type property for Azure SSIS integration runtime
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Add parameter "LicenseType" for "Set-AzureRmDataFactoryV2IntegrationRuntime" cmd to enable AHUB functionality

## Version 0.4.1
* Added two new cmdlets: Update-AzureRmDataFactoryV2 and Stop-AzureRmDataFactoryV2PipelineRun

## Version 0.3.0
* Azure DataFactory PowerShell cmdlets for ADF V2 Private Preview
