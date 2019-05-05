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

## Version 2.0.0
* Removed the `Grant-AzHDInsightHttpServicesAccess` and `Revoke-AzHDInsightHttpServicesAccess` cmdlets. These are no longer necessary because HTTP access is always enabled on all HDInsight clusters.
* Added a new `Set-AzHDInsightGatewayCredential`  cmdlet. Use this cmdlet to change the gateway HTTP username and password (replaces `Grant-AzHDInsightHttpServicesAccess`).
* Updated the `Get-AzHDInsightJobOutput` cmdlet to support granular role-based access to the storage key.
    - Users with HDInsight Cluster Operator, Contributor, or Owner roles will not be affected.
    - Users with only the Reader role will need to specify `DefaultStorageAccountKey` parameter explicitly.

For more information about these role-based access changes, see [aka.ms/hdi-config-update](http://aka.ms/hdi-config-update)


## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.0
* General availability of `Az.HDInsight` module
