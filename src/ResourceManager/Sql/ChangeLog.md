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
    * Overview of change #3213
        - This change includes the changes to implement read scale feature for azure sql databases.
        - The influenced cmdlets are: New-AzureRmSqlDatabase, Set-AzureRmSqlDatabase, Get-AzureRmSqlDatabase
        - The newly added read scale functionality allows customers to enabled read-only access to Geo Secondary databases.
        - The implmentation adds a new member in the Database Properties, called "ReadScale". It supports 2 values: Enabled/Disabled.
## Version 2.3.0
