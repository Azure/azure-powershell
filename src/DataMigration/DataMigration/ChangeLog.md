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
