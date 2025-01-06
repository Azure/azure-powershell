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
* Updated the URL to download the SQL Assessment Zip to `https://aka.ms/sqlassessmentpackage`

## Version 0.14.8
* Removed Microsoft.Azure.Management.DataMigration 0.7.0-preview dependencies
* Added Microsoft.Azure.PowerShell.DataMigration.Management.Sdk

## Version 0.14.7
* Fixed secrets exposure in example documentation.

## Version 0.14.6
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.14.5
* Changed the Login Migration Console App source to NuGet.org and added versioning support for updating the console app.

## Version 0.14.4
* Added versioning to login migration console app.

## Version 0.14.3
* Supported console app automatically upgrade.

## Version 0.14.2
* Updated the description of command `New-AzDataMigrationToSqlDb` to inform the customers that they can use `New-AzDataMigrationSqlServerSchema` to do schema migration.

## Version 0.14.1
* Added client type to New-AzDataMigrationTdeCertificateMigration
## Version 0.14.0
* Added new cmdlet `New-AzDataMigrationSqlServerSchema` to migrate Sql Server Schema from the source Sql Servers to the target Azure Sql Servers

## Version 0.13.0
* Added the custom cmdlet for TDE Migration: `New-AzDataMigrationTdeCertificateMigration`

## Version 0.12.1
* Updated the link of storage account for users to download LoginsMigration.zip file.

## Version 0.12.0
* Added custom cmdlets for LoginsMigration:
  - New-AzDataMigrationLoginsMigration

## Version 0.11.0
* Added an optional `Time` parameter to `Get-AzDataMigrationPerformanceDataCollection` to stop the perf collection after the given time 

## Version 0.10.0
* Added support for migrating SQL Server databases to Azure SQL DB
* Used `System.Security.SecureString` for secrets and passwords

## Version 0.9.0
* Added custom cmdlets for SKU recommendation
    - `Get-AzDataMigrationPerformanceDataCollection`
    - `Get-AzDataMigrationSkuRecommendation`

## Version 0.8.0
* Added cmdlets:
 - `Get-AzDataMigrationAssessment`
 - `Get-AzDataMigrationSqlService`
 - `Get-AzDataMigrationSqlServiceAuthKey`
 - `Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric`
 - `Get-AzDataMigrationSqlServiceMigration`
 - `Get-AzDataMigrationToSqlManagedInstance`
 - `Get-AzDataMigrationToSqlVM`
 - `Invoke-AzDataMigrationCutoverToSqlManagedInstance`
 - `Invoke-AzDataMigrationCutoverToSqlVM`
 - `New-AzDataMigrationSqlService`
 - `New-AzDataMigrationSqlServiceAuthKey`
 - `New-AzDataMigrationToSqlManagedInstance`
 - `New-AzDataMigrationToSqlVM`
 - `Register-AzDataMigrationIntegrationRuntime`
 - `Remove-AzDataMigrationSqlService`
 - `Remove-AzDataMigrationSqlServiceNode`
 - `Stop-AzDataMigrationToSqlManagedInstance`
 - `Stop-AzDataMigrationToSqlVM`
 - `Update-AzDataMigrationSqlService`

## Version 0.7.4
* Update references in .psd1 to use relative path

## Version 0.7.3
* Fixed miscellaneous typos across module

## Version 0.7.2
* Added `New-AzDataMigrationAzureActiveDirectoryApp` cmdlet
    - Used as input for MI online sync migration
