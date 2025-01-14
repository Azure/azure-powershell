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

## Version 1.2.1
* Fixed secrets exposure in example documentation.

## Version 1.2.0
* Added cmdlets: `Get-AzMySqlFlexibleServerAdvancedThreatProtectionSetting` and `Update-AzMySqlFlexibleServerAdvancedThreatProtectionSetting`

## Version 1.1.2
* Fixed for various docs erroneously pointing to Postgres instead of MySQL

## Version 1.1.1
* Fixed iops and high availability parameters issue

## Version 1.1.0
* Added `PublicNetworkAccess` to `Update-AzMySqlServer` [#19189]

## Version 1.0.0
* General availability of Az.MySql

## Version 0.8.0
* Changed API version to 2021-05-01
* Fixed bugs for location capabilities

## Version 0.7.0
* Resolved Cx provisiong failure incident caused by backend server minimum storage change (10gb to 20gb)
* Fixed doc of `Update-AzMySqlFlexibleServerConfiguration` [#15516]

## Version 0.6.0
* Added maintenance windows parameter to Update-AzMySqlFlexibleServer cmdlet
* Added zone parameter to server New-AzMySqlFlexibleServer cmdlet.

## Version 0.5.0
* Added cmdlet `Test-AzMySqlFlexibleServerConnect`

## Version 0.4.0
* Updated New-AzMySqlFlexibleServer cmdlet to provide easy resource group and network management within RDBMS flexible server management
* Added new cmdlets Get-AzMySqlFlexibleServerLocationBasedCapability and Get-AzMySqlConnectionString
* Added parameter MinimalTlsVersion

## Version 0.3.1
* Fixed secure string issue

## Version 0.3.0
* Added MySql flexible server cmdlets

## Version 0.2.0
* Removed legacy SkuSize from input and output (#11725)
* Added AllowAll & ClientIpAddress Modes to firewall rule cmdlets (#11932)
* specified a default name when created MySql firewall rule without a name (#11932)
* Added validateset for parameter StorageAutogrow (#11936)
* Renamed New-AzMySqlServerReplica to New-AzMySqlReplica (#11938)
* Used 'master' and 'replica' to avoid confusion when created mysql replica server (#11939)
* Provided hint in doc to use Update-AzMySqlServer & Update-AzMySqlServerConfiguration as a candidate for each other (#11954)

## Version 0.1.0
* The first preview release

