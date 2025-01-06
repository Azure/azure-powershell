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

## Version 1.1.2
* Fixed secrets exposure in example documentation.

## Version 1.1.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.1.0
* Added parameter PublicNetworkAccess for PostgreSQL single server related cmdlets [#17263]

## Version 1.0.0
* General availability of Az.PostgreSql

## Version 0.8.0
* Removed `Location` in `Restore-AzPostgreSqlFlexibleServer`
* Minor fixes for `Get-AzPostgreSqlFlexibleServerLocationBasedCapability`, `Test-AzPostgreSqlFlexibleServerConnect` and `New-AzPostgreSqlFlexibleServer`

## Version 0.7.0
* Changed default New-AzMySqlFlexibleServer network option from private access to public access
* Migrated to 2020-07-01-preview API version to 2021-05-01-preview version
* Added subnet , private DNS zone parameters for Restore-AzMySqlFlexibleServer cmdlet
* Added cmdlets for flexible server database
    - Get-AzPostgreSqlFlexibleServerDatabase
    - New-AzPostgreSqlFlexibleServerDatabase
    - Remove-AzPostgreSqlFlexibleServerDatabase   

## Version 0.6.0
* Migrated from 20200214 preview API to 20210601 API
* Changed default database create experience to public access from private access

## Version 0.5.0
* Added maintenance windows parameter to Update-AzPostgreSqlFlexibleServer cmdlet
* Added zone parameter to server New/Restore-PostgresSqlFlexibleServer cmdlet.

## Version 0.4.0
* Added cmdlet `Test-AzPostgreSqlFlexibleServerConnect`

## Version 0.3.0
* Add parameter MinimalTlsVersion
* First version of flexible server

## Version 0.2.0
* New/Update-AzPostgreSqlFirewallRule create a default name with time stamp when no name is passed (#12738)
* Added validateset for parameter StorageAutogrow (#12736)
* Used 'master' and 'replica' to avoid confusion when created postgresql replica server (#12743)
* Provided hint in doc to use Update-AzPostgreSqlServer & Update-AzPostgreSqlServerConfiguration as a candidate for each other (#12745)
* Fix secure string decrytion issue in PowerShell 7 (#12956)

## Version 0.1.0
* the first preview release

