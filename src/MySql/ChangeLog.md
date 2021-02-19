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

