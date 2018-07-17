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
Azure Data Factory new capabilities now fall under General Availability SLA. ADF has made cloud data integration easier than ever before. Build, schedule and manage data integration at scale wherever your data lives, in cloud or on-premises, with enterprise-grade security.?Accelerate your data integration projects with over 70 data source connectors available. Transform raw data into finished, shaped data that is ready for consumption by BI tools or custom applications. Easily lift your SQL Server Integration Services (SSIS) packages to Azure and let ADF manage your resources for you so you can increase productivity and lower TCO.?Meet your security and compliance needs while taking advantage of extensive capabilities and paying only for what you use. The ADF GA SDK changes includes the following:
* Updated the ADF .Net SDK version to 1.1.0 containing following changes:
    - The API 'removeNode' on IR has been removed and replaced with DELETE API on IR node.
    - 'GET activity runs' using pipeline run id has been replaced with POST query activity runs. It takes RunFilterParameters object in the body with more options to query and order the result.
    - 'GET trigger runs' using pipeline run id has been replaced with POST query trigger runs and doesn't require trigger names anymore. It takes RunFilterParameters object in the body similar to query activity runs.
    - 'CancelPipelineRun' has been moved to PipelineRuns operations and renamed to 'Cancel'.
    - 'ConfigureFactoryRepo' now accepts github configuration too.
    - The error response format has been changed. It is now compliant with other Azure ARM services. Before the API-s were returning ErrorResponse object with code, message, target and details. Now, it returns CloudError object with another "error" object nested inside that contains code, message, target and details.
    - Added If-Match header support on put calls and If-None-Match header support for get calls for ADF resources and sub resources.
    - The response of PATCH on IR has been fixed to return IR resource.
* Updated help files to include full parameter types.

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
