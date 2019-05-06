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
* Removed two cmdlets:
    - Grant-AzHDInsightHttpServicesAccess
    - Revoke-AzHDInsightHttpServicesAccess
* Added a new cmdlet Set-AzHDInsightGatewayCredential to replace Grant-AzHDInsightHttpServicesAccess
* Update cmdlet Get-AzHDInsightJobOutput to distinguish reader role and hdinsight operator role:
    - Users with reader role need to specify `DefaultStorageAccountKey` parameter explicitly, otherwise error occurs.
	- Users with hdinsight operator role will not be affected.


## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.0
* General availability of `Az.HDInsight` module
