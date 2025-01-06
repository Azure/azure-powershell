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

## Version 0.2.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.2.1
* Fixed an issue that updating password did not work.

## Version 0.2.0
* Removed legacy SkuSize from input and output [#12734]
* New/Update-AzMyMariaDbFirewallRule create a default name with time stamp when no name is passed [#12737]
* Added validateset for parameter StorageAutogrow [#12735]
* Renamed New-AzMySqlServerReplica to `New-AzMySqlReplica` [#12741]
* Used 'master' and 'replica' to avoid confusion when created mysql replica server [#12742]
* Provided hint in doc to use Update-AzMySqlServer & Update-AzMySqlServerConfiguration as a candidate for each other [#12744]
* Fixed secure string decryption issue in PowerShell 7 [#12954]

## Version 0.1.0
* the first preview release
