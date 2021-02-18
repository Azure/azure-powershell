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

